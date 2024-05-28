namespace Telelingo.EntityModels
{
    public class ChatWord
    {
        public long ChatId { get; set; }
        public long WordId { get; set; }
        public DateTime ShowOn { get; set; } = DateTime.Now;
    }
}
