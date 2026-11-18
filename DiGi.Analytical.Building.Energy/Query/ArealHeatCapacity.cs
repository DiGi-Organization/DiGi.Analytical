using DiGi.Analytical.Building.Interfaces;
using DiGi.Analytical.Classes;
using DiGi.Analytical.Interfaces;
using System.Collections.Generic;

namespace DiGi.Analytical.Building.Energy
{
    public static partial class Query
    {
        /// <summary>
        /// Gets the internal areal heat capacity κ of one face of a building element, per PN-EN ISO 13786 Annex A (simplified) as the internal heat capacity of the monthly method uses it (DiGi-Organization/DiGi.Analytical#21), <see cref="Constants.Source.InternalHeatCapacity"/>.
        /// <para>κ = Σ ρ_j·c_j·d_j over the layers from the face inwards, up to the smallest of: <paramref name="maximumThickness"/>, half the total thickness of the element, and the first insulating layer - one whose thermal conductivity is at most <paramref name="insulationThermalConductivity"/>, which is not counted. A layer the limit cuts counts with the part before the limit. A layer whose material has no density or specific heat - an unknown or transparent material - contributes nothing but its thickness; a fluid (an air gap) contributes its own ρ·c.</para>
        /// </summary>
        /// <param name="structureLayers">The layers and their materials, ordered from the face whose capacity is wanted inwards. This value can be null.</param>
        /// <param name="maximumThickness">The maximum effective thickness [m].</param>
        /// <param name="insulationThermalConductivity">The thermal conductivity [W/(mK)] at or below which a layer ends the effective thickness.</param>
        /// <returns>The areal heat capacity [J/(m2K)]; 0 when there are no layers.</returns>
        public static double ArealHeatCapacity(this IEnumerable<(IStructureLayer StructureLayer, IMaterial? Material)>? structureLayers, double maximumThickness = Constants.Default.InternalHeatCapacityMaximumThickness, double insulationThermalConductivity = Constants.Default.InsulationThermalConductivity)
        {
            if (structureLayers is null)
            {
                return 0.0;
            }

            List<(IStructureLayer StructureLayer, IMaterial? Material)> structureLayers_Temp = [];
            double thickness_Total = 0.0;
            foreach ((IStructureLayer StructureLayer, IMaterial? Material) structureLayer in structureLayers)
            {
                if (structureLayer.StructureLayer is null || double.IsNaN(structureLayer.StructureLayer.Thickness) || structureLayer.StructureLayer.Thickness <= 0)
                {
                    continue;
                }

                structureLayers_Temp.Add(structureLayer);
                thickness_Total += structureLayer.StructureLayer.Thickness;
            }

            double thickness_Limit = System.Math.Min(maximumThickness, thickness_Total / 2.0);

            double result = 0.0;
            double thickness = 0.0;
            foreach ((IStructureLayer structureLayer, IMaterial? material) in structureLayers_Temp)
            {
                if (thickness >= thickness_Limit)
                {
                    break;
                }

                double volumetricHeatCapacity;
                if (material is OpaqueMaterial opaqueMaterial)
                {
                    if (opaqueMaterial.Conductivity > 0 && opaqueMaterial.Conductivity <= insulationThermalConductivity)
                    {
                        break;
                    }

                    volumetricHeatCapacity = opaqueMaterial.Density * opaqueMaterial.SpecificHeat;
                }
                else if (material is FluidMaterial fluidMaterial)
                {
                    volumetricHeatCapacity = fluidMaterial.Density * fluidMaterial.SpecificHeat;
                }
                else
                {
                    volumetricHeatCapacity = 0.0;
                }

                double thickness_Layer = System.Math.Min(structureLayer.Thickness, thickness_Limit - thickness);
                if (!double.IsNaN(volumetricHeatCapacity) && volumetricHeatCapacity > 0)
                {
                    result += volumetricHeatCapacity * thickness_Layer;
                }

                thickness += thickness_Layer;
            }

            return result;
        }
    }
}
