﻿using FluentValidation;

namespace CleanApplication.Application.Tags.Commands.Update
{
    public class UpdateTagCommandValidator : AbstractValidator<UpdateTagCommand>
    {
        public UpdateTagCommandValidator()
        {
            RuleFor(p => p.KeyName).NotNull().NotEmpty().WithMessage("Ключ не должен быть пустым");
            RuleFor(p => p.Name).NotNull().NotEmpty().WithMessage("Имя не должно быть пустым");
        }
    }
}
