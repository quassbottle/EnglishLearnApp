using Microsoft.AspNetCore.Mvc;

namespace EnglishApplication.Controllers.Abstract;

[ApiController]
[Route("v1/[controller]")]
public abstract class ApiControllerV1 : BaseAuthController
{
}