using Telelingo.EntityModels;

namespace Telelingo.Repositories.Interfaces
{
    internal interface IChatWordRepository
    {
        Task CreateAsync(long chatId, long wordId);
        Task<ChatWord> GetByIdAsync(long chatId, long wordId);

        Task<Word> GetWordByShowOnDate(long chatId, DateTime showOnDate);
    }
}
