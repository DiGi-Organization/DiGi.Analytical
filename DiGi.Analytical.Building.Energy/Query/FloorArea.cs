using DiGi.Analytical.Building.Classes;
using DiGi.Analytical.Building.Interfaces;
using DiGi.Geometry.Spatial.Classes;
using System.Collections.Generic;

namespace DiGi.Analytical.Building.Energy
{
    public static partial class Query
    {
        /// <summary>
        /// Gets the gross floor area of a space: the area of the floors bounding it at its lowest level (DiGi-Organization/DiGi.Analytical#21).
        /// <para>A space is bounded by its own floor and by the floor of the space above, its ceiling, so only the floors whose geometry reaches within <see cref="Constants.Default.LevelTolerance"/> of the lowest of them count.</para>
        /// </summary>
        /// <param name="buildingModel">The building model holding the space. This value can be null.</param>
        /// <param name="space">The space. This value can be null.</param>
        /// <returns>The floor area [m2]; 0 when the space has no floor, or <see cref="double.NaN"/> when either argument is null.</returns>
        public static double FloorArea(this BuildingModel? buildingModel, ISpace? space)
        {
            if (buildingModel is null || space is null)
            {
                return double.NaN;
            }

            List<IFloor>? floors = buildingModel.GetComponents<IFloor>(space);
            if (floors is null || floors.Count == 0)
            {
                return 0.0;
            }

            List<(IFloor Floor, double Elevation)> floors_Elevation = [];
            double elevation_Min = double.MaxValue;
            foreach (IFloor floor in floors)
            {
                if (floor.GetBoundingBox() is BoundingBox3D boundingBox3D)
                {
                    floors_Elevation.Add((floor, boundingBox3D.Min.Z));
                    elevation_Min = System.Math.Min(elevation_Min, boundingBox3D.Min.Z);
                }
            }

            double result = 0.0;
            foreach ((IFloor floor, double elevation) in floors_Elevation)
            {
                if (elevation - elevation_Min <= Constants.Default.LevelTolerance && floor.Area() is double area && !double.IsNaN(area))
                {
                    result += area;
                }
            }

            return result;
        }
    }
}
