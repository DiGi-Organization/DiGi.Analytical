using DiGi.Core.Interfaces;

namespace DiGi.Analytical.Building.Regulation.Interfaces
{
    /// <summary>
    /// Base interface for the serializable regulation objects (DiGi-Organization/DiGi.Analytical#8).
    /// </summary>
    public interface IRegulationSerializableObject : IRegulationObject, ISerializableObject
    {
    }
}
