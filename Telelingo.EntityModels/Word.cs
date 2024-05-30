using System.ComponentModel.DataAnnotations;

namespace Telelingo.EntityModels
{
    public class Word
    {
        [Key]
        public long WordId { get; set; }
        public int Priority { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public List<Chat> Chats { get; }
    }
}
