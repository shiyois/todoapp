using FluentValidation;

namespace CleanApplication.Application.Contents.Queries.GetContentById
{
    public class GetContentByIdQueryValidator : AbstractValidator<GetContentByIdQuery>
    {
        public GetContentByIdQueryValidator()
        {
            RuleFor(x => x.Id)
              .NotNull()
              .NotEmpty().WithMessage("Идентификатор пуст");
        }
    }
}
