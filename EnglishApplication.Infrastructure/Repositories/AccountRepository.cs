using EnglishApplication.Domain.Aggregate;
using EnglishApplication.Domain.Exceptions.Account;
using EnglishApplication.Domain.Repositories;
using EnglishApplication.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EnglishApplication.Infrastructure.Repositories;

public class AccountRepository(DefaultDataContext context) : IAccountRepository
{
    public async Task<Account> GetByIdAsync(int id)
    {
        var candidate = await context.Accounts.FindAsync(id);
        
        if (candidate is null)
        {
            throw AccountNotFoundException.WithSuchId(id);
        }

        return candidate;
    }

    public async Task<Account> CreateAsync(Account account)
    {
        if (await ExistsByEmailAsync(account.Email))
        {
            throw AccountAlreadyExistsException.WithSuchEmail(account.Email);
        }

        var result = await context.Accounts.AddAsync(account);
        
        await context.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<Account> UpdateAsync(Account account, int id)
    {
        if (!await ExistsByIdAsync(id))
        {
            throw AccountNotFoundException.WithSuchId(id);
        }

        account.Id = id;
        var result = context.Accounts.Update(account);
        
        await context.SaveChangesAsync();
        
        return result.Entity;
    }

    public async Task RemoveAsync(int id)
    {
        if (!await ExistsByIdAsync(id))
        {
            throw AccountNotFoundException.WithSuchId(id);
        }
        
        context.Accounts.Remove(new Account { Id = id });
        
        await context.SaveChangesAsync();
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        var candidate = await context.Accounts.FirstOrDefaultAsync(account => account.Email == email);
        return candidate is not null;
    }

    public async Task<bool> ExistsByIdAsync(int id)
    {
        var candidate = await context.Accounts.FindAsync(id);
        return candidate is not null;
    }
}