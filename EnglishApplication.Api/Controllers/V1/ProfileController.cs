using EnglishApplication.Application.Services.Interfaces;
using EnglishApplication.Controllers.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EnglishApplication.Controllers.V1;

public class ProfileController(IAccountService service) : ApiControllerV1
{
    /// <summary>
    /// Get the profile by ID
    /// </summary>
    /// <param name="id">User ID</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAccountById(int id)
    {
        return Ok(await service.GetByIdAsync(id));
    }

    /// <summary>
    /// Get the current session profile
    /// </summary>
    /// <returns></returns>
    [HttpGet("profile")]
    public async Task<IActionResult> GetProfile()
    {
        return Ok(await service.GetByIdAsync(UserId));
    }
}