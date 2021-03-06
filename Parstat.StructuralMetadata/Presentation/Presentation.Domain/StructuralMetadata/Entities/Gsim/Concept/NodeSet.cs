using Presentation.Common.Domain.StructuralMetadata.Abstracts.Gsim;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using System.Collections.Generic;

namespace Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept
{
    public class NodeSet : AbstractConcept
    {
        public NodeSet() {
            //SentinelValueDomains = new HashSet<ValueDomain>();
            //SubstantiveValueDomains = new HashSet<ValueDomain>();
            Nodes = new List<Node>();
            Levels = new List<Level>();
        }
       // public IEnumerable<ValueDomain> SentinelValueDomains { get; set; }

        //public IEnumerable<ValueDomain>  SubstantiveValueDomains { get; set; }

        public NodeSetType NodeSetType { get; set; }
        public IList<Node> Nodes { get; set; }
        public IList<Level> Levels { get; set; }

    }
}