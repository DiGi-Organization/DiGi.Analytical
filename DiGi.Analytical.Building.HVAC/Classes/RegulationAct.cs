using DiGi.Analytical.Building.HVAC.Interfaces;
using DiGi.Core.Classes;
using DiGi.Core.Interfaces;
using System;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Analytical.Building.HVAC.Classes
{
    /// <summary>
    /// Represents a regulatory act associated with HVAC systems, providing details such as publication date, effective date, reference, name, and description.
    /// </summary>
    public class RegulationAct : SerializableObject, IHVACNamedObject, IDescribableObject
    {
        [JsonInclude, JsonPropertyName(nameof(Description))]
        private readonly string? description;

        [JsonInclude, JsonPropertyName(nameof(EffectiveDate))]
        private readonly DateTime effectiveDate;

        [JsonInclude, JsonPropertyName(nameof(Name))]
        private readonly string? name;

        [JsonInclude, JsonPropertyName(nameof(PublicAuthorityEffectiveDate))]
        private readonly DateTime? publicAuthorityEffectiveDate;

        [JsonInclude, JsonPropertyName(nameof(PublicationDate))]
        private readonly DateTime publicationDate;

        [JsonInclude, JsonPropertyName(nameof(Reference))]
        private readonly string? reference;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegulationAct"/> class.
        /// </summary>
        /// <param name="publicationDate">The date when the regulation act was published.</param>
        /// <param name="effectiveDate">The date when the regulation act becomes effective.</param>
        /// <param name="reference">The reference identifier for the regulation act.</param>
        /// <param name="name">The name of the regulation act.</param>
        /// <param name="descriprion">The description of the regulation act.</param>
        public RegulationAct(DateTime publicationDate, DateTime effectiveDate, string? reference, string? name, string? descriprion)
            : this(publicationDate, effectiveDate, null, reference, name, descriprion)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegulationAct"/> class whose requirements apply earlier to buildings of public authorities.
        /// </summary>
        /// <param name="publicationDate">The date when the regulation act was published.</param>
        /// <param name="effectiveDate">The date from which the requirements apply.</param>
        /// <param name="publicAuthorityEffectiveDate">The earlier date from which the requirements apply to a building occupied and owned by a public authority, or null when the act sets none.</param>
        /// <param name="reference">The reference identifier for the regulation act.</param>
        /// <param name="name">The name of the regulation act.</param>
        /// <param name="descriprion">The description of the regulation act.</param>
        public RegulationAct(DateTime publicationDate, DateTime effectiveDate, DateTime? publicAuthorityEffectiveDate, string? reference, string? name, string? descriprion)
            : base()
        {
            this.publicationDate = publicationDate;
            this.effectiveDate = effectiveDate;
            this.publicAuthorityEffectiveDate = publicAuthorityEffectiveDate;
            this.reference = reference;
            this.name = name;
            this.description = descriprion;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegulationAct"/> class using the provided <see cref="JsonObject"/>.
        /// </summary>
        /// <param name="jsonObject">The <see cref="JsonObject"/> used to populate the properties of the regulation act.</param>
        public RegulationAct(JsonObject jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegulationAct"/> class by copying the values from an existing <see cref="RegulationAct"/> instance.
        /// </summary>
        /// <param name="regulationAct">The source <see cref="RegulationAct"/> object to copy data from.</param>
        public RegulationAct(RegulationAct regulationAct)
            : base(regulationAct)
        {
            if (regulationAct is not null)
            {
                publicationDate = regulationAct.PublicationDate;
                effectiveDate = regulationAct.EffectiveDate;
                publicAuthorityEffectiveDate = regulationAct.PublicAuthorityEffectiveDate;
                reference = regulationAct.Reference;
                name = regulationAct.Name;
                description = regulationAct.Description;
            }
        }

        /// <summary>
        /// Gets the description of the regulation act.
        /// </summary>
        [JsonIgnore]
        public string? Description
        {
            get
            {
                return description;
            }
        }

        /// <summary>
        /// Gets the date from which the requirements of the regulation act apply.
        /// <para>For an act that sets its requirements in stages this is the date of the stage, not the date the act came into force: the 2017 U-value limits of Dz.U. 2013 poz. 926 apply from 1 January 2017 (DiGi-Organization/DiGi.Analytical#11).</para>
        /// </summary>
        [JsonIgnore]
        public DateTime EffectiveDate
        {
            get
            {
                return effectiveDate;
            }
        }

        /// <summary>
        /// Gets the name of the regulation act.
        /// </summary>
        [JsonIgnore]
        public string? Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// Gets the earlier date from which the requirements apply to a building occupied and owned by a public authority, or null when the act sets none.
        /// <para>The last stage of the U-value limits applies from 31 December 2020, but from 1 January 2019 to a building occupied and owned by a judicial body, a prosecutor's office or a public administration body (Dz.U. 2017 poz. 2285, Annex 2).</para>
        /// </summary>
        [JsonIgnore]
        public DateTime? PublicAuthorityEffectiveDate
        {
            get
            {
                return publicAuthorityEffectiveDate;
            }
        }

        /// <summary>
        /// Gets the publication date of the regulation act.
        /// </summary>
        [JsonIgnore]
        public DateTime PublicationDate
        {
            get
            {
                return publicationDate;
            }
        }

        /// <summary>
        /// Gets the reference identifier for the regulation act.
        /// </summary>
        [JsonIgnore]
        public string? Reference
        {
            get
            {
                return reference;
            }
        }
    }
}