using EnglishApplication.Domain.Entities;

namespace EnglishApplication.Domain.Repositories;

public interface IWordRepository
{
    Task<DbWord> GetByIdAsync(int id);
    Task<DbWord> GetByValueAsync(string word);
    Task<DbWord> GetByTranslationAsync(string word);
    Task<DbWord> GetRandomNotGuessedWordAsync(int userId);
}