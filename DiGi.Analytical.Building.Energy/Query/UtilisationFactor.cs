namespace DiGi.Analytical.Building.Energy
{
    public static partial class Query
    {
        /// <summary>
        /// Gets the dimensionless gain utilisation factor for heating η_H,gn of the monthly method (DiGi-Organization/DiGi.Analytical#21), <see cref="Constants.Source.GainUtilisation"/>.
        /// <para>η = (1 − γ^a) / (1 − γ^(a+1)) for γ ≠ 1, η = a / (a + 1) for γ = 1 and η = 1 / γ for γ &lt; 0 (Equations (53) to (55)). γ is within <see cref="Core.Constants.Tolerance.MicroDistance"/> of 1 when the first form loses precision, so the limit is taken there.</para>
        /// </summary>
        /// <param name="gainLossRatio">The heat balance ratio for heating γ_H = Q_H,gn / Q_H,ht [-].</param>
        /// <param name="a">The numerical parameter a_H = a_H,0 + τ / τ_H,0 [-].</param>
        /// <returns>The gain utilisation factor [-], or <see cref="double.NaN"/> when either value is NaN or <paramref name="a"/> is not positive.</returns>
        public static double UtilisationFactor(double gainLossRatio, double a)
        {
            if (double.IsNaN(gainLossRatio) || double.IsNaN(a) || a <= 0)
            {
                return double.NaN;
            }

            if (gainLossRatio < 0)
            {
                return 1.0 / gainLossRatio;
            }

            if (System.Math.Abs(gainLossRatio - 1.0) < Core.Constants.Tolerance.MicroDistance)
            {
                return a / (a + 1.0);
            }

            if (double.IsPositiveInfinity(gainLossRatio))
            {
                return 0.0;
            }

            return (1.0 - System.Math.Pow(gainLossRatio, a)) / (1.0 - System.Math.Pow(gainLossRatio, a + 1.0));
        }
    }
}
