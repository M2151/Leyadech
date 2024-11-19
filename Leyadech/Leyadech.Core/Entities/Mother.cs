namespace Leyadech.Core.Entities
{
    [Flags]
    public enum EHelpKind { Cleaning = 1, Laundry = 2, Babysitting = 4, Meals = 8, Other = 16 }
    public enum EMoterStatus { WeekAfterBirth,MonthAfterBirth, FewMonthAfterBirth,LongAfterBirth}
    public class Mother:User
    {
        public EMoterStatus? Status { get; set; }
        public DateOnly? BirthDate { get; set; }
        public DateOnly? JoinDate { get; set; }
        public int? FamilySize { get; set; }
        public int? ChildrenBelow7 { get; set; }
        public EHelpKind? HelpKindNeeded { get; set; }
        public List<string>? SpecialRequests { get; set; }
        public bool IsStandingOrder { get; set; }
    }
}
