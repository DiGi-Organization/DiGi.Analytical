using DiGi.Analytical.Building.HVAC.Classes;
using DiGi.Analytical.Building.HVAC.Enums;
using System;

namespace DiGi.Analytical.Building.HVAC
{
    public static partial class Create
    {
        /// <summary>
        /// Creates and initializes a new instance of the <see cref="RegulatedHeatTransferCoefficientsManager"/> class populated with predefined regulatory heat transfer coefficients.
        /// </summary>
        /// <returns>A configured instance of <see cref="RegulatedHeatTransferCoefficientsManager"/>.</returns>
        public static RegulatedHeatTransferCoefficientsManager RegulatedHeatTransferCoefficientsManager()
        {
            RegulationAct regulationAct;

            RegulatedHeatTransferCoefficientsManager result = new();

            regulationAct = new(new DateTime(2002, 12, 15), new DateTime(2002, 12, 16), "Dz.U. 2002 nr 75 poz. 690", "Rozporządzenie Ministra Infrastruktury z dnia 12 kwietnia 2002 r. w sprawie warunków technicznych, jakim powinny odpowiadać budynki i ich usytuowanie", null);

            RegulatedHeatTransferCoefficients_2002 regulatedHeatTransferCoefficients_2002 = new RegulatedHeatTransferCoefficients_2002(regulationAct);
            regulatedHeatTransferCoefficients_2002[ExternalPartitionType_2002.ResidentialBuilding_Wall_Multilayer] = 0.3;
            regulatedHeatTransferCoefficients_2002[ExternalPartitionType_2002.ResidentialBuilding_Wall_Solid] = 0.5;
            regulatedHeatTransferCoefficients_2002[ExternalPartitionType_2002.ResidentialBuilding_Roof] = 0.3;
            regulatedHeatTransferCoefficients_2002[ExternalPartitionType_2002.ResidentialBuilding_Floor_OverUnheatedSpaces] = 0.6;
            regulatedHeatTransferCoefficients_2002[ExternalPartitionType_2002.ResidentialBuilding_Floor] = 0.67;
            regulatedHeatTransferCoefficients_2002[ExternalPartitionType_2002.ResidentialBuilding_Window_ZoneA] = 2.6;
            regulatedHeatTransferCoefficients_2002[ExternalPartitionType_2002.ResidentialBuilding_Window_ZoneB] = 2.0;
            regulatedHeatTransferCoefficients_2002[ExternalPartitionType_2002.ResidentialBuilding_Window_Skylight] = 2.0;
            regulatedHeatTransferCoefficients_2002[ExternalPartitionType_2002.ResidentialBuilding_Door] = 2.6;

            regulatedHeatTransferCoefficients_2002[ExternalPartitionType_2002.PublicBuilding_Wall_Solid] = 0.45;
            regulatedHeatTransferCoefficients_2002[ExternalPartitionType_2002.PublicBuilding_Wall_WithWindowAndDoor] = 0.55;
            regulatedHeatTransferCoefficients_2002[ExternalPartitionType_2002.PublicBuilding_Wall_WithBaconyBrackets] = 0.65;
            regulatedHeatTransferCoefficients_2002[ExternalPartitionType_2002.PublicBuilding_Roof] = 0.3;
            regulatedHeatTransferCoefficients_2002[ExternalPartitionType_2002.PublicBuilding_Floor_OverUnheatedSpaces] = 0.6;
            regulatedHeatTransferCoefficients_2002[ExternalPartitionType_2002.PublicBuilding_Floor] = 0.6;
            regulatedHeatTransferCoefficients_2002[ExternalPartitionType_2002.PublicBuilding_Window] = 2.3;
            regulatedHeatTransferCoefficients_2002[ExternalPartitionType_2002.PublicBuilding_Window_Skylight] = 2.0;
            regulatedHeatTransferCoefficients_2002[ExternalPartitionType_2002.PublicBuilding_Door] = 2.6;

            result.Add(regulatedHeatTransferCoefficients_2002);

            regulationAct = new(new DateTime(2008, 11, 13), new DateTime(2009, 01, 01), "Dz.U. 2008 nr 201 poz. 1238", "Rozporządzenie Ministra Infrastruktury z dnia 6 listopada 2008 r. zmieniające rozporządzenie w sprawie warunków technicznych, jakim powinny odpowiadać budynki i ich usytuowanie", null);

            RegulatedHeatTransferCoefficients_2009 regulatedHeatTransferCoefficients_2009 = new RegulatedHeatTransferCoefficients_2009(regulationAct);
            regulatedHeatTransferCoefficients_2009[ExternalPartitionType_2009.ResidentialBuilding_Wall] = 0.3;
            regulatedHeatTransferCoefficients_2009[ExternalPartitionType_2009.ResidentialBuilding_Roof] = 0.25;
            regulatedHeatTransferCoefficients_2009[ExternalPartitionType_2009.ResidentialBuilding_Floor_OverUnheatedSpaces] = 0.45;
            regulatedHeatTransferCoefficients_2009[ExternalPartitionType_2009.ResidentialBuilding_Floor] = 0.45;
            regulatedHeatTransferCoefficients_2009[ExternalPartitionType_2009.ResidentialBuilding_Window_ZoneA] = 1.8;
            regulatedHeatTransferCoefficients_2009[ExternalPartitionType_2009.ResidentialBuilding_Window_ZoneB] = 1.7;
            regulatedHeatTransferCoefficients_2009[ExternalPartitionType_2009.ResidentialBuilding_Window_Skylight] = 1.8;
            regulatedHeatTransferCoefficients_2009[ExternalPartitionType_2009.ResidentialBuilding_Door] = 2.6;

            regulatedHeatTransferCoefficients_2009[ExternalPartitionType_2009.PublicBuilding_Wall] = 0.3;
            regulatedHeatTransferCoefficients_2009[ExternalPartitionType_2009.PublicBuilding_Roof] = 0.25;
            regulatedHeatTransferCoefficients_2009[ExternalPartitionType_2009.PublicBuilding_Floor_OverUnheatedSpaces] = 0.45;
            regulatedHeatTransferCoefficients_2009[ExternalPartitionType_2009.PublicBuilding_Floor] = 0.45;
            regulatedHeatTransferCoefficients_2009[ExternalPartitionType_2009.PublicBuilding_Window] = 1.8;
            regulatedHeatTransferCoefficients_2009[ExternalPartitionType_2009.PublicBuilding_Window_Skylight] = 1.7;
            regulatedHeatTransferCoefficients_2009[ExternalPartitionType_2009.PublicBuilding_Door] = 2.6;

            result.Add(regulatedHeatTransferCoefficients_2009);

            regulationAct = new(new DateTime(2013, 08, 13), new DateTime(2014, 01, 01), "Dz.U. 2013 poz. 926", "Rozporządzenie Ministra Transportu, Budownictwa i Gospodarki Morskiej z dnia 5 lipca 2013 r. zmieniające rozporządzenie w sprawie warunków technicznych, jakim powinny odpowiadać budynki i ich usytuowanie", null);

            RegulatedHeatTransferCoefficients_2014 regulatedHeatTransferCoefficients_2014 = new RegulatedHeatTransferCoefficients_2014(regulationAct);
            regulatedHeatTransferCoefficients_2014[ExternalPartitionType_2014.Wall] = 0.25;
            regulatedHeatTransferCoefficients_2014[ExternalPartitionType_2014.Roof] = 0.20;
            regulatedHeatTransferCoefficients_2014[ExternalPartitionType_2014.Floor_OverUnheatedSpaces] = 0.25;
            regulatedHeatTransferCoefficients_2014[ExternalPartitionType_2014.Floor] = 0.3;
            regulatedHeatTransferCoefficients_2014[ExternalPartitionType_2014.Window] = 1.3;
            regulatedHeatTransferCoefficients_2014[ExternalPartitionType_2014.Window_Skylight] = 1.5;
            regulatedHeatTransferCoefficients_2014[ExternalPartitionType_2014.Door] = 1.7;

            result.Add(regulatedHeatTransferCoefficients_2014);

            // The 2013 amendment set its limits in stages written into the act itself; each stage applies from its own date,
            // not from the date of a later act (DiGi-Organization/DiGi.Analytical#11).
            regulationAct = new(new DateTime(2013, 08, 13), new DateTime(2017, 01, 01), "Dz.U. 2013 poz. 926", "Rozporządzenie Ministra Transportu, Budownictwa i Gospodarki Morskiej z dnia 5 lipca 2013 r. zmieniające rozporządzenie w sprawie warunków technicznych, jakim powinny odpowiadać budynki i ich usytuowanie", "Annex 2, stage from 1 January 2017");

            RegulatedHeatTransferCoefficients_2014 regulatedHeatTransferCoefficients_2017 = new RegulatedHeatTransferCoefficients_2014(regulationAct);
            regulatedHeatTransferCoefficients_2017[ExternalPartitionType_2014.Wall] = 0.23;
            regulatedHeatTransferCoefficients_2017[ExternalPartitionType_2014.Roof] = 0.18;
            regulatedHeatTransferCoefficients_2017[ExternalPartitionType_2014.Floor_OverUnheatedSpaces] = 0.25;
            regulatedHeatTransferCoefficients_2017[ExternalPartitionType_2014.Floor] = 0.3;
            regulatedHeatTransferCoefficients_2017[ExternalPartitionType_2014.Window] = 1.1;
            regulatedHeatTransferCoefficients_2017[ExternalPartitionType_2014.Window_Skylight] = 1.3;
            regulatedHeatTransferCoefficients_2017[ExternalPartitionType_2014.Door] = 1.5;

            result.Add(regulatedHeatTransferCoefficients_2017);

            // The 2017 amendment replaced Annex 2 and moved the last stage to 31 December 2020, and to 1 January 2019 for a building
            // occupied and owned by a judicial body, a prosecutor's office or a public administration body. The 2022 consolidated text
            // (Dz.U. 2022 poz. 1225) sets no new limits.
            regulationAct = new(new DateTime(2017, 12, 08), new DateTime(2020, 12, 31), new DateTime(2019, 01, 01), "Dz.U. 2017 poz. 2285", "Rozporządzenie Ministra Infrastruktury i Budownictwa z dnia 14 listopada 2017 r. zmieniające rozporządzenie w sprawie warunków technicznych, jakim powinny odpowiadać budynki i ich usytuowanie", "Annex 2, stage from 31 December 2020 (from 1 January 2019 for public-authority buildings)");

            RegulatedHeatTransferCoefficients_2014 regulatedHeatTransferCoefficients_2021 = new RegulatedHeatTransferCoefficients_2014(regulationAct);
            regulatedHeatTransferCoefficients_2021[ExternalPartitionType_2014.Wall] = 0.20;
            regulatedHeatTransferCoefficients_2021[ExternalPartitionType_2014.Roof] = 0.15;
            regulatedHeatTransferCoefficients_2021[ExternalPartitionType_2014.Floor_OverUnheatedSpaces] = 0.25;
            regulatedHeatTransferCoefficients_2021[ExternalPartitionType_2014.Floor] = 0.3;
            regulatedHeatTransferCoefficients_2021[ExternalPartitionType_2014.Window] = 0.9;
            regulatedHeatTransferCoefficients_2021[ExternalPartitionType_2014.Window_Skylight] = 1.1;
            regulatedHeatTransferCoefficients_2021[ExternalPartitionType_2014.Door] = 1.3;

            result.Add(regulatedHeatTransferCoefficients_2021);

            return result;
        }
    }
}