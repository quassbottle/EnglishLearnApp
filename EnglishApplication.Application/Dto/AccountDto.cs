using System.Text.Json.Serialization;
using EnglishApplication.Domain.Entities;

namespace EnglishApplication.Application.Dto;

public class AccountDto
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    [JsonIgnore] public string HashedPassword { get; set; }
}