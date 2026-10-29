using System.ComponentModel;

namespace DiGi.Analytical.Building.HVAC.Enums
{
    /// <summary>
    /// Specifies the types of external partition elements for single-family residential and public buildings according to the 1997 amendment of the technical conditions (Dz.U. 1997 nr 132 poz. 878).
    /// <para>The annex has no table for a multi-family or collective-residence building, which meets the regulation by its seasonal heat demand indicator E alone.</para>
    /// </summary>
    public enum ExternalPartitionType_1997
    {
        /// <summary>
        /// Represents a multilayer wall, with insulation of conductivity not above 0.05 W/(mK), of a single-family residential building, at ti &gt; 16 °C.
        /// </summary>
        [Description("Residential building (single-family) multilayer wall")] ResidentialBuilding_Wall_Multilayer,

        /// <summary>
        /// Represents any other external wall of a single-family residential building, at ti &gt; 16 °C.
        /// </summary>
        [Description("Residential building (single-family) solid wall")] ResidentialBuilding_Wall_Solid,

        /// <summary>
        /// Represents a flat roof or a ceiling under an unheated attic or over a passage of a single-family residential building, at ti &gt; 16 °C.
        /// </summary>
        [Description("Residential building (single-family) roof over heated rooms")] ResidentialBuilding_Roof,

        /// <summary>
        /// Represents a ceiling over an unheated basement or a closed underfloor space of a single-family residential building.
        /// </summary>
        [Description("Residential building (single-family) floor over unheated spaces")] ResidentialBuilding_Floor_OverUnheatedSpaces,

        /// <summary>
        /// Represents a floor on ground of a single-family residential building, limited by a minimum thermal resistance rather than a heat transfer coefficient.
        /// </summary>
        [Description("Residential building (single-family) floor on ground")] ResidentialBuilding_Floor,

        /// <summary>
        /// Represents a window (roof windows included), balcony door or fixed glazing of a single-family residential building in climatic zones I, II and III, at ti ≥ 20 °C.
        /// </summary>
        [Description("Residential building (single-family) window, roof window or balcony door (climatic zones I, II, III)")] ResidentialBuilding_Window_ZoneA,

        /// <summary>
        /// Represents a window (roof windows included), balcony door or fixed glazing of a single-family residential building in climatic zones IV and V, at ti ≥ 20 °C.
        /// </summary>
        [Description("Residential building (single-family) window, roof window or balcony door (climatic zones IV, V)")] ResidentialBuilding_Window_ZoneB,

        /// <summary>
        /// Represents an external entrance door of a single-family residential building.
        /// </summary>
        [Description("Residential building (single-family) door")] ResidentialBuilding_Door,

        /// <summary>
        /// Represents a solid external wall of a public building, at ti &gt; 16 °C.
        /// </summary>
        [Description("Public building solid wall")] PublicBuilding_Wall_Solid,

        /// <summary>
        /// Represents an external wall with window and door openings of a public building, at ti &gt; 16 °C.
        /// </summary>
        [Description("Public building wall with window and door openings")] PublicBuilding_Wall_WithWindowAndDoor,

        /// <summary>
        /// Represents an external wall of a public building with balcony brackets penetrating it, at ti &gt; 16 °C.
        /// </summary>
        [Description("Public building wall with balcony brackets penetrating the wall")] PublicBuilding_Wall_WithBalconyBrackets,

        /// <summary>
        /// Represents a flat roof or a ceiling under an unheated attic or over a passage of a public building, at ti &gt; 16 °C.
        /// </summary>
        [Description("Public building roof over heated rooms")] PublicBuilding_Roof,

        /// <summary>
        /// Represents a ceiling over an unheated basement or a closed underfloor space of a public building.
        /// </summary>
        [Description("Public building floor over unheated spaces")] PublicBuilding_Floor_OverUnheatedSpaces,

        /// <summary>
        /// Represents a floor on ground of a public building, limited by a minimum thermal resistance rather than a heat transfer coefficient.
        /// </summary>
        [Description("Public building floor on ground")] PublicBuilding_Floor,

        /// <summary>
        /// Represents a window or balcony door of a public building, at ti ≥ 20 °C (no requirement below 20 °C).
        /// </summary>
        [Description("Public building window or balcony door")] PublicBuilding_Window,

        /// <summary>
        /// Represents an external entrance door of a public building.
        /// </summary>
        [Description("Public building door")] PublicBuilding_Door,
    }
}
