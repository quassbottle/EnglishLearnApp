using System.Security.Claims;
using EnglishApplication.Application.Dto;
using EnglishApplication.Application.Services.Interfaces;
using EnglishApplication.Common.Authentication.Hash.Interfaces;
using EnglishApplication.Domain.Exceptions.Auth;

namespace EnglishApplication.Application.Services;

public class AuthenticationService(
    IAccountService accountService,
    IPasswordHasher passwordHasher,
    IJwtTokenService jwtService) : IAuthenticationService
{
    public async Task<TokenDto> RegisterAsync(string email, string username, string password)
    {
        var hashedPassword = passwordHasher.Hash(password);

        var candidate = await accountService.CreateAsync(new AccountDto
        {
            Email = email,
            HashedPassword = hashedPassword,
            Username = username
        });

        var token = await jwtService.CreateAccessTokenAsync(new List<Claim>
        {
            new("email", email),
            new("role", "default"),
            new("id", candidate.Id.ToString())
        });

        return token;
    }

    public async Task<TokenDto> LoginAsync(string email, string password)
    {
        var candidate = await accountService.GetByEmailAsync(email);

        if (!passwordHasher.Verify(password, candidate.HashedPassword))
            throw new BadPasswordException();

        var token = await jwtService.CreateAccessTokenAsync(new List<Claim>
        {
            new("email", email),
            new("role", "default"), 
            new("id", candidate.Id.ToString())
        });

        return token;
    }
}