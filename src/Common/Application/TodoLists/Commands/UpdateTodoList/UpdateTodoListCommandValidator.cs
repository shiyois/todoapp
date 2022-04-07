using CleanApplication.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanApplication.Application.TodoLists.Commands.UpdateTodoList
{
    public class UpdateTodoListCommandValidator : AbstractValidator<UpdateTodoListCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTodoListCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Title)
                .NotEmpty().WithMessage("Введите заголовок")
                .MaximumLength(200).WithMessage("Заголовок должен быть не больше 200 символов")
                .MustAsync(BeUniqueTitle).WithMessage("Такой заголовок уже существует");
        }

        public async Task<bool> BeUniqueTitle(UpdateTodoListCommand model, string title, CancellationToken cancellationToken)
        {
            return await _context.TodoLists
                .Where(l => l.Id != model.Id)
                .AllAsync(l => l.Title != title);
        }
    }
}
