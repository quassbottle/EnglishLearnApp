using EnglishApplication.Application.RabbitMq.Consumers;
using EnglishApplication.Application.RabbitMq.Messages;
using EnglishApplication.Application.Services;
using EnglishApplication.Application.Services.Interfaces;
using EnglishApplication.Common.RabbitMQ;
using EnglishApplication.Common.RabbitMQ.Interfaces;
using MassTransit;

namespace EnglishApplication.Extensions;

public static class RabbitMqHostExtensions
{
    public static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IRabbitMqSettings, RabbitMqSettings>();
        services.AddSingleton<IRabbitMqConnectionFactory, RabbitMqConnectionFactory>();

        services.AddScoped<SessionNextRoundConsumer>();

        services.AddMassTransit(x =>
        {
            var section = configuration.GetSection("RabbitMq");
            
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(section["Host"], ushort.Parse(section["Port"]), "/", h => {
                    h.Username(section["User"]);
                    h.Password(section["Password"]);
                });
                
                cfg.UseDelayedMessageScheduler();
                
                cfg.Publish<SessionNextRoundMessage>(p => {
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