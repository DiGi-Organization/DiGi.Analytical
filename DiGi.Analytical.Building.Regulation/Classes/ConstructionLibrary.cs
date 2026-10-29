using DiGi.Analytical.Building.Classes;
using DiGi.Analytical.Building.Interfaces;
using DiGi.Analytical.Building.Regulation.Enums;
using DiGi.Analytical.Building.Regulation.Interfaces;
using DiGi.Core;
using DiGi.Core.Classes;
using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Analytical.Building.Regulation.Classes
{
    /// <summary>
    /// Represents a library of constructions - materials, layered constructions and window and door constructions - and the <see cref="ConstructionSet"/>s choosing them per building type and date range (DiGi-Organization/DiGi.Analytical#8).
    /// <para>A construction is brought into a building model with its layers and materials by <see cref="BuildingModel.Update(ConstructionRelationCluster?, IConstruction?)"/>, passing <see cref="ConstructionRelationCluster"/>.</para>
    /// </summary>
    public class ConstructionLibrary : GuidObject, IRegulationSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(ConstructionRelationCluster))]
        private readonly ConstructionRelationCluster constructionRelationCluster = [];

        [JsonInclude, JsonPropertyName("ConstructionSets")]
        private readonly List<ConstructionSet> constructionSets = [];

        [JsonInclude, JsonPropertyName(nameof(Description))]
        private readonly string? description;

        [JsonInclude, JsonPropertyName(nameof(Name))]
        private readonly string? name;

        [JsonInclude, JsonPropertyName(nameof(Version))]
        private readonly string? version;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstructionLibrary"/> class.
        /// </summary>
        /// <param name="name">The name of the library. This value can be null.</param>
        /// <param name="version">The version of the library. This value can be null.</param>
        /// <param name="description">The description of the library. This value can be null.</param>
        public ConstructionLibrary(string? name, string? version, string? description)
            : base()
        {
            this.name = name;
            this.version = version;
            this.description = description;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstructionLibrary"/> class by copying another instance, its constructions and its sets.
        /// </summary>
        /// <param name="constructionLibrary">The source <see cref="ConstructionLibrary"/> to copy from. This value can be null.</param>
        public ConstructionLibrary(ConstructionLibrary? constructionLibrary)
            : base(constructionLibrary)
        {
            if (constructionLibrary is not null)
            {
                name = constructionLibrary.name;
                version = constructionLibrary.version;
                description = constructionLibrary.description;
                constructionRelationCluster = Core.Query.Clone(constructionLibrary.constructionRelationCluster) ?? [];

                foreach (ConstructionSet constructionSet in constructionLibrary.constructionSets)
                {
                    if (Core.Query.Clone(constructionSet) is ConstructionSet constructionSet_Clone)
                    {
                        constructionSets.Add(constructionSet_Clone);
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstructionLibrary"/> class from the specified JSON object.
        /// </summary>
        /// <param name="jsonObject">The <see cref="JsonObject"/> containing the data. This value can be null.</param>
        public ConstructionLibrary(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the cluster holding the library's materials, constructions and structure layers.
        /// <para>This is the library's own cluster, not a copy: the library is built by adding to it (for example with <c>Create.StructureLayer</c>).</para>
        /// </summary>
        [JsonIgnore]
        public ConstructionRelationCluster ConstructionRelationCluster
        {
            get
            {
                return constructionRelationCluster;
            }
        }

        /// <summary>
        /// Gets the description of the library.
        /// </summary>
        [JsonIgnore]
        public string? Description
        {
            get
            {
                return description;
            }
        }

        /// <summary>
        /// Gets the name of the library.
        /// </summary>
        [JsonIgnore]
        public string? Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// Gets the version of the library.
        /// </summary>
        [JsonIgnore]
        public string? Version
        {
            get
            {
                return version;
            }
        }

        /// <summary>
        /// Adds a construction set to the library.
        /// </summary>
        /// <param name="constructionSet">The construction set. This value can be null.</param>
        /// <returns>True if the set was added; false if it is null.</returns>
        public bool Add(ConstructionSet? constructionSet)
        {
            if (constructionSet is null)
            {
                return false;
            }

            constructionSets.Add(constructionSet);
            return true;
        }

        /// <summary>
        /// Gets the construction the specified set uses for the specified role.
        /// </summary>
        /// <param name="constructionSet">The construction set. This value can be null.</param>
        /// <param name="constructionRole">The role.</param>
        /// <returns>A CLONE of the <see cref="IConstruction"/>, or null when the set has no construction for the role or the library does not hold it.</returns>
        public IConstruction? GetConstruction(ConstructionSet? constructionSet, ConstructionRole constructionRole)
        {
            GuidReference? guidReference = constructionSet?.GetConstructionReference(constructionRole);
            if (guidReference is null || !constructionRelationCluster.TryGetValue(guidReference, out IConstruction? construction))
            {
                return null;
            }

            return construction?.Clone<IConstruction>();
        }

        /// <summary>
        /// Gets the construction set that applies to a building of the specified type, climatic zone and flavour on the specified date.
        /// <para>A set for the building's own zone wins over a set for every zone; among equally specific sets the one starting latest wins.</para>
        /// </summary>
        /// <param name="dateTimeOffset">The design date (<see cref="ConstructionFlavour.Regulation"/>) or the date built (<see cref="ConstructionFlavour.TypicalAsBuilt"/>).</param>
        /// <param name="buildingType">The building type.</param>
        /// <param name="climateZone">The climatic zone of the building.</param>
        /// <param name="constructionFlavour">The kind of constructions wanted.</param>
        /// <returns>A CLONE of the <see cref="ConstructionSet"/>, or null when none applies.</returns>
        public ConstructionSet? GetConstructionSet(DateTimeOffset dateTimeOffset, BuildingType buildingType, ClimateZone climateZone, ConstructionFlavour constructionFlavour)
        {
            ConstructionSet? result = null;
            foreach (ConstructionSet constructionSet in constructionSets)
            {
                if (constructionSet.ConstructionFlavour != constructionFlavour || constructionSet.BuildingType != buildingType || !constructionSet.Includes(dateTimeOffset))
                {
                    continue;
                }

                if (constructionSet.ClimateZone is ClimateZone climateZone_Set && climateZone_Set != climateZone)
                {
                    continue;
                }

                if (result is null)
                {
                    result = constructionSet;
                    continue;
                }

                bool exact = constructionSet.ClimateZone is not null;
                bool exact_Result = result.ClimateZone is not null;
                if ((exact && !exact_Result) || (exact == exact_Result && constructionSet.StartDate > result.StartDate))
                {
                    result = constructionSet;
                }
            }

            return Core.Query.Clone(result);
        }

        /// <summary>
        /// Gets the construction sets of the library.
        /// </summary>
        /// <returns>CLONES of the library's <see cref="ConstructionSet"/>s.</returns>
        public List<ConstructionSet> GetConstructionSets()
        {
            List<ConstructionSet> result = [];
            foreach (ConstructionSet constructionSet in constructionSets)
            {
                if (Core.Query.Clone(constructionSet) is ConstructionSet constructionSet_Clone)
                {
                    result.Add(constructionSet_Clone);
                }
            }

            return result;
        }
    }
}
