using Microsoft.EntityFrameworkCore;
using Telelingo.EntityModels;

namespace Telelingo.DataContext
{
    public class DataContext : DbContext
    {
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
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }
    }
}
