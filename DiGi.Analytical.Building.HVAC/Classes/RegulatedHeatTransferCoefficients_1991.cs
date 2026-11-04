using DiGi.Analytical.Building.HVAC.Enums;
using System.Text.Json.Nodes;

namespace DiGi.Analytical.Building.HVAC.Classes
{
    /// <summary>
    /// Represents the regulated heat transfer coefficients k(max) of PN-91/B-02020 for external partition types, in force from 1 January 1992 until the k(max) annex of Dz.U. 1997 nr 132 poz. 878 applies from 29 April 1998 (DiGi-Organization/DiGi.Analytical#20).
    /// <para>The norm text is not available online: the values are those of the secondary tables that reproduce it, and the stage's <see cref="RegulationAct.Description"/> names them, records every candidate in-force date and gives the reason for the date chosen. Values the norm gave in kcal/(m2·h·°C) are converted with 1.163 W/(m2K) per kcal/(m2·h·°C).</para>
    /// </summary>
    public class RegulatedHeatTransferCoefficients_1991 : RegulatedHeatTransferCoefficients<ExternalPartitionType_1991>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegulatedHeatTransferCoefficients_1991"/> class.
        /// </summary>
        /// <param name="regulationAct">The regulation act used to initialize the heat transfer coefficients.</param>
        public RegulatedHeatTransferCoefficients_1991(RegulationAct? regulationAct)
            : base(regulationAct)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegulatedHeatTransferCoefficients_1991"/> class using the specified JSON object.
        /// </summary>
        /// <param name="jsonObject">The <see cref="JsonObject"/> containing the data used to initialize this instance.</param>
        public RegulatedHeatTransferCoefficients_1991(JsonObject jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegulatedHeatTransferCoefficients_1991"/> class using another instance of the same type.
        /// </summary>
        /// <param name="regulatedHeatTransferCoefficients_1991">The source instance to copy from.</param>
        public RegulatedHeatTransferCoefficients_1991(RegulatedHeatTransferCoefficients_1991 regulatedHeatTransferCoefficients_1991)
            : base(regulatedHeatTransferCoefficients_1991)
        {
        }
    }
}
