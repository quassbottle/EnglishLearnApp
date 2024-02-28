namespace EnglishApplication.Domain.Exceptions.Shared;

public abstract class NotFoundException(string message) : Exception(message);