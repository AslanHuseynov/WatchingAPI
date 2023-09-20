using Company.Persistence.DB;
using FluentValidation;
using System.Text.RegularExpressions;
using System.Linq;
using Watching.Application.Dtos.CategoryDto;

namespace Watching.Persistence.Validators.CategoryValidators
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
    {
        private readonly DataContext _dbContext;

        public UpdateCategoryValidator(DataContext dbContext)
        {
            _dbContext = dbContext;

            When(category => category.Id != 0, () =>
            {
                RuleFor(category => category.Name)
                .NotEmpty()
                .MaximumLength(100)
                .Must(BeUniqueCategoryName)
                .WithMessage("Category with this name already exists.");

                RuleFor(category => category.Name)
                .Must(ContainValidCharacters)
                .WithMessage("Category name cannot contain special symbols.");
            });

        }

        private bool BeUniqueCategoryName(string name)
        {
            return !_dbContext.Categories.Any(u => u.Name == name);
        }

        private bool ContainValidCharacters(string name)
        {
            string pattern = @"^[a-zA-Z0-9\s]+$";
            return Regex.IsMatch(name, pattern);
        }
    }
}
