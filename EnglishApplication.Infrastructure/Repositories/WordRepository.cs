using EnglishApplication.Domain.Entities;
using EnglishApplication.Domain.Repositories;
using EnglishApplication.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EnglishApplication.Infrastructure.Repositories;

public class WordRepository(DefaultDataContext context) : IWordRepository
{
    public async Task<DbWord> GetByIdAsync(int id)
    {
        return await context.Words
            .AsNoTracking()
            .FirstOrDefaultAsync(w => w.Id == id);
    }

    public async Task<DbWord> GetByValueAsync(string word)
    {
        return await context.Words
            .AsNoTracking()
            .FirstOrDefaultAsync(w => w.English == word);
    }
    
    public async Task<DbWord> GetByTranslationAsync(string word)
    {
        return await context.Words
            .AsNoTracking()
            .FirstOrDefaultAsync(w => w.Russian == word);
    }

    public async Task<DbWord> GetRandomWordAsync(int? seed = null)
    {
        seed = seed ?? DateTime.Now.Microsecond;

        return null;
    }
}