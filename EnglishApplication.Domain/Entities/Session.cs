namespace EnglishApplication.Domain.Entities;

public class Session
{
    public int Id { get; set; }
    
    public DateTime StartTime { get; set; } = DateTime.Now;
    public DateTime EndTime { get; set; }
    
    public ICollection<LearnedWord> Words { get; set; }
    
    public UserInfo UserInfo { get; set; }
    public int UserInfoId { get; set; }
}