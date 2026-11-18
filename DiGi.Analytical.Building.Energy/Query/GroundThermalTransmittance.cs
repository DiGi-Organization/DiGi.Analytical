using DiGi.Analytical.Building.Enums;

namespace DiGi.Analytical.Building.Energy
{
    public static partial class Query
    {
        /// <summary>
        /// Gets the thermal transmittance U of a slab-on-ground floor including the ground, in the steady state (DiGi-Organization/DiGi.Analytical#21), <see cref="Constants.Source.Ground"/>.
        /// <para>The characteristic dimension is B′ = A / (0.5·P) and the equivalent thickness d_t = w + λ_g·(R_si + R_f + R_se), with R_si = 0.17 (downward heat flow) and R_se = 0.04 m2K/W. For d_t &lt; B′ (an uninsulated or moderately insulated floor) U = 2·λ_g / (π·B′ + d_t)·ln(π·B′ / d_t + 1); otherwise (a well insulated floor) U = λ_g / (0.457·B′ + d_t).</para>
        /// <para>An exposed perimeter of 0 - a floor every edge of which borders a heated neighbour - gives an infinite B′ and so U = 0, the limit of both forms.</para>
        /// </summary>
        /// <param name="area">The area of the floor on the ground A [m2].</param>
        /// <param name="exposedPerimeter">The exposed perimeter P of the floor, without the edges along heated neighbours [m].</param>
        /// <param name="wallThickness">The thickness of the external walls at the floor's edge w [m].</param>
        /// <param name="floorThermalResistance">The thermal resistance of the floor construction R_f, its layers without the surface resistances [m2K/W].</param>
        /// <param name="groundThermalConductivity">The thermal conductivity of the ground λ_g [W/(mK)].</param>
        /// <returns>The thermal transmittance [W/(m2K)], or <see cref="double.NaN"/> when an input is NaN, the area is not positive, the perimeter or a resistance is negative or the conductivity is not positive.</returns>
        public static double GroundThermalTransmittance(double area, double exposedPerimeter, double wallThickness, double floorThermalResistance, double groundThermalConductivity = Constants.Default.GroundThermalConductivity)
        {
            if (double.IsNaN(area) || double.IsNaN(exposedPerimeter) || double.IsNaN(wallThickness) || double.IsNaN(floorThermalResistance) || double.IsNaN(groundThermalConductivity))
            {
                return double.NaN;
            }

            if (area <= 0 || exposedPerimeter < 0 || wallThickness < 0 || floorThermalResistance < 0 || groundThermalConductivity <= 0)
            {
                return double.NaN;
            }

            if (exposedPerimeter == 0)
            {
                return 0.0;
            }

            double characteristicDimension = area / (0.5 * exposedPerimeter);

            double equivalentThickness = wallThickness + groundThermalConductivity * (Building.Query.SurfaceResistance(HeatFlowDirection.Downward, true) + floorThermalResistance + Building.Query.SurfaceResistance(HeatFlowDirection.Downward, false));

            if (equivalentThickness < characteristicDimension)
            {
                return 2.0 * groundThermalConductivity / (System.Math.PI * characteristicDimension + equivalentThickness) * System.Math.Log(System.Math.PI * characteristicDimension / equivalentThickness + 1.0);
            }

            return groundThermalConductivity / (0.457 * characteristicDimension + equivalentThickness);
        }
    }
}
