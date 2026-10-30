using DiGi.Analytical.Building.Classes;
using DiGi.Analytical.Building.Interfaces;
using DiGi.Geometry.Spatial.Classes;
using System;
using System.Collections.Generic;

namespace DiGi.Analytical.Building
{
    public static partial class Query
    {
        /// <summary>
        /// Gets the parts of the walls of a building model shared with the walls of adjacent buildings: its party walls (DiGi-Organization/DiGi.GIS.Analytical#4).
        /// <para>Every wall of the model is compared with every wall of every neighbour whose bounding box comes within <paramref name="maxDistance"/> of it; each pair of walls sharing a part gives one <see cref="PartyWallResult"/> (see <see cref="Create.PartyWallResult(IWall?, Vector3D?, BuildingModel?, IWall?, Vector3D?, double, double, double, double)"/> for the test). A wall shared with two neighbours, or with two walls of one neighbour, gives one result per pair.</para>
        /// <para>The outward normal of every wall is read from the external envelope of its model (<see cref="BuildingModel.GetExternalShell(Geometry.Core.Enums.Side?, Geometry.Core.Enums.Orientation?, Geometry.Core.Enums.Orientation?, double)"/>), so only walls facing each other are compared; a wall the envelope does not carry is compared without that test.</para>
        /// <para>The model itself is not changed. A neighbour with the identifier of the model is skipped, so the model may be passed in its own neighbour list.</para>
        /// </summary>
        /// <param name="buildingModel">The building model examined. This value can be null.</param>
        /// <param name="buildingModels_Neighbour">The building models of the adjacent buildings. This value can be null.</param>
        /// <param name="maxDistance">The largest distance [m] between two wall planes at which the walls still count as one party wall.</param>
        /// <param name="maxAngle">The largest angle [rad] between two wall planes at which they still count as parallel.</param>
        /// <param name="minArea">The smallest shared area [m2] that makes a party wall.</param>
        /// <param name="tolerance">The distance tolerance.</param>
        /// <returns>The party walls of the model, an empty list when it has none, or null when the model is null.</returns>
        public static List<PartyWallResult>? PartyWalls(this BuildingModel? buildingModel, IEnumerable<BuildingModel?>? buildingModels_Neighbour, double maxDistance = 0.2, double maxAngle = 5.0 * Math.PI / 180.0, double minArea = 0.1, double tolerance = Core.Constants.Tolerance.Distance)
        {
            if (buildingModel is null)
            {
                return null;
            }

            List<PartyWallResult> result = [];
            if (buildingModels_Neighbour is null)
            {
                return result;
            }

            // GetComponents hands out clones, so the walls of each model are read once.
            List<IWall>? walls = buildingModel.GetComponents<IWall>();
            if (walls is null || walls.Count == 0)
            {
                return result;
            }

            // Outward normals of the walls, keyed by component Guid, from the external envelope oriented by ray parity.
            static Dictionary<Guid, Vector3D> Normals_Outward(BuildingModel buildingModel_Temp, double tolerance_Temp)
            {
                Dictionary<Guid, Vector3D> result_Temp = [];

                DiGi.Analytical.Classes.Shell? shell = buildingModel_Temp.GetExternalShell(Geometry.Core.Enums.Side.External, tolerance: tolerance_Temp);

                // The getter clones on access, so the list is read once.
                List<DiGi.Analytical.Classes.Face>? faces = shell?.PolygonalFaces;
                if (faces is null)
                {
                    return result_Temp;
                }

                foreach (DiGi.Analytical.Classes.Face face in faces)
                {
                    if (face.UniqueReference is Core.Classes.GuidReference guidReference && face.Plane?.Normal?.Unit is Vector3D vector3D)
                    {
                        result_Temp[guidReference.Guid] = vector3D;
                    }
                }

                return result_Temp;
            }

            List<BoundingBox3D?> boundingBox3Ds = walls.ConvertAll(x => x?.GetBoundingBox());
            Dictionary<Guid, Vector3D> normals_Outward = Normals_Outward(buildingModel, tolerance);

            foreach (BuildingModel? buildingModel_Neighbour in buildingModels_Neighbour)
            {
                if (buildingModel_Neighbour is null || buildingModel_Neighbour.Guid == buildingModel.Guid)
                {
                    continue;
                }

                List<IWall>? walls_Neighbour = buildingModel_Neighbour.GetComponents<IWall>();
                if (walls_Neighbour is null || walls_Neighbour.Count == 0)
                {
                    continue;
                }

                List<BoundingBox3D?> boundingBox3Ds_Neighbour = walls_Neighbour.ConvertAll(x => x?.GetBoundingBox());
                Dictionary<Guid, Vector3D>? normals_Outward_Neighbour = null;

                for (int i = 0; i < walls.Count; i++)
                {
                    BoundingBox3D? boundingBox3D = boundingBox3Ds[i];
                    if (boundingBox3D is null)
                    {
                        continue;
                    }

                    for (int j = 0; j < walls_Neighbour.Count; j++)
                    {
                        BoundingBox3D? boundingBox3D_Neighbour = boundingBox3Ds_Neighbour[j];
                        if (boundingBox3D_Neighbour is null || !boundingBox3D.InRange(boundingBox3D_Neighbour, maxDistance))
                        {
                            continue;
                        }

                        // The neighbour's envelope is only built once one of its walls comes close.
                        normals_Outward_Neighbour ??= Normals_Outward(buildingModel_Neighbour, tolerance);

                        normals_Outward.TryGetValue(walls[i].Guid, out Vector3D? normal_Outward);
                        normals_Outward_Neighbour.TryGetValue(walls_Neighbour[j].Guid, out Vector3D? normal_Outward_Neighbour);

                        if (Create.PartyWallResult(walls[i], normal_Outward, buildingModel_Neighbour, walls_Neighbour[j], normal_Outward_Neighbour, maxDistance, maxAngle, minArea, tolerance) is PartyWallResult partyWallResult)
                        {
                            result.Add(partyWallResult);
                        }
                    }
                }
            }

            return result;
        }
    }
}
