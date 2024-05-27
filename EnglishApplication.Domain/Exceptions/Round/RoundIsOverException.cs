using EnglishApplication.Domain.Exceptions.Shared;

namespace EnglishApplication.Domain.Exceptions.Round;

public class RoundIsOverException() : BadRequestException("This round is already over");