using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using EnglishApplication.Application.Dto;

namespace EnglishApplication.Application.Services.Interfaces;

public interface IJwtTokenService
{
    Task<TokenDto> CreateAccessTokenAsync(ICollection<Claim> claims);
    Task<TokenDto> CreateRefreshTokenAsync();
    Task<TokenDto> RefreshAccessTokenAsync();
}