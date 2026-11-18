using DiGi.Analytical.Building.Interfaces;
using DiGi.Geometry.Core.Interfaces;

namespace DiGi.Analytical.Building.Energy
{
    public static partial class Query
    {
        /// <summary>
        /// Gets the gross area of a component's face, openings included (DiGi-Organization/DiGi.Analytical#21).
        /// </summary>
        /// <param name="component">The component. This value can be null.</param>
        /// <returns>The area [m2], or <see cref="double.NaN"/> when the component is null or its geometry is not a face.</returns>
        public static double Area(this IComponent? component)
        {
            return Building.Query.Surface3D(component) is IFace face ? face.GetArea() : double.NaN;
        }

        /// <summary>
        /// Gets the area of the whole outline of an opening, frame and glazing together (DiGi-Organization/DiGi.Analytical#21).
        /// </summary>
        /// <param name="opening">The opening. This value can be null.</param>
        /// <param name="openingConstruction">The construction giving the opening its outline. This value can be null.</param>
        /// <returns>The area [m2], or <see cref="double.NaN"/> when either argument is null or the outline cannot be placed.</returns>
        public static double Area(this IOpening? opening, IOpeningConstruction? openingConstruction)
        {
            return Building.Query.Surface3D(opening, openingConstruction) is IFace face ? face.GetArea() : double.NaN;
        }
    }
}
