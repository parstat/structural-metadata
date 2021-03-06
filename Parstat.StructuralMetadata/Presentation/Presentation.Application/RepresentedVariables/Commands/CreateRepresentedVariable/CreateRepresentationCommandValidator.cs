using FluentValidation;
using Presentation.Application.RepresentedVariables.Commands.CreateRepresentedVariable;

namespace Presentation.Application.Variables.Commands.CreteVariable
{
    public class CreateRepresentedVariableCommandValidator : AbstractValidator<CreateRepresentationVariableCommand>
    {
        public CreateRepresentedVariableCommandValidator()
        {
            RuleFor(x => x.SubstantiveValueDomainId).NotEmpty();
            RuleFor(x => x.LocalId).Length(1, 100).NotEmpty();
            RuleFor(x => x.VariableId).NotEmpty();
            RuleFor(x => x.LocalId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}