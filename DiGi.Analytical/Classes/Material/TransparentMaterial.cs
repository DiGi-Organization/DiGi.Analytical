using System.ComponentModel;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Analytical.Classes
{
    /// <summary>
    /// Represents a material that possesses transparency characteristics, extending the base functionality of a solid material.
    /// <para>The optical properties of a glazing layer are described for its two faces as a <see cref="SurfaceValue"/>: <see cref="SurfaceValue.External"/> is the front face (towards the outside), <see cref="SurfaceValue.Internal"/> the back face. A property that is not set is 0 (DiGi-Organization/DiGi.Analytical#8).</para>
    /// </summary>
    public class TransparentMaterial : SolidMaterial
    {
        [JsonInclude, JsonPropertyName(nameof(Conductivity)), Description("Conductivity")]
        private double conductivity;

        [JsonInclude, JsonPropertyName(nameof(Emissivity)), Description("Emissivity")]
        private SurfaceValue? emissivity;

        [JsonInclude, JsonPropertyName(nameof(LightReflectance)), Description("Light Reflectance")]
        private SurfaceValue? lightReflectance;

        [JsonInclude, JsonPropertyName(nameof(LightTransmittance)), Description("Light Transmittance")]
        private double lightTransmittance;

        [JsonInclude, JsonPropertyName(nameof(SolarReflectance)), Description("Solar Reflectance")]
        private SurfaceValue? solarReflectance;

        [JsonInclude, JsonPropertyName(nameof(SolarTransmittance)), Description("Solar Transmittance")]
        private double solarTransmittance;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransparentMaterial"/> class with the specified name.
        /// </summary>
        /// <param name="name">The name of the transparent material.</param>
        public TransparentMaterial(string? name)
            : base(name)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransparentMaterial"/> class using an existing <see cref="TransparentMaterial"/> instance.
        /// </summary>
        /// <param name="transparentMaterial">The source <see cref="TransparentMaterial"/> instance to copy from.</param>
        public TransparentMaterial(TransparentMaterial? transparentMaterial)
            : base(transparentMaterial)
        {
            if (transparentMaterial is not null)
            {
                conductivity = transparentMaterial.conductivity;
                solarTransmittance = transparentMaterial.solarTransmittance;
                lightTransmittance = transparentMaterial.lightTransmittance;
                solarReflectance = Core.Query.Clone(transparentMaterial.solarReflectance);
                lightReflectance = Core.Query.Clone(transparentMaterial.lightReflectance);
                emissivity = Core.Query.Clone(transparentMaterial.emissivity);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransparentMaterial"/> class using the specified JSON object.
        /// </summary>
        /// <param name="jsonObject">The <see cref="JsonObject"/> containing the data used to initialize the material properties. This value can be null.</param>
        public TransparentMaterial(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets or sets the thermal conductivity of the transparent material [W/(mK)].
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
        /// Gets or sets the hemispherical emissivity of the front (<see cref="SurfaceValue.External"/>) and back (<see cref="SurfaceValue.Internal"/>) faces.
        /// </summary>
        [JsonIgnore]
        public SurfaceValue? Emissivity
        {
            get
            {
                return emissivity;
            }

            set
            {
                emissivity = value;
            }
        }

        /// <summary>
        /// Gets or sets the light reflectance of the front (<see cref="SurfaceValue.External"/>) and back (<see cref="SurfaceValue.Internal"/>) faces.
        /// </summary>
        [JsonIgnore]
        public SurfaceValue? LightReflectance
        {
            get
            {
                return lightReflectance;
            }

            set
            {
                lightReflectance = value;
            }
        }

        /// <summary>
        /// Gets or sets the light (visible) transmittance at normal incidence, between 0 and 1.
        /// </summary>
        [JsonIgnore]
        public double LightTransmittance
        {
            get
            {
                return lightTransmittance;
            }

            set
            {
                lightTransmittance = value;
            }
        }

        /// <summary>
        /// Gets or sets the solar reflectance of the front (<see cref="SurfaceValue.External"/>) and back (<see cref="SurfaceValue.Internal"/>) faces.
        /// </summary>
        [JsonIgnore]
        public SurfaceValue? SolarReflectance
        {
            get
            {
                return solarReflectance;
            }

            set
            {
                solarReflectance = value;
            }
        }

        /// <summary>
        /// Gets or sets the solar transmittance at normal incidence, between 0 and 1.
        /// </summary>
        [JsonIgnore]
        public double SolarTransmittance
        {
            get
            {
                return solarTransmittance;
            }

            set
            {
                solarTransmittance = value;
            }
        }
    }
}
