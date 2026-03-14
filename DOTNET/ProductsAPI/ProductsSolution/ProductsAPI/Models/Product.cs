using System.ComponentModel.DataAnnotations;

namespace ProductsAPI.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
