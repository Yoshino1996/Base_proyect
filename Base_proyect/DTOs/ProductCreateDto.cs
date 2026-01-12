using System.ComponentModel.DataAnnotations;

namespace Base_proyect.DTOs
{
    public class ProductCreateDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [Range(1, 10000)]
        public decimal Price { get; set; }
    }
}
