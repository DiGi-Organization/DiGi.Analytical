using DiGi.Analytical.Building.Regulation.Classes;
using DiGi.Analytical.Building.Regulation.Enums;
using System;
using System.Collections.Generic;

namespace DiGi.Analytical.Building.Regulation
{
    public static partial class Create
    {
        /// <summary>
        /// The source tag of a value from the catalogue of typical windows and balcony doors BN-85/7153-02 (40 window and 12 balcony-door types), read through its reproduction on kb.pl (2023) and muratorplus; the BN text itself was not read. Frame sizes are on a 300 mm module less a 35 mm fitting gap in width and 65 mm in height.
        /// </summary>
        public const string OpeningSizeSource_BN85 = "PL-BN85";

        /// <summary>
        /// The source tag of a value from ITB, "Diagnostyka budynków wielkopłytowych", training materials, 2019: modules, axis spacing and storey heights of the W-70, Wk-70, Szczecin, OWT-67, OWT-75 and WUF-T large-panel systems.
        /// </summary>
        public const string OpeningSizeSource_ITB = "PL-ITB";

        /// <summary>
        /// The source tag of the OWT-67 gross storey height of 270 cm, from pl.wikipedia.org "OWT-67" (rev. 72638965, 2024-01-21); ITB gives only the 280 cm of OWT-75.
        /// </summary>
        public const string OpeningSizeSource_OWT = "PL-OWT";

        /// <summary>
        /// The source tag of a value from Fundacja Hereditas, "Warszawskie kamienice przełomu XIX i XX w." (2024): the Warsaw building rules required residential storeys of at least 340 cm (p. 22).
        /// </summary>
        public const string OpeningSizeSource_WAW = "PL-WAW";

        /// <summary>
        /// The source tag of a pane layout from J. Roguska, "Okna i ich oprawa architektoniczna w warszawskich kamienicach w drugiej połowie XIX i na początku XX wieku", Kwartalnik Architektury i Urbanistyki 56(1), 2011: two casements below a fixed transom with a top light, box windows from about 1900. The article gives no dimensions.
        /// </summary>
        public const string OpeningSizeSource_ROG = "PL-ROG";

        /// <summary>
        /// The source tag of a value from the building regulation of 1928, Dz.U. 1928 nr 23 poz. 202 (consolidated text Dz.U. 1939 nr 34 poz. 216), in force until 1961: windows of at least 1/10 of the floor area, as cited by DiGi-Organization/DiGi.GIS.Analytical#2.
        /// </summary>
        public const string OpeningSizeSource_1928 = "PL-1928";

        /// <summary>
        /// The source tag of a value from the technical conditions, Dz.U. 2022 poz. 1225: § 62 (an entrance door at least 0.9 × 2.0 m in the clear) and § 223 (a 0.8 m interstorey strip).
        /// </summary>
        public const string OpeningSizeSource_WT = "PL-WT";

        /// <summary>
        /// The source tag of an uncited value, to be calibrated (façade imagery, DiGi-Organization/DiGi.GIS.Analytical#2).
        /// </summary>
        public const string OpeningSizeSource_Default = "DEFAULT";

        /// <summary>
        /// The date the sources of <see cref="OpeningSizeLibrary_PL"/> were read.
        /// </summary>
        public const string OpeningSizeLibrary_PL_RetrievalDate = "2026-10-30";

        /// <summary>
        /// The version of the library <see cref="OpeningSizeLibrary_PL"/> creates. Raise it whenever a value changes.
        /// </summary>
        public const string OpeningSizeLibrary_PL_Version = "1.0.0";

