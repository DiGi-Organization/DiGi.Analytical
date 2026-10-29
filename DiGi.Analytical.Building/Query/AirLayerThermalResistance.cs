using DiGi.Analytical.Building.Enums;

namespace DiGi.Analytical.Building
{
    public static partial class Query
    {
        /// <summary>
        /// Gets the design thermal resistance of an unventilated air layer with high-emissivity faces, per PN-EN ISO 6946 (DiGi-Organization/DiGi.Analytical#8).
        /// <para>The tabulated values for 0, 5, 7, 10, 15, 25, 50, 100 and 300 mm are [(m2K)/W]: upward 0, 0.11, 0.13, 0.15, 0.16, 0.16, 0.16, 0.16, 0.16; horizontal 0, 0.11, 0.13, 0.15, 0.17, 0.18, 0.18, 0.18, 0.18; downward 0, 0.11, 0.13, 0.15, 0.17, 0.19, 0.21, 0.22, 0.23. Intermediate thicknesses are interpolated linearly, as the standard allows. Source: the table of PN-EN ISO 6946:2008 as quoted in ProAkademia, "Opór cieplny warstw powietrza", Table 9.3.1/2.</para>
        /// <para>The standard does not give a single value for an air layer thicker than 0.3 m, which is why none is returned for it.</para>
        /// </summary>
        /// <param name="thickness">The thickness of the air layer in the direction of the heat flow [m].</param>
        /// <param name="heatFlowDirection">The direction of the heat flow.</param>
        /// <returns>The thermal resistance [(m2K)/W], or <see cref="double.NaN"/> when the thickness is NaN, negative or above 0.3 m, or <paramref name="heatFlowDirection"/> is <see cref="HeatFlowDirection.Undefined"/>.</returns>
        public static double AirLayerThermalResistance(double thickness, HeatFlowDirection heatFlowDirection)
        {
            if (double.IsNaN(thickness) || thickness < 0 || thickness > 0.3 + Core.Constants.Tolerance.Distance)
            {
                return double.NaN;
            }

            double[] thicknesses = [0.0, 0.005, 0.007, 0.010, 0.015, 0.025, 0.050, 0.100, 0.300];

            double[]? thermalResistances = heatFlowDirection switch
            {
                HeatFlowDirection.Upward => [0.0, 0.11, 0.13, 0.15, 0.16, 0.16, 0.16, 0.16, 0.16],
                HeatFlowDirection.Horizontal => [0.0, 0.11, 0.13, 0.15, 0.17, 0.18, 0.18, 0.18, 0.18],
                HeatFlowDirection.Downward => [0.0, 0.11, 0.13, 0.15, 0.17, 0.19, 0.21, 0.22, 0.23],
                _ => null,
            };

            if (thermalResistances is null)
            {
                return double.NaN;
            }

            for (int i = 1; i < thicknesses.Length; i++)
            {
                if (thickness <= thicknesses[i])
                {
                    double factor = (thickness - thicknesses[i - 1]) / (thicknesses[i] - thicknesses[i - 1]);
                    return thermalResistances[i - 1] + (factor * (thermalResistances[i] - thermalResistances[i - 1]));
                }
            }

            return thermalResistances[thermalResistances.Length - 1];
        }
    }
}
