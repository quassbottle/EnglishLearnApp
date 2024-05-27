using EnglishApplication.Domain.Entities;

namespace EnglishApplication.Application.Dto.Mappers;

public static class RoundMapper
{
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