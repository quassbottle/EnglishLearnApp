namespace EnglishApplication.Domain.Aggregate;

public class RefreshToken
{
    public int Id { get; set; }
    
    public string Token { get; set; }
    
    public Account Account { get; set; }
    public int AccountId { get; set; }
}