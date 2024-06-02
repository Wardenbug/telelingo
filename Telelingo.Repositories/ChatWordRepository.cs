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
    }
}
