using EnglishApplication.Domain.Exceptions.Shared;

namespace EnglishApplication.Domain.Exceptions.UserInfo;

public class UserNotFoundException(string message) : NotFoundException(message)
{
    public static UserNotFoundException WithSuchId(int id)
    {
        return new UserNotFoundException($"User with id \"{id}\" has not been found");
    }

    public static UserNotFoundException WithSuchEmail(string username)
    {
        return new UserNotFoundException($"User with username \"{username}\" has not been found");
    }
}