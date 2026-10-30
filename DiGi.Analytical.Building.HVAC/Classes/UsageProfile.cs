using DiGi.Analytical.Building.HVAC.Enums;
using DiGi.Analytical.Building.HVAC.Interfaces;
using DiGi.Core.Classes;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Analytical.Building.HVAC.Classes
{
    /// <summary>
    /// Represents the standard use of a building of one usage type: heating set-point, internal gains, outside airflow and hot water per area, with the source of every value (DiGi-Organization/DiGi.Analytical#9).
    /// <para>Created by <c>Create.UsageProfile</c>, which holds the data and does the calculation; the constructor only assigns and copies. <c>Create.InternalCondition</c> turns a usage profile into an <see cref="Building.Classes.InternalCondition"/> for a building.</para>
    /// <para>Every value has a source tag in <see cref="Sources"/>, keyed by the property name: <c>PL-376</c> (Dz.U. 2015 poz. 376, Annex 1), <c>PL-WT</c> (Dz.U. 2022 poz. 1225, § 134), <c>ASHRAE-90.1</c> (ASHRAE Standard 90.1-1989 and addenda, via the Seattle Energy Code 2018, Appendix B) or <c>DEFAULT</c> (uncited, to be replaced), each followed by the table it comes from.</para>
    /// </summary>
    public class UsageProfile : SerializableObject, IHVACObject
    {
        [JsonInclude, JsonPropertyName(nameof(Beta))]
        private readonly double beta = double.NaN;

        [JsonInclude, JsonPropertyName(nameof(DomesticHotWater))]
        private readonly double domesticHotWater = double.NaN;

        [JsonInclude, JsonPropertyName(nameof(DomesticHotWaterCorrection))]
        private readonly double domesticHotWaterCorrection = double.NaN;

        [JsonInclude, JsonPropertyName(nameof(FloorAreaPerPerson))]
        private readonly double floorAreaPerPerson = double.NaN;

        [JsonInclude, JsonPropertyName(nameof(HeatingSetPoint))]
        private readonly double heatingSetPoint = double.NaN;

        [JsonInclude, JsonPropertyName(nameof(InternalHeatGain))]
        private readonly double internalHeatGain = double.NaN;

        [JsonInclude, JsonPropertyName(nameof(InternalHeatGainProfile))]
        private readonly List<double>? internalHeatGainProfile;

        [JsonInclude, JsonPropertyName(nameof(OutsideAirPerArea))]
        private readonly double outsideAirPerArea = double.NaN;

        [JsonInclude, JsonPropertyName(nameof(PersonGain))]
        private readonly double personGain = double.NaN;

        [JsonInclude, JsonPropertyName(nameof(PersonLatentGain))]
        private readonly double personLatentGain = double.NaN;

        [JsonInclude, JsonPropertyName(nameof(Source))]
        private readonly string? source;

        [JsonInclude, JsonPropertyName(nameof(Sources))]
        private readonly Dictionary<string, string>? sources;

        [JsonInclude, JsonPropertyName(nameof(UsageType))]
        private readonly UsageType usageType;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsageProfile"/> class.
        /// <para>The values are assigned as given and the profile and the sources are copied; <c>Create.UsageProfile</c> computes them.</para>
        /// </summary>
        /// <param name="usageType">The usage type.</param>
        /// <param name="heatingSetPoint">The heating set-point [°C].</param>
        /// <param name="internalHeatGain">The mean internal heat gain q_int [W/m2].</param>
        /// <param name="internalHeatGainProfile">The weekly profile of the internal heat gain [W/m2], 168 values from Monday 0:00, whose mean is <paramref name="internalHeatGain"/>; null when the gain is constant.</param>
        /// <param name="outsideAirPerArea">The basic outside airflow during use [l/(s m2)].</param>
        /// <param name="domesticHotWater">The unit daily hot water demand V_Wi [dm3/(m2 d)].</param>
        /// <param name="domesticHotWaterCorrection">The correction for breaks in hot water use k_R [-].</param>
        /// <param name="floorAreaPerPerson">The floor area per person of the standard occupancy [m2/person].</param>
        /// <param name="personGain">The sensible heat gain per person [W/person].</param>
        /// <param name="personLatentGain">The latent heat gain per person [W/person].</param>
        /// <param name="beta">The share of the time the building is in use, β [-]; NaN when the internal gain does not depend on it.</param>
        /// <param name="sources">The source tag of every value, keyed by property name. This value can be null.</param>
        /// <param name="source">The sources as text. This value can be null.</param>
        public UsageProfile(
            UsageType usageType,
            double heatingSetPoint,
            double internalHeatGain,
            IEnumerable<double>? internalHeatGainProfile,
            double outsideAirPerArea,
            double domesticHotWater,
            double domesticHotWaterCorrection,
            double floorAreaPerPerson,
            double personGain,
            double personLatentGain,
            double beta,
            IDictionary<string, string>? sources,
            string? source)
        {
            this.usageType = usageType;
            this.heatingSetPoint = heatingSetPoint;
            this.internalHeatGain = internalHeatGain;
            this.internalHeatGainProfile = internalHeatGainProfile is null ? null : [.. internalHeatGainProfile];
            this.outsideAirPerArea = outsideAirPerArea;
            this.domesticHotWater = domesticHotWater;
            this.domesticHotWaterCorrection = domesticHotWaterCorrection;
            this.floorAreaPerPerson = floorAreaPerPerson;
            this.personGain = personGain;
            this.personLatentGain = personLatentGain;
            this.beta = beta;
            this.sources = sources is null ? null : new Dictionary<string, string>(sources);
            this.source = source;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UsageProfile"/> class by copying an existing instance.
        /// </summary>
        /// <param name="usageProfile">The <see cref="UsageProfile"/> to copy. This value can be null.</param>
        public UsageProfile(UsageProfile? usageProfile)
            : base(usageProfile)
        {
            if (usageProfile is not null)
            {
                usageType = usageProfile.usageType;
                heatingSetPoint = usageProfile.heatingSetPoint;
                internalHeatGain = usageProfile.internalHeatGain;
                internalHeatGainProfile = usageProfile.internalHeatGainProfile is null ? null : [.. usageProfile.internalHeatGainProfile];
                outsideAirPerArea = usageProfile.outsideAirPerArea;
                domesticHotWater = usageProfile.domesticHotWater;
                domesticHotWaterCorrection = usageProfile.domesticHotWaterCorrection;
                floorAreaPerPerson = usageProfile.floorAreaPerPerson;
                personGain = usageProfile.personGain;
                personLatentGain = usageProfile.personLatentGain;
                beta = usageProfile.beta;
                sources = usageProfile.sources is null ? null : new Dictionary<string, string>(usageProfile.sources);
                source = usageProfile.source;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UsageProfile"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the data. This value can be null.</param>
        public UsageProfile(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the share of the time the building is in use, β [-]; NaN when the internal gain does not depend on it.
        /// </summary>
        [JsonIgnore]
        public double Beta
        {
            get
            {
                return beta;
            }
        }

        /// <summary>
        /// Gets the unit daily hot water demand V_Wi [dm3/(m2 d)].
        /// </summary>
        [JsonIgnore]
        public double DomesticHotWater
        {
            get
            {
                return domesticHotWater;
            }
        }

        /// <summary>
        /// Gets the correction for breaks in hot water use k_R [-].
        /// </summary>
        [JsonIgnore]
        public double DomesticHotWaterCorrection
        {
            get
            {
                return domesticHotWaterCorrection;
            }
        }

        /// <summary>
        /// Gets the floor area per person of the standard occupancy [m2/person] - the occupancy the per-area values stand for.
        /// </summary>
        [JsonIgnore]
        public double FloorAreaPerPerson
        {
            get
            {
                return floorAreaPerPerson;
            }
        }

        /// <summary>
        /// Gets the heating set-point [°C].
        /// </summary>
        [JsonIgnore]
        public double HeatingSetPoint
        {
            get
            {
                return heatingSetPoint;
            }
        }

        /// <summary>
        /// Gets the mean internal heat gain q_int [W/m2]: people, lighting and equipment together.
        /// </summary>
        [JsonIgnore]
        public double InternalHeatGain
        {
            get
            {
                return internalHeatGain;
            }
        }

        /// <summary>
        /// Gets a copy of the weekly profile of the internal heat gain [W/m2], 168 values from Monday 0:00 whose mean is <see cref="InternalHeatGain"/>, or null when the gain is constant.
        /// </summary>
        [JsonIgnore]
        public List<double>? InternalHeatGainProfile
        {
            get
            {
                return internalHeatGainProfile is null ? null : [.. internalHeatGainProfile];
            }
        }

        /// <summary>
        /// Gets the basic outside airflow during use [l/(s m2)].
        /// </summary>
        [JsonIgnore]
        public double OutsideAirPerArea
        {
            get
            {
                return outsideAirPerArea;
            }
        }

        /// <summary>
        /// Gets the sensible heat gain per person [W/person].
        /// </summary>
        [JsonIgnore]
        public double PersonGain
        {
            get
            {
                return personGain;
            }
        }

        /// <summary>
        /// Gets the latent heat gain per person [W/person].
        /// </summary>
        [JsonIgnore]
        public double PersonLatentGain
        {
            get
            {
                return personLatentGain;
            }
        }

        /// <summary>
        /// Gets the sources of the values as text.
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
        /// Gets a copy of the source tag of every value, keyed by property name, or null.
        /// </summary>
        [JsonIgnore]
        public Dictionary<string, string>? Sources
        {
            get
            {
                return sources is null ? null : new Dictionary<string, string>(sources);
            }
        }

        /// <summary>
        /// Gets the usage type.
        /// </summary>
        [JsonIgnore]
        public UsageType UsageType
        {
            get
            {
                return usageType;
            }
        }
    }
}
