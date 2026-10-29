using DiGi.Geometry.Planar;
using DiGi.Geometry.Planar.Classes;
using DiGi.Geometry.Planar.Interfaces;
using System.Collections.Generic;

namespace DiGi.Analytical.Building
{
    public static partial class Create
    {
        /// <summary>
        /// Creates the outline of a window or door construction: a face whose holes are the glazing panes and whose remainder is the frame (DiGi-Organization/DiGi.Analytical#8).
        /// <para>Every pane must lie inside the outline, and no two panes may touch, cross or contain each other: between two panes there is always frame. <see cref="Geometry.Planar.Create.PolygonalFace2D(IPolygonal2D?, IEnumerable{IPolygonal2D}?, double)"/> silently drops a hole that is outside the outline or inside another hole, which would leave a frame with the wrong area; this factory returns <see langword="null"/> instead.</para>
        /// </summary>
        /// <param name="outline">The outline of the structural opening, in the local 2D coordinates of the opening. This value can be null.</param>
        /// <param name="panes">The outlines of the glazing panes, or null or empty for a construction without glazing (an opaque door).</param>
        /// <param name="tolerance">The distance tolerance.</param>
        /// <returns>The <see cref="PolygonalFace2D"/>, or <see langword="null"/> when the outline is null or a pane is not inside it or overlaps another pane.</returns>
        public static PolygonalFace2D? OpeningPolygonalFace2D(IPolygonal2D? outline, IEnumerable<IPolygonal2D>? panes = null, double tolerance = Core.Constants.Tolerance.Distance)
        {
            if (outline is null)
            {
                return null;
            }

            List<IPolygonal2D> panes_Valid = [];
            if (panes is not null)
            {
                foreach (IPolygonal2D pane in panes)
                {
                    if (pane is null)
                    {
                        continue;
                    }

                    if (!outline.Inside(pane, tolerance))
                    {
                        return null;
                    }

                    foreach (IPolygonal2D pane_Valid in panes_Valid)
                    {
                        if (pane_Valid.Inside(pane, tolerance) || pane.Inside(pane_Valid, tolerance) || pane_Valid.Intersect(pane, tolerance))
                        {
                            return null;
                        }
                    }

                    panes_Valid.Add(pane);
                }
            }

            PolygonalFace2D? result = Geometry.Planar.Create.PolygonalFace2D(outline, panes_Valid.Count == 0 ? null : panes_Valid, tolerance);
            if (result is null || (result.InternalEdges?.Count ?? 0) != panes_Valid.Count)
            {
                return null;
            }

            return result;
        }
    }
}
