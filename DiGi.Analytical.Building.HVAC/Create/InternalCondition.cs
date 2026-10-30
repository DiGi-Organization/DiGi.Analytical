using DiGi.Analytical.Building.Classes;
using DiGi.Analytical.Building.HVAC.Classes;
using DiGi.Analytical.Building.HVAC.Enums;
using System.Collections.Generic;
using System.Globalization;

namespace DiGi.Analytical.Building.HVAC
{
    public static partial class Create
    {
        /// <summary>
        /// Creates the internal condition of a building from its usage profile (DiGi-Organization/DiGi.Analytical#9).
        /// <para>It holds a thermostat lower limit at <see cref="UsageProfile.HeatingSetPoint"/> (continuous heating: neither source gives a set-back), a <see cref="InternalGainProfileType.TotalInternalGain"/> profile [W/m2] - constant, or the weekly profile when the usage profile has one - and an <see cref="InternalGainProfileType.Infiltration"/> profile [1/h] of 0.2 for a building erected after 1995 and 0.3 otherwise or when unknown (Dz.U. 2015 poz. 376, Annex 1, eq. 70). <see cref="SystemProperties"/> holds the hot water V_Wi · k_R [l/(d m2)], the outside airflow per area [l/(s m2)] and the sensible gain per person as the metabolic rate; ventilation stays per area, as converting it to air changes needs the volume of each space.</para>
        /// <para><b>Occupancy scaling.</b> With <paramref name="occupancy"/> and <paramref name="floorArea"/> both positive, the people share of the values follows the actual persons instead of the standard occupancy of <see cref="UsageProfile.FloorAreaPerPerson"/>: the hot water is multiplied by persons · a_std / A, and the internal gain is shifted by (persons / A - 1 / a_std) · <see cref="UsageProfile.PersonGain"/>, never below 0. This departs from the per-area values of the methodology, so <see cref="InternalConditionParameter.OccupancyScaled"/> records it.</para>
        /// <para><b>Provenance.</b> The name is the usage type, the description and <see cref="InternalConditionParameter.UsageSource"/> carry <see cref="UsageProfile.Source"/>, and <see cref="InternalConditionParameter.UsageType"/>, <see cref="InternalConditionParameter.Occupancy"/>, <see cref="InternalConditionParameter.OccupancySource"/> and <see cref="InternalConditionParameter.OccupancyScaled"/> are set.</para>
        /// </summary>
        /// <param name="usageProfile">The usage profile, from <see cref="UsageProfile(UsageType, double?, double?, bool, bool)"/>.</param>
        /// <param name="yearBuilt">The year the building was erected (or its windows replaced); null when unknown.</param>
        /// <param name="occupancy">The number of persons in the building; null when unknown.</param>
        /// <param name="floorArea">The heated floor area of the building [m2], the area the persons share; null when unknown.</param>
        /// <param name="occupancySource">Where <paramref name="occupancy"/> comes from. This value can be null.</param>
        /// <returns>The internal condition, or null when <paramref name="usageProfile"/> is null.</returns>
        public static Building.Classes.InternalCondition? InternalCondition(this Classes.UsageProfile? usageProfile, int? yearBuilt = null, double? occupancy = null, double? floorArea = null, string? occupancySource = null)
        {
            if (usageProfile is null)
            {
                return null;
            }

            double domesticHotWater = usageProfile.DomesticHotWater * usageProfile.DomesticHotWaterCorrection;
            double internalHeatGain_Shift = 0.0;

            bool scaled = occupancy is double persons && floorArea is double area && persons > 0 && area > 0 && usageProfile.FloorAreaPerPerson > 0;
            if (scaled)
            {
                double persons_PerArea = occupancy!.Value / floorArea!.Value;
                domesticHotWater *= persons_PerArea * usageProfile.FloorAreaPerPerson;
                internalHeatGain_Shift = (persons_PerArea - (1.0 / usageProfile.FloorAreaPerPerson)) * usageProfile.PersonGain;
            }

            List<double> internalHeatGains = usageProfile.InternalHeatGainProfile ?? [usageProfile.InternalHeatGain];
            for (int i = 0; i < internalHeatGains.Count; i++)
            {
                internalHeatGains[i] = System.Math.Max(0.0, internalHeatGains[i] + internalHeatGain_Shift);
            }

            double infiltration = yearBuilt is int year && year > 1995 ? 0.2 : 0.3;

            Building.Classes.InternalCondition result = new(usageProfile.UsageType.ToString())
            {
                Description = usageProfile.Source,
            };

            Thermostat thermostat = new()
            {
                Name = result.Name,
            };

            thermostat[ThermostatProfileType.LowerLimit] = new Profile([usageProfile.HeatingSetPoint]);

            InternalGain internalGain = new()
            {
                Name = result.Name,
            };

            internalGain[InternalGainProfileType.TotalInternalGain] = new Profile(internalHeatGains);
            internalGain[InternalGainProfileType.Infiltration] = new Profile([infiltration]);

            SystemProperties systemProperties = new()
            {
                DomesticHotWater = domesticHotWater,
                OutsideAirPerArea = usageProfile.OutsideAirPerArea,
                MetabolicRate = usageProfile.PersonGain,
            };

            string infiltrationSource = UsageProfileSource_PL376 + ": eq. 70, " + infiltration.ToString(CultureInfo.InvariantCulture) + " 1/h, " + (yearBuilt is null ? "year built unknown" : "built " + yearBuilt.Value.ToString(CultureInfo.InvariantCulture));

            result.SetThermostat(thermostat);
            result.SetInternalGain(internalGain);
            result.SetSystemProperties(systemProperties);
            result.SetValue(InternalConditionParameter.UsageType, usageProfile.UsageType.ToString());
            result.SetValue(InternalConditionParameter.UsageSource, usageProfile.Source + "; Infiltration: " + infiltrationSource);
            result.SetValue(InternalConditionParameter.OccupancyScaled, scaled);

            if (occupancy is double occupancy_Value)
            {
                result.SetValue(InternalConditionParameter.Occupancy, occupancy_Value);
            }

            if (occupancySource is not null)
            {
                result.SetValue(InternalConditionParameter.OccupancySource, occupancySource);
            }

            return result;
        }
    }
}
