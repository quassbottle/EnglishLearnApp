using EnglishApplication.Domain.Entities;

namespace EnglishApplication.Application.Dto.Mappers;

public static class AccountMapper
{
    public static AccountDto ToDto(this Account? account)
    {
        return account is null ?
            null :
            new AccountDto
        {
            Email = account.Email,
            Id = account.Id,
            Username = account.UserInfo?.Username,
            HashedPassword = account.HashedPassword
        };
    }
}