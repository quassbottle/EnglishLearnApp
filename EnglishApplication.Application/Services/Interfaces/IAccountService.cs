using System.Threading.Tasks;
using EnglishApplication.Application.Dto;
using EnglishApplication.Models.Auth.Request;
using EnglishApplication.Models.Auth.Response;

namespace EnglishApplication.Application.Services.Interfaces;

public interface IAccountService
{
    Task<AccountDto> GetByEmailAsync(string email);
    Task<AccountDto> CreateAsync(AccountDto dto);
}