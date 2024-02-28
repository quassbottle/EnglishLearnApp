using EnglishApplication.Domain.Exceptions.Shared;

namespace EnglishApplication.Domain.Exceptions.Account;

public class AccountAlreadyExistsException(string message) : BadRequestException(message)
{
    public static AccountAlreadyExistsException WithSuchEmail(string email)
    {
        return new AccountAlreadyExistsException($"Account with email \"{email}\" already exists.");
    }
}