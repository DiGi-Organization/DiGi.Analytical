using DiGi.Analytical.Building.HVAC.Classes;
using DiGi.Analytical.Building.HVAC.Enums;
using System;

namespace DiGi.Analytical.Building.HVAC
{
    public static partial class Create
    {
        /// <summary>
        /// Creates and initializes a new instance of the <see cref="RegulatedHeatTransferCoefficientsManager"/> class populated with predefined regulatory heat transfer coefficients.
        /// <para>The first stages are the norms in force before the technical conditions set U(max): PN-53/57 from 1955-01-01, PN-64/B-03404 from 1966-01-01, PN-74/B-03404 from 1976-01-01, PN-82/B-02020 from 1983-01-01 and PN-91/B-02020 from 1992-01-01 (DiGi-Organization/DiGi.Analytical#20). A design date before 1955-01-01 has no stage.</para>
        /// </summary>
        /// <returns>A configured instance of <see cref="RegulatedHeatTransferCoefficientsManager"/>.</returns>
        public static RegulatedHeatTransferCoefficientsManager RegulatedHeatTransferCoefficientsManager()
        {
            RegulationAct regulationAct;

            RegulatedHeatTransferCoefficientsManager result = new();

            // Before 1998-04-29 the limits were set by norms, not acts (DiGi-Organization/DiGi.Analytical#20). The norm texts are not readable
            // online, so the values are those of the secondary tables that reproduce them; each stage's description names them and records every
            // candidate in-force date. Rule for the date: an explicit in-force date beats a period boundary, which beats the norm's designation year.
            // kcal/(m2·h·°C) values are converted with 1.163 W/(m2K) per kcal/(m2·h·°C). A floor on ground has no requirement in any of them.
            const double kcal = 1.163;

            regulationAct = new(new DateTime(1953, 01, 01), new DateTime(1955, 01, 01), "PN-53/B-02405; PN-57/B-02405", "Ogrzewnictwo. Obliczanie strat ciepła; współczynniki przenikania ciepła przegród (wymagania)",
                "PN-53/B-02405 and PN-57/B-02405 as reproduced in A. Lis, Budownictwo o zoptymalizowanym potencjale energetycznym 1(13) 2014, Tabela 1, and in M. Kaczmarzyk, Czasopismo Inżynierii Lądowej, Środowiska i Architektury XXXIV/64 (2017), Tabela 1. " +
                "Wall k(max) 1.0-1.25 kcal/(m2·h·°C) = 1.163-1.45375 W/(m2K) by region: 1.163 for central and eastern Poland (2-brick wall), the looser value for western Poland and the coast (MCBE 2017 Tabl. 2; PBS 2015); mapped to climatic zones IV-V and I-III, so zone III, central Poland, takes the looser value. Other reproductions round the looser value to 1.40, 1.42 or 1.47 W/(m2K). " +
                "Flat roof 0.87, ceiling under an unheated attic 1.04 (1.05 in energooszczednydom.net), ceiling over an unheated cellar 1.163 W/(m2K); windows and doors none (Lis '-', Kaczmarzyk 'b/w'; energooszczednydom.net alone gives 2.90/3.50). " +
                "In-force date candidates: 1953 (PN-53 edition; recommendations only, Podawca ZNUV 57(6) 2017), 1955-01-01 (period start in Lis and in MCBE 2017 Tabl. 2), 1957 (designation year, ROCKWOOL), 1958-07-01 (PN-57 in force, Podawca), 1959 (Lis, PN-57 row). " +
                "Chosen: 1955-01-01, the earliest documented requirement date of the merged PN-53/57 stage, agreed by two period tables. Publication date: 1 January of the PN-53 edition year, which the sources do not give more precisely.");

            RegulatedHeatTransferCoefficients_1957 regulatedHeatTransferCoefficients_1957 = new(regulationAct);
            regulatedHeatTransferCoefficients_1957[ExternalPartitionType_1957.Wall_ZoneA] = 1.25 * kcal;
            regulatedHeatTransferCoefficients_1957[ExternalPartitionType_1957.Wall_ZoneB] = 1.0 * kcal;
            regulatedHeatTransferCoefficients_1957[ExternalPartitionType_1957.Roof_TopCeiling] = 1.04;
            regulatedHeatTransferCoefficients_1957[ExternalPartitionType_1957.Roof_Flat] = 0.87;
            regulatedHeatTransferCoefficients_1957[ExternalPartitionType_1957.Floor_OverUnheatedSpaces] = 1.0 * kcal;

            result.Add(regulatedHeatTransferCoefficients_1957);

            regulationAct = new(new DateTime(1964, 01, 01), new DateTime(1966, 01, 01), "PN-64/B-03404", "Współczynniki przenikania ciepła przegród budowlanych. Wymagania",
                "PN-64/B-03404 as reproduced in A. Lis, Budownictwo o zoptymalizowanym potencjale energetycznym 1(13) 2014, Tabela 1, A. Miros, Prace ICiMB 19 (2014), Tabela 1, and M. Kaczmarzyk, Czasopismo Inżynierii Lądowej, Środowiska i Architektury XXXIV/64 (2017), Tabela 1. " +
                "Wall k = 1.0-1.25 kcal/(m2·h·°C) by climatic zone (SPB, Projektowanie cieplno-wilgotnościowe, §2.3) = 1.163-1.45375 W/(m2K): 1.163 for central and eastern Poland, 1.25 kcal for the milder west (MCBE 2017 Tabl. 2); mapped to climatic zones IV-V and I-III, so zone III, central Poland, takes the looser value. Other reproductions round the looser value to 1.40, 1.42 or 1.47 W/(m2K). Only solid partitions were covered (G. Rutkowska, SGGW). " +
                "Flat roof 0.87, ceiling under an unheated attic 1.04 (Kaczmarzyk 1.04-1.16; energooszczednydom.net 1.16), ceiling over an unheated cellar 1.163 W/(m2K); windows and doors none (Lis '-', Kaczmarzyk 'b/w'). " +
                "In-force date candidates: 1964 (designation year, ROCKWOOL), 1966-01-01 (Miros, explicit; period start in Lis and MCBE 2017), 1968-01-01 (Podawca ZNUV 57(6) 2017; 'obowiązująca od 1968 roku', Rutkowska). " +
                "Chosen: 1966-01-01, the explicit date of Miros, matching the period start of Lis and MCBE 2017; under 1968 the PN-57 stage would run two years longer. Publication date: 1 January of the designation year.");

            RegulatedHeatTransferCoefficients_1964 regulatedHeatTransferCoefficients_1964 = new(regulationAct);
            regulatedHeatTransferCoefficients_1964[ExternalPartitionType_1964.Wall_ZoneA] = 1.25 * kcal;
            regulatedHeatTransferCoefficients_1964[ExternalPartitionType_1964.Wall_ZoneB] = 1.0 * kcal;
            regulatedHeatTransferCoefficients_1964[ExternalPartitionType_1964.Roof_TopCeiling] = 1.04;
            regulatedHeatTransferCoefficients_1964[ExternalPartitionType_1964.Roof_Flat] = 0.87;
            regulatedHeatTransferCoefficients_1964[ExternalPartitionType_1964.Floor_OverUnheatedSpaces] = 1.0 * kcal;

            result.Add(regulatedHeatTransferCoefficients_1964);

            regulationAct = new(new DateTime(1974, 01, 01), new DateTime(1976, 01, 01), "PN-74/B-03404", "Współczynniki przenikania ciepła przegród budowlanych. Wymagania",
                "PN-74/B-03404 as reproduced in A. Lis, Budownictwo o zoptymalizowanym potencjale energetycznym 1(13) 2014, Tabela 1, A. Miros, Prace ICiMB 19 (2014), Tabela 1, and M. Kaczmarzyk, Czasopismo Inżynierii Lądowej, Środowiska i Architektury XXXIV/64 (2017), Tabela 1. " +
                "Wall k(max) = 1.0 kcal/(m2·h·°C) = 1.163 W/(m2K), climatic zones dropped (SPB, Projektowanie cieplno-wilgotnościowe, §2.3). Flat roof 0.70, ceiling under an unheated attic 0.93, ceiling over an unheated cellar 1.163 W/(m2K); windows and doors none (Lis '-', Kaczmarzyk 'b/w'). " +
                "In-force date candidates: 1974 (designation year, ROCKWOOL), 1976-01-01 (Miros, explicit; period start in Lis and MCBE 2017), 1976-07-01 (Podawca ZNUV 57(6) 2017). " +
                "Chosen: 1976-01-01, the explicit date of Miros, matching the period start of Lis and MCBE 2017. Publication date: 1 January of the designation year.");

            RegulatedHeatTransferCoefficients_1974 regulatedHeatTransferCoefficients_1974 = new(regulationAct);
            regulatedHeatTransferCoefficients_1974[ExternalPartitionType_1974.Wall] = 1.0 * kcal;
            regulatedHeatTransferCoefficients_1974[ExternalPartitionType_1974.Roof_TopCeiling] = 0.93;
            regulatedHeatTransferCoefficients_1974[ExternalPartitionType_1974.Roof_Flat] = 0.70;
            regulatedHeatTransferCoefficients_1974[ExternalPartitionType_1974.Floor_OverUnheatedSpaces] = 1.0 * kcal;

            result.Add(regulatedHeatTransferCoefficients_1974);

            regulationAct = new(new DateTime(1982, 01, 01), new DateTime(1983, 01, 01), "PN-82/B-02020", "Ochrona cieplna budynków. Wymagania i obliczenia",
                "PN-82/B-02020 as reproduced in A. Lis, Budownictwo o zoptymalizowanym potencjale energetycznym 1(13) 2014, Tabela 1, A. Miros, Prace ICiMB 19 (2014), Tabela 1, and M. Kaczmarzyk, Czasopismo Inżynierii Lądowej, Środowiska i Architektury XXXIV/64 (2017), Tabela 1. " +
                "Wall 0.75, flat roof 0.45, ceiling under an unheated attic 0.40, ceiling over an unheated cellar 1.16 (energooszczednydom.net 1.00), windows 2.6 in climatic zones I-III and 2.0 in IV-V, door 2.6 (energooszczednydom.net 2.50) W/(m2K); no separate roof window row, so a roof window takes the window limit. " +
                "In-force date candidates: 1982 (designation year, ROCKWOOL), 1983-01-01 (Miros, explicit; Podawca ZNUV 57(6) 2017; period start in Lis and MCBE 2017). " +
                "Chosen: 1983-01-01, given by all four. End: 1991-12-31 (Lis, MCBE 2017, ROCKWOOL), followed by PN-91 from 1992-01-01. Publication date: 1 January of the designation year.");

            RegulatedHeatTransferCoefficients_1982 regulatedHeatTransferCoefficients_1982 = new(regulationAct);
            regulatedHeatTransferCoefficients_1982[ExternalPartitionType_1982.Wall] = 0.75;
            regulatedHeatTransferCoefficients_1982[ExternalPartitionType_1982.Roof_TopCeiling] = 0.40;
            regulatedHeatTransferCoefficients_1982[ExternalPartitionType_1982.Roof_Flat] = 0.45;
            regulatedHeatTransferCoefficients_1982[ExternalPartitionType_1982.Floor_OverUnheatedSpaces] = 1.16;
            regulatedHeatTransferCoefficients_1982[ExternalPartitionType_1982.Window_ZoneA] = 2.6;
            regulatedHeatTransferCoefficients_1982[ExternalPartitionType_1982.Window_ZoneB] = 2.0;
            regulatedHeatTransferCoefficients_1982[ExternalPartitionType_1982.Door] = 2.6;

            result.Add(regulatedHeatTransferCoefficients_1982);

            regulationAct = new(new DateTime(1991, 01, 01), new DateTime(1992, 01, 01), "PN-91/B-02020", "Ochrona cieplna budynków. Wymagania i obliczenia",
                "PN-91/B-02020 as reproduced in A. Lis, Budownictwo o zoptymalizowanym potencjale energetycznym 1(13) 2014, Tabela 1, A. Miros, Prace ICiMB 19 (2014), Tabela 1, and M. Kaczmarzyk, Czasopismo Inżynierii Lądowej, Środowiska i Architektury XXXIV/64 (2017), Tabela 1. " +
                "Wall 0.55 (Lis, Miros, MCBE 2017; Kaczmarzyk and ROCKWOOL give 0.55-0.70), flat roof 0.30, ceiling under an unheated attic 0.30, ceiling over an unheated cellar 0.60, windows 2.6 in climatic zones I-III and 2.0 in IV-V, door 2.6 W/(m2K); no separate roof window row, so a roof window takes the window limit. " +
                "In-force date candidates: 1991 (designation year, ROCKWOOL), 1992-01-01 (Miros, explicit; Podawca ZNUV 57(6) 2017; period start in Lis and MCBE 2017). " +
                "Chosen: 1992-01-01, given by all four. End candidates: 1997 (period end in Lis and MCBE 2017), 2002 (ROCKWOOL); the stage ends 1998-04-29, when the k(max) annex of Dz.U. 1997 nr 132 poz. 878 applies. Publication date: 1 January of the designation year.");

            RegulatedHeatTransferCoefficients_1991 regulatedHeatTransferCoefficients_1991 = new(regulationAct);
            regulatedHeatTransferCoefficients_1991[ExternalPartitionType_1991.Wall] = 0.55;
            regulatedHeatTransferCoefficients_1991[ExternalPartitionType_1991.Roof_TopCeiling] = 0.30;
            regulatedHeatTransferCoefficients_1991[ExternalPartitionType_1991.Roof_Flat] = 0.30;
            regulatedHeatTransferCoefficients_1991[ExternalPartitionType_1991.Floor_OverUnheatedSpaces] = 0.60;
            regulatedHeatTransferCoefficients_1991[ExternalPartitionType_1991.Window_ZoneA] = 2.6;
            regulatedHeatTransferCoefficients_1991[ExternalPartitionType_1991.Window_ZoneB] = 2.0;
            regulatedHeatTransferCoefficients_1991[ExternalPartitionType_1991.Door] = 2.6;

            result.Add(regulatedHeatTransferCoefficients_1991);

            // The 1997 amendment of the 1994 technical conditions added the first k(max) annex, for single-family and public buildings only;
            // published 28 October 1997 and in force six months later (§ 3) (DiGi-Organization/DiGi.Analytical#14).
            regulationAct = new(new DateTime(1997, 10, 28), new DateTime(1998, 04, 29), "Dz.U. 1997 nr 132 poz. 878", "Rozporządzenie Ministra Spraw Wewnętrznych i Administracji z dnia 30 września 1997 r. zmieniające rozporządzenie w sprawie warunków technicznych, jakim powinny odpowiadać budynki i ich usytuowanie", null);

            RegulatedHeatTransferCoefficients_1997 regulatedHeatTransferCoefficients_1997 = new(regulationAct);
            regulatedHeatTransferCoefficients_1997[ExternalPartitionType_1997.ResidentialBuilding_Wall_Multilayer] = 0.3;
            regulatedHeatTransferCoefficients_1997[ExternalPartitionType_1997.ResidentialBuilding_Wall_Solid] = 0.5;
            regulatedHeatTransferCoefficients_1997[ExternalPartitionType_1997.ResidentialBuilding_Roof] = 0.3;
            regulatedHeatTransferCoefficients_1997[ExternalPartitionType_1997.ResidentialBuilding_Floor_OverUnheatedSpaces] = 0.6;
            regulatedHeatTransferCoefficients_1997[ExternalPartitionType_1997.ResidentialBuilding_Window_ZoneA] = 2.6;
            regulatedHeatTransferCoefficients_1997[ExternalPartitionType_1997.ResidentialBuilding_Window_ZoneB] = 2.0;
            regulatedHeatTransferCoefficients_1997[ExternalPartitionType_1997.ResidentialBuilding_Door] = 2.6;

            regulatedHeatTransferCoefficients_1997[ExternalPartitionType_1997.PublicBuilding_Wall_Solid] = 0.45;
            regulatedHeatTransferCoefficients_1997[ExternalPartitionType_1997.PublicBuilding_Wall_WithWindowAndDoor] = 0.55;
            regulatedHeatTransferCoefficients_1997[ExternalPartitionType_1997.PublicBuilding_Wall_WithBalconyBrackets] = 0.65;
            regulatedHeatTransferCoefficients_1997[ExternalPartitionType_1997.PublicBuilding_Roof] = 0.3;
            regulatedHeatTransferCoefficients_1997[ExternalPartitionType_1997.PublicBuilding_Floor_OverUnheatedSpaces] = 0.6;
            regulatedHeatTransferCoefficients_1997[ExternalPartitionType_1997.PublicBuilding_Window] = 2.3;
            regulatedHeatTransferCoefficients_1997[ExternalPartitionType_1997.PublicBuilding_Door] = 2.6;

            // A floor on ground is limited by the minimum sum of thermal resistances of point 1.4 (ti > 16 °C), not by a k(max).
            regulatedHeatTransferCoefficients_1997.SetMinimumThermalResistance(ExternalPartitionType_1997.ResidentialBuilding_Floor, 1.5);
            regulatedHeatTransferCoefficients_1997.SetMinimumThermalResistance(ExternalPartitionType_1997.PublicBuilding_Floor, 1.5);

            result.Add(regulatedHeatTransferCoefficients_1997);

            // Published 15 June 2002, in force six months later (§ 332) (DiGi-Organization/DiGi.Analytical#12).
            regulationAct = new(new DateTime(2002, 06, 15), new DateTime(2002, 12, 16), "Dz.U. 2002 nr 75 poz. 690", "Rozporządzenie Ministra Infrastruktury z dnia 12 kwietnia 2002 r. w sprawie warunków technicznych, jakim powinny odpowiadać budynki i ich usytuowanie", null);

            // The wall, roof and basement ceiling limits are those of the single-family building table; a multi-family building has none.
            RegulatedHeatTransferCoefficients_2002 regulatedHeatTransferCoefficients_2002 = new(regulationAct);
            regulatedHeatTransferCoefficients_2002[ExternalPartitionType_2002.ResidentialBuilding_Wall_Multilayer] = 0.3;
            regulatedHeatTransferCoefficients_2002[ExternalPartitionType_2002.ResidentialBuilding_Wall_Solid] = 0.5;
            regulatedHeatTransferCoefficients_2002[ExternalPartitionType_2002.ResidentialBuilding_Roof] = 0.3;
            regulatedHeatTransferCoefficients_2002[ExternalPartitionType_2002.ResidentialBuilding_Floor_OverUnheatedSpaces] = 0.6;
            regulatedHeatTransferCoefficients_2002[ExternalPartitionType_2002.ResidentialBuilding_Window_ZoneA] = 2.6;
            regulatedHeatTransferCoefficients_2002[ExternalPartitionType_2002.ResidentialBuilding_Window_ZoneB] = 2.0;
            regulatedHeatTransferCoefficients_2002[ExternalPartitionType_2002.ResidentialBuilding_Window_Skylight] = 2.0;
            regulatedHeatTransferCoefficients_2002[ExternalPartitionType_2002.ResidentialBuilding_Door] = 2.6;

            regulatedHeatTransferCoefficients_2002[ExternalPartitionType_2002.PublicBuilding_Wall_Solid] = 0.45;
            regulatedHeatTransferCoefficients_2002[ExternalPartitionType_2002.PublicBuilding_Wall_WithWindowAndDoor] = 0.55;
            regulatedHeatTransferCoefficients_2002[ExternalPartitionType_2002.PublicBuilding_Wall_WithBaconyBrackets] = 0.65;
            regulatedHeatTransferCoefficients_2002[ExternalPartitionType_2002.PublicBuilding_Roof] = 0.3;
            regulatedHeatTransferCoefficients_2002[ExternalPartitionType_2002.PublicBuilding_Floor_OverUnheatedSpaces] = 0.6;
            regulatedHeatTransferCoefficients_2002[ExternalPartitionType_2002.PublicBuilding_Window] = 2.3;
            regulatedHeatTransferCoefficients_2002[ExternalPartitionType_2002.PublicBuilding_Window_Skylight] = 2.0;
            regulatedHeatTransferCoefficients_2002[ExternalPartitionType_2002.PublicBuilding_Door] = 2.6;

            // A floor on ground is limited by the minimum sum of thermal resistances of point 1.4 (ti > 16 °C), not by a U(max).
            regulatedHeatTransferCoefficients_2002.SetMinimumThermalResistance(ExternalPartitionType_2002.ResidentialBuilding_Floor, 1.5);
            regulatedHeatTransferCoefficients_2002.SetMinimumThermalResistance(ExternalPartitionType_2002.PublicBuilding_Floor, 1.5);

            result.Add(regulatedHeatTransferCoefficients_2002);

            regulationAct = new(new DateTime(2008, 11, 13), new DateTime(2009, 01, 01), "Dz.U. 2008 nr 201 poz. 1238", "Rozporządzenie Ministra Infrastruktury z dnia 6 listopada 2008 r. zmieniające rozporządzenie w sprawie warunków technicznych, jakim powinny odpowiadać budynki i ich usytuowanie", null);

            RegulatedHeatTransferCoefficients_2009 regulatedHeatTransferCoefficients_2009 = new(regulationAct);
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

            RegulatedHeatTransferCoefficients_2014 regulatedHeatTransferCoefficients_2014 = new(regulationAct);
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

            RegulatedHeatTransferCoefficients_2014 regulatedHeatTransferCoefficients_2017 = new(regulationAct);
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

            RegulatedHeatTransferCoefficients_2014 regulatedHeatTransferCoefficients_2021 = new(regulationAct);
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