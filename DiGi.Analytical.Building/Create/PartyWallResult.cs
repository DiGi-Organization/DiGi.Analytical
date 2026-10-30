using DiGi.Analytical.Building.Classes;
using DiGi.Analytical.Building.Interfaces;
using DiGi.Core.Classes;
using DiGi.Geometry.Spatial.Classes;
using DiGi.Geometry.Spatial.Interfaces;
using System;
using System.Collections.Generic;

namespace DiGi.Analytical.Building
{
    public static partial class Create
    {
        /// <summary>
        /// Creates the result describing the part of a wall shared with a wall of an adjacent building (DiGi-Organization/DiGi.GIS.Analytical#4).
        /// <para>The shared part is what the two planar wall faces have in common when they are nearly coplanar, as <see cref="Geometry.Spatial.Query.CoplanarIntersection"/> computes it: parallel within <paramref name="maxAngle"/>, every vertex of the neighbour face within <paramref name="maxDistance"/> of the plane of the wall, intersected in that plane. Because the real faces are compared, a gable, a lower or a shifted neighbour gives only the part both walls cover. No result is created when the shared area is below <paramref name="minArea"/>: two walls meeting along an edge only, such as two facades in one street front, share nothing.</para>
        /// <para>The faces are not oriented here, so a wall facing the same way as the neighbour wall - as two overlapping footprints give - passes this test. <see cref="Query.PartyWalls(BuildingModel?, IEnumerable{BuildingModel?}?, double, double, double, double)"/> adds that test from the outward normals of each model's envelope.</para>
        /// </summary>
        /// <param name="wall">The wall of the building examined. This value can be null.</param>
        /// <param name="neighbourBuildingModel">The building model of the adjacent building. This value can be null.</param>
        /// <param name="wall_Neighbour">The wall of the adjacent building. This value can be null.</param>
        /// <param name="maxDistance">The largest distance [m] between the two wall planes, measured at the vertices of the neighbour face, at which the walls still count as one party wall.</param>
        /// <param name="maxAngle">The largest angle [rad] between the two wall planes at which they still count as parallel.</param>
        /// <param name="minArea">The smallest shared area [m2] that makes a party wall.</param>
        /// <param name="tolerance">The distance tolerance.</param>
        /// <returns>The <see cref="Classes.PartyWallResult"/>, or null when either wall has no planar face, the walls are not nearly coplanar, or they share less than <paramref name="minArea"/>.</returns>
        public static Classes.PartyWallResult? PartyWallResult(this IWall? wall, BuildingModel? neighbourBuildingModel, IWall? wall_Neighbour, double maxDistance = 0.2, double maxAngle = 5.0 * Math.PI / 180.0, double minArea = 0.1, double tolerance = Core.Constants.Tolerance.Distance)
        {
            if (wall?.Surface3D() is not IPolygonalFace3D polygonalFace3D || wall_Neighbour?.Surface3D() is not IPolygonalFace3D polygonalFace3D_Neighbour)
            {
                return null;
            }

            List<PolygonalFace3D>? polygonalFace3Ds_Shared = Geometry.Spatial.Query.CoplanarIntersection(polygonalFace3D, polygonalFace3D_Neighbour, maxDistance, maxAngle, tolerance);
            if (polygonalFace3Ds_Shared is null || polygonalFace3Ds_Shared.Count == 0)
            {
                return null;
            }

            double area = 0;
            foreach (PolygonalFace3D polygonalFace3D_Shared in polygonalFace3Ds_Shared)
            {
                area += polygonalFace3D_Shared.GetArea();
            }

            if (!(area >= minArea))
            {
                return null;
            }

            return new Classes.PartyWallResult(new GuidReference(wall), neighbourBuildingModel is null ? null : new GuidReference(neighbourBuildingModel), new GuidReference(wall_Neighbour), polygonalFace3Ds_Shared, area);
        }
    }
}
