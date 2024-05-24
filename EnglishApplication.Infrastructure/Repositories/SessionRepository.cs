using EnglishApplication.Domain.Entities;
using EnglishApplication.Domain.Repositories;
using EnglishApplication.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EnglishApplication.Infrastructure.Repositories;

public class SessionRepository(DefaultDataContext context) : ISessionRepository
{
    public async Task<Session> CreateAsync(Session session)
    {
        var result = await context.Sessions.AddAsync(session);
        
        await context.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<Session> GetByIdAsync(int id)
    {
        var candidate = await context.Sessions
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);

        return candidate;
    }

    public async Task<Session> UpdateAsync(Session session, int id)
    {
        session.Id = id;
        var result = context.Sessions.Update(session);
        
        await context.SaveChangesAsync();
        
        return result.Entity;
    }
}