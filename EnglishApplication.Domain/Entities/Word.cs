namespace EnglishApplication.Domain.Entities;

public class Word
{
    public int Id { get; set; }
    
    public string Value { get; set; }
    public string Translation { get; set; }
    
    public ICollection<Session> Sessions { get; set; }
}