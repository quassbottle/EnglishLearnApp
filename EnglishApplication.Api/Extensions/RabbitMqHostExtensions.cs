using EnglishApplication.Application.RabbitMq.Consumers;
using EnglishApplication.Application.RabbitMq.Messages;
using EnglishApplication.Application.RabbitMq.Producers;
using EnglishApplication.Common.RabbitMQ;
using EnglishApplication.Common.RabbitMQ.Interfaces;

namespace EnglishApplication.Extensions;

public static class RabbitMqHostExtensions
{
    public static void AddRabbitMq(this IServiceCollection services)
    {
        services.AddSingleton<IRabbitMqSettings, RabbitMqSettings>();
        services.AddSingleton<IRabbitMqConnectionFactory, RabbitMqConnectionFactory>();

        services.AddSingleton<IRabbitMqProducer<SessionNextRoundMessage>, SessionNextRoundProducer>();

        services.AddHostedService<SessionNextRoundConsumer>();
    }
}