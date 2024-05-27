namespace EnglishApplication.Domain.Entities;

public class DbAccount
{
    public int Id { get; set; }

    public string Email { get; set; }
    public string HashedPassword { get; set; }

    public DbUserInfo UserInfo { get; set; }
}