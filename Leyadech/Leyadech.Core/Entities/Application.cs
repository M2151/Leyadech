using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Leyadech.Core.Entities
{
    [Table("Aplication")]
    public class Application
    {
        [Key]
        public int ApplicationId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public EHelpKind? HelpKind { get; set; }
        public string? Description { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public bool IsRelevant { get; set; }



    }
}
