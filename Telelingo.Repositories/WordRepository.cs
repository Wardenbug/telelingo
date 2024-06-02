using Microsoft.EntityFrameworkCore;
using Telelingo.DataContext;
using Telelingo.EntityModels;
using Telelingo.Repositories.Interfaces;

namespace Telelingo.Repositories
{
    public class WordRepository : BaseRepository, IWordRepository
    {
        public WordRepository(SqliteContext dbContext) : base(dbContext)
        {
        }

        public async Task<Word> GetByLowestPriorityAsync(long chatId)
        {
            var lowestPriorityWord = await _dbContext.Word
                   .Where(w => !_dbContext.ChatWord
                        .Any(c => c.ChatId == chatId && c.WordId == w.WordId))
                   .OrderBy(w => w.Priority)
                   .FirstOrDefaultAsync();

            if (lowestPriorityWord is null)
            {
                throw new Exception("There is no words for this user");
            }

            return lowestPriorityWord;
        }
    }
}
