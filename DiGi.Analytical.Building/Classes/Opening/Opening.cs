using DiGi.Analytical.Building.Interfaces;
using DiGi.Geometry.Spatial.Classes;
using System.Text.Json.Nodes;

namespace DiGi.Analytical.Building.Classes
{
    /// <summary>
    /// Represents an abstract base class for openings (windows, doors) hosted on a physical component of a building.
    /// <para>The <see cref="Plane"/> geometry is the placement of the opening: its origin is the insertion point and its axes define the local 2D coordinate system in which the outline of the opening construction (<see cref="IOpeningConstruction"/>) is expressed. Use <see cref="Query.Surface3D(IOpening, IOpeningConstruction)"/> to obtain the 3D outline.</para>
    /// </summary>
    public abstract class Opening : BuildingGeometry3DObject<Plane>, IOpening
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Opening"/> class with the specified placement plane.
        /// </summary>
        /// <param name="plane">The placement plane of the opening. The provided plane is cloned if it is not null.</param>
        public Opening(Plane? plane)
            : base(plane)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Opening"/> class with the specified unique identifier and placement plane.
        /// </summary>
        /// <param name="guid">The unique identifier for the opening.</param>
        /// <param name="plane">The placement plane of the opening. The provided plane is cloned if it is not null.</param>
        public Opening(System.Guid guid, Plane? plane)
            : base(guid, plane)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Opening"/> class by copying an existing opening.
        /// </summary>
        /// <param name="opening">The source <see cref="Opening"/> to copy from.</param>
        public Opening(Opening? opening)
            : base(opening)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Opening"/> class with the specified unique identifier by copying an existing opening.
        /// </summary>
        /// <param name="guid">The unique identifier for the opening.</param>
        /// <param name="opening">The source <see cref="Opening"/> to copy from.</param>
        public Opening(System.Guid guid, Opening? opening)
            : base(guid, opening)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Opening"/> class from the specified JSON object.
        /// </summary>
        /// <param name="jsonObject">The <see cref="JsonObject"/> containing the data used to initialize this instance.</param>
        public Opening(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }
    }
}
