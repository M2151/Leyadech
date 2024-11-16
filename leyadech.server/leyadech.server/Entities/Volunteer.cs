namespace leyadech.server.DTO
{
    public enum EVolunteerStatus { Permanent,Disposable,NotActive}
    public class Volunteer:User
    {
        public EVolunteerStatus? Status { get; set; }
        public DateOnly? JoinDate { get; set; }
        public EHelpKind? HelpKindSuggested { get; set; }
    }
}
