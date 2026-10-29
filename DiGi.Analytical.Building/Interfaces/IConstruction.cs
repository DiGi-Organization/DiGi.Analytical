using DiGi.Core.Parameter.Interfaces;

namespace DiGi.Analytical.Building.Interfaces
{
    /// <summary>
    /// Interface for building constructions that combine GUID identification, naming, and description.
    /// <para>A construction carries parameters - the declared thermal values of <see cref="Enums.OpeningConstructionParameter"/> and <see cref="Enums.PhysicalComponentConstructionParameter"/> among them (DiGi-Organization/DiGi.Analytical#8).</para>
    /// </summary>
    public interface IConstruction : IBuildingGuidObject, IBuildingNamedObject, IBuildingDescribableObject, IParametrizedObject
    {
    }

    /// <summary>
    /// Interface for building constructions associated with a specific constructable type.
    /// </summary>
    /// <typeparam name="TConstructable">The type of the constructable element.</typeparam>
    public interface IConstruction<TConstructable> : IConstruction where TConstructable : IConstructable
    {
    }
}