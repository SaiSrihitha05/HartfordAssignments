using System.ComponentModel.DataAnnotations;

namespace ProductsAPI.DTOs
{
    public class UpdateProductDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Range(1, 100000)]
        public decimal Price { get; set; }
    }
}
