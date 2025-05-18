using FluentValidation;
using ProductCategory.Application.DTOs.ProductDTOS;

namespace ProductCategory.Application.Validators
{
    public class UpdateProductValidator: AbstractValidator<UpdateProductDTO>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(100).WithMessage("Product name must be at most 100 characters.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");

            RuleFor(x => x.CategoryIds)
                .Must(list => list.Count >= 2 && list.Count <= 3)
                .WithMessage("Product must have 2 to 3 categories.");
        }
       
    }
}
