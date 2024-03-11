using EnglishApplication.Application.Services.Interfaces;
using EnglishApplication.Controllers.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnglishApplication.Controllers.V1;

public class PingController : ApiControllerV1
{
    [AllowAnonymous]
    [HttpGet("anon")]
    public async Task<IActionResult> Ping()
    {
        return Ok("Pong!");
    }

    [HttpGet("auth")]
    public async Task<IActionResult> PingAuth()
    {
        return Ok("Pong!");
    }
}