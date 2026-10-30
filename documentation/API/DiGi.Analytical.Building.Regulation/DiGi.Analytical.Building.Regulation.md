#### [DiGi\.Analytical\.Building\.Regulation](DiGi.Analytical.Building.Regulation.Overview.md 'DiGi\.Analytical\.Building\.Regulation\.Overview')

## DiGi\.Analytical\.Building\.Regulation Namespace
### Classes

<a name='DiGi.Analytical.Building.Regulation.Create'></a>

## Create Class

```csharp
public static class Create
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Create
### Fields

<a name='DiGi.Analytical.Building.Regulation.Create.ConstructionLibrary_PL_RetrievalDate'></a>

## Create\.ConstructionLibrary\_PL\_RetrievalDate Field

The date the TABULA values of [ConstructionLibrary\_PL\(\)](DiGi.Analytical.Building.Regulation.md#DiGi.Analytical.Building.Regulation.Create.ConstructionLibrary_PL() 'DiGi\.Analytical\.Building\.Regulation\.Create\.ConstructionLibrary\_PL\(\)') were read from the TABULA web tool\.

```csharp
public const string ConstructionLibrary_PL_RetrievalDate = "2026-10-30";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.Regulation.Create.ConstructionLibrary_PL_Version'></a>

## Create\.ConstructionLibrary\_PL\_Version Field

