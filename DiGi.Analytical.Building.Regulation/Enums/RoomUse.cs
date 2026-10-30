using System.ComponentModel;

namespace DiGi.Analytical.Building.Regulation.Enums
{
    /// <summary>
    /// Specifies the use of the room an opening of an opening size set serves (DiGi-Organization/DiGi.GIS.Analytical#6).
    /// </summary>
    [Description("Room use")]
    public enum RoomUse
    {
        /// <summary>
        /// Undefined room use.
        /// </summary>
        [Description("Undefined")] Undefined,

        /// <summary>
        /// Living room or bedroom: a room for the permanent stay of people.
        /// </summary>
        [Description("Living room")] LivingRoom,

        /// <summary>
        /// Kitchen.
        /// </summary>
        [Description("Kitchen")] Kitchen,

        /// <summary>
        /// Bathroom or WC.
        /// </summary>
        [Description("Bathroom")] Bathroom,

        /// <summary>
        /// Staircase.
        /// </summary>
        [Description("Staircase")] Staircase,

        /// <summary>
        /// Any other room, and the fallback of a lookup by room use.
        /// </summary>
        [Description("Other")] Other,
    }
}
