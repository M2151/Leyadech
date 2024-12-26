namespace Leyadech.Core.Entities
{
    public class Suggest:Application
    {
        public bool IsFlexible { get; set; }
        
        public EFrequency? Frequency { get; set; }
        public List<DayOfWeek>? RelevantDays { get; set; }


    }
}
