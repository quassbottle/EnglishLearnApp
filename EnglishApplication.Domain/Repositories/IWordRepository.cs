using EnglishApplication.Domain.Entities;

namespace EnglishApplication.Domain.Repositories;

/// <summary>
/// Представляет интерфейс репозитория для работы со словами.
/// </summary>
public interface IWordRepository
{
    /// <summary>
    /// Получает случайное слово, которое еще не было угадано пользователем.
    /// </summary>
    Task<DbWord> GetRandomNotGuessedWordAsync(int userId);
}