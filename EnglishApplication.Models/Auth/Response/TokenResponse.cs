namespace EnglishApplication.Models.Auth.Response;

public class TokenResponse
{
    public string Token { get; set; }
    public DateTime Expires { get; set; }
}