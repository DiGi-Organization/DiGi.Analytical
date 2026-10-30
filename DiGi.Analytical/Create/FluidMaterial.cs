using DiGi.Analytical.Classes;
using System;
using System.Collections.Generic;

namespace DiGi.Analytical
{
    public static partial class Create
    {
        /// <summary>
        /// Creates the fluid material of a gas mixture, such as the 90 % argon / 10 % air fill of a glazing unit (DiGi-Organization/DiGi.Analytical#8).
        /// <para>Every property of the mixture - conductivity, density, dynamic viscosity, specific heat, their temperature coefficients, molar mass and specific heat ratio - is the volume-fraction weighted sum of the properties of its gases, the simple mixing rule of the EN 673 glazing calculation. ISO 15099 mixes viscosity and conductivity by a non-linear rule, so a mixture created here is not an ISO 15099 mixture.</para>
        /// </summary>
        /// <param name="name">The name of the mixture. This value can be null.</param>
        /// <param name="fluidMaterials">The gases of the mixture with their volume fractions. This value can be null.</param>
        /// <param name="tolerance">The tolerance within which the volume fractions must add up to 1.</param>
        /// <returns>The <see cref="Classes.FluidMaterial"/> of the mixture, or <see langword="null"/> when there is no gas, a gas is null, a fraction is not between 0 and 1, or the fractions do not add up to 1.</returns>
        public static FluidMaterial? FluidMaterial(string? name, IEnumerable<(FluidMaterial FluidMaterial, double VolumeFraction)>? fluidMaterials, double tolerance = Core.Constants.Tolerance.Distance)
        {
            if (fluidMaterials is null)
            {
                return null;
            }

            FluidMaterial result = new(name);

            int count = 0;
            double volumeFraction_Sum = 0;
            foreach ((FluidMaterial fluidMaterial, double volumeFraction) in fluidMaterials)
            {
                if (fluidMaterial is null || double.IsNaN(volumeFraction) || volumeFraction <= 0 || volumeFraction > 1 + tolerance)
                {
                    return null;
                }

                result.Conductivity += volumeFraction * fluidMaterial.Conductivity;
                result.ConductivityTemperatureCoefficient += volumeFraction * fluidMaterial.ConductivityTemperatureCoefficient;
                result.Density += volumeFraction * fluidMaterial.Density;
                result.DynamicViscosity += volumeFraction * fluidMaterial.DynamicViscosity;
                result.DynamicViscosityTemperatureCoefficient += volumeFraction * fluidMaterial.DynamicViscosityTemperatureCoefficient;
                result.MolarMass += volumeFraction * fluidMaterial.MolarMass;
                result.SpecificHeat += volumeFraction * fluidMaterial.SpecificHeat;
                result.SpecificHeatRatio += volumeFraction * fluidMaterial.SpecificHeatRatio;
                result.SpecificHeatTemperatureCoefficient += volumeFraction * fluidMaterial.SpecificHeatTemperatureCoefficient;

                volumeFraction_Sum += volumeFraction;
                count++;
            }

            if (count == 0 || Math.Abs(volumeFraction_Sum - 1.0) > tolerance)
            {
                return null;
            }

            return result;
        }
    }
}
