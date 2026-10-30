using System.ComponentModel;

namespace DiGi.Analytical.Building.Regulation.Enums
{
    /// <summary>
    /// Specifies the kind of a window or door of an opening size set (DiGi-Organization/DiGi.GIS.Analytical#6).
    /// <para>Finer than <see cref="ConstructionRole"/>: a staircase window has its own size but the construction of a window, which <see cref="Query.OpeningConstructionRole(OpeningKind)"/> maps it to.</para>
    /// </summary>
    [Description("Opening kind")]
    public enum OpeningKind
    {
        /// <summary>
        /// Undefined opening kind.
        /// </summary>
        [Description("Undefined")] Undefined,

        /// <summary>
        /// Window of a room, with a sill.
        /// </summary>
        [Description("Window")] Window,

        /// <summary>
        /// Window of a staircase, usually between storeys.
        /// </summary>
        [Description("Staircase window")] StaircaseWindow,

        /// <summary>
        /// Balcony or loggia door: door-sized and reaching the floor, but glazed and under the window limits, so no sill rule applies.
        /// </summary>
        [Description("Balcony door")] BalconyDoor,

        /// <summary>
        /// Roof window.
        /// </summary>
        [Description("Roof window")] RoofWindow,

        /// <summary>
        /// Entrance door of a single-family or terraced house.
        /// </summary>
        [Description("Entrance door")] EntranceDoor,

        /// <summary>
        /// Entrance door of the staircase of a multi-family building, usually two leaves.
        /// </summary>
        [Description("Staircase entrance door")] StaircaseEntranceDoor,

        /// <summary>
        /// Door to an unheated space (cellar, garage, attic).
        /// </summary>
        [Description("Door to unheated space")] DoorToUnheatedSpace,

        /// <summary>
        /// Garage door.
        /// </summary>
        [Description("Garage door")] GarageDoor,
    }
}
