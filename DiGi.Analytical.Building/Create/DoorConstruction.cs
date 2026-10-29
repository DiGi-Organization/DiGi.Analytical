using DiGi.Geometry.Planar.Classes;
using DiGi.Geometry.Planar.Interfaces;
using System.Collections.Generic;

namespace DiGi.Analytical.Building
{
    public static partial class Create
    {
        /// <summary>
        /// Creates a door construction whose outline is a face with its glazing panes, if any, as holes and the frame and leaf as the remainder (DiGi-Organization/DiGi.Analytical#8).
        /// <para>The outline is validated by <see cref="OpeningPolygonalFace2D(IPolygonal2D?, IEnumerable{IPolygonal2D}?, double)"/>, which is why this factory, not the <see cref="Classes.DoorConstruction"/> constructor, is the way to build one from panes. Without panes the door is opaque.</para>
        /// </summary>
        /// <param name="name">The name of the construction. This value can be null.</param>
        /// <param name="outline">The outline of the structural opening, in the local 2D coordinates of the opening. This value can be null.</param>
        /// <param name="panes">The outlines of the glazing panes, or null or empty for an opaque door.</param>
        /// <param name="tolerance">The distance tolerance.</param>
        /// <returns>The <see cref="Classes.DoorConstruction"/>, or <see langword="null"/> when the outline is null or a pane is not inside it or overlaps another pane.</returns>
        public static Classes.DoorConstruction? DoorConstruction(string? name, IPolygonal2D? outline, IEnumerable<IPolygonal2D>? panes = null, double tolerance = Core.Constants.Tolerance.Distance)
        {
            PolygonalFace2D? polygonalFace2D = OpeningPolygonalFace2D(outline, panes, tolerance);
            if (polygonalFace2D is null)
            {
                return null;
            }

            return new Classes.DoorConstruction(name, polygonalFace2D);
        }
    }
}
