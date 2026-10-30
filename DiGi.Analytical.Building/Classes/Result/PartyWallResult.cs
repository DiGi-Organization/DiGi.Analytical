using DiGi.Analytical.Building.Interfaces;
using DiGi.Core.Classes;
using DiGi.Geometry.Spatial.Classes;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.Analytical.Building.Classes
{
    /// <summary>
    /// Represents the part of a wall that is shared with a wall of an adjacent building: a party wall (DiGi-Organization/DiGi.GIS.Analytical#4).
    /// <para>The shared part lies in the plane of the wall and is what the two coplanar wall faces have in common, so it already reflects any difference in height or plan between the two buildings. Created by <c>Create.PartyWallResult</c>, which does the geometry; the constructor only assigns and clones.</para>
    /// </summary>
    public class PartyWallResult : SerializableResult, IBuildingSerializableObject
    {
        [JsonInclude, JsonPropertyName(nameof(Area))]
        private readonly double area = double.NaN;

        [JsonInclude, JsonPropertyName(nameof(Component))]
        private readonly GuidReference? component;

        [JsonInclude, JsonPropertyName(nameof(NeighbourBuildingModel))]
        private readonly GuidReference? neighbourBuildingModel;

        [JsonInclude, JsonPropertyName(nameof(NeighbourComponent))]
        private readonly GuidReference? neighbourComponent;

        [JsonInclude, JsonPropertyName(nameof(PolygonalFace3Ds))]
        private readonly List<PolygonalFace3D>? polygonalFace3Ds;

        /// <summary>
        /// Initializes a new instance of the <see cref="PartyWallResult"/> class.
        /// <para>The values are assigned and the faces cloned, null faces skipped; the area is taken as given. <c>Create.PartyWallResult</c> computes the faces and their area.</para>
        /// </summary>
        /// <param name="component">The reference of the wall the shared part belongs to. This value can be null.</param>
        /// <param name="neighbourBuildingModel">The reference of the building model of the adjacent building. This value can be null.</param>
        /// <param name="neighbourComponent">The reference of the wall of the adjacent building the part is shared with. This value can be null.</param>
        /// <param name="polygonalFace3Ds">The shared parts, in the plane of the wall. This value can be null.</param>
        /// <param name="area">The total area of the shared parts [m2].</param>
        public PartyWallResult(GuidReference? component, GuidReference? neighbourBuildingModel, GuidReference? neighbourComponent, IEnumerable<PolygonalFace3D?>? polygonalFace3Ds, double area)
            : base()
        {
            this.component = Core.Query.Clone(component);
            this.neighbourBuildingModel = Core.Query.Clone(neighbourBuildingModel);
            this.neighbourComponent = Core.Query.Clone(neighbourComponent);
            this.area = area;

            if (polygonalFace3Ds is not null)
            {
                this.polygonalFace3Ds = [];
                foreach (PolygonalFace3D? polygonalFace3D in polygonalFace3Ds)
                {
                    if (Core.Query.Clone(polygonalFace3D) is PolygonalFace3D polygonalFace3D_Clone)
                    {
                        this.polygonalFace3Ds.Add(polygonalFace3D_Clone);
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PartyWallResult"/> class by copying an existing instance.
        /// </summary>
        /// <param name="partyWallResult">The <see cref="PartyWallResult"/> to copy. This value can be null.</param>
        public PartyWallResult(PartyWallResult? partyWallResult)
            : base(partyWallResult)
        {
            if (partyWallResult is not null)
            {
                component = Core.Query.Clone(partyWallResult.component);
                neighbourBuildingModel = Core.Query.Clone(partyWallResult.neighbourBuildingModel);
                neighbourComponent = Core.Query.Clone(partyWallResult.neighbourComponent);
                area = partyWallResult.area;

                if (partyWallResult.polygonalFace3Ds is not null)
                {
                    polygonalFace3Ds = [];
                    foreach (PolygonalFace3D polygonalFace3D in partyWallResult.polygonalFace3Ds)
                    {
                        if (Core.Query.Clone(polygonalFace3D) is PolygonalFace3D polygonalFace3D_Clone)
                        {
                            polygonalFace3Ds.Add(polygonalFace3D_Clone);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PartyWallResult"/> class from a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the result data. This value can be null.</param>
        public PartyWallResult(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets the total area of the shared parts [m2].
        /// </summary>
        [JsonIgnore]
        public double Area
        {
            get
            {
                return area;
            }
        }

        /// <summary>
        /// Gets a clone of the reference of the wall the shared part belongs to.
        /// </summary>
        [JsonIgnore]
        public GuidReference? Component
        {
            get
            {
                return Core.Query.Clone(component);
            }
        }

        /// <summary>
        /// Gets a clone of the reference of the building model of the adjacent building.
        /// </summary>
        [JsonIgnore]
        public GuidReference? NeighbourBuildingModel
        {
            get
            {
                return Core.Query.Clone(neighbourBuildingModel);
            }
        }

        /// <summary>
        /// Gets a clone of the reference of the wall of the adjacent building the part is shared with.
        /// </summary>
        [JsonIgnore]
        public GuidReference? NeighbourComponent
        {
            get
            {
                return Core.Query.Clone(neighbourComponent);
            }
        }

        /// <summary>
        /// Gets clones of the shared parts, in the plane of the wall, or null.
        /// </summary>
        [JsonIgnore]
        public List<PolygonalFace3D>? PolygonalFace3Ds
        {
            get
            {
                if (polygonalFace3Ds is null)
                {
                    return null;
                }

                List<PolygonalFace3D> result = [];
                foreach (PolygonalFace3D polygonalFace3D in polygonalFace3Ds)
                {
                    if (Core.Query.Clone(polygonalFace3D) is PolygonalFace3D polygonalFace3D_Clone)
                    {
                        result.Add(polygonalFace3D_Clone);
                    }
                }

                return result;
            }
        }
    }
}
