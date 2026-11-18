using DiGi.Analytical.Building.Classes;
using DiGi.Analytical.Building.Enums;
using DiGi.Analytical.Building.Interfaces;
using DiGi.Analytical.Building.Regulation.Enums;
using DiGi.Core.Classes;
using DiGi.Core.Parameter.Classes;
using DiGi.Geometry.Spatial.Classes;
using System;
using System.Collections.Generic;

namespace DiGi.Analytical.Building.Regulation
{
    public static partial class Query
    {
        /// <summary>
        /// Classifies the walls, roofs and floors of a building model by the construction role a construction set gives them (DiGi-Organization/DiGi.Analytical#21). These are the rules of DiGi.GIS.Analytical <c>Modify.GenerateOpenings</c> (DiGi-Organization/DiGi.GIS.Analytical#11, phase D), made public so that the opening generator and the heat-demand calculation classify a model alike.
        /// <para><b>Walls.</b> A wall carrying <see cref="ComponentParameter.PartyWall"/> is <see cref="ConstructionRole.PartyWall"/>, a wall the external shell carries is <see cref="ConstructionRole.ExternalWall"/> and any other wall is <see cref="ConstructionRole.InternalWall"/>.</para>
        /// <para><b>Roofs.</b> A roof whose external-shell face stands less than <see cref="Constants.Default.FlatRoofTilt"/> degrees off the world up axis is <see cref="ConstructionRole.FlatRoof"/>, any other roof <see cref="ConstructionRole.Roof"/>. A roof the external shell does not carry has no outward normal to read a tilt from and gets no role: it is absent from the result.</para>
        /// <para><b>Floors.</b> The floor whose geometry reaches lowest is <see cref="ConstructionRole.FloorOverUnheated"/> when <paramref name="floorBoundary"/> is <see cref="FloorBoundary.Cellar"/> and <see cref="ConstructionRole.GroundFloor"/> otherwise; every other floor is <see cref="ConstructionRole.IntermediateFloor"/>.</para>
        /// <para>The external shell is <see cref="BuildingModel.GetExternalShell(Geometry.Core.Enums.Side?, Geometry.Core.Enums.Orientation?, Geometry.Core.Enums.Orientation?, double)"/> with outward normals, so a component is external when it bounds exactly one space.</para>
        /// </summary>
        /// <param name="buildingModel">The building model whose components are classified. This value can be null.</param>
        /// <param name="floorBoundary">What the lowest floor borders, as the TypicalAsBuilt <see cref="Classes.TypologyData"/> of the building records it.</param>
        /// <param name="tolerance">The distance tolerance of the external shell.</param>
        /// <returns>The role of each classified component keyed by its identifier, or null when <paramref name="buildingModel"/> is null.</returns>
        public static Dictionary<Guid, ConstructionRole>? ConstructionRoles(this BuildingModel? buildingModel, FloorBoundary floorBoundary, double tolerance = Core.Constants.Tolerance.Distance)
        {
            if (buildingModel is null)
            {
                return null;
            }

            Dictionary<Guid, DiGi.Analytical.Classes.Face> faces_Shell = [];
            List<DiGi.Analytical.Classes.Face>? faces = buildingModel.GetExternalShell(Geometry.Core.Enums.Side.External, tolerance: tolerance)?.PolygonalFaces;
            if (faces is not null)
            {
                foreach (DiGi.Analytical.Classes.Face face in faces)
                {
                    if (face.UniqueReference is GuidReference guidReference && !faces_Shell.ContainsKey(guidReference.Guid))
                    {
                        faces_Shell[guidReference.Guid] = face;
                    }
                }
            }

            Dictionary<Guid, ConstructionRole> result = [];

            List<IWall> walls = buildingModel.GetComponents<IWall>() ?? [];
            foreach (IWall wall in walls)
            {
                if (wall is Component component && component.TryGetValue(new EnumParameterDefinition(ComponentParameter.PartyWall), out Guid _))
                {
                    result[wall.Guid] = ConstructionRole.PartyWall;
                }
                else if (faces_Shell.ContainsKey(wall.Guid))
                {
                    result[wall.Guid] = ConstructionRole.ExternalWall;
                }
                else
                {
                    result[wall.Guid] = ConstructionRole.InternalWall;
                }
            }

            List<IRoof> roofs = buildingModel.GetComponents<IRoof>() ?? [];
            foreach (IRoof roof in roofs)
            {
                // The shell normal is the roof's upward direction, as in DiGi.GIS.PostgreSQL.Modify.Update_ExternalComponentsArea; no flip is applied.
                if (!faces_Shell.TryGetValue(roof.Guid, out DiGi.Analytical.Classes.Face? face) || face.Plane?.Normal?.Unit is not Vector3D vector3D_Normal)
                {
                    continue;
                }

                double tilt = vector3D_Normal.Angle(Geometry.Spatial.Constants.Vector3D.WorldZ) * 180.0 / Math.PI;
                result[roof.Guid] = tilt < Constants.Default.FlatRoofTilt ? ConstructionRole.FlatRoof : ConstructionRole.Roof;
            }

            List<IFloor> floors = buildingModel.GetComponents<IFloor>() ?? [];
            floors.Sort((x, y) => x.Guid.CompareTo(y.Guid));

            // The lowest floor stands lowest; its elevation comes off its own geometry, so a floor the shell does not carry is classified too.
            int index_Lowest = -1;
            double elevation_Lowest = double.MaxValue;
            for (int i = 0; i < floors.Count; i++)
            {
                if (floors[i].GetBoundingBox()?.Min?.Z is double elevation && (index_Lowest == -1 || elevation < elevation_Lowest))
                {
                    index_Lowest = i;
                    elevation_Lowest = elevation;
                }
            }

            for (int i = 0; i < floors.Count; i++)
            {
                result[floors[i].Guid] = i == index_Lowest ? (floorBoundary == FloorBoundary.Cellar ? ConstructionRole.FloorOverUnheated : ConstructionRole.GroundFloor) : ConstructionRole.IntermediateFloor;
            }

            return result;
        }
    }
}
