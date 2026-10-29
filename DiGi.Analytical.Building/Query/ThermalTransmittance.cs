using DiGi.Analytical.Building.Classes;
using DiGi.Analytical.Building.Enums;
using DiGi.Analytical.Building.Interfaces;
using DiGi.Analytical.Classes;
using DiGi.Analytical.Interfaces;
using DiGi.Core.Parameter.Classes;
using DiGi.Geometry.Planar.Classes;
using DiGi.Geometry.Planar.Interfaces;
using System.Collections.Generic;

namespace DiGi.Analytical.Building
{
    public static partial class Query
    {
        /// <summary>
        /// Calculates the thermal transmittance U of a layered construction per PN-EN ISO 6946: U = 1 / (Rsi + Σ R + Rse) (DiGi-Organization/DiGi.Analytical#8).
        /// <para>The resistance R of a layer is d/λ for an <see cref="OpaqueMaterial"/> or a <see cref="TransparentMaterial"/>, and the tabulated resistance of an unventilated air layer for a <see cref="FluidMaterial"/> (<see cref="AirLayerThermalResistance(double, HeatFlowDirection)"/>). Rsi and Rse follow <see cref="SurfaceResistance(HeatFlowDirection, bool)"/>; a face in contact with the ground has no external surface resistance. Ground heat transfer (PN-EN ISO 13370) is not modelled.</para>
        /// <para>The result is <see cref="double.NaN"/> - never an optimistic value - when there is no layer, a layer has no material, a material has no conductivity (0 or less), a thickness is NaN or negative, or the direction is undefined.</para>
        /// </summary>
        /// <param name="structureLayers">The layers of the construction with their materials. This value can be null.</param>
        /// <param name="heatFlowDirection">The direction of the heat flow through the construction.</param>
        /// <param name="groundContact">True when the external face is in contact with the ground, so that it has no surface resistance.</param>
        /// <returns>The thermal transmittance U [W/(m2K)], or <see cref="double.NaN"/> when it cannot be determined.</returns>
        public static double ThermalTransmittance(IEnumerable<(IStructureLayer StructureLayer, IMaterial? Material)>? structureLayers, HeatFlowDirection heatFlowDirection, bool groundContact = false)
        {
            if (structureLayers is null || heatFlowDirection == HeatFlowDirection.Undefined)
            {
                return double.NaN;
            }

            double thermalResistance = SurfaceResistance(heatFlowDirection, true) + (groundContact ? 0.0 : SurfaceResistance(heatFlowDirection, false));

            int count = 0;
            foreach ((IStructureLayer structureLayer, IMaterial? material) in structureLayers)
            {
                double thickness = structureLayer?.Thickness ?? double.NaN;
                if (double.IsNaN(thickness) || thickness < 0)
                {
                    return double.NaN;
                }

                double thermalResistance_Layer = material switch
                {
                    OpaqueMaterial opaqueMaterial when opaqueMaterial.Conductivity > 0 => thickness / opaqueMaterial.Conductivity,
                    TransparentMaterial transparentMaterial when transparentMaterial.Conductivity > 0 => thickness / transparentMaterial.Conductivity,
                    FluidMaterial => AirLayerThermalResistance(thickness, heatFlowDirection),
                    _ => double.NaN,
                };

                if (double.IsNaN(thermalResistance_Layer))
                {
                    return double.NaN;
                }

                thermalResistance += thermalResistance_Layer;
                count++;
            }

            if (count == 0 || thermalResistance <= 0)
            {
                return double.NaN;
            }

            return 1.0 / thermalResistance;
        }

        /// <summary>
        /// Determines the thermal transmittance U of a wall, roof or floor construction held by a construction relation cluster (DiGi-Organization/DiGi.Analytical#8).
        /// <para>A declared <see cref="PhysicalComponentConstructionParameter.ThermalTransmittance"/> is returned as it stands. Otherwise U is calculated from the construction's layers and their materials per PN-EN ISO 6946.</para>
        /// </summary>
        /// <param name="constructionRelationCluster">The cluster holding the construction's layers and materials. This value can be null.</param>
        /// <param name="physicalComponentConstruction">The construction. This value can be null.</param>
        /// <param name="heatFlowDirection">The direction of the heat flow through the construction.</param>
        /// <param name="groundContact">True when the external face is in contact with the ground, so that it has no surface resistance.</param>
        /// <returns>The thermal transmittance U [W/(m2K)], or <see cref="double.NaN"/> when it cannot be determined.</returns>
        public static double ThermalTransmittance(this ConstructionRelationCluster? constructionRelationCluster, IPhysicalComponentConstruction? physicalComponentConstruction, HeatFlowDirection heatFlowDirection, bool groundContact = false)
        {
            if (physicalComponentConstruction is null)
            {
                return double.NaN;
            }

            if (physicalComponentConstruction.TryGetValue(new EnumParameterDefinition(PhysicalComponentConstructionParameter.ThermalTransmittance), out double thermalTransmittance) && !double.IsNaN(thermalTransmittance))
            {
                return thermalTransmittance;
            }

            List<IStructureLayer>? structureLayers = constructionRelationCluster?.GetStructureLayers(physicalComponentConstruction);
            if (structureLayers is null)
            {
                return double.NaN;
            }

            return ThermalTransmittance(structureLayers.ConvertAll(x => (x, constructionRelationCluster!.GetMaterial(x))), heatFlowDirection, groundContact);
        }

