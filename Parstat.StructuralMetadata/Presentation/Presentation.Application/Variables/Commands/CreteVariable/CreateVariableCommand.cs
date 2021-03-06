using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation.Application.Common.Exceptions;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Application.Variables.Commands.CreteVariable
{
    public class CreateVariableCommand : AbstractRequest, IRequest<long>
    {
        public string LocalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; } = "1.0";
        public DateTime VersionDate { get; set; } = DateTime.Now;
        public string VersionRationale { get; set; } = "First Version";
        public string Definition { get; set; }
        public long MeasuresId { get; set; }

        public class Handler : IRequestHandler<CreateVariableCommand, long>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context) 
            {
                _context = context;
            }

            public async Task<long> Handle(CreateVariableCommand request, CancellationToken cancellationToken)
            {
                Language language;
                Enum.TryParse<Language>(request.Language, true, out language);
                var unitType = await _context.UnitTypes
                    .FirstOrDefaultAsync(ut => ut.Id == request.MeasuresId);

                if(unitType == null) 
                {
                     throw new NotFoundException(nameof(UnitType), request.MeasuresId);
                }  
                var entity = new Variable 
                {
                      LocalId = request.LocalId,
                      Name = MultilanguageString.Init(language, request.Name),
                      Description = MultilanguageString.Init(language, request.Description),
                      Version = request.Version,
                      VersionDate = request.VersionDate,
                      VersionRationale = MultilanguageString.Init(language, request.VersionRationale),
                      Definition = MultilanguageString.Init(language, request.Definition),
                      MeasuresId = request.MeasuresId
                };
                _context.Variables.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return entity.Id;
            }

        }
    }
}