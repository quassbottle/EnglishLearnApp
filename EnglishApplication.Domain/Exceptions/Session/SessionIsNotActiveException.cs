using EnglishApplication.Domain.Exceptions.Shared;

namespace EnglishApplication.Domain.Exceptions.Session;

public class SessionIsNotActiveException() : BadRequestException("Session is not active");