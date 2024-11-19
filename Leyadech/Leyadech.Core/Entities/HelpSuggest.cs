namespace Leyadech.Core.Entities
{
    public class HelpSuggest:Application
    {
        public bool IsFlexible { get; set; }
        
        public EFrequency? Frequency { get; set; }
        public List<DayOfWeek>? RelevantDays { get; set; }
    }
}
