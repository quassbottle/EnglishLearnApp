using System.Text.Json.Serialization;

namespace EnglishApplication.Application.Dto;

public class AccountDto
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public int Points { get; set; }
    public DateTime? LastSolved { get; set; }
    
    
    [JsonIgnore] public string HashedPassword { get; set; }
}