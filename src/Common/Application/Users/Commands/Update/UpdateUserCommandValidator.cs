using CleanApplication.Application.Common.Interfaces;
using FluentValidation;

namespace CleanApplication.Application.Users.Commands.Update
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateUserCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Id).NotNull().WithMessage("Идентификатор пуст");
        }
      
    }
}
