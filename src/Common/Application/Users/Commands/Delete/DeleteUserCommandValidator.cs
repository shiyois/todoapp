using FluentValidation;

namespace CleanApplication.Application.Users.Commands.Delete
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(x=>x.Id).NotNull().NotEmpty().WithMessage("Пустой идентификатор");
        }
    }
}
