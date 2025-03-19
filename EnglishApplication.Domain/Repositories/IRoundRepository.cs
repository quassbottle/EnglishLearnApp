using EnglishApplication.Domain.Entities;

namespace EnglishApplication.Domain.Repositories;

/// <summary>
/// Представляет интерфейс репозитория для работы с раундами.
/// </summary>
public interface IRoundRepository
{
    /// <summary>
    /// Обновляет существующий раунд.
    /// </summary>
    Task<DbRound> UpdateAsync(DbRound round, int id);

    /// <summary>
    /// Получает раунд по идентификатору.
    /// </summary>
    Task<DbRound> GetByIdAsync(int id);

    /// <summary>
    /// Создает новый раунд.
    /// </summary>
    Task<DbRound> CreateAsync(DbRound round);
}