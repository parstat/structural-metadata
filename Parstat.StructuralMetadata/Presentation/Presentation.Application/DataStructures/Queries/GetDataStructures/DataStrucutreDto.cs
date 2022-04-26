using System;
using AutoMapper;
using Presentation.Application.Common.Mappings;
using Presentation.Common.Domain.StructuralMetadata.Abstracts.Gsim;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure;

namespace Presentation.Application.DataStructures.Queries.GetDataStructures
{
    public class DataStrucutreDto : AbstractIdentifiableArtefact, IMapFrom<DataStructure>
    {
        public string Group { get; set; }

         public void Mapping(Profile profile)
        {
            //language parameter from  request
            //default english
            string language = "en";
            profile.CreateMap<DataStructure, DataStrucutreDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name != null ? s.Name.Text(language) : String.Empty))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description != null ? s.Description.Text(language) : String.Empty))
                .ForMember(d => d.VersionRationale, opt => opt.MapFrom(s => s.VersionRationale != null ? s.VersionRationale.Text(language) : String.Empty)
                );
        }
    }
}