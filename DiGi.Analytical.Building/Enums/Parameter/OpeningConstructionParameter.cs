using DiGi.Analytical.Building.Interfaces;
using DiGi.Core.Parameter.Classes;
using System.ComponentModel;

namespace DiGi.Analytical.Building.Enums
{
    /// <summary>
    /// Defines the declared thermal and solar values of an opening construction (DiGi-Organization/DiGi.Analytical#8).
    /// <para>Historical windows and doors are known by their declared values rather than by a layer build-up. The frame and glazing areas and the glazing perimeter are not declared: they come from the construction's outline, a face whose holes are the glazing and whose remainder is the frame.</para>
    /// </summary>
    [AssociatedTypes(typeof(IOpeningConstruction)), Description("Opening construction parameter")]
    public enum OpeningConstructionParameter
    {
        /// <summary>
        /// The declared thermal transmittance of the whole window or door, Uw [W/(m2K)].
        /// </summary>
        [ParameterProperties("ac6451df-668b-4ce9-9f1a-3b581ade2690", "Thermal transmittance", "Thermal transmittance Uw [W/(m2K)]"), DoubleParameterValue(0.0)] ThermalTransmittance,

        /// <summary>
        /// The thermal transmittance of the glazing in its centre, Ug [W/(m2K)].
        /// </summary>
        [ParameterProperties("81e725ad-ab8c-42a0-995d-69d1242b3dbf", "Glazing thermal transmittance", "Glazing thermal transmittance Ug [W/(m2K)]"), DoubleParameterValue(0.0)] GlazingThermalTransmittance,

        /// <summary>
        /// The thermal transmittance of the frame, Uf [W/(m2K)].
        /// </summary>
        [ParameterProperties("ea829e88-ba80-47e5-b31f-f81f61381dcc", "Frame thermal transmittance", "Frame thermal transmittance Uf [W/(m2K)]"), DoubleParameterValue(0.0)] FrameThermalTransmittance,

        /// <summary>
        /// The linear thermal transmittance of the junction between glazing and frame (spacer), Ψg [W/(mK)].
        /// </summary>
        [ParameterProperties("ac648fde-3749-434a-ac82-fa1d4409077e", "Glazing linear thermal transmittance", "Glazing linear thermal transmittance Ψg [W/(mK)]"), DoubleParameterValue(0.0)] GlazingLinearThermalTransmittance,

        /// <summary>
        /// The total solar energy transmittance of the glazing at normal incidence, g [-].
        /// </summary>
        [ParameterProperties("bad49deb-1b5f-408c-aab3-4d9f4bc5318a", "Total solar energy transmittance", "Total solar energy transmittance g [-]"), DoubleParameterValue(0.0, 1.0)] TotalSolarEnergyTransmittance,

        /// <summary>
        /// The light (visible) transmittance of the glazing at normal incidence, τv [-] - with Uw and g, the third value a glazing is declared by (EnergyPlus WindowMaterial:SimpleGlazingSystem: U-factor, SHGC, visible transmittance).
        /// </summary>
        [ParameterProperties("263436cd-47c8-4e27-aa5a-17ca7ad998c9", "Light transmittance", "Light transmittance τv [-]"), DoubleParameterValue(0.0, 1.0)] LightTransmittance,
    }
}
