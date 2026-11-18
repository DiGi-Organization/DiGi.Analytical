using DiGi.Analytical.Building.Classes;
using DiGi.Analytical.Building.Interfaces;
using DiGi.Analytical.Interfaces;
using System.Collections.Generic;

namespace DiGi.Analytical.Building.Energy
{
    public static partial class Query
    {
        /// <summary>
        /// Gets the internal heat capacity C_m = Σ κ_j·A_j of a building model calculated as one heated zone (DiGi-Organization/DiGi.Analytical#21), <see cref="Constants.Source.InternalHeatCapacity"/>.
        /// <para>Every wall, roof and floor with a layered construction counts each of its faces that is in contact with the zone's air: a component bounding one space (the envelope, party walls included) with its inner face - the last layer, as layers are ordered from the outside inwards - and a component bounding two spaces (internal walls, intermediate floors) with both faces. A component bounding no space is not counted. κ is <see cref="ArealHeatCapacity(IEnumerable{ValueTuple{IStructureLayer, IMaterial}}?, double, double)"/> of each face; the area of a component is its face less the outlines of the openings it hosts. Openings themselves are not counted.</para>
        /// </summary>
        /// <param name="buildingModel">The building model. This value can be null.</param>
        /// <param name="maximumThickness">The maximum effective thickness, from each face [m].</param>
        /// <param name="insulationThermalConductivity">The thermal conductivity [W/(mK)] at or below which a layer ends the effective thickness.</param>
        /// <returns>The internal heat capacity [J/K]; 0 when no component has layers, or <see cref="double.NaN"/> when the model is null.</returns>
        public static double InternalHeatCapacity(this BuildingModel? buildingModel, double maximumThickness = Constants.Default.InternalHeatCapacityMaximumThickness, double insulationThermalConductivity = Constants.Default.InsulationThermalConductivity)
        {
            if (buildingModel is null)
            {
                return double.NaN;
            }

            List<IComponent>? components = buildingModel.GetComponents<IComponent>();
            if (components is null)
            {
                return 0.0;
            }

            double result = 0.0;
            foreach (IComponent component in components)
            {
                IPhysicalComponentConstruction? physicalComponentConstruction = component switch
                {
                    IWall wall => buildingModel.GetWallConstruction(wall),
                    IRoof roof => buildingModel.GetRoofConstruction(roof),
                    IFloor floor => buildingModel.GetFloorConstruction(floor),
                    _ => null,
                };

                List<IStructureLayer>? structureLayers = buildingModel.GetStructureLayers(physicalComponentConstruction);
                if (structureLayers is null || structureLayers.Count == 0)
                {
                    continue;
                }

                int count = buildingModel.GetSpaces(component)?.Count ?? 0;
                if (count == 0)
                {
                    continue;
                }

                double area = component.Area();
                if (double.IsNaN(area))
                {
                    continue;
                }

                List<IOpening>? openings = buildingModel.GetOpenings<IOpening>(component);
                if (openings is not null)
                {
                    foreach (IOpening opening in openings)
                    {
                        double area_Opening = opening.Area(buildingModel.GetOpeningConstruction<IOpeningConstruction>(opening));
                        if (!double.IsNaN(area_Opening))
                        {
                            area -= area_Opening;
                        }
                    }
                }

                if (area <= 0)
                {
                    continue;
                }

                List<(IStructureLayer StructureLayer, IMaterial? Material)> structureLayers_Inside = structureLayers.ConvertAll(x => (x, buildingModel.GetMaterial(x)));
                structureLayers_Inside.Reverse();

                double arealHeatCapacity = structureLayers_Inside.ArealHeatCapacity(maximumThickness, insulationThermalConductivity);
                if (count > 1)
                {
                    arealHeatCapacity += structureLayers.ConvertAll(x => (x, buildingModel.GetMaterial(x))).ArealHeatCapacity(maximumThickness, insulationThermalConductivity);
                }

                result += arealHeatCapacity * area;
            }

            return result;
        }
    }
}