The version of the library [ConstructionLibrary\_PL\(\)](DiGi.Analytical.Building.Regulation.md#DiGi.Analytical.Building.Regulation.Create.ConstructionLibrary_PL() 'DiGi\.Analytical\.Building\.Regulation\.Create\.ConstructionLibrary\_PL\(\)') creates\. Raise it whenever a value changes\.

```csharp
public const string ConstructionLibrary_PL_Version = "1.1.0";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.Regulation.Create.OpeningSizeLibrary_PL_RetrievalDate'></a>

## Create\.OpeningSizeLibrary\_PL\_RetrievalDate Field

The date the sources of [OpeningSizeLibrary\_PL\(\)](DiGi.Analytical.Building.Regulation.md#DiGi.Analytical.Building.Regulation.Create.OpeningSizeLibrary_PL() 'DiGi\.Analytical\.Building\.Regulation\.Create\.OpeningSizeLibrary\_PL\(\)') were read\.

```csharp
public const string OpeningSizeLibrary_PL_RetrievalDate = "2026-10-30";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.Regulation.Create.OpeningSizeLibrary_PL_Version'></a>

## Create\.OpeningSizeLibrary\_PL\_Version Field

The version of the library [OpeningSizeLibrary\_PL\(\)](DiGi.Analytical.Building.Regulation.md#DiGi.Analytical.Building.Regulation.Create.OpeningSizeLibrary_PL() 'DiGi\.Analytical\.Building\.Regulation\.Create\.OpeningSizeLibrary\_PL\(\)') creates\. Raise it whenever a value changes\.

```csharp
public const string OpeningSizeLibrary_PL_Version = "1.0.0";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.Regulation.Create.OpeningSizeSource_1928'></a>

## Create\.OpeningSizeSource\_1928 Field

The source tag of a value from the building regulation of 1928, Dz\.U\. 1928 nr 23 poz\. 202 \(consolidated text Dz\.U\. 1939 nr 34 poz\. 216\), in force until 1961: windows of at least 1/10 of the floor area, as cited by DiGi\-Organization/DiGi\.GIS\.Analytical\#2\.

```csharp
public const string OpeningSizeSource_1928 = "PL-1928";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.Regulation.Create.OpeningSizeSource_BN85'></a>

## Create\.OpeningSizeSource\_BN85 Field

The source tag of a value from the catalogue of typical windows and balcony doors BN\-85/7153\-02 \(40 window and 12 balcony\-door types\), read through its reproduction on kb\.pl \(2023\) and muratorplus; the BN text itself was not read\. Frame sizes are on a 300 mm module less a 35 mm fitting gap in width and 65 mm in height\.

```csharp
public const string OpeningSizeSource_BN85 = "PL-BN85";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.Regulation.Create.OpeningSizeSource_Default'></a>

## Create\.OpeningSizeSource\_Default Field

The source tag of an uncited value, to be calibrated \(façade imagery, DiGi\-Organization/DiGi\.GIS\.Analytical\#2\)\.

```csharp
public const string OpeningSizeSource_Default = "DEFAULT";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.Regulation.Create.OpeningSizeSource_ITB'></a>

## Create\.OpeningSizeSource\_ITB Field

The source tag of a value from ITB, "Diagnostyka budynków wielkopłytowych", training materials, 2019: modules, axis spacing and storey heights of the W\-70, Wk\-70, Szczecin, OWT\-67, OWT\-75 and WUF\-T large\-panel systems\.

```csharp
public const string OpeningSizeSource_ITB = "PL-ITB";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.Regulation.Create.OpeningSizeSource_OWT'></a>

## Create\.OpeningSizeSource\_OWT Field

The source tag of the OWT\-67 gross storey height of 270 cm, from pl\.wikipedia\.org "OWT\-67" \(rev\. 72638965, 2024\-01\-21\); ITB gives only the 280 cm of OWT\-75\.

```csharp
public const string OpeningSizeSource_OWT = "PL-OWT";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.Regulation.Create.OpeningSizeSource_ROG'></a>

## Create\.OpeningSizeSource\_ROG Field

The source tag of a pane layout from J\. Roguska, "Okna i ich oprawa architektoniczna w warszawskich kamienicach w drugiej połowie XIX i na początku XX wieku", Kwartalnik Architektury i Urbanistyki 56\(1\), 2011: two casements below a fixed transom with a top light, box windows from about 1900\. The article gives no dimensions\.

```csharp
public const string OpeningSizeSource_ROG = "PL-ROG";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.Regulation.Create.OpeningSizeSource_WAW'></a>

## Create\.OpeningSizeSource\_WAW Field

The source tag of a value from Fundacja Hereditas, "Warszawskie kamienice przełomu XIX i XX w\." \(2024\): the Warsaw building rules required residential storeys of at least 340 cm \(p\. 22\)\.

```csharp
public const string OpeningSizeSource_WAW = "PL-WAW";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.Regulation.Create.OpeningSizeSource_WT'></a>

## Create\.OpeningSizeSource\_WT Field

The source tag of a value from the technical conditions, Dz\.U\. 2022 poz\. 1225: § 62 \(an entrance door at least 0\.9 × 2\.0 m in the clear\) and § 223 \(a 0\.8 m interstorey strip\)\.

```csharp
public const string OpeningSizeSource_WT = "PL-WT";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')
### Methods

<a name='DiGi.Analytical.Building.Regulation.Create.ConstructionLibrary_PL()'></a>

## Create\.ConstructionLibrary\_PL\(\) Method

Creates the Polish construction library: declared\-U constructions of residential buildings, chosen per building type and date by [ConstructionSet](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionSet 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionSet')s \(DiGi\-Organization/DiGi\.Analytical\#15\)\.

[TypicalAsBuilt](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour.TypicalAsBuilt 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionFlavour\.TypicalAsBuilt') sets hold the constructions of the Polish national typology of the TABULA web tool (webtool.building-typology.eu), one set per TABULA building: 7 construction periods for single-family, terraced and multi-family buildings, 5 for apartment blocks. TABULA has no apartment block before 1967, so for those periods the set holds the multi-family constructions. The values are those published, read on [ConstructionLibrary\_PL\_RetrievalDate](DiGi.Analytical.Building.Regulation.md#DiGi.Analytical.Building.Regulation.Create.ConstructionLibrary_PL_RetrievalDate 'DiGi\.Analytical\.Building\.Regulation\.Create\.ConstructionLibrary\_PL\_RetrievalDate'). There is one construction per TABULA construction code, and its description names the code.

Each TypicalAsBuilt set also carries the building's [TypologyData](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.TypologyData 'DiGi\.Analytical\.Building\.Regulation\.Classes\.TypologyData') (DiGi-Organization/DiGi.Analytical#17): frame area fraction, thermal bridging surcharge, floor boundary, the additional resistance of an unheated cellar, roof type, b_tr,floor, F_w and the attached neighbours. A floor construction carries the construction's own U. TABULA publishes the floor U of a building over an unheated cellar with R = 0.3 m2K/W included, so the same construction code appeared with two U-values; since version 1.1.0 that resistance is [AdditionalFloorResistance](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.TypologyData.AdditionalFloorResistance 'DiGi\.Analytical\.Building\.Regulation\.Classes\.TypologyData\.AdditionalFloorResistance') instead.

[Regulation](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour.Regulation 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionFlavour\.Regulation') sets hold, for every stage of the technical conditions in [DiGi\.Analytical\.Building\.HVAC\.Create\.RegulatedHeatTransferCoefficientsManager](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.hvac.create.regulatedheattransfercoefficientsmanager 'DiGi\.Analytical\.Building\.HVAC\.Create\.RegulatedHeatTransferCoefficientsManager') (1998-04-29 onwards), one construction per role whose declared U is the U(max) of [RegulatedHeatTransferCoefficient\(this IRegulatedHeatTransferCoefficients, ConstructionRole, BuildingType, ClimateZone, bool\)](DiGi.Analytical.Building.Regulation.md#DiGi.Analytical.Building.Regulation.Query.RegulatedHeatTransferCoefficient(thisDiGi.Analytical.Building.HVAC.Interfaces.IRegulatedHeatTransferCoefficients,DiGi.Analytical.Building.Regulation.Enums.ConstructionRole,DiGi.Analytical.Building.Regulation.Enums.BuildingType,DiGi.Analytical.Building.Regulation.Enums.ClimateZone,bool) 'DiGi\.Analytical\.Building\.Regulation\.Query\.RegulatedHeatTransferCoefficient\(this DiGi\.Analytical\.Building\.HVAC\.Interfaces\.IRegulatedHeatTransferCoefficients, DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionRole, DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType, DiGi\.Analytical\.Building\.Regulation\.Enums\.ClimateZone, bool\)'). A role with no limit has no construction, and the set's source says why. Until 2013 the window limits depend on the climatic zone, so those stages have a set for every zone (the zone I-III windows) plus sets for zones IV and V.

The constructions carry declared values only: no layers, and window and door constructions have no outline, so they are cloned with one where an opening needs it. Every identifier is derived from a stable key, so the library serializes to the same text each time it is created: the embedded copy read by [EmbeddedConstructionLibrary\_PL\(\)](DiGi.Analytical.Building.Regulation.md#DiGi.Analytical.Building.Regulation.Query.EmbeddedConstructionLibrary_PL() 'DiGi\.Analytical\.Building\.Regulation\.Query\.EmbeddedConstructionLibrary\_PL\(\)') is this method's output.

```csharp
public static DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary ConstructionLibrary_PL();
```

#### Returns
[ConstructionLibrary](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionLibrary')  
The Polish construction library\.

<a name='DiGi.Analytical.Building.Regulation.Create.DoorConstruction(thisDiGi.Analytical.Building.Regulation.Classes.OpeningSize,string,double)'></a>

## Create\.DoorConstruction\(this OpeningSize, string, double\) Method

Creates the door construction of an opening size: its frame outline, with the panes of [Panes\(this OpeningSize\)](DiGi.Analytical.Building.Regulation.md#DiGi.Analytical.Building.Regulation.Query.Panes(thisDiGi.Analytical.Building.Regulation.Classes.OpeningSize) 'DiGi\.Analytical\.Building\.Regulation\.Query\.Panes\(this DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSize\)') as holes when the door is glazed and as a plain outline when it is opaque \(DiGi\-Organization/DiGi\.GIS\.Analytical\#6\)\.

The construction has the geometry only. The thermal values are those of the door construction of the building's construction set, which the caller copies onto it.

```csharp
public static DiGi.Analytical.Building.Classes.DoorConstruction? DoorConstruction(this DiGi.Analytical.Building.Regulation.Classes.OpeningSize? openingSize, string? name=null, double tolerance=1E-06);
```
#### Parameters

<a name='DiGi.Analytical.Building.Regulation.Create.DoorConstruction(thisDiGi.Analytical.Building.Regulation.Classes.OpeningSize,string,double).openingSize'></a>

`openingSize` [OpeningSize](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSize 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSize')

The opening size\.

<a name='DiGi.Analytical.Building.Regulation.Create.DoorConstruction(thisDiGi.Analytical.Building.Regulation.Classes.OpeningSize,string,double).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the construction; null gives [ConstructionName\(this OpeningSize\)](DiGi.Analytical.Building.Regulation.md#DiGi.Analytical.Building.Regulation.Query.ConstructionName(thisDiGi.Analytical.Building.Regulation.Classes.OpeningSize) 'DiGi\.Analytical\.Building\.Regulation\.Query\.ConstructionName\(this DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSize\)')\.

<a name='DiGi.Analytical.Building.Regulation.Create.DoorConstruction(thisDiGi.Analytical.Building.Regulation.Classes.OpeningSize,string,double).tolerance'></a>

`tolerance` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The distance tolerance\.

#### Returns
[DiGi\.Analytical\.Building\.Classes\.DoorConstruction](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.doorconstruction 'DiGi\.Analytical\.Building\.Classes\.DoorConstruction')  
The [DiGi\.Analytical\.Building\.Classes\.DoorConstruction](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.doorconstruction 'DiGi\.Analytical\.Building\.Classes\.DoorConstruction'), or null when [openingSize](DiGi.Analytical.Building.Regulation.md#DiGi.Analytical.Building.Regulation.Create.DoorConstruction(thisDiGi.Analytical.Building.Regulation.Classes.OpeningSize,string,double).openingSize 'DiGi\.Analytical\.Building\.Regulation\.Create\.DoorConstruction\(this DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSize, string, double\)\.openingSize') is null or its outline and panes do not make a valid face\.

<a name='DiGi.Analytical.Building.Regulation.Create.OpeningSizeLibrary_PL()'></a>

## Create\.OpeningSizeLibrary\_PL\(\) Method

Creates the Polish opening size library: window and door sizes and glazing layouts of residential buildings per building type, date range and large\-panel system \(DiGi\-Organization/DiGi\.GIS\.Analytical\#6\)\.

<b>Ranges.</b> The TABULA construction periods of [ConstructionPeriod\(Nullable&lt;short&gt;\)](DiGi.Analytical.Building.Regulation.md#DiGi.Analytical.Building.Regulation.Query.ConstructionPeriod(System.Nullable_short_) 'DiGi\.Analytical\.Building\.Regulation\.Query\.ConstructionPeriod\(System\.Nullable\<short\>\)'), with "until 1945" split at 1918 into tenements (tall box windows, storeys of 3.40 m and more) and inter-war modernism. TABULA has no apartment block before 1967, so those ranges repeat the multi-family sizes; terraced houses repeat the single-family sizes.

<b>Large-panel systems.</b> Apartment blocks of 1967-1985 have one set per system - W-70 (the default a lookup without a system returns), Wk-70, Szczecin, OWT-67, OWT-75 and WUF-T - with the storey height and module of the system. Window widths plus the 35 mm fitting gap of the catalogue are multiples of the system's module, and the OWT-67 window height is its 1.50 m band between the 1.20 m spandrel elements less the 65 mm gap.

<b>Sources.</b> Every [Source](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSize.Source 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSize\.Source') and [Source](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.Source 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSizeSet\.Source') is a list of "Quantity: TAG detail" items separated by "; ", with the tags [OpeningSizeSource\_BN85](DiGi.Analytical.Building.Regulation.md#DiGi.Analytical.Building.Regulation.Create.OpeningSizeSource_BN85 'DiGi\.Analytical\.Building\.Regulation\.Create\.OpeningSizeSource\_BN85'), [OpeningSizeSource\_ITB](DiGi.Analytical.Building.Regulation.md#DiGi.Analytical.Building.Regulation.Create.OpeningSizeSource_ITB 'DiGi\.Analytical\.Building\.Regulation\.Create\.OpeningSizeSource\_ITB'), [OpeningSizeSource\_OWT](DiGi.Analytical.Building.Regulation.md#DiGi.Analytical.Building.Regulation.Create.OpeningSizeSource_OWT 'DiGi\.Analytical\.Building\.Regulation\.Create\.OpeningSizeSource\_OWT'), [OpeningSizeSource\_WAW](DiGi.Analytical.Building.Regulation.md#DiGi.Analytical.Building.Regulation.Create.OpeningSizeSource_WAW 'DiGi\.Analytical\.Building\.Regulation\.Create\.OpeningSizeSource\_WAW'), [OpeningSizeSource\_ROG](DiGi.Analytical.Building.Regulation.md#DiGi.Analytical.Building.Regulation.Create.OpeningSizeSource_ROG 'DiGi\.Analytical\.Building\.Regulation\.Create\.OpeningSizeSource\_ROG'), [OpeningSizeSource\_1928](DiGi.Analytical.Building.Regulation.md#DiGi.Analytical.Building.Regulation.Create.OpeningSizeSource_1928 'DiGi\.Analytical\.Building\.Regulation\.Create\.OpeningSizeSource\_1928'), [OpeningSizeSource\_WT](DiGi.Analytical.Building.Regulation.md#DiGi.Analytical.Building.Regulation.Create.OpeningSizeSource_WT 'DiGi\.Analytical\.Building\.Regulation\.Create\.OpeningSizeSource\_WT') and [OpeningSizeSource\_Default](DiGi.Analytical.Building.Regulation.md#DiGi.Analytical.Building.Regulation.Create.OpeningSizeSource_Default 'DiGi\.Analytical\.Building\.Regulation\.Create\.OpeningSizeSource\_Default'). The catalogue sizes are tagged BN-85 even where they are used before 1985, when the set's source says so. Frame and divider widths, sill heights and the pre-1946 dimensions are defaults to calibrate.

The library is built from constants only, so it serializes to the same text each time it is created.

```csharp
public static DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary OpeningSizeLibrary_PL();
```

#### Returns
[OpeningSizeLibrary](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSizeLibrary')  
The Polish opening size library\.

<a name='DiGi.Analytical.Building.Regulation.Create.WindowConstruction(thisDiGi.Analytical.Building.Regulation.Classes.OpeningSize,string,double)'></a>

## Create\.WindowConstruction\(this OpeningSize, string, double\) Method

Creates the window construction of an opening size: its frame outline as a face whose holes are the panes of [Panes\(this OpeningSize\)](DiGi.Analytical.Building.Regulation.md#DiGi.Analytical.Building.Regulation.Query.Panes(thisDiGi.Analytical.Building.Regulation.Classes.OpeningSize) 'DiGi\.Analytical\.Building\.Regulation\.Query\.Panes\(this DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSize\)') \(DiGi\-Organization/DiGi\.GIS\.Analytical\#6\)\.

The construction has the geometry only. The thermal and optical values (U, g, τv) are those of the window construction of the building's construction set, which the caller copies onto it.

```csharp
public static DiGi.Analytical.Building.Classes.WindowConstruction? WindowConstruction(this DiGi.Analytical.Building.Regulation.Classes.OpeningSize? openingSize, string? name=null, double tolerance=1E-06);
```
#### Parameters

<a name='DiGi.Analytical.Building.Regulation.Create.WindowConstruction(thisDiGi.Analytical.Building.Regulation.Classes.OpeningSize,string,double).openingSize'></a>

`openingSize` [OpeningSize](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSize 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSize')

The opening size\.

<a name='DiGi.Analytical.Building.Regulation.Create.WindowConstruction(thisDiGi.Analytical.Building.Regulation.Classes.OpeningSize,string,double).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the construction; null gives [ConstructionName\(this OpeningSize\)](DiGi.Analytical.Building.Regulation.md#DiGi.Analytical.Building.Regulation.Query.ConstructionName(thisDiGi.Analytical.Building.Regulation.Classes.OpeningSize) 'DiGi\.Analytical\.Building\.Regulation\.Query\.ConstructionName\(this DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSize\)')\.

<a name='DiGi.Analytical.Building.Regulation.Create.WindowConstruction(thisDiGi.Analytical.Building.Regulation.Classes.OpeningSize,string,double).tolerance'></a>

`tolerance` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The distance tolerance\.

#### Returns
[DiGi\.Analytical\.Building\.Classes\.WindowConstruction](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.windowconstruction 'DiGi\.Analytical\.Building\.Classes\.WindowConstruction')  
The [DiGi\.Analytical\.Building\.Classes\.WindowConstruction](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.windowconstruction 'DiGi\.Analytical\.Building\.Classes\.WindowConstruction'), or null when [openingSize](DiGi.Analytical.Building.Regulation.md#DiGi.Analytical.Building.Regulation.Create.WindowConstruction(thisDiGi.Analytical.Building.Regulation.Classes.OpeningSize,string,double).openingSize 'DiGi\.Analytical\.Building\.Regulation\.Create\.WindowConstruction\(this DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSize, string, double\)\.openingSize') is null or its outline and panes do not make a valid face\.

<a name='DiGi.Analytical.Building.Regulation.Query'></a>

## Query Class

```csharp
public static class Query
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Query
### Fields

<a name='DiGi.Analytical.Building.Regulation.Query.EmbeddedConstructionLibrary_PL_ResourceName'></a>

## Query\.EmbeddedConstructionLibrary\_PL\_ResourceName Field

The manifest name of the embedded copy of the Polish construction library read by [EmbeddedConstructionLibrary\_PL\(\)](DiGi.Analytical.Building.Regulation.md#DiGi.Analytical.Building.Regulation.Query.EmbeddedConstructionLibrary_PL() 'DiGi\.Analytical\.Building\.Regulation\.Query\.EmbeddedConstructionLibrary\_PL\(\)')\.

```csharp
public const string EmbeddedConstructionLibrary_PL_ResourceName = "DiGi.Analytical.Building.Regulation.Resources.ConstructionLibrary_PL.json";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')
### Methods

<a name='DiGi.Analytical.Building.Regulation.Query.BuildingRegulation(System.Nullable_short_,int)'></a>

## Query\.BuildingRegulation\(Nullable\<short\>, int\) Method

Determines the building regulation regime a building was designed under, from its year built \(DiGi\-Organization/DiGi\.Analytical\#8\)\.

The year built is a completion year, so the regime is selected for [year](DiGi.Analytical.Building.Regulation.md#DiGi.Analytical.Building.Regulation.Query.BuildingRegulation(System.Nullable_short_,int).year 'DiGi\.Analytical\.Building\.Regulation\.Query\.BuildingRegulation\(System\.Nullable\<short\>, int\)\.year') − [designLag](DiGi.Analytical.Building.Regulation.md#DiGi.Analytical.Building.Regulation.Query.BuildingRegulation(System.Nullable_short_,int).designLag 'DiGi\.Analytical\.Building\.Regulation\.Query\.BuildingRegulation\(System\.Nullable\<short\>, int\)\.designLag'). By design year: before 1928 [PL\_Before1928](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation.PL_Before1928 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingRegulation\.PL\_Before1928'); 1928-1960 [PL\_1928](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation.PL_1928 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingRegulation\.PL\_1928'); 1961-1979 [PL\_1961](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation.PL_1961 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingRegulation\.PL\_1961'); 1980-1994 [PL\_1980](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation.PL_1980 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingRegulation\.PL\_1980'); 1995-2002 [PL\_1994](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation.PL_1994 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingRegulation\.PL\_1994'); 2003-2008 [PL\_WT2002](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation.PL_WT2002 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingRegulation\.PL\_WT2002'); 2009-2013 [PL\_WT2009](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation.PL_WT2009 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingRegulation\.PL\_WT2009'); 2014-2016 [PL\_WT2014](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation.PL_WT2014 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingRegulation\.PL\_WT2014'); 2017-2020 [PL\_WT2017](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation.PL_WT2017 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingRegulation\.PL\_WT2017'); from 2021 [PL\_WT2021](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation.PL_WT2021 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingRegulation\.PL\_WT2021'). A regime that started within a year (WT 2002 on 16 December 2002, the last stage on 31 December 2020) is assigned from the following year.

```csharp
public static DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation BuildingRegulation(System.Nullable<short> year, int designLag=2);
```
#### Parameters

<a name='DiGi.Analytical.Building.Regulation.Query.BuildingRegulation(System.Nullable_short_,int).year'></a>

`year` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int16](https://learn.microsoft.com/en-us/dotnet/api/system.int16 'System\.Int16')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The year built\. This value can be null\.

<a name='DiGi.Analytical.Building.Regulation.Query.BuildingRegulation(System.Nullable_short_,int).designLag'></a>

`designLag` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of years between design and completion\.

#### Returns
[BuildingRegulation](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingRegulation')  
The regime, or [Undefined](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation.Undefined 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingRegulation\.Undefined') when [year](DiGi.Analytical.Building.Regulation.md#DiGi.Analytical.Building.Regulation.Query.BuildingRegulation(System.Nullable_short_,int).year 'DiGi\.Analytical\.Building\.Regulation\.Query\.BuildingRegulation\(System\.Nullable\<short\>, int\)\.year') is null\.

<a name='DiGi.Analytical.Building.Regulation.Query.ConstructionName(thisDiGi.Analytical.Building.Regulation.Classes.OpeningSize)'></a>

## Query\.ConstructionName\(this OpeningSize\) Method

Gets the default name of the window or door construction made from an opening size: the opening kind and the frame outline in millimetres, for example "Window 1465x1435" \(DiGi\-Organization/DiGi\.GIS\.Analytical\#6\)\.

```csharp
public static string? ConstructionName(this DiGi.Analytical.Building.Regulation.Classes.OpeningSize? openingSize);
```
#### Parameters

<a name='DiGi.Analytical.Building.Regulation.Query.ConstructionName(thisDiGi.Analytical.Building.Regulation.Classes.OpeningSize).openingSize'></a>

`openingSize` [OpeningSize](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSize 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSize')

The opening size\.

#### Returns
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')  
The name, or null when [openingSize](DiGi.Analytical.Building.Regulation.md#DiGi.Analytical.Building.Regulation.Query.ConstructionName(thisDiGi.Analytical.Building.Regulation.Classes.OpeningSize).openingSize 'DiGi\.Analytical\.Building\.Regulation\.Query\.ConstructionName\(this DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSize\)\.openingSize') is null\.

<a name='DiGi.Analytical.Building.Regulation.Query.ConstructionPeriod(System.Nullable_short_)'></a>

## Query\.ConstructionPeriod\(Nullable\<short\>\) Method

Determines the TABULA / NAPE construction period of a building from its year built \(DiGi\-Organization/DiGi\.Analytical\#8\)\.

The periods are of construction, so - unlike [BuildingRegulation\(Nullable&lt;short&gt;, int\)](DiGi.Analytical.Building.Regulation.md#DiGi.Analytical.Building.Regulation.Query.BuildingRegulation(System.Nullable_short_,int) 'DiGi\.Analytical\.Building\.Regulation\.Query\.BuildingRegulation\(System\.Nullable\<short\>, int\)') - no design lag applies.

```csharp
public static DiGi.Analytical.Building.Regulation.Enums.ConstructionPeriod ConstructionPeriod(System.Nullable<short> year);
```
#### Parameters

<a name='DiGi.Analytical.Building.Regulation.Query.ConstructionPeriod(System.Nullable_short_).year'></a>

`year` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int16](https://learn.microsoft.com/en-us/dotnet/api/system.int16 'System\.Int16')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The year built\. This value can be null\.

#### Returns
[ConstructionPeriod](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.ConstructionPeriod 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionPeriod')  
The construction period, or [Undefined](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.ConstructionPeriod.Undefined 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionPeriod\.Undefined') when [year](DiGi.Analytical.Building.Regulation.md#DiGi.Analytical.Building.Regulation.Query.ConstructionPeriod(System.Nullable_short_).year 'DiGi\.Analytical\.Building\.Regulation\.Query\.ConstructionPeriod\(System\.Nullable\<short\>\)\.year') is null\.

<a name='DiGi.Analytical.Building.Regulation.Query.EmbeddedConstructionLibrary_PL()'></a>

## Query\.EmbeddedConstructionLibrary\_PL\(\) Method

Reads the Polish construction library embedded in this assembly \(DiGi\-Organization/DiGi\.Analytical\#15\)\.

The embedded file is the serialized output of [ConstructionLibrary\_PL\(\)](DiGi.Analytical.Building.Regulation.md#DiGi.Analytical.Building.Regulation.Create.ConstructionLibrary_PL() 'DiGi\.Analytical\.Building\.Regulation\.Create\.ConstructionLibrary\_PL\(\)'), kept beside the code so that a consumer reads one versioned file rather than rebuilding the library. The `ConstructionLibrary_PL_Resource` fact fails whenever the two differ.

```csharp
public static DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary? EmbeddedConstructionLibrary_PL();
```

#### Returns
[ConstructionLibrary](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionLibrary')  
A new [ConstructionLibrary](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionLibrary') read from the embedded file, or null when the file is missing or cannot be read\.

<a name='DiGi.Analytical.Building.Regulation.Query.IsCompliant(thisdouble,double,double)'></a>

## Query\.IsCompliant\(this double, double, double\) Method

Determines whether a thermal transmittance meets a maximum heat transfer coefficient: U ≤ U\(max\) within the tolerance \(DiGi\-Organization/DiGi\.Analytical\#8\)\.

A missing value on either side is never a pass: where the regulation sets no limit (U(max) NaN) or U cannot be determined, the result is false and the case is for the caller to report.

```csharp
public static bool IsCompliant(this double thermalTransmittance, double regulatedHeatTransferCoefficient, double tolerance=1E-06);
```
#### Parameters

<a name='DiGi.Analytical.Building.Regulation.Query.IsCompliant(thisdouble,double,double).thermalTransmittance'></a>

`thermalTransmittance` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The thermal transmittance U \[W/\(m2K\)\]\.

<a name='DiGi.Analytical.Building.Regulation.Query.IsCompliant(thisdouble,double,double).regulatedHeatTransferCoefficient'></a>

`regulatedHeatTransferCoefficient` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The maximum heat transfer coefficient U\(max\) \[W/\(m2K\)\]\.

<a name='DiGi.Analytical.Building.Regulation.Query.IsCompliant(thisdouble,double,double).tolerance'></a>

`tolerance` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The tolerance by which U may exceed U\(max\)\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if U ≤ U\(max\) \+ [tolerance](DiGi.Analytical.Building.Regulation.md#DiGi.Analytical.Building.Regulation.Query.IsCompliant(thisdouble,double,double).tolerance 'DiGi\.Analytical\.Building\.Regulation\.Query\.IsCompliant\(this double, double, double\)\.tolerance'); otherwise, false, also when either value is NaN\.

<a name='DiGi.Analytical.Building.Regulation.Query.OpeningConstructionRole(thisDiGi.Analytical.Building.Regulation.Enums.OpeningKind)'></a>

## Query\.OpeningConstructionRole\(this OpeningKind\) Method

Gets the role of the construction an opening of the specified kind takes from a construction set \(DiGi\-Organization/DiGi\.GIS\.Analytical\#6\)\. A staircase window takes the window construction\.

```csharp
public static DiGi.Analytical.Building.Regulation.Enums.ConstructionRole OpeningConstructionRole(this DiGi.Analytical.Building.Regulation.Enums.OpeningKind openingKind);
```
#### Parameters

<a name='DiGi.Analytical.Building.Regulation.Query.OpeningConstructionRole(thisDiGi.Analytical.Building.Regulation.Enums.OpeningKind).openingKind'></a>

`openingKind` [OpeningKind](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.OpeningKind 'DiGi\.Analytical\.Building\.Regulation\.Enums\.OpeningKind')

The opening kind\.

#### Returns
[ConstructionRole](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.ConstructionRole 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionRole')  
The [ConstructionRole](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.ConstructionRole 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionRole'), or [Undefined](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.ConstructionRole.Undefined 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionRole\.Undefined') for [Undefined](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.OpeningKind.Undefined 'DiGi\.Analytical\.Building\.Regulation\.Enums\.OpeningKind\.Undefined')\.

<a name='DiGi.Analytical.Building.Regulation.Query.Panes(thisDiGi.Analytical.Building.Regulation.Classes.OpeningSize)'></a>

## Query\.Panes\(this OpeningSize\) Method

Gets the glazing panes of an opening size, in the local coordinates of its frame outline with \(0, 0\) at the lower left corner \(DiGi\-Organization/DiGi\.GIS\.Analytical\#6\)\.

Inside a uniform frame, the sashes or leaves sit side by side with a divider between each two; a top light, when there is one, spans the full inner width above a transom of the divider width. Panes are separated by the frame or a divider of non-zero width, which is what `Create.WindowConstruction(name, outline, panes)` requires.

```csharp
public static System.Collections.Generic.List<DiGi.Geometry.Planar.Classes.Polygon2D>? Panes(this DiGi.Analytical.Building.Regulation.Classes.OpeningSize? openingSize);
```
#### Parameters

<a name='DiGi.Analytical.Building.Regulation.Query.Panes(thisDiGi.Analytical.Building.Regulation.Classes.OpeningSize).openingSize'></a>

`openingSize` [OpeningSize](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSize 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSize')

The opening size\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.Geometry\.Planar\.Classes\.Polygon2D](https://learn.microsoft.com/en-us/dotnet/api/digi.geometry.planar.classes.polygon2d 'DiGi\.Geometry\.Planar\.Classes\.Polygon2D')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
The panes from left to right, then the top light, or an empty list when the opening is not glazed or its layout leaves no positive pane; null when [openingSize](DiGi.Analytical.Building.Regulation.md#DiGi.Analytical.Building.Regulation.Query.Panes(thisDiGi.Analytical.Building.Regulation.Classes.OpeningSize).openingSize 'DiGi\.Analytical\.Building\.Regulation\.Query\.Panes\(this DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSize\)\.openingSize') is null\.

<a name='DiGi.Analytical.Building.Regulation.Query.RegulatedHeatTransferCoefficient(thisDiGi.Analytical.Building.HVAC.Interfaces.IRegulatedHeatTransferCoefficients,DiGi.Analytical.Building.Regulation.Enums.ConstructionRole,DiGi.Analytical.Building.Regulation.Enums.BuildingType,DiGi.Analytical.Building.Regulation.Enums.ClimateZone,bool)'></a>

## Query\.RegulatedHeatTransferCoefficient\(this IRegulatedHeatTransferCoefficients, ConstructionRole, BuildingType, ClimateZone, bool\) Method

Gets the maximum heat transfer coefficient U\(max\) a stage of the technical conditions sets for a construction role of a residential building \(DiGi\-Organization/DiGi\.Analytical\#8\)\.

A [SingleFamily](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.BuildingType.SingleFamily 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType\.SingleFamily') or [Terraced](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.BuildingType.Terraced 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType\.Terraced') building takes the single-family limits, a [MultiFamily](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.BuildingType.MultiFamily 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType\.MultiFamily') building or an [ApartmentBlock](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.BuildingType.ApartmentBlock 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType\.ApartmentBlock') the residential or multi-family ones. The 1997 annex has no table for a multi-family building at all, and the 2002 regulation none for its walls, roof and basement ceiling: such a building met the act by its seasonal heat demand indicator E ≤ E0, so no limit is returned.

Until 2013 the window limits depend on the climatic zone (I-III against IV-V), and in 1997 and 2002 the external wall limit on whether the wall is layered with insulation of λ ≤ 0.05 W/(mK) ([insulatedLayered](DiGi.Analytical.Building.Regulation.md#DiGi.Analytical.Building.Regulation.Query.RegulatedHeatTransferCoefficient(thisDiGi.Analytical.Building.HVAC.Interfaces.IRegulatedHeatTransferCoefficients,DiGi.Analytical.Building.Regulation.Enums.ConstructionRole,DiGi.Analytical.Building.Regulation.Enums.BuildingType,DiGi.Analytical.Building.Regulation.Enums.ClimateZone,bool).insulatedLayered 'DiGi\.Analytical\.Building\.Regulation\.Query\.RegulatedHeatTransferCoefficient\(this DiGi\.Analytical\.Building\.HVAC\.Interfaces\.IRegulatedHeatTransferCoefficients, DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionRole, DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType, DiGi\.Analytical\.Building\.Regulation\.Enums\.ClimateZone, bool\)\.insulatedLayered')). A floor on ground was limited by a minimum thermal resistance until 2008, not by a U(max). Walls and floors inside the building, party walls and garage doors have no limit here.

```csharp
public static double RegulatedHeatTransferCoefficient(this DiGi.Analytical.Building.HVAC.Interfaces.IRegulatedHeatTransferCoefficients? regulatedHeatTransferCoefficients, DiGi.Analytical.Building.Regulation.Enums.ConstructionRole constructionRole, DiGi.Analytical.Building.Regulation.Enums.BuildingType buildingType, DiGi.Analytical.Building.Regulation.Enums.ClimateZone climateZone, bool insulatedLayered=false);
```
#### Parameters

<a name='DiGi.Analytical.Building.Regulation.Query.RegulatedHeatTransferCoefficient(thisDiGi.Analytical.Building.HVAC.Interfaces.IRegulatedHeatTransferCoefficients,DiGi.Analytical.Building.Regulation.Enums.ConstructionRole,DiGi.Analytical.Building.Regulation.Enums.BuildingType,DiGi.Analytical.Building.Regulation.Enums.ClimateZone,bool).regulatedHeatTransferCoefficients'></a>

`regulatedHeatTransferCoefficients` [DiGi\.Analytical\.Building\.HVAC\.Interfaces\.IRegulatedHeatTransferCoefficients](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.hvac.interfaces.iregulatedheattransfercoefficients 'DiGi\.Analytical\.Building\.HVAC\.Interfaces\.IRegulatedHeatTransferCoefficients')

The stage of the technical conditions, as returned by the regulated heat transfer coefficients manager\. This value can be null\.

<a name='DiGi.Analytical.Building.Regulation.Query.RegulatedHeatTransferCoefficient(thisDiGi.Analytical.Building.HVAC.Interfaces.IRegulatedHeatTransferCoefficients,DiGi.Analytical.Building.Regulation.Enums.ConstructionRole,DiGi.Analytical.Building.Regulation.Enums.BuildingType,DiGi.Analytical.Building.Regulation.Enums.ClimateZone,bool).constructionRole'></a>

`constructionRole` [ConstructionRole](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.ConstructionRole 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionRole')

The role of the construction\.

<a name='DiGi.Analytical.Building.Regulation.Query.RegulatedHeatTransferCoefficient(thisDiGi.Analytical.Building.HVAC.Interfaces.IRegulatedHeatTransferCoefficients,DiGi.Analytical.Building.Regulation.Enums.ConstructionRole,DiGi.Analytical.Building.Regulation.Enums.BuildingType,DiGi.Analytical.Building.Regulation.Enums.ClimateZone,bool).buildingType'></a>

`buildingType` [BuildingType](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.BuildingType 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType')

The building type\.

<a name='DiGi.Analytical.Building.Regulation.Query.RegulatedHeatTransferCoefficient(thisDiGi.Analytical.Building.HVAC.Interfaces.IRegulatedHeatTransferCoefficients,DiGi.Analytical.Building.Regulation.Enums.ConstructionRole,DiGi.Analytical.Building.Regulation.Enums.BuildingType,DiGi.Analytical.Building.Regulation.Enums.ClimateZone,bool).climateZone'></a>

`climateZone` [ClimateZone](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.ClimateZone 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ClimateZone')

The climatic zone of the building\.

<a name='DiGi.Analytical.Building.Regulation.Query.RegulatedHeatTransferCoefficient(thisDiGi.Analytical.Building.HVAC.Interfaces.IRegulatedHeatTransferCoefficients,DiGi.Analytical.Building.Regulation.Enums.ConstructionRole,DiGi.Analytical.Building.Regulation.Enums.BuildingType,DiGi.Analytical.Building.Regulation.Enums.ClimateZone,bool).insulatedLayered'></a>

`insulatedLayered` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

True for an external wall layered with insulation of λ ≤ 0\.05 W/\(mK\); only the 1997 and 2002 stages distinguish it\.

#### Returns
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')  
The U\(max\) \[W/\(m2K\)\], or [System\.Double\.NaN](https://learn.microsoft.com/en-us/dotnet/api/system.double.nan 'System\.Double\.NaN') when the stage sets no limit for the role and building, or a required input \(zone, building type\) is undefined\.