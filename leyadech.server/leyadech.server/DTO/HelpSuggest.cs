namespace leyadech.server.DTO
{
    public class HelpSuggest:Application
    {
        public bool IsFlexible { get; set; }
        public bool IsRelevant { get; set; }
        public EFrequency Frequency { get; set; }
        public List<DayOfWeek> RelevantDays { get; set; }
    }
}
