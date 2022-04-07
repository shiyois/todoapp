using FluentValidation;
using System;

namespace CleanApplication.Application.Users.Commands.Create
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(v => v.Email)
                .MaximumLength(100).WithMessage("Адрес электронной почты не должен превышать 100 символов")
                .NotEmpty().WithMessage("Электронная почта пуста");
            RuleFor(v => v.Email)
                .EmailAddress().WithMessage("Неверный формат электронной почты");

            RuleFor(v => v.Password)
                .NotEmpty().WithMessage("Пароль не должен быть пустым");

            RuleFor(v => v.SmsCode)
                .NotEmpty().WithMessage("Проверочный код не должен быть пустым");

            RuleFor(v => v.SmsCode)
                .Matches(@"^\d{5}$")
                .WithMessage("Проверочный код недействителен");


            RuleFor(p => p.DateOfBirth)
            .Must(BeAValidAge);

        }
        
        protected bool BeAValidAge(DateTime date)
        {
            int currentYear = DateTime.Now.Year;
            int dobYear = date.Year;

            if (dobYear <= currentYear && dobYear > (currentYear - 120))
            {
                return true;
            }

            return false;
        }

    }
}
