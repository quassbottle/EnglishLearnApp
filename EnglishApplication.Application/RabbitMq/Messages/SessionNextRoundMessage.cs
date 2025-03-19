namespace EnglishApplication.Application.RabbitMq.Messages;

/// <summary>
/// Сообщение о переходе к следующему раунду сессии.
/// </summary>
public class SessionNextRoundMessage
{
    /// <summary>
    /// Идентификатор сессии.
    /// </summary>
    public int SessionId { get; set; }

    /// <summary>
    /// Идентификатор текущего раунда.
    /// </summary>
    public int CurrentRoundId { get; set; }
}