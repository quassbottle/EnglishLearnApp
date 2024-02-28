using EnglishApplication.Domain.Exceptions.Shared;

namespace EnglishApplication.Domain.Exceptions.UserInfo;

public class UserAlreadyExistsException(string message) : BadRequestException(message)
{
    public static UserAlreadyExistsException WithSuchName(string username)
    {
        return new UserAlreadyExistsException($"User with username \"{username}\" already exists.");
    }
}