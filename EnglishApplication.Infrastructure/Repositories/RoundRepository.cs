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

        context.Rounds.Update(round);

        await context.SaveChangesAsync();

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

    public Task<DbRound> CreateAsync(DbRound round)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<DbRound>> GetByRoundIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}