namespace EnglishApplication.Domain.Aggregate;

public class UserInfo
{
    public int Id { get; set; }
    
    public string Username { get; set; }
    
    public Account Account { get; set; }
    public int AccountId { get; set; }
    
    public ICollection<LearnedWord> LearnedWords { get; set; }
}