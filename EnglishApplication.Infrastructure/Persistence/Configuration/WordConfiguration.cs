using EnglishApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnglishApplication.Infrastructure.Persistence.Configuration;

public class WordConfiguration : IEntityTypeConfiguration<DbWord>
{
    public void Configure(EntityTypeBuilder<DbWord> builder)
    {
        builder.ToTable("word");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.English)
            .HasColumnName("english");

        builder.Property(e => e.Russian)
            .HasColumnName("russian");
    }
}