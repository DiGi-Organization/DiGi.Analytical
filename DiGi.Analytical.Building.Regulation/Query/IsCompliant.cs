namespace DiGi.Analytical.Building.Regulation
{
    public static partial class Query
    {
        /// <summary>
        /// Determines whether a thermal transmittance meets a maximum heat transfer coefficient: U ≤ U(max) within the tolerance (DiGi-Organization/DiGi.Analytical#8).
        /// <para>A missing value on either side is never a pass: where the regulation sets no limit (U(max) NaN) or U cannot be determined, the result is false and the case is for the caller to report.</para>
        /// </summary>
        /// <param name="thermalTransmittance">The thermal transmittance U [W/(m2K)].</param>
        /// <param name="regulatedHeatTransferCoefficient">The maximum heat transfer coefficient U(max) [W/(m2K)].</param>
        /// <param name="tolerance">The tolerance by which U may exceed U(max).</param>
        /// <returns>True if U ≤ U(max) + <paramref name="tolerance"/>; otherwise, false, also when either value is NaN.</returns>
        public static bool IsCompliant(this double thermalTransmittance, double regulatedHeatTransferCoefficient, double tolerance = Core.Constants.Tolerance.Distance)
        {
            if (double.IsNaN(thermalTransmittance) || double.IsNaN(regulatedHeatTransferCoefficient))
            {
                return false;
            }

            return thermalTransmittance <= regulatedHeatTransferCoefficient + tolerance;
        }
    }
}
