using System.Linq.Expressions;
using EnglishApplication.Domain.Entities;
using EnglishApplication.Domain.Exceptions.Account;
using EnglishApplication.Domain.Repositories;
using EnglishApplication.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EnglishApplication.Infrastructure.Repositories;

public class AccountRepository(DefaultDataContext context) : IAccountRepository
{
    public async Task<DbAccount> GetByIdAsync(int id)
    {
        var candidate = await context.Accounts
            .AsNoTracking()
            .Include(a => a.UserInfo)
            .FirstOrDefaultAsync(a => a.Id == id);

        return candidate;
    }
    
    public async Task<DbAccount> GetByEmailAsync(string email)
    {
        var candidate = await context.Accounts
            .AsNoTracking()
            .Include(a => a.UserInfo)
            .FirstOrDefaultAsync(a => a.Email == email);

        return candidate;
    }


    public async Task<DbAccount?> CreateAsync(DbAccount? dbAccount)
    {
        if (await ExistsByEmailAsync(dbAccount.Email))
            throw AccountAlreadyExistsException.WithSuchEmail(dbAccount.Email);

        var result = await context.Accounts.AddAsync(dbAccount);

        await context.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<DbAccount?> UpdateAsync(DbAccount? dbAccount, int id)
    {
        if (!await ExistsByIdAsync(id)) throw AccountNotFoundException.WithSuchId(id);

        dbAccount.Id = id;
        var result = context.Accounts.Update(dbAccount);

        await context.SaveChangesAsync();

        return result.Entity;
    }

    public async Task RemoveAsync(int id)
    {
        if (!await ExistsByIdAsync(id)) throw AccountNotFoundException.WithSuchId(id);

        context.Accounts.Remove(new DbAccount { Id = id });

        await context.SaveChangesAsync();
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        var candidate = await context.Accounts
            .AsNoTracking()
            .FirstOrDefaultAsync(account => account.Email == email);

        return candidate is not null;
    }

    public async Task<bool> ExistsByIdAsync(int id)
    {
        var candidate = await context.Accounts
            .AsNoTracking()
            .FirstOrDefaultAsync(account => account.Id == id);

        return candidate is not null;
    }

    public Task<int> GetGuessedTimesByWordIdAsync(int userId, int wordId)
    {
        var candidate = context.Rounds
            .AsNoTracking()
            .Include(r => r.Session)
            .Where(r => r.Session.UserInfoId == userId)
            .Where(r => r.Guessed ?? false)
            .Include(r => r.Word)
            .Count(r => r.WordId == wordId);

        return Task.FromResult(candidate);
    }
}