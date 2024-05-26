using System.Data;
using System.Data.Common;
using EnglishApplication.Domain.Entities;
using EnglishApplication.Infrastructure.Persistence.Configuration;
using EnglishApplication.Infrastructure.Persistence.Factories;
using EnglishApplication.Infrastructure.Persistence.Seeding;
using EnglishApplication.Infrastructure.Persistence.Seeding.Words;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EnglishApplication.Infrastructure.Persistence.Context;

public class DefaultDataContext(IDbConnectionFactory factory) : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(factory.CreateAsync().GetAwaiter().GetResult());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
        modelBuilder.ApplyConfiguration(new UserInfoConfiguration());
        modelBuilder.ApplyConfiguration(new WordConfiguration());
        modelBuilder.ApplyConfiguration(new SessionConfiguration());
        modelBuilder.ApplyConfiguration(new RoundConfiguration());
        
        modelBuilder.SeedWords();
    }

    public DbSet<DbAccount> Accounts { get; set; }
    public DbSet<DbRound> Rounds { get; set; }
    public DbSet<DbUserInfo> UserInfos { get; set; }
    public DbSet<DbWord> Words { get; set; }
    public DbSet<DbSession> Sessions { get; set; }
}