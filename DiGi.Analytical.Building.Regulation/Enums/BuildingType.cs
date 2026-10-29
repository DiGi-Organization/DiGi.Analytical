using System.ComponentModel;

namespace DiGi.Analytical.Building.Regulation.Enums
{
    /// <summary>
    /// Specifies the residential building type of the TABULA / EPISCOPE typology (DiGi-Organization/DiGi.Analytical#8).
    /// <para>For the regulations, a single-family and a terraced house are single-family buildings, and a multi-family building and an apartment block are multi-family buildings.</para>
    /// </summary>
    [Description("Building Type")]
    public enum BuildingType
    {
        /// <summary>The type is not known.</summary>
        [Description("Undefined")] Undefined,

        /// <summary>A detached single-family house (TABULA SFH).</summary>
        [Description("Single-family house")] SingleFamily,

        /// <summary>A terraced or semi-detached house (TABULA TH).</summary>
        [Description("Terraced house")] Terraced,

        /// <summary>A multi-family house (TABULA MFH).</summary>
        [Description("Multi-family house")] MultiFamily,

        /// <summary>An apartment block or tower block (TABULA AB).</summary>
        [Description("Apartment block")] ApartmentBlock,
    }
}
