namespace Eedi.Business.Entities
{
    public class MisconceptionAnswer
    {
        public int UserId { get; set; }
        public int TopicId { get; set; }
        public int SubTopicId { get; set; }
        public int MisconceptionId { get; set; }
        public string? Answer { get; set; }      
        public string? AnswerText { get; set; }
    }
}
