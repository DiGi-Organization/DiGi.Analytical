using DiGi.Core.Parameter.Classes;
using System.ComponentModel;

namespace DiGi.Analytical.Building.Enums
{
    /// <summary>
    /// Defines the set of parameters associated with a component in the analytical building model.
    /// </summary>
    [AssociatedTypes(typeof(Interfaces.IComponent)), Description("Component parameter")]
    public enum ComponentParameter
    {
        /// <summary>
        /// Represents the identifier of the building model of the adjacent building the component is shared with: the component is a party wall, adiabatic in the heat-loss area and no host for openings (DiGi-Organization/DiGi.GIS.Analytical#4).
        /// <para>Set by <c>Modify.SplitPartyWalls</c> on the shared parts of a wall; not set on a component that is not shared.</para>
        /// </summary>
        [ParameterProperties("c9ee57fa-dcb7-4810-abcb-7ffe5a5ba470", "Party wall", "Identifier of the building model of the adjacent building the component is shared with"), GuidParameterValue()] PartyWall,
    }
}
