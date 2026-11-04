using DiGi.Analytical.Building.Classes;
using DiGi.Analytical.Building.Enums;
using DiGi.Analytical.Building.HVAC.Classes;
using DiGi.Analytical.Building.HVAC.Enums;
using DiGi.Analytical.Building.HVAC.Interfaces;
using DiGi.Analytical.Building.Interfaces;
using DiGi.Analytical.Building.Regulation.Classes;
using DiGi.Analytical.Building.Regulation.Enums;
using DiGi.Analytical.Classes;
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
        public const string ConstructionLibrary_PL_Version = "1.3.0";

        /// <summary>
        /// The date the material values of <see cref="ConstructionLibrary_PL"/> were read from their secondary sources (DiGi-Organization/DiGi.Analytical#18).
        /// </summary>
        public const string ConstructionLibrary_PL_MaterialRetrievalDate = "2026-11-04";

        /// <summary>
        /// The absolute part of the tolerance within which the U of a TypicalAsBuilt layered assembly, calculated per PN-EN ISO 6946, reproduces its declared U [W/(m2K)]: |U_calc - U_declared| ≤ max(<see cref="ConstructionLibrary_PL_LayerTolerance_Absolute"/>, <see cref="ConstructionLibrary_PL_LayerTolerance_Relative"/> · U_declared) (DiGi-Organization/DiGi.Analytical#18).
        /// </summary>
        public const double ConstructionLibrary_PL_LayerTolerance_Absolute = 0.02;

        /// <summary>
        /// The relative part of the tolerance within which the U of a TypicalAsBuilt layered assembly reproduces its declared U: |U_calc - U_declared| ≤ max(<see cref="ConstructionLibrary_PL_LayerTolerance_Absolute"/>, <see cref="ConstructionLibrary_PL_LayerTolerance_Relative"/> · U_declared) (DiGi-Organization/DiGi.Analytical#18).
        /// </summary>
        public const double ConstructionLibrary_PL_LayerTolerance_Relative = 0.05;

        /// <summary>
        /// Creates the Polish construction library: declared-U constructions of residential buildings, chosen per building type and date by <see cref="ConstructionSet"/>s (DiGi-Organization/DiGi.Analytical#15).
        /// <para><see cref="ConstructionFlavour.TypicalAsBuilt"/> sets hold the constructions of the Polish national typology of the TABULA web tool (webtool.building-typology.eu), one set per TABULA building: 7 construction periods for single-family, terraced and multi-family buildings, 5 for apartment blocks. TABULA has no apartment block before 1967, so for those periods the set holds the multi-family constructions. The values are those published, read on <see cref="ConstructionLibrary_PL_RetrievalDate"/>. There is one construction per TABULA construction code, and its description names the code.</para>
        /// <para>Each TypicalAsBuilt set also carries the building's <see cref="TypologyData"/> (DiGi-Organization/DiGi.Analytical#17): frame area fraction, thermal bridging surcharge, floor boundary, the additional resistance of an unheated cellar, roof type, b_tr,floor, F_w and the attached neighbours. A floor construction carries the construction's own U. TABULA publishes the floor U of a building over an unheated cellar with R = 0.3 m2K/W included, so the same construction code appeared with two U-values; since version 1.1.0 that resistance is <see cref="TypologyData.AdditionalFloorResistance"/> instead.</para>
        /// <para><see cref="ConstructionFlavour.Regulation"/> sets hold, for every stage of the technical conditions in <see cref="HVAC.Create.RegulatedHeatTransferCoefficientsManager"/> (from the PN-53/57 norm stage of 1955-01-01 onwards, DiGi-Organization/DiGi.Analytical#20), one construction per role whose declared U is the U(max) of <see cref="Query.RegulatedHeatTransferCoefficient"/>. A role with no limit has no construction, and the set's source says why. Until 1975 the wall limit and from 1983 until 2013 the window limits depend on the climatic zone, so those stages have a set for every zone (the zone I-III limits) plus sets for zones IV and V.</para>
        /// <para><b>Layers</b> (DiGi-Organization/DiGi.Analytical#18). Every wall, roof and floor construction also has layers (index 0 outermost; a floor's outer face is the ground or cellar side) of <see cref="OpaqueMaterial"/>s whose λ, ρ and c are tagged with the norm table and the secondary source that reproduces it, retrieved <see cref="ConstructionLibrary_PL_MaterialRetrievalDate"/>. A TypicalAsBuilt assembly has one fitted layer whose thickness (rounded to 1 mm) makes its PN-EN ISO 6946 U reproduce the declared TABULA U within <see cref="ConstructionLibrary_PL_LayerTolerance_Absolute"/> / <see cref="ConstructionLibrary_PL_LayerTolerance_Relative"/>; walls take horizontal, roofs upward and floors downward heat flow, floors without ground contact. A Regulation assembly has its insulation in whole centimetres, the least that keeps its U at or below U(max). InternalWall, PartyWall and IntermediateFloor of the TypicalAsBuilt sets are layered DEFAULT assemblies with no declared U, for thermal mass.</para>
        /// <para>The declared U stays on every TABULA and Regulation construction, and <see cref="Building.Query.ThermalTransmittance(ConstructionRelationCluster?, IPhysicalComponentConstruction?, HeatFlowDirection, bool)"/> returns it as it stands; the U of the layers alone is <c>Building.Query.ThermalTransmittance(IEnumerable&lt;(IStructureLayer, IMaterial?)&gt;, HeatFlowDirection, bool)</c> of <c>GetStructureLayers</c> and <c>GetMaterial</c>, which is also the route to a floor's ground-contact U.</para>
        /// <para>Window and door constructions carry declared values only and have no outline, so they are cloned with one where an opening needs it. Every identifier is derived from a stable key, so the library serializes to the same text each time it is created: the embedded copy read by <see cref="Query.EmbeddedConstructionLibrary_PL"/> is this method's output.</para>
        /// </summary>
        /// <returns>The Polish construction library.</returns>
        public static ConstructionLibrary ConstructionLibrary_PL()
        {
            const string webTool = "webtool.building-typology.eu";

            ConstructionLibrary result = new(Core.Create.Guid("PL.ConstructionLibrary"), "PL", ConstructionLibrary_PL_Version, string.Format(CultureInfo.InvariantCulture, "Polish construction library of declared U-values (DiGi-Organization/DiGi.Analytical#15). TypicalAsBuilt: the Polish national typology of the TABULA web tool ({0}), retrieved {1}. Regulation: the k(max) of the norms PN-53/57 to PN-91/B-02020 from 1955-01-01 and the U(max) of the technical conditions from 1998-04-29 onwards (RegulatedHeatTransferCoefficientsManager).", webTool, ConstructionLibrary_PL_RetrievalDate));

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
                        if (!double.IsNaN(thermalTransmittance))
                        {
                            physicalComponentConstruction.SetValue(PhysicalComponentConstructionParameter.ThermalTransmittance, thermalTransmittance);
                        }
                        construction = physicalComponentConstruction;
                        break;
                }

                constructions[guid] = construction;
                result.ConstructionRelationCluster.Add(construction);
                return construction;
            }

            // Materials (DiGi-Organization/DiGi.Analytical#18). None of PN-EN ISO 10456, PN-EN 12524 or PN-91/B-02020 is readable online, so every value is
            // read from a secondary reproduction of their tables, tagged with it, and listed on the wiki page Required Standards as not checked against the original.
            // λ is the design value in medium-moist conditions, c the dry specific heat. No source gives μ, so it is not set.
            string tableZA1 = string.Format(CultureInfo.InvariantCulture, "PN-EN 12524 and PN-91/B-02020 as reproduced in Tabl. ZA.1 \"Zestawienie parametrów fizycznych materiałów / wyrobów budowlanych wg PN-EN 12524, PN-EN ISO 6946 i PN-91/B-02020\", Ochrona cieplna - zadania na ćwiczenia, Studia podyplomowe OiCEB (zanotowane.pl/16/1384, retrieved {0})", ConstructionLibrary_PL_MaterialRetrievalDate);

            Dictionary<string, OpaqueMaterial> materials = [];
            void Material(string key, string name, double density, double specificHeat, double conductivity, string source)
            {
                OpaqueMaterial opaqueMaterial = new(Core.Create.Guid(string.Concat("PL.Material.", key)), name)
                {
                    Conductivity = conductivity,
                    Density = density,
                    SpecificHeat = specificHeat,
                    Description = string.Format(CultureInfo.InvariantCulture, "λ = {0} W/(mK), ρ = {1} kg/m3, c = {2} J/(kgK): {3}. Not checked against the original norm.", Text(conductivity), Text(density), Text(specificHeat), source),
                };

                materials[key] = opaqueMaterial;
                result.ConstructionRelationCluster.Add(opaqueMaterial);
            }

            string Row(string row)
            {
                return string.Format(CultureInfo.InvariantCulture, "{0}, {1}", tableZA1, row);
            }

            Material("SolidBrickMasonry", "Solid ceramic brick masonry, cement-lime mortar", 1800, 880, 0.77, Row("row 20 \"Mur z cegły ceramicznej pełnej na zaprawie c-w\"; izosystems.pl (Wartości współczynnika lambda) gives 0.77 too, muratordom.pl (Współczynnik lambda) gives 0.70; 0.77 is used, the value of the norm table"));
            Material("HollowBrickMasonry", "Hollow ceramic brick masonry (dziurawka), cement-lime mortar", 1400, 880, 0.62, Row("row 21 \"Mur z cegły dziurawki na zaprawie c-w\""));
            Material("CeramicHollowBlockMasonry", "Ceramic hollow block masonry (MAX)", 1100, 880, 0.44, Row("row 26 \"Mur z pustaków ceramicznych MAX\" for ρ and λ; the row prints no c, so c is DEFAULT, taken from the ceramic brick masonry of row 20"));
            Material("SlagConcrete_1400", "Slag concrete (furnace slag) 1400 kg/m3", 1400, 840, 0.60, Row("row 12 \"Beton z żużla paleniskowego\", ρ = 1400"));
            Material("SlagConcrete_1200", "Slag concrete (furnace slag) 1200 kg/m3", 1200, 840, 0.50, Row("row 12 \"Beton z żużla paleniskowego\", ρ = 1200"));
            Material("AeratedConcreteMasonry_600", "Aerated concrete masonry 600 kg/m3, thin-joint mortar", 600, 840, 0.21, Row("row 15 \"Mur z betonu komórkowego na cienkowarstwowej zaprawie klejącej\", ρ = 600"));
            Material("AeratedConcreteMasonry_600_CementLimeMortar", "Aerated concrete masonry 600 kg/m3, cement-lime mortar", 600, 840, 0.30, Row("row 16 \"Mur z betonu komórkowego na zaprawie cementowo-wapiennej\", ρ = 600"));
            Material("AeratedConcreteMasonry_700", "Aerated concrete masonry 700 kg/m3, thin-joint mortar", 700, 840, 0.25, Row("row 15 \"Mur z betonu komórkowego na cienkowarstwowej zaprawie klejącej\", ρ = 700"));
            Material("ExpandedClayConcrete_1200", "Expanded-clay concrete 1200 kg/m3", 1200, 840, 0.54, Row("row 13 \"Beton z kruszywa keramzytowego\", ρ = 1200"));
            Material("ReinforcedConcrete", "Reinforced concrete", 2500, 840, 1.70, Row("row 5 \"Żelbet\"; the same table also prints 2.30 / 2.50 W/(mK) for reinforced concrete with 1 % / 2 % steel in another column, and 1.70 is used"));
            Material("Concrete_2200", "Plain concrete, stone aggregate, 2200 kg/m3", 2200, 840, 1.30, Row("row 7 \"Beton zwykły z kruszywa kamiennego\", ρ = 2200; another column prints 1.65 W/(mK) and c = 1000, and 1.30 is used"));
            Material("LightConcrete_1200", "Light poured concrete (pumice or granulated slag aggregate) 1200 kg/m3", 1200, 840, 0.40, Row("row 11 \"Beton z żużla pumeksowego lub granulowanego\", ρ = 1200"));
            Material("ExpandedPolystyrene", "Expanded polystyrene (EPS)", 30, 1460, 0.040, Row("row 145 \"Styropian\", ρ = 15-40 (30 used); the row also prints 0.045 for ρ = 10 and 0.043 for ρ = 20, and 0.040 is used"));
            Material("MineralWool", "Mineral wool felt, mat or board", 60, 750, 0.045, Row("row 121 \"Filce, maty i płyty z wełny mineralnej\", ρ = 40-80 (60 used)"));
            Material("Softwood", "Softwood (pine, spruce) across the grain", 550, 2510, 0.16, Row("row 49 \"Sosna i świerk - w poprzek włókien\""));
            Material("PorousFibreboard", "Porous wood fibreboard", 300, 2510, 0.06, Row("row 54 \"Płyty pilśniowe porowate\"; another column prints 0.05, and 0.06 is used"));
            Material("GypsumPlasterboard", "Gypsum plasterboard", 1000, 1000, 0.23, Row("row 69 \"Płyty gipsowo-kartonowe\", ρ = 1000"));
            Material("LimePlaster", "Lime plaster", 1700, 840, 0.70, Row("row 214 \"Tynk wapienny\""));
            Material("CementLimePlaster", "Cement-lime plaster", 1850, 840, 0.82, Row("row 213 \"Tynk lub gładź cementowo-wapienna\""));
            Material("CementScreed", "Cement screed", 2000, 840, 1.00, Row("row 211 \"Tynk lub gładź cementowa\""));
            Material("RoofingFelt", "Bituminous roofing felt", 1000, 1460, 0.18, Row("row 163 \"Papa asfaltowa\""));
            Material("ClayPugging", "Clay pugging", 1800, 840, 0.85, Row("row 72 \"Glina\"; the table has no row for pugging (polepa), so the clay row stands in for it"));

            static HeatFlowDirection Direction(ConstructionRole constructionRole)
            {
                return constructionRole switch
                {
                    ConstructionRole.Roof or ConstructionRole.FlatRoof => HeatFlowDirection.Upward,
                    ConstructionRole.GroundFloor or ConstructionRole.FloorOverUnheated or ConstructionRole.IntermediateFloor => HeatFlowDirection.Downward,
                    _ => HeatFlowDirection.Horizontal,
                };
            }

            // Resolves layer specifications (material key, thickness [m]; NaN marks the one layer to fit) into materials and thicknesses.
            // The fitted thickness makes the PN-EN ISO 6946 U of the layers, without ground contact, equal U: rounded to 1 mm (round, TypicalAsBuilt)
            // or raised to the next whole centimetre (ceiling, Regulation, where a non-positive thickness drops the layer).
            List<(OpaqueMaterial Material, double Thickness)> Layers(List<(string MaterialKey, double Thickness)> layerSpecifications, HeatFlowDirection heatFlowDirection, double thermalTransmittance, bool ceiling)
            {
                double thermalResistance = Building.Query.SurfaceResistance(heatFlowDirection, true) + Building.Query.SurfaceResistance(heatFlowDirection, false);
                foreach ((string materialKey, double thickness) in layerSpecifications)
                {
                    if (!double.IsNaN(thickness))
                    {
                        thermalResistance += thickness / materials[materialKey].Conductivity;
                    }
                }

                List<(OpaqueMaterial Material, double Thickness)> layers = [];
                foreach ((string materialKey, double thickness) in layerSpecifications)
                {
                    OpaqueMaterial opaqueMaterial = materials[materialKey];
                    if (!double.IsNaN(thickness))
                    {
                        layers.Add((opaqueMaterial, thickness));
                        continue;
                    }

                    double thickness_Fitted = opaqueMaterial.Conductivity * ((1.0 / thermalTransmittance) - thermalResistance);
                    if (ceiling)
                    {
                        thickness_Fitted = Math.Ceiling((thickness_Fitted * 100.0) - 1e-9) / 100.0;
                        if (thickness_Fitted <= 0)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        thickness_Fitted = Math.Round(thickness_Fitted, 3, MidpointRounding.AwayFromZero);
                    }

                    layers.Add((opaqueMaterial, thickness_Fitted));
                }

                return layers;
            }

            static double LayersThermalTransmittance(List<(OpaqueMaterial Material, double Thickness)> layers, HeatFlowDirection heatFlowDirection)
            {
                double thermalResistance = Building.Query.SurfaceResistance(heatFlowDirection, true) + Building.Query.SurfaceResistance(heatFlowDirection, false);
                foreach ((OpaqueMaterial material, double thickness) in layers)
                {
                    thermalResistance += thickness / material.Conductivity;
                }

                return 1.0 / thermalResistance;
            }

            static string LayersText(List<(OpaqueMaterial Material, double Thickness)> layers)
            {
                List<string> texts = layers.ConvertAll(x => string.Format(CultureInfo.InvariantCulture, "{0} {1} mm", x.Material.Name, Text(Math.Round(x.Thickness * 1000.0, 1))));
                return string.Join(", ", texts);
            }

            // Adds the layers to a construction that has none yet; a construction shared by several sets gets its layers once.
            void AddLayers(IConstruction construction, string key, List<(OpaqueMaterial Material, double Thickness)> layers)
            {
                if (construction is not IPhysicalComponentConstruction physicalComponentConstruction || result.ConstructionRelationCluster.GetStructureLayers(physicalComponentConstruction) is { Count: > 0 })
                {
                    return;
                }

                for (int i = 0; i < layers.Count; i++)
                {
                    Building.Create.StructureLayer(result.ConstructionRelationCluster, physicalComponentConstruction, layers[i].Material, layers[i].Thickness, Core.Create.Guid(string.Format(CultureInfo.InvariantCulture, "{0}.Layer.{1}", key, i)));
                }
            }

            // A layered construction with no declared U (InternalWall, PartyWall, IntermediateFloor): DEFAULT layers representative of the period's practice.
            IConstruction DefaultConstruction(ConstructionRole constructionRole, string variant, string name, List<(string MaterialKey, double Thickness)> layerSpecifications)
            {
                string key = string.Format(CultureInfo.InvariantCulture, "PL.Default.{0}.{1}", constructionRole, variant);
                List<(OpaqueMaterial Material, double Thickness)> layers = Layers(layerSpecifications, Direction(constructionRole), double.NaN, false);
                string description = string.Format(CultureInfo.InvariantCulture, "DEFAULT {0} assembly, representative of the period's practice, with no source and no declared U; it exists for thermal mass (DiGi-Organization/DiGi.Analytical#18). Layers: {1}.", constructionRole, LayersText(layers));
                IConstruction construction = Construction(constructionRole, key, name, description, double.NaN, double.NaN);
                AddLayers(construction, key, layers);
                return construction;
            }

            // TypicalAsBuilt: one row per TABULA building of the Polish national typology, as published.
            // Columns: building code, period, type, roof type (TR pitched / FR flat), floor boundary, additional floor resistance R [m2K/W] (unheated cellar),
            // g_gl,n, frame area fraction F_f, thermal bridging surcharge ΔU_tb [W/(m2K)], attached neighbours (B_Alone 0, B_N1 1),
            // then per element (roof1, wall1, floor1, window1, door1): construction code, name, U [W/(m2K)].
            // The floor U is the construction's own: over a cellar TABULA publishes 1 / (1 / U + R), so U = 1 / (1 / U_published - R) (PL.Floor.ReEx.05.01: 0.769 published, 1.0 here and on soil).
            // Every Polish record gives b_tr,floor = 0.5 and F_w = 0.9 (read 2026-10-30).
            const double floorTemperatureReductionFactor = 0.5;
            const double nonPerpendicularIncidenceFactor = 0.9;
            List<(string Code, ConstructionPeriod ConstructionPeriod, BuildingType BuildingType, string RoofType, string FloorBoundary, double AdditionalFloorResistance, double TotalSolarEnergyTransmittance, double FrameAreaFraction, double ThermalBridging, int AttachedNeighbours, (string Code, string Name, double ThermalTransmittance) Roof, (string Code, string Name, double ThermalTransmittance) Wall, (string Code, string Name, double ThermalTransmittance) Floor, (string Code, string Name, double ThermalTransmittance) Window, (string Code, string Name, double ThermalTransmittance) Door)> buildings =
            [
                ("PL.N.SFH.01.Gen.ReEx.001", Enums.ConstructionPeriod.Until1945, BuildingType.SingleFamily, "TR", "Soil", 0.0, 0.85, 0.3, 0.15, 0, ("PL.Roof.ReEx.01.03", "Pitched roof insulated on rafter", 0.7), ("PL.Wall.ReEx.01.02", "2 brick wall", 1.55), ("PL.Floor.ReEx.01.01", "Solid ground floor", 2.2), ("PL.Window.ReEx.01.01", "single glazed, wood frame", 5.0), ("PL.Door.ReEx.01.01", "Wooden door", 5.1)),
                ("PL.N.TH.01.Gen.ReEx.001", Enums.ConstructionPeriod.Until1945, BuildingType.Terraced, "FR", "Soil", 0.0, 0.85, 0.3, 0.15, 1, ("PL.Roof.ReEx.01.04", "Pitched roof insulated on ceilings", 0.9), ("PL.Wall.ReEx.01.01", "1,5 brick wall1", 1.95), ("PL.Floor.ReEx.01.01", "Solid ground floor", 2.2), ("PL.Window.ReEx.01.01", "single glazed, wood frame", 5.0), ("PL.Door.ReEx.01.01", "Wooden door", 5.1)),
                ("PL.N.MFH.01.Gen.ReEx.001", Enums.ConstructionPeriod.Until1945, BuildingType.MultiFamily, "FR", "Cellar", 0.3, 0.85, 0.3, 0.15, 0, ("PL.Roof.ReEx.01.02", "Flat roof nonventilated", 0.9), ("PL.Wall.ReEx.01.02", "2 brick wall", 1.55), ("PL.Floor.ReEx.01.02", "Suspended floor", 1.8), ("PL.Window.ReEx.01.01", "single glazed, wood frame", 5.0), ("PL.Door.ReEx.01.01", "Wooden door", 5.1)),
                ("PL.N.SFH.02.Gen.ReEx.001", Enums.ConstructionPeriod.From1946To1966, BuildingType.SingleFamily, "TR", "Soil", 0.0, 0.85, 0.3, 0.15, 0, ("PL.Roof.ReEx.02.03", "Pitched roof insulated on rafter", 0.6), ("PL.Wall.ReEx.02.01", "2 brick wall", 1.55), ("PL.Floor.ReEx.02.01", "Solid ground floor", 1.8), ("PL.Window.ReEx.02.01", "single glazed, wood frame", 5.0), ("PL.Door.ReEx.02.01", "Wooden door", 4.5)),
                ("PL.N.TH.02.Gen.ReEx.001", Enums.ConstructionPeriod.From1946To1966, BuildingType.Terraced, "FR", "Soil", 0.0, 0.85, 0.3, 0.1, 1, ("PL.Roof.ReEx.02.03", "Pitched roof insulated on rafter", 0.6), ("PL.Wall.ReEx.02.01", "2 brick wall", 1.55), ("PL.Floor.ReEx.02.01", "Solid ground floor", 1.8), ("PL.Window.ReEx.02.01", "single glazed, wood frame", 5.0), ("PL.Door.ReEx.02.01", "Wooden door", 4.5)),
                ("PL.N.MFH.02.Gen.ReEx.001", Enums.ConstructionPeriod.From1946To1966, BuildingType.MultiFamily, "FR", "Cellar", 0.3, 0.75, 0.3, 0.15, 0, ("PL.Roof.ReEx.02.02", "Flat roof nonventilated", 0.5), ("PL.Wall.ReEx.02.01", "2 brick wall", 1.55), ("PL.Floor.ReEx.02.02", "Suspended floor", 1.5), ("PL.Window.ReEx.02.02", "French window", 2.6), ("PL.Door.ReEx.02.01", "Wooden door", 4.5)),
                ("PL.N.SFH.03.Gen.ReEx.001", Enums.ConstructionPeriod.From1967To1985, BuildingType.SingleFamily, "TR", "Soil", 0.0, 0.75, 0.3, 0.15, 0, ("PL.Roof.ReEx.03.04", "Pitched roof insulated on ceilings", 0.5), ("PL.Wall.ReEx.03.02", "hollowbloks", 1.03), ("PL.Floor.ReEx.03.01", "Solid ground floor", 1.6), ("PL.Window.ReEx.03.02", "wood frame, double glazed air filled (7,5 mm gap)", 2.6), ("PL.Door.ReEx.03.01", "Wooden door", 4.0)),
                ("PL.N.TH.03.Gen.ReEx.001", Enums.ConstructionPeriod.From1967To1985, BuildingType.Terraced, "FR", "Soil", 0.0, 0.75, 0.3, 0.1, 1, ("PL.Roof.ReEx.03.03", "Pitched roof insulated on rafter", 0.6), ("PL.Wall.ReEx.03.02", "hollowbloks", 1.03), ("PL.Floor.ReEx.03.01", "Solid ground floor", 1.6), ("PL.Window.ReEx.03.02", "wood frame, double glazed air filled (7,5 mm gap)", 2.6), ("PL.Door.ReEx.03.01", "Wooden door", 4.0)),
                ("PL.N.MFH.03.Gen.ReEx.001", Enums.ConstructionPeriod.From1967To1985, BuildingType.MultiFamily, "FR", "Cellar", 0.3, 0.75, 0.3, 0.1, 0, ("PL.Roof.ReEx.03.01", "Flat roof ventilated", 0.6), ("PL.Wall.ReEx.03.03", "PrefconConcretePanels", 1.3), ("PL.Floor.ReEx.03.02", "Suspended floor", 1.3), ("PL.Window.ReEx.03.01", "French window", 2.6), ("PL.Door.ReEx.03.01", "Wooden door", 4.0)),
                ("PL.N.AB.03.Gen.ReEx.001", Enums.ConstructionPeriod.From1967To1985, BuildingType.ApartmentBlock, "FR", "Cellar", 0.3, 0.75, 0.3, 0.1, 0, ("DE.Roof.SyAv.09.01", "average U-value for roofs or top ceilings / single-unit housing / construction years 1995 ... 2009 (SUH III) / not refurbished", 0.33), ("PL.Wall.ReEx.03.03", "PrefconConcretePanels", 1.3), ("PL.Floor.ReEx.03.02", "Suspended floor", 1.3), ("PL.Window.ReEx.03.01", "French window", 2.6), ("PL.Door.ReEx.03.01", "Wooden door", 4.0)),
                ("PL.N.SFH.04.Gen.ReEx.001", Enums.ConstructionPeriod.From1986To1992, BuildingType.SingleFamily, "TR", "Soil", 0.0, 0.73, 0.3, 0.1, 0, ("PL.Roof.ReEx.04.04", "Pitched roof insulated on ceilings", 0.4), ("PL.Wall.ReEx.04.03", "PrefconConcretePanels", 1.3), ("PL.Floor.ReEx.04.01", "Solid ground floor", 1.4), ("PL.Window.ReEx.04.02", "wood frame, double glazed air filled (7,5 mm gap)", 2.6), ("PL.Door.ReEx.04.01", "Wooden door", 3.6)),
                ("PL.N.TH.04.Gen.ReEx.001", Enums.ConstructionPeriod.From1986To1992, BuildingType.Terraced, "FR", "Soil", 0.0, 0.73, 0.3, 0.1, 1, ("PL.Roof.ReEx.04.03", "Pitched roof insulated on rafter", 0.5), ("PL.Wall.ReEx.04.01", "brickwall & internal  insulation (3 layer)", 0.49), ("PL.Floor.ReEx.04.01", "Solid ground floor", 1.4), ("PL.Window.ReEx.04.02", "wood frame, double glazed air filled (7,5 mm gap)", 2.6), ("PL.Door.ReEx.04.01", "Wooden door", 3.6)),
                ("PL.N.MFH.04.Gen.ReEx.001", Enums.ConstructionPeriod.From1986To1992, BuildingType.MultiFamily, "FR", "Cellar", 0.3, 0.73, 0.3, 0.1, 0, ("PL.Roof.ReEx.04.01", "Flat roof ventilated", 0.5), ("PL.Wall.ReEx.04.04", "H-Frame", 1.1), ("PL.Floor.ReEx.04.02", "Suspended floor", 1.1), ("PL.Window.ReEx.04.02", "wood frame, double glazed air filled (7,5 mm gap)", 2.6), ("PL.Door.ReEx.04.01", "Wooden door", 3.6)),
                ("PL.N.AB.04.Gen.ReEx.001", Enums.ConstructionPeriod.From1986To1992, BuildingType.ApartmentBlock, "FR", "Cellar", 0.3, 0.75, 0.3, 0.1, 0, ("PL.Roof.ReEx.01.02", "Flat roof nonventilated", 0.9), ("PL.Wall.ReEx.04.03", "PrefconConcretePanels", 1.3), ("PL.Floor.ReEx.04.02", "Suspended floor", 1.1), ("PL.Window.ReEx.04.01", "French window", 2.6), ("PL.Door.ReEx.04.01", "Wooden door", 3.6)),
                ("PL.N.SFH.05.Gen.ReEx.001", Enums.ConstructionPeriod.From1993To2002, BuildingType.SingleFamily, "TR", "Soil", 0.0, 0.77, 0.3, 0.1, 0, ("PL.Roof.ReEx.05.04", "Pitched roof insulated on ceilings", 0.4), ("PL.Wall.ReEx.05.05", "LightFrame", 0.4), ("PL.Floor.ReEx.05.01", "Solid ground floor", 1.0), ("PL.Window.ReEx.05.02", "plastic frame, glass unit (one cell)", 1.6), ("PL.Door.ReEx.05.02", "Plastic or Compsite door", 2.5)),
                ("PL.N.TH.05.Gen.ReEx.001", Enums.ConstructionPeriod.From1993To2002, BuildingType.Terraced, "FR", "Cellar", 0.3, 0.77, 0.3, 0.1, 1, ("PL.Roof.ReEx.05.04", "Pitched roof insulated on ceilings", 0.4), ("PL.Wall.ReEx.05.01", "brickwall & internal  insulation (3 layer)", 0.19), ("PL.Floor.ReEx.05.01", "Solid ground floor", 1.0), ("PL.Window.ReEx.05.02", "plastic frame, glass unit (one cell)", 1.6), ("PL.Door.ReEx.05.02", "Plastic or Compsite door", 2.5)),
                ("PL.N.MFH.05.Gen.ReEx.001", Enums.ConstructionPeriod.From1993To2002, BuildingType.MultiFamily, "FR", "Cellar", 0.3, 0.77, 0.3, 0.1, 0, ("PL.Roof.ReEx.05.01", "Flat roof ventilated", 0.5), ("PL.Wall.ReEx.05.02", "H-Frame", 0.19), ("PL.Floor.ReEx.05.02", "Suspended floor", 0.8), ("PL.Window.ReEx.05.02", "plastic frame, glass unit (one cell)", 1.6), ("PL.Door.ReEx.05.02", "Plastic or Compsite door", 2.5)),
                ("PL.N.AB.05.Gen.ReEx.001", Enums.ConstructionPeriod.From1993To2002, BuildingType.ApartmentBlock, "FR", "Cellar", 0.3, 0.77, 0.3, 0.1, 0, ("PL.Roof.ReEx.02.02", "Flat roof nonventilated", 0.5), ("PL.Wall.ReEx.05.03", "hollowbloks", 0.18), ("PL.Floor.ReEx.05.02", "Suspended floor", 0.8), ("PL.Window.ReEx.05.02", "plastic frame, glass unit (one cell)", 1.6), ("PL.Door.ReEx.05.02", "Plastic or Compsite door", 2.5)),
                ("PL.N.SFH.06.Gen.ReEx.001", Enums.ConstructionPeriod.From2003To2008, BuildingType.SingleFamily, "TR", "Soil", 0.0, 0.77, 0.3, 0.1, 0, ("PL.Roof.ReEx.06.04", "Pitched roof insulated on ceilings", 0.3), ("PL.Wall.ReEx.06.02", "hollowbloks", 0.18), ("PL.Floor.ReEx.06.02", "Suspended floor", 0.6), ("PL.Window.ReEx.06.04", "plastic frame, glass unit ( (one cell gas filled)", 1.2), ("PL.Door.ReEx.06.02", "Plastic or Compsite insulated", 1.8)),
                ("PL.N.TH.06.Gen.ReEx.001", Enums.ConstructionPeriod.From2003To2008, BuildingType.Terraced, "FR", "Cellar", 0.3, 0.77, 0.3, 0.05, 1, ("PL.Roof.ReEx.06.04", "Pitched roof insulated on ceilings", 0.3), ("PL.Wall.ReEx.06.01", "brickwall & internal  insulation (3 layer)", 0.19), ("PL.Floor.ReEx.06.02", "Suspended floor", 0.6), ("PL.Window.ReEx.06.04", "plastic frame, glass unit ( (one cell gas filled)", 1.2), ("PL.Door.ReEx.06.02", "Plastic or Compsite insulated", 1.8)),
                ("PL.N.MFH.06.Gen.ReEx.001", Enums.ConstructionPeriod.From2003To2008, BuildingType.MultiFamily, "FR", "Cellar", 0.3, 0.77, 0.3, 0.1, 0, ("PL.Roof.ReEx.06.01", "Flat roof ventilated", 0.4), ("PL.Wall.ReEx.06.02", "hollowbloks", 0.18), ("PL.Floor.ReEx.06.02", "Suspended floor", 0.6), ("PL.Window.ReEx.06.02", "plastic frame, glass unit (one cell)", 1.5), ("PL.Door.ReEx.06.02", "Plastic or Compsite insulated", 1.8)),
                ("PL.N.AB.06.Gen.ReEx.001", Enums.ConstructionPeriod.From2003To2008, BuildingType.ApartmentBlock, "FR", "Cellar", 0.3, 0.77, 0.3, 0.1, 0, ("PL.Roof.ReEx.03.01", "Flat roof ventilated", 0.6), ("PL.Wall.ReEx.06.01", "brickwall & internal  insulation (3 layer)", 0.19), ("PL.Floor.ReEx.06.02", "Suspended floor", 0.6), ("PL.Window.ReEx.06.02", "plastic frame, glass unit (one cell)", 1.5), ("PL.Door.ReEx.06.02", "Plastic or Compsite insulated", 1.8)),
                ("PL.N.SFH.07.Gen.ReEx.001", Enums.ConstructionPeriod.From2009, BuildingType.SingleFamily, "TR", "Soil", 0.0, 0.5, 0.3, 0.1, 0, ("PL.Roof.ReEx.07.04", "Pitched roof insulated on ceilings", 0.25), ("PL.Wall.ReEx.07.01", "brickwall & internal  insulation (3 layer)", 0.19), ("PL.Floor.ReEx.07.02", "Suspended floor", 0.5), ("PL.Window.ReEx.07.04", "plastic frame, glass unit ( (one cell gas filled)", 1.1), ("PL.Door.ReEx.07.02", "Plastic or Compsite door", 1.7)),
                ("PL.N.TH.07.Gen.ReEx.001", Enums.ConstructionPeriod.From2009, BuildingType.Terraced, "FR", "Cellar", 0.3, 0.5, 0.3, 0.05, 1, ("PL.Roof.ReEx.07.04", "Pitched roof insulated on ceilings", 0.25), ("PL.Wall.ReEx.07.01", "brickwall & internal  insulation (3 layer)", 0.19), ("PL.Floor.ReEx.07.02", "Suspended floor", 0.5), ("PL.Window.ReEx.07.04", "plastic frame, glass unit ( (one cell gas filled)", 1.1), ("PL.Door.ReEx.07.02", "Plastic or Compsite door", 1.7)),
                ("PL.N.MFH.07.Gen.ReEx.001", Enums.ConstructionPeriod.From2009, BuildingType.MultiFamily, "FR", "Cellar", 0.3, 0.77, 0.3, 0.1, 0, ("PL.Roof.ReEx.07.01", "Flat roof ventilated", 0.3), ("PL.Wall.ReEx.07.02", "hollowbloks", 0.18), ("PL.Floor.ReEx.07.02", "Suspended floor", 0.5), ("PL.Window.ReEx.07.02", "plastic frame, glass unit (one cell)", 1.4), ("PL.Door.ReEx.07.03", "Metal insulated", 1.4)),
                ("PL.N.AB.07.Gen.ReEx.001", Enums.ConstructionPeriod.From2009, BuildingType.ApartmentBlock, "FR", "Cellar", 0.3, 0.77, 0.3, 0.15, 0, ("PL.Roof.ReEx.04.01", "Flat roof ventilated", 0.5), ("PL.Wall.ReEx.07.01", "brickwall & internal  insulation (3 layer)", 0.19), ("PL.Floor.ReEx.07.02", "Suspended floor", 0.5), ("PL.Window.ReEx.07.02", "plastic frame, glass unit (one cell)", 1.4), ("PL.Door.ReEx.07.02", "Plastic or Compsite door", 1.7)),
            ];

            // Layers of the TABULA wall, roof and floor constructions (DiGi-Organization/DiGi.Analytical#18), outside to inside; a floor's outer face is the ground or cellar side.
            // NaN marks the layer whose thickness is fitted to the declared U. The composition follows the TABULA name and the period's practice; it has no source.
            const double fitted = double.NaN;
            List<(string MaterialKey, double Thickness)> brickWall_Lime = [("CementLimePlaster", 0.015), ("SolidBrickMasonry", fitted), ("LimePlaster", 0.015)];
            List<(string MaterialKey, double Thickness)> brickWall = [("CementLimePlaster", 0.015), ("SolidBrickMasonry", fitted), ("CementLimePlaster", 0.015)];
            List<(string MaterialKey, double Thickness)> hollowBlockWall = [("CementLimePlaster", 0.015), ("CeramicHollowBlockMasonry", fitted), ("CementLimePlaster", 0.015)];
            List<(string MaterialKey, double Thickness)> hollowBlockWall_Insulated = [("CementLimePlaster", 0.01), ("ExpandedPolystyrene", fitted), ("CeramicHollowBlockMasonry", 0.25), ("CementLimePlaster", 0.015)];
            List<(string MaterialKey, double Thickness)> sandwichPanelWall = [("ReinforcedConcrete", 0.06), ("MineralWool", fitted), ("ReinforcedConcrete", 0.15)];
            List<(string MaterialKey, double Thickness)> brickWall_InternalInsulation = [("CementLimePlaster", 0.015), ("SolidBrickMasonry", 0.25), ("MineralWool", fitted), ("GypsumPlasterboard", 0.0125)];
            List<(string MaterialKey, double Thickness)> expandedClayConcreteWall = [("CementLimePlaster", 0.015), ("ExpandedClayConcrete_1200", fitted), ("CementLimePlaster", 0.015)];
            List<(string MaterialKey, double Thickness)> expandedClayConcreteWall_Insulated = [("CementLimePlaster", 0.01), ("ExpandedPolystyrene", fitted), ("ExpandedClayConcrete_1200", 0.24), ("CementLimePlaster", 0.015)];
            List<(string MaterialKey, double Thickness)> lightFrameWall = [("PorousFibreboard", 0.02), ("MineralWool", fitted), ("GypsumPlasterboard", 0.0125)];
            List<(string MaterialKey, double Thickness)> rafterRoof = [("RoofingFelt", 0.005), ("Softwood", 0.025), ("MineralWool", fitted), ("LimePlaster", 0.015)];
            List<(string MaterialKey, double Thickness)> timberCeiling = [("Softwood", 0.025), ("MineralWool", fitted), ("Softwood", 0.025), ("LimePlaster", 0.015)];
            List<(string MaterialKey, double Thickness)> concreteCeiling = [("MineralWool", fitted), ("ReinforcedConcrete", 0.15), ("CementLimePlaster", 0.015)];
            List<(string MaterialKey, double Thickness)> flatRoof_NonVentilated = [("RoofingFelt", 0.01), ("CementScreed", 0.03), ("MineralWool", fitted), ("ReinforcedConcrete", 0.15), ("CementLimePlaster", 0.015)];
            List<(string MaterialKey, double Thickness)> flatRoof_EPS = [("RoofingFelt", 0.01), ("ExpandedPolystyrene", fitted), ("ReinforcedConcrete", 0.15), ("CementLimePlaster", 0.015)];
            List<(string MaterialKey, double Thickness)> groundFloor_Slag = [("Concrete_2200", 0.10), ("SlagConcrete_1400", fitted), ("CementScreed", 0.04)];
            List<(string MaterialKey, double Thickness)> groundFloor_EPS = [("Concrete_2200", 0.10), ("ExpandedPolystyrene", fitted), ("CementScreed", 0.04)];
            List<(string MaterialKey, double Thickness)> suspendedFloor_Slag = [("CementLimePlaster", 0.015), ("ReinforcedConcrete", 0.15), ("SlagConcrete_1400", fitted), ("CementScreed", 0.04)];
            List<(string MaterialKey, double Thickness)> suspendedFloor_EPS = [("CementLimePlaster", 0.015), ("ReinforcedConcrete", 0.15), ("ExpandedPolystyrene", fitted), ("CementScreed", 0.04)];

            Dictionary<string, (List<(string MaterialKey, double Thickness)> LayerSpecifications, string? Note)> elementLayers = new()
            {
                ["PL.Wall.ReEx.01.01"] = (brickWall_Lime, "a nominal 1.5-brick wall is 380 mm thick, which with the cited λ gives U = 1.42 W/(m2K): the fitted masonry under-states the wall's mass"),
                ["PL.Wall.ReEx.01.02"] = (brickWall_Lime, "a nominal 2-brick wall is 510 mm thick, which with the cited λ gives U = 1.15 W/(m2K): the fitted masonry under-states the wall's mass"),
                ["PL.Wall.ReEx.02.01"] = (brickWall, "a nominal 2-brick wall is 510 mm thick, which with the cited λ gives U = 1.15 W/(m2K): the fitted masonry under-states the wall's mass"),
                ["PL.Wall.ReEx.03.02"] = (hollowBlockWall, null),
                ["PL.Wall.ReEx.03.03"] = (sandwichPanelWall, "a sandwich panel, the representative system of the WUF-T / OW-T large-panel family; the TABULA U implies a degraded insulation core"),
                ["PL.Wall.ReEx.04.03"] = (sandwichPanelWall, "a sandwich panel, the representative system of the WUF-T / OW-T large-panel family; the TABULA U implies a degraded insulation core"),
                ["PL.Wall.ReEx.04.01"] = (brickWall_InternalInsulation, null),
                ["PL.Wall.ReEx.05.01"] = (brickWall_InternalInsulation, null),
                ["PL.Wall.ReEx.06.01"] = (brickWall_InternalInsulation, null),
                ["PL.Wall.ReEx.07.01"] = (brickWall_InternalInsulation, null),
                ["PL.Wall.ReEx.04.04"] = (expandedClayConcreteWall, "an expanded-clay concrete wall, the representative system of the Szczecin / W-70 large-panel family"),
                ["PL.Wall.ReEx.05.02"] = (expandedClayConcreteWall_Insulated, "an expanded-clay concrete wall (Szczecin / W-70) with external EPS"),
                ["PL.Wall.ReEx.05.05"] = (lightFrameWall, "a timber frame wall taken as homogeneous layers: the studs are not modelled"),
                ["PL.Wall.ReEx.05.03"] = (hollowBlockWall_Insulated, null),
                ["PL.Wall.ReEx.06.02"] = (hollowBlockWall_Insulated, null),
                ["PL.Wall.ReEx.07.02"] = (hollowBlockWall_Insulated, null),
                ["PL.Roof.ReEx.01.03"] = (rafterRoof, "the rafters are not modelled"),
                ["PL.Roof.ReEx.02.03"] = (rafterRoof, "the rafters are not modelled"),
                ["PL.Roof.ReEx.03.03"] = (rafterRoof, "the rafters are not modelled"),
                ["PL.Roof.ReEx.04.03"] = (rafterRoof, "the rafters are not modelled"),
                ["PL.Roof.ReEx.01.04"] = (timberCeiling, "the top ceiling below an unheated attic; the joists are not modelled"),
                ["PL.Roof.ReEx.03.04"] = (concreteCeiling, "the top ceiling below an unheated attic"),
                ["PL.Roof.ReEx.04.04"] = (concreteCeiling, "the top ceiling below an unheated attic"),
                ["PL.Roof.ReEx.05.04"] = (concreteCeiling, "the top ceiling below an unheated attic"),
                ["PL.Roof.ReEx.06.04"] = (concreteCeiling, "the top ceiling below an unheated attic"),
                ["PL.Roof.ReEx.07.04"] = (concreteCeiling, "the top ceiling below an unheated attic"),
                ["PL.Roof.ReEx.01.02"] = (flatRoof_NonVentilated, null),
                ["PL.Roof.ReEx.02.02"] = (flatRoof_NonVentilated, null),
                ["PL.Roof.ReEx.03.01"] = (concreteCeiling, "a ventilated flat roof, taken from the inside up to the ventilated cavity (PN-EN ISO 6946 disregards the layers above a well-ventilated cavity)"),
                ["PL.Roof.ReEx.04.01"] = (concreteCeiling, "a ventilated flat roof, taken from the inside up to the ventilated cavity (PN-EN ISO 6946 disregards the layers above a well-ventilated cavity)"),
                ["PL.Roof.ReEx.05.01"] = (concreteCeiling, "a ventilated flat roof, taken from the inside up to the ventilated cavity (PN-EN ISO 6946 disregards the layers above a well-ventilated cavity)"),
                ["PL.Roof.ReEx.06.01"] = (concreteCeiling, "a ventilated flat roof, taken from the inside up to the ventilated cavity (PN-EN ISO 6946 disregards the layers above a well-ventilated cavity)"),
                ["PL.Roof.ReEx.07.01"] = (concreteCeiling, "a ventilated flat roof, taken from the inside up to the ventilated cavity (PN-EN ISO 6946 disregards the layers above a well-ventilated cavity)"),
                ["DE.Roof.SyAv.09.01"] = (flatRoof_EPS, "a generic insulated flat roof standing in for the construction of another national typology"),
                ["PL.Floor.ReEx.01.01"] = (groundFloor_Slag, "without the ground"),
                ["PL.Floor.ReEx.02.01"] = (groundFloor_Slag, "without the ground"),
                ["PL.Floor.ReEx.03.01"] = (groundFloor_EPS, "without the ground"),
                ["PL.Floor.ReEx.04.01"] = (groundFloor_EPS, "without the ground"),
                ["PL.Floor.ReEx.05.01"] = (groundFloor_EPS, "without the ground"),
                ["PL.Floor.ReEx.01.02"] = (suspendedFloor_Slag, "without the cellar's additional resistance"),
                ["PL.Floor.ReEx.02.02"] = (suspendedFloor_Slag, "without the cellar's additional resistance"),
                ["PL.Floor.ReEx.03.02"] = (suspendedFloor_EPS, "without the cellar's additional resistance"),
                ["PL.Floor.ReEx.04.02"] = (suspendedFloor_EPS, "without the cellar's additional resistance"),
                ["PL.Floor.ReEx.05.02"] = (suspendedFloor_EPS, "without the cellar's additional resistance"),
                ["PL.Floor.ReEx.06.02"] = (suspendedFloor_EPS, "without the cellar's additional resistance"),
                ["PL.Floor.ReEx.07.02"] = (suspendedFloor_EPS, "without the cellar's additional resistance"),
            };

            // InternalWall, PartyWall and IntermediateFloor of the TypicalAsBuilt sets: DEFAULT assemblies per period and, for the large-panel periods, per building type.
            IConstruction InternalConstruction(ConstructionRole constructionRole, ConstructionPeriod constructionPeriod, BuildingType buildingType)
            {
                bool largePanel = buildingType is BuildingType.MultiFamily or BuildingType.ApartmentBlock && constructionPeriod is Enums.ConstructionPeriod.From1967To1985 or Enums.ConstructionPeriod.From1986To1992;
                int stage = constructionPeriod switch
                {
                    Enums.ConstructionPeriod.Until1945 => 0,
                    Enums.ConstructionPeriod.From1946To1966 => 1,
                    Enums.ConstructionPeriod.From1967To1985 or Enums.ConstructionPeriod.From1986To1992 => 2,
                    _ => 3,
                };

                switch (constructionRole)
                {
                    case ConstructionRole.InternalWall:
                        if (largePanel)
                        {
                            return DefaultConstruction(constructionRole, "ReinforcedConcrete150", "Internal wall, reinforced concrete panel 150 mm (DEFAULT)", [("ReinforcedConcrete", 0.15)]);
                        }

                        return stage switch
                        {
                            0 or 1 => DefaultConstruction(constructionRole, "SolidBrick120", "Internal wall, solid brick 120 mm, lime plaster (DEFAULT)", [("LimePlaster", 0.015), ("SolidBrickMasonry", 0.12), ("LimePlaster", 0.015)]),
                            2 => DefaultConstruction(constructionRole, "HollowBrick120", "Internal wall, hollow brick 120 mm, cement-lime plaster (DEFAULT)", [("CementLimePlaster", 0.015), ("HollowBrickMasonry", 0.12), ("CementLimePlaster", 0.015)]),
                            _ => DefaultConstruction(constructionRole, "AeratedConcrete120", "Internal wall, aerated concrete 120 mm, cement-lime plaster (DEFAULT)", [("CementLimePlaster", 0.015), ("AeratedConcreteMasonry_600", 0.12), ("CementLimePlaster", 0.015)]),
                        };

                    case ConstructionRole.PartyWall:
                        if (largePanel)
                        {
                            return DefaultConstruction(constructionRole, "ReinforcedConcrete150", "Party wall, reinforced concrete panel 150 mm (DEFAULT)", [("ReinforcedConcrete", 0.15)]);
                        }

                        return stage switch
                        {
                            0 or 1 => DefaultConstruction(constructionRole, "SolidBrick380", "Party wall, solid brick 380 mm, lime plaster (DEFAULT)", [("LimePlaster", 0.015), ("SolidBrickMasonry", 0.38), ("LimePlaster", 0.015)]),
                            2 => DefaultConstruction(constructionRole, "SolidBrick250", "Party wall, solid brick 250 mm, cement-lime plaster (DEFAULT)", [("CementLimePlaster", 0.015), ("SolidBrickMasonry", 0.25), ("CementLimePlaster", 0.015)]),
                            _ => DefaultConstruction(constructionRole, "AeratedConcrete240", "Party wall, aerated concrete 240 mm, cement-lime plaster (DEFAULT)", [("CementLimePlaster", 0.015), ("AeratedConcreteMasonry_700", 0.24), ("CementLimePlaster", 0.015)]),
                        };

                    default:
                        return stage switch
                        {
                            0 => DefaultConstruction(constructionRole, "TimberJoist", "Intermediate floor, timber joists with clay pugging (DEFAULT)", [("LimePlaster", 0.015), ("Softwood", 0.025), ("ClayPugging", 0.06), ("Softwood", 0.025)]),
                            1 => DefaultConstruction(constructionRole, "KleinSlab", "Intermediate floor, Klein brick slab with light concrete and screed (DEFAULT)", [("CementLimePlaster", 0.015), ("SolidBrickMasonry", 0.12), ("LightConcrete_1200", 0.05), ("CementScreed", 0.04)]),
                            2 => DefaultConstruction(constructionRole, "ReinforcedConcreteSlab", "Intermediate floor, reinforced concrete slab 150 mm with screed (DEFAULT)", [("CementLimePlaster", 0.015), ("ReinforcedConcrete", 0.15), ("CementScreed", 0.04)]),
                            _ => DefaultConstruction(constructionRole, "FloatingScreed", "Intermediate floor, reinforced concrete slab 150 mm with floating screed on EPS (DEFAULT)", [("CementLimePlaster", 0.015), ("ReinforcedConcrete", 0.15), ("ExpandedPolystyrene", 0.03), ("CementScreed", 0.05)]),
                        };
                }
            }

            // The TABULA periods are periods of construction; the last one, PL.07, is 2009 ... 9999 in the web tool records (re-read 2026-10-30), after the 2003 ... 2008 period (Query.ConstructionPeriod).
            void TypicalAsBuilt(int index, BuildingType buildingType, string? note)
            {
                (string Code, ConstructionPeriod ConstructionPeriod, BuildingType BuildingType, string RoofType, string FloorBoundary, double AdditionalFloorResistance, double TotalSolarEnergyTransmittance, double FrameAreaFraction, double ThermalBridging, int AttachedNeighbours, (string Code, string Name, double ThermalTransmittance) Roof, (string Code, string Name, double ThermalTransmittance) Wall, (string Code, string Name, double ThermalTransmittance) Floor, (string Code, string Name, double ThermalTransmittance) Window, (string Code, string Name, double ThermalTransmittance) Door) building = buildings[index];

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

                // One construction per TABULA construction code. The key also holds the values, so a code published with two different values
                // would give two constructions, which the ConstructionLibrary_PL_TypologyData fact rejects.
                IConstruction Element(ConstructionRole constructionRole, (string Code, string Name, double ThermalTransmittance) element, string? detail, double totalSolarEnergyTransmittance)
                {
                    string key = string.Format(CultureInfo.InvariantCulture, "PL.TABULA.{0}.{1}.{2}", element.Code, Text(element.ThermalTransmittance), Text(totalSolarEnergyTransmittance));
                    string name = string.Format(CultureInfo.InvariantCulture, "{0} ({1})", element.Name, element.Code);
                    string description = string.Format(CultureInfo.InvariantCulture, "TABULA construction {0} \"{1}\": U = {2} W/(m2K){3} ({4}, retrieved {5}).", element.Code, element.Name, Text(element.ThermalTransmittance), detail, webTool, ConstructionLibrary_PL_RetrievalDate);

                    List<(OpaqueMaterial Material, double Thickness)>? layers = null;
                    if (constructionRole is ConstructionRole.ExternalWall or ConstructionRole.Roof or ConstructionRole.GroundFloor && elementLayers.TryGetValue(element.Code, out (List<(string MaterialKey, double Thickness)> LayerSpecifications, string? Note) elementLayer))
                    {
                        HeatFlowDirection heatFlowDirection = Direction(constructionRole);
                        layers = Layers(elementLayer.LayerSpecifications, heatFlowDirection, element.ThermalTransmittance, false);
                        string materialName_Fitted = materials[elementLayer.LayerSpecifications.Find(x => double.IsNaN(x.Thickness)).MaterialKey].Name ?? string.Empty;
                        description = string.Format(CultureInfo.InvariantCulture, "{0} Layers, outside to inside (DiGi-Organization/DiGi.Analytical#18): {1}. The {2} thickness is fitted to the declared U: the layers give U = {3} W/(m2K) per PN-EN ISO 6946, {4} heat flow, no ground contact{5}. The composition follows the TABULA name and the period's practice; it has no source.", description, LayersText(layers), materialName_Fitted.ToLowerInvariant(), Text(Math.Round(LayersThermalTransmittance(layers, heatFlowDirection), 3)), heatFlowDirection.ToString().ToLowerInvariant(), elementLayer.Note is null ? string.Empty : string.Concat("; ", elementLayer.Note));
                    }

                    IConstruction construction = Construction(constructionRole, key, name, description, element.ThermalTransmittance, totalSolarEnergyTransmittance);
                    if (layers is not null)
                    {
                        AddLayers(construction, key, layers);
                    }

                    return construction;
                }

                string? roofNote = building.Roof.Code.StartsWith("PL.", StringComparison.Ordinal) ? null : string.Format(CultureInfo.InvariantCulture, "The roof refers to {0}, a construction of another national typology, kept as published. ", building.Roof.Code);

                IConstruction construction_Roof = Element(ConstructionRole.Roof, building.Roof, roofNote is null ? " as published" : " as published; the Polish TABULA record refers here to a construction of another national typology, kept as published", double.NaN);
                IConstruction construction_Wall = Element(ConstructionRole.ExternalWall, building.Wall, " as published", double.NaN);
                IConstruction construction_Floor = Element(ConstructionRole.GroundFloor, building.Floor, " of the construction itself; over an unheated cellar TABULA publishes it with the cellar's additional resistance included, which the set's TypologyData.AdditionalFloorResistance holds instead", double.NaN);
                IConstruction construction_Window = Element(ConstructionRole.Window, building.Window, string.Format(CultureInfo.InvariantCulture, " as published, g_gl,n = {0} at normal incidence", Text(building.TotalSolarEnergyTransmittance)), building.TotalSolarEnergyTransmittance);
                IConstruction construction_Door = Element(ConstructionRole.ExternalDoor, building.Door, " as published", double.NaN);
                IConstruction construction_InternalWall = InternalConstruction(ConstructionRole.InternalWall, building.ConstructionPeriod, buildingType);
                IConstruction construction_PartyWall = InternalConstruction(ConstructionRole.PartyWall, building.ConstructionPeriod, buildingType);
                IConstruction construction_IntermediateFloor = InternalConstruction(ConstructionRole.IntermediateFloor, building.ConstructionPeriod, buildingType);

                string attachedNeighbours = building.AttachedNeighbours == 0 ? "B_Alone" : string.Concat("B_N", building.AttachedNeighbours.ToString(CultureInfo.InvariantCulture));
                string typologySource = string.Format(CultureInfo.InvariantCulture, "TABULA building {0} ({1}, retrieved {2}): code_rooftype {3}, code_constructionborder_floor_1 {4}, r_add_unheatedspace_floor1 {5}, delta_u_thermalbridging {6}, f_f {7}, b_tranmission_floor_1 {8}, f_w {9}, code_attachedneighbours {10}. {11}", building.Code, webTool, ConstructionLibrary_PL_RetrievalDate, building.RoofType, building.FloorBoundary, Text(building.AdditionalFloorResistance), Text(building.ThermalBridging), Text(building.FrameAreaFraction), Text(floorTemperatureReductionFactor), Text(nonPerpendicularIncidenceFactor), attachedNeighbours, roofNote);
                TypologyData typologyData = new(
                    building.FrameAreaFraction,
                    building.ThermalBridging,
                    building.FloorBoundary == "Cellar" ? FloorBoundary.Cellar : FloorBoundary.Soil,
                    building.AdditionalFloorResistance,
                    building.RoofType == "FR" ? RoofType.Flat : RoofType.Pitched,
                    floorTemperatureReductionFactor,
                    nonPerpendicularIncidenceFactor,
                    building.AttachedNeighbours,
                    typologySource.Trim());

                string source = string.Format(CultureInfo.InvariantCulture, "TABULA building {0}, Polish national typology ({1}, retrieved {2}). {3}{4}The frame area fraction, thermal bridging surcharge, floor boundary and cellar resistance, roof type, b_tr,floor, F_w and attached neighbours are in TypologyData; g_gl,n is on the window construction. The roof construction serves Roof and FlatRoof, the floor construction GroundFloor and FloorOverUnheated, the window construction Window, RoofWindow and BalconyDoor, the door construction ExternalDoor and StaircaseEntranceDoor. TABULA has no InternalWall, PartyWall or IntermediateFloor construction: those three are DEFAULT layered assemblies with no source and no declared U, for thermal mass ({5}, {6}, {7}). TABULA has no DoorToUnheatedSpace or GarageDoor construction.", building.Code, webTool, ConstructionLibrary_PL_RetrievalDate, note, roofNote, construction_InternalWall.Name, construction_PartyWall.Name, construction_IntermediateFloor.Name);

                ConstructionSet constructionSet = new(ConstructionFlavour.TypicalAsBuilt, buildingType, null, startDate, endDate, source, typologyData);
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
                constructionSet.SetConstruction(ConstructionRole.InternalWall, construction_InternalWall);
                constructionSet.SetConstruction(ConstructionRole.PartyWall, construction_PartyWall);
                constructionSet.SetConstruction(ConstructionRole.IntermediateFloor, construction_IntermediateFloor);

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
                            int index_Wall = constructionRoles_Regulation.IndexOf(ConstructionRole.ExternalWall);
                            bool wallZoneDependent = !values_III[index_Wall].Equals(values_IV[index_Wall]) || !values_III[index_Wall].Equals(values_V[index_Wall]);
                            string subject = wallZoneDependent ? "External walls" : "Windows";
                            notes.Add(climateZone is null ? string.Format(CultureInfo.InvariantCulture, "{0} take the limit of zones I-III, which also applies in a zone without its own set.", subject) : string.Format(CultureInfo.InvariantCulture, "{0} take the limit of zone {1}.", subject, climateZone));
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

                        ConstructionSet constructionSet = new(ConstructionFlavour.Regulation, buildingType, climateZone, startDate, endDate, source.Trim(), null);
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

                            List<(string MaterialKey, double Thickness)>? layerSpecifications = constructionRole switch
                            {
                                ConstructionRole.ExternalWall => [("CementLimePlaster", 0.01), ("ExpandedPolystyrene", fitted), (startDate.Year < 1975 ? "SolidBrickMasonry" : startDate.Year < 1991 ? "AeratedConcreteMasonry_600_CementLimeMortar" : "AeratedConcreteMasonry_600", startDate.Year < 1975 ? 0.25 : 0.24), ("CementLimePlaster", 0.015)],
                                ConstructionRole.Roof or ConstructionRole.FlatRoof => [("RoofingFelt", 0.01), ("MineralWool", fitted), ("ReinforcedConcrete", 0.15), ("CementLimePlaster", 0.015)],
                                ConstructionRole.GroundFloor => [("Concrete_2200", 0.10), ("ExpandedPolystyrene", fitted), ("CementScreed", 0.04)],
                                ConstructionRole.FloorOverUnheated => [("CementLimePlaster", 0.015), ("ReinforcedConcrete", 0.15), ("ExpandedPolystyrene", fitted), ("CementScreed", 0.04)],
                                _ => null,
                            };

                            List<(OpaqueMaterial Material, double Thickness)>? layers = null;
                            if (layerSpecifications is not null)
                            {
                                HeatFlowDirection heatFlowDirection = Direction(constructionRole);
                                layers = Layers(layerSpecifications, heatFlowDirection, value, true);
                                description = string.Format(CultureInfo.InvariantCulture, "{0} Layers, outside to inside (DiGi-Organization/DiGi.Analytical#18): {1}. A representative assembly of the stage with its insulation in whole centimetres, the least that keeps U ≤ U(max): U = {2} W/(m2K) per PN-EN ISO 6946, {3} heat flow, no ground contact. The composition has no source.", description, LayersText(layers), Text(Math.Round(LayersThermalTransmittance(layers, heatFlowDirection), 3)), heatFlowDirection.ToString().ToLowerInvariant());
                            }

                            IConstruction construction = Construction(constructionRole, key, name, description, value, double.NaN);
                            if (layers is not null)
                            {
                                AddLayers(construction, key, layers);
                            }

                            constructionSet.SetConstruction(constructionRole, construction);
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