        /// <summary>
        /// Creates the Polish opening size library: window and door sizes and glazing layouts of residential buildings per building type, date range and large-panel system (DiGi-Organization/DiGi.GIS.Analytical#6).
        /// <para><b>Ranges.</b> The TABULA construction periods of <see cref="Query.ConstructionPeriod(short?)"/>, with "until 1945" split at 1918 into tenements (tall box windows, storeys of 3.40 m and more) and inter-war modernism. TABULA has no apartment block before 1967, so those ranges repeat the multi-family sizes; terraced houses repeat the single-family sizes.</para>
        /// <para><b>Large-panel systems.</b> Apartment blocks of 1967-1985 have one set per system - W-70 (the default a lookup without a system returns), Wk-70, Szczecin, OWT-67, OWT-75 and WUF-T - with the storey height and module of the system. Window widths plus the 35 mm fitting gap of the catalogue are multiples of the system's module, and the OWT-67 window height is its 1.50 m band between the 1.20 m spandrel elements less the 65 mm gap.</para>
        /// <para><b>Sources.</b> Every <see cref="OpeningSize.Source"/> and <see cref="OpeningSizeSet.Source"/> is a list of "Quantity: TAG detail" items separated by "; ", with the tags <see cref="OpeningSizeSource_BN85"/>, <see cref="OpeningSizeSource_ITB"/>, <see cref="OpeningSizeSource_OWT"/>, <see cref="OpeningSizeSource_WAW"/>, <see cref="OpeningSizeSource_ROG"/>, <see cref="OpeningSizeSource_1928"/>, <see cref="OpeningSizeSource_WT"/> and <see cref="OpeningSizeSource_Default"/>. The catalogue sizes are tagged BN-85 even where they are used before 1985, when the set's source says so. Frame and divider widths, sill heights and the pre-1946 dimensions are defaults to calibrate.</para>
        /// <para>The library is built from constants only, so it serializes to the same text each time it is created.</para>
        /// </summary>
        /// <returns>The Polish opening size library.</returns>
        public static OpeningSizeLibrary OpeningSizeLibrary_PL()
        {
            OpeningSizeLibrary result = new(Core.Create.Guid("PL.OpeningSizeLibrary"), "PL", OpeningSizeLibrary_PL_Version, "Polish window and door sizes of residential buildings per building type, construction period and large-panel system (DiGi-Organization/DiGi.GIS.Analytical#6), sources read " + OpeningSizeLibrary_PL_RetrievalDate + ".");

            const string sill = "Sill: " + OpeningSizeSource_Default + " 0.85 m, the WT minimum below 25 m, adopted for all periods";
            const string sill_High = "Sill: " + OpeningSizeSource_Default + " high sill of a small window";
            const string layout_Wood = "Layout: " + OpeningSizeSource_Default + " frame 0.10 m, divider 0.10 m (wooden coupled sashes)";
            const string layout_Pvc = "Layout: " + OpeningSizeSource_Default + " frame 0.12 m, divider 0.12 m (PVC)";
            const string layout_Box = "Layout: " + OpeningSizeSource_ROG + " two casements below a transom with a top light; Widths: " + OpeningSizeSource_Default + " frame 0.12 m, divider 0.10 m, top light 0.55 m";
            const string layout_Door = "Layout: " + OpeningSizeSource_Default + " frame 0.05 m, opaque";
            const string layout_DoorGlazed = "Layout: " + OpeningSizeSource_Default + " frame 0.08 m, one glazed leaf";
            const string bathroom_Internal = OpeningSizeSource_Default + " bathrooms are internal (mechanically or shaft ventilated), so they have no window";

            static DateTimeOffset Date(int year)
            {
                return new DateTimeOffset(year, 1, 1, 0, 0, 0, TimeSpan.Zero);
            }

            static OpeningSize Window(RoomUse roomUse, double width, double height, double sillHeight, int columns, double frameWidth, double dividerWidth, string source)
            {
                return new OpeningSize(OpeningKind.Window, roomUse, width, height, sillHeight, true, columns, frameWidth, dividerWidth, null, source);
            }

            // BN-85/7153-02 catalogue windows (frame sizes) and balcony doors; the symbol names the catalogue type.
            static OpeningSize Catalogue(OpeningKind openingKind, RoomUse roomUse, string symbol, double width, double height, double? sillHeight, int columns, bool pvc, string sillSource = sill)
            {
                string source = "Size: " + OpeningSizeSource_BN85 + " " + symbol + "; " + (sillHeight is null ? "Sill: none" : sillSource) + "; " + (pvc ? layout_Pvc : layout_Wood);
                double frameWidth = pvc ? 0.12 : 0.10;
                return new OpeningSize(openingKind, roomUse, width, height, sillHeight, true, columns, frameWidth, frameWidth, null, source);
            }

            static OpeningSize Door(OpeningKind openingKind, double width, double height, bool glazed, string source)
            {
                return new OpeningSize(openingKind, RoomUse.Other, width, height, null, glazed, 1, glazed ? 0.08 : 0.05, glazed ? 0.08 : 0.05, null, source);
            }

            OpeningSize door_Entrance = Door(OpeningKind.EntranceDoor, 1.00, 2.10, false, "Size: " + OpeningSizeSource_Default + " 1.00 x 2.10 m frame, giving the WT § 62 minimum of 0.9 x 2.0 m in the clear (" + OpeningSizeSource_WT + "); " + layout_Door);
            OpeningSize door_Staircase = Door(OpeningKind.StaircaseEntranceDoor, 1.40, 2.10, true, "Size: " + OpeningSizeSource_Default + " 1.40 x 2.10 m, the main leaf of a two-leaf door modelled as one glazed leaf, at least 0.9 m in the clear (" + OpeningSizeSource_WT + " § 62); " + layout_DoorGlazed);
            OpeningSize door_Unheated = Door(OpeningKind.DoorToUnheatedSpace, 0.90, 2.00, false, "Size: " + OpeningSizeSource_Default + " 0.90 x 2.00 m; " + layout_Door);
            OpeningSize door_Garage = Door(OpeningKind.GarageDoor, 2.50, 2.125, false, "Size: " + OpeningSizeSource_Default + " 2.50 x 2.125 m sectional door; " + layout_Door);
            OpeningSize roofWindow = new(OpeningKind.RoofWindow, RoomUse.Other, 0.78, 1.40, null, true, 1, 0.10, 0.10, null, "Size: " + OpeningSizeSource_Default + " 0.78 x 1.40 m, the common roof-window size of manufacturer catalogues; Layout: " + OpeningSizeSource_Default + " frame 0.10 m");

            static List<OpeningSize> Catalogue_Residential(bool pvc, bool balcony, bool bathroomWindow, string kitchenSymbol, double kitchenHeight)
            {
                List<OpeningSize> openingSizes =
                [
                    Catalogue(OpeningKind.Window, RoomUse.LivingRoom, "O34-O35 1465 x 1435, two sashes", 1.465, 1.435, 0.85, 2, pvc),
                    Catalogue(OpeningKind.Window, RoomUse.Kitchen, kitchenSymbol, 1.165, kitchenHeight, 0.85, 2, pvc),
                    Catalogue(OpeningKind.Window, RoomUse.Other, "O30-O31 865 x 1435, one sash", 0.865, 1.435, 0.85, 1, pvc),
                ];

                if (bathroomWindow)
                {
                    openingSizes.Add(Catalogue(OpeningKind.Window, RoomUse.Bathroom, "04 565 x 835, one sash", 0.565, 0.835, 1.40, 1, pvc, sill_High));
                }

                if (balcony)
                {
                    openingSizes.Add(Catalogue(OpeningKind.BalconyDoor, RoomUse.LivingRoom, "OB3-OB4 865 x 2095, one leaf", 0.865, 2.095, null, 1, pvc));
                }

                return openingSizes;
            }

            OpeningSizeSet Set(BuildingType buildingType, DateTimeOffset startDate, DateTimeOffset? endDate, string? system, bool defaultSystem, double storeyHeight, double? facadeModule, IEnumerable<OpeningSize> openingSizes, string? bathroomNone, string source)
            {
                return new OpeningSizeSet(buildingType, startDate, endDate, system, defaultSystem, storeyHeight, facadeModule, openingSizes, bathroomNone is null ? null : [RoomUse.Bathroom], bathroomNone is null ? source : source + "; Bathroom: " + bathroomNone);
            }

            // Single-family houses; terraced houses take the same sizes.
            List<(DateTimeOffset Start, DateTimeOffset? End, double StoreyHeight, List<OpeningSize> OpeningSizes, string Source)> singleFamily =
            [
                (DateTimeOffset.MinValue, Date(1918), 3.00,
                [
                    Window(RoomUse.LivingRoom, 1.00, 1.60, 0.80, 2, 0.12, 0.10, "Size: " + OpeningSizeSource_Default + " 1.00 x 1.60 m two-casement window; Sill: " + OpeningSizeSource_Default + " 0.80 m; Layout: " + OpeningSizeSource_Default + " two casements, frame 0.12 m, divider 0.10 m, no top light"),
                    Window(RoomUse.Kitchen, 0.80, 1.40, 0.90, 2, 0.12, 0.10, "Size: " + OpeningSizeSource_Default + " 0.80 x 1.40 m; Sill: " + OpeningSizeSource_Default + " 0.90 m; Layout: " + OpeningSizeSource_Default + " frame 0.12 m, divider 0.10 m"),
                    Window(RoomUse.Bathroom, 0.60, 0.90, 1.30, 1, 0.10, 0.10, "Size: " + OpeningSizeSource_Default + " 0.60 x 0.90 m; " + sill_High + "; Layout: " + OpeningSizeSource_Default + " frame 0.10 m"),
                    door_Entrance, door_Unheated, roofWindow,
                ], "StoreyHeight: " + OpeningSizeSource_Default + " 3.00 m"),
                (Date(1918), Date(1946), 3.00,
                [
                    Window(RoomUse.LivingRoom, 1.20, 1.50, 0.85, 2, 0.10, 0.10, "Size: " + OpeningSizeSource_Default + " 1.20 x 1.50 m two-sash window; " + sill + "; " + layout_Wood),
                    Window(RoomUse.Kitchen, 0.90, 1.40, 0.90, 2, 0.10, 0.10, "Size: " + OpeningSizeSource_Default + " 0.90 x 1.40 m; Sill: " + OpeningSizeSource_Default + " 0.90 m; " + layout_Wood),
                    Window(RoomUse.Bathroom, 0.60, 0.90, 1.30, 1, 0.10, 0.10, "Size: " + OpeningSizeSource_Default + " 0.60 x 0.90 m; " + sill_High + "; " + layout_Wood),
                    door_Entrance, door_Unheated, roofWindow,
                ], "StoreyHeight: " + OpeningSizeSource_Default + " 3.00 m; Windows: " + OpeningSizeSource_1928 + " windows of at least 1/10 of the floor area were required"),
                (Date(1946), Date(1967), 2.80, [.. Catalogue_Residential(false, false, true, "O16-O17 1165 x 1135, two sashes", 1.135), door_Entrance, door_Unheated, roofWindow], "StoreyHeight: " + OpeningSizeSource_Default + " 2.80 m; Sizes: " + OpeningSizeSource_Default + " catalogue sizes applied before the 1985 catalogue was issued"),
                (Date(1967), Date(1986), 2.80, [.. Catalogue_Residential(false, true, true, "O16-O17 1165 x 1135, two sashes", 1.135), door_Entrance, door_Unheated, door_Garage, roofWindow], "StoreyHeight: " + OpeningSizeSource_Default + " 2.80 m; Sizes: " + OpeningSizeSource_Default + " catalogue sizes applied before the 1985 catalogue was issued"),
                (Date(1986), Date(1993), 2.80, [.. Catalogue_Residential(false, true, true, "O16-O17 1165 x 1135, two sashes", 1.135), door_Entrance, door_Unheated, door_Garage, roofWindow], "StoreyHeight: " + OpeningSizeSource_Default + " 2.80 m"),
                (Date(1993), Date(2003), 2.80, [.. Catalogue_Residential(true, true, true, "O16-O17 1165 x 1135, two sashes", 1.135), door_Entrance, door_Unheated, door_Garage, roofWindow], "StoreyHeight: " + OpeningSizeSource_Default + " 2.80 m; Sizes: " + OpeningSizeSource_BN85 + " catalogue sizes, still the manufacturers' standard sizes (kb.pl 2023)"),
                (Date(2003), Date(2009), 2.90, [.. Catalogue_Residential(true, true, true, "O16-O17 1165 x 1135, two sashes", 1.135), door_Entrance, door_Unheated, door_Garage, roofWindow], "StoreyHeight: " + OpeningSizeSource_Default + " 2.90 m; Sizes: " + OpeningSizeSource_BN85 + " catalogue sizes, still the manufacturers' standard sizes (kb.pl 2023)"),
                (Date(2009), null, 2.90, [.. Catalogue_Residential(true, true, true, "O16-O17 1165 x 1135, two sashes", 1.135), door_Entrance, door_Unheated, door_Garage, roofWindow], "StoreyHeight: " + OpeningSizeSource_Default + " 2.90 m; Sizes: " + OpeningSizeSource_BN85 + " catalogue sizes, still the manufacturers' standard sizes (kb.pl 2023)"),
            ];

            foreach ((DateTimeOffset start, DateTimeOffset? end, double storeyHeight, List<OpeningSize> openingSizes, string source) in singleFamily)
            {
                result.Add(Set(BuildingType.SingleFamily, start, end, null, false, storeyHeight, null, openingSizes, null, source));
                result.Add(Set(BuildingType.Terraced, start, end, null, false, storeyHeight, null, openingSizes, null, source + "; Type: " + OpeningSizeSource_Default + " terraced houses take the single-family sizes"));
            }

            // Multi-family buildings; apartment blocks take the same sizes outside 1967-1985, and before 1967 TABULA has no apartment block.
            List<(DateTimeOffset Start, DateTimeOffset? End, double StoreyHeight, List<OpeningSize> OpeningSizes, string? BathroomNone, string Source)> multiFamily =
            [
                (DateTimeOffset.MinValue, Date(1918), 3.40,
                [
                    new OpeningSize(OpeningKind.Window, RoomUse.LivingRoom, 1.20, 2.20, 0.80, true, 2, 0.12, 0.10, 0.55, "Size: " + OpeningSizeSource_Default + " 1.20 x 2.20 m box window; Sill: " + OpeningSizeSource_Default + " 0.80 m; " + layout_Box),
                    new OpeningSize(OpeningKind.Window, RoomUse.Kitchen, 1.00, 2.00, 0.90, true, 2, 0.12, 0.10, 0.55, "Size: " + OpeningSizeSource_Default + " 1.00 x 2.00 m courtyard window; Sill: " + OpeningSizeSource_Default + " 0.90 m; " + layout_Box),
                    new OpeningSize(OpeningKind.StaircaseWindow, RoomUse.Staircase, 1.00, 2.00, 1.00, true, 2, 0.12, 0.10, 0.50, "Size: " + OpeningSizeSource_Default + " 1.00 x 2.00 m; Sill: " + OpeningSizeSource_Default + " 1.00 m above the landing; " + layout_Box.Replace("0.55 m", "0.50 m")),
                    new OpeningSize(OpeningKind.BalconyDoor, RoomUse.LivingRoom, 1.20, 2.80, null, true, 2, 0.12, 0.10, 0.60, "Size: " + OpeningSizeSource_Default + " 1.20 x 2.80 m; Sill: none; " + layout_Box.Replace("0.55 m", "0.60 m")),
                    new OpeningSize(OpeningKind.StaircaseEntranceDoor, RoomUse.Other, 1.80, 2.80, null, false, 2, 0.08, 0.08, null, "Size: " + OpeningSizeSource_Default + " 1.80 x 2.80 m two-leaf gate; " + layout_Door),
                    door_Unheated,
                ],
                OpeningSizeSource_Default + " WCs were small rooms on air shafts or later additions, so no window is modelled", "StoreyHeight: " + OpeningSizeSource_WAW + " at least 3.40 m (Warsaw building rules)"),
                (Date(1918), Date(1946), 3.10,
                [
                    new OpeningSize(OpeningKind.Window, RoomUse.LivingRoom, 1.45, 1.60, 0.85, true, 2, 0.10, 0.10, 0.40, "Size: " + OpeningSizeSource_Default + " 1.45 x 1.60 m; " + sill + "; Layout: " + OpeningSizeSource_Default + " two sashes below a 0.40 m top light, frame 0.10 m, divider 0.10 m"),
                    Window(RoomUse.Kitchen, 1.15, 1.45, 0.85, 2, 0.10, 0.10, "Size: " + OpeningSizeSource_Default + " 1.15 x 1.45 m; " + sill + "; " + layout_Wood),
                    Window(RoomUse.Bathroom, 0.60, 0.90, 1.30, 1, 0.10, 0.10, "Size: " + OpeningSizeSource_Default + " 0.60 x 0.90 m; " + sill_High + "; " + layout_Wood),
                    new OpeningSize(OpeningKind.StaircaseWindow, RoomUse.Staircase, 0.90, 1.60, 1.00, true, 1, 0.10, 0.10, null, "Size: " + OpeningSizeSource_Default + " 0.90 x 1.60 m; Sill: " + OpeningSizeSource_Default + " 1.00 m above the landing; " + layout_Wood),
                    new OpeningSize(OpeningKind.BalconyDoor, RoomUse.LivingRoom, 0.90, 2.30, null, true, 1, 0.10, 0.10, null, "Size: " + OpeningSizeSource_Default + " 0.90 x 2.30 m; Sill: none; " + layout_Wood),
                    door_Staircase, door_Unheated,
                ], null, "StoreyHeight: " + OpeningSizeSource_Default + " 3.10 m; Windows: " + OpeningSizeSource_1928 + " windows of at least 1/10 of the floor area were required"),
                (Date(1946), Date(1967), 2.90, [.. Catalogue_Residential(false, true, false, "O32-O33 1165 x 1435, two sashes", 1.435), Catalogue(OpeningKind.StaircaseWindow, RoomUse.Staircase, "O16-O17 1165 x 1135, two sashes", 1.165, 1.135, 1.00, 2, false), door_Staircase, door_Unheated], bathroom_Internal, "StoreyHeight: " + OpeningSizeSource_Default + " 2.90 m; Sizes: " + OpeningSizeSource_Default + " catalogue sizes applied before the 1985 catalogue was issued"),
                (Date(1967), Date(1986), 2.80, [.. Catalogue_Residential(false, true, false, "O32-O33 1165 x 1435, two sashes", 1.435), Catalogue(OpeningKind.StaircaseWindow, RoomUse.Staircase, "O16-O17 1165 x 1135, two sashes", 1.165, 1.135, 1.00, 2, false), door_Staircase, door_Unheated], bathroom_Internal, "StoreyHeight: " + OpeningSizeSource_Default + " 2.80 m; Sizes: " + OpeningSizeSource_Default + " catalogue sizes applied before the 1985 catalogue was issued"),
                (Date(1986), Date(1993), 2.80, [.. Catalogue_Residential(false, true, false, "O32-O33 1165 x 1435, two sashes", 1.435), Catalogue(OpeningKind.StaircaseWindow, RoomUse.Staircase, "O16-O17 1165 x 1135, two sashes", 1.165, 1.135, 1.00, 2, false), door_Staircase, door_Unheated], bathroom_Internal, "StoreyHeight: " + OpeningSizeSource_Default + " 2.80 m"),
                (Date(1993), Date(2003), 2.80, [.. Catalogue_Residential(true, true, false, "O32-O33 1165 x 1435, two sashes", 1.435), Catalogue(OpeningKind.StaircaseWindow, RoomUse.Staircase, "O16-O17 1165 x 1135, two sashes", 1.165, 1.135, 1.00, 2, true), door_Staircase, door_Unheated], bathroom_Internal, "StoreyHeight: " + OpeningSizeSource_Default + " 2.80 m; Sizes: " + OpeningSizeSource_BN85 + " catalogue sizes, still the manufacturers' standard sizes (kb.pl 2023)"),
                (Date(2003), Date(2009), 2.90, [.. Catalogue_Residential(true, true, false, "O32-O33 1165 x 1435, two sashes", 1.435), Catalogue(OpeningKind.StaircaseWindow, RoomUse.Staircase, "O16-O17 1165 x 1135, two sashes", 1.165, 1.135, 1.00, 2, true), door_Staircase, door_Unheated, door_Garage], bathroom_Internal, "StoreyHeight: " + OpeningSizeSource_Default + " 2.90 m; Sizes: " + OpeningSizeSource_BN85 + " catalogue sizes, still the manufacturers' standard sizes (kb.pl 2023)"),
                (Date(2009), null, 2.90, [.. Catalogue_Residential(true, true, false, "O32-O33 1165 x 1435, two sashes", 1.435), Catalogue(OpeningKind.StaircaseWindow, RoomUse.Staircase, "O16-O17 1165 x 1135, two sashes", 1.165, 1.135, 1.00, 2, true), door_Staircase, door_Unheated, door_Garage], bathroom_Internal, "StoreyHeight: " + OpeningSizeSource_Default + " 2.90 m; Sizes: " + OpeningSizeSource_BN85 + " catalogue sizes, still the manufacturers' standard sizes (kb.pl 2023)"),
            ];

            foreach ((DateTimeOffset start, DateTimeOffset? end, double storeyHeight, List<OpeningSize> openingSizes, string? bathroomNone, string source) in multiFamily)
            {
                result.Add(Set(BuildingType.MultiFamily, start, end, null, false, storeyHeight, null, openingSizes, bathroomNone, source));
                if (start != Date(1967))
                {
                    string source_ApartmentBlock = start < Date(1967) ? "; Type: " + OpeningSizeSource_Default + " TABULA has no apartment block before 1967, so the multi-family sizes apply" : "; Type: " + OpeningSizeSource_Default + " apartment blocks take the multi-family sizes";
                    result.Add(Set(BuildingType.ApartmentBlock, start, end, null, false, storeyHeight, null, openingSizes, bathroomNone, source + source_ApartmentBlock));
                }
            }

            // Large-panel apartment blocks of 1967-1985, one set per system.
            List<OpeningSize> Panel(string livingSymbol, double livingWidth, int livingColumns, string kitchenSymbol, double kitchenWidth, int kitchenColumns)
            {
                return
                [
                    Catalogue(OpeningKind.Window, RoomUse.LivingRoom, livingSymbol, livingWidth, 1.435, 0.85, livingColumns, false),
                    Catalogue(OpeningKind.Window, RoomUse.Kitchen, kitchenSymbol, kitchenWidth, 1.435, 0.85, kitchenColumns, false),
                    Catalogue(OpeningKind.Window, RoomUse.Other, kitchenSymbol, kitchenWidth, 1.435, 0.85, kitchenColumns, false),
                    Catalogue(OpeningKind.StaircaseWindow, RoomUse.Staircase, "O16-O17 1165 x 1135, two sashes", 1.165, 1.135, 1.00, 2, false),
                    Catalogue(OpeningKind.BalconyDoor, RoomUse.LivingRoom, "OB3-OB4 865 x 2095, one leaf", 0.865, 2.095, null, 1, false),
                    door_Staircase,
                    door_Unheated,
                ];
            }

            List<(string System, bool Default, double StoreyHeight, string StoreyHeightSource, double FacadeModule, string FacadeModuleSource, List<OpeningSize> OpeningSizes)> panels =
            [
                ("W-70", true, 2.80, OpeningSizeSource_ITB + " 280 cm", 0.60, OpeningSizeSource_ITB + " M = 60 cm", Panel("O36-O37 1765 x 1435, two sashes", 1.765, 2, "O32-O33 1165 x 1435, two sashes", 1.165, 2)),
                ("Wk-70", false, 3.30, OpeningSizeSource_ITB + " 330 cm storey of the Wk-70 variant", 0.60, OpeningSizeSource_ITB + " M = 60 cm", Panel("O36-O37 1765 x 1435, two sashes", 1.765, 2, "O32-O33 1165 x 1435, two sashes", 1.165, 2)),
                ("Szczecin", false, 2.80, OpeningSizeSource_ITB + " 280 cm", 0.60, OpeningSizeSource_ITB + " grid n x 240 x 480 cm, of which 0.60 m is a quarter", Panel("O36-O37 1765 x 1435, two sashes", 1.765, 2, "O32-O33 1165 x 1435, two sashes", 1.165, 2)),
                ("OWT-67", false, 2.70, OpeningSizeSource_OWT + " 270 cm; WindowHeight: " + OpeningSizeSource_ITB + " 1.50 m band between the 120 cm spandrel elements, less the 65 mm fitting gap", 0.30, OpeningSizeSource_ITB + " modules 540 x 480 and 480 x 270 cm, multiples of 0.30 m", Panel("OW11 2065 x 1435, three sashes", 2.065, 3, "O32-O33 1165 x 1435, two sashes", 1.165, 2)),
                ("OWT-75", false, 2.80, OpeningSizeSource_ITB + " 280 cm", 0.30, OpeningSizeSource_ITB + " OWT modules, multiples of 0.30 m", Panel("OW11 2065 x 1435, three sashes", 2.065, 3, "O32-O33 1165 x 1435, two sashes", 1.165, 2)),
                ("WUF-T", false, 2.70, OpeningSizeSource_ITB + " 270 cm", 1.50, OpeningSizeSource_ITB + " grid n x 150 x 480 cm", Panel("O34-O35 1465 x 1435, two sashes", 1.465, 2, "O34-O35 1465 x 1435, two sashes", 1.465, 2)),
            ];

            foreach ((string system, bool defaultSystem, double storeyHeight, string storeyHeightSource, double facadeModule, string facadeModuleSource, List<OpeningSize> openingSizes) in panels)
            {
                result.Add(Set(BuildingType.ApartmentBlock, Date(1967), Date(1986), system, defaultSystem, storeyHeight, facadeModule, openingSizes, bathroom_Internal, "System: " + OpeningSizeSource_ITB + " " + system + (defaultSystem ? ", the default system" : string.Empty) + "; StoreyHeight: " + storeyHeightSource + "; FacadeModule: " + facadeModuleSource + "; Sizes: " + OpeningSizeSource_BN85 + " catalogue windows whose width plus the 35 mm gap is a multiple of the module"));
            }

            return result;
        }
    }
}
