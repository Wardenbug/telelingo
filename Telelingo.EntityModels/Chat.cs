using System.ComponentModel.DataAnnotations;

namespace Telelingo.EntityModels
{
    public class Chat
    {
        [Key]
        public long ChatId { get; set; }

        public List<Word> Words { get; } = [];
    }
}
