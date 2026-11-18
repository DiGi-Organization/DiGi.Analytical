using DiGi.Analytical.Building.Classes;
using DiGi.Analytical.Building.Enums;
using DiGi.Analytical.Building.Energy.Classes;
using DiGi.Analytical.Building.HVAC;
using DiGi.Analytical.Building.HVAC.Enums;
using DiGi.Analytical.Building.Interfaces;
using DiGi.Analytical.Building.Regulation;
using DiGi.Analytical.Building.Regulation.Classes;
using DiGi.Analytical.Building.Regulation.Enums;
using DiGi.Core.Parameter.Classes;
using DiGi.Geometry.Core.Interfaces;
using DiGi.Geometry.Planar.Classes;
using DiGi.Geometry.Spatial.Classes;
using DiGi.Geometry.Spatial.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace DiGi.Analytical.Building.Energy
{
    public static partial class Create
    {
        /// <summary>
        /// Calculates the monthly and annual energy need for space heating and the design heat load of a building model, as one continuously heated zone, by the PN-EN ISO 52016-1 monthly quasi-steady method (DiGi-Organization/DiGi.Analytical#21), <see cref="Constants.Source.Method"/>.
        /// <para><b>Components.</b> Walls, roofs and floors are classified by <c>Regulation.Query.ConstructionRoles</c>. External walls (net of the outlines of their openings), roofs, windows and doors make H_D = Σ U·A: opaque U per PN-EN ISO 6946 from the model (a declared U wins), walls with a horizontal and roofs with an upward heat flow; window and door U the declared Uw over the whole outline, computed from the pane layout only when none is declared. Party walls are adiabatic. A component or opening whose U is not known is excluded and listed in <see cref="Classes.HeatDemandResult.ExcludedComponents"/>, never counted as 0.</para>
        /// <para><b>Floors.</b> The lowest floor - and any other floor of the external shell standing within <see cref="Constants.Default.LevelTolerance"/> of the lowest level - lies on the ground (H_g, <see cref="Query.GroundThermalTransmittance(double, double, double, double, double)"/>, R_f from the floor's own layers, never its declared U) or, with a <see cref="FloorBoundary.Cellar"/> floor boundary, over the cellar: H_U = b·A / (1/U_f + R_add), U_f from the layers, so the cellar is counted once. A floor of the shell above the lowest level is a floor over outside air and joins H_D with a downward heat flow. Thermal bridges add H_tb = ΔU_tb·ΣA over every heat-loss element.</para>
        /// <para><b>Ventilation and gains.</b> H_ve = ρ_a·c_a·(q_ve + n_inf·V / 3600), with q_ve the usage profile's outside airflow per area times A_ref and n_inf its infiltration. θ_int, the internal gain per area, the airflow per area and n_inf are the floor-area weighted means of the spaces' first internal condition (its thermostat lower limit: continuous heating); a space without one does not weigh. Solar gains are F_w·g_gl,n·A_g·I_m for glazing - A_g the pane faces, (1 − F_f)·A_w for a construction without panes, counted - and α·R_se·U·A·I_m for opaque elements, I_m the host surface's monthly irradiation from <paramref name="monthlyClimate"/>; a surface missing there gains nothing and is counted. The extra heat flow to the sky F_r·R_se·U·A·h_r·Δθ_er is subtracted from the gains (Eq. (44)).</para>
        /// <para><b>Balance.</b> Per month Q_ht = (H_D + H_tb + H_g + H_U + H_ve)·(θ_int − θ_e,m)·t_m, Q_gn = Q_int + Q_sol − Q_sky, γ = Q_gn / Q_ht, a = a_H,0 + τ / τ_H,0 with τ = C_m / 3600 / H, and Q_H,nd,m = max(0, Q_ht − η·Q_gn); a month whose gains are not positive uses η = 1. The design heat load is <see cref="Query.DesignHeatLoad(double, double, double, double, double, double)"/>.</para>
        /// <para><b>Typology data.</b> F_w, ΔU_tb, F_f, R_add and b come from <paramref name="typologyData"/> - the TypicalAsBuilt set of the year built - and fall back to <paramref name="heatDemandOptions"/> where it gives none; every value used is recorded in <see cref="Classes.HeatDemandResult.Sources"/>.</para>
        /// </summary>
        /// <param name="buildingModel">The building model, with constructions, openings and internal conditions assigned. This value can be null.</param>
        /// <param name="monthlyClimate">The monthly climate of the building. This value can be null.</param>
        /// <param name="typologyData">The TABULA typology data of the TypicalAsBuilt set of the year built. This value can be null.</param>
        /// <param name="heatDemandOptions">The options; null uses the defaults of <see cref="Constants.Default"/>.</param>
        /// <param name="tolerance">The distance tolerance of the external shell and the footprint.</param>
        /// <returns>The <see cref="Classes.HeatDemandResult"/>, or null when the model or the climate is null, the climate has not 12 external temperatures, no space with a floor carries an internal condition with a heating set-point, or the model has no heat-loss element.</returns>
        public static Classes.HeatDemandResult? HeatDemandResult(this BuildingModel? buildingModel, MonthlyClimate? monthlyClimate, TypologyData? typologyData, HeatDemandOptions? heatDemandOptions = null, double tolerance = Core.Constants.Tolerance.Distance)
        {
            if (buildingModel is null || monthlyClimate is null)
            {
                return null;
            }

            List<double>? externalTemperatures = monthlyClimate.ExternalTemperatures;
            if (externalTemperatures is null || externalTemperatures.Count != 12 || externalTemperatures.Exists(double.IsNaN))
            {
                return null;
            }

            List<ISpace>? spaces = buildingModel.GetSpaces<ISpace>();
            if (spaces is null || spaces.Count == 0)
            {
                return null;
            }

            HeatDemandOptions heatDemandOptions_Temp = heatDemandOptions ?? new HeatDemandOptions();

            static double Mean(IProfile? profile)
            {
                if (profile is null || profile.Count == 0)
                {
                    return double.NaN;
                }

                double sum = 0.0;
                for (int i = 0; i < profile.Count; i++)
                {
                    sum += profile[i];
                }

                return sum / profile.Count;
            }

            static double ValueOrZero(double value)
            {
                return double.IsNaN(value) ? 0.0 : value;
            }

            static string Format(double value)
            {
                return value.ToString("0.###", CultureInfo.InvariantCulture);
            }

            // Internal conditions: floor-area weighted over the spaces that carry a heating set-point.
            double referenceFloorArea = 0.0;
            double area_Conditioned = 0.0;
            double internalTemperature_Weighted = 0.0;
            double internalGain_Weighted = 0.0;
            double outsideAirPerArea_Weighted = 0.0;
            double infiltration_Weighted = 0.0;
            foreach (ISpace space in spaces)
            {
                double floorArea = buildingModel.FloorArea(space);
                if (double.IsNaN(floorArea) || floorArea <= 0)
                {
                    continue;
                }

                referenceFloorArea += floorArea;

                IInternalCondition? internalCondition = null;
                List<SpaceInternalCondition>? spaceInternalConditions = buildingModel.GetSpaceInternalConditions(space);
                if (spaceInternalConditions is not null)
                {
                    foreach (SpaceInternalCondition spaceInternalCondition in spaceInternalConditions)
                    {
                        if (spaceInternalCondition?.InternalCondition is IInternalCondition internalCondition_Temp)
                        {
                            internalCondition = internalCondition_Temp;
                            break;
                        }
                    }
                }

                double internalTemperature = Mean(internalCondition.Profile(ThermostatProfileType.LowerLimit));
                if (double.IsNaN(internalTemperature))
                {
                    continue;
                }

                area_Conditioned += floorArea;
                internalTemperature_Weighted += internalTemperature * floorArea;
                internalGain_Weighted += ValueOrZero(Mean(internalCondition.Profile(InternalGainProfileType.TotalInternalGain))) * floorArea;
                outsideAirPerArea_Weighted += ValueOrZero(internalCondition.SystemProperties()?.OutsideAirPerArea ?? double.NaN) * floorArea;
                infiltration_Weighted += ValueOrZero(Mean(internalCondition.Profile(InternalGainProfileType.Infiltration))) * floorArea;
            }

            if (referenceFloorArea <= 0 || area_Conditioned <= 0)
            {
                return null;
            }

            double internalTemperature_Zone = internalTemperature_Weighted / area_Conditioned;
            double internalGain = internalGain_Weighted / area_Conditioned;
            double outsideAirPerArea = outsideAirPerArea_Weighted / area_Conditioned;
            double infiltration = infiltration_Weighted / area_Conditioned;

            Dictionary<string, string> sources = new()
            {
                ["Method"] = Constants.Source.Method,
                ["GainUtilisation"] = Constants.Source.GainUtilisation,
                ["TimeConstant"] = Constants.Source.TimeConstant,
                ["InternalHeatCapacity"] = Constants.Source.InternalHeatCapacity,
                ["Ventilation"] = Constants.Source.Ventilation,
                ["ThermalBridges"] = Constants.Source.ThermalBridges,
                ["SolarGlazed"] = Constants.Source.SolarGlazed,
                ["SolarOpaque"] = heatDemandOptions_Temp.IncludeOpaqueSolarGains ? Constants.Source.SolarOpaque : "not included",
                ["SkyRadiation"] = heatDemandOptions_Temp.IncludeSkyRadiation ? Constants.Source.SkyRadiation : "not included",
                ["DesignHeatLoad"] = Constants.Source.DesignHeatLoad,
                ["ReferenceFloorArea"] = "gross floor area of the spaces (" + Format(referenceFloorArea) + " m2); internal conditions weighted over " + Format(area_Conditioned) + " m2",
                ["Climate"] = monthlyClimate.Source ?? "not given",
                ["TypologyData"] = typologyData?.Source ?? "none",
            };

            // TABULA typology data first, the options where it gives none.
            double nonPerpendicularIncidenceFactor = typologyData?.NonPerpendicularIncidenceFactor ?? double.NaN;
            sources["NonPerpendicularIncidenceFactor"] = double.IsNaN(nonPerpendicularIncidenceFactor) || nonPerpendicularIncidenceFactor <= 0 ? "option" : "typology data";
            if (double.IsNaN(nonPerpendicularIncidenceFactor) || nonPerpendicularIncidenceFactor <= 0)
            {
                nonPerpendicularIncidenceFactor = heatDemandOptions_Temp.NonPerpendicularIncidenceFactor;
            }

            sources["NonPerpendicularIncidenceFactor"] += " " + Format(nonPerpendicularIncidenceFactor);

            double thermalBridgingSurcharge = typologyData?.ThermalBridgingSurcharge ?? double.NaN;
            sources["ThermalBridgingSurcharge"] = double.IsNaN(thermalBridgingSurcharge) || thermalBridgingSurcharge < 0 ? "option" : "typology data";
            if (double.IsNaN(thermalBridgingSurcharge) || thermalBridgingSurcharge < 0)
            {
                thermalBridgingSurcharge = heatDemandOptions_Temp.ThermalBridgingSurcharge;
            }

            sources["ThermalBridgingSurcharge"] += " " + Format(thermalBridgingSurcharge) + " W/(m2K)";

            double frameAreaFraction = typologyData?.FrameAreaFraction ?? double.NaN;
            sources["FrameAreaFraction"] = double.IsNaN(frameAreaFraction) || frameAreaFraction < 0 || frameAreaFraction >= 1 ? "option" : "typology data";
            if (double.IsNaN(frameAreaFraction) || frameAreaFraction < 0 || frameAreaFraction >= 1)
            {
                frameAreaFraction = heatDemandOptions_Temp.FrameAreaFraction;
            }

            sources["FrameAreaFraction"] += " " + Format(frameAreaFraction);

            FloorBoundary floorBoundary = typologyData?.FloorBoundary ?? FloorBoundary.Undefined;
            Dictionary<Guid, ConstructionRole> constructionRoles = buildingModel.ConstructionRoles(floorBoundary, tolerance) ?? [];

            Dictionary<string, List<double>> surfaceIrradiations = monthlyClimate.SurfaceIrradiations ?? [];
            int missingIrradiationCount = 0;
            List<double>? Irradiations(Guid guid)
            {
                if (surfaceIrradiations.TryGetValue(guid.ToString("D"), out List<double>? irradiations) && irradiations is not null && irradiations.Count == 12)
                {
                    return irradiations;
                }

                missingIrradiationCount++;
                return null;
            }

            double externalSurfaceResistance = Building.Query.SurfaceResistance(HeatFlowDirection.Horizontal, false);

            List<string> excludedComponents = [];
            List<(double Coefficient, List<double>? Irradiations)> solarCoefficients = [];
            double directHeatTransferCoefficient = 0.0;
            double area_HeatLoss = 0.0;
            double skyCoefficient = 0.0;
            int glazingFallbackCount = 0;
            int computedWindowThermalTransmittanceCount = 0;

            void AddOpaque(Guid guid, double thermalTransmittance, double area, List<double>? irradiations, double skyFormFactor)
            {
                if (double.IsNaN(thermalTransmittance))
                {
                    excludedComponents.Add(guid.ToString("D"));
                    return;
                }

                if (area <= 0)
                {
                    return;
                }

                directHeatTransferCoefficient += thermalTransmittance * area;
                area_HeatLoss += area;
                skyCoefficient += skyFormFactor * externalSurfaceResistance * thermalTransmittance * area;

                if (heatDemandOptions_Temp.IncludeOpaqueSolarGains && skyFormFactor > 0)
                {
                    solarCoefficients.Add((heatDemandOptions_Temp.OpaqueSolarAbsorptance * externalSurfaceResistance * thermalTransmittance * area, irradiations));
                }
            }

            // Adds the openings of a host and returns the area of their outlines, to be taken off the host.
            double AddOpenings(IComponent component, List<double>? irradiations, double skyFormFactor)
            {
                double result = 0.0;

                List<IOpening>? openings = buildingModel.GetOpenings<IOpening>(component);
                if (openings is null)
                {
                    return result;
                }

                foreach (IOpening opening in openings)
                {
                    IOpeningConstruction? openingConstruction = buildingModel.GetOpeningConstruction<IOpeningConstruction>(opening);
                    double area = opening.Area(openingConstruction);
                    if (double.IsNaN(area) || area <= 0)
                    {
                        excludedComponents.Add(opening.Guid.ToString("D"));
                        continue;
                    }

                    result += area;

                    double thermalTransmittance = double.NaN;
                    if (openingConstruction is not null && openingConstruction.TryGetValue(new EnumParameterDefinition(OpeningConstructionParameter.ThermalTransmittance), out double thermalTransmittance_Declared))
                    {
                        thermalTransmittance = thermalTransmittance_Declared;
                    }

                    if (double.IsNaN(thermalTransmittance))
                    {
                        thermalTransmittance = buildingModel.ThermalTransmittance(openingConstruction);
                        if (!double.IsNaN(thermalTransmittance))
                        {
                            computedWindowThermalTransmittanceCount++;
                        }
                    }

                    if (double.IsNaN(thermalTransmittance))
                    {
                        excludedComponents.Add(opening.Guid.ToString("D"));
                        continue;
                    }

                    directHeatTransferCoefficient += thermalTransmittance * area;
                    area_HeatLoss += area;
                    skyCoefficient += skyFormFactor * externalSurfaceResistance * thermalTransmittance * area;

                    if (openingConstruction is null || !openingConstruction.TryGetValue(new EnumParameterDefinition(OpeningConstructionParameter.TotalSolarEnergyTransmittance), out double totalSolarEnergyTransmittance) || double.IsNaN(totalSolarEnergyTransmittance) || totalSolarEnergyTransmittance <= 0)
                    {
                        continue;
                    }

                    double area_Glazed = 0.0;
                    List<ISurface3D>? surface3Ds_Pane = Building.Query.Surface3Ds(opening, openingConstruction, OpeningConstructionPart.Pane);
                    if (surface3Ds_Pane is not null)
                    {
                        foreach (ISurface3D surface3D_Pane in surface3Ds_Pane)
                        {
                            if (surface3D_Pane is IFace face && face.GetArea() is double area_Pane && !double.IsNaN(area_Pane))
                            {
                                area_Glazed += area_Pane;
                            }
                        }
                    }

                    if (area_Glazed <= 0)
                    {
                        area_Glazed = (1.0 - frameAreaFraction) * area;
                        glazingFallbackCount++;
                    }

                    solarCoefficients.Add((nonPerpendicularIncidenceFactor * totalSolarEnergyTransmittance * area_Glazed, irradiations));
                }

                return result;
            }

            // External walls, net of their openings; party walls are adiabatic and internal walls bound the zone on both sides.
            List<IWall> walls = buildingModel.GetComponents<IWall>() ?? [];
            double wallThickness_Weighted = 0.0;
            double area_WallThickness = 0.0;
            foreach (IWall wall in walls)
            {
                if (!constructionRoles.TryGetValue(wall.Guid, out ConstructionRole constructionRole) || constructionRole != ConstructionRole.ExternalWall)
                {
                    continue;
                }

                List<double>? irradiations = Irradiations(wall.Guid);
                double area = wall.Area() - AddOpenings(wall, irradiations, heatDemandOptions_Temp.WallSkyFormFactor);

                IWallConstruction? wallConstruction = buildingModel.GetWallConstruction(wall);
                AddOpaque(wall.Guid, buildingModel.ThermalTransmittance(wallConstruction, HeatFlowDirection.Horizontal), area, irradiations, heatDemandOptions_Temp.WallSkyFormFactor);

                List<IStructureLayer>? structureLayers = buildingModel.GetStructureLayers(wallConstruction);
                if (structureLayers is not null && structureLayers.Count > 0 && area > 0)
                {
                    double thickness = 0.0;
                    foreach (IStructureLayer structureLayer in structureLayers)
                    {
                        thickness += ValueOrZero(structureLayer.Thickness);
                    }

                    wallThickness_Weighted += thickness * area;
                    area_WallThickness += area;
                }
            }

            // Roofs of the external shell, with their roof windows.
            List<IRoof> roofs = buildingModel.GetComponents<IRoof>() ?? [];
            foreach (IRoof roof in roofs)
            {
                if (!constructionRoles.TryGetValue(roof.Guid, out ConstructionRole constructionRole) || (constructionRole != ConstructionRole.Roof && constructionRole != ConstructionRole.FlatRoof))
                {
                    continue;
                }

                List<double>? irradiations = Irradiations(roof.Guid);
                double area = roof.Area() - AddOpenings(roof, irradiations, heatDemandOptions_Temp.RoofSkyFormFactor);
                AddOpaque(roof.Guid, buildingModel.ThermalTransmittance(buildingModel.GetRoofConstruction(roof), HeatFlowDirection.Upward), area, irradiations, heatDemandOptions_Temp.RoofSkyFormFactor);
            }

            // Floors: on the ground, over the cellar, or over outside air.
            double elevation_Min = buildingModel.GetBoundingBox()?.Min.Z ?? double.NaN;
            List<(IFloor Floor, double Area)> floors_Ground = [];
            double groundHeatTransferCoefficient = 0.0;
            double unheatedSpaceHeatTransferCoefficient = 0.0;

            List<IFloor> floors = buildingModel.GetComponents<IFloor>() ?? [];
            foreach (IFloor floor in floors)
            {
                constructionRoles.TryGetValue(floor.Guid, out ConstructionRole constructionRole);

                bool external = (buildingModel.GetSpaces(floor)?.Count ?? 0) == 1;
                bool lowest = floor.GetBoundingBox() is BoundingBox3D boundingBox3D && !double.IsNaN(elevation_Min) && boundingBox3D.Min.Z - elevation_Min <= Constants.Default.LevelTolerance;

                bool ground = constructionRole == ConstructionRole.GroundFloor || constructionRole == ConstructionRole.FloorOverUnheated || (constructionRole == ConstructionRole.IntermediateFloor && external && lowest);
                if (!ground)
                {
                    if (constructionRole == ConstructionRole.IntermediateFloor && external)
                    {
                        AddOpaque(floor.Guid, buildingModel.ThermalTransmittance(buildingModel.GetFloorConstruction(floor), HeatFlowDirection.Downward), floor.Area() - AddOpenings(floor, null, 0.0), null, 0.0);
                    }

                    continue;
                }

                double area = floor.Area();
                if (double.IsNaN(area) || area <= 0)
                {
                    excludedComponents.Add(floor.Guid.ToString("D"));
                    continue;
                }

                floors_Ground.Add((floor, area));
            }

            if (floors_Ground.Count > 0)
            {
                double area_Ground = 0.0;
                foreach ((IFloor _, double area) in floors_Ground)
                {
                    area_Ground += area;
                }

                if (floorBoundary == FloorBoundary.Cellar)
                {
                    double additionalFloorResistance = typologyData?.AdditionalFloorResistance ?? double.NaN;
                    if (double.IsNaN(additionalFloorResistance) || additionalFloorResistance < 0)
                    {
                        additionalFloorResistance = 0.0;
                    }

                    double floorTemperatureReductionFactor = typologyData?.FloorTemperatureReductionFactor ?? double.NaN;
                    if (double.IsNaN(floorTemperatureReductionFactor) || floorTemperatureReductionFactor <= 0)
                    {
                        floorTemperatureReductionFactor = 1.0;
                    }

                    sources["Floor"] = Constants.Source.Cellar + ": R_add " + Format(additionalFloorResistance) + " m2K/W, b " + Format(floorTemperatureReductionFactor);

                    foreach ((IFloor floor, double area) in floors_Ground)
                    {
                        List<IStructureLayer>? structureLayers = buildingModel.GetStructureLayers(buildingModel.GetFloorConstruction(floor));
                        double thermalTransmittance_Floor = structureLayers is null ? double.NaN : Building.Query.ThermalTransmittance(structureLayers.ConvertAll(x => (x, buildingModel.GetMaterial(x))), HeatFlowDirection.Downward);
                        if (double.IsNaN(thermalTransmittance_Floor) || thermalTransmittance_Floor <= 0)
                        {
                            excludedComponents.Add(floor.Guid.ToString("D"));
                            continue;
                        }

                        unheatedSpaceHeatTransferCoefficient += floorTemperatureReductionFactor * area / ((1.0 / thermalTransmittance_Floor) + additionalFloorResistance);
                        area_HeatLoss += area;
                    }
                }
                else
                {
                    double exposedPerimeter = buildingModel.ExposedPerimeter(tolerance);
                    double wallThickness = area_WallThickness > 0 ? wallThickness_Weighted / area_WallThickness : heatDemandOptions_Temp.GroundWallThickness;

                    sources["Floor"] = Constants.Source.Ground + ": A " + Format(area_Ground) + " m2, P " + Format(exposedPerimeter) + " m, w " + Format(wallThickness) + " m (" + (area_WallThickness > 0 ? "external wall layers" : "option") + "), λ_g " + Format(heatDemandOptions_Temp.GroundThermalConductivity) + " W/(mK)";

                    double internalSurfaceResistance = Building.Query.SurfaceResistance(HeatFlowDirection.Downward, true);
                    foreach ((IFloor floor, double area) in floors_Ground)
                    {
                        List<IStructureLayer>? structureLayers = buildingModel.GetStructureLayers(buildingModel.GetFloorConstruction(floor));
                        double thermalTransmittance_Layers = structureLayers is null ? double.NaN : Building.Query.ThermalTransmittance(structureLayers.ConvertAll(x => (x, buildingModel.GetMaterial(x))), HeatFlowDirection.Downward, groundContact: true);
                        double thermalTransmittance = double.IsNaN(thermalTransmittance_Layers) || thermalTransmittance_Layers <= 0 ? double.NaN : Query.GroundThermalTransmittance(area_Ground, exposedPerimeter, wallThickness, (1.0 / thermalTransmittance_Layers) - internalSurfaceResistance, heatDemandOptions_Temp.GroundThermalConductivity);
                        if (double.IsNaN(thermalTransmittance))
                        {
                            excludedComponents.Add(floor.Guid.ToString("D"));
                            continue;
                        }

                        groundHeatTransferCoefficient += thermalTransmittance * area;
                        area_HeatLoss += area;
                    }
                }
            }

            if (area_HeatLoss <= 0)
            {
                return null;
            }

            sources["WindowThermalTransmittance"] = "declared Uw over the whole outline" + (computedWindowThermalTransmittanceCount == 0 ? string.Empty : "; " + computedWindowThermalTransmittanceCount.ToString(CultureInfo.InvariantCulture) + " computed from the pane layout (no declared Uw)");

            double thermalBridgeHeatTransferCoefficient = thermalBridgingSurcharge * area_HeatLoss;

            // Volume of the shell, or footprint times height when the shell is open.
            double heatedVolume = buildingModel.HeatedVolume(tolerance);
            if (!double.IsNaN(heatedVolume))
            {
                sources["HeatedVolume"] = "external shell";
            }
            else
            {
                double area_Footprint = 0.0;
                List<PolygonalFace2D>? polygonalFace2Ds = buildingModel.Footprints(tolerance);
                if (polygonalFace2Ds is not null)
                {
                    foreach (PolygonalFace2D polygonalFace2D in polygonalFace2Ds)
                    {
                        area_Footprint += ValueOrZero(polygonalFace2D.GetArea());
                    }
                }

                BoundingBox3D? boundingBox3D = buildingModel.GetBoundingBox();
                heatedVolume = boundingBox3D is null ? 0.0 : area_Footprint * (boundingBox3D.Max.Z - boundingBox3D.Min.Z);
                sources["HeatedVolume"] = "footprint area times height (external shell open)";
            }

            double ventilationHeatTransferCoefficient = Constants.Default.AirHeatCapacity * ((outsideAirPerArea * referenceFloorArea / 1000.0) + (infiltration * heatedVolume / 3600.0));

            double internalHeatCapacity = buildingModel.InternalHeatCapacity(heatDemandOptions_Temp.InternalHeatCapacityMaximumThickness, heatDemandOptions_Temp.InsulationThermalConductivity);
            double transmissionHeatTransferCoefficient = directHeatTransferCoefficient + thermalBridgeHeatTransferCoefficient + groundHeatTransferCoefficient + unheatedSpaceHeatTransferCoefficient;
            double heatTransferCoefficient = transmissionHeatTransferCoefficient + ventilationHeatTransferCoefficient;
            double timeConstant = heatTransferCoefficient > 0 ? internalHeatCapacity / 3600.0 / heatTransferCoefficient : double.NaN;
            double a = heatDemandOptions_Temp.UtilisationNumericalParameter + (timeConstant / heatDemandOptions_Temp.UtilisationReferenceTimeConstant);

            double skyRadiation = heatDemandOptions_Temp.IncludeSkyRadiation ? skyCoefficient * 5.0 * heatDemandOptions_Temp.ExternalEmissivity * heatDemandOptions_Temp.SkyTemperatureDifference : 0.0;

            List<double> transmissionHeatTransfers = [];
            List<double> ventilationHeatTransfers = [];
            List<double> internalHeatGains = [];
            List<double> solarHeatGains = [];
            List<double> skyRadiationHeatTransfers = [];
            List<double> heatBalanceRatios = [];
            List<double> gainUtilisationFactors = [];
            List<double> heatingEnergyNeeds = [];
            double heatingEnergyNeed = 0.0;
            for (int i = 0; i < 12; i++)
            {
                double monthDuration = Query.MonthDuration(i + 1);
                double temperatureDifference = internalTemperature_Zone - externalTemperatures[i];

                double transmissionHeatTransfer = transmissionHeatTransferCoefficient * temperatureDifference * monthDuration / 1000.0;
                double ventilationHeatTransfer = ventilationHeatTransferCoefficient * temperatureDifference * monthDuration / 1000.0;
                double internalHeatGain = internalGain * referenceFloorArea * monthDuration / 1000.0;
                double skyRadiationHeatTransfer = skyRadiation * monthDuration / 1000.0;

                double solarHeatGain = 0.0;
                foreach ((double coefficient, List<double>? irradiations) in solarCoefficients)
                {
                    if (irradiations is not null && !double.IsNaN(irradiations[i]))
                    {
                        solarHeatGain += coefficient * irradiations[i];
                    }
                }

                double heatTransfer = transmissionHeatTransfer + ventilationHeatTransfer;
                double heatGain = internalHeatGain + solarHeatGain - skyRadiationHeatTransfer;

                double heatBalanceRatio = heatTransfer != 0 ? heatGain / heatTransfer : double.NaN;
                double gainUtilisationFactor = heatGain <= 0 ? 1.0 : heatTransfer == 0 ? 0.0 : Query.UtilisationFactor(heatBalanceRatio, a);

                double heatingEnergyNeed_Month = System.Math.Max(0.0, heatTransfer - (gainUtilisationFactor * heatGain));

                transmissionHeatTransfers.Add(transmissionHeatTransfer);
                ventilationHeatTransfers.Add(ventilationHeatTransfer);
                internalHeatGains.Add(internalHeatGain);
                solarHeatGains.Add(solarHeatGain);
                skyRadiationHeatTransfers.Add(skyRadiationHeatTransfer);
                heatBalanceRatios.Add(heatBalanceRatio);
                gainUtilisationFactors.Add(gainUtilisationFactor);
                heatingEnergyNeeds.Add(heatingEnergyNeed_Month);
                heatingEnergyNeed += heatingEnergyNeed_Month;
            }

            double designHeatLoad = Query.DesignHeatLoad(directHeatTransferCoefficient + thermalBridgeHeatTransferCoefficient + unheatedSpaceHeatTransferCoefficient, groundHeatTransferCoefficient, ventilationHeatTransferCoefficient, internalTemperature_Zone, monthlyClimate.DesignExternalTemperature, monthlyClimate.AnnualMeanExternalTemperature);
            double designVentilationHeatLoss = double.IsNaN(designHeatLoad) ? double.NaN : ventilationHeatTransferCoefficient * (internalTemperature_Zone - monthlyClimate.DesignExternalTemperature);
            double designTransmissionHeatLoss = designHeatLoad - designVentilationHeatLoss;

            return new Classes.HeatDemandResult(
                heatingEnergyNeed,
                heatingEnergyNeed / referenceFloorArea,
                heatingEnergyNeeds,
                transmissionHeatTransfers,
                ventilationHeatTransfers,
                internalHeatGains,
                solarHeatGains,
                skyRadiationHeatTransfers,
                heatBalanceRatios,
                gainUtilisationFactors,
                directHeatTransferCoefficient,
                thermalBridgeHeatTransferCoefficient,
                groundHeatTransferCoefficient,
                unheatedSpaceHeatTransferCoefficient,
                ventilationHeatTransferCoefficient,
                internalHeatCapacity,
                timeConstant,
                referenceFloorArea,
                heatedVolume,
                internalTemperature_Zone,
                designHeatLoad,
                designTransmissionHeatLoss,
                designVentilationHeatLoss,
                Constants.Source.Method,
                Constants.Default.HeatDemandMethodVersion,
                sources,
                excludedComponents,
                glazingFallbackCount,
                missingIrradiationCount);
        }
    }
}
