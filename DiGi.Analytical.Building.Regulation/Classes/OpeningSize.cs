using DiGi.Analytical.Building.Regulation.Enums;
using DiGi.Analytical.Building.Regulation.Interfaces;
using DiGi.Core.Classes;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Analytical.Building.Regulation.Classes
{
    /// <summary>
    /// Represents the size and glazing layout of one window or door of a stock (DiGi-Organization/DiGi.GIS.Analytical#6).
    /// <para><see cref="Width"/> and <see cref="Height"/> are the frame outline, which becomes the outline of the window or door construction, from (0, 0) at its lower left corner. The glazing is a regular layout: a uniform <see cref="FrameWidth"/> around <see cref="Columns"/> sashes or leaves separated by dividers of <see cref="DividerWidth"/>, and optionally a top light of <see cref="TopLightHeight"/> above a transom of the divider width. <see cref="Query.Panes(OpeningSize?)"/> derives the pane rectangles; a uniform frame and divider width converts exactly to the frame-and-divider description of EnergyPlus.</para>
    /// </summary>
    public class OpeningSize : SerializableObject, IRegulationSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(Columns))]
        private readonly int columns;

        [JsonInclude, JsonPropertyName(nameof(DividerWidth))]
        private readonly double dividerWidth;

        [JsonInclude, JsonPropertyName(nameof(FrameWidth))]
        private readonly double frameWidth;

        [JsonInclude, JsonPropertyName(nameof(Glazed))]
        private readonly bool glazed;

        [JsonInclude, JsonPropertyName(nameof(Height))]
        private readonly double height;

        [JsonInclude, JsonPropertyName(nameof(OpeningKind))]
        private readonly OpeningKind openingKind;

        [JsonInclude, JsonPropertyName(nameof(RoomUse))]
        private readonly RoomUse roomUse;

        [JsonInclude, JsonPropertyName(nameof(SillHeight))]
        private readonly double? sillHeight;

        [JsonInclude, JsonPropertyName(nameof(Source))]
        private readonly string? source;

        [JsonInclude, JsonPropertyName(nameof(TopLightHeight))]
        private readonly double? topLightHeight;

        [JsonInclude, JsonPropertyName(nameof(Width))]
        private readonly double width;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningSize"/> class.
        /// </summary>
        /// <param name="openingKind">The opening kind.</param>
        /// <param name="roomUse">The use of the room the opening serves.</param>
        /// <param name="width">The width of the frame outline [m].</param>
        /// <param name="height">The height of the frame outline [m].</param>
        /// <param name="sillHeight">The height of the bottom of the frame above the floor [m]; null for doors and balcony doors.</param>
        /// <param name="glazed">True when the opening is glazed, so <see cref="Query.Panes(OpeningSize?)"/> returns panes.</param>
        /// <param name="columns">The number of sashes or leaves side by side.</param>
        /// <param name="frameWidth">The uniform face width of the frame [m].</param>
        /// <param name="dividerWidth">The face width of a mullion between sashes and of the transom below a top light [m].</param>
        /// <param name="topLightHeight">The height of the top light above the transom, frame excluded [m]; null when there is none.</param>
        /// <param name="source">The sources of the values, each with its tag. This value can be null.</param>
        public OpeningSize(
            OpeningKind openingKind,
            RoomUse roomUse,
            double width,
            double height,
            double? sillHeight,
            bool glazed,
            int columns,
            double frameWidth,
            double dividerWidth,
            double? topLightHeight,
            string? source)
        {
            this.openingKind = openingKind;
            this.roomUse = roomUse;
            this.width = width;
            this.height = height;
            this.sillHeight = sillHeight;
            this.glazed = glazed;
            this.columns = columns;
            this.frameWidth = frameWidth;
            this.dividerWidth = dividerWidth;
            this.topLightHeight = topLightHeight;
            this.source = source;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningSize"/> class by copying an existing instance.
        /// </summary>
        /// <param name="openingSize">The <see cref="OpeningSize"/> to copy. This value can be null.</param>
        public OpeningSize(OpeningSize? openingSize)
            : base(openingSize)
        {
            if (openingSize is not null)
            {
                openingKind = openingSize.openingKind;
                roomUse = openingSize.roomUse;
                width = openingSize.width;
                height = openingSize.height;
                sillHeight = openingSize.sillHeight;
                glazed = openingSize.glazed;
                columns = openingSize.columns;
                frameWidth = openingSize.frameWidth;
                dividerWidth = openingSize.dividerWidth;
                topLightHeight = openingSize.topLightHeight;
                source = openingSize.source;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningSize"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the data. This value can be null.</param>
        public OpeningSize(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the number of sashes or leaves side by side.
        /// </summary>
        [JsonIgnore]
        public int Columns
        {
            get
            {
                return columns;
            }
        }

        /// <summary>
        /// Gets the face width of a mullion between sashes and of the transom below a top light [m].
        /// </summary>
        [JsonIgnore]
        public double DividerWidth
        {
            get
            {
                return dividerWidth;
            }
        }

        /// <summary>
        /// Gets the uniform face width of the frame [m].
        /// </summary>
        [JsonIgnore]
        public double FrameWidth
        {
            get
            {
                return frameWidth;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the opening is glazed.
        /// </summary>
        [JsonIgnore]
        public bool Glazed
        {
            get
            {
                return glazed;
            }
        }

        /// <summary>
        /// Gets the height of the frame outline [m].
        /// </summary>
        [JsonIgnore]
        public double Height
        {
            get
            {
                return height;
            }
        }

        /// <summary>
        /// Gets the opening kind.
        /// </summary>
        [JsonIgnore]
        public OpeningKind OpeningKind
        {
            get
            {
                return openingKind;
            }
        }

        /// <summary>
        /// Gets the use of the room the opening serves.
        /// </summary>
        [JsonIgnore]
        public RoomUse RoomUse
        {
            get
            {
                return roomUse;
            }
        }

        /// <summary>
        /// Gets the height of the bottom of the frame above the floor [m], or null for doors and balcony doors.
        /// </summary>
        [JsonIgnore]
        public double? SillHeight
        {
            get
            {
                return sillHeight;
            }
        }

        /// <summary>
        /// Gets the sources of the values, each with its tag.
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
        /// Gets the height of the top light above the transom, frame excluded [m], or null when there is none.
        /// </summary>
        [JsonIgnore]
        public double? TopLightHeight
        {
            get
            {
                return topLightHeight;
            }
        }

        /// <summary>
        /// Gets the width of the frame outline [m].
        /// </summary>
        [JsonIgnore]
        public double Width
        {
            get
            {
                return width;
            }
        }
    }
}
