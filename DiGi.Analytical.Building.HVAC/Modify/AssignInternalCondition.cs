using DiGi.Analytical.Building.Classes;
using DiGi.Analytical.Building.Interfaces;
using System.Collections.Generic;

namespace DiGi.Analytical.Building.HVAC
{
    public static partial class Modify
    {
        /// <summary>
        /// Assigns an internal condition to every space of a building model, over the hours of its longest profile, as <see cref="Assign(BuildingModel?, ISpace?, IInternalCondition?, string?)"/> does for one space (DiGi-Organization/DiGi.Analytical#9).
        /// </summary>
        /// <param name="buildingModel">The building model.</param>
        /// <param name="internalCondition">The internal condition, for example from <see cref="Create.InternalCondition(Classes.UsageProfile?, int?, double?, double?, string?)"/>.</param>
        /// <param name="id">An optional identifier shared by every relation created, which the HVAC IndexedDoubles query filters by.</param>
        /// <returns>True when the model has spaces and every one was assigned; otherwise, false.</returns>
        public static bool AssignInternalCondition(this BuildingModel? buildingModel, IInternalCondition? internalCondition, string? id = null)
        {
            if (buildingModel is null || internalCondition is null)
            {
                return false;
            }

            List<ISpace>? spaces = buildingModel.GetSpaces<ISpace>();
            if (spaces is null || spaces.Count == 0)
            {
                return false;
            }

            bool result = true;
            foreach (ISpace space in spaces)
            {
                if (!buildingModel.Assign(space, internalCondition, id))
                {
                    result = false;
                }
            }

            return result;
        }
    }
}
