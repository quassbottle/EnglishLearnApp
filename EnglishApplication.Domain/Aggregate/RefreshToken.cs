namespace EnglishApplication.Domain.Aggregate;

public class RefreshToken
{
    public int Id { get; set; }
    
    public string Token { get; set; }
    
    public Account Owner { get; set; }
    public int OwnerId { get; set; }
}