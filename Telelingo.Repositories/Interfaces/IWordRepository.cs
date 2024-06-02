using Telelingo.EntityModels;

namespace Telelingo.Repositories.Interfaces
{
    internal interface IWordRepository
    {
        Task<Word> GetByLowestPriorityAsync(long chatId);
    }
}
