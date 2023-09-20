using FluentValidation;
using Watching.Application.Dtos.UserDto;
using Watching.Application.Interfaces;

namespace Watching.Application.Validators.UserValidators
{

    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly IUserService _userService;

        public CreateUserValidator(IUserService userService)
        {
            _userService = userService;

            //RuleFor(user => user.FullName)
            //.NotEmpty().WithMessage("Full Name is required.")
            //.Must(BeUniqueFullName).WithMessage("Full Name is already taken.");

            RuleFor(user => user.FullName)
                .NotEmpty().WithMessage("Full Name is required.")
                .Must(BeValidFullName).WithMessage("Full Name contains invalid characters.");
        }

        //private bool BeUniqueFullName(string fullName)
        //{
        //    // Check if a user with the same FullName already exists in the database
        //    var existingUser = _userService.GetUserByFullName(fullName);

        //    // If an existing user with the same FullName is found, return false
        //    return existingUser == null;
        //}
        private bool BeValidFullName(string fullName)
        {
            string invalidCharacters = "!@#$%^&*()=+{}[]/";

            return !fullName.Any(c => invalidCharacters.Contains(c));
        }
    }

}
