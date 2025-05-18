using System.ComponentModel.DataAnnotations;

namespace ProductCategory.Application.DTOs.ProductDTOS
{
    public class AddProductDTO
    {
        [Required]
        public string ProductName { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public List<int> CategoryIds { get; set; }

        public AddProductDTO()
        {
            ProductName = string.Empty;
            CategoryIds = new List<int>();
        }
    }
}
