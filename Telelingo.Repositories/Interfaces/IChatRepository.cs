namespace Telelingo.Repositories.Interfaces
{
    internal interface IChatRepository
    {
        Task CreateIfNoExitsAsync(long chatId);
    }
}
