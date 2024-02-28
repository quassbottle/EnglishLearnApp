namespace EnglishApplication.Domain.Aggregate;

public class Category
{
    public int Id { get; set; }
    
    public int Name { get; set; }
    
    public ICollection<Word> Words { get; set; }
}