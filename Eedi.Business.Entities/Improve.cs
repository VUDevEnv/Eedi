namespace Eedi.Business.Entities
{
    public class Improve
    {
        public int Id { get; set; }
        public IEnumerable<Topic>? Topics { get; set; }
    }
}