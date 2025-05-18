using Microsoft.EntityFrameworkCore;
using ProductCategory.Application.Abstractions.IRepositories;
using ProductCategory.Application.DTOs;
using ProductCategory.Application.DTOs.CategoryDTOS;
using ProductCategory.Domain.Entities;

namespace ProductCategory.Infrastrucuture.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationContext _context;

        public CategoryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(AddCategoryDTO categoryDTO)
        {
            var category = new Category
            {
                CategoryName = categoryDTO.CategoryName,
                CategoryDescription = categoryDTO.CategoryDescription,
            };

            _context.Categories.Add(category);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return -1;
            }

            bool hasProducts = await _context.ProductCategories.AnyAsync(cp => cp.CategoryId == id);

            if (hasProducts)
            {
                return -2;
            }

            _context.Categories.Remove(category);
            return await _context.SaveChangesAsync();
        }

        public async Task<(List<Category> categories, int count)> GetAllAsync(PaginationParamsDTO pagination)
        {
            var query = _context.Categories
            .Include(p => p.ProductsCategories)
            .ThenInclude(pc => pc.Product)
            .AsQueryable();

            int totalCount = await query.CountAsync();

            var categories = await query
                .OrderBy(c => c.CategoryName)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            return (categories, totalCount);
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            return category;
        }

        public async Task<int> UpdateAsync(UpdateCategoryDTO category)
        {
            var existingCategory = await _context.Categories.FindAsync(category.Id);

            if (existingCategory == null)
            {
                return -1;
            }

            existingCategory.CategoryName = category.CategoryName;
            existingCategory.CategoryDescription = category.CategoryDescription;
            return await _context.SaveChangesAsync();
        }
    }
}
