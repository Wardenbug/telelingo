namespace Telelingo.Repositories.Interfaces
{
    internal interface IChatWordRepository
    {
        Task CreateAsync(long chatId, long wordId);
    }
}
