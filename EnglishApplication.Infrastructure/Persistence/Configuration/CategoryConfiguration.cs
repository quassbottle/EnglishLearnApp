using EnglishApplication.Domain.Aggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnglishApplication.Infrastructure.Persistence.Configuration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();

        /*
        builder
            .HasMany(c => c.Words)
            .WithOne(w => w.Category)
            .HasForeignKey(w => w.CategoryId);*/
    }
}