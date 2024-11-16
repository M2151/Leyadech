namespace leyadech.server.DTO
{
    public enum EFrequency { Disposable,Daily,Weekly,Monthly,Other }
    public class Volunteering
    {
        public int VolunteeringId { get; set; }
        public int RequestId { get; set; }
        public int SuggestId { get; set; }
        public string? Description { get; set; }
        public EHelpKind? HelpKind { get; set; }
        public EFrequency? HelpFrequency { get; set; }
        public DateOnly? DateStart { get; set; }
        public DateOnly? DateEnd { get; set; }
        public TimeOnly? TimeStart { get; set; }
        public TimeOnly? TimeEnd { get; set; }
        public Feedback? Feedback { get; set; }

    }
}
