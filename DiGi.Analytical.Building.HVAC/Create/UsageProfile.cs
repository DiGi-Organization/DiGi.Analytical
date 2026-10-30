using DiGi.Analytical.Building.HVAC.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DiGi.Analytical.Building.HVAC
{
    public static partial class Create
    {
        /// <summary>
        /// The source tag of a value from the Polish energy-certificate methodology, Dz.U. 2015 poz. 376, Annex 1 (amended by Dz.U. 2017 poz. 22, 2019 poz. 1829 and 2023 poz. 697, none of which changes Tables 23-27).
        /// </summary>
        public const string UsageProfileSource_PL376 = "PL-376";

        /// <summary>
        /// The source tag of a value from the technical conditions, Dz.U. 2022 poz. 1225 (consolidated text), § 134 ust. 2.
        /// </summary>
        public const string UsageProfileSource_PLWT = "PL-WT";

        /// <summary>
        /// The source tag of a value from ASHRAE Standard 90.1-1989 and addenda, as published in the Seattle Energy Code 2018, Appendix B (Tables B102 and B103).
        /// </summary>
        public const string UsageProfileSource_ASHRAE = "ASHRAE-90.1";

        /// <summary>
        /// The source tag of an uncited value, to be replaced by a cited one.
        /// </summary>
        public const string UsageProfileSource_Default = "DEFAULT";

        /// <summary>
        /// Creates the standard-use profile of a building of the given usage type: heating set-point, internal gains, outside airflow and hot water per area, each value with its source (DiGi-Organization/DiGi.Analytical#9).
        /// <para><b>Sources, in order of precedence.</b> A value is taken from the first source that has it: the Polish energy-certificate methodology (<see cref="UsageProfileSource_PL376"/>: q_int Table 26, k_R and V_Wi Table 27, outside airflow Tables 23-25), the technical conditions (<see cref="UsageProfileSource_PLWT"/>: the heating temperatures of § 134 ust. 2), ASHRAE 90.1 (<see cref="UsageProfileSource_ASHRAE"/>: occupancy densities and heat per person of Table B102, occupancy schedules of Tables B103), and only then an uncited default (<see cref="UsageProfileSource_Default"/>). Every value carries its tag in <see cref="Classes.UsageProfile.Sources"/>.</para>
        /// <para><b>β, the share of the time in use</b>, which the internal gains of most non-residential types depend on (Table 26): the methodology's standard office (P1 = 0.6, β = 0.3); for every other type the ASHRAE occupancy hours per week divided by 168 - the ASHRAE office gives 48.6 / 168 = 0.29 against the methodology's 0.3, which is what this rule rests on. A given <paramref name="beta"/> overrides it.</para>
        /// <para><b>Production</b> has no values in the methodology ("individually"): the internal gains and hot water come from ASHRAE light manufacturing (people, receptacles and service hot water of Table B102 weighted by the weekly hours of Table B103(4); lighting is excluded, the document gives no lighting power density), the ventilation is the storage row as a stand-in (<see cref="UsageProfileSource_Default"/>).</para>
        /// <para><b>Residential floor area per person</b> has no source - ASHRAE 90.1 has no residential row - and is a 30 m2 default.</para>
        /// <para>With <paramref name="hourly"/> a weekly 168-hour internal gain profile is added for the types whose gain depends on β: q(h) = q_off + (q_use - q_off) · f(h), with f the ASHRAE occupancy fraction scaled so that its mean is β, so the mean of the profile is exactly <see cref="Classes.UsageProfile.InternalHeatGain"/>. The other types stay constant.</para>
        /// </summary>
        /// <param name="usageType">The usage type.</param>
        /// <param name="beta">The share of the time the building is in use, β [-], overriding the default; ignored for types whose gain does not depend on it.</param>
        /// <param name="officeShare">The share P1 of office rooms in the floor area of an office building [-], overriding the standard 0.6.</param>
        /// <param name="meteredHotWater">True for a multi-family building with hot water billed by individual metering (1.60 instead of 2.00 dm3/(m2 d)).</param>
        /// <param name="hourly">True to add the weekly 168-hour internal gain profile.</param>
        /// <returns>The <see cref="Classes.UsageProfile"/>, or null for <see cref="UsageType.Undefined"/>.</returns>
        public static Classes.UsageProfile? UsageProfile(this UsageType usageType, double? beta = null, double? officeShare = null, bool meteredHotWater = false, bool hourly = false)
        {
            if (usageType == UsageType.Undefined)
            {
                return null;
            }

            const double wattsPerBtuPerHour = 0.29307107;
            const double squareMetersPerSquareFoot = 0.09290304;

            const string pl376_Table23 = UsageProfileSource_PL376 + ": Table 23";
            const string pl376_Table24 = UsageProfileSource_PL376 + ": Table 24";
            const string pl376_Table25 = UsageProfileSource_PL376 + ": Table 25";
            const string pl376_Table26 = UsageProfileSource_PL376 + ": Table 26";
            const string pl376_Table27 = UsageProfileSource_PL376 + ": Table 27";
            const string ashrae_TableB102 = UsageProfileSource_ASHRAE + ": Table B102";

            // ASHRAE 90.1 Table B102 footnote b: 230 Btu/h sensible and 190 Btu/h latent per person.
            double personGain = 230.0 * wattsPerBtuPerHour;
            double personLatentGain = 190.0 * wattsPerBtuPerHour;

            // ASHRAE 90.1 Tables B103: occupancy [%] by hour, weekday, Saturday and Sunday. The arrays reproduce the printed
            // daily totals; Assembly prints 50.50 h per week, but its own daily totals give 50.0, which is what is used.
            (string Table, double[] Weekday, double[] Saturday, double[] Sunday)? Schedule(UsageType usageType_Schedule)
            {
                return usageType_Schedule switch
                {
                    // Tables B103(4) Light Manufacturing and B103(5) Office print the same occupancy.
                    UsageType.Office or UsageType.Production => (usageType_Schedule == UsageType.Production ? "Table B103(4) Light Manufacturing" : "Table B103(5) Office",
                        [0, 0, 0, 0, 0, 0, 10, 20, 95, 95, 95, 95, 50, 95, 95, 95, 95, 30, 10, 10, 10, 10, 5, 5],
                        [0, 0, 0, 0, 0, 0, 10, 10, 30, 30, 30, 30, 10, 10, 10, 10, 10, 5, 5, 0, 0, 0, 0, 0],
                        [0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0]),
                    UsageType.Education => ("Table B103(9) School",
                        [0, 0, 0, 0, 0, 0, 0, 5, 75, 90, 90, 80, 80, 80, 80, 45, 15, 5, 15, 20, 20, 10, 0, 0],
                        [0, 0, 0, 0, 0, 0, 0, 0, 10, 10, 10, 10, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
                        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]),
                    UsageType.Gastronomy => ("Table B103(7) Restaurant",
                        [15, 15, 5, 0, 0, 0, 0, 5, 5, 5, 20, 50, 80, 70, 40, 20, 25, 50, 80, 80, 80, 50, 35, 20],
                        [30, 25, 5, 0, 0, 0, 0, 0, 0, 5, 20, 45, 50, 50, 35, 30, 30, 30, 70, 90, 70, 65, 55, 35],
                        [20, 20, 5, 0, 0, 0, 0, 0, 0, 0, 10, 20, 25, 25, 15, 20, 25, 35, 55, 65, 70, 35, 20, 20]),
                    UsageType.Sport => ("Table B103(1) Assembly",
                        [0, 0, 0, 0, 0, 0, 0, 0, 20, 20, 20, 80, 80, 80, 80, 80, 80, 80, 20, 20, 20, 20, 10, 0],
                        [0, 0, 0, 0, 0, 0, 0, 0, 20, 20, 20, 60, 60, 60, 60, 60, 60, 60, 60, 60, 60, 80, 10, 0],
                        [0, 0, 0, 0, 0, 0, 0, 0, 10, 10, 10, 10, 10, 70, 70, 70, 70, 70, 70, 70, 70, 70, 20, 0]),
                    UsageType.Retail => ("Table B103(8) Retail",
                        [0, 0, 0, 0, 0, 0, 0, 10, 20, 50, 50, 70, 70, 70, 70, 80, 70, 50, 50, 30, 30, 0, 0, 0],
                        [0, 0, 0, 0, 0, 0, 0, 10, 20, 50, 60, 80, 80, 80, 80, 80, 80, 60, 20, 20, 20, 10, 0, 0],
                        [0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 20, 20, 40, 40, 40, 40, 40, 20, 10, 0, 0, 0, 0, 0]),
                    UsageType.CollectiveResidence => ("Table B103(3) Hotel/Motel",
                        [90, 90, 90, 90, 90, 90, 70, 40, 40, 20, 20, 20, 20, 20, 20, 30, 50, 50, 50, 70, 70, 80, 90, 90],
                        [90, 90, 90, 90, 90, 90, 70, 50, 50, 30, 30, 30, 30, 30, 30, 30, 30, 50, 60, 60, 60, 70, 70, 70],
                        [70, 70, 70, 70, 70, 70, 70, 70, 50, 50, 50, 30, 30, 20, 20, 20, 30, 40, 40, 60, 60, 80, 80, 80]),
                    UsageType.Storage => ("Table B103(10) Warehouse",
                        [0, 0, 0, 0, 0, 0, 0, 15, 70, 90, 90, 90, 50, 85, 85, 85, 20, 0, 0, 0, 0, 0, 0, 0],
                        [0, 0, 0, 0, 0, 0, 0, 0, 20, 20, 20, 20, 10, 10, 10, 10, 0, 0, 0, 0, 0, 0, 0, 0],
                        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]),
                    _ => null,
                };
            }

            // The week from Monday 0:00 as fractions [0-1]: five weekdays, Saturday, Sunday.
            static List<double> Week((string Table, double[] Weekday, double[] Saturday, double[] Sunday) schedule)
            {
                List<double> result = new(168);
                for (int day = 0; day < 7; day++)
                {
                    double[] values = day < 5 ? schedule.Weekday : day == 5 ? schedule.Saturday : schedule.Sunday;
                    foreach (double value in values)
                    {
                        result.Add(value / 100.0);
                    }
                }

                return result;
            }

            static string Text(double value)
            {
                return value.ToString("0.####", CultureInfo.InvariantCulture);
            }

            Dictionary<string, string> sources = [];

            double heatingSetPoint;
            double outsideAirPerArea;
            double domesticHotWater;
            double domesticHotWaterCorrection;
            double floorAreaPerPerson;
            double internalHeatGain = double.NaN;
            double beta_Used = double.NaN;
            double internalHeatGain_Use = double.NaN;
            double internalHeatGain_Off = double.NaN;

            // Heating set-points of the technical conditions, § 134 ust. 2.
            switch (usageType)
            {
                case UsageType.Sport:
                    heatingSetPoint = 16.0;
                    sources[nameof(Classes.UsageProfile.HeatingSetPoint)] = UsageProfileSource_PLWT + ": § 134 ust. 2, +16 °C (gyms; swimming halls are +24 °C)";
                    break;

                case UsageType.Production:
                    heatingSetPoint = 16.0;
                    sources[nameof(Classes.UsageProfile.HeatingSetPoint)] = UsageProfileSource_PLWT + ": § 134 ust. 2, +16 °C (production halls)";
                    break;

                case UsageType.Storage:
                    heatingSetPoint = 12.0;
                    sources[nameof(Classes.UsageProfile.HeatingSetPoint)] = UsageProfileSource_PLWT + ": § 134 ust. 2, +12 °C (stores requiring permanent staff; +5 °C without)";
                    break;

                default:
                    heatingSetPoint = 20.0;
                    sources[nameof(Classes.UsageProfile.HeatingSetPoint)] = UsageProfileSource_PLWT + ": § 134 ust. 2, +20 °C (rooms for the permanent stay of people; bathrooms +24 °C and residential staircases +8 °C are not zoned)";
                    break;
            }

            // Outside airflow during use, Tables 23-25 [10^-3 m3/(s m2)], held in l/(s m2).
            switch (usageType)
            {
                case UsageType.SingleFamily:
                    outsideAirPerArea = 0.31;
                    sources[nameof(Classes.UsageProfile.OutsideAirPerArea)] = pl376_Table24 + ", continuous ventilation";
                    break;

                case UsageType.MultiFamily:
                    outsideAirPerArea = 0.32;
                    sources[nameof(Classes.UsageProfile.OutsideAirPerArea)] = pl376_Table23 + ", dwellings, continuous ventilation (staircases not zoned)";
                    break;

                case UsageType.Office:
                case UsageType.Education:
                    outsideAirPerArea = 0.56;
                    sources[nameof(Classes.UsageProfile.OutsideAirPerArea)] = pl376_Table25;
                    break;

                case UsageType.Healthcare:
                case UsageType.Gastronomy:
                case UsageType.Sport:
                case UsageType.CollectiveResidence:
                    outsideAirPerArea = 0.42;
                    sources[nameof(Classes.UsageProfile.OutsideAirPerArea)] = pl376_Table25;
                    break;

                case UsageType.Retail:
                    outsideAirPerArea = 0.33;
                    sources[nameof(Classes.UsageProfile.OutsideAirPerArea)] = pl376_Table25;
                    break;

                case UsageType.Storage:
                    outsideAirPerArea = 0.08;
                    sources[nameof(Classes.UsageProfile.OutsideAirPerArea)] = pl376_Table25;
                    break;

                default:
                    outsideAirPerArea = 0.08;
                    sources[nameof(Classes.UsageProfile.OutsideAirPerArea)] = UsageProfileSource_Default + ": the storage row of Table 25 as a stand-in; the methodology sets production " + "individually";
                    break;
            }

            // Hot water, Table 27: V_Wi [dm3/(m2 d)] and k_R.
            switch (usageType)
            {
                case UsageType.SingleFamily:
                    domesticHotWater = 1.40;
                    domesticHotWaterCorrection = 0.90;
                    break;

                case UsageType.MultiFamily:
                    domesticHotWater = meteredHotWater ? 1.60 : 2.00;
                    domesticHotWaterCorrection = 0.90;
                    break;

                case UsageType.Office:
                    domesticHotWater = 0.35;
                    domesticHotWaterCorrection = 0.70;
                    break;

                case UsageType.Education:
                    domesticHotWater = 0.80;
                    domesticHotWaterCorrection = 0.55;
                    break;

                case UsageType.Healthcare:
                    domesticHotWater = 6.50;
                    domesticHotWaterCorrection = 1.00;
                    break;

                case UsageType.Gastronomy:
                    domesticHotWater = 2.50;
                    domesticHotWaterCorrection = 0.80;
                    break;

                case UsageType.Sport:
                    domesticHotWater = 0.25;
                    domesticHotWaterCorrection = 0.50;
                    break;

                case UsageType.Retail:
                    domesticHotWater = 0.60;
                    domesticHotWaterCorrection = 0.78;
                    break;

                case UsageType.CollectiveResidence:
                    domesticHotWater = 3.75;
                    domesticHotWaterCorrection = 0.60;
                    break;

                case UsageType.Storage:
                    domesticHotWater = 0.10;
                    domesticHotWaterCorrection = 0.70;
                    break;

                default:
                    // ASHRAE light manufacturing: 225 Btu/h per person over 30.54 h a week of the hot-water schedule (Table B103(4)),
                    // heated from 10 to 55 °C as the methodology assumes, per 750 ft2 a person.
                    double energy_PerPersonDay = 225.0 * wattsPerBtuPerHour * 30.54 / 7.0 * 3.6;
                    domesticHotWater = energy_PerPersonDay / (4.19 * (55.0 - 10.0)) / (750.0 * squareMetersPerSquareFoot);
                    domesticHotWaterCorrection = 1.0;
                    break;
            }

            if (usageType == UsageType.Production)
            {
                sources[nameof(Classes.UsageProfile.DomesticHotWater)] = UsageProfileSource_ASHRAE + ": Tables B102 and B103(4) light manufacturing, 225 Btu/h per person over 30.54 h a week, heated from 10 to 55 °C, per 750 ft2 a person";
                sources[nameof(Classes.UsageProfile.DomesticHotWaterCorrection)] = UsageProfileSource_Default + ": 1.0, the ASHRAE hot-water schedule already averages the week";
            }
            else
            {
                sources[nameof(Classes.UsageProfile.DomesticHotWater)] = pl376_Table27 + (usageType == UsageType.MultiFamily ? (meteredHotWater ? ", individual metering" : ", flat-rate billing") : string.Empty);
                sources[nameof(Classes.UsageProfile.DomesticHotWaterCorrection)] = pl376_Table27 + (usageType == UsageType.Sport ? ", 0.33-0.50, the upper bound used" : string.Empty);
            }

            // Floor area per person of the standard occupancy: ASHRAE 90.1 Table B102, none for residential buildings.
            switch (usageType)
            {
                case UsageType.SingleFamily:
                case UsageType.MultiFamily:
                    floorAreaPerPerson = 30.0;
                    sources[nameof(Classes.UsageProfile.FloorAreaPerPerson)] = UsageProfileSource_Default + ": 30 m2 a person, approximating the national average; ASHRAE 90.1 has no residential row - replace with the GUS NSP 2021 value";
                    break;

                default:
                    (double SquareFeet, string Row) density = usageType switch
                    {
                        UsageType.Office => (275.0, "office"),
                        UsageType.Education => (75.0, "school"),
                        UsageType.Retail => (300.0, "retail"),
                        UsageType.Gastronomy => (100.0, "restaurant"),
                        UsageType.Healthcare => (200.0, "health/institutional"),
                        UsageType.CollectiveResidence => (250.0, "hotel/motel"),
                        UsageType.Sport => (50.0, "assembly"),
                        UsageType.Storage => (15000.0, "warehouse"),
                        _ => (750.0, "light manufacturing"),
                    };

                    floorAreaPerPerson = density.SquareFeet * squareMetersPerSquareFoot;
                    sources[nameof(Classes.UsageProfile.FloorAreaPerPerson)] = ashrae_TableB102 + ", " + density.Row + ", " + Text(density.SquareFeet) + " ft2 a person";
                    break;
            }

            sources[nameof(Classes.UsageProfile.PersonGain)] = ashrae_TableB102 + ", footnote b, 230 Btu/h sensible a person";
            sources[nameof(Classes.UsageProfile.PersonLatentGain)] = ashrae_TableB102 + ", footnote b, 190 Btu/h latent a person";

            (string Table, double[] Weekday, double[] Saturday, double[] Sunday)? schedule = Schedule(usageType);
            List<double>? week = schedule is null ? null : Week(schedule.Value);
            double beta_Schedule = week is null ? double.NaN : week.Average();

            // β: the methodology's standard office, else the ASHRAE occupancy hours a week / 168, unless given.
            double Beta(string? source_Default)
            {
                if (beta is double beta_Given)
                {
                    sources[nameof(Classes.UsageProfile.Beta)] = "given: " + Text(beta_Given);
                    return beta_Given;
                }

                if (source_Default is not null)
                {
                    sources[nameof(Classes.UsageProfile.Beta)] = source_Default;
                    return 0.3;
                }

                sources[nameof(Classes.UsageProfile.Beta)] = UsageProfileSource_ASHRAE + ": " + schedule!.Value.Table + ", occupancy " + Text(beta_Schedule * 168.0) + " h a week / 168";
                return beta_Schedule;
            }

            // Internal gains, Table 26: constant, or q_use · β + q_off · (1 - β).
            switch (usageType)
            {
                case UsageType.SingleFamily:
                    internalHeatGain = 6.8;
                    sources[nameof(Classes.UsageProfile.InternalHeatGain)] = pl376_Table26;
                    break;

                case UsageType.MultiFamily:
                    internalHeatGain = 7.1;
                    sources[nameof(Classes.UsageProfile.InternalHeatGain)] = pl376_Table26 + ", dwellings (staircases 1.0 W/m2 not zoned)";
                    break;

                case UsageType.Healthcare:
                    internalHeatGain = 8.0;
                    sources[nameof(Classes.UsageProfile.InternalHeatGain)] = pl376_Table26;
                    break;

                case UsageType.Office:
                    double share = officeShare ?? 0.6;
                    beta_Used = Beta(pl376_Table26 + ", standard office use, β = 0.3");
                    internalHeatGain_Use = (20.0 * share) + (8.0 * (1.0 - share));
                    internalHeatGain_Off = (2.0 * share) + (1.0 * (1.0 - share));
                    sources[nameof(Classes.UsageProfile.InternalHeatGain)] = pl376_Table26 + ", (20 P1 + 8 (1 - P1)) β + (2 P1 + 1 (1 - P1)) (1 - β), P1 = " + Text(share) + (officeShare is null ? " (standard)" : " (given)");
                    break;

                case UsageType.Production:
                    // ASHRAE light manufacturing: people at 750 ft2 a person over the occupancy hours, receptacles 0.20 W/ft2 over the
                    // lighting and receptacle hours (56 h a week, Table B103(4)); lighting itself is not in the document and is excluded.
                    beta_Used = Beta(null);
                    double people = personGain / (750.0 * squareMetersPerSquareFoot) * beta_Used;
                    double receptacles = 0.20 / squareMetersPerSquareFoot * (56.0 / 168.0);
                    internalHeatGain = people + receptacles;
                    sources[nameof(Classes.UsageProfile.InternalHeatGain)] = UsageProfileSource_ASHRAE + ": Tables B102 and B103(4) light manufacturing, people 230 Btu/h a person at 750 ft2 a person times β, plus receptacles 0.20 W/ft2 times 56 h / 168; lighting excluded (no lighting power density in the source)";
                    break;

                default:
                    beta_Used = Beta(null);
                    (internalHeatGain_Use, internalHeatGain_Off) = usageType switch
                    {
                        UsageType.Education => (12.0, 1.0),
                        UsageType.Gastronomy => (10.0, 1.0),
                        UsageType.Sport => (9.0, 1.0),
                        UsageType.Retail => (10.0, 1.0),
                        UsageType.CollectiveResidence => (6.0, 2.0),
                        _ => (2.0, 1.0),
                    };

                    sources[nameof(Classes.UsageProfile.InternalHeatGain)] = pl376_Table26 + ", " + Text(internalHeatGain_Use) + " β + " + Text(internalHeatGain_Off) + " (1 - β)";
                    break;
            }

            List<double>? internalHeatGainProfile = null;
            if (!double.IsNaN(internalHeatGain_Use))
            {
                internalHeatGain = (internalHeatGain_Use * beta_Used) + (internalHeatGain_Off * (1.0 - beta_Used));

                if (hourly && week is not null && beta_Schedule > 0)
                {
                    // The ASHRAE occupancy shape scaled to the β used, so the mean of the week is the monthly value exactly.
                    double scale = beta_Used / beta_Schedule;
                    internalHeatGainProfile = week.ConvertAll(x => internalHeatGain_Off + ((internalHeatGain_Use - internalHeatGain_Off) * x * scale));
                    sources[nameof(Classes.UsageProfile.InternalHeatGainProfile)] = UsageProfileSource_ASHRAE + ": " + schedule!.Value.Table + " occupancy shape, scaled to β";
                }
            }

            string source = string.Join("; ", sources.Select(x => x.Key + ": " + x.Value));

            return new Classes.UsageProfile(
                usageType,
                heatingSetPoint,
                internalHeatGain,
                internalHeatGainProfile,
                outsideAirPerArea,
                domesticHotWater,
                domesticHotWaterCorrection,
                floorAreaPerPerson,
                personGain,
                personLatentGain,
                beta_Used,
                sources,
                source);
        }
    }
}
