using Microsoft.EntityFrameworkCore;
using telelingo;
using Telelingo.EntityModels;

namespace Telelingo.DataContext
{
    internal static class Seed
    {
        public static void SeedWord(ModelBuilder modelBuilder)
        {
            var parser = new JsonParser("words.json");
            var dict = parser.GetWordsDictionary();

            int count = 1;
            foreach (var pair in dict)
            {
                Console.WriteLine($"{pair.Key}");
                modelBuilder.Entity<Word>().HasData(new Word()
                {
                    Key = pair.Key,
                    Value = pair.Value,
                    Priority = 1,
                    WordId = count
                });
                count++;
            }
        }
    }
}
