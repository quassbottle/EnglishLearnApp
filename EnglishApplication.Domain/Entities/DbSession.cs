namespace EnglishApplication.Domain.Entities;

/// <summary>
/// Представляет сущность сессии в базе данных.
/// </summary>
public class DbSession
{
    /// <summary>
    /// Получает или задает идентификатор сессии.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Получает или задает информацию о пользователе, связанную с сессией.
    /// </summary>
    public DbUserInfo UserInfo { get; set; }

    /// <summary>
    /// Получает или задает идентификатор информации о пользователе, связанной с сессией.
    /// </summary>
    public int UserInfoId { get; set; }

    /// <summary>
    /// Получает или задает коллекцию раундов, связанных с сессией.
    /// </summary>
    public ICollection<DbRound> Rounds { get; set; }

    /// <summary>
    /// Получает или задает флаг, указывающий, активна ли сессия.
    /// По умолчанию сессия активна.
    /// </summary>
    public bool Active { get; set; } = true;
}