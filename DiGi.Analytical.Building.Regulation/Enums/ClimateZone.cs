using System.ComponentModel;

namespace DiGi.Analytical.Building.Regulation.Enums
{
    /// <summary>
    /// Specifies the Polish climatic zone of PN-82/B-02403, on which the window limits of the regulations until 2013 depend (zones I-III against IV-V) (DiGi-Organization/DiGi.Analytical#8).
    /// </summary>
    [Description("Climate Zone")]
    public enum ClimateZone
    {
        /// <summary>The zone is not known.</summary>
        [Description("Undefined")] Undefined,

        /// <summary>Climatic zone I (design outdoor temperature -16 °C).</summary>
        [Description("Zone I")] I,

        /// <summary>Climatic zone II (-18 °C).</summary>
        [Description("Zone II")] II,

        /// <summary>Climatic zone III (-20 °C).</summary>
        [Description("Zone III")] III,

        /// <summary>Climatic zone IV (-22 °C).</summary>
        [Description("Zone IV")] IV,

        /// <summary>Climatic zone V (-24 °C).</summary>
        [Description("Zone V")] V,
    }
}
