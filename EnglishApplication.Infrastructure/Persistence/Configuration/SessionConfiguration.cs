using EnglishApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnglishApplication.Infrastructure.Persistence.Configuration;

public class SessionConfiguration : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
    {        
        builder.ToTable("Sessions");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();

        builder.Property(e => e.StartTime).HasDefaultValue(DateTime.Now.ToUniversalTime());
        
        builder
            .HasMany(e => e.Words)
            .WithOne(e => e.Session);
    }
}