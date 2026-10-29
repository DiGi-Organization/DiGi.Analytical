namespace DiGi.Analytical.Building.Regulation
{
    public static partial class Query
    {
        /// <summary>
        /// Determines the building regulation regime a building was designed under, from its year built (DiGi-Organization/DiGi.Analytical#8).
        /// <para>The year built is a completion year, so the regime is selected for <paramref name="year"/> − <paramref name="designLag"/>. By design year: before 1928 <see cref="Enums.BuildingRegulation.PL_Before1928"/>; 1928-1960 <see cref="Enums.BuildingRegulation.PL_1928"/>; 1961-1979 <see cref="Enums.BuildingRegulation.PL_1961"/>; 1980-1994 <see cref="Enums.BuildingRegulation.PL_1980"/>; 1995-2002 <see cref="Enums.BuildingRegulation.PL_1994"/>; 2003-2008 <see cref="Enums.BuildingRegulation.PL_WT2002"/>; 2009-2013 <see cref="Enums.BuildingRegulation.PL_WT2009"/>; 2014-2016 <see cref="Enums.BuildingRegulation.PL_WT2014"/>; 2017-2020 <see cref="Enums.BuildingRegulation.PL_WT2017"/>; from 2021 <see cref="Enums.BuildingRegulation.PL_WT2021"/>. A regime that started within a year (WT 2002 on 16 December 2002, the last stage on 31 December 2020) is assigned from the following year.</para>
        /// </summary>
        /// <param name="year">The year built. This value can be null.</param>
        /// <param name="designLag">The number of years between design and completion.</param>
        /// <returns>The regime, or <see cref="Enums.BuildingRegulation.Undefined"/> when <paramref name="year"/> is null.</returns>
        public static Enums.BuildingRegulation BuildingRegulation(short? year, int designLag = 2)
        {
            if (year is null)
            {
                return Enums.BuildingRegulation.Undefined;
            }

            int year_Design = year.Value - designLag;

            if (year_Design < 1928)
            {
                return Enums.BuildingRegulation.PL_Before1928;
            }

            if (year_Design < 1961)
            {
                return Enums.BuildingRegulation.PL_1928;
            }

            if (year_Design < 1980)
            {
                return Enums.BuildingRegulation.PL_1961;
            }

            if (year_Design < 1995)
            {
                return Enums.BuildingRegulation.PL_1980;
            }

            if (year_Design < 2003)
            {
                return Enums.BuildingRegulation.PL_1994;
            }

            if (year_Design < 2009)
            {
                return Enums.BuildingRegulation.PL_WT2002;
            }

            if (year_Design < 2014)
            {
                return Enums.BuildingRegulation.PL_WT2009;
            }

            if (year_Design < 2017)
            {
                return Enums.BuildingRegulation.PL_WT2014;
            }

            if (year_Design < 2021)
            {
                return Enums.BuildingRegulation.PL_WT2017;
            }

            return Enums.BuildingRegulation.PL_WT2021;
        }
    }
}
