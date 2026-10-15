using DiGi.Analytical.Building.Interfaces;
using DiGi.Geometry.Spatial.Classes;
using System.Text.Json.Nodes;

namespace DiGi.Analytical.Building.Classes
{
    /// <summary>
    /// Represents a door hosted on a physical component of a building. Its outline is defined by the assigned <see cref="IDoorConstruction"/>.
    /// </summary>
    public class Door : Opening, IDoor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Door"/> class with the specified placement plane.
        /// </summary>
        /// <param name="plane">The placement plane of the door. The provided plane is cloned if it is not null.</param>
        public Door(Plane? plane)
            : base(plane)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Door"/> class with the specified unique identifier and placement plane.
        /// </summary>
        /// <param name="guid">The unique identifier for the door.</param>
        /// <param name="plane">The placement plane of the door. The provided plane is cloned if it is not null.</param>
        public Door(System.Guid guid, Plane? plane)
            : base(guid, plane)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Door"/> class by copying an existing door.
        /// </summary>
        /// <param name="door">The source <see cref="Door"/> to copy from.</param>
        public Door(Door? door)
            : base(door)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Door"/> class with the specified unique identifier by copying an existing door.
        /// </summary>
        /// <param name="guid">The unique identifier for the door.</param>
        /// <param name="door">The source <see cref="Door"/> to copy from.</param>
        public Door(System.Guid guid, Door? door)
            : base(guid, door)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Door"/> class from the specified JSON object.
        /// </summary>
        /// <param name="jsonObject">The <see cref="JsonObject"/> containing the data used to initialize this instance.</param>
        public Door(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }
    }
}
