using EnglishApplication.Application.Services;
using EnglishApplication.Application.Services.Interfaces;
using EnglishApplication.Common.Authentication.Jwt;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishApplication.Application.Extensions;

public static class ApplicationHostExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IJwtTokenService, JwtTokenService>();
    }
}