using EnglishApplication.Application.Dto;
using EnglishApplication.Models.Auth.Request;

namespace EnglishApplication.Application.Services.Interfaces;

public interface IAuthenticationService
{
    Task<TokenDto> RegisterAsync(RegisterRequest request);
    Task<TokenDto> LoginAsync(LoginRequest request);
}