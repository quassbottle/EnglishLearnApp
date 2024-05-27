namespace EnglishApplication.Common.RabbitMQ.Interfaces;

public interface IRabbitMqProducer<in TMessage>
{
    Task SendAsync(TMessage message);
}