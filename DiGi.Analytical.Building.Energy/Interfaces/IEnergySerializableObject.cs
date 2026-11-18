using DiGi.Core.Interfaces;

namespace DiGi.Analytical.Building.Energy.Interfaces
{
    /// <summary>
    /// Base interface for the serializable objects of the building energy calculation (DiGi-Organization/DiGi.Analytical#21).
    /// </summary>
    public interface IEnergySerializableObject : IEnergyObject, ISerializableObject
    {
    }
}
