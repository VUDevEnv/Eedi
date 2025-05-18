namespace Eedi.Business.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public int SubTopicId { get; set; }
        public string? QuestionImageUrl { get; set; } = "";
        public IEnumerable<string>? AnswerOptions { get; set; }
    }
}
