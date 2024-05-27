namespace EnglishApplication.Domain.Entities;

public class DbUserInfo
{
    public int Id { get; set; }

    public string Username { get; set; }
    public int Points { get; set; }
    public int Streak { get; set; }
    public DateTime LastSolved { get; set; }

    public DbAccount Account { get; set; }
    public int AccountId { get; set; }

    public ICollection<DbSession> Sessions { get; set; }
}