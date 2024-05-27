using EnglishApplication.Application.Dto;

namespace EnglishApplication.Application.Services.Interfaces;

public interface IAuthenticationService
{
    Task<TokenDto> RegisterAsync(string email, string username, string password);
    Task<TokenDto> LoginAsync(string login, string password);
}