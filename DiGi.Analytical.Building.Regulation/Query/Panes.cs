using DiGi.Analytical.Building.Regulation.Classes;
using DiGi.Geometry.Planar.Classes;
using System.Collections.Generic;

namespace DiGi.Analytical.Building.Regulation
{
    public static partial class Query
    {
        /// <summary>
        /// Gets the glazing panes of an opening size, in the local coordinates of its frame outline with (0, 0) at the lower left corner (DiGi-Organization/DiGi.GIS.Analytical#6).
        /// <para>Inside a uniform frame, the sashes or leaves sit side by side with a divider between each two; a top light, when there is one, spans the full inner width above a transom of the divider width. Panes are separated by the frame or a divider of non-zero width, which is what <c>Create.WindowConstruction(name, outline, panes)</c> requires.</para>
        /// </summary>
        /// <param name="openingSize">The opening size.</param>
        /// <returns>The panes from left to right, then the top light, or an empty list when the opening is not glazed or its layout leaves no positive pane; null when <paramref name="openingSize"/> is null.</returns>
        public static List<Polygon2D>? Panes(this OpeningSize? openingSize)
        {
            if (openingSize is null)
            {
                return null;
            }

            List<Polygon2D> result = [];

            int columns = openingSize.Columns;
            double frameWidth = openingSize.FrameWidth;
            double dividerWidth = openingSize.DividerWidth;
            if (!openingSize.Glazed || columns < 1 || frameWidth <= 0 || (columns > 1 && dividerWidth <= 0))
            {
                return result;
            }

            static Polygon2D Rectangle(double minX, double minY, double maxX, double maxY)
            {
                return new Polygon2D([new Point2D(minX, minY), new Point2D(maxX, minY), new Point2D(maxX, maxY), new Point2D(minX, maxY)]);
            }

            double maxX = openingSize.Width - frameWidth;
            double maxY = openingSize.Height - frameWidth;

            double maxY_Sashes = maxY;
            if (openingSize.TopLightHeight is double topLightHeight && topLightHeight > 0)
            {
                if (dividerWidth <= 0)
                {
                    return result;
                }

                maxY_Sashes = maxY - topLightHeight - dividerWidth;
            }

            double width_Sash = (maxX - frameWidth - ((columns - 1) * dividerWidth)) / columns;
            if (width_Sash <= 0 || maxY_Sashes <= frameWidth)
            {
                return result;
            }

            for (int i = 0; i < columns; i++)
            {
                double minX = frameWidth + (i * (width_Sash + dividerWidth));
                result.Add(Rectangle(minX, frameWidth, minX + width_Sash, maxY_Sashes));
            }

            if (maxY_Sashes < maxY)
            {
                result.Add(Rectangle(frameWidth, maxY_Sashes + dividerWidth, maxX, maxY));
            }

            return result;
        }
    }
}
