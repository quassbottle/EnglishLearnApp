using EnglishApplication.Domain.Entities;

namespace EnglishApplication.Domain.Repositories;

/// <summary>
/// Представляет интерфейс репозитория для работы с сессиями.
/// </summary>
public interface ISessionRepository
{
    /// <summary>
    /// Создает новую сессию для указанного пользователя.
    /// </summary>
    Task<DbSession> CreateAsync(int userId);

    /// <summary>
    /// Обновляет существующую сессию.
    /// </summary>
    Task<DbSession> UpdateAsync(DbSession dbSession, int id);

    /// <summary>
    /// Получает сессию по идентификатору.
    /// </summary>
    Task<DbSession> GetByIdAsync(int id);

    /// <summary>
    /// Получает все сессии, связанные с указанным пользователем.
    /// </summary>
    Task<ICollection<DbSession>> GetByUserIdAsync(int id);

    /// <summary>
    /// Получает активную сессию для указанного пользователя.
    /// </summary>
    Task<DbSession> GetActiveByUserIdAsync(int id);
}