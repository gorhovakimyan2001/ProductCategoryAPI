using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ProductCategory.Domain.Entities
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; }

        [AllowNull]
        public string CategoryDescription { get; set; } = string.Empty;

        public ICollection<CategoryProduct> ProductsCategories { get; set; }
    }
}
