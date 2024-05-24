using System.Data.Common;
using EnglishApplication.Infrastructure.Persistence.Factories;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace EnglishApplication.Infrastructure.Factories;

public class DefaultConnectionFactory(IConfiguration configuration) : IDbConnectionFactory
{
    public async Task<DbConnection> CreateAsync()
    {
        var connection = new NpgsqlConnection(configuration.GetConnectionString("Default"));
        await connection.OpenAsync();
        return connection;
    }
}