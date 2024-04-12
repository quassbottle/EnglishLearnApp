using System.Threading.Tasks;
using EnglishApplication.Application.Dto;
using EnglishApplication.Application.Dto.Mappers;
using EnglishApplication.Application.Services.Interfaces;
using EnglishApplication.Domain.Aggregate;
using EnglishApplication.Domain.Exceptions.Account;
using EnglishApplication.Domain.Repositories;

namespace EnglishApplication.Application.Services;

public class AccountService(IAccountRepository repository) : IAccountService
{
    public async Task<AccountDto> GetByEmailAsync(string email)
    {
        var candidate = await repository.FirstOrDefaultAsync(acc => acc.Email == email);

        if (candidate is null)
        {
            throw AccountNotFoundException.WithSuchEmail(email);
        }

        return candidate.ToDto();
    }

    public async Task<AccountDto> CreateAsync(AccountDto dto)
    {
        var candidate = await repository.CreateAsync(new Account
        {
            Email = dto.Email,
            HashedPassword = dto.HashedPassword,
            UserInfo = new UserInfo
            {
                Username = dto.Username
            }
        });

        return candidate.ToDto();
    }
}