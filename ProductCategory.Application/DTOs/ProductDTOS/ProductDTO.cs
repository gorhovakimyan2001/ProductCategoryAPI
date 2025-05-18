using ProductCategory.Application.DTOs.CategoryDTOS;

namespace ProductCategory.Application.DTOs.ProductDTOS
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public IEnumerable<CategoryDTO> Categories { get; set; }
    }
}
