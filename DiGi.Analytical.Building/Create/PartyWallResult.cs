using DiGi.Analytical.Building.Classes;
using DiGi.Analytical.Building.Interfaces;
using DiGi.Core.Classes;
using DiGi.Geometry.Planar.Classes;
using DiGi.Geometry.Planar.Interfaces;
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
        /// <para>The two walls share a part when their planar faces are parallel within <paramref name="maxAngle"/>, face each other, and every vertex of the neighbour face lies within <paramref name="maxDistance"/> of the plane of the wall. The neighbour face is then converted into the plane of the wall and intersected with the wall face; the shared part is that intersection. Because the real faces are compared, a gable, a lower or a shifted neighbour gives only the part both walls cover.</para>
        /// <para>The walls face each other when their outward normals point in opposite directions, so the two buildings lie on opposite sides of the shared plane. The stored face normals are not oriented, so the outward normals are passed in - <c>Query.PartyWalls</c> reads them from each model's external envelope. A coplanar wall on the same side, as two overlapping footprints give, is then no party wall. When either outward normal is unknown the test is not made.</para>
        /// <para>Pieces of the intersection smaller than the square of <paramref name="tolerance"/> are dropped as slivers, and no result is created when the remaining area is below <paramref name="minArea"/>: two walls meeting along an edge only, such as two facades in one street front, share nothing.</para>
        /// </summary>
        /// <param name="wall">The wall of the building examined. This value can be null.</param>
        /// <param name="normal_Outward">The outward normal of <paramref name="wall"/>, or null when it is not known.</param>
        /// <param name="neighbourBuildingModel">The building model of the adjacent building. This value can be null.</param>
        /// <param name="wall_Neighbour">The wall of the adjacent building. This value can be null.</param>
        /// <param name="normal_Outward_Neighbour">The outward normal of <paramref name="wall_Neighbour"/>, or null when it is not known.</param>
        /// <param name="maxDistance">The largest distance [m] between the two wall planes, measured at the vertices of the neighbour face, at which the walls still count as one party wall.</param>
        /// <param name="maxAngle">The largest angle [rad] between the two wall planes at which they still count as parallel.</param>
        /// <param name="minArea">The smallest shared area [m2] that makes a party wall.</param>
        /// <param name="tolerance">The distance tolerance.</param>
        /// <returns>The <see cref="Classes.PartyWallResult"/>, or null when either wall has no planar face, the walls are not parallel, facing each other or close enough, or they share less than <paramref name="minArea"/>.</returns>
        public static Classes.PartyWallResult? PartyWallResult(
            this IWall? wall,
            Vector3D? normal_Outward,
            BuildingModel? neighbourBuildingModel,
            IWall? wall_Neighbour,
            Vector3D? normal_Outward_Neighbour,
            double maxDistance = 0.2,
            double maxAngle = 5.0 * Math.PI / 180.0,
            double minArea = 0.1,
            double tolerance = Core.Constants.Tolerance.Distance)
        {
            if (wall?.Surface3D() is not IPolygonalFace3D polygonalFace3D || wall_Neighbour?.Surface3D() is not IPolygonalFace3D polygonalFace3D_Neighbour)
            {
                return null;
            }

            Plane? plane = polygonalFace3D.Plane;
            Vector3D? normal = plane?.Normal?.Unit;
            Vector3D? normal_Neighbour = polygonalFace3D_Neighbour.Plane?.Normal?.Unit;
            if (plane is null || normal is null || normal_Neighbour is null)
            {
                return null;
            }

            if (Math.Abs(normal.DotProduct(normal_Neighbour)) < Math.Cos(maxAngle))
            {
                return null;
            }

            if (normal_Outward is not null && normal_Outward_Neighbour is not null && !(normal_Outward.DotProduct(normal_Outward_Neighbour) < 0))
            {
                return null;
            }

            List<Point3D>? point3Ds_Neighbour = polygonalFace3D_Neighbour.ExternalEdge?.GetPoints();
            if (point3Ds_Neighbour is null || point3Ds_Neighbour.Count < 3)
            {
                return null;
            }

            foreach (Point3D point3D in point3Ds_Neighbour)
            {
                if (!(plane.Distance(point3D) <= maxDistance))
                {
                    return null;
                }
            }

            Polygon2D? Polygon2D(IPolygonal3D? polygonal3D)
            {
                List<Point3D>? point3Ds = polygonal3D?.GetPoints();
                if (point3Ds is null || point3Ds.Count < 3)
                {
                    return null;
                }

                List<Point2D> point2Ds = [];
                foreach (Point3D point3D in point3Ds)
                {
                    if (Geometry.Spatial.Query.Convert(plane, point3D) is Point2D point2D)
                    {
                        point2Ds.Add(point2D);
                    }
                }

                return point2Ds.Count < 3 ? null : new Polygon2D(point2Ds);
            }

            List<IPolygonal2D> polygonal2Ds_Internal_Neighbour = [];
            if (polygonalFace3D_Neighbour.InternalEdges is List<IPolygonal3D> polygonal3Ds_Internal)
            {
                foreach (IPolygonal3D polygonal3D_Internal in polygonal3Ds_Internal)
                {
                    if (Polygon2D(polygonal3D_Internal) is Polygon2D polygon2D_Internal)
                    {
                        polygonal2Ds_Internal_Neighbour.Add(polygon2D_Internal);
                    }
                }
            }

            PolygonalFace2D? polygonalFace2D_Neighbour = Geometry.Planar.Create.PolygonalFace2D(Polygon2D(polygonalFace3D_Neighbour.ExternalEdge), polygonal2Ds_Internal_Neighbour, tolerance);

            IPolygonalFace2D? polygonalFace2D_Wall = polygonalFace3D.Geometry2D;
            PolygonalFace2D? polygonalFace2D = polygonalFace2D_Wall is null ? null : Geometry.Planar.Create.PolygonalFace2D(polygonalFace2D_Wall.ExternalEdge, polygonalFace2D_Wall.InternalEdges, tolerance);
            if (polygonalFace2D is null || polygonalFace2D_Neighbour is null)
            {
                return null;
            }

            List<PolygonalFace2D>? polygonalFace2Ds_Shared = Geometry.Planar.Query.Intersection(polygonalFace2D, polygonalFace2D_Neighbour);
            if (polygonalFace2Ds_Shared is null || polygonalFace2Ds_Shared.Count == 0)
            {
                return null;
            }

            double area = 0;
            List<PolygonalFace3D> polygonalFace3Ds_Shared = [];
            foreach (PolygonalFace2D polygonalFace2D_Shared in polygonalFace2Ds_Shared)
            {
                double area_Shared = polygonalFace2D_Shared.GetArea();
                if (double.IsNaN(area_Shared) || area_Shared < tolerance * tolerance)
                {
                    continue;
                }

                area += area_Shared;
                polygonalFace3Ds_Shared.Add(new PolygonalFace3D(plane, polygonalFace2D_Shared));
            }

            if (area < minArea || polygonalFace3Ds_Shared.Count == 0)
            {
                return null;
            }

            return new Classes.PartyWallResult(new GuidReference(wall), neighbourBuildingModel is null ? null : new GuidReference(neighbourBuildingModel), new GuidReference(wall_Neighbour), polygonalFace3Ds_Shared, area);
        }
    }
}
