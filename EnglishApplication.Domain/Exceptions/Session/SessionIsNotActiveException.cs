using EnglishApplication.Domain.Exceptions.Shared;

namespace EnglishApplication.Domain.Exceptions.Session;

/// <summary>
/// Исключение, указывающее на то, что сессия не активна.
/// </summary>
public class SessionIsNotActiveException() : BadRequestException("Session is not active");