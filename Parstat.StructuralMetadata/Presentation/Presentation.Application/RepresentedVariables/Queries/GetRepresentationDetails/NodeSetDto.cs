using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Application.Common.Models;
using Presentation.Application.Common.Models.StructuralMetadata.Abstracts;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Application.RepresentedVariables.Queries.GetRepresentationDetails
{
    public class NodeSetDto : AbstractBaseDto, IMapFrom<NodeSet>
    {
        public string Name { get; set; }
        public string LocalId { get; set; }
        public string Description { get; set; }

        public NodeSetType NodeSetType { get; set; }
        //public List<NodeDto> Nodes { get; set; }

        public void Mapping(Profile profile)
        {
            //language parameter from request
            //default english
            string language = "en";
            profile.CreateMap<NodeSet, NodeSetDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.LocalId, opt => opt.MapFrom(s => s.LocalId))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name != null ? s.Name.Text(language) : null))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description != null ? s.Description.Text(language) : null))
                .ForMember(d => d.NodeSetType, opt => opt.MapFrom(s => s.NodeSetType));
                //.ForMember(d => d.Nodes, opt => opt.MapFrom(s => s.Nodes));
        } 
    }
}