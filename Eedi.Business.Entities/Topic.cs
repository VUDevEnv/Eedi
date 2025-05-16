namespace Eedi.Business.Entities
{
    public class Topic
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public IEnumerable<SubTopic>? SubTopics { get; set; }
    }
}
