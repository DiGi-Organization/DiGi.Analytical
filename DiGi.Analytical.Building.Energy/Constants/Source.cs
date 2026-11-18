namespace DiGi.Analytical.Building.Energy.Constants
{
    /// <summary>
    /// The source tags of the monthly heat demand (DiGi-Organization/DiGi.Analytical#21). None of the standards is in hand, so every equation and default is tagged with the public reproduction it was taken from and counts as not checked against the original (wiki <i>Required Standards</i>).
    /// </summary>
    public static class Source
    {
        /// <summary>
        /// The monthly quasi-steady method. ISO/TR 52016-2:2017, 5.2.4 (public preview at sis.se) states that the monthly method of ISO 52016-1 "is basically the same as the monthly method in ISO 13790"; its listed differences (intermittent heating, unconditioned adjacent zones, sunspaces, the free-floating temperature, overheating) are outside a continuously heated single zone. The equations are therefore those of ISO 13790 as reproduced in its approval draft ISO/FDIS 13790:2007 (public copy, ETH Zürich OptiControl literature).
        /// </summary>
        public const string Method = "PN-EN ISO 52016-1 monthly method as reproduced in ISO/FDIS 13790:2007 (via ISO/TR 52016-2:2017, 5.2.4)";

        /// <summary>
        /// The gain utilisation factor, Equations (53) to (57), and the numerical parameter a_H,0 = 1 and reference time constant τ_H,0 = 15 h of the monthly method, Table 9.
        /// </summary>
        public const string GainUtilisation = "PN-EN ISO 52016-1 as reproduced in ISO/FDIS 13790:2007, 12.2.1.1, Eq. (53)-(57), Table 9";

        /// <summary>
        /// The building time constant τ = (C_m / 3600) / (H_tr + H_ve), Equation (63).
        /// </summary>
        public const string TimeConstant = "PN-EN ISO 52016-1 as reproduced in ISO/FDIS 13790:2007, 12.2.1.3, Eq. (63)";

        /// <summary>
        /// The internal heat capacity C_m = Σ κ_j·A_j, Equation (67), κ_j per ISO 13786 Annex A up to 0.10 m, Table 11.
        /// </summary>
        public const string InternalHeatCapacity = "PN-EN ISO 52016-1 as reproduced in ISO/FDIS 13790:2007, 12.3.1.1, Eq. (67), Table 11; κ per PN-EN ISO 13786 Annex A (simplified), from secondary knowledge";

        /// <summary>
        /// The solar gains of glazed elements, Equations (44), (45) and (48): F_w·g_gl,n·(1 − F_f)·A_w·I, with F_w = 0.90 in absence of national values.
        /// </summary>
        public const string SolarGlazed = "PN-EN ISO 52016-1 as reproduced in ISO/FDIS 13790:2007, 11.3.3, Eq. (45), (48)";

        /// <summary>
        /// The solar gains of opaque elements, Equation (46): α·R_se·U·A·I.
        /// </summary>
        public const string SolarOpaque = "PN-EN ISO 52016-1 as reproduced in ISO/FDIS 13790:2007, 11.3.4, Eq. (46)";

        /// <summary>
        /// The extra heat flow by thermal radiation to the sky, Equations (44) and (47): F_r·R_se·U·A·h_r·Δθ_er, subtracted from the solar gains; h_r = 5·ε, Δθ_er = 11 K in intermediate zones, F_r = 1 for a roof and 0.5 for a wall.
        /// </summary>
        public const string SkyRadiation = "PN-EN ISO 52016-1 as reproduced in ISO/FDIS 13790:2007, 11.3.5, 11.4.6, Eq. (44), (47)";

        /// <summary>
        /// Heat transfer through a slab on ground in the steady state.
        /// </summary>
        public const string Ground = "PN-EN ISO 13370 slab on ground (steady state), from secondary knowledge; conventions (λ_g = 2.0 for sand/gravel, R_f without R_si, party walls out of the exposed perimeter) as reproduced in BRE BR 443 (2019), chapter 9";

        /// <summary>
        /// The floor over an unheated cellar, from the TABULA typology data of the building.
        /// </summary>
        public const string Cellar = "TABULA additional floor resistance and temperature reduction factor (TypologyData)";

        /// <summary>
        /// The ventilation heat transfer coefficient H_ve = ρ_a·c_a·(q_ve + n_inf·V / 3600), ρ_a·c_a = 1200 J/(m3K).
        /// </summary>
        public const string Ventilation = "Dz.U. 2015 poz. 376, Annex 1, Eq. (57) (ρ_a·c_a = 1200 J/(m3K)); airflows of the usage profile (DiGi-Organization/DiGi.Analytical#9)";

        /// <summary>
        /// The thermal bridging surcharge ΔU_tb on the area of every heat-loss element.
        /// </summary>
        public const string ThermalBridges = "TABULA ΔU_tb surcharge (TypologyData.ThermalBridgingSurcharge)";

        /// <summary>
        /// The design heat load of PN-EN 12831-1, simplified.
        /// </summary>
        public const string DesignHeatLoad = "PN-EN 12831-1 simplified, from secondary knowledge (f_g1 = 1.45, f_g2 = (θ_int − θ_m,e) / (θ_int − θ_e)); θ_e and θ_m,e per zone as reproduced in Strzeszewski and Wereszczyński (Purmo 2009), Table 2.1";
    }
}
