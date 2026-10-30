using DiGi.Analytical.Building.Classes;
using DiGi.Analytical.Building.Enums;
using DiGi.Analytical.Building.HVAC.Classes;
using DiGi.Analytical.Building.HVAC.Enums;
using DiGi.Analytical.Building.HVAC.Interfaces;
using DiGi.Analytical.Building.Interfaces;
using DiGi.Analytical.Building.Regulation.Classes;
using DiGi.Analytical.Building.Regulation.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace DiGi.Analytical.Building.Regulation
{
    public static partial class Create
    {
        /// <summary>
        /// The date the TABULA values of <see cref="ConstructionLibrary_PL"/> were read from the TABULA web tool.
        /// </summary>
        public const string ConstructionLibrary_PL_RetrievalDate = "2026-10-30";

        /// <summary>
        /// The version of the library <see cref="ConstructionLibrary_PL"/> creates. Raise it whenever a value changes.
        /// </summary>
        public const string ConstructionLibrary_PL_Version = "1.0.0";

        /// <summary>
        /// Creates the Polish construction library: declared-U constructions of residential buildings, chosen per building type and date by <see cref="ConstructionSet"/>s (DiGi-Organization/DiGi.Analytical#15).
        /// <para><see cref="ConstructionFlavour.TypicalAsBuilt"/> sets hold the constructions of the Polish national typology of the TABULA web tool (webtool.building-typology.eu), one set per TABULA building: 7 construction periods for single-family, terraced and multi-family buildings, 5 for apartment blocks. TABULA has no apartment block before 1967, so for those periods the set holds the multi-family constructions. The values are those published, read on <see cref="ConstructionLibrary_PL_RetrievalDate"/>; each construction's description names its TABULA code.</para>
        /// <para><see cref="ConstructionFlavour.Regulation"/> sets hold, for every stage of the technical conditions in <see cref="HVAC.Create.RegulatedHeatTransferCoefficientsManager"/> (1998-04-29 onwards), one construction per role whose declared U is the U(max) of <see cref="Query.RegulatedHeatTransferCoefficient"/>. A role with no limit has no construction, and the set's source says why. Until 2013 the window limits depend on the climatic zone, so those stages have a set for every zone (the zone I-III windows) plus sets for zones IV and V.</para>
        /// <para>The constructions carry declared values only: no layers, and window and door constructions have no outline, so they are cloned with one where an opening needs it. Every identifier is derived from a stable key, so the library serializes to the same text each time it is created: the embedded copy read by <see cref="Query.EmbeddedConstructionLibrary_PL"/> is this method's output.</para>
        /// </summary>
        /// <returns>The Polish construction library.</returns>
        public static ConstructionLibrary ConstructionLibrary_PL()
        {
            const string webTool = "webtool.building-typology.eu";

            ConstructionLibrary result = new(Core.Create.Guid("PL.ConstructionLibrary"), "PL", ConstructionLibrary_PL_Version, string.Format(CultureInfo.InvariantCulture, "Polish construction library of declared U-values (DiGi-Organization/DiGi.Analytical#15). TypicalAsBuilt: the Polish national typology of the TABULA web tool ({0}), retrieved {1}. Regulation: the U(max) of the technical conditions from 1998-04-29 onwards (RegulatedHeatTransferCoefficientsManager).", webTool, ConstructionLibrary_PL_RetrievalDate));

            Dictionary<Guid, IConstruction> constructions = [];

            static string Text(double value)
            {
                return value.ToString("R", CultureInfo.InvariantCulture);
            }

            static string DateText(DateTimeOffset dateTimeOffset)
            {
                return dateTimeOffset.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            }

            static DateTimeOffset Date(int year, int month, int day)
            {
                return new DateTimeOffset(year, month, day, 0, 0, 0, TimeSpan.Zero);
            }

            IConstruction Construction(ConstructionRole constructionRole, string key, string name, string description, double thermalTransmittance, double totalSolarEnergyTransmittance)
            {
                Guid guid = Core.Create.Guid(key);
                if (constructions.TryGetValue(guid, out IConstruction? construction_Existing))
                {
                    return construction_Existing;
                }

                IConstruction construction;
                switch (constructionRole)
                {
                    case ConstructionRole.Window:
                    case ConstructionRole.RoofWindow:
                    case ConstructionRole.BalconyDoor:
                        WindowConstruction windowConstruction = new(guid, new WindowConstruction(name, null)) { Description = description };
                        windowConstruction.SetValue(OpeningConstructionParameter.ThermalTransmittance, thermalTransmittance);
                        if (!double.IsNaN(totalSolarEnergyTransmittance))
                        {
                            windowConstruction.SetValue(OpeningConstructionParameter.TotalSolarEnergyTransmittance, totalSolarEnergyTransmittance);
                        }

                        construction = windowConstruction;
                        break;

                    case ConstructionRole.ExternalDoor:
                    case ConstructionRole.StaircaseEntranceDoor:
                    case ConstructionRole.DoorToUnheatedSpace:
                    case ConstructionRole.GarageDoor:
                        DoorConstruction doorConstruction = new(guid, new DoorConstruction(name, null)) { Description = description };
                        doorConstruction.SetValue(OpeningConstructionParameter.ThermalTransmittance, thermalTransmittance);
                        construction = doorConstruction;
                        break;

                    default:
                        PhysicalComponentConstruction physicalComponentConstruction = constructionRole switch
                        {
                            ConstructionRole.ExternalWall or ConstructionRole.InternalWall or ConstructionRole.PartyWall => new WallConstruction(guid, null),
                            ConstructionRole.Roof or ConstructionRole.FlatRoof => new RoofConstruction(guid, null),
                            _ => new FloorConstruction(guid, null),
                        };

                        physicalComponentConstruction.Name = name;
                        physicalComponentConstruction.Description = description;
                        physicalComponentConstruction.SetValue(PhysicalComponentConstructionParameter.ThermalTransmittance, thermalTransmittance);
                        construction = physicalComponentConstruction;
                        break;
                }

                constructions[guid] = construction;
                result.ConstructionRelationCluster.Add(construction);
                return construction;
            }

            // TypicalAsBuilt: one row per TABULA building of the Polish national typology, as published.
            // Columns: building code, period, type, roof type (TR pitched / FR flat), floor boundary, additional floor resistance R [m2K/W] (unheated cellar),
            // g_gl,n, frame area fraction F_f, thermal bridging surcharge ΔU_tb [W/(m2K)], then per element (roof1, wall1, floor1, window1, door1): construction code, name, U [W/(m2K)].
            List<(string Code, ConstructionPeriod ConstructionPeriod, BuildingType BuildingType, string RoofType, string FloorBoundary, double AdditionalFloorResistance, double TotalSolarEnergyTransmittance, double FrameAreaFraction, double ThermalBridging, (string Code, string Name, double ThermalTransmittance) Roof, (string Code, string Name, double ThermalTransmittance) Wall, (string Code, string Name, double ThermalTransmittance) Floor, (string Code, string Name, double ThermalTransmittance) Window, (string Code, string Name, double ThermalTransmittance) Door)> buildings =
            [
                ("PL.N.SFH.01.Gen.ReEx.001", Enums.ConstructionPeriod.Until1945, BuildingType.SingleFamily, "TR", "Soil", 0.0, 0.85, 0.3, 0.15, ("PL.Roof.ReEx.01.03", "Pitched roof insulated on rafter", 0.7), ("PL.Wall.ReEx.01.02", "2 brick wall", 1.55), ("PL.Floor.ReEx.01.01", "Solid ground floor", 2.2), ("PL.Window.ReEx.01.01", "single glazed, wood frame", 5.0), ("PL.Door.ReEx.01.01", "Wooden door", 5.1)),
                ("PL.N.TH.01.Gen.ReEx.001", Enums.ConstructionPeriod.Until1945, BuildingType.Terraced, "FR", "Soil", 0.0, 0.85, 0.3, 0.15, ("PL.Roof.ReEx.01.04", "Pitched roof insulated on ceilings", 0.9), ("PL.Wall.ReEx.01.01", "1,5 brick wall1", 1.95), ("PL.Floor.ReEx.01.01", "Solid ground floor", 2.2), ("PL.Window.ReEx.01.01", "single glazed, wood frame", 5.0), ("PL.Door.ReEx.01.01", "Wooden door", 5.1)),
                ("PL.N.MFH.01.Gen.ReEx.001", Enums.ConstructionPeriod.Until1945, BuildingType.MultiFamily, "FR", "Cellar", 0.3, 0.85, 0.3, 0.15, ("PL.Roof.ReEx.01.02", "Flat roof nonventilated", 0.9), ("PL.Wall.ReEx.01.02", "2 brick wall", 1.55), ("PL.Floor.ReEx.01.02", "Suspended floor", 1.16883116883117), ("PL.Window.ReEx.01.01", "single glazed, wood frame", 5.0), ("PL.Door.ReEx.01.01", "Wooden door", 5.1)),
                ("PL.N.SFH.02.Gen.ReEx.001", Enums.ConstructionPeriod.From1946To1966, BuildingType.SingleFamily, "TR", "Soil", 0.0, 0.85, 0.3, 0.15, ("PL.Roof.ReEx.02.03", "Pitched roof insulated on rafter", 0.6), ("PL.Wall.ReEx.02.01", "2 brick wall", 1.55), ("PL.Floor.ReEx.02.01", "Solid ground floor", 1.8), ("PL.Window.ReEx.02.01", "single glazed, wood frame", 5.0), ("PL.Door.ReEx.02.01", "Wooden door", 4.5)),
                ("PL.N.TH.02.Gen.ReEx.001", Enums.ConstructionPeriod.From1946To1966, BuildingType.Terraced, "FR", "Soil", 0.0, 0.85, 0.3, 0.1, ("PL.Roof.ReEx.02.03", "Pitched roof insulated on rafter", 0.6), ("PL.Wall.ReEx.02.01", "2 brick wall", 1.55), ("PL.Floor.ReEx.02.01", "Solid ground floor", 1.8), ("PL.Window.ReEx.02.01", "single glazed, wood frame", 5.0), ("PL.Door.ReEx.02.01", "Wooden door", 4.5)),
                ("PL.N.MFH.02.Gen.ReEx.001", Enums.ConstructionPeriod.From1946To1966, BuildingType.MultiFamily, "FR", "Cellar", 0.3, 0.75, 0.3, 0.15, ("PL.Roof.ReEx.02.02", "Flat roof nonventilated", 0.5), ("PL.Wall.ReEx.02.01", "2 brick wall", 1.55), ("PL.Floor.ReEx.02.02", "Suspended floor", 1.03448275862069), ("PL.Window.ReEx.02.02", "French window", 2.6), ("PL.Door.ReEx.02.01", "Wooden door", 4.5)),
                ("PL.N.SFH.03.Gen.ReEx.001", Enums.ConstructionPeriod.From1967To1985, BuildingType.SingleFamily, "TR", "Soil", 0.0, 0.75, 0.3, 0.15, ("PL.Roof.ReEx.03.04", "Pitched roof insulated on ceilings", 0.5), ("PL.Wall.ReEx.03.02", "hollowbloks", 1.03), ("PL.Floor.ReEx.03.01", "Solid ground floor", 1.6), ("PL.Window.ReEx.03.02", "wood frame, double glazed air filled (7,5 mm gap)", 2.6), ("PL.Door.ReEx.03.01", "Wooden door", 4.0)),
                ("PL.N.TH.03.Gen.ReEx.001", Enums.ConstructionPeriod.From1967To1985, BuildingType.Terraced, "FR", "Soil", 0.0, 0.75, 0.3, 0.1, ("PL.Roof.ReEx.03.03", "Pitched roof insulated on rafter", 0.6), ("PL.Wall.ReEx.03.02", "hollowbloks", 1.03), ("PL.Floor.ReEx.03.01", "Solid ground floor", 1.6), ("PL.Window.ReEx.03.02", "wood frame, double glazed air filled (7,5 mm gap)", 2.6), ("PL.Door.ReEx.03.01", "Wooden door", 4.0)),
                ("PL.N.MFH.03.Gen.ReEx.001", Enums.ConstructionPeriod.From1967To1985, BuildingType.MultiFamily, "FR", "Cellar", 0.3, 0.75, 0.3, 0.1, ("PL.Roof.ReEx.03.01", "Flat roof ventilated", 0.6), ("PL.Wall.ReEx.03.03", "PrefconConcretePanels", 1.3), ("PL.Floor.ReEx.03.02", "Suspended floor", 0.935251798561151), ("PL.Window.ReEx.03.01", "French window", 2.6), ("PL.Door.ReEx.03.01", "Wooden door", 4.0)),
                ("PL.N.AB.03.Gen.ReEx.001", Enums.ConstructionPeriod.From1967To1985, BuildingType.ApartmentBlock, "FR", "Cellar", 0.3, 0.75, 0.3, 0.1, ("DE.Roof.SyAv.09.01", "average U-value for roofs or top ceilings / single-unit housing / construction years 1995 ... 2009 (SUH III) / not refurbished", 0.33), ("PL.Wall.ReEx.03.03", "PrefconConcretePanels", 1.3), ("PL.Floor.ReEx.03.02", "Suspended floor", 0.935251798561151), ("PL.Window.ReEx.03.01", "French window", 2.6), ("PL.Door.ReEx.03.01", "Wooden door", 4.0)),
                ("PL.N.SFH.04.Gen.ReEx.001", Enums.ConstructionPeriod.From1986To1992, BuildingType.SingleFamily, "TR", "Soil", 0.0, 0.73, 0.3, 0.1, ("PL.Roof.ReEx.04.04", "Pitched roof insulated on ceilings", 0.4), ("PL.Wall.ReEx.04.03", "PrefconConcretePanels", 1.3), ("PL.Floor.ReEx.04.01", "Solid ground floor", 1.4), ("PL.Window.ReEx.04.02", "wood frame, double glazed air filled (7,5 mm gap)", 2.6), ("PL.Door.ReEx.04.01", "Wooden door", 3.6)),
                ("PL.N.TH.04.Gen.ReEx.001", Enums.ConstructionPeriod.From1986To1992, BuildingType.Terraced, "FR", "Soil", 0.0, 0.73, 0.3, 0.1, ("PL.Roof.ReEx.04.03", "Pitched roof insulated on rafter", 0.5), ("PL.Wall.ReEx.04.01", "brickwall & internal  insulation (3 layer)", 0.49), ("PL.Floor.ReEx.04.01", "Solid ground floor", 1.4), ("PL.Window.ReEx.04.02", "wood frame, double glazed air filled (7,5 mm gap)", 2.6), ("PL.Door.ReEx.04.01", "Wooden door", 3.6)),
                ("PL.N.MFH.04.Gen.ReEx.001", Enums.ConstructionPeriod.From1986To1992, BuildingType.MultiFamily, "FR", "Cellar", 0.3, 0.73, 0.3, 0.1, ("PL.Roof.ReEx.04.01", "Flat roof ventilated", 0.5), ("PL.Wall.ReEx.04.04", "H-Frame", 1.1), ("PL.Floor.ReEx.04.02", "Suspended floor", 0.827067669172932), ("PL.Window.ReEx.04.02", "wood frame, double glazed air filled (7,5 mm gap)", 2.6), ("PL.Door.ReEx.04.01", "Wooden door", 3.6)),
                ("PL.N.AB.04.Gen.ReEx.001", Enums.ConstructionPeriod.From1986To1992, BuildingType.ApartmentBlock, "FR", "Cellar", 0.3, 0.75, 0.3, 0.1, ("PL.Roof.ReEx.01.02", "Flat roof nonventilated", 0.9), ("PL.Wall.ReEx.04.03", "PrefconConcretePanels", 1.3), ("PL.Floor.ReEx.04.02", "Suspended floor", 0.827067669172932), ("PL.Window.ReEx.04.01", "French window", 2.6), ("PL.Door.ReEx.04.01", "Wooden door", 3.6)),
                ("PL.N.SFH.05.Gen.ReEx.001", Enums.ConstructionPeriod.From1993To2002, BuildingType.SingleFamily, "TR", "Soil", 0.0, 0.77, 0.3, 0.1, ("PL.Roof.ReEx.05.04", "Pitched roof insulated on ceilings", 0.4), ("PL.Wall.ReEx.05.05", "LightFrame", 0.4), ("PL.Floor.ReEx.05.01", "Solid ground floor", 1.0), ("PL.Window.ReEx.05.02", "plastic frame, glass unit (one cell)", 1.6), ("PL.Door.ReEx.05.02", "Plastic or Compsite door", 2.5)),
                ("PL.N.TH.05.Gen.ReEx.001", Enums.ConstructionPeriod.From1993To2002, BuildingType.Terraced, "FR", "Cellar", 0.3, 0.77, 0.3, 0.1, ("PL.Roof.ReEx.05.04", "Pitched roof insulated on ceilings", 0.4), ("PL.Wall.ReEx.05.01", "brickwall & internal  insulation (3 layer)", 0.19), ("PL.Floor.ReEx.05.01", "Solid ground floor", 0.769230769230769), ("PL.Window.ReEx.05.02", "plastic frame, glass unit (one cell)", 1.6), ("PL.Door.ReEx.05.02", "Plastic or Compsite door", 2.5)),
                ("PL.N.MFH.05.Gen.ReEx.001", Enums.ConstructionPeriod.From1993To2002, BuildingType.MultiFamily, "FR", "Cellar", 0.3, 0.77, 0.3, 0.1, ("PL.Roof.ReEx.05.01", "Flat roof ventilated", 0.5), ("PL.Wall.ReEx.05.02", "H-Frame", 0.19), ("PL.Floor.ReEx.05.02", "Suspended floor", 0.645161290322581), ("PL.Window.ReEx.05.02", "plastic frame, glass unit (one cell)", 1.6), ("PL.Door.ReEx.05.02", "Plastic or Compsite door", 2.5)),
                ("PL.N.AB.05.Gen.ReEx.001", Enums.ConstructionPeriod.From1993To2002, BuildingType.ApartmentBlock, "FR", "Cellar", 0.3, 0.77, 0.3, 0.1, ("PL.Roof.ReEx.02.02", "Flat roof nonventilated", 0.5), ("PL.Wall.ReEx.05.03", "hollowbloks", 0.18), ("PL.Floor.ReEx.05.02", "Suspended floor", 0.645161290322581), ("PL.Window.ReEx.05.02", "plastic frame, glass unit (one cell)", 1.6), ("PL.Door.ReEx.05.02", "Plastic or Compsite door", 2.5)),
                ("PL.N.SFH.06.Gen.ReEx.001", Enums.ConstructionPeriod.From2003To2008, BuildingType.SingleFamily, "TR", "Soil", 0.0, 0.77, 0.3, 0.1, ("PL.Roof.ReEx.06.04", "Pitched roof insulated on ceilings", 0.3), ("PL.Wall.ReEx.06.02", "hollowbloks", 0.18), ("PL.Floor.ReEx.06.02", "Suspended floor", 0.6), ("PL.Window.ReEx.06.04", "plastic frame, glass unit ( (one cell gas filled)", 1.2), ("PL.Door.ReEx.06.02", "Plastic or Compsite insulated", 1.8)),
                ("PL.N.TH.06.Gen.ReEx.001", Enums.ConstructionPeriod.From2003To2008, BuildingType.Terraced, "FR", "Cellar", 0.3, 0.77, 0.3, 0.05, ("PL.Roof.ReEx.06.04", "Pitched roof insulated on ceilings", 0.3), ("PL.Wall.ReEx.06.01", "brickwall & internal  insulation (3 layer)", 0.19), ("PL.Floor.ReEx.06.02", "Suspended floor", 0.508474576271186), ("PL.Window.ReEx.06.04", "plastic frame, glass unit ( (one cell gas filled)", 1.2), ("PL.Door.ReEx.06.02", "Plastic or Compsite insulated", 1.8)),
                ("PL.N.MFH.06.Gen.ReEx.001", Enums.ConstructionPeriod.From2003To2008, BuildingType.MultiFamily, "FR", "Cellar", 0.3, 0.77, 0.3, 0.1, ("PL.Roof.ReEx.06.01", "Flat roof ventilated", 0.4), ("PL.Wall.ReEx.06.02", "hollowbloks", 0.18), ("PL.Floor.ReEx.06.02", "Suspended floor", 0.508474576271186), ("PL.Window.ReEx.06.02", "plastic frame, glass unit (one cell)", 1.5), ("PL.Door.ReEx.06.02", "Plastic or Compsite insulated", 1.8)),
                ("PL.N.AB.06.Gen.ReEx.001", Enums.ConstructionPeriod.From2003To2008, BuildingType.ApartmentBlock, "FR", "Cellar", 0.3, 0.77, 0.3, 0.1, ("PL.Roof.ReEx.03.01", "Flat roof ventilated", 0.6), ("PL.Wall.ReEx.06.01", "brickwall & internal  insulation (3 layer)", 0.19), ("PL.Floor.ReEx.06.02", "Suspended floor", 0.508474576271186), ("PL.Window.ReEx.06.02", "plastic frame, glass unit (one cell)", 1.5), ("PL.Door.ReEx.06.02", "Plastic or Compsite insulated", 1.8)),
                ("PL.N.SFH.07.Gen.ReEx.001", Enums.ConstructionPeriod.From2009, BuildingType.SingleFamily, "TR", "Soil", 0.0, 0.5, 0.3, 0.1, ("PL.Roof.ReEx.07.04", "Pitched roof insulated on ceilings", 0.25), ("PL.Wall.ReEx.07.01", "brickwall & internal  insulation (3 layer)", 0.19), ("PL.Floor.ReEx.07.02", "Suspended floor", 0.5), ("PL.Window.ReEx.07.04", "plastic frame, glass unit ( (one cell gas filled)", 1.1), ("PL.Door.ReEx.07.02", "Plastic or Compsite door", 1.7)),
                ("PL.N.TH.07.Gen.ReEx.001", Enums.ConstructionPeriod.From2009, BuildingType.Terraced, "FR", "Cellar", 0.3, 0.5, 0.3, 0.05, ("PL.Roof.ReEx.07.04", "Pitched roof insulated on ceilings", 0.25), ("PL.Wall.ReEx.07.01", "brickwall & internal  insulation (3 layer)", 0.19), ("PL.Floor.ReEx.07.02", "Suspended floor", 0.434782608695652), ("PL.Window.ReEx.07.04", "plastic frame, glass unit ( (one cell gas filled)", 1.1), ("PL.Door.ReEx.07.02", "Plastic or Compsite door", 1.7)),
                ("PL.N.MFH.07.Gen.ReEx.001", Enums.ConstructionPeriod.From2009, BuildingType.MultiFamily, "FR", "Cellar", 0.3, 0.77, 0.3, 0.1, ("PL.Roof.ReEx.07.01", "Flat roof ventilated", 0.3), ("PL.Wall.ReEx.07.02", "hollowbloks", 0.18), ("PL.Floor.ReEx.07.02", "Suspended floor", 0.434782608695652), ("PL.Window.ReEx.07.02", "plastic frame, glass unit (one cell)", 1.4), ("PL.Door.ReEx.07.03", "Metal insulated", 1.4)),
                ("PL.N.AB.07.Gen.ReEx.001", Enums.ConstructionPeriod.From2009, BuildingType.ApartmentBlock, "FR", "Cellar", 0.3, 0.77, 0.3, 0.15, ("PL.Roof.ReEx.04.01", "Flat roof ventilated", 0.5), ("PL.Wall.ReEx.07.01", "brickwall & internal  insulation (3 layer)", 0.19), ("PL.Floor.ReEx.07.02", "Suspended floor", 0.434782608695652), ("PL.Window.ReEx.07.02", "plastic frame, glass unit (one cell)", 1.4), ("PL.Door.ReEx.07.02", "Plastic or Compsite door", 1.7)),
            ];

            // The TABULA periods are periods of construction; the last one is published as 2008 ... 9999 and starts here in 2009, after the 2003 ... 2008 period (Query.ConstructionPeriod).
            void TypicalAsBuilt(int index, BuildingType buildingType, string? note)
            {
                (string Code, ConstructionPeriod ConstructionPeriod, BuildingType BuildingType, string RoofType, string FloorBoundary, double AdditionalFloorResistance, double TotalSolarEnergyTransmittance, double FrameAreaFraction, double ThermalBridging, (string Code, string Name, double ThermalTransmittance) Roof, (string Code, string Name, double ThermalTransmittance) Wall, (string Code, string Name, double ThermalTransmittance) Floor, (string Code, string Name, double ThermalTransmittance) Window, (string Code, string Name, double ThermalTransmittance) Door) building = buildings[index];

                DateTimeOffset startDate;
                DateTimeOffset? endDate;
                switch (building.ConstructionPeriod)
                {
                    case Enums.ConstructionPeriod.Until1945:
                        startDate = DateTimeOffset.MinValue;
                        endDate = Date(1946, 1, 1);
                        break;

                    case Enums.ConstructionPeriod.From1946To1966:
                        startDate = Date(1946, 1, 1);
                        endDate = Date(1967, 1, 1);
                        break;

                    case Enums.ConstructionPeriod.From1967To1985:
                        startDate = Date(1967, 1, 1);
                        endDate = Date(1986, 1, 1);
                        break;

                    case Enums.ConstructionPeriod.From1986To1992:
                        startDate = Date(1986, 1, 1);
                        endDate = Date(1993, 1, 1);
                        break;

                    case Enums.ConstructionPeriod.From1993To2002:
                        startDate = Date(1993, 1, 1);
                        endDate = Date(2003, 1, 1);
                        break;

                    case Enums.ConstructionPeriod.From2003To2008:
                        startDate = Date(2003, 1, 1);
                        endDate = Date(2009, 1, 1);
                        break;

                    default:
                        startDate = Date(2009, 1, 1);
                        endDate = null;
                        break;
                }

                string Description((string Code, string Name, double ThermalTransmittance) element, string? detail)
                {
                    return string.Format(CultureInfo.InvariantCulture, "TABULA construction {0} \"{1}\" of building {2}: U = {3} W/(m2K) as published{4} ({5}, retrieved {6}).", element.Code, element.Name, building.Code, Text(element.ThermalTransmittance), detail, webTool, ConstructionLibrary_PL_RetrievalDate);
                }

                string Name((string Code, string Name, double ThermalTransmittance) element)
                {
                    return string.Format(CultureInfo.InvariantCulture, "{0} ({1})", element.Name, element.Code);
                }

                string roofDetail = string.Format(CultureInfo.InvariantCulture, "; roof type {0}", building.RoofType);
                if (!building.Roof.Code.StartsWith("PL.", StringComparison.Ordinal))
                {
                    roofDetail += "; the Polish TABULA record refers here to a construction of another national typology, kept as published";
                }

                string floorDetail = string.Format(CultureInfo.InvariantCulture, "; floor boundary {0}", building.FloorBoundary);
                if (building.AdditionalFloorResistance > 0)
                {
                    floorDetail += string.Format(CultureInfo.InvariantCulture, ", the U including the additional resistance R = {0} m2K/W of the unheated space", Text(building.AdditionalFloorResistance));
                }

                string windowDetail = string.Format(CultureInfo.InvariantCulture, "; g_gl,n = {0} at normal incidence, frame area fraction F_f = {1}", Text(building.TotalSolarEnergyTransmittance), Text(building.FrameAreaFraction));

                IConstruction construction_Roof = Construction(ConstructionRole.Roof, string.Concat("PL.TABULA.", building.Code, ".Roof"), Name(building.Roof), Description(building.Roof, roofDetail), building.Roof.ThermalTransmittance, double.NaN);
                IConstruction construction_Wall = Construction(ConstructionRole.ExternalWall, string.Concat("PL.TABULA.", building.Code, ".Wall"), Name(building.Wall), Description(building.Wall, null), building.Wall.ThermalTransmittance, double.NaN);
                IConstruction construction_Floor = Construction(ConstructionRole.GroundFloor, string.Concat("PL.TABULA.", building.Code, ".Floor"), Name(building.Floor), Description(building.Floor, floorDetail), building.Floor.ThermalTransmittance, double.NaN);
                IConstruction construction_Window = Construction(ConstructionRole.Window, string.Concat("PL.TABULA.", building.Code, ".Window"), Name(building.Window), Description(building.Window, windowDetail), building.Window.ThermalTransmittance, building.TotalSolarEnergyTransmittance);
                IConstruction construction_Door = Construction(ConstructionRole.ExternalDoor, string.Concat("PL.TABULA.", building.Code, ".Door"), Name(building.Door), Description(building.Door, null), building.Door.ThermalTransmittance, double.NaN);

                string source = string.Format(CultureInfo.InvariantCulture, "TABULA building {0}, Polish national typology ({1}, retrieved {2}). {3}Roof type {4}, floor boundary {5}; thermal bridging surcharge ΔU_tb = {6} W/(m2K), frame area fraction F_f = {7}, g_gl,n = {8}. The roof construction serves Roof and FlatRoof, the floor construction GroundFloor and FloorOverUnheated, the window construction Window, RoofWindow and BalconyDoor, the door construction ExternalDoor and StaircaseEntranceDoor. TABULA has no InternalWall, PartyWall, IntermediateFloor, DoorToUnheatedSpace or GarageDoor construction.", building.Code, webTool, ConstructionLibrary_PL_RetrievalDate, note, building.RoofType, building.FloorBoundary, Text(building.ThermalBridging), Text(building.FrameAreaFraction), Text(building.TotalSolarEnergyTransmittance));

                ConstructionSet constructionSet = new(ConstructionFlavour.TypicalAsBuilt, buildingType, null, startDate, endDate, source);
                constructionSet.SetConstruction(ConstructionRole.ExternalWall, construction_Wall);
                constructionSet.SetConstruction(ConstructionRole.Roof, construction_Roof);
                constructionSet.SetConstruction(ConstructionRole.FlatRoof, construction_Roof);
                constructionSet.SetConstruction(ConstructionRole.GroundFloor, construction_Floor);
                constructionSet.SetConstruction(ConstructionRole.FloorOverUnheated, construction_Floor);
                constructionSet.SetConstruction(ConstructionRole.Window, construction_Window);
                constructionSet.SetConstruction(ConstructionRole.RoofWindow, construction_Window);
                constructionSet.SetConstruction(ConstructionRole.BalconyDoor, construction_Window);
                constructionSet.SetConstruction(ConstructionRole.ExternalDoor, construction_Door);
                constructionSet.SetConstruction(ConstructionRole.StaircaseEntranceDoor, construction_Door);

                result.Add(constructionSet);
            }

            for (int i = 0; i < buildings.Count; i++)
            {
                TypicalAsBuilt(i, buildings[i].BuildingType, null);

                // TABULA has no apartment block before 1967: the multi-family building of the period stands in for it.
                if (buildings[i].BuildingType == BuildingType.MultiFamily && buildings[i].ConstructionPeriod is Enums.ConstructionPeriod.Until1945 or Enums.ConstructionPeriod.From1946To1966)
                {
                    TypicalAsBuilt(i, BuildingType.ApartmentBlock, "TABULA has no apartment block for this period, so the set holds the constructions of its multi-family building. ");
                }
            }

            // Regulation: one set per stage of the technical conditions and building type, the constructions carrying the stage's U(max).
            List<ConstructionRole> constructionRoles_Regulation =
            [
                ConstructionRole.ExternalWall,
                ConstructionRole.Roof,
                ConstructionRole.FlatRoof,
                ConstructionRole.GroundFloor,
                ConstructionRole.FloorOverUnheated,
                ConstructionRole.Window,
                ConstructionRole.RoofWindow,
                ConstructionRole.BalconyDoor,
                ConstructionRole.ExternalDoor,
                ConstructionRole.StaircaseEntranceDoor,
                ConstructionRole.DoorToUnheatedSpace,
            ];

            List<BuildingType> buildingTypes = [BuildingType.SingleFamily, BuildingType.Terraced, BuildingType.MultiFamily, BuildingType.ApartmentBlock];

            static string Group(ConstructionRole constructionRole)
            {
                return constructionRole switch
                {
                    ConstructionRole.Roof or ConstructionRole.FlatRoof => "Roof",
                    ConstructionRole.Window or ConstructionRole.BalconyDoor => "Window",
                    ConstructionRole.ExternalDoor or ConstructionRole.StaircaseEntranceDoor or ConstructionRole.DoorToUnheatedSpace => "Door",
                    _ => constructionRole.ToString(),
                };
            }

            List<IRegulatedHeatTransferCoefficients> regulatedHeatTransferCoefficientsList = HVAC.Create.RegulatedHeatTransferCoefficientsManager().RegulatedHeatTransferCoefficients<IRegulatedHeatTransferCoefficients>();
            regulatedHeatTransferCoefficientsList.RemoveAll(x => x.RegulationAct is null);
            regulatedHeatTransferCoefficientsList.Sort((x, y) => x.RegulationAct!.EffectiveDate.CompareTo(y.RegulationAct!.EffectiveDate));

            for (int i = 0; i < regulatedHeatTransferCoefficientsList.Count; i++)
            {
                IRegulatedHeatTransferCoefficients regulatedHeatTransferCoefficients = regulatedHeatTransferCoefficientsList[i];
                RegulationAct regulationAct = regulatedHeatTransferCoefficients.RegulationAct!;

                DateTimeOffset startDate = Date(regulationAct.EffectiveDate.Year, regulationAct.EffectiveDate.Month, regulationAct.EffectiveDate.Day);
                DateTimeOffset? endDate = null;
                if (i + 1 < regulatedHeatTransferCoefficientsList.Count)
                {
                    DateTime effectiveDate_Next = regulatedHeatTransferCoefficientsList[i + 1].RegulationAct!.EffectiveDate;
                    endDate = Date(effectiveDate_Next.Year, effectiveDate_Next.Month, effectiveDate_Next.Day);
                }

                bool stage_1997_2002 = regulatedHeatTransferCoefficients is RegulatedHeatTransferCoefficients_1997 or RegulatedHeatTransferCoefficients_2002;

                foreach (BuildingType buildingType in buildingTypes)
                {
                    bool singleFamily = buildingType is BuildingType.SingleFamily or BuildingType.Terraced;

                    List<double> Values(ClimateZone climateZone)
                    {
                        List<double> values = [];
                        foreach (ConstructionRole constructionRole in constructionRoles_Regulation)
                        {
                            values.Add(regulatedHeatTransferCoefficients.RegulatedHeatTransferCoefficient(constructionRole, buildingType, climateZone, true));
                        }

                        return values;
                    }

                    static bool Equal(List<double> values_1, List<double> values_2)
                    {
                        for (int j = 0; j < values_1.Count; j++)
                        {
                            if (!values_1[j].Equals(values_2[j]))
                            {
                                return false;
                            }
                        }

                        return true;
                    }

                    List<double> values_III = Values(ClimateZone.III);
                    List<double> values_IV = Values(ClimateZone.IV);
                    List<double> values_V = Values(ClimateZone.V);
                    bool zoneDependent = !Equal(values_III, values_IV) || !Equal(values_III, values_V);

                    void Regulation(ClimateZone? climateZone, List<double> values)
                    {
                        List<string> notes = [];
                        if (zoneDependent)
                        {
                            notes.Add(climateZone is null ? "Windows take the limit of zones I-III, which also applies in a zone without its own set." : string.Format(CultureInfo.InvariantCulture, "Windows take the limit of zone {0}.", climateZone));
                        }

                        if (stage_1997_2002 && singleFamily)
                        {
                            notes.Add(string.Format(CultureInfo.InvariantCulture, "The external wall takes the limit of a wall layered with insulation of λ ≤ 0.05 W/(mK); any other wall had {0} W/(m2K).", Text(regulatedHeatTransferCoefficients.RegulatedHeatTransferCoefficient(ConstructionRole.ExternalWall, buildingType, ClimateZone.III, false))));
                        }

                        if (!singleFamily && regulatedHeatTransferCoefficients is RegulatedHeatTransferCoefficients_1997)
                        {
                            notes.Add("The 1997 annex sets no limit for a multi-family building.");
                        }
                        else if (!singleFamily && regulatedHeatTransferCoefficients is RegulatedHeatTransferCoefficients_2002)
                        {
                            notes.Add("The 2002 regulation sets no wall, roof or basement ceiling limit for a multi-family building, which met the act by its seasonal heat demand indicator E ≤ E0.");
                        }

                        if (regulatedHeatTransferCoefficients.TryGetMinimumThermalResistance(nameof(ExternalPartitionType_2002.ResidentialBuilding_Floor), out double minimumThermalResistance))
                        {
                            notes.Add(string.Format(CultureInfo.InvariantCulture, "A floor on ground was limited by a minimum thermal resistance R = {0} m2K/W, not by a U(max).", Text(minimumThermalResistance)));
                        }

                        if (regulationAct.PublicAuthorityEffectiveDate is DateTime publicAuthorityEffectiveDate)
                        {
                            notes.Add(string.Format(CultureInfo.InvariantCulture, "For a building of a public authority the stage applies from {0}; the set uses the general date.", DateText(Date(publicAuthorityEffectiveDate.Year, publicAuthorityEffectiveDate.Month, publicAuthorityEffectiveDate.Day))));
                        }

                        List<string> constructionRoles_Missing = [];
                        for (int j = 0; j < constructionRoles_Regulation.Count; j++)
                        {
                            if (double.IsNaN(values[j]))
                            {
                                constructionRoles_Missing.Add(constructionRoles_Regulation[j].ToString());
                            }
                        }

                        string source = string.Format(CultureInfo.InvariantCulture, "{0}: {1}. In force from {2}. Each construction carries the U(max) of the stage for a {3} building as its declared U. {4}{5}", regulationAct.Reference, regulationAct.Name, DateText(startDate), buildingType, string.Join(" ", notes), constructionRoles_Missing.Count == 0 ? string.Empty : string.Concat(" No limit, so no construction: ", string.Join(", ", constructionRoles_Missing), "."));

                        ConstructionSet constructionSet = new(ConstructionFlavour.Regulation, buildingType, climateZone, startDate, endDate, source.Trim());
                        for (int j = 0; j < constructionRoles_Regulation.Count; j++)
                        {
                            ConstructionRole constructionRole = constructionRoles_Regulation[j];
                            double value = values[j];
                            if (double.IsNaN(value))
                            {
                                continue;
                            }

                            string group = Group(constructionRole);
                            string key = string.Format(CultureInfo.InvariantCulture, "PL.Regulation.{0}.{1}.{2}", DateText(startDate), group, Text(value));
                            string name = string.Format(CultureInfo.InvariantCulture, "{0} U(max) {1} ({2})", group, Text(value), DateText(startDate));
                            string description = string.Format(CultureInfo.InvariantCulture, "U(max) = {0} W/(m2K) of {1} for {2}, in force from {3}: a regulation limit, not a surveyed construction.", Text(value), regulationAct.Reference, group, DateText(startDate));

                            constructionSet.SetConstruction(constructionRole, Construction(constructionRole, key, name, description, value, double.NaN));
                        }

                        result.Add(constructionSet);
                    }

                    Regulation(null, values_III);
                    if (zoneDependent)
                    {
                        Regulation(ClimateZone.IV, values_IV);
                        Regulation(ClimateZone.V, values_V);
                    }
                }
            }

            return result;
        }
    }
}
