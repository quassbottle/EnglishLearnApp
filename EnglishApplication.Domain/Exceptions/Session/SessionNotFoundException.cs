using EnglishApplication.Domain.Exceptions.Shared;

namespace EnglishApplication.Domain.Exceptions.Session;

public class SessionNotFoundException(string message) : NotFoundException(message)
{
    public static SessionNotFoundException WithSuchId(int id)
    {
        return new SessionNotFoundException($"Session with id \"{id}\" has not been found");
    }
}