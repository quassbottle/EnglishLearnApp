using EnglishApplication.Domain.Entities;

namespace EnglishApplication.Domain.Repositories;

public interface ISessionRepository
{
    Task<DbSession> CreateAsync(int userId);
    Task<DbSession> UpdateAsync(DbSession dbSession, int id);
    Task<DbSession> GetByIdAsync(int id);
    Task<ICollection<DbRound>> GetRoundsByIdAsync(int id);
    Task<ICollection<DbSession>> GetByUserIdAsync(int id);
    Task<DbSession> GetActiveByUserIdAsync(int id);
}