using DiGi.Analytical.Building.Regulation.Enums;

namespace DiGi.Analytical.Building.Regulation
{
    public static partial class Query
    {
        /// <summary>
        /// Gets the design outdoor temperature θ_e of a Polish climate zone of PN-82/B-02403, the external temperature of the design heat load (DiGi-Organization/DiGi.Analytical#21).
        /// <para>-16, -18, -20, -22 and -24 °C for zones I to V: PN-EN 12831:2006 as reproduced in Strzeszewski and Wereszczyński (Purmo 2009), Table 2.1, the source the zone map of DiGi.GIS.Analytical <c>Query.ClimateZone</c> is digitised from. Not checked against the original.</para>
        /// </summary>
        /// <param name="climateZone">The climate zone.</param>
        /// <returns>The design outdoor temperature [°C], or <see cref="double.NaN"/> for <see cref="ClimateZone.Undefined"/>.</returns>
        public static double DesignOutdoorTemperature(this ClimateZone climateZone)
        {
            return climateZone switch
            {
                ClimateZone.I => -16.0,
                ClimateZone.II => -18.0,
                ClimateZone.III => -20.0,
                ClimateZone.IV => -22.0,
                ClimateZone.V => -24.0,
                _ => double.NaN,
            };
        }
    }
}
