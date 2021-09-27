using Presentation.Common.Domain.StructuralMetadata.Abstracts.Gsim;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using System.Collections.Generic;

namespace Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept
{
    public class ValueDomain : AbstractIdentifiableArtefact
    {
        public ValueDomain() {
            Representations = new List<RepresentedVariableValueDomain>();
        }
        public ValueDomainType Type { get; set; }
        public string Expression { get; set; }
        public DataType DataType { get; set; }
        public long? LevelId { get; set; }
        public Level Level { get; set; }
        public long? NodeSetId { get; set; }
        public NodeSet NodeSet { get; set; }
        //public IEnumerable<RepresentedVariable> RepresentedVariables { get; set; }
        public IList<RepresentedVariableValueDomain> Representations { get; set; }


    }
}