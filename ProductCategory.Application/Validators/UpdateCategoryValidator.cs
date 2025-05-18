using FluentValidation;
using ProductCategory.Application.DTOs.CategoryDTOS;

namespace ProductCategory.Application.Validators
{
    public class UpdateCategoryValidator: AbstractValidator<UpdateCategoryDTO>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("Category name is required.")
                .MaximumLength(100).WithMessage("Category name must be at most 100 characters.");
        }
    }
}
