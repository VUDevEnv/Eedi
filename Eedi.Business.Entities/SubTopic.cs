namespace Eedi.Business.Entities
{
    public class SubTopic
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public IEnumerable<Misconception>? Misconceptions { get; set; }
    }
}