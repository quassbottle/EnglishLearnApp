using EnglishApplication.Domain.Exceptions.Shared;

namespace EnglishApplication.Domain.Exceptions.Round;

/// <summary>
/// Исключение, указывающее на то, что раунд уже завершен.
/// </summary>
public class RoundIsOverException() : BadRequestException("This round is already over");