using Microsoft.EntityFrameworkCore;
using Telelingo.DataContext;
using Telelingo.Repositories.Interfaces;

namespace Telelingo.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly SqliteContext _dbContext;

        public ChatRepository(SqliteContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateIfNoExits(long chatId)
        {
            var chat = await _dbContext.Chat.FirstOrDefaultAsync((el) => el.ChatId == chatId);

            if (chat is null)
            {
                await _dbContext.Chat.AddAsync(new Telelingo.EntityModels.Chat()
                {
                    ChatId = chatId,
                });

                await _dbContext.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine($"chat id {chat.ChatId}");
            }
        }
    }
}
