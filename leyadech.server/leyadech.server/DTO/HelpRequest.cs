namespace leyadech.server.DTO
{
    public class HelpRequest
    {
        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }
        public TimeOnly TimeStart { get; set; }
        public TimeOnly TimeEnd { get; set; }
        public EFrequency Frequency { get; set; }

    }
}
