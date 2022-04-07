using CleanApplication.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CleanApplication.Application.Settings.Commands.Create
{
    public class CreateSettingCommandValidator : AbstractValidator<CreateSettingCommand>
    {
        private readonly IApplicationDbContext _context;
        public CreateSettingCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.Name)
       .MaximumLength(2048).WithMessage("Имя ключа не должно превышать 2048 символов")
       .NotNull().NotEmpty().WithMessage("Имя ключа не должно быть пустым")
             .MustAsync(BeUniqueName).WithMessage("Указанный заголовок уже существует");
        }
        public async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        {
            return await _context.Settings
                .AllAsync(l => l.Name != name);
        }

    }
}
