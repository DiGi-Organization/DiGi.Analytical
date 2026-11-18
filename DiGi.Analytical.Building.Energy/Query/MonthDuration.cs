namespace DiGi.Analytical.Building.Energy
{
    public static partial class Query
    {
        /// <summary>
        /// Gets the duration t_m of a month of a non-leap year, the length of the monthly balance (DiGi-Organization/DiGi.Analytical#21). The weather years of the solar results are mapped onto a non-leap year as well (8 760 hours).
        /// </summary>
        /// <param name="month">The month, 1 (January) to 12 (December).</param>
        /// <returns>The duration [h], or <see cref="double.NaN"/> for a month outside 1-12.</returns>
        public static double MonthDuration(int month)
        {
            return month switch
            {
                1 or 3 or 5 or 7 or 8 or 10 or 12 => 31 * 24.0,
                4 or 6 or 9 or 11 => 30 * 24.0,
                2 => 28 * 24.0,
                _ => double.NaN,
            };
        }
    }
}
