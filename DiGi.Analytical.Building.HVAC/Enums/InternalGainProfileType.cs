using System.ComponentModel;

namespace DiGi.Analytical.Building.HVAC.Enums
{
    /// <summary>
    /// Specifies the type of internal gain profile used in HVAC analytical calculations.
    /// <para>The values of a profile follow the Tas internal-condition convention the TIC importer keeps: gains in W/m2 of floor area, infiltration and ventilation in air changes per hour [1/h], pollutant generation in g/(h m2). A profile's values repeat over the hours it is assigned to, so one value is a constant and 24 or 168 values a daily or weekly cycle.</para>
    /// </summary>
    [Description("Internal gain profile type")]
    public enum InternalGainProfileType
    {
        /// <summary>
        /// Undefined internal gain profile type.
        /// </summary>
        [Description("Undefined")] Undefined,

        /// <summary>
        /// Represents the internal gain profile type for infiltration [1/h].
        /// </summary>
        [Description("Infiltration")] Infiltration,

        /// <summary>
        /// Represents an internal gain profile type associated with ventilation [1/h].
        /// </summary>
        [Description("Ventilation")] Ventilation,

        /// <summary>
        /// Represents the internal heat gain profile associated with lighting [W/m2].
        /// </summary>
        [Description("Lighting gain")] LightingGain,

        /// <summary>
        /// Represents the internal gain profile type for occupancy sensible heat gain [W/m2].
        /// </summary>
        [Description("Occupancy sensible gain")] OccupancySensibleGain,

        /// <summary>Represents the internal gain profile type for occupancy latent gain [W/m2].</summary>
        [Description("Occupancy latent gain")] OccupancyLatentGain,

        /// <summary>
        /// Represents an internal gain profile type for equipment sensible gain [W/m2].
        /// </summary>
        [Description("Equipment sensible gain")] EquipmentSensibleGain,

        /// <summary>
        /// Represents the internal gain profile type for equipment latent gain [W/m2].
        /// </summary>
        [Description("Equipment latent gain")] EquipmentLatentGain,

        /// <summary>
        /// Represents an internal gain profile type associated with pollutant generation [g/(h m2)].
        /// </summary>
        [Description("Pollutant generation")] PollutantGeneration,

        /// <summary>
        /// Represents the total internal heat gain [W/m2] - people, lighting and equipment together, not split into their own profiles (DiGi-Organization/DiGi.Analytical#9).
        /// <para>The Polish energy-certificate methodology gives only this total (q_int, Dz.U. 2015 poz. 376, Annex 1, Table 26), and a monthly balance needs nothing more. It is not added to the occupancy, lighting or equipment profiles: a condition carries either the total or the split, never both.</para>
        /// </summary>
        [Description("Total internal gain")] TotalInternalGain,
    }
}