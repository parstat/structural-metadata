using System;
using System.Collections.Generic;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.NodeSets.StatisticalClassifications.Queries.GetFlatStatisticalClassification
{
    public class StatisticalClassificationFlatDto : AbstractConceptDto, IMapFrom<NodeSet>
    {
        public List<LevelDetailsFlatDto> Levels { get; set; }
        public List<StatisticalClassificationItemFlatDto> Items { get; set; }

        public void Mapping(Profile profile)
        {
            //language parameter from request
            //default english
            string language = "en";
            profile.CreateMap<NodeSet, StatisticalClassificationFlatDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name != null ? s.Name.Text(language) : String.Empty))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description != null ? s.Description.Text(language) : String.Empty))
                .ForMember(d => d.VersionRationale, opt => opt.MapFrom(s => s.VersionRationale != null ? s.VersionRationale.Text(language) : String.Empty))
                .ForMember(d => d.Definition, opt => opt.MapFrom(s => s.Definition != null ? s.Definition.Text(language) : String.Empty))
                .ForMember(d => d.Link, opt => opt.MapFrom(s => s.Link != null ? s.Link.Text(language) : String.Empty))
                .ForMember(d => d.Items, opt => opt.MapFrom(s => s.Nodes));
        }
    }
}