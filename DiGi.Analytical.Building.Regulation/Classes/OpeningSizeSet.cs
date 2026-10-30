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
    /// Represents the window and door sizes of the buildings of one type built in one date range, with the storey height and façade module of that stock (DiGi-Organization/DiGi.GIS.Analytical#6).
    /// <para>Keyed like a <see cref="ConstructionSet"/>: <see cref="BuildingType"/> and the range from <see cref="StartDate"/> to <see cref="EndDate"/>, looked up with the year built (no design lag). A large-panel stock has one set per prefabrication <see cref="System"/>; <see cref="DefaultSystem"/> marks the one a lookup without a system returns.</para>
    /// <para>A room use whose rooms have no window in this stock (the internal bathrooms of large-panel blocks) is listed in <see cref="WindowlessRoomUses"/>, so a missing size is a documented "none", not a gap.</para>
    /// </summary>
    public class OpeningSizeSet : SerializableObject, IRegulationSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(BuildingType))]
        private readonly BuildingType buildingType;

        [JsonInclude, JsonPropertyName(nameof(DefaultSystem))]
        private readonly bool defaultSystem;

        [JsonInclude, JsonPropertyName(nameof(EndDate))]
        private readonly DateTimeOffset? endDate;

        [JsonInclude, JsonPropertyName(nameof(FacadeModule))]
        private readonly double? facadeModule;

        [JsonInclude, JsonPropertyName("OpeningSizes")]
        private readonly List<OpeningSize> openingSizes = [];

        [JsonInclude, JsonPropertyName(nameof(Source))]
        private readonly string? source;

        [JsonInclude, JsonPropertyName(nameof(StartDate))]
        private readonly DateTimeOffset startDate;

        [JsonInclude, JsonPropertyName(nameof(StoreyHeight))]
        private readonly double storeyHeight;

        [JsonInclude, JsonPropertyName(nameof(System))]
        private readonly string? system;

        [JsonInclude, JsonPropertyName("WindowlessRoomUses")]
        private readonly List<RoomUse> windowlessRoomUses = [];

        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningSizeSet"/> class.
        /// </summary>
        /// <param name="buildingType">The building type.</param>
        /// <param name="startDate">The first date the set applies to.</param>
        /// <param name="endDate">The first date the set no longer applies to, or null when it still applies.</param>
        /// <param name="system">The large-panel system of the stock, or null.</param>
        /// <param name="defaultSystem">True when a lookup without a system returns this set among the systems of its range.</param>
        /// <param name="storeyHeight">The typical gross storey height of the stock [m].</param>
        /// <param name="facadeModule">The façade module the openings are placed on [m], or null when the stock has none.</param>
        /// <param name="openingSizes">The window and door sizes; the items are copied. This value can be null.</param>
        /// <param name="windowlessRoomUses">The room uses whose rooms have no window in this stock. This value can be null.</param>
        /// <param name="source">The sources of the storey height, the module and the choice of sizes, each with its tag. This value can be null.</param>
        public OpeningSizeSet(
            BuildingType buildingType,
            DateTimeOffset startDate,
            DateTimeOffset? endDate,
            string? system,
            bool defaultSystem,
            double storeyHeight,
            double? facadeModule,
            IEnumerable<OpeningSize>? openingSizes,
            IEnumerable<RoomUse>? windowlessRoomUses,
            string? source)
        {
            this.buildingType = buildingType;
            this.startDate = startDate;
            this.endDate = endDate;
            this.system = system;
            this.defaultSystem = defaultSystem;
            this.storeyHeight = storeyHeight;
            this.facadeModule = facadeModule;
            this.source = source;

            if (openingSizes is not null)
            {
                foreach (OpeningSize openingSize in openingSizes)
                {
                    if (Core.Query.Clone(openingSize) is OpeningSize openingSize_Clone)
                    {
                        this.openingSizes.Add(openingSize_Clone);
                    }
                }
            }

            if (windowlessRoomUses is not null)
            {
                this.windowlessRoomUses.AddRange(windowlessRoomUses);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningSizeSet"/> class by copying an existing instance.
        /// </summary>
        /// <param name="openingSizeSet">The <see cref="OpeningSizeSet"/> to copy. This value can be null.</param>
        public OpeningSizeSet(OpeningSizeSet? openingSizeSet)
            : base(openingSizeSet)
        {
            if (openingSizeSet is not null)
            {
                buildingType = openingSizeSet.buildingType;
                startDate = openingSizeSet.startDate;
                endDate = openingSizeSet.endDate;
                system = openingSizeSet.system;
                defaultSystem = openingSizeSet.defaultSystem;
                storeyHeight = openingSizeSet.storeyHeight;
                facadeModule = openingSizeSet.facadeModule;
                source = openingSizeSet.source;

                foreach (OpeningSize openingSize in openingSizeSet.openingSizes)
                {
                    if (Core.Query.Clone(openingSize) is OpeningSize openingSize_Clone)
                    {
                        openingSizes.Add(openingSize_Clone);
                    }
                }

                windowlessRoomUses.AddRange(openingSizeSet.windowlessRoomUses);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningSizeSet"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the data. This value can be null.</param>
        public OpeningSizeSet(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the building type.
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
        /// Gets a value indicating whether a lookup without a system returns this set among the systems of its range.
        /// </summary>
        [JsonIgnore]
        public bool DefaultSystem
        {
            get
            {
                return defaultSystem;
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
        /// Gets the façade module the openings are placed on [m], or null when the stock has none.
        /// </summary>
        [JsonIgnore]
        public double? FacadeModule
        {
            get
            {
                return facadeModule;
            }
        }

        /// <summary>
        /// Gets the sources of the storey height, the module and the choice of sizes, each with its tag.
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
        /// Gets the typical gross storey height of the stock [m].
        /// </summary>
        [JsonIgnore]
        public double StoreyHeight
        {
            get
            {
                return storeyHeight;
            }
        }

        /// <summary>
        /// Gets the large-panel system of the stock, or null.
        /// </summary>
        [JsonIgnore]
        public string? System
        {
            get
            {
                return system;
            }
        }

        /// <summary>
        /// Gets a copy of the room uses whose rooms have no window in this stock.
        /// </summary>
        [JsonIgnore]
        public List<RoomUse> WindowlessRoomUses
        {
            get
            {
                return [.. windowlessRoomUses];
            }
        }

        /// <summary>
        /// Gets the size of an opening of the specified kind serving a room of the specified use: the size for that use, else the size for <see cref="RoomUse.Other"/>, else the first size of that kind.
        /// </summary>
        /// <param name="openingKind">The opening kind.</param>
        /// <param name="roomUse">The room use.</param>
        /// <returns>A CLONE of the <see cref="OpeningSize"/>, or null when the set has no size of that kind or <paramref name="roomUse"/> is one of <see cref="WindowlessRoomUses"/>.</returns>
        public OpeningSize? GetOpeningSize(OpeningKind openingKind, RoomUse roomUse)
        {
            if (openingKind == OpeningKind.Window && windowlessRoomUses.Contains(roomUse))
            {
                return null;
            }

            OpeningSize? result_Other = null;
            OpeningSize? result_First = null;
            foreach (OpeningSize openingSize in openingSizes)
            {
                if (openingSize.OpeningKind != openingKind)
                {
                    continue;
                }

                if (openingSize.RoomUse == roomUse)
                {
                    return Core.Query.Clone(openingSize);
                }

                if (openingSize.RoomUse == RoomUse.Other)
                {
                    result_Other ??= openingSize;
                }

                result_First ??= openingSize;
            }

            return Core.Query.Clone(result_Other ?? result_First);
        }

        /// <summary>
        /// Gets the window and door sizes of the set.
        /// </summary>
        /// <returns>CLONES of the <see cref="OpeningSize"/>s.</returns>
        public List<OpeningSize> GetOpeningSizes()
        {
            List<OpeningSize> result = [];
            foreach (OpeningSize openingSize in openingSizes)
            {
                if (Core.Query.Clone(openingSize) is OpeningSize openingSize_Clone)
                {
                    result.Add(openingSize_Clone);
                }
            }

            return result;
        }

        /// <summary>
        /// Determines whether the set applies to the specified date: on or after <see cref="StartDate"/> and before <see cref="EndDate"/>, compared by calendar date.
        /// </summary>
        /// <param name="dateTimeOffset">The date built.</param>
        /// <returns>True if the set applies to the date; otherwise, false.</returns>
        public bool Includes(DateTimeOffset dateTimeOffset)
        {
            if (dateTimeOffset.Date < startDate.Date)
            {
                return false;
            }

            return endDate is not DateTimeOffset endDate_Temp || dateTimeOffset.Date < endDate_Temp.Date;
        }
    }
}
