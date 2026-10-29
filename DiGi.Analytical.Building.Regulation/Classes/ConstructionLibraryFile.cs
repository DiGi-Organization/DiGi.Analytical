using DiGi.Core;
using DiGi.Core.Classes;
using System.Text.Json.Nodes;

namespace DiGi.Analytical.Building.Regulation.Classes
{
    /// <summary>
    /// Represents a storage file for <see cref="ConstructionLibrary"/> instances, mirroring <see cref="Analytical.Classes.MaterialsFile"/> (DiGi-Organization/DiGi.Analytical#8).
    /// </summary>
    public class ConstructionLibraryFile : Core.IO.File.Classes.StorageFile<ConstructionLibrary>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConstructionLibraryFile"/> class using the specified file path.
        /// </summary>
        /// <param name="path">The file system path to the construction library file. This value can be null.</param>
        public ConstructionLibraryFile(string? path)
            : base(path)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstructionLibraryFile"/> class using the specified JSON object.
        /// </summary>
        /// <param name="jsonObject">The <see cref="JsonObject"/> containing the data used to initialize the file.</param>
        public ConstructionLibraryFile(JsonObject? jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstructionLibraryFile"/> class using an existing <see cref="ConstructionLibraryFile"/> instance.
        /// </summary>
        /// <param name="constructionLibraryFile">The source <see cref="ConstructionLibraryFile"/> instance to copy from.</param>
        public ConstructionLibraryFile(ConstructionLibraryFile? constructionLibraryFile)
            : base(constructionLibraryFile)
        {
        }

        /// <summary>
        /// Retrieves the unique reference for the specified construction library.
        /// </summary>
        /// <param name="constructionLibrary">The construction library to retrieve the reference for.</param>
        /// <returns>The unique reference associated with the specified construction library, or null.</returns>
        public override UniqueReference? GetUniqueReference(ConstructionLibrary? constructionLibrary)
        {
            return constructionLibrary?.UniqueReference();
        }
    }
}
