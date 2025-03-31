using EnglishApplication.Application.Dto;
using EnglishApplication.Application.Dto.Mappers;
using EnglishApplication.Application.Services.Interfaces;
using EnglishApplication.Domain.Entities;
using EnglishApplication.Domain.Exceptions.Account;
using EnglishApplication.Domain.Repositories;

namespace EnglishApplication.Application.Services;

public class AccountService(IAccountRepository repository) : IAccountService
{
    public async Task<AccountDto> GetByIdAsync(int id)
    {
        var candidate = await repository.GetByIdAsync(id);

        if (candidate is null) throw AccountNotFoundException.WithSuchId(id);

        return candidate.ToDto();
    }

    public async Task<AccountDto> GetByEmailAsync(string email)
    {
        var candidate = await repository.GetByEmailAsync(email);

        if (candidate is null) throw AccountNotFoundException.WithSuchEmail(email);

        return candidate.ToDto();
    }

    public async Task AssertEmailNotExistsAsync(string email)
    {
        var candidate = await repository.GetByEmailAsync(email);
        if (candidate is not null)
        {
            throw AccountAlreadyExistsException.WithSuchEmail(email);
        }
    }

    public async Task<AccountDto> CreateAsync(AccountDto dto)
    {
        var candidate = await repository.CreateAsync(new DbAccount
        {
            Email = dto.Email,
            HashedPassword = dto.HashedPassword,
            UserInfo = new DbUserInfo
            {
                Username = dto.Username
            }
        });

        return candidate.ToDto();
    }
}