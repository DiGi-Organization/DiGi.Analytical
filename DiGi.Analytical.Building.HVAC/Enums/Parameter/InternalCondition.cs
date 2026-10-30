using DiGi.Analytical.Building.Interfaces;
using DiGi.Core.Parameter.Classes;
using System.ComponentModel;

namespace DiGi.Analytical.Building.HVAC.Enums
{
    /// <summary>
    /// Defines the available parameters for an internal condition in the HVAC analytical model.
    /// </summary>
    [AssociatedTypes(typeof(IInternalCondition)), Description("Internal condition parameter")]
    public enum InternalConditionParameter
    {
        /// <summary>
        /// Represents the internal gain parameter for an internal condition.
        /// </summary>
        [ParameterProperties("be61a143-04fd-418c-a184-ce435c274280", "InternalGain", "Internal Gain"), ObjectParameterValue(true, true, typeof(Classes.InternalGain))] InternalGain,

        /// <summary>
        /// Specifies that the internal condition parameter is a thermostat.
        /// </summary>
        [ParameterProperties("3686aa6d-3590-4bcf-8382-c2c086f5874b", "Thermostat", "Thermostat"), ObjectParameterValue(true, true, typeof(Classes.Thermostat))] Thermostat,

        /// <summary>
        /// Represents the heating emitter internal condition parameter.
        /// </summary>
        [ParameterProperties("1cb95e8b-fb84-4d87-ae53-7949f9235874", "HeatingEmitter", "Heating Emitter"), ObjectParameterValue(true, true, typeof(Classes.HeatingEmitter))] HeatingEmitter,

        /// <summary>
        /// Represents the cooling emitter internal condition parameter.
        /// </summary>
        [ParameterProperties("210d1fa2-66ba-4721-917a-4d52f2689767", "CoolingEmitter", "Cooling Emitter"), ObjectParameterValue(true, true, typeof(Classes.CoolingEmitter))] CoolingEmitter,

        /// <summary>
        /// Represents the system properties parameter for the internal condition.
        /// </summary>
        [ParameterProperties("be085040-2032-4008-bb44-b1aa78b1ef32", "SystemProperties", "System Properties"), ObjectParameterValue(true, true, typeof(Classes.SystemProperties))] SystemProperties,

        /// <summary>
        /// Represents the usage type of the usage profile the internal condition was created from, as the name of a <see cref="Enums.UsageType"/> value (DiGi-Organization/DiGi.Analytical#9).
        /// </summary>
        [ParameterProperties("c9aac71b-7923-4ded-8c1c-519fc99dd152", "UsageType", "Usage Type"), StringParameterValue()] UsageType,

        /// <summary>
        /// Represents the sources of the values of the internal condition: the source tag of every value, and whether the usage type was a fallback.
        /// </summary>
        [ParameterProperties("5ee313e9-8d0a-446f-9ff6-9a42c37c4cc0", "UsageSource", "Usage Source"), StringParameterValue()] UsageSource,

        /// <summary>
        /// Represents the number of persons the internal condition was scaled to.
        /// </summary>
        [ParameterProperties("aec973ad-7c25-4dd2-804e-5d66a7c6bb5e", "Occupancy", "Occupancy"), DoubleParameterValue(0.0)] Occupancy,

        /// <summary>
        /// Represents where the number of persons came from (for example the occupancy estimate of a building).
        /// </summary>
        [ParameterProperties("6b6d18a5-f8fe-4e6d-9cd7-81bd5916d8bc", "OccupancySource", "Occupancy Source"), StringParameterValue()] OccupancySource,

        /// <summary>
        /// Represents whether the internal gains and hot water of the internal condition were scaled to <see cref="Occupancy"/>; false when the standard per-area values apply.
        /// </summary>
        [ParameterProperties("10a88a12-9a85-42ec-a29a-5945590d5cbb", "OccupancyScaled", "Occupancy Scaled"), BooleanParameterValue()] OccupancyScaled,
    }
}