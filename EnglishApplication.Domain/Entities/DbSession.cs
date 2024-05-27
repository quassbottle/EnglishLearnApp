namespace EnglishApplication.Domain.Entities;

public class DbSession
{
    public int Id { get; set; }

    public DbUserInfo UserInfo { get; set; }
    public int UserInfoId { get; set; }

    public ICollection<DbRound> Rounds { get; set; }

    public bool Active { get; set; } = true;
}