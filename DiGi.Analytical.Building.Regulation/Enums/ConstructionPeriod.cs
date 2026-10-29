using System.ComponentModel;

namespace DiGi.Analytical.Building.Regulation.Enums
{
    /// <summary>
    /// Specifies the construction period of a Polish residential building, as used by the TABULA / EPISCOPE Polish typology of NAPE (DiGi-Organization/DiGi.Analytical#8).
    /// <para>The periods are of construction (year built), so no design lag applies to them.</para>
    /// </summary>
    [Description("Construction Period")]
    public enum ConstructionPeriod
    {
        /// <summary>The period is not known.</summary>
        [Description("Undefined")] Undefined,

        /// <summary>Built in 1945 or earlier.</summary>
        [Description("Until 1945")] Until1945,

        /// <summary>Built 1946-1966.</summary>
        [Description("1946-1966")] From1946To1966,

        /// <summary>Built 1967-1985: the large-panel period.</summary>
        [Description("1967-1985")] From1967To1985,

        /// <summary>Built 1986-1992.</summary>
        [Description("1986-1992")] From1986To1992,

        /// <summary>Built 1993-2002.</summary>
        [Description("1993-2002")] From1993To2002,

        /// <summary>Built 2003-2008.</summary>
        [Description("2003-2008")] From2003To2008,

        /// <summary>Built in 2009 or later.</summary>
        [Description("From 2009")] From2009,
    }
}
