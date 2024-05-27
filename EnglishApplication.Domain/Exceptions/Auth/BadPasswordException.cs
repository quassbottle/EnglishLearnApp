using EnglishApplication.Domain.Exceptions.Shared;

namespace EnglishApplication.Domain.Exceptions.Auth;

public class BadPasswordException() : BadRequestException("Bad password");