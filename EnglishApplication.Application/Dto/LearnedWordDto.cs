namespace EnglishApplication.Application.Dto;

public class LearnedWordDto
{
    public int Id { get; set; }
    public WordDto Word { get; set; }
    public int GuessedTimes { get; set; }
}