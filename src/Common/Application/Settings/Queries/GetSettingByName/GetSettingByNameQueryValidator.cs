using FluentValidation;

namespace CleanApplication.Application.Settings.Queries.GetSettingById
{
    public class GetSettingByNameQueryValidator : AbstractValidator<GetSettingByNameQuery>
    {
        public GetSettingByNameQueryValidator()
        {
            RuleFor(x => x.Name)
              .NotNull()
              .NotEmpty().WithMessage("Ключ пуст");
        }
    }
}
