using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Telelingo.EntityModels;

namespace Telelingo.DataContext
{
    public class DataContext : DbContext
    {

        public static readonly ILoggerFactory MyLoggerFactory
        = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public DbSet<Chat> Chat { get; set; }
        public DbSet<Word> Word { get; set; }
        public DbSet<ChatWord> ChatWord { get; set; }

        public string DbPath { get; }

        public DataContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "test.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chat>()
                .HasMany(chat => chat.Words)
                .WithMany(word => word.Chats)
                .UsingEntity<ChatWord>();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(MyLoggerFactory)
                .UseSqlite($"Data Source={DbPath}");
        }
    }
}
