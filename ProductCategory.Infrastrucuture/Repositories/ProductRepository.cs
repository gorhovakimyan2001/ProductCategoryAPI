using Microsoft.EntityFrameworkCore;
using ProductCategory.Application.Abstractions.IRepositories;
using ProductCategory.Application.DTOs;
using ProductCategory.Application.DTOs.ProductDTOS;
using ProductCategory.Domain.Entities;

namespace ProductCategory.Infrastrucuture.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly ApplicationContext _context;

        public ProductRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<(List<Product> products, int count)> GetAllAsync(PaginationParamsDTO pagination)
        {
            var query = _context.Products
                .Include(p => p.ProductsCategories)
                    .ThenInclude(pc => pc.Category)
                .AsNoTracking();

            int count = await query.CountAsync();

            var products = await query
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            return (products, count);
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.ProductsCategories)
                    .ThenInclude(pc => pc.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<int> CreateAsync(AddProductDTO dto)
        {
            var product = new Product
            {
                ProductName = dto.ProductName,
                Price = dto.Price,
                ProductsCategories = dto.CategoryIds.Select(cid => new CategoryProduct
                {
                    CategoryId = cid
                }).ToList()
            };

            _context.Products.Add(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(UpdateProductDTO updatedProduct)
        {
            var existing = await _context.Products
                .Include(p => p.ProductsCategories)
                .FirstOrDefaultAsync(p => p.Id == updatedProduct.Id);

            if (existing == null)
                return -1;

            existing.ProductName = updatedProduct.ProductName;
            existing.Price = updatedProduct.Price;

            _context.ProductCategories.RemoveRange(existing.ProductsCategories);
            existing.ProductsCategories = updatedProduct.CategoryIds.Select(cid => new CategoryProduct
            {
                ProductId = updatedProduct.Id,
                CategoryId = cid
            }).ToList();

            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
                return 0;

            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }
    }
}
