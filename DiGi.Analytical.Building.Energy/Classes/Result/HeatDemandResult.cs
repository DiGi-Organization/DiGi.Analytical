using DiGi.Analytical.Building.Energy.Interfaces;
using DiGi.Core.Classes;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Analytical.Building.Energy.Classes
{
    /// <summary>
    /// Represents the monthly heat demand of a building calculated by the PN-EN ISO 52016-1 monthly quasi-steady method (DiGi-Organization/DiGi.Analytical#21): the monthly and annual energy need for space heating, the heat transfer coefficients, the dynamic parameters, the design heat load and the provenance of every value.
    /// <para>Created by <c>Create.HeatDemandResult</c>, which does the calculation; the constructor only assigns and copies.</para>
    /// </summary>
    public class HeatDemandResult : SerializableResult, IEnergySerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(DesignHeatLoad))]
        private readonly double designHeatLoad = double.NaN;

        [JsonInclude, JsonPropertyName(nameof(DesignTransmissionHeatLoss))]
        private readonly double designTransmissionHeatLoss = double.NaN;

        [JsonInclude, JsonPropertyName(nameof(DesignVentilationHeatLoss))]
        private readonly double designVentilationHeatLoss = double.NaN;

        [JsonInclude, JsonPropertyName(nameof(DirectHeatTransferCoefficient))]
        private readonly double directHeatTransferCoefficient = double.NaN;

        [JsonInclude, JsonPropertyName(nameof(ExcludedComponents))]
        private readonly List<string>? excludedComponents;

        [JsonInclude, JsonPropertyName(nameof(GainUtilisationFactors))]
        private readonly List<double>? gainUtilisationFactors;

        [JsonInclude, JsonPropertyName(nameof(GlazingFallbackCount))]
        private readonly int glazingFallbackCount;

        [JsonInclude, JsonPropertyName(nameof(GroundHeatTransferCoefficient))]
        private readonly double groundHeatTransferCoefficient = double.NaN;

        [JsonInclude, JsonPropertyName(nameof(HeatBalanceRatios))]
        private readonly List<double>? heatBalanceRatios;

        [JsonInclude, JsonPropertyName(nameof(HeatedVolume))]
        private readonly double heatedVolume = double.NaN;

        [JsonInclude, JsonPropertyName(nameof(HeatingEnergyNeed))]
        private readonly double heatingEnergyNeed = double.NaN;

        [JsonInclude, JsonPropertyName(nameof(HeatingEnergyNeedPerArea))]
        private readonly double heatingEnergyNeedPerArea = double.NaN;

        [JsonInclude, JsonPropertyName(nameof(HeatingEnergyNeeds))]
        private readonly List<double>? heatingEnergyNeeds;

        [JsonInclude, JsonPropertyName(nameof(InternalHeatCapacity))]
        private readonly double internalHeatCapacity = double.NaN;

        [JsonInclude, JsonPropertyName(nameof(InternalHeatGains))]
        private readonly List<double>? internalHeatGains;

        [JsonInclude, JsonPropertyName(nameof(InternalTemperature))]
        private readonly double internalTemperature = double.NaN;

        [JsonInclude, JsonPropertyName(nameof(Method))]
        private readonly string? method;

        [JsonInclude, JsonPropertyName(nameof(MethodVersion))]
        private readonly int methodVersion;

        [JsonInclude, JsonPropertyName(nameof(MissingIrradiationCount))]
        private readonly int missingIrradiationCount;

        [JsonInclude, JsonPropertyName(nameof(ReferenceFloorArea))]
        private readonly double referenceFloorArea = double.NaN;

        [JsonInclude, JsonPropertyName(nameof(SkyRadiationHeatTransfers))]
        private readonly List<double>? skyRadiationHeatTransfers;

        [JsonInclude, JsonPropertyName(nameof(SolarHeatGains))]
        private readonly List<double>? solarHeatGains;

        [JsonInclude, JsonPropertyName(nameof(Sources))]
        private readonly Dictionary<string, string>? sources;

        [JsonInclude, JsonPropertyName(nameof(ThermalBridgeHeatTransferCoefficient))]
        private readonly double thermalBridgeHeatTransferCoefficient = double.NaN;

        [JsonInclude, JsonPropertyName(nameof(TimeConstant))]
        private readonly double timeConstant = double.NaN;

        [JsonInclude, JsonPropertyName(nameof(TransmissionHeatTransfers))]
        private readonly List<double>? transmissionHeatTransfers;

        [JsonInclude, JsonPropertyName(nameof(UnheatedSpaceHeatTransferCoefficient))]
        private readonly double unheatedSpaceHeatTransferCoefficient = double.NaN;

        [JsonInclude, JsonPropertyName(nameof(VentilationHeatTransferCoefficient))]
        private readonly double ventilationHeatTransferCoefficient = double.NaN;

        [JsonInclude, JsonPropertyName(nameof(VentilationHeatTransfers))]
        private readonly List<double>? ventilationHeatTransfers;

        /// <summary>
        /// Initializes a new instance of the <see cref="HeatDemandResult"/> class.
        /// <para>The values are assigned and the collections copied; <c>Create.HeatDemandResult</c> computes them.</para>
        /// </summary>
        /// <param name="heatingEnergyNeed">The annual energy need for space heating Q_H,nd, the sum of the positive monthly needs [kWh/a].</param>
        /// <param name="heatingEnergyNeedPerArea">The annual energy need for space heating per reference floor area Q_H,nd / A_ref [kWh/(m2a)].</param>
        /// <param name="heatingEnergyNeeds">The monthly energy needs for space heating Q_H,nd,m, January to December [kWh]. This value can be null.</param>
        /// <param name="transmissionHeatTransfers">The monthly heat transfer by transmission Q_tr,m = (H_D + H_tb + H_g + H_U)·(θ_int − θ_e,m)·t_m, January to December [kWh]. This value can be null.</param>
        /// <param name="ventilationHeatTransfers">The monthly heat transfer by ventilation Q_ve,m = H_ve·(θ_int − θ_e,m)·t_m, January to December [kWh]. This value can be null.</param>
        /// <param name="internalHeatGains">The monthly internal heat gains Q_int,m, January to December [kWh]. This value can be null.</param>
        /// <param name="solarHeatGains">The monthly solar heat gains of glazed and opaque elements before the sky radiation is subtracted, January to December [kWh]. This value can be null.</param>
        /// <param name="skyRadiationHeatTransfers">The monthly extra heat flow by thermal radiation to the sky, subtracted from the solar gains, January to December [kWh]. This value can be null.</param>
        /// <param name="heatBalanceRatios">The monthly heat balance ratios γ_H = Q_gn / Q_ht, January to December [-]. This value can be null.</param>
        /// <param name="gainUtilisationFactors">The monthly gain utilisation factors η_H,gn, January to December [-]. This value can be null.</param>
        /// <param name="directHeatTransferCoefficient">The direct heat transfer coefficient H_D = Σ U·A of the external walls, roofs, exposed floors, windows and doors [W/K].</param>
        /// <param name="thermalBridgeHeatTransferCoefficient">The heat transfer coefficient of thermal bridges H_tb = ΔU_tb·ΣA [W/K].</param>
        /// <param name="groundHeatTransferCoefficient">The heat transfer coefficient through the ground H_g of the floors on the ground [W/K].</param>
        /// <param name="unheatedSpaceHeatTransferCoefficient">The heat transfer coefficient through the unheated cellar H_U [W/K].</param>
        /// <param name="ventilationHeatTransferCoefficient">The ventilation heat transfer coefficient H_ve [W/K].</param>
        /// <param name="internalHeatCapacity">The internal heat capacity of the building C_m [J/K].</param>
        /// <param name="timeConstant">The time constant of the building τ [h].</param>
        /// <param name="referenceFloorArea">The reference floor area A_ref, the gross floor area of the spaces [m2].</param>
        /// <param name="heatedVolume">The volume inside the external shell V [m3].</param>
        /// <param name="internalTemperature">The internal set-point temperature for heating θ_int, the floor-area weighted thermostat lower limit [°C].</param>
        /// <param name="designHeatLoad">The design heat load Φ_HL = Φ_T + Φ_V [W].</param>
        /// <param name="designTransmissionHeatLoss">The design transmission heat loss Φ_T [W].</param>
        /// <param name="designVentilationHeatLoss">The design ventilation heat loss Φ_V [W].</param>
        /// <param name="method">The method the result was calculated by. This value can be null.</param>
        /// <param name="methodVersion">The version of the method, <see cref="Constants.Default.HeatDemandMethodVersion"/> when the result was calculated.</param>
        /// <param name="sources">The source of each value, keyed by the name of the value. This value can be null.</param>
        /// <param name="excludedComponents">The identifiers, in the "D" format, of the components and openings excluded because their thermal transmittance is not known. This value can be null.</param>
        /// <param name="glazingFallbackCount">The number of glazed openings whose glazed area was taken as (1 − F_f)·A_w because their construction has no panes.</param>
        /// <param name="missingIrradiationCount">The number of external surfaces with no monthly irradiation in the climate, whose solar gains are 0.</param>
        public HeatDemandResult(
            double heatingEnergyNeed,
            double heatingEnergyNeedPerArea,
            IEnumerable<double>? heatingEnergyNeeds,
            IEnumerable<double>? transmissionHeatTransfers,
            IEnumerable<double>? ventilationHeatTransfers,
            IEnumerable<double>? internalHeatGains,
            IEnumerable<double>? solarHeatGains,
            IEnumerable<double>? skyRadiationHeatTransfers,
            IEnumerable<double>? heatBalanceRatios,
            IEnumerable<double>? gainUtilisationFactors,
            double directHeatTransferCoefficient,
            double thermalBridgeHeatTransferCoefficient,
            double groundHeatTransferCoefficient,
            double unheatedSpaceHeatTransferCoefficient,
            double ventilationHeatTransferCoefficient,
            double internalHeatCapacity,
            double timeConstant,
            double referenceFloorArea,
            double heatedVolume,
            double internalTemperature,
            double designHeatLoad,
            double designTransmissionHeatLoss,
            double designVentilationHeatLoss,
            string? method,
            int methodVersion,
            IDictionary<string, string>? sources,
            IEnumerable<string>? excludedComponents,
            int glazingFallbackCount,
            int missingIrradiationCount)
            : base()
        {
            this.heatingEnergyNeed = heatingEnergyNeed;
            this.heatingEnergyNeedPerArea = heatingEnergyNeedPerArea;
            this.heatingEnergyNeeds = heatingEnergyNeeds is null ? null : [.. heatingEnergyNeeds];
            this.transmissionHeatTransfers = transmissionHeatTransfers is null ? null : [.. transmissionHeatTransfers];
            this.ventilationHeatTransfers = ventilationHeatTransfers is null ? null : [.. ventilationHeatTransfers];
            this.internalHeatGains = internalHeatGains is null ? null : [.. internalHeatGains];
            this.solarHeatGains = solarHeatGains is null ? null : [.. solarHeatGains];
            this.skyRadiationHeatTransfers = skyRadiationHeatTransfers is null ? null : [.. skyRadiationHeatTransfers];
            this.heatBalanceRatios = heatBalanceRatios is null ? null : [.. heatBalanceRatios];
            this.gainUtilisationFactors = gainUtilisationFactors is null ? null : [.. gainUtilisationFactors];
            this.directHeatTransferCoefficient = directHeatTransferCoefficient;
            this.thermalBridgeHeatTransferCoefficient = thermalBridgeHeatTransferCoefficient;
            this.groundHeatTransferCoefficient = groundHeatTransferCoefficient;
            this.unheatedSpaceHeatTransferCoefficient = unheatedSpaceHeatTransferCoefficient;
            this.ventilationHeatTransferCoefficient = ventilationHeatTransferCoefficient;
            this.internalHeatCapacity = internalHeatCapacity;
            this.timeConstant = timeConstant;
            this.referenceFloorArea = referenceFloorArea;
            this.heatedVolume = heatedVolume;
            this.internalTemperature = internalTemperature;
            this.designHeatLoad = designHeatLoad;
            this.designTransmissionHeatLoss = designTransmissionHeatLoss;
            this.designVentilationHeatLoss = designVentilationHeatLoss;
            this.method = method;
            this.methodVersion = methodVersion;
            this.sources = sources is null ? null : new Dictionary<string, string>(sources);
            this.excludedComponents = excludedComponents is null ? null : [.. excludedComponents];
            this.glazingFallbackCount = glazingFallbackCount;
            this.missingIrradiationCount = missingIrradiationCount;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HeatDemandResult"/> class by copying an existing instance.
        /// </summary>
        /// <param name="heatDemandResult">The <see cref="HeatDemandResult"/> to copy. This value can be null.</param>
        public HeatDemandResult(HeatDemandResult? heatDemandResult)
            : base(heatDemandResult)
        {
            if (heatDemandResult is not null)
            {
                heatingEnergyNeed = heatDemandResult.heatingEnergyNeed;
                heatingEnergyNeedPerArea = heatDemandResult.heatingEnergyNeedPerArea;
                heatingEnergyNeeds = heatDemandResult.heatingEnergyNeeds is null ? null : [.. heatDemandResult.heatingEnergyNeeds];
                transmissionHeatTransfers = heatDemandResult.transmissionHeatTransfers is null ? null : [.. heatDemandResult.transmissionHeatTransfers];
                ventilationHeatTransfers = heatDemandResult.ventilationHeatTransfers is null ? null : [.. heatDemandResult.ventilationHeatTransfers];
                internalHeatGains = heatDemandResult.internalHeatGains is null ? null : [.. heatDemandResult.internalHeatGains];
                solarHeatGains = heatDemandResult.solarHeatGains is null ? null : [.. heatDemandResult.solarHeatGains];
                skyRadiationHeatTransfers = heatDemandResult.skyRadiationHeatTransfers is null ? null : [.. heatDemandResult.skyRadiationHeatTransfers];
                heatBalanceRatios = heatDemandResult.heatBalanceRatios is null ? null : [.. heatDemandResult.heatBalanceRatios];
                gainUtilisationFactors = heatDemandResult.gainUtilisationFactors is null ? null : [.. heatDemandResult.gainUtilisationFactors];
                directHeatTransferCoefficient = heatDemandResult.directHeatTransferCoefficient;
                thermalBridgeHeatTransferCoefficient = heatDemandResult.thermalBridgeHeatTransferCoefficient;
                groundHeatTransferCoefficient = heatDemandResult.groundHeatTransferCoefficient;
                unheatedSpaceHeatTransferCoefficient = heatDemandResult.unheatedSpaceHeatTransferCoefficient;
                ventilationHeatTransferCoefficient = heatDemandResult.ventilationHeatTransferCoefficient;
                internalHeatCapacity = heatDemandResult.internalHeatCapacity;
                timeConstant = heatDemandResult.timeConstant;
                referenceFloorArea = heatDemandResult.referenceFloorArea;
                heatedVolume = heatDemandResult.heatedVolume;
                internalTemperature = heatDemandResult.internalTemperature;
                designHeatLoad = heatDemandResult.designHeatLoad;
                designTransmissionHeatLoss = heatDemandResult.designTransmissionHeatLoss;
                designVentilationHeatLoss = heatDemandResult.designVentilationHeatLoss;
                method = heatDemandResult.method;
                methodVersion = heatDemandResult.methodVersion;
                sources = heatDemandResult.sources is null ? null : new Dictionary<string, string>(heatDemandResult.sources);
                excludedComponents = heatDemandResult.excludedComponents is null ? null : [.. heatDemandResult.excludedComponents];
                glazingFallbackCount = heatDemandResult.glazingFallbackCount;
                missingIrradiationCount = heatDemandResult.missingIrradiationCount;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HeatDemandResult"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the result data. This value can be null.</param>
        public HeatDemandResult(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the design heat load Φ_HL = Φ_T + Φ_V [W].
        /// </summary>
        [JsonIgnore]
        public double DesignHeatLoad
        {
            get
            {
                return designHeatLoad;
            }
        }

        /// <summary>
        /// Gets the design transmission heat loss Φ_T [W].
        /// </summary>
        [JsonIgnore]
        public double DesignTransmissionHeatLoss
        {
            get
            {
                return designTransmissionHeatLoss;
            }
        }

        /// <summary>
        /// Gets the design ventilation heat loss Φ_V [W].
        /// </summary>
        [JsonIgnore]
        public double DesignVentilationHeatLoss
        {
            get
            {
                return designVentilationHeatLoss;
            }
        }

        /// <summary>
        /// Gets the direct heat transfer coefficient H_D = Σ U·A of the external walls, roofs, exposed floors, windows and doors [W/K].
        /// </summary>
        [JsonIgnore]
        public double DirectHeatTransferCoefficient
        {
            get
            {
                return directHeatTransferCoefficient;
            }
        }

        /// <summary>
        /// Gets a copy of the identifiers, in the "D" format, of the components and openings excluded because their thermal transmittance is not known.
        /// </summary>
        [JsonIgnore]
        public List<string>? ExcludedComponents
        {
            get
            {
                return excludedComponents is null ? null : [.. excludedComponents];
            }
        }

        /// <summary>
        /// Gets a copy of the monthly gain utilisation factors η_H,gn, January to December [-].
        /// </summary>
        [JsonIgnore]
        public List<double>? GainUtilisationFactors
        {
            get
            {
                return gainUtilisationFactors is null ? null : [.. gainUtilisationFactors];
            }
        }

        /// <summary>
        /// Gets the number of glazed openings whose glazed area was taken as (1 − F_f)·A_w because their construction has no panes.
        /// </summary>
        [JsonIgnore]
        public int GlazingFallbackCount
        {
            get
            {
                return glazingFallbackCount;
            }
        }

        /// <summary>
        /// Gets the heat transfer coefficient through the ground H_g of the floors on the ground [W/K].
        /// </summary>
        [JsonIgnore]
        public double GroundHeatTransferCoefficient
        {
            get
            {
                return groundHeatTransferCoefficient;
            }
        }

        /// <summary>
        /// Gets a copy of the monthly heat balance ratios γ_H = Q_gn / Q_ht, January to December [-].
        /// </summary>
        [JsonIgnore]
        public List<double>? HeatBalanceRatios
        {
            get
            {
                return heatBalanceRatios is null ? null : [.. heatBalanceRatios];
            }
        }

        /// <summary>
        /// Gets the volume inside the external shell V [m3].
        /// </summary>
        [JsonIgnore]
        public double HeatedVolume
        {
            get
            {
                return heatedVolume;
            }
        }

        /// <summary>
        /// Gets the annual energy need for space heating Q_H,nd, the sum of the positive monthly needs [kWh/a].
        /// </summary>
        [JsonIgnore]
        public double HeatingEnergyNeed
        {
            get
            {
                return heatingEnergyNeed;
            }
        }

        /// <summary>
        /// Gets the annual energy need for space heating per reference floor area Q_H,nd / A_ref [kWh/(m2a)].
        /// </summary>
        [JsonIgnore]
        public double HeatingEnergyNeedPerArea
        {
            get
            {
                return heatingEnergyNeedPerArea;
            }
        }

        /// <summary>
        /// Gets a copy of the monthly energy needs for space heating Q_H,nd,m, January to December [kWh].
        /// </summary>
        [JsonIgnore]
        public List<double>? HeatingEnergyNeeds
        {
            get
            {
                return heatingEnergyNeeds is null ? null : [.. heatingEnergyNeeds];
            }
        }

        /// <summary>
        /// Gets the internal heat capacity of the building C_m [J/K].
        /// </summary>
        [JsonIgnore]
        public double InternalHeatCapacity
        {
            get
            {
                return internalHeatCapacity;
            }
        }

        /// <summary>
        /// Gets a copy of the monthly internal heat gains Q_int,m, January to December [kWh].
        /// </summary>
        [JsonIgnore]
        public List<double>? InternalHeatGains
        {
            get
            {
                return internalHeatGains is null ? null : [.. internalHeatGains];
            }
        }

        /// <summary>
        /// Gets the internal set-point temperature for heating θ_int, the floor-area weighted thermostat lower limit [°C].
        /// </summary>
        [JsonIgnore]
        public double InternalTemperature
        {
            get
            {
                return internalTemperature;
            }
        }

        /// <summary>
        /// Gets the method the result was calculated by.
        /// </summary>
        [JsonIgnore]
        public string? Method
        {
            get
            {
                return method;
            }
        }

        /// <summary>
        /// Gets the version of the method, <see cref="Constants.Default.HeatDemandMethodVersion"/> when the result was calculated.
        /// </summary>
        [JsonIgnore]
        public int MethodVersion
        {
            get
            {
                return methodVersion;
            }
        }

        /// <summary>
        /// Gets the number of external surfaces with no monthly irradiation in the climate, whose solar gains are 0.
        /// </summary>
        [JsonIgnore]
        public int MissingIrradiationCount
        {
            get
            {
                return missingIrradiationCount;
            }
        }

        /// <summary>
        /// Gets the reference floor area A_ref, the gross floor area of the spaces [m2].
        /// </summary>
        [JsonIgnore]
        public double ReferenceFloorArea
        {
            get
            {
                return referenceFloorArea;
            }
        }

        /// <summary>
        /// Gets a copy of the monthly extra heat flow by thermal radiation to the sky, subtracted from the solar gains, January to December [kWh].
        /// </summary>
        [JsonIgnore]
        public List<double>? SkyRadiationHeatTransfers
        {
            get
            {
                return skyRadiationHeatTransfers is null ? null : [.. skyRadiationHeatTransfers];
            }
        }

        /// <summary>
        /// Gets a copy of the monthly solar heat gains of glazed and opaque elements before the sky radiation is subtracted, January to December [kWh].
        /// </summary>
        [JsonIgnore]
        public List<double>? SolarHeatGains
        {
            get
            {
                return solarHeatGains is null ? null : [.. solarHeatGains];
            }
        }

        /// <summary>
        /// Gets a copy of the source of each value, keyed by the name of the value.
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
        /// Gets the heat transfer coefficient of thermal bridges H_tb = ΔU_tb·ΣA [W/K].
        /// </summary>
        [JsonIgnore]
        public double ThermalBridgeHeatTransferCoefficient
        {
            get
            {
                return thermalBridgeHeatTransferCoefficient;
            }
        }

        /// <summary>
        /// Gets the time constant of the building τ [h].
        /// </summary>
        [JsonIgnore]
        public double TimeConstant
        {
            get
            {
                return timeConstant;
            }
        }

        /// <summary>
        /// Gets a copy of the monthly heat transfer by transmission Q_tr,m = (H_D + H_tb + H_g + H_U)·(θ_int − θ_e,m)·t_m, January to December [kWh].
        /// </summary>
        [JsonIgnore]
        public List<double>? TransmissionHeatTransfers
        {
            get
            {
                return transmissionHeatTransfers is null ? null : [.. transmissionHeatTransfers];
            }
        }

        /// <summary>
        /// Gets the heat transfer coefficient through the unheated cellar H_U [W/K].
        /// </summary>
        [JsonIgnore]
        public double UnheatedSpaceHeatTransferCoefficient
        {
            get
            {
                return unheatedSpaceHeatTransferCoefficient;
            }
        }

        /// <summary>
        /// Gets the ventilation heat transfer coefficient H_ve [W/K].
        /// </summary>
        [JsonIgnore]
        public double VentilationHeatTransferCoefficient
        {
            get
            {
                return ventilationHeatTransferCoefficient;
            }
        }

        /// <summary>
        /// Gets a copy of the monthly heat transfer by ventilation Q_ve,m = H_ve·(θ_int − θ_e,m)·t_m, January to December [kWh].
        /// </summary>
        [JsonIgnore]
        public List<double>? VentilationHeatTransfers
        {
            get
            {
                return ventilationHeatTransfers is null ? null : [.. ventilationHeatTransfers];
            }
        }
    }
}
