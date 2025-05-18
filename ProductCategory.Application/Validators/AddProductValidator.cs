using FluentValidation;
using ProductCategory.Application.DTOs.ProductDTOS;

namespace ProductCategory.Application.Validators
{
    public class AddProductValidator: AbstractValidator<AddProductDTO>
    {
        public AddProductValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(100).WithMessage("Product name must be at most 100 characters.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");

            RuleFor(x => x.CategoryIds)
                .NotNull().WithMessage("CategoryIds is required.")
                .Must(list => list.Count >= 2 && list.Count <= 3)
                .WithMessage("Product must be assigned to 2 or 3 categories.");
        }
    }
}
