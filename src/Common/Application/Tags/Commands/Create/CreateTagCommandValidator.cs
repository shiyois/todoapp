using FluentValidation;

namespace CleanApplication.Application.Tags.Commands.Create
{
    public class CreateTagCommandValidator : AbstractValidator<CreateTagCommand>
    {
        public CreateTagCommandValidator()
        {
            RuleFor(p => p.KeyName).NotNull().NotEmpty().WithMessage("Ключ не должен быть пустым");
            RuleFor(p => p.Name).NotNull().NotEmpty().WithMessage("Имя не должно быть пустым");
        }
      
    }
}
