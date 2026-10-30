using System.ComponentModel;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Analytical.Classes
{
    /// <summary>
    /// Represents a material with fluid-specific properties, extending the functionality of the base <see cref="Material"/> class.
    /// <para>Describes a gas filling a cavity, such as the air or argon of a glazing unit or an air layer in a wall. A property that is not set is 0 (DiGi-Organization/DiGi.Analytical#8).</para>
    /// <para><see cref="Conductivity"/>, <see cref="Density"/>, <see cref="DynamicViscosity"/> and <see cref="SpecificHeat"/> are the values at <see cref="ReferenceTemperature"/> (283 K, the mean temperature of the EN 673 glazing calculation). For the temperature-dependent properties of ISO 15099 (and EnergyPlus WindowMaterial:Gas, property = A + B·T), the temperature coefficients give the change per kelvin: value(T) = value + coefficient · (T − <see cref="ReferenceTemperature"/>). A gas mixture is built with <c>Create.FluidMaterial</c>.</para>
    /// </summary>
    public class FluidMaterial : Material
    {
        /// <summary>
        /// The temperature [K] the conductivity, density, dynamic viscosity and specific heat of a fluid material are given at: 283 K, the mean temperature of the EN 673 glazing calculation.
        /// </summary>
        public const double ReferenceTemperature = 283.0;

        [JsonInclude, JsonPropertyName(nameof(Conductivity)), Description("Conductivity")]
        private double conductivity;

        [JsonInclude, JsonPropertyName(nameof(ConductivityTemperatureCoefficient)), Description("Conductivity Temperature Coefficient")]
        private double conductivityTemperatureCoefficient;

        [JsonInclude, JsonPropertyName(nameof(Density)), Description("Density")]
        private double density;

        [JsonInclude, JsonPropertyName(nameof(DynamicViscosity)), Description("Dynamic Viscosity")]
        private double dynamicViscosity;

        [JsonInclude, JsonPropertyName(nameof(DynamicViscosityTemperatureCoefficient)), Description("Dynamic Viscosity Temperature Coefficient")]
        private double dynamicViscosityTemperatureCoefficient;

        [JsonInclude, JsonPropertyName(nameof(MolarMass)), Description("Molar Mass")]
        private double molarMass;

        [JsonInclude, JsonPropertyName(nameof(SpecificHeat)), Description("Specific Heat")]
        private double specificHeat;

        [JsonInclude, JsonPropertyName(nameof(SpecificHeatRatio)), Description("Specific Heat Ratio")]
        private double specificHeatRatio;

        [JsonInclude, JsonPropertyName(nameof(SpecificHeatTemperatureCoefficient)), Description("Specific Heat Temperature Coefficient")]
        private double specificHeatTemperatureCoefficient;

        /// <summary>
        /// Initializes a new instance of the <see cref="FluidMaterial"/> class with the specified name.
        /// </summary>
        /// <param name="name">The name of the fluid material. This value can be null.</param>
        public FluidMaterial(string? name)
            : base(name)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FluidMaterial"/> class using another <see cref="FluidMaterial"/> instance.
        /// </summary>
        /// <param name="fluidMaterial">The source <see cref="FluidMaterial"/> object to copy from.</param>
        public FluidMaterial(FluidMaterial? fluidMaterial)
            : base(fluidMaterial)
        {
            if (fluidMaterial is not null)
            {
                conductivity = fluidMaterial.conductivity;
                conductivityTemperatureCoefficient = fluidMaterial.conductivityTemperatureCoefficient;
                density = fluidMaterial.density;
                dynamicViscosity = fluidMaterial.dynamicViscosity;
                dynamicViscosityTemperatureCoefficient = fluidMaterial.dynamicViscosityTemperatureCoefficient;
                molarMass = fluidMaterial.molarMass;
                specificHeat = fluidMaterial.specificHeat;
                specificHeatRatio = fluidMaterial.specificHeatRatio;
                specificHeatTemperatureCoefficient = fluidMaterial.specificHeatTemperatureCoefficient;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FluidMaterial"/> class using the specified JSON object.
        /// </summary>
        /// <param name="jsonObject">The <see cref="JsonObject"/> containing the material properties to initialize the instance.</param>
        public FluidMaterial(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets or sets the thermal conductivity of the fluid at <see cref="ReferenceTemperature"/> [W/(mK)].
        /// </summary>
        [JsonIgnore]
        public double Conductivity
        {
            get
            {
                return conductivity;
            }

            set
            {
                conductivity = value;
            }
        }

        /// <summary>
        /// Gets or sets the change of the thermal conductivity per kelvin [W/(mK²)] (ISO 15099).
        /// </summary>
        [JsonIgnore]
        public double ConductivityTemperatureCoefficient
        {
            get
            {
                return conductivityTemperatureCoefficient;
            }

            set
            {
                conductivityTemperatureCoefficient = value;
            }
        }

        /// <summary>
        /// Gets or sets the density of the fluid at <see cref="ReferenceTemperature"/> and atmospheric pressure [kg/m3].
        /// </summary>
        [JsonIgnore]
        public double Density
        {
            get
            {
                return density;
            }

            set
            {
                density = value;
            }
        }

        /// <summary>
        /// Gets or sets the dynamic viscosity of the fluid at <see cref="ReferenceTemperature"/> [kg/(ms)].
        /// </summary>
        [JsonIgnore]
        public double DynamicViscosity
        {
            get
            {
                return dynamicViscosity;
            }

            set
            {
                dynamicViscosity = value;
            }
        }

        /// <summary>
        /// Gets or sets the change of the dynamic viscosity per kelvin [kg/(msK)] (ISO 15099).
        /// </summary>
        [JsonIgnore]
        public double DynamicViscosityTemperatureCoefficient
        {
            get
            {
                return dynamicViscosityTemperatureCoefficient;
            }

            set
            {
                dynamicViscosityTemperatureCoefficient = value;
            }
        }

        /// <summary>
        /// Gets or sets the molar mass of the fluid [kg/kmol] (ISO 15099; 28.97 for air, 39.948 for argon).
        /// </summary>
        [JsonIgnore]
        public double MolarMass
        {
            get
            {
                return molarMass;
            }

            set
            {
                molarMass = value;
            }
        }

        /// <summary>
        /// Gets or sets the specific heat capacity of the fluid at <see cref="ReferenceTemperature"/> [J/(kgK)].
        /// </summary>
        [JsonIgnore]
        public double SpecificHeat
        {
            get
            {
                return specificHeat;
            }

            set
            {
                specificHeat = value;
            }
        }

        /// <summary>
        /// Gets or sets the ratio of the specific heats cp/cv of the fluid [-] (ISO 15099; 1.4 for air).
        /// </summary>
        [JsonIgnore]
        public double SpecificHeatRatio
        {
            get
            {
                return specificHeatRatio;
            }

            set
            {
                specificHeatRatio = value;
            }
        }

        /// <summary>
        /// Gets or sets the change of the specific heat capacity per kelvin [J/(kgK²)] (ISO 15099).
        /// </summary>
        [JsonIgnore]
        public double SpecificHeatTemperatureCoefficient
        {
            get
            {
                return specificHeatTemperatureCoefficient;
            }

            set
            {
                specificHeatTemperatureCoefficient = value;
            }
        }
    }
}
