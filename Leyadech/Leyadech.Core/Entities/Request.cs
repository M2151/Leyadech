namespace Leyadech.Core.Entities
{
    public class Request:Application
    {
        //public DateOnly DateStart { get; set; }
        //public DateOnly DateEnd { get; set; }
        //public TimeOnly TimeStart { get; set; }
        //public TimeOnly TimeEnd { get; set; }
        public EFrequency? Frequency { get; set; }
        public int UrgencyLevel { get; set; }
        public List<string>? Preferences { get; set; }


    }
}
