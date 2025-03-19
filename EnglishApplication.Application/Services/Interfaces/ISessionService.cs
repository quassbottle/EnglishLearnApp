using EnglishApplication.Application.Dto;

namespace EnglishApplication.Application.Services.Interfaces;

/// <summary>
/// Интерфейс сервиса управления сессиями.
/// </summary>
public interface ISessionService
{
    /// <summary>
    /// Получает сессию по её идентификатору асинхронно.
    /// </summary>
    /// <param name="id">Идентификатор сессии.</param>
    /// <returns>DTO (Data Transfer Object) сессии.</returns>
    Task<SessionDto> GetByIdAsync(int id);

    /// <summary>
    /// Получает все сессии по идентификатору пользователя асинхронно.
    /// </summary>
    /// <param name="id">Идентификатор пользователя.</param>
    /// <returns>Коллекция DTO (Data Transfer Object) сессий.</returns>
    Task<ICollection<SessionDto>> GetByUserIdAsync(int id);

    /// <summary>
    /// Получает текущий раунд сессии асинхронно.
    /// </summary>
    /// <param name="sessionId">Идентификатор сессии.</param>
    /// <returns>DTO (Data Transfer Object) текущего раунда.</returns>
    Task<RoundDto> GetCurrentRoundAsync(int sessionId);

    /// <summary>
    /// Получает активную сессию пользователя асинхронно.
    /// </summary>
    /// <param name="id">Идентификатор пользователя.</param>
    /// <returns>DTO (Data Transfer Object) активной сессии.</returns>
    Task<SessionDto> GetActiveByUserIdAsync(int id);

    /// <summary>
    /// Создает новую сессию для пользователя асинхронно.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <returns>DTO (Data Transfer Object) созданной сессии.</returns>
    Task<SessionDto> CreateAsync(int userId);

    /// <summary>
    /// Попытка угадать текущее слово в сессии асинхронно.
    /// </summary>
    /// <param name="sessionId">Идентификатор сессии.</param>
    /// <param name="word">Слово для угадывания.</param>
    /// <returns>DTO (Data Transfer Object) обновленной сессии.</returns>
    Task<SessionDto> GuessCurrentWordAsync(int sessionId, string word);
    
    /// <summary>
    /// Переходит к следующему раунду в сессии асинхронно.
    /// </summary>
    /// <param name="sessionId">Идентификатор сессии.</param>
    /// <returns>DTO (Data Transfer Object) обновленной сессии.</returns>
    Task<SessionDto> MoveNextRoundAsync(int sessionId);
}
