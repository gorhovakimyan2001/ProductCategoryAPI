namespace ProductCategory.Application.DTOs.ProductDTOS
{
    public class ProductsDTO
    {
        public int PageCount { get; set; }

        public IEnumerable<ProductDTO> Products { get; set; }
    }
}
