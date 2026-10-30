using DiGi.Analytical.Classes;

namespace DiGi.Analytical
{
    public static partial class Query
    {
        /// <summary>
        /// Gets the properties of a fluid material at the specified temperature (DiGi-Organization/DiGi.Analytical#8).
        /// <para>Conductivity, dynamic viscosity and specific heat follow the linear temperature dependence of ISO 15099: value(T) = value + coefficient · (T − <see cref="FluidMaterial.ReferenceTemperature"/>). The density follows the ideal gas at constant pressure: ρ(T) = ρ · <see cref="FluidMaterial.ReferenceTemperature"/> / T. At the reference temperature, 283 K, the stored values are returned as they are.</para>
        /// </summary>
        /// <param name="fluidMaterial">The fluid material. This value can be null.</param>
        /// <param name="temperature">The temperature [K].</param>
        /// <returns>The conductivity [W/(mK)], density [kg/m3], dynamic viscosity [kg/(ms)] and specific heat [J/(kgK)] at the temperature, or NaN for each when the material is null or the temperature is NaN or not above 0 K.</returns>
        public static (double Conductivity, double Density, double DynamicViscosity, double SpecificHeat) FluidProperties(this FluidMaterial? fluidMaterial, double temperature)
        {
            if (fluidMaterial is null || double.IsNaN(temperature) || temperature <= 0)
            {
                return (double.NaN, double.NaN, double.NaN, double.NaN);
            }

            double temperatureDifference = temperature - FluidMaterial.ReferenceTemperature;

            return (fluidMaterial.Conductivity + (fluidMaterial.ConductivityTemperatureCoefficient * temperatureDifference),
                fluidMaterial.Density * FluidMaterial.ReferenceTemperature / temperature,
                fluidMaterial.DynamicViscosity + (fluidMaterial.DynamicViscosityTemperatureCoefficient * temperatureDifference),
                fluidMaterial.SpecificHeat + (fluidMaterial.SpecificHeatTemperatureCoefficient * temperatureDifference));
        }
    }
}
