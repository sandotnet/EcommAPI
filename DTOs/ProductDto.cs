using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcommAPI.DTOs
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public double? Price { get; set; } 
    }
}
