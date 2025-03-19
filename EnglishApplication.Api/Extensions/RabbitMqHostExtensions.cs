using EnglishApplication.Application.RabbitMq.Consumers;
using EnglishApplication.Application.RabbitMq.Messages;
using MassTransit;

namespace EnglishApplication.Extensions;

/// <summary>
/// Расширения для настройки RabbitMQ хоста.
/// </summary>
/// <remarks>
/// В этом классе содержатся методы для настройки подключения и работы с RabbitMQ.
/// </remarks>
public static class RabbitMqHostExtensions
{
    /// <summary>
    /// Добавляет настройки RabbitMQ в сервисы приложения.
    /// </summary>
    /// <param name="services">Коллекция сервисов.</param>
    /// <param name="configuration">Конфигурация приложения.</param>
    public static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<SessionNextRoundConsumer>();

        services.AddMassTransit(x =>
        {
            var section = configuration.GetSection("RabbitMq");

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(section["Host"], ushort.Parse(section["Port"]), "/", h =>
                {
                    h.Username(section["User"]);
                    h.Password(section["Password"]);
                });

                cfg.UseDelayedMessageScheduler();

                cfg.Publish<SessionNextRoundMessage>(p =>
                {
                    p.ExchangeType = "x-delayed-message";
                    p.Durable = true;
                    p.AutoDelete = false;
                    p.SetExchangeArgument("x-delayed-type", "direct");
                });

                cfg.ReceiveEndpoint(section["SessionNextRoundQueue"], e =>
                {
                    e.Consumer<SessionNextRoundConsumer>(context);
                    e.UseRawJsonDeserializer();
                });

                cfg.ConfigureEndpoints(context);
            });
        });
    }
}
