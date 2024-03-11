namespace EnglishApplication.Domain.Aggregate;

public class Account
{
    public int Id { get; set; }
    
    public string Email { get; set; }
    public string HashedPassword { get; set; }
    
    public UserInfo UserInfo { get; set; }
    public int UserInfoId { get; set; }
    
    public RefreshToken RefreshToken { get; set; }
    public int RefreshTokenId { get; set; }
}