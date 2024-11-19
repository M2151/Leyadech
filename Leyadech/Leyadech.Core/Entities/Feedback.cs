namespace Leyadech.Core.Entities
{
    public class Feedback
    {
        public int Id { get; set; }
        public int VolunteeringId { get; set; }
        public int SatisfactionLevel { get; set; }
        public string? Content { get; set; }
    }
}
