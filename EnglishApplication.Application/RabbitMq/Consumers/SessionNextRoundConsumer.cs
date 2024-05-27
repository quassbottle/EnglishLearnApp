using System.Text.Json;
using EnglishApplication.Application.RabbitMq.Messages;
using EnglishApplication.Application.Services.Interfaces;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EnglishApplication.Application.RabbitMq.Consumers;

public class SessionNextRoundConsumer(IBusRegistrationContext busContext, ILogger<SessionNextRoundConsumer> logger) : IConsumer<SessionNextRoundMessage>
{
    public async Task Consume(ConsumeContext<SessionNextRoundMessage> context)
    {
        using var scope = busContext.CreateScope();

        var service = scope.ServiceProvider.GetRequiredService<ISessionService>();
        
        var session = await service.GetByIdAsync(context.Message.SessionId);
        var currentRound = await service.GetCurrentRoundAsync(session.Id);

        if (currentRound.Id == context.Message.CurrentRoundId)
        {
            await service.MoveNextRoundAsync(session.Id);
            
            logger.LogInformation($"Session {session.Id} is moving to the next round");
        }

    } 
}