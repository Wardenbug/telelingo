using Telelingo.EntityModels;

namespace Telelingo.Bot.Interfaces
{
    public interface IUserState
    {
        Word word { get; set; }
        int messageId { get; set; }
    }
}
