using EnglishApplication.Domain.Entities;
using EnglishApplication.Domain.Repositories;
using EnglishApplication.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EnglishApplication.Infrastructure.Repositories;

public class SessionRepository(DefaultDataContext context) : ISessionRepository
{
    public async Task<DbSession> CreateAsync(DbSession dbSession)
    {
        var result = await context.Sessions.AddAsync(dbSession);
        
        await context.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<DbSession> GetByIdAsync(int id)
    {
        var candidate = await context.Sessions
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);

        return candidate;
    }

    public async Task<DbSession> UpdateAsync(DbSession dbSession, int id)
    {
        dbSession.Id = id;
        var result = context.Sessions.Update(dbSession);
        
        await context.SaveChangesAsync();
        
        return result.Entity;
    }
}