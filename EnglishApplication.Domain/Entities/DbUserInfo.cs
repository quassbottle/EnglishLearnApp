namespace EnglishApplication.Domain.Entities;

public class DbUserInfo 
{
    public int Id { get; set; }
    
    public string Username { get; set; }
    
    public DbAccount DbAccount { get; set; }
    public int AccountId { get; set; }
    
    public ICollection<DbSession> Sessions { get; set; }
}