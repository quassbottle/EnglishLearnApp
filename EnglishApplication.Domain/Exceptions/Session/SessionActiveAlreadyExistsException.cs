using EnglishApplication.Domain.Exceptions.Shared;

namespace EnglishApplication.Domain.Exceptions.Session;

/// <summary>
/// Исключение, указывающее на то, что активная сессия уже существует.
/// </summary>
public class SessionActiveAlreadyExistsException() : BadRequestException("Active session already exists");