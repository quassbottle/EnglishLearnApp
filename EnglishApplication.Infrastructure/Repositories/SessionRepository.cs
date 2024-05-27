using EnglishApplication.Domain.Entities;
using EnglishApplication.Domain.Repositories;
using EnglishApplication.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EnglishApplication.Infrastructure.Repositories;

public class SessionRepository(DefaultDataContext context, IWordRepository wordRepository) : ISessionRepository
{
    public async Task<DbSession> CreateAsync(int userId)
    {
        var startTime = DateTime.Now.ToUniversalTime();

        var result = await context.Sessions
            .AddAsync(new DbSession
            {
                UserInfoId = userId,
                Rounds = new List<DbRound>
                {
                    new()
                    {
                        StartTime = startTime,
                        WordId = (await wordRepository.GetRandomNotGuessedWordAsync(userId)).Id
                    }
                }
            });

        await context.SaveChangesAsync();

        return await GetByIdAsync(result.Entity.Id);
    }

    public async Task<DbSession> GetByIdAsync(int id)
    {
        var candidate = await context.Sessions
            .AsNoTracking()
            .Include(e => e.Rounds)
            .ThenInclude(r => r.Word)
            .Include(e => e.UserInfo)
            .FirstOrDefaultAsync(e => e.Id == id);

        return candidate;
    }

    public async Task<ICollection<DbRound>> GetRoundsByIdAsync(int id)
    {
        var candidate = await context.Sessions
            .AsNoTracking()
            .Include(e => e.Rounds)
            .ThenInclude(r => r.Word)
            .FirstOrDefaultAsync(e => e.Id == id);

        return candidate.Rounds ?? new List<DbRound>();
    }

    public async Task<ICollection<DbSession>> GetByUserIdAsync(int id)
    {
        var candidate = await context.Sessions
            .AsNoTracking()
            .Include(e => e.Rounds)
            .ThenInclude(r => r.Word)
            .Include(e => e.UserInfo)
            .Where(e => e.UserInfoId == id)
            .ToListAsync();

        return candidate;
    }

    public async Task<DbSession> GetActiveByUserIdAsync(int id)
    {
        var candidate = await context.Sessions
            .AsNoTracking()
            .Include(e => e.Rounds)
            .ThenInclude(r => r.Word)
            .Include(e => e.UserInfo)
            .OrderByDescending(e =>
                e.Rounds.OrderByDescending(r => r.StartTime).FirstOrDefault())
            .FirstOrDefaultAsync(e => e.Active);

        return candidate;
    }

    public async Task<DbSession> UpdateAsync(DbSession dbSession, int id)
    {
        dbSession.Id = id;
        
        await using var transaction = await context.Database.BeginTransactionAsync();

        context.Sessions.Update(dbSession);
        await context.SaveChangesAsync();

        await transaction.CommitAsync();

        return await GetByIdAsync(id);
    }
}