using DiGi.Analytical.Building.Classes;
using DiGi.Analytical.Building.Interfaces;
using DiGi.Geometry.Planar.Interfaces;
using DiGi.Geometry.Spatial;
using DiGi.Geometry.Spatial.Classes;
using DiGi.Geometry.Spatial.Interfaces;

namespace DiGi.Analytical.Building
{
    public static partial class Query
    {
        /// <summary>
        /// Extracts the 3D surface representation of the specified building component.
        /// <para>Surface based components (e.g. <see cref="SurfaceRoof"/>, <see cref="SurfaceWall"/>) return their geometry directly, face based components (e.g. <see cref="FaceFloor"/>) return their planar face and curve based walls (e.g. <see cref="CurveWall"/>) return the surface created by extruding the base curve by the wall vector.</para>
        /// </summary>
        /// <param name="component">The building component. This value can be null.</param>
        /// <returns>The <see cref="ISurface3D"/> representing the component, or null if the component has no supported surface geometry.</returns>
        public static ISurface3D? Surface3D(this IComponent? component)
        {
            if (component is IBuildingGeometryObject<ISurface3D> buildingGeometryObject_Surface3D)
            {
                return buildingGeometryObject_Surface3D.Geometry;
            }

            if (component is IBuildingGeometryObject<IFace3D> buildingGeometryObject_Face3D)
            {
                return buildingGeometryObject_Face3D.Geometry;
            }

            if (component is CurveWall<ICurve3D> curveWall)
            {
                return curveWall.GetSurface3D();
            }

            return null;
        }

        /// <summary>
        /// Creates the 3D outline of the specified opening by mapping the 2D outline of its construction onto the placement plane of the opening.
        /// <para>The outline (<see cref="IGeometry2DConstruction{TConstructable, TGeometry2D}.Geometry"/> of the construction) is expressed in the local 2D coordinates of the opening's <see cref="Plane"/>, whose origin is the insertion point of the opening.</para>
        /// </summary>
        /// <param name="opening">The opening providing the placement plane. This value can be null.</param>
        /// <param name="openingConstruction">The opening construction providing the 2D outline. This value can be null.</param>
        /// <returns>The <see cref="ISurface3D"/> outline of the opening, or null if either argument is null, has no geometry, or the outline cannot be mapped onto a 3D surface.</returns>
        public static ISurface3D? Surface3D(this IOpening? opening, IOpeningConstruction? openingConstruction)
        {
            if (opening?.Geometry is not Plane plane)
            {
                return null;
            }

            if (openingConstruction is not IBuildingGeometryObject<ISurface2D> buildingGeometryObject_Surface2D)
            {
                return null;
            }

            ISurface2D? surface2D = buildingGeometryObject_Surface2D.Geometry;
            if (surface2D == null)
            {
                return null;
            }

            return plane.Convert(surface2D) as ISurface3D;
        }
    }
}