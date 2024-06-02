using Microsoft.EntityFrameworkCore;
using Telelingo.DataContext;
using Telelingo.EntityModels;
using Telelingo.Repositories.Interfaces;

namespace Telelingo.Repositories
{
    public class ChatRepository : BaseRepository, IChatRepository
    {

        public ChatRepository(SqliteContext dbContext) : base(dbContext)
        {
        }

        public async Task CreateIfNoExitsAsync(long chatId)
        {
            var chat = await _dbContext.Chat.FirstOrDefaultAsync((el) => el.ChatId == chatId);

            if (chat is null)
            {
                await _dbContext.Chat.AddAsync(new Chat()
                {
                    ChatId = chatId,
                });

                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
