using EnglishApplication.Application.Services.Interfaces;
using EnglishApplication.Controllers.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EnglishApplication.Controllers.V1;

public class AccountController(IAccountService service) : ApiControllerV1
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAccountById(int id)
    {
        return Ok(await service.GetByIdAsync(id));
    }

    [HttpGet("profile")]
    public async Task<IActionResult> GetProfile()
    {
        return Ok(await service.GetByIdAsync(Id));
    }
}