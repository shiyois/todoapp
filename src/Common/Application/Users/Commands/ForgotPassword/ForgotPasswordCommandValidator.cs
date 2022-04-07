using FluentValidation;

namespace CleanApplication.Application.Users.Commands.ForgotPassword
{
    public class ForgotPasswordCommandValidator : AbstractValidator<ForgotPasswordCommand>
    {
        public ForgotPasswordCommandValidator()
        {
            RuleFor(v => v.Email)
              .MaximumLength(100).WithMessage("Адрес электронной почты не должен превышать 100 символов")
              .NotEmpty().WithMessage("Электронная почта пуста");
            
            RuleFor(v => v.Email)
                .EmailAddress().WithMessage("Неверный формат электронной почты");
            
            RuleFor(v => v.PhoneNumber)
              .MaximumLength(11)
              .NotEmpty();

            RuleFor(v => v.Password)
              .NotEmpty().WithMessage("Пароль не должен быть пустым");

            RuleFor(v => v.SmsCode)
           .NotEmpty().WithMessage("Проверочный код не должен быть пустым");

            RuleFor(v => v.SmsCode)
                .Matches(@"^\d{5}$")
                .WithMessage("Проверочный код недействителен");


        }

    }
}
