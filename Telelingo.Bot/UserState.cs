using Telelingo.Bot.Interfaces;
using Telelingo.EntityModels;

namespace Telelingo.Bot
{
    public class UserState : IUserState
    {
        public Word word { get; set; }
        public int messageId { get; set; }
        public int maxNewWordInDay { get; set; } = 10;
    }
}
