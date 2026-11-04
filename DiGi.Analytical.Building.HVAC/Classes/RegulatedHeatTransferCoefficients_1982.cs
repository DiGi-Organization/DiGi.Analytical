using DiGi.Analytical.Building.HVAC.Enums;
using System.Text.Json.Nodes;

namespace DiGi.Analytical.Building.HVAC.Classes
{
    /// <summary>
    /// Represents the regulated heat transfer coefficients k(max) of PN-82/B-02020 for external partition types, in force from 1 January 1983 until PN-91/B-02020 applies from 1 January 1992 (DiGi-Organization/DiGi.Analytical#20).
    /// <para>The norm text is not available online: the values are those of the secondary tables that reproduce it, and the stage's <see cref="RegulationAct.Description"/> names them, records every candidate in-force date and gives the reason for the date chosen. Values the norm gave in kcal/(m2·h·°C) are converted with 1.163 W/(m2K) per kcal/(m2·h·°C).</para>
    /// </summary>
    public class RegulatedHeatTransferCoefficients_1982 : RegulatedHeatTransferCoefficients<ExternalPartitionType_1982>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegulatedHeatTransferCoefficients_1982"/> class.
        /// </summary>
        /// <param name="regulationAct">The regulation act used to initialize the heat transfer coefficients.</param>
        public RegulatedHeatTransferCoefficients_1982(RegulationAct? regulationAct)
            : base(regulationAct)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegulatedHeatTransferCoefficients_1982"/> class using the specified JSON object.
        /// </summary>
        /// <param name="jsonObject">The <see cref="JsonObject"/> containing the data used to initialize this instance.</param>
        public RegulatedHeatTransferCoefficients_1982(JsonObject jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegulatedHeatTransferCoefficients_1982"/> class using another instance of the same type.
        /// </summary>
        /// <param name="regulatedHeatTransferCoefficients_1982">The source instance to copy from.</param>
        public RegulatedHeatTransferCoefficients_1982(RegulatedHeatTransferCoefficients_1982 regulatedHeatTransferCoefficients_1982)
            : base(regulatedHeatTransferCoefficients_1982)
        {
        }
    }
}
