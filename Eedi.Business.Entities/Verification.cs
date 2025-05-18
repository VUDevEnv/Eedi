namespace Eedi.Business.Entities
{
    public class Verification
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public int SubTopicId { get; set; }
        public int QuestionId { get; set; }
        public string? AnswerOption { get; set; }
        public string? Explanation { get; set; }
        public bool? Correct { get; set; }
    }
}
