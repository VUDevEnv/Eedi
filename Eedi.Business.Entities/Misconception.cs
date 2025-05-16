namespace Eedi.Business.Entities
{
    public class Misconception
    {        
        public int Id { get; set; }
        public string? QuestionImage { get; set; }
        public IEnumerable<string>? AnswerOptions { get; set; }
        public bool CorrectAnswer  { get; set; }
    }
}
