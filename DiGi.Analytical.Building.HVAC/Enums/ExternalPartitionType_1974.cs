using System.ComponentModel;

namespace DiGi.Analytical.Building.HVAC.Enums
{
    /// <summary>
    /// Specifies the types of external partition elements limited by the k(max) of PN-74/B-03404, in force from 1 January 1976 until PN-82/B-02020 applies from 1 January 1983 (DiGi-Organization/DiGi.Analytical#20).
    /// <para>The norm sets one k(max) per partition for every building type; a floor on ground has no requirement.</para>
    /// <para>The norm dropped the climatic zones of PN-64/B-03404.</para>
    /// <para>Windows and doors have no limit: the reproduced tables give none before PN-82/B-02020.</para>
    /// </summary>
    public enum ExternalPartitionType_1974
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
    }
}
