using DiGi.Analytical.Building.HVAC.Enums;
using System.Text.Json.Nodes;

namespace DiGi.Analytical.Building.HVAC.Classes
{
    /// <summary>
    /// Represents the regulated heat transfer coefficients according to the 2002 regulation standards for external partition types.
    /// <para>Annex 2 of the regulation (Dz.U. 2002 nr 75 poz. 690) sets the wall, roof and basement ceiling limits of a residential building in the single-family building table only. A multi-family or collective-residence building has no wall or roof U(max): it meets the regulation by its seasonal heat demand indicator E not exceeding E0 (§ 329). The window and door limits apply to every residential building.</para>
    /// <para>A floor on ground is limited by a minimum sum of thermal resistances R(min) of 1.5 (m2K)/W at ti &gt; 16 °C (point 1.4), not by a heat transfer coefficient; it is held as a minimum thermal resistance (DiGi-Organization/DiGi.Analytical#12).</para>
    /// </summary>
    public class RegulatedHeatTransferCoefficients_2002 : RegulatedHeatTransferCoefficients<ExternalPartitionType_2002>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegulatedHeatTransferCoefficients_2002"/> class.
        /// </summary>
        /// <param name="regulationAct">The regulation act used to initialize the heat transfer coefficients.</param>
        public RegulatedHeatTransferCoefficients_2002(RegulationAct? regulationAct)
            : base(regulationAct)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegulatedHeatTransferCoefficients_2002"/> class using the specified JSON object.
        /// </summary>
        /// <param name="jsonObject">The <see cref="JsonObject"/> containing the data used to initialize this instance.</param>
        public RegulatedHeatTransferCoefficients_2002(JsonObject jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegulatedHeatTransferCoefficients_2002"/> class using another instance of the same type.
        /// </summary>
        /// <param name="regulatedHeatTransferCoefficients_2002">The source instance to copy from.</param>
        public RegulatedHeatTransferCoefficients_2002(RegulatedHeatTransferCoefficients_2002 regulatedHeatTransferCoefficients_2002)
            : base(regulatedHeatTransferCoefficients_2002)
        {
        }
    }
}