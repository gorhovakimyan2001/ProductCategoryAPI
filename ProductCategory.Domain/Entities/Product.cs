using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductCategory.Domain.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]         
        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public ICollection<CategoryProduct> ProductsCategories { get; set; }
    }
}
