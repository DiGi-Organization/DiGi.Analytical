using DiGi.Analytical.Building.Regulation.Enums;

namespace DiGi.Analytical.Building.Regulation
{
    public static partial class Query
    {
        /// <summary>
        /// Gets the role of the construction an opening of the specified kind takes from a construction set (DiGi-Organization/DiGi.GIS.Analytical#6). A staircase window takes the window construction.
        /// </summary>
        /// <param name="openingKind">The opening kind.</param>
        /// <returns>The <see cref="Enums.ConstructionRole"/>, or <see cref="Enums.ConstructionRole.Undefined"/> for <see cref="OpeningKind.Undefined"/>.</returns>
        public static Enums.ConstructionRole OpeningConstructionRole(this OpeningKind openingKind)
        {
            return openingKind switch
            {
                OpeningKind.Window or OpeningKind.StaircaseWindow => Enums.ConstructionRole.Window,
                OpeningKind.BalconyDoor => Enums.ConstructionRole.BalconyDoor,
                OpeningKind.RoofWindow => Enums.ConstructionRole.RoofWindow,
                OpeningKind.EntranceDoor => Enums.ConstructionRole.ExternalDoor,
                OpeningKind.StaircaseEntranceDoor => Enums.ConstructionRole.StaircaseEntranceDoor,
                OpeningKind.DoorToUnheatedSpace => Enums.ConstructionRole.DoorToUnheatedSpace,
                OpeningKind.GarageDoor => Enums.ConstructionRole.GarageDoor,
                _ => Enums.ConstructionRole.Undefined,
            };
        }
    }
}
