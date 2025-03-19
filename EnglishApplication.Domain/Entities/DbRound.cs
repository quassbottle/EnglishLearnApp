namespace EnglishApplication.Domain.Entities;

/// <summary>
/// Представляет сущность раунда в базе данных.
/// </summary>
public class DbRound
{
    /// <summary>
    /// Получает или задает идентификатор раунда.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Получает или задает время начала раунда.
    /// </summary>
    public DateTime StartTime { get; set; }

    /// <summary>
    /// Получает или задает время завершения раунда.
    /// </summary>
    public DateTime? EndTime { get; set; }

    /// <summary>
    /// Получает или задает слово, связанное с раундом.
    /// </summary>
    public DbWord Word { get; set; }

    /// <summary>
    /// Получает или задает идентификатор слова, связанного с раундом.
    /// </summary>
    public int WordId { get; set; }

    /// <summary>
    /// Получает или задает флаг, указывающий, было ли угадано слово в раунде.
    /// </summary>
    public bool? Guessed { get; set; }

    /// <summary>
    /// Получает или задает сессию, связанную с раундом.
    /// </summary>
    public DbSession Session { get; set; }

    /// <summary>
    /// Получает или задает идентификатор сессии, связанной с раундом.
    /// </summary>
    public int SessionId { get; set; }
}