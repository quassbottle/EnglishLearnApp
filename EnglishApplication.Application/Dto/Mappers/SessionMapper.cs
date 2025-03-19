using EnglishApplication.Domain.Entities;

namespace EnglishApplication.Application.Dto.Mappers;

/// <summary>
/// Класс-маппер для сопоставления объектов Session и SessionDto.
/// </summary>
public static class SessionMapper
{
    /// <summary>
    /// Преобразует объект типа DbSession в объект типа SessionDto.
    /// </summary>
    /// <param name="db">Объект типа DbSession.</param>
    /// <returns>Объект типа SessionDto.</returns>
    public static SessionDto ToDto(this DbSession db)
    {
        return db is null
            ? null
            : new SessionDto
            {
                Id = db.Id,
                Rounds = db.Rounds is null ? new List<RoundDto>() : db.Rounds.Select(RoundMapper.ToDto).ToList(),
                Active = db.Active,
                UserId = db.UserInfoId
            };
    }

    /// <summary>
    /// Преобразует объект типа SessionDto в объект типа DbSession.
    /// </summary>
    /// <param name="dto">Объект типа SessionDto.</param>
    /// <returns>Объект типа DbSession.</returns>
    public static DbSession ToDb(this SessionDto dto)
    {
        return new DbSession
        {
            Id = dto.Id,
            Rounds = dto.Rounds.Select(RoundMapper.ToDb).ToList(),
            Active = dto.Active,
            UserInfoId = dto.UserId
        };
    }
}