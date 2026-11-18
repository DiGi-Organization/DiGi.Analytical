using DiGi.Analytical.Building.Classes;
using DiGi.Geometry.Spatial.Classes;
using System.Collections.Generic;

namespace DiGi.Analytical.Building.Energy
{
    public static partial class Query
    {
        /// <summary>
        /// Gets the volume enclosed by the external shell of a building model, the volume V of its single heated zone (DiGi-Organization/DiGi.Analytical#21).
        /// <para>The faces of <see cref="BuildingModel.GetExternalShell(Geometry.Core.Enums.Side?, Geometry.Core.Enums.Orientation?, Geometry.Core.Enums.Orientation?, double)"/> with outward normals give V = Σ A_f·(n_f · (p_f − c)) / 3 by the divergence theorem, exact for planar faces; c is a point of the first face, so the large map coordinates of a GIS model do not cost precision.</para>
        /// <para>The theorem holds only for a closed shell. A closed shell's area-weighted normals sum to zero, so a shell whose |Σ A_f·n_f| exceeds 1 % of its area is open and the volume is not known. One GIS model in six has an open shell (a storey split leaving a T-junction, adjacent CityGML parts); the caller then falls back to a volume of its own and records it.</para>
        /// </summary>
        /// <param name="buildingModel">The building model. This value can be null.</param>
        /// <param name="tolerance">The distance tolerance of the external shell.</param>
        /// <returns>The volume [m3], or <see cref="double.NaN"/> when the model is null, has no shell or the shell is open or encloses no volume.</returns>
        public static double HeatedVolume(this BuildingModel? buildingModel, double tolerance = Core.Constants.Tolerance.Distance)
        {
            List<DiGi.Analytical.Classes.Face>? faces = buildingModel?.GetExternalShell(Geometry.Core.Enums.Side.External, tolerance: tolerance)?.PolygonalFaces;
            if (faces is null || faces.Count < 4)
            {
                return double.NaN;
            }

            Point3D? point3D_Reference = null;
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

                point3D_Reference ??= point3D_Origin;

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

            if (area_Total <= 0 || System.Math.Sqrt((x * x) + (y * y) + (z * z)) > 0.01 * area_Total || result <= 0)
            {
                return double.NaN;
            }

            return result;
        }
    }
}
