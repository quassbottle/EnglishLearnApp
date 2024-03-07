using EnglishApplication.Domain.Aggregate;

namespace EnglishApplication.Application.Dto.Mappers;

public static class AccountMapper
{
    public static AccountDto ToDto(this Account account)
    {
        return new AccountDto
        {
            Email = account.Email,
            Id = account.Id,
            Username = account.UserInfo?.Username,
            HashedPassword = account.HashedPassword
        };
    }
}