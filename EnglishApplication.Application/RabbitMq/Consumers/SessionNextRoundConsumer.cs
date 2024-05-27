using EnglishApplication.Common.RabbitMQ.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;

namespace EnglishApplication.Application.RabbitMq.Consumers;

public class SessionNextRoundConsumer : BackgroundService
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    
    public SessionNextRoundConsumer(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var factory = scope.ServiceProvider.GetRequiredService<IRabbitMqConnectionFactory>().CreateInstance();

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        
        _channel.QueueDeclare()
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("test");
    }

    public override void Dispose()
    {
        _channel.Close();
        _connection.Close();
        
        base.Dispose();
    }
}