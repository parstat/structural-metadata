using System;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.Variables.Queries.GetVariableDetails
{
    public class RepresentedVariableMiniDto : AbstractBaseDto, IMapFrom<RepresentedVariable>
    {
        public string LocalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public SubstantiveValueDomainMiniDto SubstantiveValueDomain { get; set; }
        public SentinelValueDomainMiniDto SentinelValueDomain { get; set; }

        public void Mapping(Profile profile)
        {
            //language parameter from request
            //default to english
            string language = "en";
            profile.CreateMap<RepresentedVariable, RepresentedVariableMiniDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.LocalId, opt => opt.MapFrom(s => s.LocalId))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name != null ? s.Name.Text(language) : String.Empty))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description != null ? s.Description.Text(language) : String.Empty))
                .ForMember(d => d.SubstantiveValueDomain, opt => opt.MapFrom(s => s.SubstantiveValueDomain))
                .ForMember(d => d.SentinelValueDomain, opt => opt.MapFrom(s => s.SentinelValueDomain != null ? s.SentinelValueDomain : null));
        }
    }
}