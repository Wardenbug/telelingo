using System.ComponentModel.DataAnnotations;

namespace Telelingo.EntityModels
{
    public class Word
    {
        [Key]
        public long WordId { get; set; }

        public List<Chat> Chats { get; }
    }
}
