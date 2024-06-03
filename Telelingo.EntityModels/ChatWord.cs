namespace Telelingo.EntityModels
{
    public class ChatWord
    {
        public long ChatId { get; set; }
        public long WordId { get; set; }

        public int LearningRate { get; set; } = 0;
        public DateTime ShowOn { get; set; } = DateTime.UtcNow;
    }
}
