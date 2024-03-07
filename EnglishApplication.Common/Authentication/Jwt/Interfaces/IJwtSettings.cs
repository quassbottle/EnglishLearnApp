using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace EnglishApplication.Common.Authentication.Jwt.Interfaces;

public interface IJwtSettings
{
    public string Issuer { get; }
    public string Audience { get; }
    public string Key { get; }
    public int TokenExpiresAfterHours { get; }
    public int RefreshTokenExpiresAfterHours { get; }
}