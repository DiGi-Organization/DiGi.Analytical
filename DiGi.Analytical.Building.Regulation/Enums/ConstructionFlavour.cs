using System.ComponentModel;

namespace DiGi.Analytical.Building.Regulation.Enums
{
    /// <summary>
    /// Specifies which kind of construction a construction set describes (DiGi-Organization/DiGi.Analytical#8).
    /// </summary>
    [Description("Construction Flavour")]
    public enum ConstructionFlavour
    {
        /// <summary>The flavour is not known.</summary>
        [Description("Undefined")] Undefined,

        /// <summary>The minimum assemblies meeting the thermal limits of the regulation in force; looked up by design date.</summary>
        [Description("Regulation")] Regulation,

        /// <summary>The assemblies typically built in the period (TABULA / NAPE), usually worse than the regulation; looked up by year built.</summary>
        [Description("Typical as built")] TypicalAsBuilt,
    }
}
