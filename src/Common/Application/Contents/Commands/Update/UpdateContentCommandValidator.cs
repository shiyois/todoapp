using FluentValidation;

namespace CleanApplication.Application.Contents.Commands.Update
{
    public class UpdateContentCommandValidator : AbstractValidator<UpdateContentCommand>
    {
        public UpdateContentCommandValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(200).WithMessage("Имя не должно содержать более 200 символов")
                .NotNull().NotEmpty().WithMessage("Имя не должно быть пустым");

            RuleFor(v => v.Id).NotNull();
        }
    }
}
