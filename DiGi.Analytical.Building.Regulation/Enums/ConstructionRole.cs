using System.ComponentModel;

namespace DiGi.Analytical.Building.Regulation.Enums
{
    /// <summary>
    /// Specifies the element a construction of a construction set is used for (DiGi-Organization/DiGi.Analytical#8).
    /// </summary>
    [Description("Construction Role")]
    public enum ConstructionRole
    {
        /// <summary>The role is not known.</summary>
        [Description("Undefined")] Undefined,

        /// <summary>An external wall in contact with outside air.</summary>
        [Description("External wall")] ExternalWall,

        /// <summary>An internal wall within the building.</summary>
        [Description("Internal wall")] InternalWall,

        /// <summary>A wall shared with an adjacent building.</summary>
        [Description("Party wall")] PartyWall,

        /// <summary>A pitched roof, or the ceiling under an unheated attic.</summary>
        [Description("Roof")] Roof,

        /// <summary>A flat roof (stropodach).</summary>
        [Description("Flat roof")] FlatRoof,

        /// <summary>A floor on ground.</summary>
        [Description("Ground floor")] GroundFloor,

        /// <summary>A floor over an unheated basement or a closed underfloor space.</summary>
        [Description("Floor over unheated space")] FloorOverUnheated,

        /// <summary>An intermediate floor between heated storeys.</summary>
        [Description("Intermediate floor")] IntermediateFloor,

        /// <summary>A window in an external wall.</summary>
        [Description("Window")] Window,

        /// <summary>A roof window or skylight.</summary>
        [Description("Roof window")] RoofWindow,

        /// <summary>A balcony door: door-sized, but under the window limits of the regulations.</summary>
        [Description("Balcony door")] BalconyDoor,

        /// <summary>The entrance door of a single-family building.</summary>
        [Description("External door")] ExternalDoor,

        /// <summary>The staircase entrance door of a multi-family building, usually two-leaved and glazed.</summary>
        [Description("Staircase entrance door")] StaircaseEntranceDoor,

        /// <summary>A door between heated and unheated spaces.</summary>
        [Description("Door to unheated space")] DoorToUnheatedSpace,

        /// <summary>A garage door or gate.</summary>
        [Description("Garage door")] GarageDoor,
    }
}
