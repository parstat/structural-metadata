using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Presentation.Common.Domain;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Concept;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure;
using Presentation.Domain.StructuralMetadata.Entities.Tags;

namespace Presentation.Application.Common.Interfaces
{
    public interface IStructuralMetadataDbContext
    {
         DbSet<Category> Categories {get; set;}
         DbSet<Correspondence> Correspondences {get; set;}
         DbSet<Concept> Concepts { get; set; }
         DbSet<Label> Labels {get; set;}
         DbSet<Level> Levels {get; set;}
         DbSet<Mapping> Mappings {get; set;}
         DbSet<MeasurementType> MeasurementTypes {get; set;}
         DbSet<MeasurementUnit> MeasurementUnits {get; set;}
         DbSet<Node> Nodes {get; set;}
         DbSet<NodeSet> NodeSets {get; set;}
         DbSet<RepresentedVariable> RepresentedVariables {get; set;}
         DbSet<UnitType> UnitTypes {get; set;}
         DbSet<ValueDomain> ValueDomains {get; set;}
         DbSet<Variable> Variables {get; set;}

         DbSet<Tag> Tags { get; set; }
         DbSet<EntityTag> EntityTags { get; set; }
         DbSet<DataSet> DataSets { get; set; }
         DbSet<DataStructure> DataStructures { get; set; }
         DbSet<LogicalRecord> LogicalRecords { get; set ; }
         DbSet<Component> Components { get; set; }
         Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        EntityEntry Entry(AuditableEntity entity);
    }
}