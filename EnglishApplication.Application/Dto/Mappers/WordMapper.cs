using EnglishApplication.Domain.Entities;

namespace EnglishApplication.Application.Dto.Mappers;

/// <summary>
/// Класс-маппер для сопоставления объектов Word и WordDto.
/// </summary>
public static class WordMapper
{
    /// <summary>
    /// Преобразует объект типа DbWord в объект типа WordDto.
    /// </summary>
    /// <param name="db">Объект типа DbWord.</param>
    /// <returns>Объект типа WordDto.</returns>
    public static WordDto ToDto(this DbWord db)
    {
        return new WordDto
        {
            Id = db.Id,
            English = db.English,
            Russian = db.Russian
        };
    }

    /// <summary>
    /// Преобразует объект типа WordDto в объект типа DbWord.
    /// </summary>
    /// <param name="dto">Объект типа WordDto.</param>
    /// <returns>Объект типа DbWord.</returns>
    public static DbWord ToDb(this WordDto dto)
    {
        return new DbWord
        {
            Id = dto.Id,
            English = dto.English,
            Russian = dto.Russian
        };
    }
}