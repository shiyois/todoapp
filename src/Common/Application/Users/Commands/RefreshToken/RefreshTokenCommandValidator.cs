using FluentValidation;

namespace CleanApplication.Application.Users.Commands.RefreshToken
{
    public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
    {
        public RefreshTokenCommandValidator()
        {
            RuleFor(v => v.RefreshToken)
             .NotEmpty().WithMessage("Токен пуст");
        }
    }

}
