namespace EnglishApplication.Models.Session;

public class SessionRound
{
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public bool? Guessed { get; set; }
    public string Word { get; set; }
}