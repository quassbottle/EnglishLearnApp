using EnglishApplication.Application.Services.Interfaces;
using EnglishApplication.Controllers.Abstract;
using EnglishApplication.Models.Session;
using EnglishApplication.Models.Session.Mappers;
using EnglishApplication.Models.Session.Request;
using EnglishApplication.Models.Session.Response;
using Microsoft.AspNetCore.Mvc;

namespace EnglishApplication.Controllers.V1;

public class SessionController(ISessionService service) : ApiControllerV1
{
    /// <summary>
    /// Begin the game session
    /// </summary>
    /// <returns></returns>
    [HttpPost("start")]
    public async Task<IActionResult> Start()
    {
        var dto = await service.CreateAsync(UserId);

        return Ok(dto.ToResponse());
    }

    /// <summary>
    /// Get current active game session by your profile
    /// </summary>
    /// <returns></returns>
    [HttpGet("active")]
    public async Task<IActionResult> GetActive()
    {
        var dto = await service.GetActiveByUserIdAsync(UserId);

        return Ok(dto.ToResponse());
    }

    /// <summary>
    /// Guess the current word in your active session
    /// </summary>
    /// <returns></returns>
    [HttpPost("guess")]
    public async Task<IActionResult> Guess(GuessRequest request)
    {
        var active = await service.GetActiveByUserIdAsync(UserId);
        var dto = await service.GuessCurrentWordAsync(active.Id, request.Word);

        return Ok(dto.ToResponse());
    }
}