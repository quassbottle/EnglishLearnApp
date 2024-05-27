using EnglishApplication.Application.Dto;
using EnglishApplication.Application.Dto.Mappers;
using EnglishApplication.Application.Services.Interfaces;
using EnglishApplication.Domain.Exceptions.Round;
using EnglishApplication.Domain.Exceptions.Session;
using EnglishApplication.Domain.Repositories;

namespace EnglishApplication.Application.Services;

public class SessionService(ISessionRepository repository) : ISessionService
{
    public async Task<SessionDto> GetByIdAsync(int id)
    {
        var candidate = await repository.GetByIdAsync(id);

        if (candidate is null) throw SessionNotFoundException.WithSuchId(id);

        return candidate.ToDto();
    }

    public async Task<ICollection<SessionDto>> GetByUserIdAsync(int id)
    {
        var candidate = await repository.GetByUserIdAsync(id);

        return candidate.Select(SessionMapper.ToDto).ToList();
    }

    public async Task<RoundDto> GetCurrentRoundAsync(int sessionId)
    {
        var candidate = await repository.GetByIdAsync(sessionId);

        if (candidate is null) throw SessionNotFoundException.WithSuchId(sessionId);

        return candidate.Rounds.MaxBy(r => r.StartTime).ToDto();
    }

    public async Task<SessionDto> GetActiveByUserIdAsync(int id)
    {
        var candidate = await repository.GetActiveByUserIdAsync(id);

        if (candidate is null) throw new SessionNotFoundException("Active session not found");

        return candidate.ToDto();
    }

    public async Task<ICollection<RoundDto>> GetRoundsByIdAsync(int id)
    {
        var candidate = await repository.GetByIdAsync(id);

        return candidate.Rounds.Select(RoundMapper.ToDto).ToList();
    }

    public async Task<SessionDto> CreateAsync(int userId)
    {
        if (await repository.GetActiveByUserIdAsync(userId) is not null)
            throw new SessionActiveAlreadyExistsException();

        var candidate = await repository.CreateAsync(userId);

        return candidate.ToDto();
    }

    public async Task<SessionDto> GuessCurrentWordAsync(int sessionId, string word)
    {
        var candidate = await repository.GetByIdAsync(sessionId);

        if (candidate is null) throw SessionNotFoundException.WithSuchId(sessionId);

        var now = DateTime.Now.ToUniversalTime();

        var currentRound = await GetCurrentRoundAsync(sessionId);

        if (now > currentRound.EndTime) throw new RoundIsOverException();

        currentRound.Guessed = currentRound.Word.Russian == word.TrimStart().TrimEnd().ToLower();
        currentRound.EndTime = now;

        candidate.Rounds = candidate.Rounds
            .Where(r => r.Id != currentRound.Id)
            .Append(currentRound.ToDb()).ToList();

        var result = await repository.UpdateAsync(candidate, candidate.Id);

        return result.ToDto();
    }
}