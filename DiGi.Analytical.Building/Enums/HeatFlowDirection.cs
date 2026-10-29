using System.ComponentModel;

namespace DiGi.Analytical.Building.Enums
{
    /// <summary>
    /// Specifies the direction of the heat flow through a construction, which decides its surface and air-layer resistances (PN-EN ISO 6946; DiGi-Organization/DiGi.Analytical#8).
    /// <para>A heat flow within ±30° of the horizontal plane is horizontal. Where the direction is not fixed or a value independent of it is required, the standard recommends the horizontal values.</para>
    /// </summary>
    [Description("Heat Flow Direction")]
    public enum HeatFlowDirection
    {
        /// <summary>
        /// The direction is not known; surface and air-layer resistances are not available.
        /// </summary>
        [Description("Undefined")] Undefined,

        /// <summary>
        /// Upward heat flow - a roof or a ceiling heated from below.
        /// </summary>
        [Description("Upward")] Upward,

        /// <summary>
        /// Horizontal heat flow - a wall.
        /// </summary>
        [Description("Horizontal")] Horizontal,

        /// <summary>
        /// Downward heat flow - a floor over an unheated or outside space.
        /// </summary>
        [Description("Downward")] Downward,
    }
}
