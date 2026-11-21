namespace DiGi.Analytical.Building.Energy.Constants
{
    /// <summary>
    /// The defaults of the monthly heat demand (DiGi-Organization/DiGi.Analytical#21). Each value names its source (<see cref="Source"/>); a value marked <c>DEFAULT</c> is a decided default with no cited source, to be calibrated.
    /// </summary>
    public static class Default
    {
        /// <summary>
        /// The version of the <see cref="Enums.HeatDemandMethod.Monthly"/> method, the revision stored results of that method are keyed by together with the method (<c>building_data.heat_demand_method_version</c>). Bump it whenever the monthly method, a default or an input rule changes, so that results of an older version are recomputed. It counts revisions within the monthly method only: another method is another <see cref="Enums.HeatDemandMethod"/> member with its own version constant, starting at 1 (DiGi-Organization/DiGi.Analytical#23).
        /// </summary>
        public const int HeatDemandMethodVersion = 1;

        /// <summary>
        /// The dimensionless reference numerical parameter of the gain utilisation factor for heating, a_H,0 = 1.0 for the monthly method (<see cref="Source.GainUtilisation"/>, Table 9).
        /// </summary>
        public const double UtilisationNumericalParameter = 1.0;

        /// <summary>
        /// The reference time constant of the gain utilisation factor for heating, τ_H,0 = 15 h for the monthly method (<see cref="Source.GainUtilisation"/>, Table 9).
        /// </summary>
        public const double UtilisationReferenceTimeConstant = 15.0;

        /// <summary>
        /// The thermal conductivity of the ground, λ_g = 2.0 W/(mK): sand or gravel, the value PN-EN ISO 13370 uses when the soil is not known (<see cref="Source.Ground"/>).
        /// </summary>
        public const double GroundThermalConductivity = 2.0;

        /// <summary>
        /// The thickness of the external walls, w = 0.30 m, used in the equivalent thickness of a ground floor when no external wall has layers. <c>DEFAULT</c>.
        /// </summary>
        public const double GroundWallThickness = 0.30;

        /// <summary>
        /// The absorption coefficient for solar radiation of opaque external surfaces, α = 0.6: a medium colour. The source gives no default ("from appropriate national sources", <see cref="Source.SolarOpaque"/>). <c>DEFAULT</c>.
        /// </summary>
        public const double OpaqueSolarAbsorptance = 0.6;

        /// <summary>
        /// The emissivity for thermal radiation of external surfaces, ε = 0.9, which gives h_r = 5·ε = 4.5 W/(m2K) (<see cref="Source.SkyRadiation"/>). <c>DEFAULT</c> for ε.
        /// </summary>
        public const double ExternalEmissivity = 0.9;

        /// <summary>
        /// The average difference between the external air temperature and the apparent sky temperature, Δθ_er = 11 K, the value for intermediate climatic zones (<see cref="Source.SkyRadiation"/>).
        /// </summary>
        public const double SkyTemperatureDifference = 11.0;

        /// <summary>
        /// The form factor between an unshaded vertical wall and the sky, F_r = 0.5 (<see cref="Source.SkyRadiation"/>).
        /// </summary>
        public const double WallSkyFormFactor = 0.5;

        /// <summary>
        /// The form factor between an unshaded horizontal roof and the sky, F_r = 1.0 (<see cref="Source.SkyRadiation"/>). It is applied to every roof, pitched or flat.
        /// </summary>
        public const double RoofSkyFormFactor = 1.0;

        /// <summary>
        /// The correction of the glazing's solar transmittance at normal incidence for non-perpendicular incidence, F_w = 0.90, used when the typology data gives none (<see cref="Source.SolarGlazed"/>, Eq. (48)).
        /// </summary>
        public const double NonPerpendicularIncidenceFactor = 0.9;

        /// <summary>
        /// The thermal bridging surcharge ΔU_tb = 0.10 W/(m2K), the middle of TABULA's 0.05-0.15 range, used when the typology data gives none. <c>DEFAULT</c>.
        /// </summary>
        public const double ThermalBridgingSurcharge = 0.10;

        /// <summary>
        /// The frame area fraction F_f = 0.30, the glazed area of an opening whose construction has no panes being (1 − F_f)·A_w, used when the typology data gives none: the fixed value the source names for heating-dominated climates (<see cref="Source.SolarGlazed"/>, 11.4.5) and TABULA's value.
        /// </summary>
        public const double FrameAreaFraction = 0.30;

        /// <summary>
        /// The maximum thickness, from each face, counted in the internal heat capacity of a building element, 0.10 m for a one-day period of variation (<see cref="Source.InternalHeatCapacity"/>, Table 11).
        /// </summary>
        public const double InternalHeatCapacityMaximumThickness = 0.10;

        /// <summary>
        /// The thermal conductivity, in W/(mK), at or below which a layer is an insulating layer that ends the effective thickness of the internal heat capacity (PN-EN ISO 13786 Annex A). <c>DEFAULT</c>.
        /// </summary>
        public const double InsulationThermalConductivity = 0.10;

        /// <summary>
        /// The heat capacity of air per volume, ρ_a·c_a = 1200 J/(m3K) (<see cref="Source.Ventilation"/>).
        /// </summary>
        public const double AirHeatCapacity = 1200.0;

        /// <summary>
        /// The correction factor f_g1 = 1.45 of the annual variation of the outdoor temperature in the ground heat loss of the design heat load (<see cref="Source.DesignHeatLoad"/>).
        /// </summary>
        public const double GroundTemperatureVariationFactor = 1.45;

        /// <summary>
        /// The height, in m, within which a floor carried by the external shell counts as standing at the lowest level of the building and so as a floor on the ground. <c>DEFAULT</c>.
        /// </summary>
        public const double LevelTolerance = 0.1;
    }
}
