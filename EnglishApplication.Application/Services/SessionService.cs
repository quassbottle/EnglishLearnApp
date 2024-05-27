using EnglishApplication.Application.Dto;
using EnglishApplication.Application.Dto.Mappers;
using EnglishApplication.Application.Services.Interfaces;
using EnglishApplication.Domain.Entities;
using EnglishApplication.Domain.Exceptions.Round;
using EnglishApplication.Domain.Exceptions.Session;
using EnglishApplication.Domain.Repositories;

namespace EnglishApplication.Application.Services;

public class SessionService(ISessionRepository sessionRepository, IWordRepository wordRepository, IRoundRepository roundRepository) : ISessionService
{
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

        return candidate.ToDto();
    }

    public async Task<SessionDto> GuessCurrentWordAsync(int sessionId, string word)
    {
        var candidate = await sessionRepository.GetByIdAsync(sessionId);

        if (candidate is null) throw SessionNotFoundException.WithSuchId(sessionId);

        var now = DateTime.Now.ToUniversalTime();

        var currentRound = await GetCurrentRoundAsync(sessionId);

        if (now > currentRound.EndTime) throw new RoundIsOverException();

        currentRound.Guessed = currentRound.Word.Russian == word.TrimStart().TrimEnd().ToLower();
        currentRound.EndTime = now;

        candidate.Rounds = candidate.Rounds
            .Where(r => r.Id != currentRound.Id)
            .Append(currentRound.ToDb()).ToList();

        if (candidate.Rounds.Count >= 5)
        {
            candidate.Active = false;
            await sessionRepository.UpdateAsync(candidate, candidate.Id);

            return await GetByIdAsync(candidate.Id);
        }

        await sessionRepository.UpdateAsync(candidate, candidate.Id);

        return await AddRoundAsync(candidate.Id, candidate.UserInfoId);
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
            StartTime = startTime,
            EndTime = startTime.AddSeconds(30)
        });

        return await GetByIdAsync(sessionId);
    }
}