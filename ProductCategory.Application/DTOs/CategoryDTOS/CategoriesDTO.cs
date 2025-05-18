namespace ProductCategory.Application.DTOs.CategoryDTOS
{
    public class CategoriesDTO
    {
        public int PageCount { get; set; }

        public List<CategoryDTO> Categories { get; set; }
    }
}
