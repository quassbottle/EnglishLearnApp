using EnglishApplication.Domain.Entities;

namespace EnglishApplication.Domain.Repositories;

public interface IWordRepository
{
    Task<Word> GetByIdAsync(int id);
}