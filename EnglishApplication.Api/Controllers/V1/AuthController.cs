using EnglishApplication.Application.Services.Interfaces;
using EnglishApplication.Controllers.Abstract;
using EnglishApplication.Models.Auth.Request;
using Microsoft.AspNetCore.Mvc;

namespace EnglishApplication.Controllers.V1;

public class AuthController(IAccountService accountService) : ApiControllerV1
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var result = await accountService.RegisterAsync(request);

        return Ok(result);
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var result = await accountService.RegisterAsync(request);

        return Ok(result);
    }
}