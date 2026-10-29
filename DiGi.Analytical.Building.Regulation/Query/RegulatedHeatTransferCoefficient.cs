using DiGi.Analytical.Building.HVAC.Classes;
using DiGi.Analytical.Building.HVAC.Enums;
using DiGi.Analytical.Building.HVAC.Interfaces;
using DiGi.Analytical.Building.Regulation.Enums;

namespace DiGi.Analytical.Building.Regulation
{
    public static partial class Query
    {
        /// <summary>
        /// Gets the maximum heat transfer coefficient U(max) a stage of the technical conditions sets for a construction role of a residential building (DiGi-Organization/DiGi.Analytical#8).
        /// <para>A <see cref="BuildingType.SingleFamily"/> or <see cref="BuildingType.Terraced"/> building takes the single-family limits, a <see cref="BuildingType.MultiFamily"/> building or an <see cref="BuildingType.ApartmentBlock"/> the residential or multi-family ones. The 1997 annex has no table for a multi-family building at all, and the 2002 regulation none for its walls, roof and basement ceiling: such a building met the act by its seasonal heat demand indicator E ≤ E0, so no limit is returned.</para>
        /// <para>Until 2013 the window limits depend on the climatic zone (I-III against IV-V), and in 1997 and 2002 the external wall limit on whether the wall is layered with insulation of λ ≤ 0.05 W/(mK) (<paramref name="insulatedLayered"/>). A floor on ground was limited by a minimum thermal resistance until 2008, not by a U(max). Walls and floors inside the building, party walls and garage doors have no limit here.</para>
        /// </summary>
        /// <param name="regulatedHeatTransferCoefficients">The stage of the technical conditions, as returned by the regulated heat transfer coefficients manager. This value can be null.</param>
        /// <param name="constructionRole">The role of the construction.</param>
        /// <param name="buildingType">The building type.</param>
        /// <param name="climateZone">The climatic zone of the building.</param>
        /// <param name="insulatedLayered">True for an external wall layered with insulation of λ ≤ 0.05 W/(mK); only the 1997 and 2002 stages distinguish it.</param>
        /// <returns>The U(max) [W/(m2K)], or <see cref="double.NaN"/> when the stage sets no limit for the role and building, or a required input (zone, building type) is undefined.</returns>
        public static double RegulatedHeatTransferCoefficient(this IRegulatedHeatTransferCoefficients? regulatedHeatTransferCoefficients, ConstructionRole constructionRole, BuildingType buildingType, ClimateZone climateZone, bool insulatedLayered = false)
        {
            if (regulatedHeatTransferCoefficients is null || buildingType == BuildingType.Undefined)
            {
                return double.NaN;
            }

            bool singleFamily = buildingType is BuildingType.SingleFamily or BuildingType.Terraced;
            bool? zoneA = climateZone switch
            {
                ClimateZone.I or ClimateZone.II or ClimateZone.III => true,
                ClimateZone.IV or ClimateZone.V => false,
                _ => null,
            };

            static double Value<TEnum>(RegulatedHeatTransferCoefficients<TEnum> regulatedHeatTransferCoefficients_Temp, TEnum? @enum) where TEnum : struct, System.Enum
            {
                return @enum is TEnum enum_Temp && regulatedHeatTransferCoefficients_Temp.TryGetValue(enum_Temp, out double value) ? value : double.NaN;
            }

            switch (regulatedHeatTransferCoefficients)
            {
                case RegulatedHeatTransferCoefficients_1997 regulatedHeatTransferCoefficients_1997:
                    if (!singleFamily)
                    {
                        return double.NaN;
                    }

                    return Value(regulatedHeatTransferCoefficients_1997, constructionRole switch
                    {
                        ConstructionRole.ExternalWall => insulatedLayered ? ExternalPartitionType_1997.ResidentialBuilding_Wall_Multilayer : ExternalPartitionType_1997.ResidentialBuilding_Wall_Solid,
                        ConstructionRole.Roof or ConstructionRole.FlatRoof => ExternalPartitionType_1997.ResidentialBuilding_Roof,
                        ConstructionRole.FloorOverUnheated => ExternalPartitionType_1997.ResidentialBuilding_Floor_OverUnheatedSpaces,
                        ConstructionRole.Window or ConstructionRole.RoofWindow or ConstructionRole.BalconyDoor when zoneA is bool zoneA_1997 => zoneA_1997 ? ExternalPartitionType_1997.ResidentialBuilding_Window_ZoneA : ExternalPartitionType_1997.ResidentialBuilding_Window_ZoneB,
                        ConstructionRole.ExternalDoor or ConstructionRole.StaircaseEntranceDoor => ExternalPartitionType_1997.ResidentialBuilding_Door,
                        _ => (ExternalPartitionType_1997?)null,
                    });

                case RegulatedHeatTransferCoefficients_2002 regulatedHeatTransferCoefficients_2002:
                    return Value(regulatedHeatTransferCoefficients_2002, constructionRole switch
                    {
                        ConstructionRole.ExternalWall when singleFamily => insulatedLayered ? ExternalPartitionType_2002.ResidentialBuilding_Wall_Multilayer : ExternalPartitionType_2002.ResidentialBuilding_Wall_Solid,
                        ConstructionRole.Roof or ConstructionRole.FlatRoof when singleFamily => ExternalPartitionType_2002.ResidentialBuilding_Roof,
                        ConstructionRole.FloorOverUnheated when singleFamily => ExternalPartitionType_2002.ResidentialBuilding_Floor_OverUnheatedSpaces,
                        ConstructionRole.Window or ConstructionRole.BalconyDoor when zoneA is bool zoneA_2002 => zoneA_2002 ? ExternalPartitionType_2002.ResidentialBuilding_Window_ZoneA : ExternalPartitionType_2002.ResidentialBuilding_Window_ZoneB,
                        ConstructionRole.RoofWindow => ExternalPartitionType_2002.ResidentialBuilding_Window_Skylight,
                        ConstructionRole.ExternalDoor or ConstructionRole.StaircaseEntranceDoor => ExternalPartitionType_2002.ResidentialBuilding_Door,
                        _ => (ExternalPartitionType_2002?)null,
                    });

                case RegulatedHeatTransferCoefficients_2009 regulatedHeatTransferCoefficients_2009:
                    return Value(regulatedHeatTransferCoefficients_2009, constructionRole switch
                    {
                        ConstructionRole.ExternalWall => ExternalPartitionType_2009.ResidentialBuilding_Wall,
                        ConstructionRole.Roof or ConstructionRole.FlatRoof => ExternalPartitionType_2009.ResidentialBuilding_Roof,
                        ConstructionRole.FloorOverUnheated => ExternalPartitionType_2009.ResidentialBuilding_Floor_OverUnheatedSpaces,
                        ConstructionRole.GroundFloor => ExternalPartitionType_2009.ResidentialBuilding_Floor,
                        ConstructionRole.Window or ConstructionRole.BalconyDoor when zoneA is bool zoneA_2009 => zoneA_2009 ? ExternalPartitionType_2009.ResidentialBuilding_Window_ZoneA : ExternalPartitionType_2009.ResidentialBuilding_Window_ZoneB,
                        ConstructionRole.RoofWindow => ExternalPartitionType_2009.ResidentialBuilding_Window_Skylight,
                        ConstructionRole.ExternalDoor or ConstructionRole.StaircaseEntranceDoor => ExternalPartitionType_2009.ResidentialBuilding_Door,
                        _ => (ExternalPartitionType_2009?)null,
                    });

                case RegulatedHeatTransferCoefficients_2014 regulatedHeatTransferCoefficients_2014:
                    return Value(regulatedHeatTransferCoefficients_2014, constructionRole switch
                    {
                        ConstructionRole.ExternalWall => ExternalPartitionType_2014.Wall,
                        ConstructionRole.Roof or ConstructionRole.FlatRoof => ExternalPartitionType_2014.Roof,
                        ConstructionRole.FloorOverUnheated => ExternalPartitionType_2014.Floor_OverUnheatedSpaces,
                        ConstructionRole.GroundFloor => ExternalPartitionType_2014.Floor,
                        ConstructionRole.Window or ConstructionRole.BalconyDoor => ExternalPartitionType_2014.Window,
                        ConstructionRole.RoofWindow => ExternalPartitionType_2014.Window_Skylight,
                        ConstructionRole.ExternalDoor or ConstructionRole.StaircaseEntranceDoor or ConstructionRole.DoorToUnheatedSpace => ExternalPartitionType_2014.Door,
                        _ => (ExternalPartitionType_2014?)null,
                    });
            }

            return double.NaN;
        }
    }
}
