using EnglishApplication.Application.Services;
using EnglishApplication.Application.Services.Interfaces;

namespace EnglishApplication.Extensions;

public static class ApplicationHostExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IJwtTokenService, JwtTokenService>();
        services.AddScoped<ISessionService, SessionService>();
    }
}