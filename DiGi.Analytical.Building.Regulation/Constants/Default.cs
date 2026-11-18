namespace DiGi.Analytical.Building.Regulation.Constants
{
    /// <summary>
    /// Defaults of the construction-role rules of the regulation library.
    /// </summary>
    public static class Default
    {
        /// <summary>
        /// The tilt, in degrees, of a roof's external-shell face against the world up axis below which the roof takes <see cref="Enums.ConstructionRole.FlatRoof"/> (<see cref="Query.ConstructionRoles(DiGi.Analytical.Building.Classes.BuildingModel?, Enums.FloorBoundary, double)"/>): 5°, the flat threshold of <c>DiGi.GIS.PostgreSQL.Modify.Update_ExternalComponentsArea</c>.
        /// </summary>
        public const double FlatRoofTilt = 5.0;
    }
}
