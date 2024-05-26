namespace EnglishApplication.Domain.Entities;

public class DbSession
{
    public int Id { get; set; }
    
    public DbUserInfo DbUserInfo { get; set; }
    public int UserInfoId { get; set; }
    
    public ICollection<DbRound> Rounds { get; set; }
}