namespace Eedi.Business.Entities
{
    public class Improve
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<Topic>? Topics { get; set; }
    }
}