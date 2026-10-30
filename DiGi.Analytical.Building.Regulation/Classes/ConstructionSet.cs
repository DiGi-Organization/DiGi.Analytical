using DiGi.Analytical.Building.Interfaces;
using DiGi.Analytical.Building.Regulation.Enums;
using DiGi.Analytical.Building.Regulation.Interfaces;
using DiGi.Core.Classes;
using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Analytical.Building.Regulation.Classes
{
    /// <summary>
    /// Represents the constructions to use, one per <see cref="ConstructionRole"/>, for a building of a given type built or designed within a date range (DiGi-Organization/DiGi.Analytical#8).
    /// <para>A set is keyed by a date range rather than by a regime, like the regulated heat transfer coefficients: <see cref="ConstructionFlavour.Regulation"/> sets change at the dates the thermal limits changed and are looked up by design date, <see cref="ConstructionFlavour.TypicalAsBuilt"/> sets change at the TABULA period dates and are looked up by year built. The constructions themselves are held, with their layers and materials, by the <see cref="ConstructionLibrary"/> the set belongs to; the set refers to them.</para>
    /// </summary>
    public class ConstructionSet : SerializableObject, IRegulationSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(BuildingType))]
        private readonly BuildingType buildingType;

        [JsonInclude, JsonPropertyName(nameof(ClimateZone))]
        private readonly ClimateZone? climateZone;

        [JsonInclude, JsonPropertyName(nameof(ConstructionFlavour))]
        private readonly ConstructionFlavour constructionFlavour;

        [JsonInclude, JsonPropertyName("Constructions")]
        private readonly Dictionary<ConstructionRole, GuidReference> constructions = [];

        [JsonInclude, JsonPropertyName(nameof(EndDate))]
        private readonly DateTimeOffset? endDate;

        [JsonInclude, JsonPropertyName(nameof(Source))]
        private readonly string? source;

        [JsonInclude, JsonPropertyName(nameof(StartDate))]
        private readonly DateTimeOffset startDate;

        [JsonInclude, JsonPropertyName(nameof(TypologyData))]
        private readonly TypologyData? typologyData;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstructionSet"/> class.
        /// </summary>
        /// <param name="constructionFlavour">The kind of constructions the set describes.</param>
        /// <param name="buildingType">The building type the set applies to.</param>
        /// <param name="climateZone">The climatic zone the set applies to, or null for every zone.</param>
        /// <param name="startDate">The first date the set applies to.</param>
        /// <param name="endDate">The first date the set no longer applies to, or null when it still applies.</param>
        /// <param name="source">The source of the set's constructions (norm, Dz.U. text, TABULA / NAPE). This value can be null.</param>
        /// <param name="typologyData">The non-construction inputs of the typology building the set describes, or null for a set that describes none (<see cref="ConstructionFlavour.Regulation"/>).</param>
        public ConstructionSet(ConstructionFlavour constructionFlavour, BuildingType buildingType, ClimateZone? climateZone, DateTimeOffset startDate, DateTimeOffset? endDate, string? source, TypologyData? typologyData)
        {
            this.constructionFlavour = constructionFlavour;
            this.buildingType = buildingType;
            this.climateZone = climateZone;
            this.startDate = startDate;
            this.endDate = endDate;
            this.source = source;
            this.typologyData = typologyData;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstructionSet"/> class by copying another instance.
        /// </summary>
        /// <param name="constructionSet">The source <see cref="ConstructionSet"/> to copy from. This value can be null.</param>
        public ConstructionSet(ConstructionSet? constructionSet)
            : base(constructionSet)
        {
            if (constructionSet is not null)
            {
                constructionFlavour = constructionSet.constructionFlavour;
                buildingType = constructionSet.buildingType;
                climateZone = constructionSet.climateZone;
                startDate = constructionSet.startDate;
                endDate = constructionSet.endDate;
                source = constructionSet.source;
                typologyData = Core.Query.Clone(constructionSet.typologyData);

                foreach (KeyValuePair<ConstructionRole, GuidReference> keyValuePair in constructionSet.constructions)
                {
                    if (Core.Query.Clone(keyValuePair.Value) is GuidReference guidReference)
                    {
                        constructions[keyValuePair.Key] = guidReference;
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstructionSet"/> class from the specified JSON object.
        /// </summary>
        /// <param name="jsonObject">The <see cref="JsonObject"/> containing the data. This value can be null.</param>
        public ConstructionSet(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the building type the set applies to.
        /// </summary>
        [JsonIgnore]
        public BuildingType BuildingType
        {
            get
            {
                return buildingType;
            }
        }

        /// <summary>
        /// Gets the climatic zone the set applies to, or null when it applies to every zone.
        /// </summary>
        [JsonIgnore]
        public ClimateZone? ClimateZone
        {
            get
            {
                return climateZone;
            }
        }

        /// <summary>
        /// Gets the kind of constructions the set describes.
        /// </summary>
        [JsonIgnore]
        public ConstructionFlavour ConstructionFlavour
        {
            get
            {
                return constructionFlavour;
            }
        }

        /// <summary>
        /// Gets the first date the set no longer applies to, or null when it still applies.
        /// </summary>
        [JsonIgnore]
        public DateTimeOffset? EndDate
        {
            get
            {
                return endDate;
            }
        }

        /// <summary>
        /// Gets the source of the set's constructions.
        /// </summary>
        [JsonIgnore]
        public string? Source
        {
            get
            {
                return source;
            }
        }

        /// <summary>
        /// Gets the first date the set applies to.
        /// </summary>
        [JsonIgnore]
        public DateTimeOffset StartDate
        {
            get
            {
                return startDate;
            }
        }

        /// <summary>
        /// Gets a CLONE of the non-construction inputs of the typology building the set describes (frame area fraction, thermal bridging, floor boundary and the TABULA balance factors), or null when the set describes no typology building (DiGi-Organization/DiGi.Analytical#17).
        /// </summary>
        [JsonIgnore]
        public TypologyData? TypologyData
        {
            get
            {
                return Core.Query.Clone(typologyData);
            }
        }

        /// <summary>
        /// Gets the reference of the construction used for the specified role.
        /// </summary>
        /// <param name="constructionRole">The role.</param>
        /// <returns>A CLONE of the construction's <see cref="GuidReference"/>, or null when the set has no construction for the role.</returns>
        public GuidReference? GetConstructionReference(ConstructionRole constructionRole)
        {
            return constructions.TryGetValue(constructionRole, out GuidReference? guidReference) ? Core.Query.Clone(guidReference) : null;
        }

        /// <summary>
        /// Gets the roles the set has a construction for.
        /// </summary>
        /// <returns>The roles, in no particular order.</returns>
        public List<ConstructionRole> GetConstructionRoles()
        {
            return [.. constructions.Keys];
        }

        /// <summary>
        /// Determines whether the set applies to the specified date: on or after <see cref="StartDate"/> and before <see cref="EndDate"/>, compared by calendar date.
        /// </summary>
        /// <param name="dateTimeOffset">The design date (<see cref="ConstructionFlavour.Regulation"/>) or the date built (<see cref="ConstructionFlavour.TypicalAsBuilt"/>).</param>
        /// <returns>True if the set applies to the date; otherwise, false.</returns>
        public bool Includes(DateTimeOffset dateTimeOffset)
        {
            if (dateTimeOffset.Date < startDate.Date)
            {
                return false;
            }

            return endDate is not DateTimeOffset endDate_Temp || dateTimeOffset.Date < endDate_Temp.Date;
        }

        /// <summary>
        /// Sets the construction used for the specified role, replacing any previous one. The construction itself belongs in the <see cref="ConstructionLibrary.ConstructionRelationCluster"/> of the library holding the set.
        /// </summary>
        /// <param name="constructionRole">The role.</param>
        /// <param name="construction">The construction. This value can be null.</param>
        /// <returns>True if the construction was set; false if it is null or the role is <see cref="ConstructionRole.Undefined"/>.</returns>
        public bool SetConstruction(ConstructionRole constructionRole, IConstruction? construction)
        {
            if (construction is null || constructionRole == ConstructionRole.Undefined)
            {
                return false;
            }

            constructions[constructionRole] = new GuidReference(construction);
            return true;
        }
    }
}
