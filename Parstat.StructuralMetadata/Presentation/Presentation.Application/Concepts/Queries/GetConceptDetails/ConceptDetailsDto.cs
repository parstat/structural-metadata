using System;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.Concepts.Queries.GetConceptDetails
{
    public class ConceptDetailsDto : AbstractConceptDto, IMapFrom<Concept>
    {
        public void Mapping(Profile profile)
        {
            //language parameter from  request
            //default english
            string language = "en";
            profile.CreateMap<Concept, ConceptDetailsDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name == null ? String.Empty : s.Name.Text(language)))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description != null ? s.Description.Text(language) : String.Empty))
                .ForMember(d => d.VersionRationale, opt => opt.MapFrom(s => s.VersionRationale != null ? s.VersionRationale.Text(language) : String.Empty))
                .ForMember(d => d.Definition, opt => opt.MapFrom(s => s.Definition != null ? s.Definition.Text(language) : String.Empty))
                .ForMember(d => d.Link, opt => opt.MapFrom(s => s.Link != null ? s.Link.Text(language) : String.Empty));
        }
    }
}