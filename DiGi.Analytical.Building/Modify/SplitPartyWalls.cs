using DiGi.Analytical.Building.Classes;
using DiGi.Analytical.Building.Enums;
using DiGi.Analytical.Building.Interfaces;
using DiGi.Analytical.Classes;
using DiGi.Core.Classes;
using DiGi.Core.Interfaces;
using DiGi.Geometry.Planar.Classes;
using DiGi.Geometry.Spatial.Classes;
using System;
using System.Collections.Generic;

namespace DiGi.Analytical.Building
{
    public static partial class Modify
    {
        /// <summary>
        /// Splits every wall of a building model into the parts it shares with adjacent buildings and the rest, and marks the shared parts as party walls (DiGi-Organization/DiGi.GIS.Analytical#4).
        /// <para>For each space bounded by a wall named in <paramref name="partyWallResults"/>, the shell of the space is rebuilt with the face of that wall replaced by its pieces - first the part no neighbour shares, then one piece per shared part - all carrying the reference of the wall, and written back with <see cref="BuildingModelShellsUpdater"/>. The first piece keeps the identifier of the wall, so the wall keeps its identity on its external part, or on its first shared part when it is shared whole; the other pieces become walls of the same type and construction. Every shared piece gets <see cref="ComponentParameter.PartyWall"/>, the identifier of the neighbour's building model. A shared part overlapping one already taken for the same wall is reduced to the part not yet taken, so the pieces never overlap.</para>
        /// <para>The split is opt-in and is not applied to stored models: the pieces meet the edges of the roof, the floor and the other walls in T-junctions, and an envelope whose edges must pair up to close (<c>ClosingTolerance</c>) may no longer close. Areas by party wall can be had without a split, from <see cref="Query.PartyWalls(BuildingModel?, IEnumerable{BuildingModel?}?, double, double, double, double)"/>.</para>
        /// </summary>
        /// <remarks>
        /// Openings hosted by a split wall stay assigned to the piece that keeps the identifier of the wall, as in <see cref="TrySplit(BuildingModel, double, double, IFloorConstruction, IEnumerable{ISpace}, double)"/>; they are not moved to the piece that contains them.
        /// </remarks>
        /// <param name="buildingModel">The building model to split, in place. This value can be null.</param>
        /// <param name="partyWallResults">The party walls of the model, as returned by <see cref="Query.PartyWalls(BuildingModel?, IEnumerable{BuildingModel?}?, double, double, double, double)"/>. This value can be null.</param>
        /// <param name="tolerance">The distance tolerance.</param>
        /// <returns>True if at least one wall was split or marked; otherwise, false.</returns>
        public static bool SplitPartyWalls(this BuildingModel? buildingModel, IEnumerable<PartyWallResult?>? partyWallResults, double tolerance = Core.Constants.Tolerance.Distance)
        {
            if (buildingModel is null || partyWallResults is null)
            {
                return false;
            }

            // The shared parts of each wall with the identifier of the neighbour model, keyed by the wall's identifier.
            Dictionary<Guid, List<Tuple<PolygonalFace3D, Guid>>> dictionary_Shared = [];
            foreach (PartyWallResult? partyWallResult in partyWallResults)
            {
                if (partyWallResult?.Component is not GuidReference guidReference_Component || partyWallResult.PolygonalFace3Ds is not List<PolygonalFace3D> polygonalFace3Ds)
                {
                    continue;
                }

                Guid guid_Neighbour = partyWallResult.NeighbourBuildingModel?.Guid ?? Guid.Empty;

                if (!dictionary_Shared.TryGetValue(guidReference_Component.Guid, out List<Tuple<PolygonalFace3D, Guid>>? tuples))
                {
                    tuples = [];
                    dictionary_Shared[guidReference_Component.Guid] = tuples;
                }

                foreach (PolygonalFace3D polygonalFace3D in polygonalFace3Ds)
                {
                    tuples.Add(new Tuple<PolygonalFace3D, Guid>(polygonalFace3D, guid_Neighbour));
                }
            }

            if (dictionary_Shared.Count == 0 || buildingModel.GetComponents<IWall>() is not List<IWall> walls)
            {
                return false;
            }

            // Only the spaces a shared wall bounds are rebuilt: the shell of every other space stays as it is, and is not even built.
            List<ISpace> spaces = [];
            HashSet<Guid> guids_Space = [];
            foreach (IWall wall in walls)
            {
                if (wall is null || !dictionary_Shared.ContainsKey(wall.Guid) || buildingModel.GetSpaces(wall) is not List<ISpace> spaces_Wall)
                {
                    continue;
                }

                foreach (ISpace space_Wall in spaces_Wall)
                {
                    if (space_Wall is not null && guids_Space.Add(space_Wall.Guid))
                    {
                        spaces.Add(space_Wall);
                    }
                }
            }

            if (spaces.Count == 0)
            {
                return false;
            }

            List<Shell> shells = [];

            // The shared pieces, as the internal points the updater keys the created components by, with the neighbour each is shared with.
            List<Tuple<Point3D, Guid>> tuples_Marked = [];

            foreach (ISpace space in spaces)
            {
                Shell? shell = buildingModel.GetShell(space, tolerance: tolerance);
                if (shell?.PolygonalFaces is not List<Face> faces)
                {
                    continue;
                }

                bool split = false;
                List<Face> faces_New = [];
                foreach (Face face in faces)
                {
                    IUniqueReference? uniqueReference = face.UniqueReference;
                    if (uniqueReference is not GuidReference guidReference || !dictionary_Shared.TryGetValue(guidReference.Guid, out List<Tuple<PolygonalFace3D, Guid>>? tuples) || face.Plane is not Plane plane || Geometry.Spatial.Query.Convert(plane, (PolygonalFace3D)face) is not PolygonalFace2D polygonalFace2D)
                    {
                        faces_New.Add(face);
                        continue;
                    }

                    // The shared parts in the plane of the face, each reduced by the parts taken before it so that no two overlap.
                    List<PolygonalFace2D> polygonalFace2Ds_Taken = [];
                    List<Tuple<PolygonalFace2D, Guid>> tuples_Shared = [];
                    foreach (Tuple<PolygonalFace3D, Guid> tuple in tuples)
                    {
                        if (Geometry.Spatial.Query.Convert(plane, tuple.Item1) is not PolygonalFace2D polygonalFace2D_Shared)
                        {
                            continue;
                        }

                        List<PolygonalFace2D>? polygonalFace2Ds_Shared = polygonalFace2Ds_Taken.Count == 0 ? [polygonalFace2D_Shared] : Geometry.Planar.Query.Difference(polygonalFace2D_Shared, polygonalFace2Ds_Taken, tolerance);
                        if (polygonalFace2Ds_Shared is null)
                        {
                            continue;
                        }

                        foreach (PolygonalFace2D polygonalFace2D_Temp in polygonalFace2Ds_Shared)
                        {
                            if (!(polygonalFace2D_Temp.GetArea() >= tolerance * tolerance))
                            {
                                continue;
                            }

                            polygonalFace2Ds_Taken.Add(polygonalFace2D_Temp);
                            tuples_Shared.Add(new Tuple<PolygonalFace2D, Guid>(polygonalFace2D_Temp, tuple.Item2));
                        }
                    }

                    if (tuples_Shared.Count == 0)
                    {
                        faces_New.Add(face);
                        continue;
                    }

                    // The part no neighbour shares comes first, so it keeps the identifier of the wall.
                    List<PolygonalFace2D> polygonalFace2Ds_External = Geometry.Planar.Query.Difference(polygonalFace2D, polygonalFace2Ds_Taken, tolerance) ?? [];

                    foreach (PolygonalFace2D polygonalFace2D_External in polygonalFace2Ds_External)
                    {
                        if (polygonalFace2D_External.GetArea() >= tolerance * tolerance && Geometry.Spatial.Query.Convert(plane, polygonalFace2D_External) is PolygonalFace3D polygonalFace3D_External)
                        {
                            faces_New.Add(new Face(guidReference, polygonalFace3D_External));
                        }
                    }

                    foreach (Tuple<PolygonalFace2D, Guid> tuple_Shared in tuples_Shared)
                    {
                        if (Geometry.Spatial.Query.Convert(plane, tuple_Shared.Item1) is not PolygonalFace3D polygonalFace3D_Shared)
                        {
                            continue;
                        }

                        faces_New.Add(new Face(guidReference, polygonalFace3D_Shared));

                        if (polygonalFace3D_Shared.GetInternalPoint(tolerance) is Point3D point3D_Internal)
                        {
                            tuples_Marked.Add(new Tuple<Point3D, Guid>(point3D_Internal, tuple_Shared.Item2));
                        }
                    }

                    split = true;
                }

                if (split)
                {
                    shells.Add(new Shell(new GuidReference(space), faces_New));
                }
            }

            if (shells.Count == 0)
            {
                return false;
            }

            BuildingModelShellsUpdater buildingModelShellsUpdater = new(buildingModel)
            {
                Shells = shells,
                Tolerance = tolerance
            };

            if (!buildingModelShellsUpdater.Update())
            {
                return false;
            }

            // The updater keys every component it created by the internal point of the face it came from; the shared pieces are found by theirs.
            if (buildingModelShellsUpdater.UpdatedComponents is not Dictionary<IUniqueReference, List<Tuple<Point3D, IComponent>>> dictionary_Updated)
            {
                return true;
            }

            foreach (List<Tuple<Point3D, IComponent>> tuples_Updated in dictionary_Updated.Values)
            {
                foreach (Tuple<Point3D, IComponent> tuple_Updated in tuples_Updated)
                {
                    Tuple<Point3D, Guid>? tuple_Marked = tuples_Marked.Find(x => x.Item1.Distance(tuple_Updated.Item1) <= tolerance);
                    if (tuple_Marked is null || tuple_Updated.Item2 is not Component component)
                    {
                        continue;
                    }

                    component.SetValue(ComponentParameter.PartyWall, tuple_Marked.Item2);
                    buildingModel.Update(component);
                }
            }

            return true;
        }
    }
}
