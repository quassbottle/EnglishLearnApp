namespace EnglishApplication.Domain.Entities;

public class DbWord
{
    public int Id { get; set; }

    public string English { get; set; }
    public string Russian { get; set; }

    public ICollection<DbRound> Rounds { get; set; }
}