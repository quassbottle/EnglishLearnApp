using System.Linq.Expressions;
using EnglishApplication.Domain.Entities;

namespace EnglishApplication.Domain.Repositories;

public interface IAccountRepository
{
    Task<DbAccount> GetByIdAsync(int id);
    Task<DbAccount?> CreateAsync(DbAccount? dbAccount);
    Task<DbAccount?> UpdateAsync(DbAccount? dbAccount, int id);
    Task RemoveAsync(int id);
    Task<bool> ExistsByEmailAsync(string email);
    Task<bool> ExistsByIdAsync(int id);
    Task<DbAccount> GetByEmailAsync(string email);
    Task<int> GetGuessedTimesByWordIdAsync(int userId, int wordId);
}