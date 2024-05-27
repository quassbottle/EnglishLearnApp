using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EnglishApplication.Common.Authentication.Jwt;

public static class JwtReader
{
    public static string? GetId(string token)
    {
        return ParseToken(token, "id");
    }

    public static string? GetEmail(string token)
    {
        return ParseToken(token, "email");
    }

    public static string? GetRole(string token)
    {
        return ParseToken(token, "role");
    }

    private static string? ParseToken(string token, string role)
    {
        var removeBearer = token.Split(' ')[1];
        var handler = new JwtSecurityTokenHandler();
        var tokenData = handler.ReadJwtToken(removeBearer).Payload;
        return tokenData.Claims.FirstOrDefault(c => c.Type.Split('/').Last() == role)?.Value;
    }

    public static List<Claim> GetClaims(int id, string email, string role)
    {
        var claims = new List<Claim>
        {
            new("id", id.ToString()),
            new("email", email),
            new("role", role)
        };

        return claims;
    }
}