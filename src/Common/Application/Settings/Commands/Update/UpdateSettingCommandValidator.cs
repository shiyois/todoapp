using CleanApplication.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CleanApplication.Application.Settings.Commands.Update
{
    public class UpdateSettingCommandValidator : AbstractValidator<UpdateSettingCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateSettingCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Id).NotNull();
        }
        public async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        {
            return await _context.Settings
                .AllAsync(l => l.Name != name);
        }
    }
}
