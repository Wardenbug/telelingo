using Microsoft.EntityFrameworkCore;
using Telelingo.DataContext;
using Telelingo.EntityModels;
using Telelingo.Repositories.Interfaces;

namespace Telelingo.Repositories
{
    public class ChatWordRepository : BaseRepository, IChatWordRepository
    {
        public ChatWordRepository(SqliteContext dbContext) : base(dbContext)
        {
        }

        public async Task CreateAsync(long chatId, long wordId)
        {
            _dbContext.ChatWord.Add(new ChatWord()
            {
                ChatId = chatId,
                WordId = wordId
            });
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ChatWord> GetByIdAsync(long chatId, long wordId)
        {
            return await _dbContext.ChatWord
                .Where((c) => c.ChatId == chatId && c.WordId == wordId)
                .FirstOrDefaultAsync();
        }

        public async Task<Word> GetWordByShowOnDate(long chatId, DateTime showOnDate)
        {
            return await _dbContext.ChatWord
                .Where((c) => c.ShowOn <= showOnDate && c.ChatId == chatId)
                .Join(_dbContext.Word,
                (cw) => cw.WordId,
                (w) => w.WordId,
                (cw, w) => w)
                .FirstOrDefaultAsync();
        }
    }
}
