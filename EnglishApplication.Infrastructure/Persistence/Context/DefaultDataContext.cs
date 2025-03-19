using EnglishApplication.Domain.Entities;
using EnglishApplication.Infrastructure.Factories.Interfaces;
using EnglishApplication.Infrastructure.Persistence.Configuration;
using EnglishApplication.Infrastructure.Persistence.Seeding.Words;
using Microsoft.EntityFrameworkCore;

namespace EnglishApplication.Infrastructure.Persistence.Context
{
    /// <summary>
    /// Контекст данных по умолчанию для приложения.
    /// </summary>
    public class DefaultDataContext : DbContext
    {
        private readonly IDbConnectionFactory _factory;

        /// <summary>
        /// Инициализирует новый экземпляр контекста данных по умолчанию.
        /// </summary>
        /// <param name="factory">Фабрика соединений с базой данных.</param>
        public DefaultDataContext(IDbConnectionFactory factory)
        {
            _factory = factory;
        }

        /// <summary>
        /// Коллекция учетных записей в базе данных.
        /// </summary>
        public DbSet<DbAccount> Accounts { get; set; }

        /// <summary>
        /// Коллекция раундов в базе данных.
        /// </summary>
        public DbSet<DbRound> Rounds { get; set; }

        /// <summary>
        /// Коллекция информации о пользователях в базе данных.
        /// </summary>
        public DbSet<DbUserInfo> UserInfos { get; set; }

        /// <summary>
        /// Коллекция слов в базе данных.
        /// </summary>
        public DbSet<DbWord> Words { get; set; }

        /// <summary>
        /// Коллекция сессий в базе данных.
        /// </summary>
        public DbSet<DbSession> Sessions { get; set; }

        /// <summary>
        /// Настраивает контекст данных.
        /// </summary>
        /// <param name="optionsBuilder">Построитель опций контекста данных.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_factory.CreateAsync().GetAwaiter().GetResult());
            optionsBuilder.EnableSensitiveDataLogging();
        }

        /// <summary>
        /// Настраивает модели данных.
        /// </summary>
        /// <param name="modelBuilder">Построитель моделей данных.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new UserInfoConfiguration());
            modelBuilder.ApplyConfiguration(new WordConfiguration());
            modelBuilder.ApplyConfiguration(new SessionConfiguration());
            modelBuilder.ApplyConfiguration(new RoundConfiguration());

            modelBuilder.SeedWords();
        }
    }
}
