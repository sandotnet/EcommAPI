using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcommAPI.DTOs
{
    public class OrderDto
    {
        public Guid OrderId { get; set; }
        public int ProductId { get; set; }
        public string? UserId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
