using EnglishApplication.Application.Dto;
using EnglishApplication.Application.Dto.Mappers;
using EnglishApplication.Application.RabbitMq.Messages;
using EnglishApplication.Application.Services.Interfaces;
using EnglishApplication.Domain.Entities;
using EnglishApplication.Domain.Exceptions.Round;
using EnglishApplication.Domain.Exceptions.Session;
using EnglishApplication.Domain.Repositories;
using MassTransit;

namespace EnglishApplication.Application.Services;

public class SessionService(ISessionRepository sessionRepository,
    IWordRepository wordRepository,
    IRoundRepository roundRepository,
    IUserInfoRepository userInfoRepository,
    IPublishEndpoint bus) : ISessionService
{
    private const int PointsPerAnswer = 100;
    private const int Delay = 30000;
    private const int MaxRounds = 5;

    public async Task<SessionDto> GetByIdAsync(int id)
    {
        var candidate = await sessionRepository.GetByIdAsync(id);

        if (candidate is null) throw SessionNotFoundException.WithSuchId(id);

        return candidate.ToDto();
    }

    public async Task<ICollection<SessionDto>> GetByUserIdAsync(int id)
    {
        var candidate = await sessionRepository.GetByUserIdAsync(id);

        return candidate.Select(SessionMapper.ToDto).ToList();
    }

    public async Task<RoundDto> GetCurrentRoundAsync(int sessionId)
    {
        var candidate = await sessionRepository.GetByIdAsync(sessionId);

        if (candidate is null) throw SessionNotFoundException.WithSuchId(sessionId);

        return candidate.Rounds.MaxBy(r => r.StartTime).ToDto();
    }

    public async Task<SessionDto> GetActiveByUserIdAsync(int id)
    {
        var candidate = await sessionRepository.GetActiveByUserIdAsync(id);

        if (candidate is null) throw new SessionNotFoundException("Active session not found");

        return candidate.ToDto();
    }

    public async Task<ICollection<RoundDto>> GetRoundsByIdAsync(int id)
    {
        var candidate = await sessionRepository.GetByIdAsync(id);

        return candidate.Rounds.Select(RoundMapper.ToDto).ToList();
    }

    public async Task<SessionDto> CreateAsync(int userId)
    {
        if ((await sessionRepository.GetActiveByUserIdAsync(userId)) is not null)
            throw new SessionActiveAlreadyExistsException();

        var candidate = await sessionRepository.CreateAsync(userId);
        var currentRound = await GetCurrentRoundAsync(candidate.Id);

        bus.Publish(new SessionNextRoundMessage { SessionId = candidate.Id, CurrentRoundId = currentRound.Id },
            context => { context.Headers.Set("x-delay", Delay); });

        return candidate.ToDto();
    }

    public async Task<SessionDto> GuessCurrentWordAsync(int sessionId, string word)
    {
        var candidate = await sessionRepository.GetByIdAsync(sessionId);

        if (candidate is null) throw SessionNotFoundException.WithSuchId(sessionId);
        if (!candidate.Active) throw new SessionIsNotActiveException();

        var now = DateTime.Now.ToUniversalTime();

        var currentRound = await GetCurrentRoundAsync(sessionId);

        if (now > currentRound.EndTime) throw new RoundIsOverException();

        currentRound.Guessed = currentRound.Word.Russian == word.TrimStart().TrimEnd().ToLower();
        currentRound.EndTime = now;

        candidate.Rounds = candidate.Rounds
            .Where(r => r.Id != currentRound.Id)
            .Append(currentRound.ToDb()).ToList();

        if (candidate.Rounds.Count >= MaxRounds)
        {
            candidate.Active = false;
            await sessionRepository.UpdateAsync(candidate, candidate.Id);

            if (candidate.UserInfo.LastSolved is null)
            {
                candidate.UserInfo.LastSolved = now.Date;
                candidate.UserInfo.Streak = 1;
            }
            else if (candidate.UserInfo.LastSolved.GetValueOrDefault().AddDays(1) == now.Date)
            {
                candidate.UserInfo.LastSolved = now.Date;
                candidate.UserInfo.Streak++;
            }
            else if (candidate.UserInfo.LastSolved.GetValueOrDefault() == now.Date)
            {
                // ignored
            }
            else
            {
                candidate.UserInfo.LastSolved = now.Date;
                candidate.UserInfo.Streak = 0;
            }

            candidate.UserInfo.Points += candidate.Rounds.Count(r => r.Guessed.GetValueOrDefault()) * PointsPerAnswer;

            await userInfoRepository.UpdateAsync(candidate.UserInfo, candidate.UserInfoId);

            return await GetByIdAsync(candidate.Id);
        }

        await sessionRepository.UpdateAsync(candidate, candidate.Id);

        var addRound = await AddRoundAsync(sessionId, candidate.UserInfoId);
        var newRound = await GetCurrentRoundAsync(addRound.Id);

        if (addRound.Active)
        {
            bus.Publish(new SessionNextRoundMessage { SessionId = candidate.Id, CurrentRoundId = newRound.Id },
                context => { context.Headers.Set("x-delay", Delay); });
        }

        return addRound;
    }

    public async Task<SessionDto> AddRoundAsync(int sessionId, int userId)
    {
        var candidate = await sessionRepository.GetByIdAsync(sessionId);

        if (candidate is null) throw SessionNotFoundException.WithSuchId(sessionId);

        var startTime = DateTime.Now.ToUniversalTime();

        await roundRepository.CreateAsync(new DbRound
        {
            SessionId = sessionId,
            WordId = (await wordRepository.GetRandomNotGuessedWordAsync(userId)).Id,
            StartTime = startTime
        });

        return await GetByIdAsync(sessionId);
    }

    public async Task<SessionDto> MoveNextRoundAsync(int sessionId)
    {
        var candidate = await sessionRepository.GetByIdAsync(sessionId);

        if (candidate is null) throw SessionNotFoundException.WithSuchId(sessionId);

        var currentRound = await GetCurrentRoundAsync(sessionId);

        var now = DateTime.Now.ToUniversalTime();

        currentRound.Guessed = false;
        currentRound.EndTime = now;

        candidate.Rounds = candidate.Rounds
            .Where(r => r.Id != currentRound.Id)
            .Append(currentRound.ToDb()).ToList();

        if (candidate.Rounds.Count >= MaxRounds)
        {
            candidate.Active = false;
            await sessionRepository.UpdateAsync(candidate, candidate.Id);

            if (candidate.UserInfo.LastSolved is null)
            {
                candidate.UserInfo.LastSolved = now.Date;
                candidate.UserInfo.Streak = 1;
            }
            else if (candidate.UserInfo.LastSolved.GetValueOrDefault().AddDays(1) == now.Date)
            {
                candidate.UserInfo.LastSolved = now.Date;
                candidate.UserInfo.Streak++;
            }
            else if (candidate.UserInfo.LastSolved.GetValueOrDefault() == now.Date)
            {
                // ignored
            }
            else
            {
                candidate.UserInfo.LastSolved = now.Date;
                candidate.UserInfo.Streak = 0;
            }

            candidate.UserInfo.Points += candidate.Rounds.Count(r => r.Guessed.GetValueOrDefault()) * PointsPerAnswer;

            await userInfoRepository.UpdateAsync(candidate.UserInfo, candidate.UserInfoId);

            return await GetByIdAsync(candidate.Id);
        }

        await sessionRepository.UpdateAsync(candidate, candidate.Id);

        var addRound = await AddRoundAsync(sessionId, candidate.UserInfoId);
        var newRound = await GetCurrentRoundAsync(addRound.Id);

        bus.Publish(new SessionNextRoundMessage { SessionId = candidate.Id, CurrentRoundId = newRound.Id },
            context => { context.Headers.Set("x-delay", Delay); });

        return addRound;
    }
}