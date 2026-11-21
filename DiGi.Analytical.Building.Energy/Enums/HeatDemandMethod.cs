using System.ComponentModel;

namespace DiGi.Analytical.Building.Energy.Enums
{
    /// <summary>
    /// Specifies the method a heat demand was calculated by (DiGi-Organization/DiGi.Analytical#23, Heat Demand Method Identity DiGi-Organization/DiGi.GIS.Analytical#19).
    /// <para>A result is identified by its method and its <see cref="Classes.HeatDemandResult.MethodVersion"/>, the revision within that method; results of different methods are stored side by side and compared, never mixed. The integer values are stored and sent as integers and never change; a new engine - the hourly method of PN-EN ISO 52016-1, EnergyPlus, a calibrated method - is a new member with its own version 1.</para>
    /// </summary>
    [Description("Heat demand method")]
    public enum HeatDemandMethod
    {
        /// <summary>The method is not known; never stored.</summary>
        [Description("Undefined")] Undefined = 0,

        /// <summary>The PN-EN ISO 52016-1 monthly quasi-steady method of <c>Create.HeatDemandResult</c>, one continuously heated zone (<see cref="Constants.Source.Method"/>); its revision is <see cref="Constants.Default.HeatDemandMethodVersion"/>.</summary>
        [Description("Monthly (PN-EN ISO 52016-1 monthly quasi-steady)")] Monthly = 1,
    }
}
