namespace EnglishApplication.Domain.Aggregate;

public class Word
{
    public int Id { get; set; }
    
    public string Value { get; set; }
    public string Translation { get; set; }
    
    //public Category Category { get; set; }
    //public int CategoryId { get; set; }
    
    public ICollection<LearnedWord> LearnedWords { get; set; }
}