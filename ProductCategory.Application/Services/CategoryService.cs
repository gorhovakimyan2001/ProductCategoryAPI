using ProductCategory.Application.Abstractions.IRepositories;
using ProductCategory.Application.Abstractions.IServices;
using ProductCategory.Application.DTOs;
using ProductCategory.Application.DTOs.CategoryDTOS;
using ProductCategory.Common.Exceptions;

namespace ProductCategory.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> CreateCategoryAsync(AddCategoryDTO category)
        {
            int resoponse = await _categoryRepository.CreateAsync(category);
            return resoponse > 0;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            int response = await _categoryRepository.DeleteAsync(id);

            if (response == -1)
                throw new NotFoundException($"Category with {id} not found");

            if (response == 0)
                throw new NotSavedException("Deletion process not saved");

            return response > 0;
        }

        public async Task<CategoriesDTO> GetCategoriesAsync(PaginationParamsDTO pagination)
        {
            var response = await _categoryRepository.GetAllAsync(pagination);

            List<CategoryDTO> categories = new List<CategoryDTO>();
            foreach (var category in response.categories)
            {
                categories.Add(new CategoryDTO()
                {
                    Id = category.Id,
                    CategoryDescription = category.CategoryDescription,
                    CategoryName = category.CategoryName,
                });
            }

            return new CategoriesDTO()
            {
                PageCount = response.count,
                Categories = categories,
            };
        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(int id)
        {
            var response = await _categoryRepository.GetByIdAsync(id);

            if (response == null)
                throw new NotFoundException($"Category with {id} not found");

            return new CategoryDTO() 
            { 
                Id = response.Id,
                CategoryDescription = response.CategoryDescription,
                CategoryName = response.CategoryName
            };
        }

        public async Task<bool> UpdateCategoryAsync(UpdateCategoryDTO category)
        {
            int response = await _categoryRepository.UpdateAsync(category);

            if (response == -1)
                throw new NotFoundException($"Category with {category.Id} not found");

            if (response == 0)
                throw new NotSavedException("Update process not saved");

            return response > 0;
        }
    }
}
