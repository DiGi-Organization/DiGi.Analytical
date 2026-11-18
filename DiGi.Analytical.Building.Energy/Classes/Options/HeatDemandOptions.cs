using DiGi.Analytical.Building.Energy.Interfaces;
using DiGi.Core.Classes;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Analytical.Building.Energy.Classes
{
    /// <summary>
    /// Holds every numeric default of the monthly heat demand, so nothing is hard-coded in <c>Create.HeatDemandResult</c> (DiGi-Organization/DiGi.Analytical#21).
    /// <para>The defaults are <see cref="Constants.Default"/>, each with its source. The fallbacks (F_w, ΔU_tb, F_f) apply only where the building's TABULA typology data gives no value.</para>
    /// </summary>
    public class HeatDemandOptions : SerializableOptions, IEnergySerializableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HeatDemandOptions"/> class with the defaults of <see cref="Constants.Default"/>.
        /// </summary>
        public HeatDemandOptions()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HeatDemandOptions"/> class by copying another instance.
        /// </summary>
        /// <param name="heatDemandOptions">The options to copy. This value can be null.</param>
        public HeatDemandOptions(HeatDemandOptions? heatDemandOptions)
            : base(heatDemandOptions)
        {
            if (heatDemandOptions is not null)
            {
                UtilisationNumericalParameter = heatDemandOptions.UtilisationNumericalParameter;
                UtilisationReferenceTimeConstant = heatDemandOptions.UtilisationReferenceTimeConstant;
                GroundThermalConductivity = heatDemandOptions.GroundThermalConductivity;
                GroundWallThickness = heatDemandOptions.GroundWallThickness;
                OpaqueSolarAbsorptance = heatDemandOptions.OpaqueSolarAbsorptance;
                ExternalEmissivity = heatDemandOptions.ExternalEmissivity;
                SkyTemperatureDifference = heatDemandOptions.SkyTemperatureDifference;
                WallSkyFormFactor = heatDemandOptions.WallSkyFormFactor;
                RoofSkyFormFactor = heatDemandOptions.RoofSkyFormFactor;
                NonPerpendicularIncidenceFactor = heatDemandOptions.NonPerpendicularIncidenceFactor;
                ThermalBridgingSurcharge = heatDemandOptions.ThermalBridgingSurcharge;
                FrameAreaFraction = heatDemandOptions.FrameAreaFraction;
                InternalHeatCapacityMaximumThickness = heatDemandOptions.InternalHeatCapacityMaximumThickness;
                InsulationThermalConductivity = heatDemandOptions.InsulationThermalConductivity;
                IncludeOpaqueSolarGains = heatDemandOptions.IncludeOpaqueSolarGains;
                IncludeSkyRadiation = heatDemandOptions.IncludeSkyRadiation;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HeatDemandOptions"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the options. This value can be null.</param>
        public HeatDemandOptions(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets or sets the thickness of the external walls w [m] used in the equivalent thickness of a ground floor when no external wall has layers.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(GroundWallThickness))]
        public double GroundWallThickness { get; set; } = Constants.Default.GroundWallThickness;

        /// <summary>
        /// Gets or sets the thermal conductivity of the ground λ_g [W/(mK)].
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(GroundThermalConductivity))]
        public double GroundThermalConductivity { get; set; } = Constants.Default.GroundThermalConductivity;

        /// <summary>
        /// Gets or sets the emissivity ε of the external surfaces for thermal radiation; the external radiative heat transfer coefficient is h_r = 5·ε [W/(m2K)].
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(ExternalEmissivity))]
        public double ExternalEmissivity { get; set; } = Constants.Default.ExternalEmissivity;

        /// <summary>
        /// Gets or sets the fallback frame area fraction F_f [-] of an opening whose construction has no panes, used when the typology data gives none.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(FrameAreaFraction))]
        public double FrameAreaFraction { get; set; } = Constants.Default.FrameAreaFraction;

        /// <summary>
        /// Gets or sets a value indicating whether the solar gains of opaque elements, α·R_se·U·A·I, are included.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(IncludeOpaqueSolarGains))]
        public bool IncludeOpaqueSolarGains { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether the extra heat flow by thermal radiation to the sky is subtracted from the solar gains. The source allows a national choice to ignore it.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(IncludeSkyRadiation))]
        public bool IncludeSkyRadiation { get; set; } = true;

        /// <summary>
        /// Gets or sets the thermal conductivity [W/(mK)] at or below which a layer ends the effective thickness of the internal heat capacity.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(InsulationThermalConductivity))]
        public double InsulationThermalConductivity { get; set; } = Constants.Default.InsulationThermalConductivity;

        /// <summary>
        /// Gets or sets the maximum thickness [m], from each face, counted in the internal heat capacity of a building element.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(InternalHeatCapacityMaximumThickness))]
        public double InternalHeatCapacityMaximumThickness { get; set; } = Constants.Default.InternalHeatCapacityMaximumThickness;

        /// <summary>
        /// Gets or sets the fallback correction for non-perpendicular incidence F_w [-], used when the typology data gives none.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(NonPerpendicularIncidenceFactor))]
        public double NonPerpendicularIncidenceFactor { get; set; } = Constants.Default.NonPerpendicularIncidenceFactor;

        /// <summary>
        /// Gets or sets the absorption coefficient for solar radiation α [-] of the opaque external surfaces.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(OpaqueSolarAbsorptance))]
        public double OpaqueSolarAbsorptance { get; set; } = Constants.Default.OpaqueSolarAbsorptance;

        /// <summary>
        /// Gets or sets the form factor F_r [-] between a roof and the sky.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(RoofSkyFormFactor))]
        public double RoofSkyFormFactor { get; set; } = Constants.Default.RoofSkyFormFactor;

        /// <summary>
        /// Gets or sets the average difference Δθ_er [K] between the external air temperature and the apparent sky temperature.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(SkyTemperatureDifference))]
        public double SkyTemperatureDifference { get; set; } = Constants.Default.SkyTemperatureDifference;

        /// <summary>
        /// Gets or sets the fallback thermal bridging surcharge ΔU_tb [W/(m2K)], used when the typology data gives none.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(ThermalBridgingSurcharge))]
        public double ThermalBridgingSurcharge { get; set; } = Constants.Default.ThermalBridgingSurcharge;

        /// <summary>
        /// Gets or sets the dimensionless reference numerical parameter a_H,0 of the gain utilisation factor.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(UtilisationNumericalParameter))]
        public double UtilisationNumericalParameter { get; set; } = Constants.Default.UtilisationNumericalParameter;

        /// <summary>
        /// Gets or sets the reference time constant τ_H,0 [h] of the gain utilisation factor.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(UtilisationReferenceTimeConstant))]
        public double UtilisationReferenceTimeConstant { get; set; } = Constants.Default.UtilisationReferenceTimeConstant;

        /// <summary>
        /// Gets or sets the form factor F_r [-] between a wall and the sky.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(WallSkyFormFactor))]
        public double WallSkyFormFactor { get; set; } = Constants.Default.WallSkyFormFactor;
    }
}
