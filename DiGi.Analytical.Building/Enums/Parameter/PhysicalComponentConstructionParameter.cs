using DiGi.Analytical.Building.Interfaces;
using DiGi.Core.Parameter.Classes;
using System.ComponentModel;

namespace DiGi.Analytical.Building.Enums
{
    /// <summary>
    /// Defines the declared values of a wall, roof or floor construction (DiGi-Organization/DiGi.Analytical#8).
    /// </summary>
    [AssociatedTypes(typeof(IPhysicalComponentConstruction)), Description("Physical component construction parameter")]
    public enum PhysicalComponentConstructionParameter
    {
        /// <summary>
        /// The declared thermal transmittance U [W/(m2K)], for a construction known by its U rather than by its layers - a floor on ground, or a historical assembly. When set it takes precedence over the value computed from the layers.
        /// </summary>
        [ParameterProperties("dd75f81b-c273-405e-8f49-342bae40c07d", "Thermal transmittance", "Thermal transmittance U [W/(m2K)]"), DoubleParameterValue(0.0)] ThermalTransmittance,
    }
}
