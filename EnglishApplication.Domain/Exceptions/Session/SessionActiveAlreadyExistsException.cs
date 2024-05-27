using EnglishApplication.Domain.Exceptions.Shared;

namespace EnglishApplication.Domain.Exceptions.Session;

public class SessionActiveAlreadyExistsException() : BadRequestException("Active session already exists")
{
}