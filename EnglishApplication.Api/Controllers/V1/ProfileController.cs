using EnglishApplication.Application.Services.Interfaces;
using EnglishApplication.Controllers.Abstract;
using EnglishApplication.Models.Session.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace EnglishApplication.Controllers.V1;

public class ProfileController(IAccountService accountService, ISessionService sessionService) : ApiControllerV1
{
    /// <summary>
    /// Get the profile by ID
    /// </summary>
    /// <param name="id">User ID</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAccountById(int id)
    {
        return Ok(await accountService.GetByIdAsync(id));
    }

    [HttpGet("{id}/sessions")]
    public async Task<IActionResult> GetSessionsByUser(int id)
    {
        return Ok((await sessionService.GetByUserIdAsync(id)).Select(i => i.ToResponse()));
    }
    
    /// <summary>
    /// Get the current session profile
    /// </summary>
    /// <returns></returns>
    [HttpGet("profile")]
    public async Task<IActionResult> GetProfile()
    {
        return Ok(await accountService.GetByIdAsync(UserId));
    }
}