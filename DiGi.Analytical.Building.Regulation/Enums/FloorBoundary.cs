using System.ComponentModel;

namespace DiGi.Analytical.Building.Regulation.Enums
{
    /// <summary>
    /// Specifies what the lowest floor of a typology building borders, as TABULA records it (code_constructionborder_floor) (DiGi-Organization/DiGi.Analytical#17).
    /// </summary>
    [Description("Floor boundary")]
    public enum FloorBoundary
    {
        /// <summary>
        /// Undefined floor boundary.
        /// </summary>
        [Description("Undefined")] Undefined,

        /// <summary>
        /// The floor lies on the ground (TABULA "Soil").
        /// </summary>
        [Description("Soil")] Soil,

        /// <summary>
        /// The floor lies over an unheated cellar (TABULA "Cellar"); the cellar adds <see cref="Classes.TypologyData.AdditionalFloorResistance"/>.
        /// </summary>
        [Description("Cellar")] Cellar,
    }
}
