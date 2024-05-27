using EnglishApplication.Application.Dto;

namespace EnglishApplication.Application.Services.Interfaces;

public interface ISessionService
{
    Task<SessionDto> GetByIdAsync(int id);
    Task<ICollection<SessionDto>> GetByUserIdAsync(int id);
    Task<RoundDto> GetCurrentRoundAsync(int sessionId);
    Task<SessionDto> GetActiveByUserIdAsync(int id);
    Task<ICollection<RoundDto>> GetRoundsByIdAsync(int id);
    Task<SessionDto> CreateAsync(int userId);
    Task<SessionDto> GuessCurrentWordAsync(int sessionId, string word);
    Task<SessionDto> AddRoundAsync(int sessionId, int userId);
}