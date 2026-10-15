using DiGi.Analytical.Building.Interfaces;
using DiGi.Geometry.Spatial.Classes;
using System.Text.Json.Nodes;

namespace DiGi.Analytical.Building.Classes
{
    /// <summary>
    /// Represents a window hosted on a physical component of a building. Its outline is defined by the assigned <see cref="IWindowConstruction"/>.
    /// </summary>
    public class Window : Opening, IWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Window"/> class with the specified placement plane.
        /// </summary>
        /// <param name="plane">The placement plane of the window. The provided plane is cloned if it is not null.</param>
        public Window(Plane? plane)
            : base(plane)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Window"/> class with the specified unique identifier and placement plane.
        /// </summary>
        /// <param name="guid">The unique identifier for the window.</param>
        /// <param name="plane">The placement plane of the window. The provided plane is cloned if it is not null.</param>
        public Window(System.Guid guid, Plane? plane)
            : base(guid, plane)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Window"/> class by copying an existing window.
        /// </summary>
        /// <param name="window">The source <see cref="Window"/> to copy from.</param>
        public Window(Window? window)
            : base(window)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Window"/> class with the specified unique identifier by copying an existing window.
        /// </summary>
        /// <param name="guid">The unique identifier for the window.</param>
        /// <param name="window">The source <see cref="Window"/> to copy from.</param>
        public Window(System.Guid guid, Window? window)
            : base(guid, window)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Window"/> class from the specified JSON object.
        /// </summary>
        /// <param name="jsonObject">The <see cref="JsonObject"/> containing the data used to initialize this instance.</param>
        public Window(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }
    }
}
