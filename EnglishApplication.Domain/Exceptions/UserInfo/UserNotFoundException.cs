using EnglishApplication.Domain.Exceptions.Shared;

namespace EnglishApplication.Domain.Exceptions.UserInfo;

/// <summary>
/// Исключение, указывающее на то, что пользователь не был найден.
/// </summary>
public class UserNotFoundException : NotFoundException
{
    /// <summary>
    /// Создает новый экземпляр исключения с указанным сообщением.
    /// </summary>
    /// <param name="message">Сообщение об ошибке.</param>
    public UserNotFoundException(string message) : base(message) { }

    /// <summary>
    /// Создает новый экземпляр исключения с сообщением о том, что пользователь с указанным идентификатором не был найден.
    /// </summary>
    /// <param name="id">Идентификатор пользователя, который не был найден.</param>
    /// <returns>Новый экземпляр исключения <see cref="UserNotFoundException"/>.</returns>
    public static UserNotFoundException WithSuchId(int id)
    {
        return new UserNotFoundException($"User with id \"{id}\" has not been found");
    }

    /// <summary>
    /// Создает новый экземпляр исключения с сообщением о том, что пользователь с указанным именем не был найден.
    /// </summary>
    /// <param name="username">Имя пользователя, который не был найден.</param>
    /// <returns>Новый экземпляр исключения <see cref="UserNotFoundException"/>.</returns>
    public static UserNotFoundException WithSuchEmail(string username)
    {
        return new UserNotFoundException($"User with username \"{username}\" has not been found");
    }
}