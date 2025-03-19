namespace EnglishApplication.Application.Dto;

/// <summary>
/// DTO (Data Transfer Object) для представления данных слова.
/// </summary>
public class WordDto
{
    /// <summary>
    /// Идентификатор слова.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Слово на английском языке.
    /// </summary>
    public string English { get; set; }

    /// <summary>
    /// Слово на русском языке.
    /// </summary>
    public string Russian { get; set; }
}