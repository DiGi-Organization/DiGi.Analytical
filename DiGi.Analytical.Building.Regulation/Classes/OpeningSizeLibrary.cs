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
    /// Represents a library of <see cref="OpeningSizeSet"/>s: the window and door sizes per building type, date range and large-panel system (DiGi-Organization/DiGi.GIS.Analytical#6).
    /// </summary>
    public class OpeningSizeLibrary : GuidObject, IRegulationSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(Description))]
        private readonly string? description;

        [JsonInclude, JsonPropertyName(nameof(Name))]
        private readonly string? name;

        [JsonInclude, JsonPropertyName("OpeningSizeSets")]
        private readonly List<OpeningSizeSet> openingSizeSets = [];

        [JsonInclude, JsonPropertyName(nameof(Version))]
        private readonly string? version;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningSizeLibrary"/> class with the specified identifier, so that a library generated more than once keeps the same identity.
        /// </summary>
        /// <param name="guid">The identifier of the library.</param>
        /// <param name="name">The name of the library. This value can be null.</param>
        /// <param name="version">The version of the library. This value can be null.</param>
        /// <param name="description">The description of the library. This value can be null.</param>
        public OpeningSizeLibrary(Guid guid, string? name, string? version, string? description)
            : base(guid)
        {
            this.name = name;
            this.version = version;
            this.description = description;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningSizeLibrary"/> class by copying an existing instance.
        /// </summary>
        /// <param name="openingSizeLibrary">The <see cref="OpeningSizeLibrary"/> to copy. This value can be null.</param>
        public OpeningSizeLibrary(OpeningSizeLibrary? openingSizeLibrary)
            : base(openingSizeLibrary)
        {
            if (openingSizeLibrary is not null)
            {
                name = openingSizeLibrary.name;
                version = openingSizeLibrary.version;
                description = openingSizeLibrary.description;

                foreach (OpeningSizeSet openingSizeSet in openingSizeLibrary.openingSizeSets)
                {
                    if (Core.Query.Clone(openingSizeSet) is OpeningSizeSet openingSizeSet_Clone)
                    {
                        openingSizeSets.Add(openingSizeSet_Clone);
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningSizeLibrary"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the data. This value can be null.</param>
        public OpeningSizeLibrary(JsonObject? jsonObject)
            : base(jsonObject)
        {
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
        /// Adds an opening size set to the library.
        /// </summary>
        /// <param name="openingSizeSet">The opening size set. This value can be null.</param>
        /// <returns>True if the set was added; false if it is null.</returns>
        public bool Add(OpeningSizeSet? openingSizeSet)
        {
            if (openingSizeSet is null)
            {
                return false;
            }

            openingSizeSets.Add(openingSizeSet);
            return true;
        }

        /// <summary>
        /// Gets the opening size set of a building of the specified type built on the specified date.
        /// <para>Without <paramref name="system"/> the set with no system, or the <see cref="OpeningSizeSet.DefaultSystem"/> one among several systems, is returned; with a system, only the set of that system (compared ignoring case). Among sets that equally apply the one starting latest wins.</para>
        /// </summary>
        /// <param name="dateTimeOffset">The date built - 1 January of the year built when only the year is known.</param>
        /// <param name="buildingType">The building type.</param>
        /// <param name="system">The large-panel system, or null for the default.</param>
        /// <returns>A CLONE of the <see cref="OpeningSizeSet"/>, or null when none applies.</returns>
        public OpeningSizeSet? GetOpeningSizeSet(DateTimeOffset dateTimeOffset, BuildingType buildingType, string? system = null)
        {
            OpeningSizeSet? result = null;
            foreach (OpeningSizeSet openingSizeSet in openingSizeSets)
            {
                if (openingSizeSet.BuildingType != buildingType || !openingSizeSet.Includes(dateTimeOffset))
                {
                    continue;
                }

                if (system is null)
                {
                    if (openingSizeSet.System is not null && !openingSizeSet.DefaultSystem)
                    {
                        continue;
                    }
                }
                else if (!string.Equals(openingSizeSet.System, system, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                if (result is null || openingSizeSet.StartDate > result.StartDate)
                {
                    result = openingSizeSet;
                }
            }

            return Core.Query.Clone(result);
        }

        /// <summary>
        /// Gets the opening size sets of the library.
        /// </summary>
        /// <returns>CLONES of the library's <see cref="OpeningSizeSet"/>s.</returns>
        public List<OpeningSizeSet> GetOpeningSizeSets()
        {
            List<OpeningSizeSet> result = [];
            foreach (OpeningSizeSet openingSizeSet in openingSizeSets)
            {
                if (Core.Query.Clone(openingSizeSet) is OpeningSizeSet openingSizeSet_Clone)
                {
                    result.Add(openingSizeSet_Clone);
                }
            }

            return result;
        }
    }
}
