using DiGi.Analytical.Building.Regulation.Enums;
using DiGi.Analytical.Building.Regulation.Interfaces;
using DiGi.Core.Classes;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Analytical.Building.Regulation.Classes
{
    /// <summary>
    /// Represents the inputs of a TABULA typology building that are not constructions: the frame area fraction, the thermal bridging surcharge, the floor boundary and the factors the TABULA energy balance applies to them (DiGi-Organization/DiGi.Analytical#17).
    /// <para>A <see cref="ConstructionFlavour.TypicalAsBuilt"/> <see cref="ConstructionSet"/> carries one, read from the building's TABULA record, so that a heat-demand calculation (DiGi-Organization/DiGi.Analytical#10) applies them once. The floor construction of a set carries the construction's own U: the resistance of an unheated cellar is <see cref="AdditionalFloorResistance"/>, not part of that U.</para>
    /// </summary>
    public class TypologyData : SerializableObject, IRegulationSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(AdditionalFloorResistance))]
        private readonly double additionalFloorResistance;

        [JsonInclude, JsonPropertyName(nameof(AttachedNeighbours))]
        private readonly int attachedNeighbours;

        [JsonInclude, JsonPropertyName(nameof(FloorBoundary))]
        private readonly FloorBoundary floorBoundary;

        [JsonInclude, JsonPropertyName(nameof(FloorTemperatureReductionFactor))]
        private readonly double floorTemperatureReductionFactor;

        [JsonInclude, JsonPropertyName(nameof(FrameAreaFraction))]
        private readonly double frameAreaFraction;

        [JsonInclude, JsonPropertyName(nameof(NonPerpendicularIncidenceFactor))]
        private readonly double nonPerpendicularIncidenceFactor;

        [JsonInclude, JsonPropertyName(nameof(RoofType))]
        private readonly RoofType roofType;

        [JsonInclude, JsonPropertyName(nameof(Source))]
        private readonly string? source;

        [JsonInclude, JsonPropertyName(nameof(ThermalBridgingSurcharge))]
        private readonly double thermalBridgingSurcharge;

        /// <summary>
        /// Initializes a new instance of the <see cref="TypologyData"/> class.
        /// </summary>
        /// <param name="frameAreaFraction">The frame area fraction of the windows, F_f [-].</param>
        /// <param name="thermalBridgingSurcharge">The thermal bridging surcharge on the envelope U-values, ΔU_tb [W/(m2K)].</param>
        /// <param name="floorBoundary">What the lowest floor borders.</param>
        /// <param name="additionalFloorResistance">The additional thermal resistance of the unheated space below the floor, R [m2K/W]; 0 on soil.</param>
        /// <param name="roofType">The roof type.</param>
        /// <param name="floorTemperatureReductionFactor">The temperature reduction factor of the floor's heat transfer, b_tr,floor [-].</param>
        /// <param name="nonPerpendicularIncidenceFactor">The correction of the window solar transmittance for non-perpendicular incidence, F_w [-].</param>
        /// <param name="attachedNeighbours">The number of attached neighbouring buildings: TABULA B_Alone is 0, B_N1 is 1, B_N2 is 2.</param>
        /// <param name="source">The TABULA record the values were read from. This value can be null.</param>
        public TypologyData(
            double frameAreaFraction,
            double thermalBridgingSurcharge,
            FloorBoundary floorBoundary,
            double additionalFloorResistance,
            RoofType roofType,
            double floorTemperatureReductionFactor,
            double nonPerpendicularIncidenceFactor,
            int attachedNeighbours,
            string? source)
        {
            this.frameAreaFraction = frameAreaFraction;
            this.thermalBridgingSurcharge = thermalBridgingSurcharge;
            this.floorBoundary = floorBoundary;
            this.additionalFloorResistance = additionalFloorResistance;
            this.roofType = roofType;
            this.floorTemperatureReductionFactor = floorTemperatureReductionFactor;
            this.nonPerpendicularIncidenceFactor = nonPerpendicularIncidenceFactor;
            this.attachedNeighbours = attachedNeighbours;
            this.source = source;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TypologyData"/> class by copying an existing instance.
        /// </summary>
        /// <param name="typologyData">The <see cref="TypologyData"/> to copy. This value can be null.</param>
        public TypologyData(TypologyData? typologyData)
            : base(typologyData)
        {
            if (typologyData is not null)
            {
                frameAreaFraction = typologyData.frameAreaFraction;
                thermalBridgingSurcharge = typologyData.thermalBridgingSurcharge;
                floorBoundary = typologyData.floorBoundary;
                additionalFloorResistance = typologyData.additionalFloorResistance;
                roofType = typologyData.roofType;
                floorTemperatureReductionFactor = typologyData.floorTemperatureReductionFactor;
                nonPerpendicularIncidenceFactor = typologyData.nonPerpendicularIncidenceFactor;
                attachedNeighbours = typologyData.attachedNeighbours;
                source = typologyData.source;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TypologyData"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the data. This value can be null.</param>
        public TypologyData(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the additional thermal resistance of the unheated space below the floor, R [m2K/W]; 0 on soil.
        /// </summary>
        [JsonIgnore]
        public double AdditionalFloorResistance
        {
            get
            {
                return additionalFloorResistance;
            }
        }

        /// <summary>
        /// Gets the number of attached neighbouring buildings: TABULA B_Alone is 0, B_N1 is 1, B_N2 is 2.
        /// </summary>
        [JsonIgnore]
        public int AttachedNeighbours
        {
            get
            {
                return attachedNeighbours;
            }
        }

        /// <summary>
        /// Gets what the lowest floor borders.
        /// </summary>
        [JsonIgnore]
        public FloorBoundary FloorBoundary
        {
            get
            {
                return floorBoundary;
            }
        }

        /// <summary>
        /// Gets the temperature reduction factor of the floor's heat transfer, b_tr,floor [-].
        /// </summary>
        [JsonIgnore]
        public double FloorTemperatureReductionFactor
        {
            get
            {
                return floorTemperatureReductionFactor;
            }
        }

        /// <summary>
        /// Gets the frame area fraction of the windows, F_f [-].
        /// </summary>
        [JsonIgnore]
        public double FrameAreaFraction
        {
            get
            {
                return frameAreaFraction;
            }
        }

        /// <summary>
        /// Gets the correction of the window solar transmittance for non-perpendicular incidence, F_w [-].
        /// </summary>
        [JsonIgnore]
        public double NonPerpendicularIncidenceFactor
        {
            get
            {
                return nonPerpendicularIncidenceFactor;
            }
        }

        /// <summary>
        /// Gets the roof type.
        /// </summary>
        [JsonIgnore]
        public RoofType RoofType
        {
            get
            {
                return roofType;
            }
        }

        /// <summary>
        /// Gets the TABULA record the values were read from.
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
        /// Gets the thermal bridging surcharge on the envelope U-values, ΔU_tb [W/(m2K)].
        /// </summary>
        [JsonIgnore]
        public double ThermalBridgingSurcharge
        {
            get
            {
                return thermalBridgingSurcharge;
            }
        }
    }
}
