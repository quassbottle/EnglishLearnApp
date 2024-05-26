using EnglishApplication.Domain.Entities;

namespace EnglishApplication.Domain.Repositories;

public interface IUserInfoRepository
{
    Task<bool> ExistsByUsernameAsync(string username);
    Task<bool> ExistsByIdAsync(int id);
    Task<DbUserInfo> UpdateAsync(DbUserInfo dbUserInfo, int id);
    Task<DbUserInfo> GetByIdAsync(int id);
    Task<DbUserInfo> GetByUsernameAsync(string username);
}