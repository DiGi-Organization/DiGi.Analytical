using System.ComponentModel;

namespace DiGi.Analytical.Building.Regulation.Enums
{
    /// <summary>
    /// Specifies the Polish building regulation regime a building was designed under (DiGi-Organization/DiGi.Analytical#8, moved here from the design of DiGi-Organization/DiGi.GIS.Analytical#2).
    /// <para>The regime decides the geometric and fire rules of a design (daylight, distances, fire separation). The thermal limits change on their own dates, which is why the construction library is keyed by date range, not by this regime.</para>
    /// </summary>
    [Description("Building Regulation")]
    public enum BuildingRegulation
    {
        /// <summary>The regime is not known.</summary>
        [Description("Undefined")] Undefined,

        /// <summary>Partition-era local building codes, before the 1928 regulation.</summary>
        [Description("Before 1928")] PL_Before1928,

        /// <summary>Rozporządzenie Prezydenta RP o prawie budowlanym (Dz.U. 1928 nr 23 poz. 202), in force until 1961.</summary>
        [Description("Building law of 1928")] PL_1928,

        /// <summary>Prawo budowlane of 1961 with its technical regulations.</summary>
        [Description("Building law of 1961")] PL_1961,

        /// <summary>The technical conditions of 1980 (Dz.U. 1980 nr 17 poz. 62).</summary>
        [Description("Technical conditions of 1980")] PL_1980,

        /// <summary>The technical conditions of 1994 (Dz.U. 1995 nr 10 poz. 46), in force from 1 April 1995.</summary>
        [Description("Technical conditions of 1994")] PL_1994,

        /// <summary>The technical conditions of 2002 (Dz.U. 2002 nr 75 poz. 690), in force from 16 December 2002.</summary>
        [Description("Technical conditions of 2002")] PL_WT2002,

        /// <summary>The technical conditions of 2002 as amended in 2008 (Dz.U. 2008 nr 201 poz. 1238), from 1 January 2009.</summary>
        [Description("Technical conditions of 2002, 2009 amendment")] PL_WT2009,

        /// <summary>The 2014 stage of the 2013 amendment (Dz.U. 2013 poz. 926).</summary>
        [Description("Technical conditions of 2002, 2014 stage")] PL_WT2014,

        /// <summary>The 2017 stage of the 2013 amendment (Dz.U. 2013 poz. 926), from 1 January 2017.</summary>
        [Description("Technical conditions of 2002, 2017 stage")] PL_WT2017,

        /// <summary>The last stage (Dz.U. 2017 poz. 2285), from 31 December 2020.</summary>
        [Description("Technical conditions of 2002, 2021 stage")] PL_WT2021,
    }
}
