using EnglishApplication.Domain.Aggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnglishApplication.Infrastructure.Persistence.Configuration;

public class LearnedWordConfiguration : IEntityTypeConfiguration<LearnedWord>
{
    public void Configure(EntityTypeBuilder<LearnedWord> builder)
    {
        builder.ToTable("LearnedWords");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();

        builder
            .HasOne(lw => lw.UserInfo)
            .WithMany(ui => ui.LearnedWords)
            .HasForeignKey(lw => lw.UserInfoId);

        builder
            .HasOne(lw => lw.Word)
            .WithMany(w => w.LearnedWords)
            .HasForeignKey(lw => lw.WordId);
    }
}