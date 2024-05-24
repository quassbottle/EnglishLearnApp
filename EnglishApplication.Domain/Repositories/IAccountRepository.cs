using System.Linq.Expressions;
using EnglishApplication.Domain.Entities;

namespace EnglishApplication.Domain.Repositories;

public interface IAccountRepository
{
    Task<Account> GetByIdAsync(int id);
    Task<Account> CreateAsync(Account account);
    Task<Account> UpdateAsync(Account account, int id);
    Task RemoveAsync(int id);
    Task<bool> ExistsByEmailAsync(string email);
    Task<bool> ExistsByIdAsync(int id);
    Task<Account> FirstOrDefaultAsync(Expression<Func<Account, bool>> predicate);
}