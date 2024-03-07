using EnglishApplication.Common.Authentication.Jwt;
using EnglishApplication.Common.Authentication.Jwt.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishApplication.Common.Authentication.Extensions;

public static class AuthenticationExtensions
{
    public static void AddJwtSettings(this IServiceCollection services)
    {
        services.AddSingleton<IJwtSettings, JwtSettings>();
    }
}