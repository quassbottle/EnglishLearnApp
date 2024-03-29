using System.Data;
using EnglishApplication.Domain.Repositories;
using EnglishApplication.Infrastructure.Persistence.Context;
using EnglishApplication.Infrastructure.Persistence.Factories;
using EnglishApplication.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EnglishApplication.Infrastructure.Extensions;

public static class InfrastructureHostExtensions
{
    public static void MigrateDatabase<TContext>(this IHost host) where TContext : DbContext
    {
        using var scope = host.Services.CreateScope();
        using var context = scope.ServiceProvider.GetService<TContext>();
        context.Database.Migrate();
    }

    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IDbConnectionFactory, DefaultConnectionFactory>();
        
        services.AddDbContext<DefaultDataContext>();

        services.AddScoped<IAccountRepository, AccountRepository>();
    }
}