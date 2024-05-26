using EnglishApplication.Domain.Entities;

namespace EnglishApplication.Domain.Repositories;

public interface ISessionRepository
{
    Task<DbSession> CreateAsync(DbSession dbSession);
    Task<DbSession> UpdateAsync(DbSession dbSession, int id);
    Task<DbSession> GetByIdAsync(int id);

}