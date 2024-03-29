﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;

namespace Presentation.Application.NodeSets.CodeList.Commands.RemoveCodeItemCommand
{
    public class RemoveCodeItemCommand : AbstractRequest, IRequest<Unit>
    {
        public long NodeSetId { get; set; }
        public string Code { get; set; }
        public class Handler : IRequestHandler<RemoveCodeItemCommand, Unit>
        {
            private readonly IStructuralMetadataDbContext _context;

            public Handler(IStructuralMetadataDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(RemoveCodeItemCommand request, CancellationToken cancellationToken)
            {
                //Check if nodeset exist
                var node = await _context.Nodes.FirstOrDefaultAsync(n => n.NodeSetId == request.NodeSetId
                                                                     &&  n.Code == request.Code);
                if (node != null)
                {
                    _context.Nodes.Remove(node); 
                    await _context.SaveChangesAsync(cancellationToken);
                }

                return Unit.Value;
            }
        }
    }
}