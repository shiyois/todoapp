using FluentValidation;

namespace CleanApplication.Application.Settings.Queries.GetSettingById
{
    public class GetSettingByIdQueryValidator : AbstractValidator<GetSettingByIdQuery>
    {
        public GetSettingByIdQueryValidator()
        {
            RuleFor(x => x.Id)
              .NotNull()
              .NotEmpty().WithMessage("Идентификатор пуст");
        }
    }
}
