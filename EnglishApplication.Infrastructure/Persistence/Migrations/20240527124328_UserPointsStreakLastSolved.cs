using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnglishApplication.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UserPointsStreakLastSolved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "last_solved",
                table: "user_info",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "points",
                table: "user_info",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "streak",
                table: "user_info",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "last_solved",
                table: "user_info");

            migrationBuilder.DropColumn(
                name: "points",
                table: "user_info");

            migrationBuilder.DropColumn(
                name: "streak",
                table: "user_info");
        }
    }
}
