namespace EnglishApplication.Domain.Entities;

public class Account
{
    public int Id { get; set; }
    
    public string Email { get; set; }
    public string HashedPassword { get; set; }
    
    public UserInfo UserInfo { get; set; }
    public int UserInfoId { get; set; }
}