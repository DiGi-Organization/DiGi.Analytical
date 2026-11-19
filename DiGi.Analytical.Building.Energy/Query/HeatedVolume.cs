using DiGi.Analytical.Building.Classes;
using DiGi.Geometry.Spatial.Classes;
using System.Collections.Generic;

namespace DiGi.Analytical.Building.Energy
{
    public static partial class Query
    {
        /// <summary>
        /// Gets the volume enclosed by the external shell of a building model, the volume V of its single heated zone (DiGi-Organization/DiGi.Analytical#21).
        /// <para>The faces of <see cref="BuildingModel.GetExternalShell(Geometry.Core.Enums.Side?, Geometry.Core.Enums.Orientation?, Geometry.Core.Enums.Orientation?, double)"/> with outward normals give V = Σ A_f·(n_f · (p_f − c)) / 3 by the divergence theorem, exact for planar faces; c is the centre of the shell's bounding box. A reference point inside the shell keeps the large map coordinates of a GIS model from costing anything and limits what a residual can cost to the shell's own extent (DiGi-Organization/DiGi.Analytical#22), where c used to be the plane origin of the first face - (0, 0, elevation) for a footprint extruded by <c>Create.Plane(z)</c>, about 800 km from the building, which levered the residual of a slightly open shell into a volume a hundredfold too large.</para>
        /// <para>The theorem holds only for a closed shell. A closed shell's area-weighted normals sum to zero, so a shell whose |Σ A_f·n_f| exceeds 1 % of its area is open and the volume is not known; a shell inside that screen is still rejected when its residual could move the result by more than 1 % of it, |Σ A_f·n_f| times half the bounding-box diagonal over 3 (DiGi-Organization/DiGi.Analytical#22). One GIS model in six has an open shell (a storey split leaving a T-junction, adjacent CityGML parts); the caller then falls back to a volume of its own and records it.</para>
        /// </summary>
        /// <param name="buildingModel">The building model. This value can be null.</param>
        /// <param name="tolerance">The distance tolerance of the external shell.</param>
        /// <returns>The volume [m3], or <see cref="double.NaN"/> when the model is null, has no shell or the shell is open or encloses no volume.</returns>
        public static double HeatedVolume(this BuildingModel? buildingModel, double tolerance = Core.Constants.Tolerance.Distance)
        {
            DiGi.Analytical.Classes.Shell? shell = buildingModel?.GetExternalShell(Geometry.Core.Enums.Side.External, tolerance: tolerance);
            List<DiGi.Analytical.Classes.Face>? faces = shell?.PolygonalFaces;
            if (shell is null || faces is null || faces.Count < 4)
            {
                return double.NaN;
            }

            BoundingBox3D? boundingBox3D = shell.GetBoundingBox();
            if (boundingBox3D is null)
            {
                return double.NaN;
            }

            Point3D point3D_Min = boundingBox3D.Min;
            Point3D point3D_Max = boundingBox3D.Max;

            // The reference point is the centre of the shell, never a plane origin: a footprint extruded by Create.Plane(z) carries its plane at the map origin, and a reference point out there turns the residual of a slightly open shell into the volume of the map (DiGi-Organization/DiGi.Analytical#22).
            Point3D point3D_Reference = new((point3D_Min.X + point3D_Max.X) / 2.0, (point3D_Min.Y + point3D_Max.Y) / 2.0, (point3D_Min.Z + point3D_Max.Z) / 2.0);

            double length_X = point3D_Max.X - point3D_Min.X;
            double length_Y = point3D_Max.Y - point3D_Min.Y;
            double length_Z = point3D_Max.Z - point3D_Min.Z;
            double halfDiagonal = 0.5 * System.Math.Sqrt((length_X * length_X) + (length_Y * length_Y) + (length_Z * length_Z));

            double area_Total = 0.0;
            double x = 0.0;
            double y = 0.0;
            double z = 0.0;
            double result = 0.0;
            foreach (DiGi.Analytical.Classes.Face face in faces)
            {
                Plane? plane = face.Plane;
                if (plane?.Normal?.Unit is not Vector3D vector3D_Normal || plane.Origin is not Point3D point3D_Origin)
                {
                    return double.NaN;
                }

                double area = face.GetArea();
                if (double.IsNaN(area))
                {
                    return double.NaN;
                }

                area_Total += area;
                x += area * vector3D_Normal.X;
                y += area * vector3D_Normal.Y;
                z += area * vector3D_Normal.Z;

                result += area * ((vector3D_Normal.X * (point3D_Origin.X - point3D_Reference.X)) + (vector3D_Normal.Y * (point3D_Origin.Y - point3D_Reference.Y)) + (vector3D_Normal.Z * (point3D_Origin.Z - point3D_Reference.Z))) / 3.0;
            }

            double residual = System.Math.Sqrt((x * x) + (y * y) + (z * z));
            if (area_Total <= 0 || result <= 0 || residual > 0.01 * area_Total)
            {
                return double.NaN;
            }

            // With the reference point at the centre, a residual can move the result by at most |sum| times the distance to the farthest face, so a shell whose residual could cost more than 1 % of the volume is as unknown as one past the area screen (DiGi-Organization/DiGi.Analytical#22).
            if ((residual * halfDiagonal) / 3.0 > 0.01 * result)
            {
                return double.NaN;
            }

            return result;
        }
    }
}
