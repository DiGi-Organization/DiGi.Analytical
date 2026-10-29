using DiGi.Analytical.Building.Enums;
using DiGi.Analytical.Building.Interfaces;
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
        /// Creates the 3D surfaces of a part of the specified opening by mapping the 2D outline of its construction onto the placement plane of the opening (DiGi-Organization/DiGi.Analytical#8).
        /// <para>The outline of a window or door construction is a face whose holes are the glazing and whose remainder is the frame. <see cref="OpeningConstructionPart.Frame"/> returns that face with its holes, <see cref="OpeningConstructionPart.Pane"/> one face per hole, and <see cref="OpeningConstructionPart.Undefined"/> the whole outline (<see cref="Surface3D(IOpening?, IOpeningConstruction?)"/>). An outline without holes has no glazing: its frame is the whole outline and it has no panes.</para>
        /// </summary>
        /// <param name="opening">The opening providing the placement plane. This value can be null.</param>
        /// <param name="openingConstruction">The opening construction providing the 2D outline. This value can be null.</param>
        /// <param name="openingConstructionPart">The part of the opening whose surfaces are created.</param>
        /// <returns>The <see cref="ISurface3D"/>s of the part (empty when the part has none), or null if either argument is null, has no geometry, or the outline cannot be mapped onto a 3D surface.</returns>
        public static List<ISurface3D>? Surface3Ds(this IOpening? opening, IOpeningConstruction? openingConstruction, OpeningConstructionPart openingConstructionPart)
        {
            if (opening?.Geometry is not Plane plane)
            {
                return null;
            }

            if (openingConstructionPart == OpeningConstructionPart.Undefined)
            {
                ISurface3D? surface3D = Surface3D(opening, openingConstruction);
                return surface3D is null ? null : [surface3D];
            }

            if (openingConstruction is not IBuildingGeometryObject<ISurface2D> { Geometry: ISurface2D surface2D })
            {
                return null;
            }

            List<IPolygonal2D>? internalEdges = (surface2D as IPolygonalFace2D)?.InternalEdges;

            if (openingConstructionPart == OpeningConstructionPart.Frame)
            {
                return plane.Convert(surface2D) is ISurface3D surface3D_Frame ? [surface3D_Frame] : null;
            }

            List<ISurface3D> result = [];
            if (internalEdges is null)
            {
                return result;
            }

            foreach (IPolygonal2D internalEdge in internalEdges)
            {
                PolygonalFace2D? polygonalFace2D_Pane = Geometry.Planar.Create.PolygonalFace2D(internalEdge);
                if (polygonalFace2D_Pane is not null && plane.Convert(polygonalFace2D_Pane) is ISurface3D surface3D_Pane)
                {
                    result.Add(surface3D_Pane);
                }
            }

            return result;
        }
    }
}
