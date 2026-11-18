using DiGi.Analytical.Building.Classes;
using DiGi.Analytical.Building.Enums;
using DiGi.Analytical.Building.Interfaces;
using DiGi.Core.Parameter.Classes;
using DiGi.Geometry.Planar.Classes;
using DiGi.Geometry.Planar.Interfaces;
using DiGi.Geometry.Spatial.Classes;
using System;
using System.Collections.Generic;

namespace DiGi.Analytical.Building.Energy
{
    public static partial class Query
    {
        /// <summary>
        /// Gets the exposed perimeter P of the ground floor of a building model, the perimeter of PN-EN ISO 13370 (DiGi-Organization/DiGi.Analytical#21), <see cref="Constants.Source.Ground"/>.
        /// <para>The perimeter of the model's footprint (<see cref="Building.Query.Footprints(BuildingModel?, double)"/>, courtyard edges included) less the base length of every party wall (<see cref="ComponentParameter.PartyWall"/>) standing at the lowest level of the model: an edge along a heated neighbour loses no heat through the ground. The base length of a party wall is the horizontal extent of its face, which is vertical.</para>
        /// </summary>
        /// <param name="buildingModel">The building model. This value can be null.</param>
        /// <param name="tolerance">The distance tolerance of the footprint.</param>
        /// <returns>The exposed perimeter [m], never below 0, or <see cref="double.NaN"/> when the model is null or has no footprint.</returns>
        public static double ExposedPerimeter(this BuildingModel? buildingModel, double tolerance = Core.Constants.Tolerance.Distance)
        {
            List<PolygonalFace2D>? polygonalFace2Ds = buildingModel?.Footprints(tolerance);
            if (buildingModel is null || polygonalFace2Ds is null || polygonalFace2Ds.Count == 0)
            {
                return double.NaN;
            }

            double result = 0.0;
            foreach (PolygonalFace2D polygonalFace2D in polygonalFace2Ds)
            {
                if (polygonalFace2D.ExternalEdge is IPolygonal2D polygonal2D_External)
                {
                    result += polygonal2D_External.GetPerimeter();
                }

                List<IPolygonal2D>? polygonal2Ds_Internal = polygonalFace2D.InternalEdges;
                if (polygonal2Ds_Internal is not null)
                {
                    foreach (IPolygonal2D polygonal2D_Internal in polygonal2Ds_Internal)
                    {
                        result += polygonal2D_Internal.GetPerimeter();
                    }
                }
            }

            double elevation_Min = buildingModel.GetBoundingBox()?.Min.Z ?? double.NaN;
            if (double.IsNaN(elevation_Min))
            {
                return result;
            }

            List<IWall>? walls = buildingModel.GetComponents<IWall>();
            if (walls is not null)
            {
                foreach (IWall wall in walls)
                {
                    if (wall is not Component component || !component.TryGetValue(new EnumParameterDefinition(ComponentParameter.PartyWall), out Guid _))
                    {
                        continue;
                    }

                    if (wall.GetBoundingBox() is not BoundingBox3D boundingBox3D || boundingBox3D.Min.Z - elevation_Min > Constants.Default.LevelTolerance)
                    {
                        continue;
                    }

                    double x = boundingBox3D.Max.X - boundingBox3D.Min.X;
                    double y = boundingBox3D.Max.Y - boundingBox3D.Min.Y;
                    result -= System.Math.Sqrt((x * x) + (y * y));
                }
            }

            return System.Math.Max(0.0, result);
        }
    }
}
