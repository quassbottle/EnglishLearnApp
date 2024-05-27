namespace EnglishApplication.Application.RabbitMq.Messages;

public class SessionNextRoundMessage
{
    public int SessionId { get; set; }
    public int CurrentRoundId { get; set; }
}