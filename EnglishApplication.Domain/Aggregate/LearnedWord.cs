namespace EnglishApplication.Domain.Aggregate;

public class LearnedWord
{
    public int Id { get; set; }
    
    public Word Word { get; set; }
    public int WordId { get; set; }
    
    public UserInfo UserInfo { get; set; }
    public int UserInfoId { get; set; }
    
    public int GuessedTimes { get; set; }
}