        /// <summary>
        /// Determines the thermal transmittance U of a wall, roof or floor construction held by a building model (DiGi-Organization/DiGi.Analytical#8).
        /// <para>A declared <see cref="PhysicalComponentConstructionParameter.ThermalTransmittance"/> is returned as it stands. Otherwise U is calculated from the construction's layers and their materials in the model per PN-EN ISO 6946.</para>
        /// </summary>
        /// <param name="buildingModel">The building model holding the construction's layers and materials. This value can be null.</param>
        /// <param name="physicalComponentConstruction">The construction. This value can be null.</param>
        /// <param name="heatFlowDirection">The direction of the heat flow through the construction.</param>
        /// <param name="groundContact">True when the external face is in contact with the ground, so that it has no surface resistance.</param>
        /// <returns>The thermal transmittance U [W/(m2K)], or <see cref="double.NaN"/> when it cannot be determined.</returns>
        public static double ThermalTransmittance(this BuildingModel? buildingModel, IPhysicalComponentConstruction? physicalComponentConstruction, HeatFlowDirection heatFlowDirection, bool groundContact = false)
        {
            if (physicalComponentConstruction is null)
            {
                return double.NaN;
            }

            if (physicalComponentConstruction.TryGetValue(new EnumParameterDefinition(PhysicalComponentConstructionParameter.ThermalTransmittance), out double thermalTransmittance) && !double.IsNaN(thermalTransmittance))
            {
                return thermalTransmittance;
            }

            List<IStructureLayer>? structureLayers = buildingModel?.GetStructureLayers(physicalComponentConstruction);
            if (structureLayers is null)
            {
                return double.NaN;
            }

            return ThermalTransmittance(structureLayers.ConvertAll(x => (x, buildingModel!.GetMaterial(x))), heatFlowDirection, groundContact);
        }

        /// <summary>
        /// Determines the thermal transmittance Uw of a window or door construction (DiGi-Organization/DiGi.Analytical#8).
        /// <para>The outline of the construction is a face whose holes are the glazing and whose remainder is the frame. When it has at least one hole and the glazing Ug, frame Uf and glazing-edge Ψg values are declared (<see cref="OpeningConstructionParameter"/>), Uw = (Ag·Ug + Af·Uf + lg·Ψg) / (Ag + Af) per PN-EN ISO 10077-1, with Ag the area of the holes, Af the rest of the outline and lg the perimeter of the holes. The value follows the geometry, so a construction cloned to another size keeps a correct Uw.</para>
        /// <para>Otherwise the declared <see cref="OpeningConstructionParameter.ThermalTransmittance"/> is returned, and <see cref="double.NaN"/> when there is none.</para>
        /// </summary>
        /// <param name="openingConstruction">The window or door construction. This value can be null.</param>
        /// <returns>The thermal transmittance Uw [W/(m2K)], or <see cref="double.NaN"/> when it cannot be determined.</returns>
        public static double ThermalTransmittance(this IOpeningConstruction? openingConstruction)
        {
            if (openingConstruction is null)
            {
                return double.NaN;
            }

            double Value(OpeningConstructionParameter openingConstructionParameter)
            {
                return openingConstruction.TryGetValue(new EnumParameterDefinition(openingConstructionParameter), out double value) ? value : double.NaN;
            }

            double glazingThermalTransmittance = Value(OpeningConstructionParameter.GlazingThermalTransmittance);
            double frameThermalTransmittance = Value(OpeningConstructionParameter.FrameThermalTransmittance);
            double glazingLinearThermalTransmittance = Value(OpeningConstructionParameter.GlazingLinearThermalTransmittance);

            if (!double.IsNaN(glazingThermalTransmittance) && !double.IsNaN(frameThermalTransmittance) && !double.IsNaN(glazingLinearThermalTransmittance) && openingConstruction is IBuildingGeometryObject<ISurface2D> { Geometry: IPolygonalFace2D polygonalFace2D } && polygonalFace2D.ExternalEdge is IPolygonal2D externalEdge && polygonalFace2D.InternalEdges is List<IPolygonal2D> internalEdges && internalEdges.Count != 0)
            {
                double area = externalEdge.GetArea();
                double area_Glazing = 0;
                double perimeter_Glazing = 0;
                foreach (IPolygonal2D internalEdge in internalEdges)
                {
                    area_Glazing += internalEdge.GetArea();

                    List<Segment2D>? segment2Ds = internalEdge.GetSegments();
                    if (segment2Ds is not null)
                    {
                        foreach (Segment2D segment2D in segment2Ds)
                        {
                            perimeter_Glazing += segment2D.Length;
                        }
                    }
                }

                if (area > 0 && area_Glazing <= area)
                {
                    return ((area_Glazing * glazingThermalTransmittance) + ((area - area_Glazing) * frameThermalTransmittance) + (perimeter_Glazing * glazingLinearThermalTransmittance)) / area;
                }
            }

            return Value(OpeningConstructionParameter.ThermalTransmittance);
        }
    }
}
