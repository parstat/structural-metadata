using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Presentation.Application.Common.Interfaces;
using Presentation.Application.Common.Requests;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.NodeSets.CodeLists.Queries.GetCodeLists
{
    public class GetCodeListsQuery : AbstractRequest, IRequest<CodeListsVm>
    {
        public string Name { get; set; }
        public class GetCodeListsQueryHandler : IRequestHandler<GetCodeListsQuery, CodeListsVm>
        {
            private readonly IStructuralMetadataDbContext _context;
            private readonly IMapper _mapper;

            public GetCodeListsQueryHandler(IStructuralMetadataDbContext context, IMapper mapper) 
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CodeListsVm> Handle(GetCodeListsQuery request, CancellationToken cancellationToken)
            {
                IQueryable<NodeSet> codeListsQuery = createQuery(request.Name, request.Language);
                var codeLists = await codeListsQuery.AsNoTracking()
                    .ProjectTo<CodeListDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> {["language"] = request.Language})
                    .OrderBy(cl => cl.LocalId)
                    .ToListAsync(cancellationToken);

                var vm = new CodeListsVm
                {
                    CodeLists = codeLists
                };

                return vm;
            }

            private IQueryable<NodeSet> createQuery(string name, string language) 
            {

                IQueryable<NodeSet> nodeSetsQuery =  _context.NodeSets
                    .Where(ns => ns.NodeSetType == NodeSetType.CODE_LIST || ns.NodeSetType == NodeSetType.SENTINEL_CODE_LIST);

                if (!String.IsNullOrEmpty(name))
                {
                    if(language == "en")
                    {
                        nodeSetsQuery = nodeSetsQuery.Where( ns => EF.Functions.ILike(ns.Name.En.ToUpper(), $"%{name.ToUpper()}%")
                                                  || EF.Functions.ILike(ns.LocalId.ToUpper(), $"%{name.ToUpper()}%"));
                    }
                    if(language == "ru")
                    {
                        nodeSetsQuery = nodeSetsQuery.Where( ns => EF.Functions.ILike(ns.Name.Ru.ToUpper(), $"%{name.ToUpper()}%")
                                                  || EF.Functions.ILike(ns.LocalId.ToUpper(), $"%{name.ToUpper()}%"));
                    }
                    if(language == "ro")
                    {
                        nodeSetsQuery = nodeSetsQuery.Where( ns => EF.Functions.ILike(ns.Name.Ro.ToUpper(), $"%{name.ToUpper()}%")
                                                  || EF.Functions.ILike(ns.LocalId.ToUpper(), $"%{name.ToUpper()}%"));
                    }
                }

                return nodeSetsQuery;
            }
        }
    }
}