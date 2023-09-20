using Company.Persistence.DB;
using FluentValidation;
using System.Text.RegularExpressions;
using Watching.Application.Dtos.UserDto;

namespace Watching.Persistence.Validators.UserValidators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        private readonly DataContext _dbContext;

        public UpdateUserValidator(DataContext dbContext)
        {
            _dbContext = dbContext;

            When(user => user.Id != 0, () =>
            {
                RuleFor(user => user.FullName)
                .NotEmpty()
                .MaximumLength(100)
                .Must(BeUniqueUserFullName)
                .WithMessage("User with this name already exists.");

                RuleFor(user => user.FullName)
                .Must(ContainValidCharacters)
                .WithMessage("User name cannot contain special symbols.");
            });
        }

        private bool BeUniqueUserFullName(string name)
        {
            return !_dbContext.Users.Any(u => u.FullName == name);
        }

        private bool ContainValidCharacters(string name)
        {
            string pattern = @"^[a-zA-Z0-9\s]+$";
            return Regex.IsMatch(name, pattern);
        }
    }
}
