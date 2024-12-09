using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leyadech.Core.Entities
{

    public enum EFrequency { Disposable,Daily,Weekly,Monthly,Other }
    [Table("Volunteering")]
    public class Volunteering
    {
        [Key]
        public int VolunteeringId { get; set; }
        [ForeignKey("Request")]
        public int RequestId { get; set; }
        [ForeignKey("Suggest")]
        public int SuggestId { get; set; }
        public string? Description { get; set; }
        public EHelpKind? HelpKind { get; set; }
        public EFrequency? HelpFrequency { get; set; }
        public DateOnly? DateStart { get; set; }
        public DateOnly? DateEnd { get; set; }
        public TimeOnly? TimeStart { get; set; }
        public TimeOnly? TimeEnd { get; set; }
        public string? Feedback { get; set; }

    }
}
