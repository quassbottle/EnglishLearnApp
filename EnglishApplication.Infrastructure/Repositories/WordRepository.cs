using EnglishApplication.Common.Helpers;
using EnglishApplication.Domain.Entities;
using EnglishApplication.Domain.Repositories;
using EnglishApplication.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EnglishApplication.Infrastructure.Repositories;

public class WordRepository(DefaultDataContext context) : IWordRepository
{
    public async Task<DbWord> GetRandomNotGuessedWordAsync(int userId)
    {
        var wordGuesses = await context.Rounds
            .AsNoTracking()
            .Include(r => r.Session)
            .Where(r => r.Session.UserInfoId == userId)
            .GroupBy(r => r.WordId)
            .Select(g => new
            {
                WordId = g.Key,
                GuessCount = g.Count(r => r.Guessed ?? false)
            })
            .ToListAsync();

        var allWords = await context.Words
            .AsNoTracking()
            .ToListAsync();

        var notGuessedWords = allWords
            .Where(w =>
            {
                var wordGuess = wordGuesses.FirstOrDefault(g => g.WordId == w.Id);
                return wordGuess == null || wordGuess.GuessCount < 3;
            })
            .ToList();

        if (notGuessedWords.Any()) return notGuessedWords[ThreadLocalRandom.Instance.Next(notGuessedWords.Count)];

        return null;
    }
}