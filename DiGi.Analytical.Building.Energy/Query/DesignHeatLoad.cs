namespace DiGi.Analytical.Building.Energy
{
    public static partial class Query
    {
        /// <summary>
        /// Gets the design heat load Φ_HL of a building calculated as one heated zone, PN-EN 12831-1 simplified (DiGi-Organization/DiGi.Analytical#21), <see cref="Constants.Source.DesignHeatLoad"/>.
        /// <para>Φ_HL = (H_T + f_g1·f_g2·H_g + H_ve)·(θ_int − θ_e), with f_g1 = <see cref="Constants.Default.GroundTemperatureVariationFactor"/> and f_g2 = (θ_int − θ_m,e) / (θ_int − θ_e). The ground loss is counted only when the mean annual temperature is known.</para>
        /// </summary>
        /// <param name="transmissionHeatTransferCoefficient">The transmission heat transfer coefficient to outside air and through unheated spaces, H_T = H_D + H_tb + H_U [W/K].</param>
        /// <param name="groundHeatTransferCoefficient">The heat transfer coefficient through the ground H_g [W/K].</param>
        /// <param name="ventilationHeatTransferCoefficient">The ventilation heat transfer coefficient H_ve [W/K].</param>
        /// <param name="internalTemperature">The internal design temperature θ_int [°C].</param>
        /// <param name="designExternalTemperature">The design external temperature θ_e [°C].</param>
        /// <param name="annualMeanExternalTemperature">The mean annual external temperature θ_m,e [°C].</param>
        /// <returns>The design heat load [W], or <see cref="double.NaN"/> when a coefficient or a temperature it needs is NaN, or θ_int is not above θ_e.</returns>
        public static double DesignHeatLoad(double transmissionHeatTransferCoefficient, double groundHeatTransferCoefficient, double ventilationHeatTransferCoefficient, double internalTemperature, double designExternalTemperature, double annualMeanExternalTemperature)
        {
            if (double.IsNaN(transmissionHeatTransferCoefficient) || double.IsNaN(groundHeatTransferCoefficient) || double.IsNaN(ventilationHeatTransferCoefficient) || double.IsNaN(internalTemperature) || double.IsNaN(designExternalTemperature))
            {
                return double.NaN;
            }

            double temperatureDifference = internalTemperature - designExternalTemperature;
            if (temperatureDifference <= 0)
            {
                return double.NaN;
            }

            double groundHeatTransferCoefficient_Design = 0.0;
            if (groundHeatTransferCoefficient > 0)
            {
                if (double.IsNaN(annualMeanExternalTemperature))
                {
                    return double.NaN;
                }

                groundHeatTransferCoefficient_Design = Constants.Default.GroundTemperatureVariationFactor * ((internalTemperature - annualMeanExternalTemperature) / temperatureDifference) * groundHeatTransferCoefficient;
            }

            return (transmissionHeatTransferCoefficient + groundHeatTransferCoefficient_Design + ventilationHeatTransferCoefficient) * temperatureDifference;
        }
    }
}
