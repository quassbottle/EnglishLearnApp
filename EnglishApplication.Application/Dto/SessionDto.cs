namespace EnglishApplication.Application.Dto;

public class SessionDto
{
    public int Id { get; set; }
    public ICollection<RoundDto> Rounds { get; set; }
    public bool Active { get; set; }
    public int UserId { get; set; }
}