using DiGi.Analytical.Building.Regulation.Classes;
using DiGi.Geometry.Planar.Classes;
using System.Collections.Generic;

namespace DiGi.Analytical.Building.Regulation
{
    public static partial class Create
    {
        /// <summary>
        /// Creates the door construction of an opening size: its frame outline, with the panes of <see cref="Query.Panes(OpeningSize?)"/> as holes when the door is glazed and as a plain outline when it is opaque (DiGi-Organization/DiGi.GIS.Analytical#6).
        /// <para>The construction has the geometry only. The thermal values are those of the door construction of the building's construction set, which the caller copies onto it.</para>
        /// </summary>
        /// <param name="openingSize">The opening size.</param>
        /// <param name="name">The name of the construction; null gives <see cref="Query.ConstructionName(OpeningSize?)"/>.</param>
        /// <param name="tolerance">The distance tolerance.</param>
        /// <returns>The <see cref="Building.Classes.DoorConstruction"/>, or null when <paramref name="openingSize"/> is null or its outline and panes do not make a valid face.</returns>
        public static Building.Classes.DoorConstruction? DoorConstruction(this OpeningSize? openingSize, string? name = null, double tolerance = Core.Constants.Tolerance.Distance)
        {
            if (openingSize is null || !(openingSize.Width > 0) || !(openingSize.Height > 0))
            {
                return null;
            }

            Polygon2D outline = new([new Point2D(0, 0), new Point2D(openingSize.Width, 0), new Point2D(openingSize.Width, openingSize.Height), new Point2D(0, openingSize.Height)]);
            List<Polygon2D>? panes = Query.Panes(openingSize);

            return Building.Create.DoorConstruction(name ?? Query.ConstructionName(openingSize), outline, panes is null || panes.Count == 0 ? null : panes, tolerance);
        }
    }
}
