using EnglishApplication.Application.Dto;

namespace EnglishApplication.Application.Services.Interfaces;

public interface IWordService
{
    Task<ICollection<(WordDto, int)>> GetGuessedTimesByUserIdAsync(int id);
}