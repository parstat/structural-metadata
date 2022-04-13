using System;
using System.Collections.Generic;
using Presentation.Common.Domain.StructuralMetadata.Abstracts.Gsim;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;

namespace Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure
{
    public class Component : AbstractIdentifiableArtefact
    {
        public ComponentType Type { get; set; }
        public long RepresentedVariableId { get; set; }
        public RepresentedVariable RepresentedVariable { get; set; }
        public long DataStructureId { get; set; }
        public DataStructure DataStructure { get; set; }
        public IList<LogicalRecord> Records { get; set; }

        public Component() 
        {
            this.Records = new List<LogicalRecord>();
        }
    }
}
