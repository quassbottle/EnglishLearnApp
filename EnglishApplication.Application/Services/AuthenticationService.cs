using System.Security.Claims;
using EnglishApplication.Application.Dto;
using EnglishApplication.Application.Services.Interfaces;
using EnglishApplication.Common.Authentication.Hash.Interfaces;
using EnglishApplication.Common.Authentication.Jwt;
using EnglishApplication.Domain.Aggregate;
using EnglishApplication.Domain.Repositories;
using EnglishApplication.Models.Auth.Request;
using EnglishApplication.Models.Auth.Response;

namespace EnglishApplication.Application.Services;

public class AuthenticationService(
    IAccountService accountService,
    IPasswordHasher passwordHasher,
    IJwtTokenService jwtService) : IAuthenticationService
{
    public async Task<TokenDto> RegisterAsync(RegisterRequest request)
    {
        var hashedPassword = passwordHasher.Hash(request.Password);

        var candidate = await accountService.CreateAsync(new AccountDto
        {
            Email = request.Email,
            HashedPassword = hashedPassword,
            Username = request.Username
        });

        var token = await jwtService.CreateAccessTokenAsync(new List<Claim>
        {
            new("email", request.Email),
            new("role", "default"), // todo: add roles
            new("id", candidate.Id.ToString())
        });

        return token;
    }

    public async Task<TokenDto> LoginAsync(LoginRequest request)
    {
        var candidate = await accountService.GetByEmailAsync(request.Email);

        if (!passwordHasher.Verify(request.Password, candidate.HashedPassword))
        {
            throw new Exception("bad password"); // todo: create domain specified exception
        }
        
        var token = await jwtService.CreateAccessTokenAsync(new List<Claim>
        {
            new("email", request.Email),
            new("role", "default"), // todo: add roles
            new("id", candidate.Id.ToString())
        });

        return token;
    }
}