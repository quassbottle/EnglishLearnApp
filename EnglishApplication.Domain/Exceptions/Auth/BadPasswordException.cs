using EnglishApplication.Domain.Exceptions.Shared;

namespace EnglishApplication.Domain.Exceptions.Auth;

/// <summary>
/// Исключение, указывающее на то, что пароль недействителен.
/// </summary>
public class BadPasswordException() : BadRequestException("Bad password");