using EnglishApplication.Common.Authentication.Hash;
using EnglishApplication.Common.Authentication.Hash.Interfaces;
using EnglishApplication.Common.Authentication.Jwt;
using EnglishApplication.Common.Authentication.Jwt.Interfaces;

namespace EnglishApplication.Extensions;

public static class AuthenticationExtensions
{
    public static void AddAuthModule(this IServiceCollection services)
    {
        services.AddSingleton<IJwtSettings, JwtSettings>();
        services.AddSingleton<IPasswordHasher, BCryptPasswordHasher>();
    }
}