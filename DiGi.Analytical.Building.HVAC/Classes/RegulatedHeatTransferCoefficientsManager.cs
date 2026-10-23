using DiGi.Analytical.Building.HVAC.Interfaces;
using DiGi.Core.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Analytical.Building.HVAC.Classes
{
    /// <summary>
    /// Manages the collection and retrieval of regulated heat transfer coefficients associated with specific timestamps.
    /// </summary>
    public class RegulatedHeatTransferCoefficientsManager : SerializableObject, IHVACObject
    {
        [JsonInclude, JsonPropertyName("Values")]
        private readonly SortedDictionary<DateTime, IRegulatedHeatTransferCoefficients> values = [];

        /// <summary>
        /// Initializes a new instance of the <see cref="RegulatedHeatTransferCoefficientsManager"/> class.
        /// </summary>
        public RegulatedHeatTransferCoefficientsManager()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegulatedHeatTransferCoefficientsManager"/> class from the specified JSON object.
        /// </summary>
        /// <param name="jsonObject">The <see cref="JsonObject"/> used to populate the properties of the manager.</param>
        public RegulatedHeatTransferCoefficientsManager(JsonObject jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegulatedHeatTransferCoefficientsManager"/> class by copying the specified instance.
        /// </summary>
        /// <param name="regulatedHeatTransferCoefficientsManager">The source <see cref="RegulatedHeatTransferCoefficientsManager"/> instance to copy from.</param>
        public RegulatedHeatTransferCoefficientsManager(RegulatedHeatTransferCoefficientsManager regulatedHeatTransferCoefficientsManager)
            : base(regulatedHeatTransferCoefficientsManager)
        {
            if (regulatedHeatTransferCoefficientsManager is not null)
            {
                foreach (IRegulatedHeatTransferCoefficients regulatedHeatTransferCoefficients in values.Values)
                {
                    Add(regulatedHeatTransferCoefficients);
                }
            }
        }

        /// <summary>
        /// Adds a regulated heat transfer coefficient to the manager.
        /// </summary>
        /// <param name="regulatedHeatTransferCoefficients">The regulated heat transfer coefficients to add.</param>
        /// <returns>True if the regulated heat transfer coefficients were successfully added; otherwise, false.</returns>
        public bool Add(IRegulatedHeatTransferCoefficients? regulatedHeatTransferCoefficients)
        {
            if (regulatedHeatTransferCoefficients?.RegulationAct is not RegulationAct regulationAct)
            {
                return false;
            }

            values[regulationAct.EffectiveDate] = regulatedHeatTransferCoefficients;
            return true;
        }

        /// <summary>
        /// Retrieves the regulated heat transfer coefficients applicable for the specified date and time.
        /// </summary>
        /// <param name="dateTime">The date and time used to determine the active regulated heat transfer coefficients.</param>
        /// <returns>The <see cref="IRegulatedHeatTransferCoefficients"/> corresponding to the provided date, or <c>null</c> if no applicable coefficients are found.</returns>
        public IRegulatedHeatTransferCoefficients? GetRegulatedHeatTransferCoefficients(DateTime dateTime)
        {
            return GetRegulatedHeatTransferCoefficients(dateTime, false);
        }

        /// <summary>
        /// Retrieves the regulated heat transfer coefficients applicable for the specified date and time, for a building of a public authority or for any other building.
        /// <para>The coefficients that apply are those with the latest date on or before <paramref name="dateTime"/>. For a public-authority building that date is the act's <see cref="RegulationAct.PublicAuthorityEffectiveDate"/> where the act sets one, so the last stage of the U-value limits applies to it from 1 January 2019 instead of 31 December 2020 (DiGi-Organization/DiGi.Analytical#11).</para>
        /// </summary>
        /// <param name="dateTime">The date and time used to determine the active regulated heat transfer coefficients.</param>
        /// <param name="publicAuthority">Whether the building is occupied and owned by a judicial body, a prosecutor's office or a public administration body.</param>
        /// <returns>The <see cref="IRegulatedHeatTransferCoefficients"/> corresponding to the provided date, or <c>null</c> if no applicable coefficients are found.</returns>
        public IRegulatedHeatTransferCoefficients? GetRegulatedHeatTransferCoefficients(DateTime dateTime, bool publicAuthority)
        {
            if (values is null || values.Count == 0)
            {
                return null;
            }

            IRegulatedHeatTransferCoefficients? result = null;
            DateTime dateTime_Result = DateTime.MinValue;
            foreach (KeyValuePair<DateTime, IRegulatedHeatTransferCoefficients> keyValuePair in values)
            {
                DateTime dateTime_Applicable = keyValuePair.Key;
                if (publicAuthority && keyValuePair.Value?.RegulationAct?.PublicAuthorityEffectiveDate is DateTime publicAuthorityEffectiveDate && publicAuthorityEffectiveDate < dateTime_Applicable)
                {
                    dateTime_Applicable = publicAuthorityEffectiveDate;
                }

                if (dateTime_Applicable > dateTime)
                {
                    continue;
                }

                if (result is null || dateTime_Applicable >= dateTime_Result)
                {
                    result = keyValuePair.Value;
                    dateTime_Result = dateTime_Applicable;
                }
            }

            return result;
        }

        /// <summary>
        /// Retrieves a list of regulated heat transfer coefficients filtered by the specified type.
        /// </summary>
        /// <typeparam name="TRegulatedHeatTransferCoefficients">The specific type of regulated heat transfer coefficients to retrieve, which must implement <see cref="IRegulatedHeatTransferCoefficients"/>.</typeparam>
        /// <returns>A list of all instances that match the specified type <typeparamref name="TRegulatedHeatTransferCoefficients"/>.</returns>
        public List<TRegulatedHeatTransferCoefficients> RegulatedHeatTransferCoefficients<TRegulatedHeatTransferCoefficients>() where TRegulatedHeatTransferCoefficients : IRegulatedHeatTransferCoefficients
        {
            List<TRegulatedHeatTransferCoefficients> result = [];
            foreach (IRegulatedHeatTransferCoefficients regulatedHeatTransferCoefficients in values.Values)
            {
                if (regulatedHeatTransferCoefficients is TRegulatedHeatTransferCoefficients regulatedHeatTransferCoefficients_Temp)
                {
                    result.Add(regulatedHeatTransferCoefficients_Temp);
                }
            }

            return result;
        }
    }
}