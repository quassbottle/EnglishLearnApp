using EnglishApplication.Domain.Entities;

namespace EnglishApplication.Application.Dto.Mappers;

public static class SessionMapper
{
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