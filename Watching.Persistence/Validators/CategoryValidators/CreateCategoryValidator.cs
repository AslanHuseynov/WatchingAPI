using Company.Persistence.DB;
using FluentValidation;
using Watching.Application.Dtos.CategoryDto;

namespace Watching.Persistence.Validators.CategoryValidators
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
    {
        private readonly DataContext _dbContext;

        public CreateCategoryValidator(DataContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(category => category.Name)
                .NotEmpty()
                .MaximumLength(100)
                .Must(BeUniqueCategoryName)
                .WithMessage("Category with this name already exists.");

            RuleFor(category => category.Name)
                .NotEmpty().WithMessage("Category name is required.")
                .Must(BeValidCategoryName).WithMessage("Category name contains invalid characters.");
        }

        private bool BeUniqueCategoryName(string name)
        {
            // Check if a user with the same FullName already exists in the database
            return !_dbContext.Categories.Any(u => u.Name == name);
        }
        private bool BeValidCategoryName(string name)
        {
            string invalidCharacters = "!@#$%^&*()=+{}[]/";

            return !name.Any(c => invalidCharacters.Contains(c));
        }
    }
}
