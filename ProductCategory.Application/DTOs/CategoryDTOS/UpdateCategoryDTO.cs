using System.ComponentModel.DataAnnotations;

namespace ProductCategory.Application.DTOs.CategoryDTOS
{
    public class UpdateCategoryDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }
    }
}
