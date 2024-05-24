using EnglishApplication.Domain.Entities;

namespace EnglishApplication.Domain.Repositories;

public interface ISessionRepository
{
    Task<Session> CreateAsync(Session session);
    Task<Session> UpdateAsync(Session session, int id);
    Task<Session> GetByIdAsync(int id);

}