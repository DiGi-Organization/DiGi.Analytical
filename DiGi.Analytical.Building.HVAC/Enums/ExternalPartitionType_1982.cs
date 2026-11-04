using System.ComponentModel;

namespace DiGi.Analytical.Building.HVAC.Enums
{
    /// <summary>
    /// Specifies the types of external partition elements limited by the k(max) of PN-82/B-02020, in force from 1 January 1983 until PN-91/B-02020 applies from 1 January 1992 (DiGi-Organization/DiGi.Analytical#20).
    /// <para>The norm sets one k(max) per partition for every building type; a floor on ground has no requirement.</para>
    /// </summary>
    public enum ExternalPartitionType_1982
    {
        /// <summary>
        /// Represents an external wall.
        /// </summary>
        [Description("Wall")] Wall,

        /// <summary>
        /// Represents a ceiling under an unheated attic (strop pod poddaszem).
        /// </summary>
        [Description("Ceiling under an unheated attic")] Roof_TopCeiling,

        /// <summary>
        /// Represents a flat roof over heated rooms (stropodach).
        /// </summary>
        [Description("Flat roof")] Roof_Flat,

        /// <summary>
        /// Represents a ceiling over an unheated cellar or a closed underfloor space.
        /// </summary>
        [Description("Floor over unheated spaces")] Floor_OverUnheatedSpaces,

        /// <summary>
        /// Represents a window or balcony door in climatic zones I, II and III; the norm has no separate roof window row, so a roof window takes this limit too.
        /// </summary>
        [Description("Window or balcony door (climatic zones I, II, III)")] Window_ZoneA,

        /// <summary>
        /// Represents a window or balcony door in climatic zones IV and V; the norm has no separate roof window row, so a roof window takes this limit too.
        /// </summary>
        [Description("Window or balcony door (climatic zones IV, V)")] Window_ZoneB,

        /// <summary>
        /// Represents an external entrance door.
        /// </summary>
        [Description("Door")] Door,
    }
}
