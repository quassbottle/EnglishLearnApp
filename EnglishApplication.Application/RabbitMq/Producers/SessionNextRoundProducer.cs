using System.Text;
using System.Text.Json;
using EnglishApplication.Application.Dto;
using EnglishApplication.Application.RabbitMq.Messages;
using EnglishApplication.Common.RabbitMQ.Interfaces;

namespace EnglishApplication.Application.RabbitMq.Producers;

public class SessionNextRoundProducer(IRabbitMqConnectionFactory factory): IRabbitMqProducer<SessionNextRoundMessage>
{
    public Task SendAsync(SessionNextRoundMessage message)
    {
        const string queueName = "rounds";
        const string delayBind = "delayBind";
        const string exchange = "roundExchange";
        const int delay = 30 * 1000;
        
        using var connection = factory.CreateInstance().CreateConnection();
        using var channel = connection.CreateModel();
        
        IDictionary<string, object> args = new Dictionary<string, object> { { "x-delayed-type", "direct" } };
        channel.ExchangeDeclare(exchange, "x-delayed-message", true, false, args);

        var queue = channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
        channel.QueueBind(queue, exchange, delayBind, null);

        var basicProperties = channel.CreateBasicProperties();
        basicProperties.Headers = new Dictionary<string, object> { { "x-delay", delay } };

        channel.BasicPublish(exchange, delayBind, true, basicProperties, Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message)));
        
        Console.WriteLine(" [x] Sent {0}", JsonSerializer.Serialize(message));

        return Task.CompletedTask;
    }
}