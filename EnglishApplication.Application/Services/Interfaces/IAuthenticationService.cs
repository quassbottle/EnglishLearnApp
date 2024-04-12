using System.Security.Claims;
using System.Threading.Tasks;
using EnglishApplication.Application.Dto;
using EnglishApplication.Models.Auth.Request;
using EnglishApplication.Models.Auth.Response;

namespace EnglishApplication.Application.Services.Interfaces;

public interface IAuthenticationService
{
    Task<TokenDto> RegisterAsync(RegisterRequest request);
    Task<TokenDto> LoginAsync(LoginRequest request);
}