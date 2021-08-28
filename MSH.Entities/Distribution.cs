using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSH.Entities
{
    public class Distribution : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DistributionID { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Company Name should not be more than 30 characters")]
        [StringLength(30)]
        public string Name { get; set; }
        public int? ParentID { get; set; }
    }
}
