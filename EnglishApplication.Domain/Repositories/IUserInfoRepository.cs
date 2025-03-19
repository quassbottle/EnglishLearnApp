using EnglishApplication.Domain.Entities;

namespace EnglishApplication.Domain.Repositories;

/// <summary>
/// Представляет интерфейс репозитория для работы с информацией о пользователях.
/// </summary>
public interface IUserInfoRepository
{
    /// <summary>
    /// Обновляет информацию о пользователе.
    /// </summary>
    Task<DbUserInfo> UpdateAsync(DbUserInfo dbUserInfo, int id);
}