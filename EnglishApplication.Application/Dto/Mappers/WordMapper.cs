using EnglishApplication.Domain.Entities;

namespace EnglishApplication.Application.Dto.Mappers;

public static class WordMapper
{
    public static WordDto ToDto(this DbWord db)
    {
        return new WordDto
        {
            Id = db.Id,
            English = db.English,
            Russian = db.Russian
        };
    }

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