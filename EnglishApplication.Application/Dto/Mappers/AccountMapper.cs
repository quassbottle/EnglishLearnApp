using EnglishApplication.Domain.Entities;

namespace EnglishApplication.Application.Dto.Mappers;

/// <summary>
/// Класс-маппер для сопоставления объектов Account и AccountDto.
/// </summary>
public static class AccountMapper
{
    /// <summary>
    /// Преобразует объект типа DbAccount в объект типа AccountDto.
    /// </summary>
    /// <param name="account">Объект типа DbAccount.</param>
    /// <returns>Объект типа AccountDto.</returns>
    public static AccountDto ToDto(this DbAccount? account)
    {
        return account is null
            ? null
            : new AccountDto
            {
                Email = account.Email,
                Id = account.Id,
                Username = account.UserInfo.Username,
                HashedPassword = account.HashedPassword,
                Streak = account.UserInfo.Streak,
                LastSolved = account.UserInfo.LastSolved,
                Points = account.UserInfo.Points
            };
    }
}