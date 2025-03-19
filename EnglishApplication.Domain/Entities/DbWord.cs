namespace EnglishApplication.Domain.Entities;

/// <summary>
/// Представляет сущность слова в базе данных.
/// </summary>
public class DbWord
{
    /// <summary>
    /// Получает или задает идентификатор слова.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Получает или задает английское представление слова.
    /// </summary>
    public string English { get; set; }

    /// <summary>
    /// Получает или задает русское представление слова.
    /// </summary>
    public string Russian { get; set; }

    /// <summary>
    /// Получает или задает коллекцию раундов, связанных с данным словом.
    /// </summary>
    public ICollection<DbRound> Rounds { get; set; }
}