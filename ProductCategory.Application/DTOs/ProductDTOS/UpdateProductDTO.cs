using System.ComponentModel.DataAnnotations;

namespace ProductCategory.Application.DTOs.ProductDTOS
{
    public class UpdateProductDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public List<int> CategoryIds { get; set; }

        public UpdateProductDTO()
        {
            ProductName = string.Empty;
            CategoryIds = new List<int>();
        }
    }
}
