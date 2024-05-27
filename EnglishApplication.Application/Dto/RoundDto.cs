namespace EnglishApplication.Application.Dto;

public class RoundDto
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool? Guessed { get; set; }
    public WordDto Word { get; set; }
}