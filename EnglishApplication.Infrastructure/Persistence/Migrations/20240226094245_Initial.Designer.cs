﻿// <auto-generated />
using EnglishApplication.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EnglishApplication.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(DefaultDataContext))]
    [Migration("20240226094245_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EnglishApplication.Domain.Aggregate.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserInfoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Accounts", (string)null);
                });

            modelBuilder.Entity("EnglishApplication.Domain.Aggregate.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Name")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("EnglishApplication.Domain.Aggregate.LearnedWord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("GuessedTimes")
                        .HasColumnType("integer");

                    b.Property<int>("UserInfoId")
                        .HasColumnType("integer");

                    b.Property<int>("WordId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserInfoId");

                    b.HasIndex("WordId");

                    b.ToTable("LearnedWords", (string)null);
                });

            modelBuilder.Entity("EnglishApplication.Domain.Aggregate.UserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("UserInfos", (string)null);
                });

            modelBuilder.Entity("EnglishApplication.Domain.Aggregate.Word", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Words", (string)null);
                });

            modelBuilder.Entity("EnglishApplication.Domain.Aggregate.LearnedWord", b =>
                {
                    b.HasOne("EnglishApplication.Domain.Aggregate.UserInfo", "UserInfo")
                        .WithMany("LearnedWords")
                        .HasForeignKey("UserInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnglishApplication.Domain.Aggregate.Word", "Word")
                        .WithMany("LearnedWords")
                        .HasForeignKey("WordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserInfo");

                    b.Navigation("Word");
                });

            modelBuilder.Entity("EnglishApplication.Domain.Aggregate.UserInfo", b =>
                {
                    b.HasOne("EnglishApplication.Domain.Aggregate.Account", "Account")
                        .WithOne("UserInfo")
                        .HasForeignKey("EnglishApplication.Domain.Aggregate.UserInfo", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("EnglishApplication.Domain.Aggregate.Word", b =>
                {
                    b.HasOne("EnglishApplication.Domain.Aggregate.Category", "Category")
                        .WithMany("Words")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("EnglishApplication.Domain.Aggregate.Account", b =>
                {
                    b.Navigation("UserInfo")
                        .IsRequired();
                });

            modelBuilder.Entity("EnglishApplication.Domain.Aggregate.Category", b =>
                {
                    b.Navigation("Words");
                });

            modelBuilder.Entity("EnglishApplication.Domain.Aggregate.UserInfo", b =>
                {
                    b.Navigation("LearnedWords");
                });

            modelBuilder.Entity("EnglishApplication.Domain.Aggregate.Word", b =>
                {
                    b.Navigation("LearnedWords");
                });
#pragma warning restore 612, 618
        }
    }
}
