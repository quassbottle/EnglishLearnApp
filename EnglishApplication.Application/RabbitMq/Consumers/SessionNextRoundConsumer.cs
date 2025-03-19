using System.Text.Json;
using EnglishApplication.Application.RabbitMq.Messages;
using EnglishApplication.Application.Services.Interfaces;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EnglishApplication.Application.RabbitMq.Consumers;

/// <summary>
/// Консьюмер для обработки сообщения о переходе к следующему раунду сессии.
/// </summary>
/// <remarks>
/// Используется для автоматического перехода раундов внутри сессии независимо от работы веб-сервера.
/// </remarks>
public class SessionNextRoundConsumer
    (IBusRegistrationContext busContext, ILogger<SessionNextRoundConsumer> logger) : IConsumer<SessionNextRoundMessage>
{
    /// <summary>
    /// Обрабатывает полученное сообщение о переходе к следующему раунду сессии.
    /// </summary>
    /// <param name="context">Контекст полученного сообщения.</param>
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