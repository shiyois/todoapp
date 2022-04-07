using FluentValidation;

namespace CleanApplication.Application.Tags.Queries.GetTagById
{
    public class GetTagByIdQueryValidator : AbstractValidator<GetTagByIdQuery>
    {
        public GetTagByIdQueryValidator()
        {
            RuleFor(x => x.Id)
              .NotNull()
              .NotEmpty().WithMessage("Идентификатор пуст");
        }
    }
}
