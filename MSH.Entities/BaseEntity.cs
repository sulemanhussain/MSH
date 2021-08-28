using System;
using System.ComponentModel.DataAnnotations;

namespace MSH.Entities
{
    public class BaseEntity
    {
        [StringLength(50)]
        public string GUID { get; set; }
        public int? InsertBy { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
