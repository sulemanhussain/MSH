using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSH.Entities
{
    public class ApplicationType : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApplicationTypeID { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name = "Application Name")]
        public string AppName { get; set; }
        [Display(Name = "Application Code")]
        public string AppCode { get; set; }
        [Display(Name = "Distribution")]
        public int DistributionID { get; set; }

        [ForeignKey("DistributionID")]
        public virtual Distribution Distribution { get; set; }
    }
}
