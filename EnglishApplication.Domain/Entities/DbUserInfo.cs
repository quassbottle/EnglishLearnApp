namespace EnglishApplication.Domain.Entities;

/// <summary>
/// Представляет сущность информации о пользователе в базе данных.
/// </summary>
public class DbUserInfo
{
    /// <summary>
    /// Получает или задает идентификатор информации о пользователе.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Получает или задает имя пользователя.
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    /// Получает или задает количество очков пользователя.
    /// </summary>
    public int Points { get; set; }

    /// <summary>
    /// Получает или задает количество дней подряд, в течение которых пользователь решал задания.
    /// </summary>
    public int Streak { get; set; }

    /// <summary>
    /// Получает или задает дату и время последнего решенного задания пользователем.
    /// </summary>
    public DateTime? LastSolved { get; set; }

    /// <summary>
    /// Получает или задает учетную запись, связанную с информацией о пользователе.
    /// </summary>
    public DbAccount Account { get; set; }

    /// <summary>
    /// Получает или задает идентификатор учетной записи, связанной с информацией о пользователе.
    /// </summary>
    public int AccountId { get; set; }

    /// <summary>
    /// Получает или задает коллекцию сессий, связанных с информацией о пользователе.
    /// </summary>
    public ICollection<DbSession> Sessions { get; set; }
}