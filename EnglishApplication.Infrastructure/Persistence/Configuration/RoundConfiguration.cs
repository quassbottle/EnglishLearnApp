using EnglishApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnglishApplication.Infrastructure.Persistence.Configuration;

public class RoundConfiguration : IEntityTypeConfiguration<DbRound>
{
    public void Configure(EntityTypeBuilder<DbRound> builder)
    {
        builder.ToTable("round");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.StartTime)
            .HasColumnName("start_time")
            .HasDefaultValue(DateTime.Now);

        builder.Property(e => e.EndTime)
            .HasColumnName("end_time");

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