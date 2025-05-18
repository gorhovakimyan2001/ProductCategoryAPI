using ProductCategory.Application.DTOs;
using ProductCategory.Application.DTOs.ProductDTOS;
using ProductCategory.Domain.Entities;

namespace ProductCategory.Application.Abstractions.IRepositories
{
    public interface IProductRepository
    {
        public Task<(List<Product> products, int count)> GetAllAsync(PaginationParamsDTO pagination);

        public Task<Product> GetByIdAsync(int id);

        public Task<int> CreateAsync(AddProductDTO product);

        public Task<int> UpdateAsync(UpdateProductDTO product);

        public Task<int> DeleteAsync(int id);
    }
}
