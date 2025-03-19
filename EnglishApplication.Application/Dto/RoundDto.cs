namespace EnglishApplication.Application.Dto;

/// <summary>
/// DTO (Data Transfer Object) для представления данных раунда.
/// </summary>
public class RoundDto
{
    /// <summary>
    /// Идентификатор раунда.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Время начала раунда.
    /// </summary>
    public DateTime StartTime { get; set; }

    /// <summary>
    /// Время завершения раунда (если раунд завершен).
    /// </summary>
    public DateTime? EndTime { get; set; }

    /// <summary>
    /// Флаг, указывающий, было ли слово угадано в раунде.
    /// </summary>
    public bool? Guessed { get; set; }

    /// <summary>
    /// DTO (Data Transfer Object) для представления данных слова, связанного с раундом.
    /// </summary>
    public WordDto Word { get; set; }
}