namespace EnglishApplication.Domain.Entities;

public class LearnedWord
{
    public int Id { get; set; }

    public Word Word { get; set; }
    public int WordId { get; set; }
    
    public Session Session { get; set; }
    public int SessionId { get; set; }
}