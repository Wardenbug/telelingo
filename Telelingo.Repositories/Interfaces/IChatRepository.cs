namespace Telelingo.Repositories.Interfaces
{
    internal interface IChatRepository
    {
        void CreateIfNoExits(long chatId);
    }
}
