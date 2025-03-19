using EnglishApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnglishApplication.Infrastructure.Persistence.Configuration;

/// <summary>
/// Конфигурация сущности информации о пользователе для Entity Framework Core.
/// </summary>
public class UserInfoConfiguration : IEntityTypeConfiguration<DbUserInfo>
{
    /// <summary>
    /// Настраивает сущность информации о пользователе для хранения в базе данных.
    /// </summary>
    public void Configure(EntityTypeBuilder<DbUserInfo> builder)
    {
        builder.ToTable("user_info");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Username)
            .HasColumnName("username");

        builder.Property(e => e.AccountId)
            .HasColumnName("account_id");

        builder.Property(e => e.LastSolved)
            .HasColumnName("last_solved");

        builder.Property(e => e.Points)
            .HasColumnName("points");

        builder.Property(e => e.Streak)
            .HasColumnName("streak");

        builder.HasAlternateKey(e => e.Username);

        builder
            .HasMany(e => e.Sessions)
            .WithOne(e => e.UserInfo);
    }
}