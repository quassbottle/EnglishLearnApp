using EnglishApplication.Domain.Entities;

namespace EnglishApplication.Application.Dto.Mappers;

public static class AccountMapper
{
    public static AccountDto ToDto(this DbAccount? account)
    {
        return account is null ?
            null :
            new AccountDto
        {
            Email = account.Email,
            Id = account.Id,
            Username = account.DbUserInfo?.Username,
            HashedPassword = account.HashedPassword
        };
    }
}