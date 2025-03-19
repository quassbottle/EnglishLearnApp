using EnglishApplication.Domain.Repositories;
using EnglishApplication.Infrastructure.Factories;
using EnglishApplication.Infrastructure.Factories.Interfaces;
using EnglishApplication.Infrastructure.Persistence.Context;
using EnglishApplication.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EnglishApplication.Extensions;

/// <summary>
/// Расширения для настройки инфраструктурных компонентов приложения.
/// </summary>
/// <remarks>
/// Этот класс содержит методы для настройки базы данных и регистрации репозиториев и фабрик в контейнере зависимостей.
/// </remarks>
public static class InfrastructureHostExtensions
{
    /// <summary>
    /// Выполняет миграцию базы данных для указанного контекста.
    /// </summary>
    /// <typeparam name="TContext">Тип контекста базы данных, наследуемый от DbContext.</typeparam>
    /// <param name="host">Экземпляр IHost, используемый для получения сервисов.</param>
    public static void MigrateDatabase<TContext>(this IHost host) where TContext : DbContext
    {
        using var scope = host.Services.CreateScope();
        using var context = scope.ServiceProvider.GetService<TContext>();
        context.Database.Migrate();
    }

    /// <summary>
    /// Добавляет инфраструктурные сервисы в коллекцию сервисов.
    /// </summary>
    /// <param name="services">Коллекция сервисов.</param>
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IDbConnectionFactory, DefaultConnectionFactory>();

        services.AddDbContext<DefaultDataContext>();

        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IUserInfoRepository, UserInfoRepository>();
        services.AddScoped<ISessionRepository, SessionRepository>();
        services.AddScoped<IWordRepository, WordRepository>();
        services.AddScoped<IRoundRepository, RoundRepository>();
    }
}