using System.Diagnostics.CodeAnalysis;

namespace ProductCategory.Application.DTOs.CategoryDTOS
{
    public class AddCategoryDTO
    {
        public string CategoryName { get; set; }

        [AllowNull]
        public string CategoryDescription { get; set; } = string.Empty;
    }
}
