namespace leyadech.server.DTO
{
    public class Application
    {
        public int ApplicationId { get; set; }
        public int UserId { get; set; }
        public EHelpKind? HelpKind { get; set; }
        public string? Description { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public bool IsRelevant { get; set; }



    }
}
