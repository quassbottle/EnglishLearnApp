namespace EnglishApplication.Common.RabbitMQ.Interfaces;

public interface IRabbitMqSettings
{
    public string Host { get; }
    public string User { get; }
    public string Password { get; }
    public int Port { get; }
    public string SessionNextRoundQueue { get; }
}