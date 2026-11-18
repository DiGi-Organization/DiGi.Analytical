using DiGi.Analytical.Building.Classes;
using DiGi.Analytical.Building.Interfaces;
using System.Collections.Generic;

namespace DiGi.Analytical.Building.Energy
{
    public static partial class Query
    {
        /// <summary>
        /// Gets the reference floor area A_ref of a building model calculated as one heated zone: the sum of the gross floor areas of all its spaces (<see cref="FloorArea(BuildingModel?, ISpace?)"/>), matching <c>building_data.TotalArea</c> (DiGi-Organization/DiGi.Analytical#21).
        /// </summary>
        /// <param name="buildingModel">The building model. This value can be null.</param>
        /// <returns>The reference floor area [m2]; 0 when the model has no space, or <see cref="double.NaN"/> when it is null.</returns>
        public static double ReferenceFloorArea(this BuildingModel? buildingModel)
        {
            if (buildingModel is null)
            {
                return double.NaN;
            }

            double result = 0.0;
            List<ISpace>? spaces = buildingModel.GetSpaces<ISpace>();
            if (spaces is not null)
            {
                foreach (ISpace space in spaces)
                {
                    double floorArea = buildingModel.FloorArea(space);
                    if (!double.IsNaN(floorArea))
                    {
                        result += floorArea;
                    }
                }
            }

            return result;
        }
    }
}
