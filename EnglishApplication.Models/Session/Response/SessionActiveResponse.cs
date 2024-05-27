namespace EnglishApplication.Models.Session.Response;

public class SessionActiveResponse
{
    public int Id { get; set; }
    public bool Active { get; set; }
    public ICollection<SessionRound> Rounds { get; set; }
}