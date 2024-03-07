using EnglishApplication.Application.Dto;
using EnglishApplication.Application.Services.Interfaces;
using EnglishApplication.Controllers.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnglishApplication.Controllers;

public class PingController(IAccountService accountService) : ApiControllerV1
{
    [HttpGet("anon")]
    public async Task<IActionResult> Ping()
    {
        return Ok("Pong!");
    }

    [HttpGet("auth")]
    [Authorize]
    public async Task<IActionResult> PingAuth()
    {
        return Ok("Pong!");
    }
}