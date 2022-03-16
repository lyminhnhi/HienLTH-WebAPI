using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebAPI.Data
{
    [Table("ProductTable")]
    public class ProductEntity
    {
        [Key]
        public Guid Code { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        public string Description { get; set; }
        public byte Promotion { get; set; }
        public int? CategoryCode { get; set; }
        [ForeignKey("CategoryCode")]
        public CategoryEntity Category { get; set; }
    }
}
