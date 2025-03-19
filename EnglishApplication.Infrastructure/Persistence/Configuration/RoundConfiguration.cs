using EnglishApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnglishApplication.Infrastructure.Persistence.Configuration;

/// <summary>
/// Конфигурация сущности раунда для Entity Framework Core.
/// </summary>
public class RoundConfiguration : IEntityTypeConfiguration<DbRound>
{
    /// <summary>
    /// Настраивает сущность раунда для хранения в базе данных.
    /// </summary>
    public void Configure(EntityTypeBuilder<DbRound> builder)
    {
        builder.ToTable("round");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.StartTime)
            .HasColumnName("start_time");

        builder.Property(e => e.EndTime)
            .HasColumnName("end_time")
            .IsRequired(false);

        builder.Property(e => e.WordId)
            .HasColumnName("word_id");

        builder.Property(e => e.Guessed)
            .HasColumnName("guessed");

        builder.Property(e => e.SessionId)
            .HasColumnName("session_id");

        builder.HasOne(e => e.Word)
            .WithMany(e => e.Rounds)
            .HasForeignKey(e => e.WordId);
    }
}