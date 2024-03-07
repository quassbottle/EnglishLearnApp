using EnglishApplication.Common.Authentication.Hash;
using EnglishApplication.Common.Authentication.Hash.Interfaces;
using EnglishApplication.Common.Authentication.Jwt;
using EnglishApplication.Common.Authentication.Jwt.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishApplication.Common.Authentication.Extensions;

public static class AuthenticationExtensions
{
    public static void AddJwtSettings(this IServiceCollection services)
    {
        services.AddSingleton<IJwtSettings, JwtSettings>();
        services.AddSingleton<IPasswordHasher, BCryptPasswordHasher>();
    }
}