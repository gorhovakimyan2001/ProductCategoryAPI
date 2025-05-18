using ProductCategory.Application.DTOs;
using ProductCategory.Application.DTOs.CategoryDTOS;

namespace ProductCategory.Application.Abstractions.IServices
{
    public interface ICategoryService
    {
        public Task<CategoriesDTO> GetCategoriesAsync(PaginationParamsDTO pagination);

        public Task<CategoryDTO> GetCategoryByIdAsync(int id);

        public Task<bool> CreateCategoryAsync(AddCategoryDTO category);

        public Task<bool> UpdateCategoryAsync(UpdateCategoryDTO category);

        public Task<bool> DeleteCategoryAsync(int id);
    }
}
