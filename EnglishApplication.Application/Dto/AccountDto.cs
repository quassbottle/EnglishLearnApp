using System.Text.Json.Serialization;

namespace EnglishApplication.Application.Dto;

/// <summary>
/// DTO (Data Transfer Object) для представления данных аккаунта.
/// </summary>
public class AccountDto
{
    /// <summary>
    /// Идентификатор аккаунта.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Электронная почта аккаунта.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Имя пользователя аккаунта.
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    /// Количество очков аккаунта.
    /// </summary>
    public int Points { get; set; }

    /// <summary>
    /// Серия решеных заданий в течении нескольких дней
    /// </summary>
    public int Streak { get; set; }

    /// <summary>
    /// Дата последнего решенного задания аккаунта.
    /// </summary>
    public DateTime? LastSolved { get; set; }

    /// <summary>
    /// Захешированный пароль аккаунта (игнорируется при сериализации).
    /// </summary>
    [JsonIgnore]
    public string HashedPassword { get; set; }
}