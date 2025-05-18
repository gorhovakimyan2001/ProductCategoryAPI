using ProductCategory.Application.Abstractions.IRepositories;
using ProductCategory.Application.Abstractions.IServices;
using ProductCategory.Application.DTOs;
using ProductCategory.Application.DTOs.CategoryDTOS;
using ProductCategory.Application.DTOs.ProductDTOS;
using ProductCategory.Common.Exceptions;

namespace ProductCategory.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository productRepository)
        {
            _repository = productRepository;
        }

        public async Task<bool> CreateProductAsync(AddProductDTO category)
        {
            int response = await _repository.CreateAsync(category);
            return response > 0;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            int response = await _repository.DeleteAsync(id);

            if (response == -1)
                throw new NotFoundException($"Product with {id} not found");

            if (response == 0)
                throw new NotSavedException($"Deletion process not saved");

            return response > 0;
        }

        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            var response = await _repository.GetByIdAsync(id);

            if (response == null)
                throw new NotFoundException($"Product with {id} not found");

            return new ProductDTO
            {
                Id = response.Id,
                ProductName = response.ProductName,
                Price = response.Price,
                Categories = response.ProductsCategories
                    .Select(pc => new CategoryDTO
                    {
                        Id = pc.Category.Id,
                        CategoryName = pc.Category.CategoryName,
                        CategoryDescription = pc.Category.CategoryDescription,
                    })
            };
        }

        public async Task<ProductsDTO> GetProductsAsync(PaginationParamsDTO pagination)
        {
            var response = await _repository.GetAllAsync(pagination);

            ProductsDTO dto = new ProductsDTO
            {
                PageCount = response.count,
                Products = response.products.Select(p => new ProductDTO
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    Categories = p.ProductsCategories
                        .Where(pc => pc.Category != null)
                        .Select(pc => new CategoryDTO
                        {
                            Id = pc.Category.Id,
                            CategoryName = pc.Category.CategoryName,
                            CategoryDescription = pc.Category.CategoryDescription,                            
                        }).ToList()
                })
            };

            return dto;
        }

        public async Task<bool> UpdateProductAsync(UpdateProductDTO product)
        {
            int response = await _repository.UpdateAsync(product);

            if (response == -1)
                throw new NotFoundException($"Product with {product.Id} not found");

            if (response == 0)
                throw new NotSavedException($"Update process not saved");

            return response > 0;
        }
    }
}
