using System;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.DataSets.Common
{
    public class ValueItemMiniDto : AbstractBaseDto, IMapFrom<Node>
    {
        public string Code { get; set; }
        public string Value { get; set; }
        public void Mapping(Profile profile)
        {
            //language parameter from request
            //default to english
            string language = "en";
            profile.CreateMap<Node, ValueItemMiniDto>()
                .ForMember(d => d.Code, opt => opt.MapFrom(s => s.Code))
                .ForMember(d => d.Value, opt => opt.MapFrom(s => s.Label != null && s.Label.Value != null ? s.Label.Value.Text(language) : String.Empty));
        } 
    }
}