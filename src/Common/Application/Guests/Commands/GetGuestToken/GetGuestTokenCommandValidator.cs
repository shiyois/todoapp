using FluentValidation;

namespace CleanApplication.Application.Guests.Commands.GetGuestToken
{
    public class GetGuestTokenCommandValidator : AbstractValidator<GetGuestTokenCommand>
    {
        public GetGuestTokenCommandValidator()
        {
            RuleFor(v => v.PhoneNumber)
            .MaximumLength(11)
            .NotEmpty();

            RuleFor(v => v.FirstName)
             .NotEmpty().WithMessage("Имя не должно быть пустым");

            RuleFor(v => v.LastName)
             .NotEmpty().WithMessage("Фамилия не должна быть пустой");

            RuleFor(v => v.SmsCode)
             .NotEmpty().WithMessage("Проверочный код не должен быть пустым");

            RuleFor(v => v.SmsCode)
                .Matches(@"^\d{5}$")
                .WithMessage("Проверочный код недействителен");
        }
    }
}
