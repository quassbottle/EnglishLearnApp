using EnglishApplication.Application.Dto;

namespace EnglishApplication.Application.Services.Interfaces;

public interface IAccountService
{
    Task<AccountDto> GetByIdAsync(int id);
    Task<AccountDto> GetByEmailAsync(string email);
    Task<AccountDto> CreateAsync(AccountDto dto);
}