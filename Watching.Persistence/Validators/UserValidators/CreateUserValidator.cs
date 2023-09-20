using Company.Persistence.DB;
using FluentValidation;
using Watching.Application.Dtos.UserDto;

namespace Watching.Persistence.Validators.UserValidators
{

    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly DataContext _dbContext;

        public CreateUserValidator(DataContext dataContext)
        {
            _dbContext = dataContext;

            RuleFor(user => user.FullName)
                .NotEmpty()
                .MaximumLength(100)
                .Must(BeUniqueFullName)
                .WithMessage("User with this FullName already exists.");

            RuleFor(user => user.FullName)
                .NotEmpty().WithMessage("Full Name is required.")
                .Must(BeValidFullName).WithMessage("Full Name contains invalid characters.");
        }

        private bool BeUniqueFullName(string fullName)
        {
            // Check if a user with the same FullName already exists in the database
            return !_dbContext.Users.Any(u => u.FullName == fullName);
        }
        private bool BeValidFullName(string fullName)
        {
            string invalidCharacters = "!@#$%^&*()=+{}[]/";

            return !fullName.Any(c => invalidCharacters.Contains(c));
        }
    }

}
