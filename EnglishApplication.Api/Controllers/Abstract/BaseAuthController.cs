using EnglishApplication.Common.Authentication.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnglishApplication.Controllers.Abstract;

[Authorize]
[ApiController]
public abstract class BaseAuthController : ControllerBase
{
    private string AuthHeader => HttpContext.Request.Headers.Authorization.ToString();

    protected int UserId => int.Parse(JwtReader.GetId(AuthHeader));
    protected string Role => JwtReader.GetRole(AuthHeader);
    protected string Email => JwtReader.GetEmail(AuthHeader);
}