using EnglishApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnglishApplication.Infrastructure.Persistence.Configuration;

public class SessionConfiguration : IEntityTypeConfiguration<DbSession>
{
    public void Configure(EntityTypeBuilder<DbSession> builder)
    {
        builder.ToTable("session");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.UserInfoId)
            .HasColumnName("user_info_id");

        builder.Property(e => e.Active)
            .HasColumnName("active")
            .HasDefaultValue(true);

        builder.HasMany(e => e.Rounds)
            .WithOne(e => e.Session)
            .HasForeignKey(e => e.SessionId);
    }
}