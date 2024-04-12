using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EnglishApplication.Application.Dto;
using EnglishApplication.Application.Services.Interfaces;
using EnglishApplication.Common.Authentication.Jwt.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace EnglishApplication.Application.Services;

public class JwtTokenService(IJwtSettings jwtSettings) : IJwtTokenService
{
    public async Task<TokenDto> CreateAccessTokenAsync(ICollection<Claim> claims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key));

        var token = new JwtSecurityToken(
            jwtSettings.Issuer,
            jwtSettings.Audience,
            claims,
            null,
            DateTime.UtcNow.AddHours(jwtSettings.TokenExpiresAfterHours),
            new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

        return await Task.FromResult(new TokenDto
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token)
        });
    }

    public async Task<TokenDto> CreateRefreshTokenAsync()
    {
        return await CreateAccessTokenAsync(new List<Claim>());
    }

    public Task<TokenDto> RefreshAccessTokenAsync()
    {
        throw new NotImplementedException();
    }
}