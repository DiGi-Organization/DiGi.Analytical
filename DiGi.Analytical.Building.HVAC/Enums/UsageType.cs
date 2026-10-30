using System.ComponentModel;

namespace DiGi.Analytical.Building.HVAC.Enums
{
    /// <summary>
    /// Specifies how a building is used, as the Polish energy-certificate methodology distinguishes it (Dz.U. 2015 poz. 376, Annex 1, Tables 23-27) (DiGi-Organization/DiGi.Analytical#9).
    /// <para>Each value is one row of those tables, so a usage type selects the internal gains, outside airflow and hot water of a usage profile.</para>
    /// </summary>
    [Description("Usage type")]
    public enum UsageType
    {
        /// <summary>
        /// Undefined usage type.
        /// </summary>
        [Description("Undefined")] Undefined,

        /// <summary>
        /// Single-family residential building (budynek mieszkalny jednorodzinny).
        /// </summary>
        [Description("Single-family")] SingleFamily,

        /// <summary>
        /// Multi-family residential building (budynek mieszkalny wielorodzinny).
        /// </summary>
        [Description("Multi-family")] MultiFamily,

        /// <summary>
        /// Collective residence (budynek zamieszkania zbiorowego): dormitories, care homes, hostels.
        /// </summary>
        [Description("Collective residence")] CollectiveResidence,

        /// <summary>
        /// Office building (budynek biurowy).
        /// </summary>
        [Description("Office")] Office,

        /// <summary>
        /// Building for education, higher education and science (oświata, szkolnictwo wyższe, nauka).
        /// </summary>
        [Description("Education")] Education,

        /// <summary>
        /// Building for healthcare (opieka zdrowotna).
        /// </summary>
        [Description("Healthcare")] Healthcare,

        /// <summary>
        /// Building for gastronomy (gastronomia).
        /// </summary>
        [Description("Gastronomy")] Gastronomy,

        /// <summary>
        /// Building for sport (sport).
        /// </summary>
        [Description("Sport")] Sport,

        /// <summary>
        /// Building for retail and services (handel, usługi).
        /// </summary>
        [Description("Retail")] Retail,

        /// <summary>
        /// Storage building (budynek magazynowy).
        /// </summary>
        [Description("Storage")] Storage,

        /// <summary>
        /// Production building (budynek produkcyjny). The methodology sets its values "individually"; the usage profile fills them from ASHRAE 90.1 light manufacturing.
        /// </summary>
        [Description("Production")] Production,
    }
}
