using EnglishApplication.Application.Dto;
using EnglishApplication.Models.Session.Response;

namespace EnglishApplication.Models.Session.Mappers;

public static class SessionModelMapper
{
    public static SessionActiveResponse ToResponse(this SessionDto dto)
    {
        return dto is null
            ? null
            : new SessionActiveResponse
            {
                Id = dto.Id,
                Active = dto.Active,
                GuessedTimes = dto.Rounds is null ? 0 : dto.Rounds.Count(r => r.Guessed.GetValueOrDefault()),
                Rounds = dto.Rounds is null
                    ? null
                    : dto.Rounds.Select(r => new SessionRound
                    {
                        StartTime = r.StartTime,
                        EndTime = r.EndTime,
                        Guessed = r.Guessed,
                        Word = r.Word.English
                    }).ToList()
            };
    }
}