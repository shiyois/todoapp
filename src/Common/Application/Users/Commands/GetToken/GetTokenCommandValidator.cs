using FluentValidation;

namespace CleanApplication.Application.Users.Queries.GetToken
{
    public class CreateUserCommandValidator : AbstractValidator<GetTokenCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(v => v.Email)
                .MaximumLength(100).WithMessage("Адрес электронной почты не должен превышать 100 символов")
                .NotEmpty().WithMessage("Электронная почта пуста");
            
            RuleFor(v => v.Email)
                .EmailAddress().WithMessage("Неверный формат электронной почты");

            RuleFor(v => v.Password)
                .NotEmpty().WithMessage("Пароль пуст");
        }
    }
}
