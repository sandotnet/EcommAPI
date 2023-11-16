using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EcommAPI.Entities
{
    [Table("Products")]
    public class Product
    {
        [Key] //applied primary key with identity(1,1)
       // [DatabaseGenerated(DatabaseGeneratedOption.None)] //identity is disabled
        public int ProductId { get; set; }
        [Column("ProductName",TypeName ="varchar")]
        [StringLength(50)]
        [Required]
        public string? Name { get; set; }
        public double? Price { get; set; } //null constraint is applied
    }
}
