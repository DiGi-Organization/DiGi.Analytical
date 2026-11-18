using DiGi.Analytical.Building.Regulation.Enums;

namespace DiGi.Analytical.Building.Regulation
{
    public static partial class Query
    {
        /// <summary>
        /// Gets the mean annual outdoor temperature θ_m,e of a Polish climate zone of PN-82/B-02403, which the ground correction f_g2 of the design heat load uses (DiGi-Organization/DiGi.Analytical#21).
        /// <para>7.7, 7.9, 7.6, 6.9 and 5.5 °C for zones I to V: PN-EN 12831:2006 as reproduced in Strzeszewski and Wereszczyński (Purmo 2009), Table 2.1. Not checked against the original.</para>
        /// </summary>
        /// <param name="climateZone">The climate zone.</param>
        /// <returns>The mean annual outdoor temperature [°C], or <see cref="double.NaN"/> for <see cref="ClimateZone.Undefined"/>.</returns>
        public static double AnnualMeanOutdoorTemperature(this ClimateZone climateZone)
        {
            return climateZone switch
            {
                ClimateZone.I => 7.7,
                ClimateZone.II => 7.9,
                ClimateZone.III => 7.6,
                ClimateZone.IV => 6.9,
                ClimateZone.V => 5.5,
                _ => double.NaN,
            };
        }
    }
}
