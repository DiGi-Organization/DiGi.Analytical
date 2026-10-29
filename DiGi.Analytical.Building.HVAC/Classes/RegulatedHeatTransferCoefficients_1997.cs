using DiGi.Analytical.Building.HVAC.Enums;
using System.Text.Json.Nodes;

namespace DiGi.Analytical.Building.HVAC.Classes
{
    /// <summary>
    /// Represents the regulated heat transfer coefficients according to the 1997 amendment of the technical conditions (Dz.U. 1997 nr 132 poz. 878) for external partition types, in force from 29 April 1998 until the 2002 regulation (DiGi-Organization/DiGi.Analytical#14).
    /// <para>The annex sets k(max) limits for a single-family residential building and a public building only - for windows and doors as well. A multi-family or collective-residence building has no U(max) at all: it meets the regulation by its seasonal heat demand indicator E not exceeding E0 (§ 329).</para>
    /// <para>A floor on ground is limited by a minimum sum of thermal resistances R(min) of 1.5 (m2K)/W at ti &gt; 16 °C (point 1.4), not by a heat transfer coefficient; it is held as a minimum thermal resistance.</para>
    /// </summary>
    public class RegulatedHeatTransferCoefficients_1997 : RegulatedHeatTransferCoefficients<ExternalPartitionType_1997>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegulatedHeatTransferCoefficients_1997"/> class.
        /// </summary>
        /// <param name="regulationAct">The regulation act used to initialize the heat transfer coefficients.</param>
        public RegulatedHeatTransferCoefficients_1997(RegulationAct? regulationAct)
            : base(regulationAct)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegulatedHeatTransferCoefficients_1997"/> class using the specified JSON object.
        /// </summary>
        /// <param name="jsonObject">The <see cref="JsonObject"/> containing the data used to initialize this instance.</param>
        public RegulatedHeatTransferCoefficients_1997(JsonObject jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegulatedHeatTransferCoefficients_1997"/> class using another instance of the same type.
        /// </summary>
        /// <param name="regulatedHeatTransferCoefficients_1997">The source instance to copy from.</param>
        public RegulatedHeatTransferCoefficients_1997(RegulatedHeatTransferCoefficients_1997 regulatedHeatTransferCoefficients_1997)
            : base(regulatedHeatTransferCoefficients_1997)
        {
        }
    }
}
