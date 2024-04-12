using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EnglishApplication.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    HashedPassword = table.Column<string>(type: "text", nullable: false),
                    UserInfoId = table.Column<int>(type: "integer", nullable: false),
                    RefreshTokenId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<string>(type: "text", nullable: false),
                    Translation = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Token = table.Column<string>(type: "text", nullable: false),
                    AccountId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    AccountId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfos", x => x.Id);
                    table.UniqueConstraint("AK_UserInfos_Username", x => x.Username);
                    table.ForeignKey(
                        name: "FK_UserInfos_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LearnedWords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WordId = table.Column<int>(type: "integer", nullable: false),
                    UserInfoId = table.Column<int>(type: "integer", nullable: false),
                    GuessedTimes = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearnedWords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LearnedWords_UserInfos_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "UserInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LearnedWords_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "Id", "Translation", "Value" },
                values: new object[,]
                {
                    { 1, "слово", "word" },
                    { 2, "дом", "house" },
                    { 3, "кот", "cat" },
                    { 4, "собака", "dog" },
                    { 5, "дерево", "tree" },
                    { 6, "книга", "book" },
                    { 7, "компьютер", "computer" },
                    { 8, "небо", "sky" },
                    { 9, "солнце", "sun" },
                    { 10, "луна", "moon" },
                    { 11, "яблоко", "apple" },
                    { 12, "банан", "banana" },
                    { 13, "машина", "car" },
                    { 14, "стол", "table" },
                    { 15, "стул", "chair" },
                    { 16, "ручка", "pen" },
                    { 17, "карандаш", "pencil" },
                    { 18, "окно", "window" },
                    { 19, "дверь", "door" },
                    { 20, "телефон", "phone" },
                    { 21, "планшет", "tablet" },
                    { 22, "стул", "chair" },
                    { 23, "лампа", "lamp" },
                    { 24, "часы", "clock" },
                    { 25, "книжная полка", "bookshelf" },
                    { 26, "кровать", "bed" },
                    { 27, "окно", "window" },
                    { 28, "чашка", "cup" },
                    { 29, "ложка", "spoon" },
                    { 30, "вилка", "fork" },
                    { 31, "нож", "knife" },
                    { 32, "тарелка", "plate" },
                    { 33, "телевизор", "television" },
                    { 34, "пульт", "remote" },
                    { 35, "наушники", "headphones" },
                    { 36, "гитара", "guitar" },
                    { 37, "микрофон", "microphone" },
                    { 38, "колонка", "speaker" },
                    { 39, "клавиатура", "keyboard" },
                    { 40, "мышь", "mouse" },
                    { 41, "скатерть", "tablecloth" },
                    { 42, "салфетка", "napkin" },
                    { 43, "тарелка", "plate" },
                    { 44, "шкаф", "cupboard" },
                    { 45, "зеркало", "mirror" },
                    { 46, "полотенце", "towel" },
                    { 47, "щетка", "brush" },
                    { 48, "зубная паста", "toothpaste" },
                    { 49, "шампунь", "shampoo" },
                    { 50, "мыло", "soap" },
                    { 51, "зубная щетка", "toothbrush" },
                    { 52, "бритва", "razor" },
                    { 53, "расческа", "comb" },
                    { 54, "туалет", "toilet" },
                    { 55, "раковина", "sink" },
                    { 56, "ванна", "bathtub" },
                    { 57, "душ", "shower" },
                    { 58, "полотенце", "towel" },
                    { 59, "туалетная бумага", "toilet paper" },
                    { 60, "мусорное ведро", "trash can" },
                    { 61, "холодильник", "fridge" },
                    { 62, "морозильник", "freezer" },
                    { 63, "духовка", "oven" },
                    { 64, "микроволновая печь", "microwave" },
                    { 65, "плита", "stove" },
                    { 66, "чайник", "kettle" },
                    { 67, "кофеварка", "coffeemaker" },
                    { 68, "посудомоечная машина", "dishwasher" },
                    { 69, "стиральная машина", "washing machine" },
                    { 70, "сушилка", "dryer" },
                    { 71, "утюг", "iron" },
                    { 72, "гладильная доска", "ironing board" },
                    { 73, "пылесос", "vacuum cleaner" },
                    { 74, "метла", "broom" },
                    { 75, "швабра", "mop" },
                    { 76, "ведро", "bucket" },
                    { 77, "лопата для мусора", "dustpan" },
                    { 78, "губка", "sponge" },
                    { 79, "моющее средство", "dish soap" },
                    { 80, "сушилка для посуды", "dish rack" },
                    { 81, "спальня", "bedroom" },
                    { 82, "гостиная", "living room" },
                    { 83, "кухня", "kitchen" },
                    { 84, "ванная комната", "bathroom" },
                    { 85, "столовая", "dining room" },
                    { 86, "офис", "office" },
                    { 87, "гараж", "garage" },
                    { 88, "сад", "garden" },
                    { 89, "балкон", "balcony" },
                    { 90, "крыльцо", "porch" },
                    { 91, "двор", "yard" },
                    { 92, "улица", "street" },
                    { 93, "парк", "park" },
                    { 94, "школа", "school" },
                    { 95, "больница", "hospital" },
                    { 96, "супермаркет", "supermarket" },
                    { 97, "банк", "bank" },
                    { 98, "почта", "post office" },
                    { 99, "библиотека", "library" },
                    { 100, "ресторан", "restaurant" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LearnedWords_UserInfoId",
                table: "LearnedWords",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_LearnedWords_WordId",
                table: "LearnedWords",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_AccountId",
                table: "RefreshToken",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserInfos_AccountId",
                table: "UserInfos",
                column: "AccountId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LearnedWords");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "UserInfos");

            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
