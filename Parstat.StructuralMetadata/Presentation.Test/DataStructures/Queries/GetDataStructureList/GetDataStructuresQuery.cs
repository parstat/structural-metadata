﻿using FluentAssertions;
using NUnit.Framework;
using Presentation.Application.DataStructures.UnitDataStructure.Queries.GetDataStructures;
using Presentation.Common.Domain.StructuralMetadata.Enums;
using Presentation.Domain;
using Presentation.Domain.StructuralMetadata.Entities.Gsim.Structure;
using System;
using System.Threading.Tasks;

namespace Presentation.Test.DataStructures.Queries.GetDataStructureList
{
    using static Testing;
    public class GetDataStructuresQueryList
    {
        [Test]
        public async Task GetDataStructuresQuery_ShouldReturnTheListOfDataStructures()
        {
            // Arrange
            var dataStructure = new DataStructure
            {
                LocalId = Guid.NewGuid().ToString(),
                Name = MultilanguageString.Init(Language.EN, "Variable1"),
                Description = MultilanguageString.Init(Language.EN, "Description of variable 1"),
                Version = "1.1",
                Group = "Data structure group",
                VersionDate = DateTime.Now,
                Type = DataSetType.UNIT,
            };

            await AddAsync(dataStructure);

            // Act
            var query = new GetUnitDataStructuresQuery();
            UnitDataStructuresVm result = await SendAsync(query);

            // Assert
            result.Should().NotBeNull();
            result.UnitDataStructures.Should().HaveCountGreaterThan(0);
        }
    }
}
