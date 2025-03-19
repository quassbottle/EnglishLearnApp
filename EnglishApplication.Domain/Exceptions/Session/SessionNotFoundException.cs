using EnglishApplication.Domain.Exceptions.Shared;

namespace EnglishApplication.Domain.Exceptions.Session;

/// <summary>
/// Исключение, указывающее на то, что сессия не была найдена.
/// </summary>
public class SessionNotFoundException(string message) : NotFoundException(message)
{
    /// <summary>
    /// Создает новый экземпляр исключения с сообщением о том, что сессия с указанным идентификатором не была найдена.
    /// </summary>
    /// <param name="id">Идентификатор сессии, которая не была найдена.</param>
    /// <returns>Новый экземпляр исключения <see cref="SessionNotFoundException"/>.</returns>
    public static SessionNotFoundException WithSuchId(int id)
    {
        return new SessionNotFoundException($"Session with id \"{id}\" has not been found");
    }
}