using ProductCategory.Application.DTOs;
using ProductCategory.Application.DTOs.CategoryDTOS;
using ProductCategory.Domain.Entities;

namespace ProductCategory.Application.Abstractions.IRepositories
{
    public interface ICategoryRepository
    {
        public Task<(List<Category> categories, int count)> GetAllAsync(PaginationParamsDTO pagination);

        public Task<Category> GetByIdAsync(int id);

        public Task<int> CreateAsync(AddCategoryDTO category);

        public Task<int> UpdateAsync(UpdateCategoryDTO category);

        public Task<int> DeleteAsync(int id);
    }
}
