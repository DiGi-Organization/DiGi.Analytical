using DiGi.Analytical.Building.Interfaces;
using DiGi.Geometry.Core.Enums;
using DiGi.Geometry.Planar;
using DiGi.Geometry.Planar.Classes;
using DiGi.Geometry.Planar.Interfaces;
using DiGi.Geometry.Spatial;
using DiGi.Geometry.Spatial.Classes;
using DiGi.Geometry.Spatial.Interfaces;
using System.Collections.Generic;

namespace DiGi.Analytical.Building
{
    public static partial class Query
    {
        /// <summary>
        /// Checks whether the specified physical component can host the opening with the given construction.
        /// <para>The host surface (<see cref="Surface3D(IComponent)"/>) and the opening outline (<see cref="Surface3D(IOpening, IOpeningConstruction)"/>) must both be <see cref="IPolygonalFace3D"/>, they must be coplanar within <paramref name="tolerance"/>, and the opening outline must lie inside the host face: every point of its external edge lies inside or on the boundary of the host face (touching the host edge is allowed, crossing it or entering a hole is not), and no hole of the host face lies inside the opening.</para>
        /// <para>Overlap with other openings already hosted on the component is NOT checked.</para>
        /// </summary>
        /// <param name="physicalComponent">The physical component to host the opening. This value can be null.</param>
        /// <param name="opening">The opening providing the placement plane. This value can be null.</param>
        /// <param name="openingConstruction">The opening construction providing the 2D outline of the opening. This value can be null.</param>
        /// <param name="tolerance">The distance tolerance used for the coplanarity and containment checks.</param>
        /// <returns>True if the opening lies on and inside the host face; false otherwise, including when any argument is null or a geometry is not polygonal.</returns>
        public static bool IsValidHost(this IPhysicalComponent? physicalComponent, IOpening? opening, IOpeningConstruction? openingConstruction, double tolerance = Core.Constants.Tolerance.Distance)
        {
            if (physicalComponent == null || opening == null || openingConstruction == null)
            {
                return false;
            }

            if (physicalComponent.Surface3D() is not IPolygonalFace3D polygonalFace3D_Host)
            {
                return false;
            }

            if (opening.Surface3D(openingConstruction) is not IPolygonalFace3D polygonalFace3D_Opening)
            {
                return false;
            }

            if (!polygonalFace3D_Host.Coplanar(polygonalFace3D_Opening, tolerance))
            {
                return false;
            }

            Plane? plane = polygonalFace3D_Host.Plane;
            if (plane == null)
            {
                return false;
            }

            IPolygonalFace2D? polygonalFace2D_Host = plane.Convert(polygonalFace3D_Host);
            IPolygonalFace2D? polygonalFace2D_Opening = plane.Convert(polygonalFace3D_Opening);
            if (polygonalFace2D_Host == null || polygonalFace2D_Opening == null)
            {
                return false;
            }

            List<IPolygonal2D>? polygonal2Ds_Host = polygonalFace2D_Host.Edges;
            List<Segment2D>? segment2Ds_Opening = polygonalFace2D_Opening.ExternalEdge?.GetSegments();
            if (polygonal2Ds_Host == null || segment2Ds_Opening == null || segment2Ds_Opening.Count == 0)
            {
                return false;
            }

            List<Segment2D> segment2Ds_Host = [];
            foreach (IPolygonal2D polygonal2D_Host in polygonal2Ds_Host)
            {
                List<Segment2D>? segment2Ds = polygonal2D_Host?.GetSegments();
                if (segment2Ds != null)
                {
                    segment2Ds_Host.AddRange(segment2Ds);
                }
            }

            PolygonalFace2DPointRelationSolver polygonalFace2DPointRelationSolver_Host = new(polygonalFace2D_Host, tolerance);

            PointRelation PointRelation_Host(Point2D point2D)
            {
                polygonalFace2DPointRelationSolver_Host.Input = point2D;
                polygonalFace2DPointRelationSolver_Host.Solve();
                return polygonalFace2DPointRelationSolver_Host.Output;
            }

            // An opening exactly covering a hole has every edge on the host boundary, so its interior is tested too
            Point2D? point2D_Internal = polygonalFace2D_Opening.GetInternalPoint(tolerance);
            if (point2D_Internal == null || PointRelation_Host(point2D_Internal) != PointRelation.Inside)
            {
                return false;
            }

            foreach (Segment2D segment2D_Opening in segment2Ds_Opening)
            {
                Point2D? point2D_Start = segment2D_Opening.Start;
                Point2D? point2D_End = segment2D_Opening.End;
                if (point2D_Start == null || point2D_End == null)
                {
                    return false;
                }

                // Split the edge at every crossing with the host boundary; each piece then lies entirely on one side, so its mid point decides
                List<Point2D> point2Ds = [point2D_Start, point2D_End];

                List<Point2D>? point2Ds_Intersection = segment2D_Opening.IntersectionPoints(segment2Ds_Host, tolerance);
                if (point2Ds_Intersection != null)
                {
                    point2Ds.AddRange(point2Ds_Intersection);
                }

                point2Ds.Sort((x, y) => point2D_Start.Distance(x).CompareTo(point2D_Start.Distance(y)));

                for (int i = 0; i < point2Ds.Count; i++)
                {
                    PointRelation pointRelation = PointRelation_Host(point2Ds[i]);
                    if (pointRelation != PointRelation.Inside && pointRelation != PointRelation.On)
                    {
                        return false;
                    }

                    if (i == point2Ds.Count - 1)
                    {
                        continue;
                    }

                    Point2D? point2D_Mid = point2Ds[i].Mid(point2Ds[i + 1]);
                    if (point2D_Mid == null)
                    {
                        continue;
                    }

                    pointRelation = PointRelation_Host(point2D_Mid);
                    if (pointRelation != PointRelation.Inside && pointRelation != PointRelation.On)
                    {
                        return false;
                    }
                }
            }

            // A hole enclosed by the opening is crossed by none of its edges, so the holes are tested against the opening
            List<IPolygonal2D>? polygonal2Ds_Internal = polygonalFace2D_Host.InternalEdges;
            if (polygonal2Ds_Internal == null || polygonal2Ds_Internal.Count == 0)
            {
                return true;
            }

            PolygonalFace2DPointRelationSolver polygonalFace2DPointRelationSolver_Opening = new(polygonalFace2D_Opening, tolerance);
            foreach (IPolygonal2D polygonal2D_Internal in polygonal2Ds_Internal)
            {
                if (polygonal2D_Internal == null)
                {
                    continue;
                }

                List<Point2D> point2Ds_Internal = [];

                List<Point2D>? point2Ds_Hole = polygonal2D_Internal.GetPoints();
                if (point2Ds_Hole != null)
                {
                    point2Ds_Internal.AddRange(point2Ds_Hole);
                }

                Point2D? point2D_Internal_Hole = polygonal2D_Internal.GetInternalPoint(tolerance);
                if (point2D_Internal_Hole != null)
                {
                    point2Ds_Internal.Add(point2D_Internal_Hole);
                }

                foreach (Point2D point2D in point2Ds_Internal)
                {
                    polygonalFace2DPointRelationSolver_Opening.Input = point2D;
                    polygonalFace2DPointRelationSolver_Opening.Solve();
                    if (polygonalFace2DPointRelationSolver_Opening.Output == PointRelation.Inside)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
