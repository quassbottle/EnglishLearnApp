using EnglishApplication.Domain.Entities;
using EnglishApplication.Domain.Exceptions.UserInfo;
using EnglishApplication.Domain.Repositories;
using EnglishApplication.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EnglishApplication.Infrastructure.Repositories;

public class UserInfoRepository(DefaultDataContext context) : IUserInfoRepository
{
    public async Task<bool> ExistsByUsernameAsync(string username)
    {
        var candidate = await context.UserInfos.FirstOrDefaultAsync(ui => ui.Username == username);
        return candidate is not null;
    }

    public async Task<bool> ExistsByIdAsync(int id)
    {
        var candidate = await context.UserInfos
            .AsNoTracking()
            .FirstOrDefaultAsync(ui => ui.Id == id);

        return candidate is not null;
    }

    public async Task<DbUserInfo> UpdateAsync(DbUserInfo dbUserInfo, int id)
    {
        if (!await ExistsByIdAsync(id)) throw UserNotFoundException.WithSuchId(id);

        dbUserInfo.Id = id;
        var result = context.UserInfos.Update(dbUserInfo);

        await context.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<DbUserInfo> GetByIdAsync(int id)
    {
        var candidate = await context.UserInfos
            .AsNoTracking()
            .FirstOrDefaultAsync(ui => ui.Id == id);

        return candidate;
    }

    public async Task<DbUserInfo> GetByUsernameAsync(string username)
    {
        var candidate = await context.UserInfos
            .AsNoTracking()
            .FirstOrDefaultAsync(ui => ui.Username == username);

        return candidate;
    }

    public Task<int> GetGuessedTimesAsync(int id)
    {
        throw new NotImplementedException();
    }
}