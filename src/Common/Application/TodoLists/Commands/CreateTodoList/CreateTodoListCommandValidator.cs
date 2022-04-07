using CleanApplication.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CleanApplication.Application.TodoLists.Commands.CreateTodoList
{
    public class CreateTodoListCommandValidator : AbstractValidator<CreateTodoListCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateTodoListCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Title)
                .NotEmpty().WithMessage("Введите заголовок")
                .MaximumLength(200).WithMessage("Заголовок должен быть не больше 200 символов")
                .MustAsync(BeUniqueTitle).WithMessage("Такой заголовок уже существует");
        }

        public async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken)
        {
            return await _context.TodoLists
                .AllAsync(l => l.Title != title);
        }
    }
}
