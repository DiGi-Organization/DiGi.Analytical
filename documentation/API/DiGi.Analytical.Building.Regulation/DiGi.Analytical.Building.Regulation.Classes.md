#### [DiGi\.Analytical\.Building\.Regulation](DiGi.Analytical.Building.Regulation.Overview.md 'DiGi\.Analytical\.Building\.Regulation\.Overview')

## DiGi\.Analytical\.Building\.Regulation\.Classes Namespace
### Classes

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary'></a>

## ConstructionLibrary Class

Represents a library of constructions \- materials, layered constructions and window and door constructions \- and the [ConstructionSet](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionSet 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionSet')s choosing them per building type and date range \(DiGi\-Organization/DiGi\.Analytical\#8\)\.

A construction is brought into a building model with its layers and materials by [DiGi\.Analytical\.Building\.Classes\.BuildingModel\.Update\(DiGi\.Analytical\.Building\.Classes\.ConstructionRelationCluster,DiGi\.Analytical\.Building\.Interfaces\.IConstruction\)](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel.update#digi-analytical-building-classes-buildingmodel-update(digi-analytical-building-classes-constructionrelationcluster-digi-analytical-building-interfaces-iconstruction) 'DiGi\.Analytical\.Building\.Classes\.BuildingModel\.Update\(DiGi\.Analytical\.Building\.Classes\.ConstructionRelationCluster,DiGi\.Analytical\.Building\.Interfaces\.IConstruction\)'), passing [ConstructionRelationCluster](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary.ConstructionRelationCluster 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionLibrary\.ConstructionRelationCluster').

```csharp
public class ConstructionLibrary : DiGi.Core.Classes.GuidObject, DiGi.Analytical.Building.Regulation.Interfaces.IRegulationSerializableObject, DiGi.Analytical.Building.Regulation.Interfaces.IRegulationObject, DiGi.Analytical.Building.Interfaces.IBuildingObject, DiGi.Analytical.Interfaces.IAnalyticalObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Classes\.UniqueObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.uniqueobject 'DiGi\.Core\.Classes\.UniqueObject') → [DiGi\.Core\.Classes\.GuidObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.guidobject 'DiGi\.Core\.Classes\.GuidObject') → ConstructionLibrary

Implements [IRegulationSerializableObject](DiGi.Analytical.Building.Regulation.Interfaces.md#DiGi.Analytical.Building.Regulation.Interfaces.IRegulationSerializableObject 'DiGi\.Analytical\.Building\.Regulation\.Interfaces\.IRegulationSerializableObject'), [IRegulationObject](DiGi.Analytical.Building.Regulation.Interfaces.md#DiGi.Analytical.Building.Regulation.Interfaces.IRegulationObject 'DiGi\.Analytical\.Building\.Regulation\.Interfaces\.IRegulationObject'), [DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.ibuildingobject 'DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject'), [DiGi\.Analytical\.Interfaces\.IAnalyticalObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.interfaces.ianalyticalobject 'DiGi\.Analytical\.Interfaces\.IAnalyticalObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary.ConstructionLibrary(DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary)'></a>

## ConstructionLibrary\(ConstructionLibrary\) Constructor

Initializes a new instance of the [ConstructionLibrary](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionLibrary') class by copying another instance, its constructions and its sets\.

```csharp
public ConstructionLibrary(DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary? constructionLibrary);
```
#### Parameters

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary.ConstructionLibrary(DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary).constructionLibrary'></a>

`constructionLibrary` [ConstructionLibrary](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionLibrary')

The source [ConstructionLibrary](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionLibrary') to copy from\. This value can be null\.

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary.ConstructionLibrary(string,string,string)'></a>

## ConstructionLibrary\(string, string, string\) Constructor

Initializes a new instance of the [ConstructionLibrary](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionLibrary') class\.

```csharp
public ConstructionLibrary(string? name, string? version, string? description);
```
#### Parameters

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary.ConstructionLibrary(string,string,string).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the library\. This value can be null\.

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary.ConstructionLibrary(string,string,string).version'></a>

`version` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The version of the library\. This value can be null\.

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary.ConstructionLibrary(string,string,string).description'></a>

`description` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The description of the library\. This value can be null\.

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary.ConstructionLibrary(System.Guid,string,string,string)'></a>

## ConstructionLibrary\(Guid, string, string, string\) Constructor

Initializes a new instance of the [ConstructionLibrary](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionLibrary') class with the specified identifier, so that a library generated more than once keeps the same identity\.

```csharp
public ConstructionLibrary(System.Guid guid, string? name, string? version, string? description);
```
#### Parameters

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary.ConstructionLibrary(System.Guid,string,string,string).guid'></a>

`guid` [System\.Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid 'System\.Guid')

The identifier of the library\.

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary.ConstructionLibrary(System.Guid,string,string,string).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the library\. This value can be null\.

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary.ConstructionLibrary(System.Guid,string,string,string).version'></a>

`version` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The version of the library\. This value can be null\.

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary.ConstructionLibrary(System.Guid,string,string,string).description'></a>

`description` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The description of the library\. This value can be null\.

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary.ConstructionLibrary(System.Text.Json.Nodes.JsonObject)'></a>

## ConstructionLibrary\(JsonObject\) Constructor

Initializes a new instance of the [ConstructionLibrary](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionLibrary') class from the specified JSON object\.

```csharp
public ConstructionLibrary(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary.ConstructionLibrary(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject') containing the data\. This value can be null\.
### Properties

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary.ConstructionRelationCluster'></a>

## ConstructionLibrary\.ConstructionRelationCluster Property

Gets the cluster holding the library's materials, constructions and structure layers\.

This is the library's own cluster, not a copy: the library is built by adding to it (for example with `Create.StructureLayer`).

```csharp
public DiGi.Analytical.Building.Classes.ConstructionRelationCluster ConstructionRelationCluster { get; }
```

#### Property Value
[DiGi\.Analytical\.Building\.Classes\.ConstructionRelationCluster](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.constructionrelationcluster 'DiGi\.Analytical\.Building\.Classes\.ConstructionRelationCluster')

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary.Description'></a>

## ConstructionLibrary\.Description Property

Gets the description of the library\.

```csharp
public string? Description { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary.Name'></a>

## ConstructionLibrary\.Name Property

Gets the name of the library\.

```csharp
public string? Name { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary.Version'></a>

## ConstructionLibrary\.Version Property

Gets the version of the library\.

```csharp
public string? Version { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')
### Methods

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary.Add(DiGi.Analytical.Building.Regulation.Classes.ConstructionSet)'></a>

## ConstructionLibrary\.Add\(ConstructionSet\) Method

Adds a construction set to the library\.

```csharp
public bool Add(DiGi.Analytical.Building.Regulation.Classes.ConstructionSet? constructionSet);
```
#### Parameters

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary.Add(DiGi.Analytical.Building.Regulation.Classes.ConstructionSet).constructionSet'></a>

`constructionSet` [ConstructionSet](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionSet 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionSet')

The construction set\. This value can be null\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the set was added; false if it is null\.

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary.GetConstruction(DiGi.Analytical.Building.Regulation.Classes.ConstructionSet,DiGi.Analytical.Building.Regulation.Enums.ConstructionRole)'></a>

## ConstructionLibrary\.GetConstruction\(ConstructionSet, ConstructionRole\) Method

Gets the construction the specified set uses for the specified role\.

```csharp
public DiGi.Analytical.Building.Interfaces.IConstruction? GetConstruction(DiGi.Analytical.Building.Regulation.Classes.ConstructionSet? constructionSet, DiGi.Analytical.Building.Regulation.Enums.ConstructionRole constructionRole);
```
#### Parameters

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary.GetConstruction(DiGi.Analytical.Building.Regulation.Classes.ConstructionSet,DiGi.Analytical.Building.Regulation.Enums.ConstructionRole).constructionSet'></a>

`constructionSet` [ConstructionSet](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionSet 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionSet')

The construction set\. This value can be null\.

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary.GetConstruction(DiGi.Analytical.Building.Regulation.Classes.ConstructionSet,DiGi.Analytical.Building.Regulation.Enums.ConstructionRole).constructionRole'></a>

`constructionRole` [ConstructionRole](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.ConstructionRole 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionRole')

The role\.

#### Returns
[DiGi\.Analytical\.Building\.Interfaces\.IConstruction](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.iconstruction 'DiGi\.Analytical\.Building\.Interfaces\.IConstruction')  
A CLONE of the [DiGi\.Analytical\.Building\.Interfaces\.IConstruction](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.iconstruction 'DiGi\.Analytical\.Building\.Interfaces\.IConstruction'), or null when the set has no construction for the role or the library does not hold it\.

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary.GetConstructionSet(System.DateTimeOffset,DiGi.Analytical.Building.Regulation.Enums.BuildingType,DiGi.Analytical.Building.Regulation.Enums.ClimateZone,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour)'></a>

## ConstructionLibrary\.GetConstructionSet\(DateTimeOffset, BuildingType, ClimateZone, ConstructionFlavour\) Method

Gets the construction set that applies to a building of the specified type, climatic zone and flavour on the specified date\.

A set for the building's own zone wins over a set for every zone; among equally specific sets the one starting latest wins.

```csharp
public DiGi.Analytical.Building.Regulation.Classes.ConstructionSet? GetConstructionSet(System.DateTimeOffset dateTimeOffset, DiGi.Analytical.Building.Regulation.Enums.BuildingType buildingType, DiGi.Analytical.Building.Regulation.Enums.ClimateZone climateZone, DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour constructionFlavour);
```
#### Parameters

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary.GetConstructionSet(System.DateTimeOffset,DiGi.Analytical.Building.Regulation.Enums.BuildingType,DiGi.Analytical.Building.Regulation.Enums.ClimateZone,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour).dateTimeOffset'></a>

`dateTimeOffset` [System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')

The design date \([Regulation](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour.Regulation 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionFlavour\.Regulation')\) or the date built \([TypicalAsBuilt](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour.TypicalAsBuilt 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionFlavour\.TypicalAsBuilt')\)\.

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary.GetConstructionSet(System.DateTimeOffset,DiGi.Analytical.Building.Regulation.Enums.BuildingType,DiGi.Analytical.Building.Regulation.Enums.ClimateZone,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour).buildingType'></a>

`buildingType` [BuildingType](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.BuildingType 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType')

The building type\.

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary.GetConstructionSet(System.DateTimeOffset,DiGi.Analytical.Building.Regulation.Enums.BuildingType,DiGi.Analytical.Building.Regulation.Enums.ClimateZone,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour).climateZone'></a>

`climateZone` [ClimateZone](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.ClimateZone 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ClimateZone')

The climatic zone of the building\.

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary.GetConstructionSet(System.DateTimeOffset,DiGi.Analytical.Building.Regulation.Enums.BuildingType,DiGi.Analytical.Building.Regulation.Enums.ClimateZone,DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour).constructionFlavour'></a>

`constructionFlavour` [ConstructionFlavour](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionFlavour')

The kind of constructions wanted\.

#### Returns
[ConstructionSet](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionSet 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionSet')  
A CLONE of the [ConstructionSet](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionSet 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionSet'), or null when none applies\.

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary.GetConstructionSets()'></a>

## ConstructionLibrary\.GetConstructionSets\(\) Method

Gets the construction sets of the library\.

```csharp
public System.Collections.Generic.List<DiGi.Analytical.Building.Regulation.Classes.ConstructionSet> GetConstructionSets();
```

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[ConstructionSet](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionSet 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionSet')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
CLONES of the library's [ConstructionSet](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionSet 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionSet')s\.

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionLibraryFile'></a>

## ConstructionLibraryFile Class

Represents a storage file for [ConstructionLibrary](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionLibrary') instances, mirroring [DiGi\.Analytical\.Classes\.MaterialsFile](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.classes.materialsfile 'DiGi\.Analytical\.Classes\.MaterialsFile') \(DiGi\-Organization/DiGi\.Analytical\#8\)\.

```csharp
public class ConstructionLibraryFile : DiGi.Core.IO.File.Classes.StorageFile<DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.IO\.File\.Classes\.File](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.file.classes.file 'DiGi\.Core\.IO\.File\.Classes\.File') → [DiGi\.Core\.IO\.File\.Classes\.StorageFile&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.file.classes.storagefile-1 'DiGi\.Core\.IO\.File\.Classes\.StorageFile\`1')[ConstructionLibrary](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionLibrary')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.file.classes.storagefile-1 'DiGi\.Core\.IO\.File\.Classes\.StorageFile\`1') → ConstructionLibraryFile
### Constructors

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionLibraryFile.ConstructionLibraryFile(DiGi.Analytical.Building.Regulation.Classes.ConstructionLibraryFile)'></a>

## ConstructionLibraryFile\(ConstructionLibraryFile\) Constructor

Initializes a new instance of the [ConstructionLibraryFile](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionLibraryFile 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionLibraryFile') class using an existing [ConstructionLibraryFile](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionLibraryFile 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionLibraryFile') instance\.

```csharp
public ConstructionLibraryFile(DiGi.Analytical.Building.Regulation.Classes.ConstructionLibraryFile? constructionLibraryFile);
```
#### Parameters

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionLibraryFile.ConstructionLibraryFile(DiGi.Analytical.Building.Regulation.Classes.ConstructionLibraryFile).constructionLibraryFile'></a>

`constructionLibraryFile` [ConstructionLibraryFile](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionLibraryFile 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionLibraryFile')

The source [ConstructionLibraryFile](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionLibraryFile 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionLibraryFile') instance to copy from\.

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionLibraryFile.ConstructionLibraryFile(string)'></a>

## ConstructionLibraryFile\(string\) Constructor

Initializes a new instance of the [ConstructionLibraryFile](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionLibraryFile 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionLibraryFile') class using the specified file path\.

```csharp
public ConstructionLibraryFile(string? path);
```
#### Parameters

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionLibraryFile.ConstructionLibraryFile(string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The file system path to the construction library file\. This value can be null\.

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionLibraryFile.ConstructionLibraryFile(System.Text.Json.Nodes.JsonObject)'></a>

## ConstructionLibraryFile\(JsonObject\) Constructor

Initializes a new instance of the [ConstructionLibraryFile](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionLibraryFile 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionLibraryFile') class using the specified JSON object\.

```csharp
public ConstructionLibraryFile(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionLibraryFile.ConstructionLibraryFile(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject') containing the data used to initialize the file\.
### Methods

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionLibraryFile.GetUniqueReference(DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary)'></a>

## ConstructionLibraryFile\.GetUniqueReference\(ConstructionLibrary\) Method

Retrieves the unique reference for the specified construction library\.

```csharp
public override DiGi.Core.Classes.UniqueReference? GetUniqueReference(DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary? constructionLibrary);
```
#### Parameters

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionLibraryFile.GetUniqueReference(DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary).constructionLibrary'></a>

`constructionLibrary` [ConstructionLibrary](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionLibrary')

The construction library to retrieve the reference for\.

#### Returns
[DiGi\.Core\.Classes\.UniqueReference](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.uniquereference 'DiGi\.Core\.Classes\.UniqueReference')  
The unique reference associated with the specified construction library, or null\.

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionSet'></a>

## ConstructionSet Class

Represents the constructions to use, one per [ConstructionRole](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.ConstructionRole 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionRole'), for a building of a given type built or designed within a date range \(DiGi\-Organization/DiGi\.Analytical\#8\)\.

A set is keyed by a date range rather than by a regime, like the regulated heat transfer coefficients: [Regulation](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour.Regulation 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionFlavour\.Regulation') sets change at the dates the thermal limits changed and are looked up by design date, [TypicalAsBuilt](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour.TypicalAsBuilt 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionFlavour\.TypicalAsBuilt') sets change at the TABULA period dates and are looked up by year built. The constructions themselves are held, with their layers and materials, by the [ConstructionLibrary](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionLibrary') the set belongs to; the set refers to them.

```csharp
public class ConstructionSet : DiGi.Core.Classes.SerializableObject, DiGi.Analytical.Building.Regulation.Interfaces.IRegulationSerializableObject, DiGi.Analytical.Building.Regulation.Interfaces.IRegulationObject, DiGi.Analytical.Building.Interfaces.IBuildingObject, DiGi.Analytical.Interfaces.IAnalyticalObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → ConstructionSet

Implements [IRegulationSerializableObject](DiGi.Analytical.Building.Regulation.Interfaces.md#DiGi.Analytical.Building.Regulation.Interfaces.IRegulationSerializableObject 'DiGi\.Analytical\.Building\.Regulation\.Interfaces\.IRegulationSerializableObject'), [IRegulationObject](DiGi.Analytical.Building.Regulation.Interfaces.md#DiGi.Analytical.Building.Regulation.Interfaces.IRegulationObject 'DiGi\.Analytical\.Building\.Regulation\.Interfaces\.IRegulationObject'), [DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.ibuildingobject 'DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject'), [DiGi\.Analytical\.Interfaces\.IAnalyticalObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.interfaces.ianalyticalobject 'DiGi\.Analytical\.Interfaces\.IAnalyticalObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionSet.ConstructionSet(DiGi.Analytical.Building.Regulation.Classes.ConstructionSet)'></a>

## ConstructionSet\(ConstructionSet\) Constructor

Initializes a new instance of the [ConstructionSet](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionSet 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionSet') class by copying another instance\.

```csharp
public ConstructionSet(DiGi.Analytical.Building.Regulation.Classes.ConstructionSet? constructionSet);
```
#### Parameters

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionSet.ConstructionSet(DiGi.Analytical.Building.Regulation.Classes.ConstructionSet).constructionSet'></a>

`constructionSet` [ConstructionSet](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionSet 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionSet')

The source [ConstructionSet](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionSet 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionSet') to copy from\. This value can be null\.

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionSet.ConstructionSet(DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,DiGi.Analytical.Building.Regulation.Enums.BuildingType,System.Nullable_DiGi.Analytical.Building.Regulation.Enums.ClimateZone_,System.DateTimeOffset,System.Nullable_System.DateTimeOffset_,string)'></a>

## ConstructionSet\(ConstructionFlavour, BuildingType, Nullable\<ClimateZone\>, DateTimeOffset, Nullable\<DateTimeOffset\>, string\) Constructor

Initializes a new instance of the [ConstructionSet](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionSet 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionSet') class\.

```csharp
public ConstructionSet(DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour constructionFlavour, DiGi.Analytical.Building.Regulation.Enums.BuildingType buildingType, System.Nullable<DiGi.Analytical.Building.Regulation.Enums.ClimateZone> climateZone, System.DateTimeOffset startDate, System.Nullable<System.DateTimeOffset> endDate, string? source);
```
#### Parameters

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionSet.ConstructionSet(DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,DiGi.Analytical.Building.Regulation.Enums.BuildingType,System.Nullable_DiGi.Analytical.Building.Regulation.Enums.ClimateZone_,System.DateTimeOffset,System.Nullable_System.DateTimeOffset_,string).constructionFlavour'></a>

`constructionFlavour` [ConstructionFlavour](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionFlavour')

The kind of constructions the set describes\.

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionSet.ConstructionSet(DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,DiGi.Analytical.Building.Regulation.Enums.BuildingType,System.Nullable_DiGi.Analytical.Building.Regulation.Enums.ClimateZone_,System.DateTimeOffset,System.Nullable_System.DateTimeOffset_,string).buildingType'></a>

`buildingType` [BuildingType](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.BuildingType 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType')

The building type the set applies to\.

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionSet.ConstructionSet(DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,DiGi.Analytical.Building.Regulation.Enums.BuildingType,System.Nullable_DiGi.Analytical.Building.Regulation.Enums.ClimateZone_,System.DateTimeOffset,System.Nullable_System.DateTimeOffset_,string).climateZone'></a>

`climateZone` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[ClimateZone](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.ClimateZone 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ClimateZone')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The climatic zone the set applies to, or null for every zone\.

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionSet.ConstructionSet(DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,DiGi.Analytical.Building.Regulation.Enums.BuildingType,System.Nullable_DiGi.Analytical.Building.Regulation.Enums.ClimateZone_,System.DateTimeOffset,System.Nullable_System.DateTimeOffset_,string).startDate'></a>

`startDate` [System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')

The first date the set applies to\.

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionSet.ConstructionSet(DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,DiGi.Analytical.Building.Regulation.Enums.BuildingType,System.Nullable_DiGi.Analytical.Building.Regulation.Enums.ClimateZone_,System.DateTimeOffset,System.Nullable_System.DateTimeOffset_,string).endDate'></a>

`endDate` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The first date the set no longer applies to, or null when it still applies\.

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionSet.ConstructionSet(DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour,DiGi.Analytical.Building.Regulation.Enums.BuildingType,System.Nullable_DiGi.Analytical.Building.Regulation.Enums.ClimateZone_,System.DateTimeOffset,System.Nullable_System.DateTimeOffset_,string).source'></a>

`source` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The source of the set's constructions \(norm, Dz\.U\. text, TABULA / NAPE\)\. This value can be null\.

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionSet.ConstructionSet(System.Text.Json.Nodes.JsonObject)'></a>

## ConstructionSet\(JsonObject\) Constructor

Initializes a new instance of the [ConstructionSet](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionSet 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionSet') class from the specified JSON object\.

```csharp
public ConstructionSet(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionSet.ConstructionSet(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject') containing the data\. This value can be null\.
### Properties

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionSet.BuildingType'></a>

## ConstructionSet\.BuildingType Property

Gets the building type the set applies to\.

```csharp
public DiGi.Analytical.Building.Regulation.Enums.BuildingType BuildingType { get; }
```

#### Property Value
[BuildingType](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.BuildingType 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType')

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionSet.ClimateZone'></a>

## ConstructionSet\.ClimateZone Property

Gets the climatic zone the set applies to, or null when it applies to every zone\.

```csharp
public System.Nullable<DiGi.Analytical.Building.Regulation.Enums.ClimateZone> ClimateZone { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[ClimateZone](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.ClimateZone 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ClimateZone')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionSet.ConstructionFlavour'></a>

## ConstructionSet\.ConstructionFlavour Property

Gets the kind of constructions the set describes\.

```csharp
public DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour ConstructionFlavour { get; }
```

#### Property Value
[ConstructionFlavour](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionFlavour')

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionSet.EndDate'></a>

## ConstructionSet\.EndDate Property

Gets the first date the set no longer applies to, or null when it still applies\.

```csharp
public System.Nullable<System.DateTimeOffset> EndDate { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionSet.Source'></a>

## ConstructionSet\.Source Property

Gets the source of the set's constructions\.

```csharp
public string? Source { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionSet.StartDate'></a>

## ConstructionSet\.StartDate Property

Gets the first date the set applies to\.

```csharp
public System.DateTimeOffset StartDate { get; }
```

#### Property Value
[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')
### Methods

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionSet.GetConstructionReference(DiGi.Analytical.Building.Regulation.Enums.ConstructionRole)'></a>

## ConstructionSet\.GetConstructionReference\(ConstructionRole\) Method

Gets the reference of the construction used for the specified role\.

```csharp
public DiGi.Core.Classes.GuidReference? GetConstructionReference(DiGi.Analytical.Building.Regulation.Enums.ConstructionRole constructionRole);
```
#### Parameters

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionSet.GetConstructionReference(DiGi.Analytical.Building.Regulation.Enums.ConstructionRole).constructionRole'></a>

`constructionRole` [ConstructionRole](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.ConstructionRole 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionRole')

The role\.

#### Returns
[DiGi\.Core\.Classes\.GuidReference](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.guidreference 'DiGi\.Core\.Classes\.GuidReference')  
A CLONE of the construction's [DiGi\.Core\.Classes\.GuidReference](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.guidreference 'DiGi\.Core\.Classes\.GuidReference'), or null when the set has no construction for the role\.

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionSet.GetConstructionRoles()'></a>

## ConstructionSet\.GetConstructionRoles\(\) Method

Gets the roles the set has a construction for\.

```csharp
public System.Collections.Generic.List<DiGi.Analytical.Building.Regulation.Enums.ConstructionRole> GetConstructionRoles();
```

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[ConstructionRole](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.ConstructionRole 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionRole')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
The roles, in no particular order\.

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionSet.Includes(System.DateTimeOffset)'></a>

## ConstructionSet\.Includes\(DateTimeOffset\) Method

Determines whether the set applies to the specified date: on or after [StartDate](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionSet.StartDate 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionSet\.StartDate') and before [EndDate](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionSet.EndDate 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionSet\.EndDate'), compared by calendar date\.

```csharp
public bool Includes(System.DateTimeOffset dateTimeOffset);
```
#### Parameters

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionSet.Includes(System.DateTimeOffset).dateTimeOffset'></a>

`dateTimeOffset` [System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')

The design date \([Regulation](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour.Regulation 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionFlavour\.Regulation')\) or the date built \([TypicalAsBuilt](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour.TypicalAsBuilt 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionFlavour\.TypicalAsBuilt')\)\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the set applies to the date; otherwise, false\.

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionSet.SetConstruction(DiGi.Analytical.Building.Regulation.Enums.ConstructionRole,DiGi.Analytical.Building.Interfaces.IConstruction)'></a>

## ConstructionSet\.SetConstruction\(ConstructionRole, IConstruction\) Method

Sets the construction used for the specified role, replacing any previous one\. The construction itself belongs in the [ConstructionRelationCluster](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary.ConstructionRelationCluster 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionLibrary\.ConstructionRelationCluster') of the library holding the set\.

```csharp
public bool SetConstruction(DiGi.Analytical.Building.Regulation.Enums.ConstructionRole constructionRole, DiGi.Analytical.Building.Interfaces.IConstruction? construction);
```
#### Parameters

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionSet.SetConstruction(DiGi.Analytical.Building.Regulation.Enums.ConstructionRole,DiGi.Analytical.Building.Interfaces.IConstruction).constructionRole'></a>

`constructionRole` [ConstructionRole](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.ConstructionRole 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionRole')

The role\.

<a name='DiGi.Analytical.Building.Regulation.Classes.ConstructionSet.SetConstruction(DiGi.Analytical.Building.Regulation.Enums.ConstructionRole,DiGi.Analytical.Building.Interfaces.IConstruction).construction'></a>

`construction` [DiGi\.Analytical\.Building\.Interfaces\.IConstruction](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.iconstruction 'DiGi\.Analytical\.Building\.Interfaces\.IConstruction')

The construction\. This value can be null\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the construction was set; false if it is null or the role is [Undefined](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.ConstructionRole.Undefined 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionRole\.Undefined')\.

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSize'></a>

## OpeningSize Class

Represents the size and glazing layout of one window or door of a stock \(DiGi\-Organization/DiGi\.GIS\.Analytical\#6\)\.

[Width](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSize.Width 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSize\.Width') and [Height](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSize.Height 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSize\.Height') are the frame outline, which becomes the outline of the window or door construction, from (0, 0) at its lower left corner. The glazing is a regular layout: a uniform [FrameWidth](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSize.FrameWidth 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSize\.FrameWidth') around [Columns](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSize.Columns 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSize\.Columns') sashes or leaves separated by dividers of [DividerWidth](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSize.DividerWidth 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSize\.DividerWidth'), and optionally a top light of [TopLightHeight](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSize.TopLightHeight 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSize\.TopLightHeight') above a transom of the divider width. [Panes\(this OpeningSize\)](DiGi.Analytical.Building.Regulation.md#DiGi.Analytical.Building.Regulation.Query.Panes(thisDiGi.Analytical.Building.Regulation.Classes.OpeningSize) 'DiGi\.Analytical\.Building\.Regulation\.Query\.Panes\(this DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSize\)') derives the pane rectangles; a uniform frame and divider width converts exactly to the frame-and-divider description of EnergyPlus.

```csharp
public class OpeningSize : DiGi.Core.Classes.SerializableObject, DiGi.Analytical.Building.Regulation.Interfaces.IRegulationSerializableObject, DiGi.Analytical.Building.Regulation.Interfaces.IRegulationObject, DiGi.Analytical.Building.Interfaces.IBuildingObject, DiGi.Analytical.Interfaces.IAnalyticalObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → OpeningSize

Implements [IRegulationSerializableObject](DiGi.Analytical.Building.Regulation.Interfaces.md#DiGi.Analytical.Building.Regulation.Interfaces.IRegulationSerializableObject 'DiGi\.Analytical\.Building\.Regulation\.Interfaces\.IRegulationSerializableObject'), [IRegulationObject](DiGi.Analytical.Building.Regulation.Interfaces.md#DiGi.Analytical.Building.Regulation.Interfaces.IRegulationObject 'DiGi\.Analytical\.Building\.Regulation\.Interfaces\.IRegulationObject'), [DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.ibuildingobject 'DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject'), [DiGi\.Analytical\.Interfaces\.IAnalyticalObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.interfaces.ianalyticalobject 'DiGi\.Analytical\.Interfaces\.IAnalyticalObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSize.OpeningSize(DiGi.Analytical.Building.Regulation.Classes.OpeningSize)'></a>

## OpeningSize\(OpeningSize\) Constructor

Initializes a new instance of the [OpeningSize](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSize 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSize') class by copying an existing instance\.

```csharp
public OpeningSize(DiGi.Analytical.Building.Regulation.Classes.OpeningSize? openingSize);
```
#### Parameters

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSize.OpeningSize(DiGi.Analytical.Building.Regulation.Classes.OpeningSize).openingSize'></a>

`openingSize` [OpeningSize](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSize 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSize')

The [OpeningSize](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSize 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSize') to copy\. This value can be null\.

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSize.OpeningSize(DiGi.Analytical.Building.Regulation.Enums.OpeningKind,DiGi.Analytical.Building.Regulation.Enums.RoomUse,double,double,System.Nullable_double_,bool,int,double,double,System.Nullable_double_,string)'></a>

## OpeningSize\(OpeningKind, RoomUse, double, double, Nullable\<double\>, bool, int, double, double, Nullable\<double\>, string\) Constructor

Initializes a new instance of the [OpeningSize](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSize 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSize') class\.

```csharp
public OpeningSize(DiGi.Analytical.Building.Regulation.Enums.OpeningKind openingKind, DiGi.Analytical.Building.Regulation.Enums.RoomUse roomUse, double width, double height, System.Nullable<double> sillHeight, bool glazed, int columns, double frameWidth, double dividerWidth, System.Nullable<double> topLightHeight, string? source);
```
#### Parameters

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSize.OpeningSize(DiGi.Analytical.Building.Regulation.Enums.OpeningKind,DiGi.Analytical.Building.Regulation.Enums.RoomUse,double,double,System.Nullable_double_,bool,int,double,double,System.Nullable_double_,string).openingKind'></a>

`openingKind` [OpeningKind](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.OpeningKind 'DiGi\.Analytical\.Building\.Regulation\.Enums\.OpeningKind')

The opening kind\.

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSize.OpeningSize(DiGi.Analytical.Building.Regulation.Enums.OpeningKind,DiGi.Analytical.Building.Regulation.Enums.RoomUse,double,double,System.Nullable_double_,bool,int,double,double,System.Nullable_double_,string).roomUse'></a>

`roomUse` [RoomUse](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.RoomUse 'DiGi\.Analytical\.Building\.Regulation\.Enums\.RoomUse')

The use of the room the opening serves\.

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSize.OpeningSize(DiGi.Analytical.Building.Regulation.Enums.OpeningKind,DiGi.Analytical.Building.Regulation.Enums.RoomUse,double,double,System.Nullable_double_,bool,int,double,double,System.Nullable_double_,string).width'></a>

`width` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The width of the frame outline \[m\]\.

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSize.OpeningSize(DiGi.Analytical.Building.Regulation.Enums.OpeningKind,DiGi.Analytical.Building.Regulation.Enums.RoomUse,double,double,System.Nullable_double_,bool,int,double,double,System.Nullable_double_,string).height'></a>

`height` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The height of the frame outline \[m\]\.

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSize.OpeningSize(DiGi.Analytical.Building.Regulation.Enums.OpeningKind,DiGi.Analytical.Building.Regulation.Enums.RoomUse,double,double,System.Nullable_double_,bool,int,double,double,System.Nullable_double_,string).sillHeight'></a>

`sillHeight` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The height of the bottom of the frame above the floor \[m\]; null for doors and balcony doors\.

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSize.OpeningSize(DiGi.Analytical.Building.Regulation.Enums.OpeningKind,DiGi.Analytical.Building.Regulation.Enums.RoomUse,double,double,System.Nullable_double_,bool,int,double,double,System.Nullable_double_,string).glazed'></a>

`glazed` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

True when the opening is glazed, so [Panes\(this OpeningSize\)](DiGi.Analytical.Building.Regulation.md#DiGi.Analytical.Building.Regulation.Query.Panes(thisDiGi.Analytical.Building.Regulation.Classes.OpeningSize) 'DiGi\.Analytical\.Building\.Regulation\.Query\.Panes\(this DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSize\)') returns panes\.

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSize.OpeningSize(DiGi.Analytical.Building.Regulation.Enums.OpeningKind,DiGi.Analytical.Building.Regulation.Enums.RoomUse,double,double,System.Nullable_double_,bool,int,double,double,System.Nullable_double_,string).columns'></a>

`columns` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of sashes or leaves side by side\.

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSize.OpeningSize(DiGi.Analytical.Building.Regulation.Enums.OpeningKind,DiGi.Analytical.Building.Regulation.Enums.RoomUse,double,double,System.Nullable_double_,bool,int,double,double,System.Nullable_double_,string).frameWidth'></a>

`frameWidth` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The uniform face width of the frame \[m\]\.

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSize.OpeningSize(DiGi.Analytical.Building.Regulation.Enums.OpeningKind,DiGi.Analytical.Building.Regulation.Enums.RoomUse,double,double,System.Nullable_double_,bool,int,double,double,System.Nullable_double_,string).dividerWidth'></a>

`dividerWidth` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The face width of a mullion between sashes and of the transom below a top light \[m\]\.

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSize.OpeningSize(DiGi.Analytical.Building.Regulation.Enums.OpeningKind,DiGi.Analytical.Building.Regulation.Enums.RoomUse,double,double,System.Nullable_double_,bool,int,double,double,System.Nullable_double_,string).topLightHeight'></a>

`topLightHeight` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The height of the top light above the transom, frame excluded \[m\]; null when there is none\.

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSize.OpeningSize(DiGi.Analytical.Building.Regulation.Enums.OpeningKind,DiGi.Analytical.Building.Regulation.Enums.RoomUse,double,double,System.Nullable_double_,bool,int,double,double,System.Nullable_double_,string).source'></a>

`source` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The sources of the values, each with its tag\. This value can be null\.

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSize.OpeningSize(System.Text.Json.Nodes.JsonObject)'></a>

## OpeningSize\(JsonObject\) Constructor

Initializes a new instance of the [OpeningSize](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSize 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSize') class from a JSON object\.

```csharp
public OpeningSize(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSize.OpeningSize(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the data\. This value can be null\.
### Properties

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSize.Columns'></a>

## OpeningSize\.Columns Property

Gets the number of sashes or leaves side by side\.

```csharp
public int Columns { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSize.DividerWidth'></a>

## OpeningSize\.DividerWidth Property

Gets the face width of a mullion between sashes and of the transom below a top light \[m\]\.

```csharp
public double DividerWidth { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSize.FrameWidth'></a>

## OpeningSize\.FrameWidth Property

Gets the uniform face width of the frame \[m\]\.

```csharp
public double FrameWidth { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSize.Glazed'></a>

## OpeningSize\.Glazed Property

Gets a value indicating whether the opening is glazed\.

```csharp
public bool Glazed { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSize.Height'></a>

## OpeningSize\.Height Property

Gets the height of the frame outline \[m\]\.

```csharp
public double Height { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSize.OpeningKind'></a>

## OpeningSize\.OpeningKind Property

Gets the opening kind\.

```csharp
public DiGi.Analytical.Building.Regulation.Enums.OpeningKind OpeningKind { get; }
```

#### Property Value
[OpeningKind](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.OpeningKind 'DiGi\.Analytical\.Building\.Regulation\.Enums\.OpeningKind')

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSize.RoomUse'></a>

## OpeningSize\.RoomUse Property

Gets the use of the room the opening serves\.

```csharp
public DiGi.Analytical.Building.Regulation.Enums.RoomUse RoomUse { get; }
```

#### Property Value
[RoomUse](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.RoomUse 'DiGi\.Analytical\.Building\.Regulation\.Enums\.RoomUse')

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSize.SillHeight'></a>

## OpeningSize\.SillHeight Property

Gets the height of the bottom of the frame above the floor \[m\], or null for doors and balcony doors\.

```csharp
public System.Nullable<double> SillHeight { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSize.Source'></a>

## OpeningSize\.Source Property

Gets the sources of the values, each with its tag\.

```csharp
public string? Source { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSize.TopLightHeight'></a>

## OpeningSize\.TopLightHeight Property

Gets the height of the top light above the transom, frame excluded \[m\], or null when there is none\.

```csharp
public System.Nullable<double> TopLightHeight { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSize.Width'></a>

## OpeningSize\.Width Property

Gets the width of the frame outline \[m\]\.

```csharp
public double Width { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary'></a>

## OpeningSizeLibrary Class

Represents a library of [OpeningSizeSet](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSizeSet')s: the window and door sizes per building type, date range and large\-panel system \(DiGi\-Organization/DiGi\.GIS\.Analytical\#6\)\.

```csharp
public class OpeningSizeLibrary : DiGi.Core.Classes.GuidObject, DiGi.Analytical.Building.Regulation.Interfaces.IRegulationSerializableObject, DiGi.Analytical.Building.Regulation.Interfaces.IRegulationObject, DiGi.Analytical.Building.Interfaces.IBuildingObject, DiGi.Analytical.Interfaces.IAnalyticalObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Classes\.UniqueObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.uniqueobject 'DiGi\.Core\.Classes\.UniqueObject') → [DiGi\.Core\.Classes\.GuidObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.guidobject 'DiGi\.Core\.Classes\.GuidObject') → OpeningSizeLibrary

Implements [IRegulationSerializableObject](DiGi.Analytical.Building.Regulation.Interfaces.md#DiGi.Analytical.Building.Regulation.Interfaces.IRegulationSerializableObject 'DiGi\.Analytical\.Building\.Regulation\.Interfaces\.IRegulationSerializableObject'), [IRegulationObject](DiGi.Analytical.Building.Regulation.Interfaces.md#DiGi.Analytical.Building.Regulation.Interfaces.IRegulationObject 'DiGi\.Analytical\.Building\.Regulation\.Interfaces\.IRegulationObject'), [DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.ibuildingobject 'DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject'), [DiGi\.Analytical\.Interfaces\.IAnalyticalObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.interfaces.ianalyticalobject 'DiGi\.Analytical\.Interfaces\.IAnalyticalObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary.OpeningSizeLibrary(DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary)'></a>

## OpeningSizeLibrary\(OpeningSizeLibrary\) Constructor

Initializes a new instance of the [OpeningSizeLibrary](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSizeLibrary') class by copying an existing instance\.

```csharp
public OpeningSizeLibrary(DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary? openingSizeLibrary);
```
#### Parameters

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary.OpeningSizeLibrary(DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary).openingSizeLibrary'></a>

`openingSizeLibrary` [OpeningSizeLibrary](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSizeLibrary')

The [OpeningSizeLibrary](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSizeLibrary') to copy\. This value can be null\.

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary.OpeningSizeLibrary(System.Guid,string,string,string)'></a>

## OpeningSizeLibrary\(Guid, string, string, string\) Constructor

Initializes a new instance of the [OpeningSizeLibrary](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSizeLibrary') class with the specified identifier, so that a library generated more than once keeps the same identity\.

```csharp
public OpeningSizeLibrary(System.Guid guid, string? name, string? version, string? description);
```
#### Parameters

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary.OpeningSizeLibrary(System.Guid,string,string,string).guid'></a>

`guid` [System\.Guid](https://learn.microsoft.com/en-us/dotnet/api/system.guid 'System\.Guid')

The identifier of the library\.

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary.OpeningSizeLibrary(System.Guid,string,string,string).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the library\. This value can be null\.

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary.OpeningSizeLibrary(System.Guid,string,string,string).version'></a>

`version` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The version of the library\. This value can be null\.

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary.OpeningSizeLibrary(System.Guid,string,string,string).description'></a>

`description` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The description of the library\. This value can be null\.

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary.OpeningSizeLibrary(System.Text.Json.Nodes.JsonObject)'></a>

## OpeningSizeLibrary\(JsonObject\) Constructor

Initializes a new instance of the [OpeningSizeLibrary](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSizeLibrary') class from a JSON object\.

```csharp
public OpeningSizeLibrary(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary.OpeningSizeLibrary(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the data\. This value can be null\.
### Properties

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary.Description'></a>

## OpeningSizeLibrary\.Description Property

Gets the description of the library\.

```csharp
public string? Description { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary.Name'></a>

## OpeningSizeLibrary\.Name Property

Gets the name of the library\.

```csharp
public string? Name { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary.Version'></a>

## OpeningSizeLibrary\.Version Property

Gets the version of the library\.

```csharp
public string? Version { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')
### Methods

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary.Add(DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet)'></a>

## OpeningSizeLibrary\.Add\(OpeningSizeSet\) Method

Adds an opening size set to the library\.

```csharp
public bool Add(DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet? openingSizeSet);
```
#### Parameters

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary.Add(DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet).openingSizeSet'></a>

`openingSizeSet` [OpeningSizeSet](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSizeSet')

The opening size set\. This value can be null\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the set was added; false if it is null\.

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary.GetOpeningSizeSet(System.DateTimeOffset,DiGi.Analytical.Building.Regulation.Enums.BuildingType,string)'></a>

## OpeningSizeLibrary\.GetOpeningSizeSet\(DateTimeOffset, BuildingType, string\) Method

Gets the opening size set of a building of the specified type built on the specified date\.

Without [system](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary.GetOpeningSizeSet(System.DateTimeOffset,DiGi.Analytical.Building.Regulation.Enums.BuildingType,string).system 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSizeLibrary\.GetOpeningSizeSet\(System\.DateTimeOffset, DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType, string\)\.system') the set with no system, or the [DefaultSystem](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.DefaultSystem 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSizeSet\.DefaultSystem') one among several systems, is returned; with a system, only the set of that system (compared ignoring case). Among sets that equally apply the one starting latest wins.

```csharp
public DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet? GetOpeningSizeSet(System.DateTimeOffset dateTimeOffset, DiGi.Analytical.Building.Regulation.Enums.BuildingType buildingType, string? system=null);
```
#### Parameters

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary.GetOpeningSizeSet(System.DateTimeOffset,DiGi.Analytical.Building.Regulation.Enums.BuildingType,string).dateTimeOffset'></a>

`dateTimeOffset` [System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')

The date built \- 1 January of the year built when only the year is known\.

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary.GetOpeningSizeSet(System.DateTimeOffset,DiGi.Analytical.Building.Regulation.Enums.BuildingType,string).buildingType'></a>

`buildingType` [BuildingType](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.BuildingType 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType')

The building type\.

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary.GetOpeningSizeSet(System.DateTimeOffset,DiGi.Analytical.Building.Regulation.Enums.BuildingType,string).system'></a>

`system` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The large\-panel system, or null for the default\.

#### Returns
[OpeningSizeSet](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSizeSet')  
A CLONE of the [OpeningSizeSet](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSizeSet'), or null when none applies\.

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeLibrary.GetOpeningSizeSets()'></a>

## OpeningSizeLibrary\.GetOpeningSizeSets\(\) Method

Gets the opening size sets of the library\.

```csharp
public System.Collections.Generic.List<DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet> GetOpeningSizeSets();
```

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[OpeningSizeSet](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSizeSet')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
CLONES of the library's [OpeningSizeSet](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSizeSet')s\.

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet'></a>

## OpeningSizeSet Class

Represents the window and door sizes of the buildings of one type built in one date range, with the storey height and façade module of that stock \(DiGi\-Organization/DiGi\.GIS\.Analytical\#6\)\.

Keyed like a [ConstructionSet](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionSet 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionSet'): [BuildingType](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.BuildingType 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSizeSet\.BuildingType') and the range from [StartDate](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.StartDate 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSizeSet\.StartDate') to [EndDate](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.EndDate 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSizeSet\.EndDate'), looked up with the year built (no design lag). A large-panel stock has one set per prefabrication [System](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.System 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSizeSet\.System'); [DefaultSystem](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.DefaultSystem 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSizeSet\.DefaultSystem') marks the one a lookup without a system returns.

A room use whose rooms have no window in this stock (the internal bathrooms of large-panel blocks) is listed in [WindowlessRoomUses](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.WindowlessRoomUses 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSizeSet\.WindowlessRoomUses'), so a missing size is a documented "none", not a gap.

```csharp
public class OpeningSizeSet : DiGi.Core.Classes.SerializableObject, DiGi.Analytical.Building.Regulation.Interfaces.IRegulationSerializableObject, DiGi.Analytical.Building.Regulation.Interfaces.IRegulationObject, DiGi.Analytical.Building.Interfaces.IBuildingObject, DiGi.Analytical.Interfaces.IAnalyticalObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → OpeningSizeSet

Implements [IRegulationSerializableObject](DiGi.Analytical.Building.Regulation.Interfaces.md#DiGi.Analytical.Building.Regulation.Interfaces.IRegulationSerializableObject 'DiGi\.Analytical\.Building\.Regulation\.Interfaces\.IRegulationSerializableObject'), [IRegulationObject](DiGi.Analytical.Building.Regulation.Interfaces.md#DiGi.Analytical.Building.Regulation.Interfaces.IRegulationObject 'DiGi\.Analytical\.Building\.Regulation\.Interfaces\.IRegulationObject'), [DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.ibuildingobject 'DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject'), [DiGi\.Analytical\.Interfaces\.IAnalyticalObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.interfaces.ianalyticalobject 'DiGi\.Analytical\.Interfaces\.IAnalyticalObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.OpeningSizeSet(DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet)'></a>

## OpeningSizeSet\(OpeningSizeSet\) Constructor

Initializes a new instance of the [OpeningSizeSet](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSizeSet') class by copying an existing instance\.

```csharp
public OpeningSizeSet(DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet? openingSizeSet);
```
#### Parameters

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.OpeningSizeSet(DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet).openingSizeSet'></a>

`openingSizeSet` [OpeningSizeSet](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSizeSet')

The [OpeningSizeSet](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSizeSet') to copy\. This value can be null\.

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.OpeningSizeSet(DiGi.Analytical.Building.Regulation.Enums.BuildingType,System.DateTimeOffset,System.Nullable_System.DateTimeOffset_,string,bool,double,System.Nullable_double_,System.Collections.Generic.IEnumerable_DiGi.Analytical.Building.Regulation.Classes.OpeningSize_,System.Collections.Generic.IEnumerable_DiGi.Analytical.Building.Regulation.Enums.RoomUse_,string)'></a>

## OpeningSizeSet\(BuildingType, DateTimeOffset, Nullable\<DateTimeOffset\>, string, bool, double, Nullable\<double\>, IEnumerable\<OpeningSize\>, IEnumerable\<RoomUse\>, string\) Constructor

Initializes a new instance of the [OpeningSizeSet](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSizeSet') class\.

```csharp
public OpeningSizeSet(DiGi.Analytical.Building.Regulation.Enums.BuildingType buildingType, System.DateTimeOffset startDate, System.Nullable<System.DateTimeOffset> endDate, string? system, bool defaultSystem, double storeyHeight, System.Nullable<double> facadeModule, System.Collections.Generic.IEnumerable<DiGi.Analytical.Building.Regulation.Classes.OpeningSize>? openingSizes, System.Collections.Generic.IEnumerable<DiGi.Analytical.Building.Regulation.Enums.RoomUse>? windowlessRoomUses, string? source);
```
#### Parameters

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.OpeningSizeSet(DiGi.Analytical.Building.Regulation.Enums.BuildingType,System.DateTimeOffset,System.Nullable_System.DateTimeOffset_,string,bool,double,System.Nullable_double_,System.Collections.Generic.IEnumerable_DiGi.Analytical.Building.Regulation.Classes.OpeningSize_,System.Collections.Generic.IEnumerable_DiGi.Analytical.Building.Regulation.Enums.RoomUse_,string).buildingType'></a>

`buildingType` [BuildingType](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.BuildingType 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType')

The building type\.

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.OpeningSizeSet(DiGi.Analytical.Building.Regulation.Enums.BuildingType,System.DateTimeOffset,System.Nullable_System.DateTimeOffset_,string,bool,double,System.Nullable_double_,System.Collections.Generic.IEnumerable_DiGi.Analytical.Building.Regulation.Classes.OpeningSize_,System.Collections.Generic.IEnumerable_DiGi.Analytical.Building.Regulation.Enums.RoomUse_,string).startDate'></a>

`startDate` [System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')

The first date the set applies to\.

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.OpeningSizeSet(DiGi.Analytical.Building.Regulation.Enums.BuildingType,System.DateTimeOffset,System.Nullable_System.DateTimeOffset_,string,bool,double,System.Nullable_double_,System.Collections.Generic.IEnumerable_DiGi.Analytical.Building.Regulation.Classes.OpeningSize_,System.Collections.Generic.IEnumerable_DiGi.Analytical.Building.Regulation.Enums.RoomUse_,string).endDate'></a>

`endDate` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The first date the set no longer applies to, or null when it still applies\.

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.OpeningSizeSet(DiGi.Analytical.Building.Regulation.Enums.BuildingType,System.DateTimeOffset,System.Nullable_System.DateTimeOffset_,string,bool,double,System.Nullable_double_,System.Collections.Generic.IEnumerable_DiGi.Analytical.Building.Regulation.Classes.OpeningSize_,System.Collections.Generic.IEnumerable_DiGi.Analytical.Building.Regulation.Enums.RoomUse_,string).system'></a>

`system` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The large\-panel system of the stock, or null\.

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.OpeningSizeSet(DiGi.Analytical.Building.Regulation.Enums.BuildingType,System.DateTimeOffset,System.Nullable_System.DateTimeOffset_,string,bool,double,System.Nullable_double_,System.Collections.Generic.IEnumerable_DiGi.Analytical.Building.Regulation.Classes.OpeningSize_,System.Collections.Generic.IEnumerable_DiGi.Analytical.Building.Regulation.Enums.RoomUse_,string).defaultSystem'></a>

`defaultSystem` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

True when a lookup without a system returns this set among the systems of its range\.

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.OpeningSizeSet(DiGi.Analytical.Building.Regulation.Enums.BuildingType,System.DateTimeOffset,System.Nullable_System.DateTimeOffset_,string,bool,double,System.Nullable_double_,System.Collections.Generic.IEnumerable_DiGi.Analytical.Building.Regulation.Classes.OpeningSize_,System.Collections.Generic.IEnumerable_DiGi.Analytical.Building.Regulation.Enums.RoomUse_,string).storeyHeight'></a>

`storeyHeight` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The typical gross storey height of the stock \[m\]\.

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.OpeningSizeSet(DiGi.Analytical.Building.Regulation.Enums.BuildingType,System.DateTimeOffset,System.Nullable_System.DateTimeOffset_,string,bool,double,System.Nullable_double_,System.Collections.Generic.IEnumerable_DiGi.Analytical.Building.Regulation.Classes.OpeningSize_,System.Collections.Generic.IEnumerable_DiGi.Analytical.Building.Regulation.Enums.RoomUse_,string).facadeModule'></a>

`facadeModule` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The façade module the openings are placed on \[m\], or null when the stock has none\.

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.OpeningSizeSet(DiGi.Analytical.Building.Regulation.Enums.BuildingType,System.DateTimeOffset,System.Nullable_System.DateTimeOffset_,string,bool,double,System.Nullable_double_,System.Collections.Generic.IEnumerable_DiGi.Analytical.Building.Regulation.Classes.OpeningSize_,System.Collections.Generic.IEnumerable_DiGi.Analytical.Building.Regulation.Enums.RoomUse_,string).openingSizes'></a>

`openingSizes` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[OpeningSize](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSize 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSize')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The window and door sizes; the items are copied\. This value can be null\.

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.OpeningSizeSet(DiGi.Analytical.Building.Regulation.Enums.BuildingType,System.DateTimeOffset,System.Nullable_System.DateTimeOffset_,string,bool,double,System.Nullable_double_,System.Collections.Generic.IEnumerable_DiGi.Analytical.Building.Regulation.Classes.OpeningSize_,System.Collections.Generic.IEnumerable_DiGi.Analytical.Building.Regulation.Enums.RoomUse_,string).windowlessRoomUses'></a>

`windowlessRoomUses` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[RoomUse](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.RoomUse 'DiGi\.Analytical\.Building\.Regulation\.Enums\.RoomUse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The room uses whose rooms have no window in this stock\. This value can be null\.

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.OpeningSizeSet(DiGi.Analytical.Building.Regulation.Enums.BuildingType,System.DateTimeOffset,System.Nullable_System.DateTimeOffset_,string,bool,double,System.Nullable_double_,System.Collections.Generic.IEnumerable_DiGi.Analytical.Building.Regulation.Classes.OpeningSize_,System.Collections.Generic.IEnumerable_DiGi.Analytical.Building.Regulation.Enums.RoomUse_,string).source'></a>

`source` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The sources of the storey height, the module and the choice of sizes, each with its tag\. This value can be null\.

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.OpeningSizeSet(System.Text.Json.Nodes.JsonObject)'></a>

## OpeningSizeSet\(JsonObject\) Constructor

Initializes a new instance of the [OpeningSizeSet](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSizeSet') class from a JSON object\.

```csharp
public OpeningSizeSet(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.OpeningSizeSet(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the data\. This value can be null\.
### Properties

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.BuildingType'></a>

## OpeningSizeSet\.BuildingType Property

Gets the building type\.

```csharp
public DiGi.Analytical.Building.Regulation.Enums.BuildingType BuildingType { get; }
```

#### Property Value
[BuildingType](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.BuildingType 'DiGi\.Analytical\.Building\.Regulation\.Enums\.BuildingType')

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.DefaultSystem'></a>

## OpeningSizeSet\.DefaultSystem Property

Gets a value indicating whether a lookup without a system returns this set among the systems of its range\.

```csharp
public bool DefaultSystem { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.EndDate'></a>

## OpeningSizeSet\.EndDate Property

Gets the first date the set no longer applies to, or null when it still applies\.

```csharp
public System.Nullable<System.DateTimeOffset> EndDate { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.FacadeModule'></a>

## OpeningSizeSet\.FacadeModule Property

Gets the façade module the openings are placed on \[m\], or null when the stock has none\.

```csharp
public System.Nullable<double> FacadeModule { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.Source'></a>

## OpeningSizeSet\.Source Property

Gets the sources of the storey height, the module and the choice of sizes, each with its tag\.

```csharp
public string? Source { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.StartDate'></a>

## OpeningSizeSet\.StartDate Property

Gets the first date the set applies to\.

```csharp
public System.DateTimeOffset StartDate { get; }
```

#### Property Value
[System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.StoreyHeight'></a>

## OpeningSizeSet\.StoreyHeight Property

Gets the typical gross storey height of the stock \[m\]\.

```csharp
public double StoreyHeight { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.System'></a>

## OpeningSizeSet\.System Property

Gets the large\-panel system of the stock, or null\.

```csharp
public string? System { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.WindowlessRoomUses'></a>

## OpeningSizeSet\.WindowlessRoomUses Property

Gets a copy of the room uses whose rooms have no window in this stock\.

```csharp
public System.Collections.Generic.List<DiGi.Analytical.Building.Regulation.Enums.RoomUse> WindowlessRoomUses { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[RoomUse](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.RoomUse 'DiGi\.Analytical\.Building\.Regulation\.Enums\.RoomUse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')
### Methods

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.GetOpeningSize(DiGi.Analytical.Building.Regulation.Enums.OpeningKind,DiGi.Analytical.Building.Regulation.Enums.RoomUse)'></a>

## OpeningSizeSet\.GetOpeningSize\(OpeningKind, RoomUse\) Method

Gets the size of an opening of the specified kind serving a room of the specified use: the size for that use, else the size for [Other](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.RoomUse.Other 'DiGi\.Analytical\.Building\.Regulation\.Enums\.RoomUse\.Other'), else the first size of that kind\.

```csharp
public DiGi.Analytical.Building.Regulation.Classes.OpeningSize? GetOpeningSize(DiGi.Analytical.Building.Regulation.Enums.OpeningKind openingKind, DiGi.Analytical.Building.Regulation.Enums.RoomUse roomUse);
```
#### Parameters

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.GetOpeningSize(DiGi.Analytical.Building.Regulation.Enums.OpeningKind,DiGi.Analytical.Building.Regulation.Enums.RoomUse).openingKind'></a>

`openingKind` [OpeningKind](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.OpeningKind 'DiGi\.Analytical\.Building\.Regulation\.Enums\.OpeningKind')

The opening kind\.

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.GetOpeningSize(DiGi.Analytical.Building.Regulation.Enums.OpeningKind,DiGi.Analytical.Building.Regulation.Enums.RoomUse).roomUse'></a>

`roomUse` [RoomUse](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.RoomUse 'DiGi\.Analytical\.Building\.Regulation\.Enums\.RoomUse')

The room use\.

#### Returns
[OpeningSize](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSize 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSize')  
A CLONE of the [OpeningSize](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSize 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSize'), or null when the set has no size of that kind or [roomUse](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.GetOpeningSize(DiGi.Analytical.Building.Regulation.Enums.OpeningKind,DiGi.Analytical.Building.Regulation.Enums.RoomUse).roomUse 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSizeSet\.GetOpeningSize\(DiGi\.Analytical\.Building\.Regulation\.Enums\.OpeningKind, DiGi\.Analytical\.Building\.Regulation\.Enums\.RoomUse\)\.roomUse') is one of [WindowlessRoomUses](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.WindowlessRoomUses 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSizeSet\.WindowlessRoomUses')\.

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.GetOpeningSizes()'></a>

## OpeningSizeSet\.GetOpeningSizes\(\) Method

Gets the window and door sizes of the set\.

```csharp
public System.Collections.Generic.List<DiGi.Analytical.Building.Regulation.Classes.OpeningSize> GetOpeningSizes();
```

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[OpeningSize](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSize 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSize')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
CLONES of the [OpeningSize](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSize 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSize')s\.

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.Includes(System.DateTimeOffset)'></a>

## OpeningSizeSet\.Includes\(DateTimeOffset\) Method

Determines whether the set applies to the specified date: on or after [StartDate](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.StartDate 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSizeSet\.StartDate') and before [EndDate](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.EndDate 'DiGi\.Analytical\.Building\.Regulation\.Classes\.OpeningSizeSet\.EndDate'), compared by calendar date\.

```csharp
public bool Includes(System.DateTimeOffset dateTimeOffset);
```
#### Parameters

<a name='DiGi.Analytical.Building.Regulation.Classes.OpeningSizeSet.Includes(System.DateTimeOffset).dateTimeOffset'></a>

`dateTimeOffset` [System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')

The date built\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the set applies to the date; otherwise, false\.