using System.ComponentModel;

namespace DiGi.Analytical.Building.Regulation.Enums
{
    /// <summary>
    /// Specifies the roof type of a typology building, as TABULA records it (code_rooftype) (DiGi-Organization/DiGi.Analytical#17).
    /// </summary>
    [Description("Roof type")]
    public enum RoofType
    {
        /// <summary>
        /// Undefined roof type.
        /// </summary>
        [Description("Undefined")] Undefined,

        /// <summary>
        /// A pitched roof (TABULA "TR").
        /// </summary>
        [Description("Pitched")] Pitched,

        /// <summary>
        /// A flat roof (TABULA "FR").
        /// </summary>
        [Description("Flat")] Flat,
    }
}
