using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSH.Entities.Common
{
    public class Category : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        public int? ParentCategoryID { get; set; }
    }
}