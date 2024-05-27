using EnglishApplication.Application.Services.Interfaces;
using EnglishApplication.Controllers.Abstract;
using EnglishApplication.Models.Auth.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnglishApplication.Controllers.V1;

[AllowAnonymous]
public class AuthController(IAuthenticationService authService) : ApiControllerV1
{
    /// <summary>
    /// Log in account
    /// </summary>
    /// <param name="request">Log in params</param>
    /// <returns></returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var (email, password) = request;
        
        var result = await authService.LoginAsync(email, password);

        return Ok(result);
    }

    /// <summary>
    /// Register an account
    /// </summary>
    /// <param name="request">Register params</param>
    /// <returns></returns>
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var (email, username, password) = request;
        
        var result = await authService.RegisterAsync(email, username, password);

        return Ok(result);
    }
}