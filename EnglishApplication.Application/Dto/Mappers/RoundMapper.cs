using EnglishApplication.Domain.Entities;

namespace EnglishApplication.Application.Dto.Mappers;

/// <summary>
/// Класс-маппер для сопоставления объектов Round и RoundDto.
/// </summary>
public static class RoundMapper
{
    /// <summary>
    /// Преобразует объект типа DbRound в объект типа RoundDto.
    /// </summary>
    /// <param name="db">Объект типа DbRound.</param>
    /// <returns>Объект типа RoundDto.</returns>
    public static RoundDto ToDto(this DbRound db)
    {
        return db is null
            ? null
            : new RoundDto
            {
                Id = db.Id,
                StartTime = db.StartTime,
                EndTime = db.EndTime,
                Guessed = db.Guessed,
                Word = db.Word.ToDto()
            };
    }

    /// <summary>
    /// Преобразует объект типа RoundDto в объект типа DbRound.
    /// </summary>
    /// <param name="dto">Объект типа RoundDto.</param>
    /// <returns>Объект типа DbRound.</returns>
    public static DbRound ToDb(this RoundDto dto)
    {
        return new DbRound
        {
            Id = dto.Id,
            StartTime = dto.StartTime,
            EndTime = dto.EndTime,
            Guessed = dto.Guessed,
            WordId = dto.Word.Id
        };
    }
}