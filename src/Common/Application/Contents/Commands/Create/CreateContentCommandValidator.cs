using FluentValidation;

namespace CleanApplication.Application.Contents.Commands.Create
{
    public class CreateContentCommandValidator : AbstractValidator<CreateContentCommand>
    {
        public CreateContentCommandValidator()
        {
            RuleFor(x=>x.Name)
                .MaximumLength(200).WithMessage("Имя не должно содержать более 200 символов")
                .NotNull().NotEmpty().WithMessage("Имя не должно быть пустым");
            
        }
    }
}
