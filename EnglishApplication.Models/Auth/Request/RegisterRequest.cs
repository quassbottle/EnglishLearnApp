using System.Globalization;

namespace EnglishApplication.Models.Auth.Request;

public class RegisterRequest
{
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public void Deconstruct(out string email, out string username, out string password)
    {
        email = Email;
        username = Username;
        password = Password;
    }
}