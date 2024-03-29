﻿using MediatR;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Application.DataStructures.UnitDataStructure.Commands.CreateCommand
{
    public class CreateUnitDataStructureCommand : AbstractRequest, IRequest<long>
    {
        public string LocalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; } = "1.0";
        public DateTime VersionDate { get; set; } = DateTime.Now;
        public string VersionRationale { get; set; } = "First Version";
        public string Group { get; set; }
        public DataSetType Type { get; set; }

        public class Handler : IRequestHandler<CreateUnitDataStructureCommand, long>
        {
            private readonly IStructuralMetadataDbContext _context;
            public Handler(IStructuralMetadataDbContext context)
            {
                _context = context;
            }
            public async Task<long> Handle(CreateUnitDataStructureCommand request, CancellationToken cancellationToken)
            {
                Enum.TryParse(request.Language, true, out Language language);

                var dataStructure = new Domain.StructuralMetadata.Entities.Gsim.Structure.DataStructure()
                {                    
                    LocalId = request.LocalId,
                    Name = MultilanguageString.Init(language, request.Name),
                    Description = MultilanguageString.Init(language, request.Description),
                    Version = request.Version,
                    VersionDate = request.VersionDate,
                    VersionRationale = MultilanguageString.Init(language, request.VersionRationale),
                    Group = request.Group,
                    Type = request.Type
                };

                _context.DataStructures.Add(dataStructure);

                await _context.SaveChangesAsync(cancellationToken);

                //await _mediator.Publish(new VariableCreated {Id = entity.Id}, cancellationToken);

                return dataStructure.Id;
            }
        }
    }
}
