namespace EnglishApplication.Common.RabbitMQ.Interfaces;

public interface IRabbitMqProducer<in TMessage> : IDisposable
{
    Task SendAsync(TMessage message);
}