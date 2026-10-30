using DiGi.Analytical.Building.Regulation.Classes;
using System.Globalization;

namespace DiGi.Analytical.Building.Regulation
{
    public static partial class Query
    {
        /// <summary>
        /// Gets the default name of the window or door construction made from an opening size: the opening kind and the frame outline in millimetres, for example "Window 1465x1435" (DiGi-Organization/DiGi.GIS.Analytical#6).
        /// </summary>
        /// <param name="openingSize">The opening size.</param>
        /// <returns>The name, or null when <paramref name="openingSize"/> is null.</returns>
        public static string? ConstructionName(this OpeningSize? openingSize)
        {
            if (openingSize is null)
            {
                return null;
            }

            static string Millimetres(double value)
            {
                return System.Math.Round(value * 1000.0).ToString("0", CultureInfo.InvariantCulture);
            }

            return openingSize.OpeningKind + " " + Millimetres(openingSize.Width) + "x" + Millimetres(openingSize.Height);
        }
    }
}
