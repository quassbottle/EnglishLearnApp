using EnglishApplication.Domain.Entities;

namespace EnglishApplication.Domain.Repositories;

public interface IRoundRepository
{
    Task<DbRound> UpdateAsync(DbRound round, int id);
    Task<DbRound> GetByIdAsync(int id);
}