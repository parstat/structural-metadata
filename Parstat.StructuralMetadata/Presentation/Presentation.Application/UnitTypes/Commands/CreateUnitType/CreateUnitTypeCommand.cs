using MediatR;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Application.UnitTypes.Commands.CreateUnitType
{
    public class CreateUnitTypeCommand : AbstractRequest, IRequest<long>
    {
        public string LocalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public DateTime VersionDate { get; set; }
        public string VersionRationale { get; set; }
        public string Definition { get; set; }

        public class Handler : IRequestHandler<CreateUnitTypeCommand, long>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context) 
            {
                _context = context;
            }

            public async Task<long> Handle(CreateUnitTypeCommand request, CancellationToken cancellationToken)
            {
                Language language;
                Enum.TryParse<Language>(request.Language, true, out language);
                var entity = new UnitType 
                {
                      LocalId = request.LocalId,
                      Name = MultilanguageString.Init(language, request.Name),
                      Description = request.Description != null ? MultilanguageString.Init(language, request.Description) : null,
                      Version = request.Version != null ? request.Version : "1.0",
                      VersionDate = request.VersionDate != null ? request.VersionDate : DateTime.Now,
                      VersionRationale = request.VersionRationale != null ? MultilanguageString.Init(language, request.VersionRationale) : null,
                      Definition = request.Definition != null ? MultilanguageString.Init(language, request.Definition) : null,
                };
                _context.UnitTypes.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return entity.Id;
            }
        }
    }
}