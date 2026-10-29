namespace DiGi.Analytical.Building.Regulation
{
    public static partial class Query
    {
        /// <summary>
        /// Determines the TABULA / NAPE construction period of a building from its year built (DiGi-Organization/DiGi.Analytical#8).
        /// <para>The periods are of construction, so - unlike <see cref="BuildingRegulation(short?, int)"/> - no design lag applies.</para>
        /// </summary>
        /// <param name="year">The year built. This value can be null.</param>
        /// <returns>The construction period, or <see cref="Enums.ConstructionPeriod.Undefined"/> when <paramref name="year"/> is null.</returns>
        public static Enums.ConstructionPeriod ConstructionPeriod(short? year)
        {
            if (year is null)
            {
                return Enums.ConstructionPeriod.Undefined;
            }

            short year_Value = year.Value;

            if (year_Value <= 1945)
            {
                return Enums.ConstructionPeriod.Until1945;
            }

            if (year_Value <= 1966)
            {
                return Enums.ConstructionPeriod.From1946To1966;
            }

            if (year_Value <= 1985)
            {
                return Enums.ConstructionPeriod.From1967To1985;
            }

            if (year_Value <= 1992)
            {
                return Enums.ConstructionPeriod.From1986To1992;
            }

            if (year_Value <= 2002)
            {
                return Enums.ConstructionPeriod.From1993To2002;
            }

            if (year_Value <= 2008)
            {
                return Enums.ConstructionPeriod.From2003To2008;
            }

            return Enums.ConstructionPeriod.From2009;
        }
    }
}
