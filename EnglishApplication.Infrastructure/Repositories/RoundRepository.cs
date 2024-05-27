using EnglishApplication.Domain.Entities;
using EnglishApplication.Domain.Repositories;
using EnglishApplication.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EnglishApplication.Infrastructure.Repositories;

public class RoundRepository(DefaultDataContext context) : IRoundRepository
{
    public async Task<DbRound> UpdateAsync(DbRound round, int id)
    {
        round.Id = id;

        await using var transaction = await context.Database.BeginTransactionAsync();

        context.Rounds.Update(round);
        await context.SaveChangesAsync();

        await transaction.CommitAsync();

        return await GetByIdAsync(id);
    }

    public async Task<DbRound> GetByIdAsync(int id)
    {
        var candidate = await context.Rounds
            .AsNoTracking()
            .Include(e => e.Word)
            .Include(e => e.Session)
            .FirstOrDefaultAsync(r => r.Id == id);

        return candidate;
    }

    public async Task<DbRound> CreateAsync(DbRound round)
    {
        var result = await context.Rounds.AddAsync(round);

        await context.SaveChangesAsync();

        return result.Entity;
    }
}