namespace EnglishApplication.Domain.Entities;

public class DbRound
{
    public int Id { get; set; }

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public DbWord Word { get; set; }
    public int WordId { get; set; }

    public bool? Guessed { get; set; }

    public DbSession Session { get; set; }
    public int SessionId { get; set; }
}