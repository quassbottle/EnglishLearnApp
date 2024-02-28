using System.Data;
using System.Data.Common;

namespace EnglishApplication.Infrastructure.Persistence.Factories;

public interface IDbConnectionFactory
{
    Task<DbConnection> CreateAsync();
}