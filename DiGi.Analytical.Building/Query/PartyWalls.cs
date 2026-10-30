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
        /// <para>The same as <see cref="PartyWalls(IEnumerable{BuildingModel?}?, IEnumerable{BuildingModel?}?, double, double, double, double)"/> for a single model; see there for the test. A neighbour with the identifier of the model is skipped, so the model may be passed in its own neighbour list.</para>
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

            Dictionary<Guid, List<PartyWallResult>>? dictionary = PartyWalls([buildingModel], buildingModels_Neighbour, maxDistance, maxAngle, minArea, tolerance);

            return dictionary is not null && dictionary.TryGetValue(buildingModel.Guid, out List<PartyWallResult>? result) ? result : [];
        }

        /// <summary>
        /// Gets the party walls of every building model of a collection: the parts of their walls shared with the walls of the other models of the collection and of the given neighbours (DiGi-Organization/DiGi.GIS.Analytical#4).
        /// <para>Two models are compared when their bounding boxes come within <paramref name="maxDistance"/> of each other, and two of their walls when the walls' boxes do; each pair of walls sharing a part gives one <see cref="PartyWallResult"/> for the wall of the model examined (see <see cref="Create.PartyWallResult(IWall?, BuildingModel?, IWall?, double, double, double, double)"/>). A wall shared with two neighbours, or with two walls of one neighbour, gives one result per pair.</para>
        /// <para>The walls must also face each other: their outward normals, read from the external envelope of each model (<see cref="BuildingModel.GetExternalShell(Geometry.Core.Enums.Side?, Geometry.Core.Enums.Orientation?, Geometry.Core.Enums.Orientation?, double)"/>), point in opposite directions, so the two buildings lie on opposite sides of the shared plane. A coplanar wall on the same side, as two overlapping footprints give, is then no party wall; a wall the envelope does not carry is accepted without the test.</para>
        /// <para>Within one call each model's walls are read once and its envelope is built at most once, and only when one of its walls shares a part: the envelope is by far the most expensive step, so a collection costs one per model however many neighbours it has. The models themselves are not changed.</para>
        /// </summary>
        /// <param name="buildingModels">The building models examined. This value can be null.</param>
        /// <param name="buildingModels_Neighbour">Further building models the examined ones are compared with, which get no results themselves. A model in both collections is examined. This value can be null.</param>
        /// <param name="maxDistance">The largest distance [m] between two wall planes at which the walls still count as one party wall.</param>
        /// <param name="maxAngle">The largest angle [rad] between two wall planes at which they still count as parallel.</param>
        /// <param name="minArea">The smallest shared area [m2] that makes a party wall.</param>
        /// <param name="tolerance">The distance tolerance.</param>
        /// <returns>The party walls of each examined model, keyed by its identifier, with an empty list for a model that has none; or null when <paramref name="buildingModels"/> is null.</returns>
        public static Dictionary<Guid, List<PartyWallResult>>? PartyWalls(this IEnumerable<BuildingModel?>? buildingModels, IEnumerable<BuildingModel?>? buildingModels_Neighbour, double maxDistance = 0.2, double maxAngle = 5.0 * Math.PI / 180.0, double minArea = 0.1, double tolerance = Core.Constants.Tolerance.Distance)
        {
            if (buildingModels is null)
            {
                return null;
            }

            // Every model once, by identifier: the examined ones first, then the neighbours not already among them.
            List<BuildingModel> buildingModels_All = [];
            Dictionary<Guid, int> indexes = [];
            foreach (BuildingModel? buildingModel in buildingModels)
            {
                if (buildingModel is not null && !indexes.ContainsKey(buildingModel.Guid))
                {
                    indexes[buildingModel.Guid] = buildingModels_All.Count;
                    buildingModels_All.Add(buildingModel);
                }
            }

            int count_Examined = buildingModels_All.Count;

            if (buildingModels_Neighbour is not null)
            {
                foreach (BuildingModel? buildingModel in buildingModels_Neighbour)
                {
                    if (buildingModel is not null && !indexes.ContainsKey(buildingModel.Guid))
                    {
                        indexes[buildingModel.Guid] = buildingModels_All.Count;
                        buildingModels_All.Add(buildingModel);
                    }
                }
            }

            int count = buildingModels_All.Count;

            // Read on first use and kept for the call: walls (GetComponents hands out clones), their boxes, and the outward normals.
            BoundingBox3D?[] boundingBox3Ds = new BoundingBox3D?[count];
            List<IWall>?[] walls = new List<IWall>?[count];
            List<BoundingBox3D?>?[] boundingBox3Ds_Wall = new List<BoundingBox3D?>?[count];
            Dictionary<Guid, Vector3D>?[] normals_Outward = new Dictionary<Guid, Vector3D>?[count];

            for (int i = 0; i < count; i++)
            {
                boundingBox3Ds[i] = buildingModels_All[i].GetBoundingBox();
            }

            List<IWall> Walls(int index)
            {
                if (walls[index] is not List<IWall> walls_Index)
                {
                    walls_Index = buildingModels_All[index].GetComponents<IWall>() ?? [];
                    walls[index] = walls_Index;
                    boundingBox3Ds_Wall[index] = walls_Index.ConvertAll(x => x?.GetBoundingBox());
                }

                return walls_Index;
            }

            // Outward normals of the walls, keyed by component Guid, from the external envelope oriented by ray parity.
            Dictionary<Guid, Vector3D> Normals_Outward(int index)
            {
                if (normals_Outward[index] is Dictionary<Guid, Vector3D> result_Index)
                {
                    return result_Index;
                }

                result_Index = [];
                normals_Outward[index] = result_Index;

                DiGi.Analytical.Classes.Shell? shell = buildingModels_All[index].GetExternalShell(Geometry.Core.Enums.Side.External, tolerance: tolerance);

                // The getter clones on access, so the list is read once.
                List<DiGi.Analytical.Classes.Face>? faces = shell?.PolygonalFaces;
                if (faces is not null)
                {
                    foreach (DiGi.Analytical.Classes.Face face in faces)
                    {
                        if (face.UniqueReference is Core.Classes.GuidReference guidReference && face.Plane?.Normal?.Unit is Vector3D vector3D)
                        {
                            result_Index[guidReference.Guid] = vector3D;
                        }
                    }
                }

                return result_Index;
            }

            Dictionary<Guid, List<PartyWallResult>> result = [];
            for (int i = 0; i < count_Examined; i++)
            {
                List<PartyWallResult> partyWallResults = [];
                result[buildingModels_All[i].Guid] = partyWallResults;

                if (boundingBox3Ds[i] is not BoundingBox3D boundingBox3D)
                {
                    continue;
                }

                for (int j = 0; j < count; j++)
                {
                    if (j == i || boundingBox3Ds[j] is not BoundingBox3D boundingBox3D_Neighbour || !boundingBox3D.InRange(boundingBox3D_Neighbour, maxDistance))
                    {
                        continue;
                    }

                    List<IWall> walls_I = Walls(i);
                    List<IWall> walls_J = Walls(j);
                    List<BoundingBox3D?> boundingBox3Ds_I = boundingBox3Ds_Wall[i]!;
                    List<BoundingBox3D?> boundingBox3Ds_J = boundingBox3Ds_Wall[j]!;

                    for (int k = 0; k < walls_I.Count; k++)
                    {
                        if (boundingBox3Ds_I[k] is not BoundingBox3D boundingBox3D_Wall)
                        {
                            continue;
                        }

                        for (int l = 0; l < walls_J.Count; l++)
                        {
                            if (boundingBox3Ds_J[l] is not BoundingBox3D boundingBox3D_Wall_Neighbour || !boundingBox3D_Wall.InRange(boundingBox3D_Wall_Neighbour, maxDistance))
                            {
                                continue;
                            }

                            // Once both envelopes exist, two walls facing the same way - adjacent facades of one street front - are
                            // rejected before the overlay rather than after it.
                            if (normals_Outward[i] is Dictionary<Guid, Vector3D> normals_Outward_I && normals_Outward[j] is Dictionary<Guid, Vector3D> normals_Outward_J && normals_Outward_I.TryGetValue(walls_I[k].Guid, out Vector3D? normal_Outward_Known) && normals_Outward_J.TryGetValue(walls_J[l].Guid, out Vector3D? normal_Outward_Neighbour_Known) && !(normal_Outward_Known.DotProduct(normal_Outward_Neighbour_Known) < 0))
                            {
                                continue;
                            }

                            if (Create.PartyWallResult(walls_I[k], buildingModels_All[j], walls_J[l], maxDistance, maxAngle, minArea, tolerance) is not PartyWallResult partyWallResult)
                            {
                                continue;
                            }

                            // Only now, with a wall pair that does share a part, are the envelopes of the two models built.
                            if (Normals_Outward(i).TryGetValue(walls_I[k].Guid, out Vector3D? normal_Outward) && Normals_Outward(j).TryGetValue(walls_J[l].Guid, out Vector3D? normal_Outward_Neighbour) && !(normal_Outward.DotProduct(normal_Outward_Neighbour) < 0))
                            {
                                continue;
                            }

                            partyWallResults.Add(partyWallResult);
                        }
                    }
                }
            }

            return result;
        }
    }
}
