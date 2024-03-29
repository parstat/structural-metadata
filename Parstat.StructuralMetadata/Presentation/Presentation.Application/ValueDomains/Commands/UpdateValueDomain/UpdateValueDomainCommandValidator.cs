﻿using FluentValidation;
using Presentation.Common.Domain.StructuralMetadata.Enums;

namespace Presentation.Application.ValueDomains.Commands.UpdateValueDomain
{
    public class UpdateValueDomainCommandValidator : AbstractValidator<UpdateValueDomainCommand>
    {
        public UpdateValueDomainCommandValidator()
        {
            RuleFor(x => x.LocalId).Length(1, 100).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.DataType).IsInEnum();
            RuleFor(x => x.Type).IsInEnum();
            RuleFor(x => x.Expression).NotEmpty().When(x => x.Type == ValueDomainType.DESCRIBED);            
            RuleFor(x => x.LevelId).NotEmpty().When(x => (x.Type == ValueDomainType.ENUMERATED && x.NodesetId == null));
        }
    }
}
