using AuthorizationService.Models.Authorization;
using FluentValidation;

namespace AuthorizationService.Validation;

public class UserDtoValidator : AbstractValidator<UserDto>
{
    public UserDtoValidator()
    {
        RuleFor(dto => dto.Email)
            .NotNull().WithMessage("Email address is required")
            .EmailAddress().WithMessage("Email is not valid");

        RuleFor(dto => dto.Password)
            .Equal(dto => dto.PasswordConfirmation)
            .WithMessage("Confirmation password not equal");
    }
}