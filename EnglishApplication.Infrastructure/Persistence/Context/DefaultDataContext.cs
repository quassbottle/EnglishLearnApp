using System.Data;
using System.Data.Common;
using EnglishApplication.Domain.Aggregate;
using EnglishApplication.Infrastructure.Persistence.Configuration;
using EnglishApplication.Infrastructure.Persistence.Factories;
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
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new LearnedWordConfiguration());
        modelBuilder.ApplyConfiguration(new UserInfoConfiguration());
        modelBuilder.ApplyConfiguration(new WordConfiguration());
    }
    
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<LearnedWord> LearnedWords { get; set; }
    public DbSet<UserInfo> UserInfos { get; set; }
    public DbSet<Word> Words { get; set; }
}