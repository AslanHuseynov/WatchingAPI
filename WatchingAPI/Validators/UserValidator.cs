
using FluentValidation;
using Watching.Application.Dtos.UserDto;

namespace Watching.Application.Validators
{

    public class UserValidator : AbstractValidator<CreateUserDto>
    {
        public UserValidator()
        {
            RuleFor(user => user.FullName)
                .NotEmpty().WithMessage("Full Name is required.")
                .Must(BeValidFullName).WithMessage("Full Name contains invalid characters.");
        }
        private bool BeValidFullName(string fullName)
        {
            // Define the characters that are not allowed in the Full Name
            string invalidCharacters = "!@#$%^&*()=+{}[]/";

            // Check if any of the invalid characters are present in the Full Name
            return !fullName.Any(c => invalidCharacters.Contains(c));
        }
    }

}
