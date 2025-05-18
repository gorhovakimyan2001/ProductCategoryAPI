namespace ProductCategory.Application.DTOs.CategoryDTOS
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; } = string.Empty;
    }
}
