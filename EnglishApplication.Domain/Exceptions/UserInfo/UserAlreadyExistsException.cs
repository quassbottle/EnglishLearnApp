using EnglishApplication.Domain.Exceptions.Shared;

namespace EnglishApplication.Domain.Exceptions.UserInfo;

/// <summary>
/// Исключение, указывающее на то, что пользователь уже существует.
/// </summary>
public class UserAlreadyExistsException : BadRequestException
{
    /// <summary>
    /// Создает новый экземпляр исключения с указанным сообщением.
    /// </summary>
    /// <param name="message">Сообщение об ошибке.</param>
    public UserAlreadyExistsException(string message) : base(message) { }

    /// <summary>
    /// Создает новый экземпляр исключения с сообщением о том, что пользователь с указанным именем уже существует.
    /// </summary>
    /// <param name="username">Имя пользователя, который уже существует.</param>
    /// <returns>Новый экземпляр исключения <see cref="UserAlreadyExistsException"/>.</returns>
    public static UserAlreadyExistsException WithSuchName(string username)
    {
        return new UserAlreadyExistsException($"User with username \"{username}\" already exists.");
    }
}