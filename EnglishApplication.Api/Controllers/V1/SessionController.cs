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
    [HttpPost("start")]
    public async Task<IActionResult> Start()
    {
        var dto = await service.CreateAsync(Id);

        return Ok(dto.ToResponse());
    }

    [HttpGet("active")]
    public async Task<IActionResult> GetActive()
    {
        var dto = await service.GetActiveByUserIdAsync(Id);

        return Ok(dto.ToResponse());
    }

    [HttpPost("guess")]
    public async Task<IActionResult> Guess(GuessRequest request)
    {
        var active = await service.GetActiveByUserIdAsync(Id);
        var dto = await service.GuessCurrentWordAsync(active.Id, request.Word);

        return Ok(dto.ToResponse());
    }
}