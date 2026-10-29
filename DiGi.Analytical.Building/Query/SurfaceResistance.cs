using DiGi.Analytical.Building.Enums;

namespace DiGi.Analytical.Building
{
    public static partial class Query
    {
        /// <summary>
        /// Gets the design surface resistance of a construction face in contact with air, per PN-EN ISO 6946 (DiGi-Organization/DiGi.Analytical#8).
        /// <para>Internal (Rsi): 0.10 upward, 0.13 horizontal, 0.17 downward [(m2K)/W]. External (Rse): 0.04 for every direction. A face in contact with another material or with the ground has no surface resistance; that is for the caller to decide.</para>
        /// </summary>
        /// <param name="heatFlowDirection">The direction of the heat flow.</param>
        /// <param name="internal">True for the internal surface resistance Rsi, false for the external one Rse.</param>
        /// <returns>The surface resistance [(m2K)/W], or <see cref="double.NaN"/> when <paramref name="heatFlowDirection"/> is <see cref="HeatFlowDirection.Undefined"/>.</returns>
        public static double SurfaceResistance(this HeatFlowDirection heatFlowDirection, bool @internal)
        {
            if (heatFlowDirection == HeatFlowDirection.Undefined)
            {
                return double.NaN;
            }

            if (!@internal)
            {
                return 0.04;
            }

            return heatFlowDirection switch
            {
                HeatFlowDirection.Upward => 0.10,
                HeatFlowDirection.Horizontal => 0.13,
                HeatFlowDirection.Downward => 0.17,
                _ => double.NaN,
            };
        }
    }
}
