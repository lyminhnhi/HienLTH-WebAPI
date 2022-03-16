using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Data
{
    [Table("CategoryTable")]
    public class CategoryEntity
    {
        [Key]
        public int CategoryCode { get; set; }
        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; }

        public virtual ICollection<ProductEntity> Products { get; set; }
    }
}
