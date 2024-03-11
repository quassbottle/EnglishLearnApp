using System.Data;
using System.Data.Common;
using EnglishApplication.Domain.Aggregate;
using EnglishApplication.Infrastructure.Persistence.Configuration;
using EnglishApplication.Infrastructure.Persistence.Factories;
using EnglishApplication.Infrastructure.Persistence.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EnglishApplication.Infrastructure.Persistence.Context;

public class DefaultDataContext(IDbConnectionFactory factory) : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(factory.CreateAsync().GetAwaiter().GetResult());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
        //modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new LearnedWordConfiguration());
        modelBuilder.ApplyConfiguration(new UserInfoConfiguration());
        modelBuilder.ApplyConfiguration(new WordConfiguration());
        
        modelBuilder.Entity<Word>().HasData(new List<Word>()
            {
            new() { Id = 1, Value = "word", Translation = "слово" },
            new() { Id = 2, Value = "house", Translation = "дом" },
            new() { Id = 3, Value = "cat", Translation = "кот" },
            new() { Id = 4, Value = "dog", Translation = "собака" },
            new() { Id = 5, Value = "tree", Translation = "дерево" },
            new() { Id = 6, Value = "book", Translation = "книга" },
            new() { Id = 7, Value = "computer", Translation = "компьютер" },
            new() { Id = 8, Value = "sky", Translation = "небо" },
            new() { Id = 9, Value = "sun", Translation = "солнце" },
            new() { Id = 10, Value = "moon", Translation = "луна" },
            // Продолжение списка слов
            new() { Id = 11, Value = "apple", Translation = "яблоко" },
            new() { Id = 12, Value = "banana", Translation = "банан" },
            new() { Id = 13, Value = "car", Translation = "машина" },
            new() { Id = 14, Value = "table", Translation = "стол" },
            new() { Id = 15, Value = "chair", Translation = "стул" },
            new() { Id = 16, Value = "pen", Translation = "ручка" },
            new() { Id = 17, Value = "pencil", Translation = "карандаш" },
            new() { Id = 18, Value = "window", Translation = "окно" },
            new() { Id = 19, Value = "door", Translation = "дверь" },
            new() { Id = 20, Value = "phone", Translation = "телефон" },
            // Продолжение списка слов
            new() { Id = 21, Value = "tablet", Translation = "планшет" },
            new() { Id = 22, Value = "chair", Translation = "стул" },
            new() { Id = 23, Value = "lamp", Translation = "лампа" },
            new() { Id = 24, Value = "clock", Translation = "часы" },
            new() { Id = 25, Value = "bookshelf", Translation = "книжная полка" },
            new() { Id = 26, Value = "bed", Translation = "кровать" },
            new() { Id = 27, Value = "window", Translation = "окно" },
            new() { Id = 28, Value = "cup", Translation = "чашка" },
            new() { Id = 29, Value = "spoon", Translation = "ложка" },
            new() { Id = 30, Value = "fork", Translation = "вилка" },
            // Продолжение списка слов
            new() { Id = 31, Value = "knife", Translation = "нож" },
            new() { Id = 32, Value = "plate", Translation = "тарелка" },
            new() { Id = 33, Value = "television", Translation = "телевизор" },
            new() { Id = 34, Value = "remote", Translation = "пульт" },
            new() { Id = 35, Value = "headphones", Translation = "наушники" },
            new() { Id = 36, Value = "guitar", Translation = "гитара" },
            new() { Id = 37, Value = "microphone", Translation = "микрофон" },
            new() { Id = 38, Value = "speaker", Translation = "колонка" },
            new() { Id = 39, Value = "keyboard", Translation = "клавиатура" },
            new() { Id = 40, Value = "mouse", Translation = "мышь" },
            // Продолжение списка слов
            new() { Id = 41, Value = "tablecloth", Translation = "скатерть" },
            new() { Id = 42, Value = "napkin", Translation = "салфетка" },
            new() { Id = 43, Value = "plate", Translation = "тарелка" },
            new() { Id = 44, Value = "cupboard", Translation = "шкаф" },
            new() { Id = 45, Value = "mirror", Translation = "зеркало" },
            new() { Id = 46, Value = "towel", Translation = "полотенце" },
            new() { Id = 47, Value = "brush", Translation = "щетка" },
            new() { Id = 48, Value = "toothpaste", Translation = "зубная паста" },
            new() { Id = 49, Value = "shampoo", Translation = "шампунь" },
            new() { Id = 50, Value = "soap", Translation = "мыло" },
            new() { Id = 51, Value = "toothbrush", Translation = "зубная щетка" },
            new() { Id = 52, Value = "razor", Translation = "бритва" },
            new() { Id = 53, Value = "comb", Translation = "расческа" },
            new() { Id = 54, Value = "toilet", Translation = "туалет" },
            new() { Id = 55, Value = "sink", Translation = "раковина" },
            new() { Id = 56, Value = "bathtub", Translation = "ванна" },
            new() { Id = 57, Value = "shower", Translation = "душ" },
            new() { Id = 58, Value = "towel", Translation = "полотенце" },
            new() { Id = 59, Value = "toilet paper", Translation = "туалетная бумага" },
            new() { Id = 60, Value = "trash can", Translation = "мусорное ведро" },
            new() { Id = 61, Value = "fridge", Translation = "холодильник" },
            new() { Id = 62, Value = "freezer", Translation = "морозильник" },
            new() { Id = 63, Value = "oven", Translation = "духовка" },
            new() { Id = 64, Value = "microwave", Translation = "микроволновая печь" },
            new() { Id = 65, Value = "stove", Translation = "плита" },
            new() { Id = 66, Value = "kettle", Translation = "чайник" },
            new() { Id = 67, Value = "coffeemaker", Translation = "кофеварка" },
            new() { Id = 68, Value = "dishwasher", Translation = "посудомоечная машина" },
            new() { Id = 69, Value = "washing machine", Translation = "стиральная машина" },
            new() { Id = 70, Value = "dryer", Translation = "сушилка" },
            new() { Id = 71, Value = "iron", Translation = "утюг" },
            new() { Id = 72, Value = "ironing board", Translation = "гладильная доска" },
            new() { Id = 73, Value = "vacuum cleaner", Translation = "пылесос" },
            new() { Id = 74, Value = "broom", Translation = "метла" },
            new() { Id = 75, Value = "mop", Translation = "швабра" },
            new() { Id = 76, Value = "bucket", Translation = "ведро" },
            new() { Id = 77, Value = "dustpan", Translation = "лопата для мусора" },
            new() { Id = 78, Value = "sponge", Translation = "губка" },
            new() { Id = 79, Value = "dish soap", Translation = "моющее средство" },
            new() { Id = 80, Value = "dish rack", Translation = "сушилка для посуды" },
            new() { Id = 81, Value = "bedroom", Translation = "спальня" },
            new() { Id = 82, Value = "living room", Translation = "гостиная" },
            new() { Id = 83, Value = "kitchen", Translation = "кухня" },
            new() { Id = 84, Value = "bathroom", Translation = "ванная комната" },
            new() { Id = 85, Value = "dining room", Translation = "столовая" },
            new() { Id = 86, Value = "office", Translation = "офис" },
            new() { Id = 87, Value = "garage", Translation = "гараж" },
            new() { Id = 88, Value = "garden", Translation = "сад" },
            new() { Id = 89, Value = "balcony", Translation = "балкон" },
            new() { Id = 90, Value = "porch", Translation = "крыльцо" },
            new() { Id = 91, Value = "yard", Translation = "двор" },
            new() { Id = 92, Value = "street", Translation = "улица" },
            new() { Id = 93, Value = "park", Translation = "парк" },
            new() { Id = 94, Value = "school", Translation = "школа" },
            new() { Id = 95, Value = "hospital", Translation = "больница" },
            new() { Id = 96, Value = "supermarket", Translation = "супермаркет" },
            new() { Id = 97, Value = "bank", Translation = "банк" },
            new() { Id = 98, Value = "post office", Translation = "почта" },
            new() { Id = 99, Value = "library", Translation = "библиотека" },
            new() { Id = 100, Value = "restaurant", Translation = "ресторан" }
        });
    }
    
    public DbSet<Account> Accounts { get; set; }
    //public DbSet<Category> Categories { get; set; }
    public DbSet<LearnedWord> LearnedWords { get; set; }
    public DbSet<UserInfo> UserInfos { get; set; }
    public DbSet<Word> Words { get; set; }
}