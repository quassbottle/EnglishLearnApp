using System;
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
                name: "account",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email = table.Column<string>(type: "text", nullable: false),
                    hashed_password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "word",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    english = table.Column<string>(type: "text", nullable: false),
                    russian = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_word", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_info",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "text", nullable: false),
                    account_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_info", x => x.id);
                    table.UniqueConstraint("AK_user_info_username", x => x.username);
                    table.ForeignKey(
                        name: "FK_user_info_account_account_id",
                        column: x => x.account_id,
                        principalTable: "account",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "session",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_info_id = table.Column<int>(type: "integer", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_session", x => x.id);
                    table.ForeignKey(
                        name: "FK_session_user_info_user_info_id",
                        column: x => x.user_info_id,
                        principalTable: "user_info",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "round",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    start_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    word_id = table.Column<int>(type: "integer", nullable: false),
                    guessed = table.Column<bool>(type: "boolean", nullable: true),
                    session_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_round", x => x.id);
                    table.ForeignKey(
                        name: "FK_round_session_session_id",
                        column: x => x.session_id,
                        principalTable: "session",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_round_word_word_id",
                        column: x => x.word_id,
                        principalTable: "word",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "word",
                columns: new[] { "id", "english", "russian" },
                values: new object[,]
                {
                    { 1, "word", "слово" },
                    { 2, "house", "дом" },
                    { 3, "cat", "кот" },
                    { 4, "dog", "собака" },
                    { 5, "tree", "дерево" },
                    { 6, "book", "книга" },
                    { 7, "computer", "компьютер" },
                    { 8, "sky", "небо" },
                    { 9, "sun", "солнце" },
                    { 10, "moon", "луна" },
                    { 11, "apple", "яблоко" },
                    { 12, "banana", "банан" },
                    { 13, "car", "машина" },
                    { 14, "table", "стол" },
                    { 15, "chair", "стул" },
                    { 16, "pen", "ручка" },
                    { 17, "pencil", "карандаш" },
                    { 18, "window", "окно" },
                    { 19, "door", "дверь" },
                    { 20, "phone", "телефон" },
                    { 21, "tablet", "планшет" },
                    { 22, "chair", "стул" },
                    { 23, "lamp", "лампа" },
                    { 24, "clock", "часы" },
                    { 25, "bookshelf", "книжная полка" },
                    { 26, "bed", "кровать" },
                    { 27, "window", "окно" },
                    { 28, "cup", "чашка" },
                    { 29, "spoon", "ложка" },
                    { 30, "fork", "вилка" },
                    { 31, "knife", "нож" },
                    { 32, "plate", "тарелка" },
                    { 33, "television", "телевизор" },
                    { 34, "remote", "пульт" },
                    { 35, "headphones", "наушники" },
                    { 36, "guitar", "гитара" },
                    { 37, "microphone", "микрофон" },
                    { 38, "speaker", "колонка" },
                    { 39, "keyboard", "клавиатура" },
                    { 40, "mouse", "мышь" },
                    { 41, "tablecloth", "скатерть" },
                    { 42, "napkin", "салфетка" },
                    { 43, "plate", "тарелка" },
                    { 44, "cupboard", "шкаф" },
                    { 45, "mirror", "зеркало" },
                    { 46, "towel", "полотенце" },
                    { 47, "brush", "щетка" },
                    { 48, "toothpaste", "зубная паста" },
                    { 49, "shampoo", "шампунь" },
                    { 50, "soap", "мыло" },
                    { 51, "toothbrush", "зубная щетка" },
                    { 52, "razor", "бритва" },
                    { 53, "comb", "расческа" },
                    { 54, "toilet", "туалет" },
                    { 55, "sink", "раковина" },
                    { 56, "bathtub", "ванна" },
                    { 57, "shower", "душ" },
                    { 58, "towel", "полотенце" },
                    { 59, "toilet paper", "туалетная бумага" },
                    { 60, "trash can", "мусорное ведро" },
                    { 61, "fridge", "холодильник" },
                    { 62, "freezer", "морозильник" },
                    { 63, "oven", "духовка" },
                    { 64, "microwave", "микроволновая печь" },
                    { 65, "stove", "плита" },
                    { 66, "kettle", "чайник" },
                    { 67, "coffeemaker", "кофеварка" },
                    { 68, "dishwasher", "посудомоечная машина" },
                    { 69, "washing machine", "стиральная машина" },
                    { 70, "dryer", "сушилка" },
                    { 71, "iron", "утюг" },
                    { 72, "ironing board", "гладильная доска" },
                    { 73, "vacuum cleaner", "пылесос" },
                    { 74, "broom", "метла" },
                    { 75, "mop", "швабра" },
                    { 76, "bucket", "ведро" },
                    { 77, "dustpan", "лопата для мусора" },
                    { 78, "sponge", "губка" },
                    { 79, "dish soap", "моющее средство" },
                    { 80, "dish rack", "сушилка для посуды" },
                    { 81, "bedroom", "спальня" },
                    { 82, "living room", "гостиная" },
                    { 83, "kitchen", "кухня" },
                    { 84, "bathroom", "ванная комната" },
                    { 85, "dining room", "столовая" },
                    { 86, "office", "офис" },
                    { 87, "garage", "гараж" },
                    { 88, "garden", "сад" },
                    { 89, "balcony", "балкон" },
                    { 90, "porch", "крыльцо" },
                    { 91, "yard", "двор" },
                    { 92, "street", "улица" },
                    { 93, "park", "парк" },
                    { 94, "school", "школа" },
                    { 95, "hospital", "больница" },
                    { 96, "supermarket", "супермаркет" },
                    { 97, "bank", "банк" },
                    { 98, "post office", "почта" },
                    { 99, "library", "библиотека" },
                    { 100, "restaurant", "ресторан" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_round_session_id",
                table: "round",
                column: "session_id");

            migrationBuilder.CreateIndex(
                name: "IX_round_word_id",
                table: "round",
                column: "word_id");

            migrationBuilder.CreateIndex(
                name: "IX_session_user_info_id",
                table: "session",
                column: "user_info_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_info_account_id",
                table: "user_info",
                column: "account_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "round");

            migrationBuilder.DropTable(
                name: "session");

            migrationBuilder.DropTable(
                name: "word");

            migrationBuilder.DropTable(
                name: "user_info");

            migrationBuilder.DropTable(
                name: "account");
        }
    }
}
