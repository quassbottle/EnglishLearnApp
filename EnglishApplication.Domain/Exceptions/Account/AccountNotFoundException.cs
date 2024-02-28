using EnglishApplication.Domain.Exceptions.Shared;

namespace EnglishApplication.Domain.Exceptions.Account;

public class AccountNotFoundException(string message) : NotFoundException(message)
{
    public static AccountNotFoundException WithSuchId(int id)
    {
        return new AccountNotFoundException($"Account with id \"{id}\" has not been found");
    }

    public static AccountNotFoundException WithSuchEmail(string email)
    {
        return new AccountNotFoundException($"Account with email \"{email}\" has not been found");
    }
}