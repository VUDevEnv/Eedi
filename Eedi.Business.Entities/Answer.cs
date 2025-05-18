namespace Eedi.Business.Entities
{
    public class Answer
    {
        public int TopicId { get; set; }
        public int SubTopicId { get; set; }
        public int QuestionId { get; set; }
        public string? Option { get; set; } = "";
    }
}
