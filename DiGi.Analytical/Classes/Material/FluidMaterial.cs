using System.ComponentModel;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Analytical.Classes
{
    /// <summary>
    /// Represents a material with fluid-specific properties, extending the functionality of the base <see cref="Material"/> class.
    /// <para>Describes a gas filling a cavity, such as the air or argon of a glazing unit or an air layer in a wall. A property that is not set is 0 (DiGi-Organization/DiGi.Analytical#8).</para>
    /// </summary>
    public class FluidMaterial : Material
    {
        [JsonInclude, JsonPropertyName(nameof(Conductivity)), Description("Conductivity")]
        private double conductivity;

        [JsonInclude, JsonPropertyName(nameof(Density)), Description("Density")]
        private double density;

        [JsonInclude, JsonPropertyName(nameof(DynamicViscosity)), Description("Dynamic Viscosity")]
        private double dynamicViscosity;

        [JsonInclude, JsonPropertyName(nameof(SpecificHeat)), Description("Specific Heat")]
        private double specificHeat;

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
                density = fluidMaterial.density;
                dynamicViscosity = fluidMaterial.dynamicViscosity;
                specificHeat = fluidMaterial.specificHeat;
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
        /// Gets or sets the thermal conductivity of the fluid [W/(mK)].
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
        /// Gets or sets the density of the fluid [kg/m3].
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
        /// Gets or sets the dynamic viscosity of the fluid [kg/(ms)].
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
        /// Gets or sets the specific heat capacity of the fluid [J/(kgK)].
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
    }
}
