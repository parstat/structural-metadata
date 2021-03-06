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

namespace Presentation.Application.DataSets.UnitDataSet.Queries.GetUnitDataSets
{
    public class GetUnitDataSetsQuery : AbstractRequest, IRequest<UnitDataSetsVm>
    {
        
        public class GetLabelsQueryHandler : IRequestHandler<GetUnitDataSetsQuery, UnitDataSetsVm>
        {
            private readonly IStructuralMetadataDbContext _context;
            private readonly IMapper _mapper;

            public GetLabelsQueryHandler(IStructuralMetadataDbContext context, IMapper mapper) 
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<UnitDataSetsVm> Handle(GetUnitDataSetsQuery request, CancellationToken cancellationToken)
            {
                
                var datasets = await _context.DataSets.Where(ds => ds.Type == DataSetType.UNIT)
                    .AsNoTracking()
                    .ProjectTo<UnitDataSetMiniDto>(_mapper.ConfigurationProvider, new Dictionary<string, object> {["language"] = request.Language})
                    .OrderBy(mu => mu.Id)
                    .ToListAsync(cancellationToken);

                var vm = new UnitDataSetsVm
                {
                    UnitDataSets = datasets
                };

                return vm;
            }
        }
    }
}
