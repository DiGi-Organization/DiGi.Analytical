using DiGi.Analytical.Building.Regulation.Classes;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DiGi.Analytical.Building.Regulation
{
    public static partial class Query
    {
        /// <summary>
        /// The manifest name of the embedded copy of the Polish construction library read by <see cref="EmbeddedConstructionLibrary_PL"/>.
        /// </summary>
        public const string EmbeddedConstructionLibrary_PL_ResourceName = "DiGi.Analytical.Building.Regulation.Resources.ConstructionLibrary_PL.json";

        /// <summary>
        /// Reads the Polish construction library embedded in this assembly (DiGi-Organization/DiGi.Analytical#15).
        /// <para>The embedded file is the serialized output of <see cref="Create.ConstructionLibrary_PL"/>, kept beside the code so that a consumer reads one versioned file rather than rebuilding the library. The <c>ConstructionLibrary_PL_Resource</c> fact fails whenever the two differ.</para>
        /// </summary>
        /// <returns>A new <see cref="ConstructionLibrary"/> read from the embedded file, or null when the file is missing or cannot be read.</returns>
        public static ConstructionLibrary? EmbeddedConstructionLibrary_PL()
        {
            using Stream? stream = typeof(Query).Assembly.GetManifestResourceStream(EmbeddedConstructionLibrary_PL_ResourceName);
            if (stream is null)
            {
                return null;
            }

            using StreamReader streamReader = new(stream);
            List<ConstructionLibrary>? constructionLibraries = Core.Convert.ToDiGi<ConstructionLibrary>(streamReader.ReadToEnd());
            return constructionLibraries?.FirstOrDefault();
        }
    }
}
