using ProductCategory.Application.DTOs;
using ProductCategory.Application.DTOs.ProductDTOS;

namespace ProductCategory.Application.Abstractions.IServices
{
    public interface IProductService
    {
        public Task<ProductsDTO> GetProductsAsync(PaginationParamsDTO pagination);

        public Task<ProductDTO> GetProductByIdAsync(int id);

        public Task<bool> CreateProductAsync(AddProductDTO category);

        public Task<bool> UpdateProductAsync(UpdateProductDTO category);

        public Task<bool> DeleteProductAsync(int id);
    }
}
