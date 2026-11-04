using System.ComponentModel;

namespace DiGi.Analytical.Building.HVAC.Enums
{
    /// <summary>
    /// Specifies the types of external partition elements limited by the k(max) of PN-64/B-03404, in force from 1 January 1966 until PN-74/B-03404 applies from 1 January 1976 (DiGi-Organization/DiGi.Analytical#20).
    /// <para>The norm sets one k(max) per partition for every building type; a floor on ground has no requirement.</para>
    /// <para>Only the wall limit depends on the climatic zone; the norm's zones are mapped onto the I-III and IV-V grouping of the later regulations.</para>
    /// <para>Windows and doors have no limit: the reproduced tables give none before PN-82/B-02020.</para>
    /// </summary>
    public enum ExternalPartitionType_1964
    {
        /// <summary>
        /// Represents an external wall in climatic zones I, II and III: the looser k(max) the norm set for the milder west of Poland.
        /// </summary>
        [Description("Wall (climatic zones I, II, III)")] Wall_ZoneA,

        /// <summary>
        /// Represents an external wall in climatic zones IV and V: the stricter k(max) the norm set for central and eastern Poland.
        /// </summary>
        [Description("Wall (climatic zones IV, V)")] Wall_ZoneB,

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
    }
}
