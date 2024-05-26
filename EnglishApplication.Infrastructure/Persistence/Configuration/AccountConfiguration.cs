using EnglishApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnglishApplication.Infrastructure.Persistence.Configuration;

public class AccountConfiguration : IEntityTypeConfiguration<DbAccount>
{
    public void Configure(EntityTypeBuilder<DbAccount> builder)
    {
        builder.ToTable("account");

        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();
        
        builder.Property(e => e.Email)
            .HasColumnName("email");

        builder.Property(e => e.HashedPassword)
            .HasColumnName("hashed_password");

        builder.Property(e => e.UserInfoId)
            .HasColumnName("user_info_id");
        
        builder
            .HasOne(e => e.DbUserInfo)
            .WithOne(e => e.DbAccount)
            .HasForeignKey<DbUserInfo>(e => e.AccountId);
    }
}