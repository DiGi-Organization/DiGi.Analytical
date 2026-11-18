using DiGi.Analytical.Building.Energy.Interfaces;
using DiGi.Core.Classes;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Analytical.Building.Energy.Classes
{
    /// <summary>
    /// Represents the monthly climate a building's heat demand is calculated for (DiGi-Organization/DiGi.Analytical#21): the 12 monthly mean external temperatures, the design and mean annual temperatures of its climate zone, and the monthly solar irradiation on each of its external surfaces.
    /// <para>Assembled by DiGi.GIS.Analytical <c>Create.MonthlyClimate</c> from the weather file and the solar result of the building; the constructor only assigns and copies.</para>
    /// </summary>
    public class MonthlyClimate : SerializableObject, IEnergySerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(AnnualMeanExternalTemperature))]
        private readonly double annualMeanExternalTemperature = double.NaN;

        [JsonInclude, JsonPropertyName(nameof(DesignExternalTemperature))]
        private readonly double designExternalTemperature = double.NaN;

        [JsonInclude, JsonPropertyName(nameof(ExternalTemperatures))]
        private readonly List<double>? externalTemperatures;

        [JsonInclude, JsonPropertyName(nameof(Source))]
        private readonly string? source;

        [JsonInclude, JsonPropertyName(nameof(SurfaceIrradiations))]
        private readonly Dictionary<string, List<double>>? surfaceIrradiations;

        /// <summary>
        /// Initializes a new instance of the <see cref="MonthlyClimate"/> class.
        /// <para>The values are assigned and the collections copied; nothing is validated here. <c>Create.HeatDemandResult</c> rejects a climate without 12 temperatures.</para>
        /// </summary>
        /// <param name="externalTemperatures">The monthly mean external air temperatures θ_e,m, January to December [°C]. This value can be null.</param>
        /// <param name="designExternalTemperature">The design external temperature θ_e of the design heat load [°C].</param>
        /// <param name="annualMeanExternalTemperature">The mean annual external temperature θ_m,e [°C].</param>
        /// <param name="surfaceIrradiations">The monthly solar irradiation on the outward face of each external component, shading included, keyed by the component's identifier in the "D" format, January to December [kWh/m2]. This value can be null.</param>
        /// <param name="source">The sources of the values: weather file, solar result. This value can be null.</param>
        public MonthlyClimate(IEnumerable<double>? externalTemperatures, double designExternalTemperature, double annualMeanExternalTemperature, IDictionary<string, List<double>>? surfaceIrradiations, string? source)
            : base()
        {
            this.externalTemperatures = externalTemperatures is null ? null : [.. externalTemperatures];
            this.designExternalTemperature = designExternalTemperature;
            this.annualMeanExternalTemperature = annualMeanExternalTemperature;
            this.source = source;

            if (surfaceIrradiations is not null)
            {
                this.surfaceIrradiations = [];
                foreach (KeyValuePair<string, List<double>> keyValuePair in surfaceIrradiations)
                {
                    if (keyValuePair.Value is not null)
                    {
                        this.surfaceIrradiations[keyValuePair.Key] = [.. keyValuePair.Value];
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MonthlyClimate"/> class by copying an existing instance.
        /// </summary>
        /// <param name="monthlyClimate">The <see cref="MonthlyClimate"/> to copy. This value can be null.</param>
        public MonthlyClimate(MonthlyClimate? monthlyClimate)
            : base(monthlyClimate)
        {
            if (monthlyClimate is not null)
            {
                externalTemperatures = monthlyClimate.externalTemperatures is null ? null : [.. monthlyClimate.externalTemperatures];
                designExternalTemperature = monthlyClimate.designExternalTemperature;
                annualMeanExternalTemperature = monthlyClimate.annualMeanExternalTemperature;
                source = monthlyClimate.source;

                if (monthlyClimate.surfaceIrradiations is not null)
                {
                    surfaceIrradiations = [];
                    foreach (KeyValuePair<string, List<double>> keyValuePair in monthlyClimate.surfaceIrradiations)
                    {
                        surfaceIrradiations[keyValuePair.Key] = [.. keyValuePair.Value];
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MonthlyClimate"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the climate data. This value can be null.</param>
        public MonthlyClimate(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the mean annual external temperature θ_m,e [°C].
        /// </summary>
        [JsonIgnore]
        public double AnnualMeanExternalTemperature
        {
            get
            {
                return annualMeanExternalTemperature;
            }
        }

        /// <summary>
        /// Gets the design external temperature θ_e of the design heat load [°C].
        /// </summary>
        [JsonIgnore]
        public double DesignExternalTemperature
        {
            get
            {
                return designExternalTemperature;
            }
        }

        /// <summary>
        /// Gets a copy of the monthly mean external air temperatures θ_e,m, January to December [°C].
        /// </summary>
        [JsonIgnore]
        public List<double>? ExternalTemperatures
        {
            get
            {
                return externalTemperatures is null ? null : [.. externalTemperatures];
            }
        }

        /// <summary>
        /// Gets the sources of the values.
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
        /// Gets a copy of the monthly solar irradiation on the outward face of each external component, keyed by the component's identifier in the "D" format, January to December [kWh/m2].
        /// </summary>
        [JsonIgnore]
        public Dictionary<string, List<double>>? SurfaceIrradiations
        {
            get
            {
                if (surfaceIrradiations is null)
                {
                    return null;
                }

                Dictionary<string, List<double>> result = [];
                foreach (KeyValuePair<string, List<double>> keyValuePair in surfaceIrradiations)
                {
                    result[keyValuePair.Key] = [.. keyValuePair.Value];
                }

                return result;
            }
        }
    }
}
