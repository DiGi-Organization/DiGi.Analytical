namespace DiGi.Analytical.Building.Interfaces
{
    /// <summary>
    /// Interface for a single layer within a building structure.
    /// </summary>
    public interface IStructureLayer : IBuildingGuidObject
    {
        /// <summary>
        /// Gets the position index of this layer within the parent structure.
        /// <para>Layers are ordered from the outside inwards: index 0 is the outermost layer (DiGi-Organization/DiGi.Analytical#8).</para>
        /// </summary>
        int Index { get; }

        /// <summary>
        /// Gets the thickness of the structure layer [m].
        /// </summary>
        double Thickness { get; }
    }
}