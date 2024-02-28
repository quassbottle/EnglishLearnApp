using EnglishApplication.Domain.Aggregate;

namespace EnglishApplication.Domain.Repositories;

public interface IUserInfoRepository
{
    Task<bool> ExistsByUsernameAsync(string username);
    Task<bool> ExistsByIdAsync(int id);
    Task<UserInfo> UpdateAsync(UserInfo userInfo, int id);
    Task<UserInfo> GetByIdAsync(int id);
    Task<UserInfo> GetByUsernameAsync(string username);
}