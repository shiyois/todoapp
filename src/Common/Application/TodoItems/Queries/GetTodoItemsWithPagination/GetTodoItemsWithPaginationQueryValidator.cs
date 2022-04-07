using FluentValidation;

namespace CleanApplication.Application.TodoItems.Queries.GetTodoItemsWithPagination
{
    public class GetTodoItemsWithPaginationQueryValidator : AbstractValidator<GetTodoItemsWithPaginationQuery>
    {
        public GetTodoItemsWithPaginationQueryValidator()
        {
            RuleFor(x => x.ListId)
                .NotNull()
                .NotEmpty().WithMessage("Требуется идентификатор списка");

            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1).WithMessage("Номер страницы должен быть больше или равен 1");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("Размер страницы должен быть больше или равен 1");
        }
    }
}
