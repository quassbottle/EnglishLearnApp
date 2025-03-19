namespace EnglishApplication.Domain.Entities;

/// <summary>
/// Представляет сущность учетной записи в базе данных.
/// </summary>
public class DbAccount
{
    /// <summary>
    /// Получает или задает идентификатор учетной записи.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Получает или задает адрес электронной почты учетной записи.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Получает или задает хешированный пароль учетной записи.
    /// </summary>
    public string HashedPassword { get; set; }

    /// <summary>
    /// Получает или задает информацию о пользователе, связанную с учетной записью.
    /// </summary>
    public DbUserInfo UserInfo { get; set; }
}