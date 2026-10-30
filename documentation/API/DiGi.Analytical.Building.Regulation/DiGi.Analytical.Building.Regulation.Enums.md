#### [DiGi\.Analytical\.Building\.Regulation](DiGi.Analytical.Building.Regulation.Overview.md 'DiGi\.Analytical\.Building\.Regulation\.Overview')

## DiGi\.Analytical\.Building\.Regulation\.Enums Namespace
### Enums

<a name='DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation'></a>

## BuildingRegulation Enum

Specifies the Polish building regulation regime a building was designed under \(DiGi\-Organization/DiGi\.Analytical\#8, moved here from the design of DiGi\-Organization/DiGi\.GIS\.Analytical\#2\)\.

The regime decides the geometric and fire rules of a design (daylight, distances, fire separation). The thermal limits change on their own dates, which is why the construction library is keyed by date range, not by this regime.

```csharp
public enum BuildingRegulation
```
### Fields

<a name='DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation.Undefined'></a>

`Undefined` 0

The regime is not known\.

<a name='DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation.PL_Before1928'></a>

`PL_Before1928` 1

Partition\-era local building codes, before the 1928 regulation\.

<a name='DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation.PL_1928'></a>

`PL_1928` 2

Rozporządzenie Prezydenta RP o prawie budowlanym \(Dz\.U\. 1928 nr 23 poz\. 202\), in force until 1961\.

<a name='DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation.PL_1961'></a>

`PL_1961` 3

Prawo budowlane of 1961 with its technical regulations\.

<a name='DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation.PL_1980'></a>

`PL_1980` 4

The technical conditions of 1980 \(Dz\.U\. 1980 nr 17 poz\. 62\)\.

<a name='DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation.PL_1994'></a>

`PL_1994` 5

The technical conditions of 1994 \(Dz\.U\. 1995 nr 10 poz\. 46\), in force from 1 April 1995\.

<a name='DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation.PL_WT2002'></a>

`PL_WT2002` 6

The technical conditions of 2002 \(Dz\.U\. 2002 nr 75 poz\. 690\), in force from 16 December 2002\.

<a name='DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation.PL_WT2009'></a>

`PL_WT2009` 7

The technical conditions of 2002 as amended in 2008 \(Dz\.U\. 2008 nr 201 poz\. 1238\), from 1 January 2009\.

<a name='DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation.PL_WT2014'></a>

`PL_WT2014` 8

The 2014 stage of the 2013 amendment \(Dz\.U\. 2013 poz\. 926\)\.

<a name='DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation.PL_WT2017'></a>

`PL_WT2017` 9

The 2017 stage of the 2013 amendment \(Dz\.U\. 2013 poz\. 926\), from 1 January 2017\.

<a name='DiGi.Analytical.Building.Regulation.Enums.BuildingRegulation.PL_WT2021'></a>

`PL_WT2021` 10

The last stage \(Dz\.U\. 2017 poz\. 2285\), from 31 December 2020\.

<a name='DiGi.Analytical.Building.Regulation.Enums.BuildingType'></a>

## BuildingType Enum

Specifies the residential building type of the TABULA / EPISCOPE typology \(DiGi\-Organization/DiGi\.Analytical\#8\)\.

For the regulations, a single-family and a terraced house are single-family buildings, and a multi-family building and an apartment block are multi-family buildings.

```csharp
public enum BuildingType
```
### Fields

<a name='DiGi.Analytical.Building.Regulation.Enums.BuildingType.Undefined'></a>

`Undefined` 0

The type is not known\.

<a name='DiGi.Analytical.Building.Regulation.Enums.BuildingType.SingleFamily'></a>

`SingleFamily` 1

A detached single\-family house \(TABULA SFH\)\.

<a name='DiGi.Analytical.Building.Regulation.Enums.BuildingType.Terraced'></a>

`Terraced` 2

A terraced or semi\-detached house \(TABULA TH\)\.

<a name='DiGi.Analytical.Building.Regulation.Enums.BuildingType.MultiFamily'></a>

`MultiFamily` 3

A multi\-family house \(TABULA MFH\)\.

<a name='DiGi.Analytical.Building.Regulation.Enums.BuildingType.ApartmentBlock'></a>

`ApartmentBlock` 4

An apartment block or tower block \(TABULA AB\)\.

<a name='DiGi.Analytical.Building.Regulation.Enums.ClimateZone'></a>

## ClimateZone Enum

Specifies the Polish climatic zone of PN\-82/B\-02403, on which the window limits of the regulations until 2013 depend \(zones I\-III against IV\-V\) \(DiGi\-Organization/DiGi\.Analytical\#8\)\.

```csharp
public enum ClimateZone
```
### Fields

<a name='DiGi.Analytical.Building.Regulation.Enums.ClimateZone.Undefined'></a>

`Undefined` 0

The zone is not known\.

<a name='DiGi.Analytical.Building.Regulation.Enums.ClimateZone.I'></a>

`I` 1

Climatic zone I \(design outdoor temperature \-16 °C\)\.

<a name='DiGi.Analytical.Building.Regulation.Enums.ClimateZone.II'></a>

`II` 2

Climatic zone II \(\-18 °C\)\.

<a name='DiGi.Analytical.Building.Regulation.Enums.ClimateZone.III'></a>

`III` 3

Climatic zone III \(\-20 °C\)\.

<a name='DiGi.Analytical.Building.Regulation.Enums.ClimateZone.IV'></a>

`IV` 4

Climatic zone IV \(\-22 °C\)\.

<a name='DiGi.Analytical.Building.Regulation.Enums.ClimateZone.V'></a>

`V` 5

Climatic zone V \(\-24 °C\)\.

<a name='DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour'></a>

## ConstructionFlavour Enum

Specifies which kind of construction a construction set describes \(DiGi\-Organization/DiGi\.Analytical\#8\)\.

```csharp
public enum ConstructionFlavour
```
### Fields

<a name='DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour.Undefined'></a>

`Undefined` 0

The flavour is not known\.

<a name='DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour.Regulation'></a>

`Regulation` 1

The minimum assemblies meeting the thermal limits of the regulation in force; looked up by design date\.

<a name='DiGi.Analytical.Building.Regulation.Enums.ConstructionFlavour.TypicalAsBuilt'></a>

`TypicalAsBuilt` 2

The assemblies typically built in the period \(TABULA / NAPE\), usually worse than the regulation; looked up by year built\.

<a name='DiGi.Analytical.Building.Regulation.Enums.ConstructionPeriod'></a>

## ConstructionPeriod Enum

Specifies the construction period of a Polish residential building, as used by the TABULA / EPISCOPE Polish typology of NAPE \(DiGi\-Organization/DiGi\.Analytical\#8\)\.

The periods are of construction (year built), so no design lag applies to them.

```csharp
public enum ConstructionPeriod
```
### Fields

<a name='DiGi.Analytical.Building.Regulation.Enums.ConstructionPeriod.Undefined'></a>

`Undefined` 0

The period is not known\.

<a name='DiGi.Analytical.Building.Regulation.Enums.ConstructionPeriod.Until1945'></a>

`Until1945` 1

Built in 1945 or earlier\.

<a name='DiGi.Analytical.Building.Regulation.Enums.ConstructionPeriod.From1946To1966'></a>

`From1946To1966` 2

Built 1946\-1966\.

<a name='DiGi.Analytical.Building.Regulation.Enums.ConstructionPeriod.From1967To1985'></a>

`From1967To1985` 3

Built 1967\-1985: the large\-panel period\.

<a name='DiGi.Analytical.Building.Regulation.Enums.ConstructionPeriod.From1986To1992'></a>

`From1986To1992` 4

Built 1986\-1992\.

<a name='DiGi.Analytical.Building.Regulation.Enums.ConstructionPeriod.From1993To2002'></a>

`From1993To2002` 5

Built 1993\-2002\.

<a name='DiGi.Analytical.Building.Regulation.Enums.ConstructionPeriod.From2003To2008'></a>

`From2003To2008` 6

Built 2003\-2008\.

<a name='DiGi.Analytical.Building.Regulation.Enums.ConstructionPeriod.From2009'></a>

`From2009` 7

Built in 2009 or later\.

<a name='DiGi.Analytical.Building.Regulation.Enums.ConstructionRole'></a>

## ConstructionRole Enum

Specifies the element a construction of a construction set is used for \(DiGi\-Organization/DiGi\.Analytical\#8\)\.

```csharp
public enum ConstructionRole
```
### Fields

<a name='DiGi.Analytical.Building.Regulation.Enums.ConstructionRole.Undefined'></a>

`Undefined` 0

The role is not known\.

<a name='DiGi.Analytical.Building.Regulation.Enums.ConstructionRole.ExternalWall'></a>

`ExternalWall` 1

An external wall in contact with outside air\.

<a name='DiGi.Analytical.Building.Regulation.Enums.ConstructionRole.InternalWall'></a>

`InternalWall` 2

An internal wall within the building\.

<a name='DiGi.Analytical.Building.Regulation.Enums.ConstructionRole.PartyWall'></a>

`PartyWall` 3

A wall shared with an adjacent building\.

<a name='DiGi.Analytical.Building.Regulation.Enums.ConstructionRole.Roof'></a>

`Roof` 4

A pitched roof, or the ceiling under an unheated attic\.

<a name='DiGi.Analytical.Building.Regulation.Enums.ConstructionRole.FlatRoof'></a>

`FlatRoof` 5

A flat roof \(stropodach\)\.

<a name='DiGi.Analytical.Building.Regulation.Enums.ConstructionRole.GroundFloor'></a>

`GroundFloor` 6

A floor on ground\.

<a name='DiGi.Analytical.Building.Regulation.Enums.ConstructionRole.FloorOverUnheated'></a>

`FloorOverUnheated` 7

A floor over an unheated basement or a closed underfloor space\.

<a name='DiGi.Analytical.Building.Regulation.Enums.ConstructionRole.IntermediateFloor'></a>

`IntermediateFloor` 8

An intermediate floor between heated storeys\.

<a name='DiGi.Analytical.Building.Regulation.Enums.ConstructionRole.Window'></a>

`Window` 9

A window in an external wall\.

<a name='DiGi.Analytical.Building.Regulation.Enums.ConstructionRole.RoofWindow'></a>

`RoofWindow` 10

A roof window or skylight\.

<a name='DiGi.Analytical.Building.Regulation.Enums.ConstructionRole.BalconyDoor'></a>

`BalconyDoor` 11

A balcony door: door\-sized, but under the window limits of the regulations\.

<a name='DiGi.Analytical.Building.Regulation.Enums.ConstructionRole.ExternalDoor'></a>

`ExternalDoor` 12

The entrance door of a single\-family building\.

<a name='DiGi.Analytical.Building.Regulation.Enums.ConstructionRole.StaircaseEntranceDoor'></a>

`StaircaseEntranceDoor` 13

The staircase entrance door of a multi\-family building, usually two\-leaved and glazed\.

<a name='DiGi.Analytical.Building.Regulation.Enums.ConstructionRole.DoorToUnheatedSpace'></a>

`DoorToUnheatedSpace` 14

A door between heated and unheated spaces\.

<a name='DiGi.Analytical.Building.Regulation.Enums.ConstructionRole.GarageDoor'></a>

`GarageDoor` 15

A garage door or gate\.

<a name='DiGi.Analytical.Building.Regulation.Enums.FloorBoundary'></a>

## FloorBoundary Enum

Specifies what the lowest floor of a typology building borders, as TABULA records it \(code\_constructionborder\_floor\) \(DiGi\-Organization/DiGi\.Analytical\#17\)\.

```csharp
public enum FloorBoundary
```
### Fields

<a name='DiGi.Analytical.Building.Regulation.Enums.FloorBoundary.Undefined'></a>

`Undefined` 0

Undefined floor boundary\.

<a name='DiGi.Analytical.Building.Regulation.Enums.FloorBoundary.Soil'></a>

`Soil` 1

The floor lies on the ground \(TABULA "Soil"\)\.

<a name='DiGi.Analytical.Building.Regulation.Enums.FloorBoundary.Cellar'></a>

`Cellar` 2

The floor lies over an unheated cellar \(TABULA "Cellar"\); the cellar adds [AdditionalFloorResistance](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.TypologyData.AdditionalFloorResistance 'DiGi\.Analytical\.Building\.Regulation\.Classes\.TypologyData\.AdditionalFloorResistance')\.

<a name='DiGi.Analytical.Building.Regulation.Enums.OpeningKind'></a>

## OpeningKind Enum

Specifies the kind of a window or door of an opening size set \(DiGi\-Organization/DiGi\.GIS\.Analytical\#6\)\.

Finer than [ConstructionRole](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.ConstructionRole 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionRole'): a staircase window has its own size but the construction of a window, which [OpeningConstructionRole\(this OpeningKind\)](DiGi.Analytical.Building.Regulation.md#DiGi.Analytical.Building.Regulation.Query.OpeningConstructionRole(thisDiGi.Analytical.Building.Regulation.Enums.OpeningKind) 'DiGi\.Analytical\.Building\.Regulation\.Query\.OpeningConstructionRole\(this DiGi\.Analytical\.Building\.Regulation\.Enums\.OpeningKind\)') maps it to.

```csharp
public enum OpeningKind
```
### Fields

<a name='DiGi.Analytical.Building.Regulation.Enums.OpeningKind.Undefined'></a>

`Undefined` 0

Undefined opening kind\.

<a name='DiGi.Analytical.Building.Regulation.Enums.OpeningKind.Window'></a>

`Window` 1

Window of a room, with a sill\.

<a name='DiGi.Analytical.Building.Regulation.Enums.OpeningKind.StaircaseWindow'></a>

`StaircaseWindow` 2

Window of a staircase, usually between storeys\.

<a name='DiGi.Analytical.Building.Regulation.Enums.OpeningKind.BalconyDoor'></a>

`BalconyDoor` 3

Balcony or loggia door: door\-sized and reaching the floor, but glazed and under the window limits, so no sill rule applies\.

<a name='DiGi.Analytical.Building.Regulation.Enums.OpeningKind.RoofWindow'></a>

`RoofWindow` 4

Roof window\.

<a name='DiGi.Analytical.Building.Regulation.Enums.OpeningKind.EntranceDoor'></a>

`EntranceDoor` 5

Entrance door of a single\-family or terraced house\.

<a name='DiGi.Analytical.Building.Regulation.Enums.OpeningKind.StaircaseEntranceDoor'></a>

`StaircaseEntranceDoor` 6

Entrance door of the staircase of a multi\-family building, usually two leaves\.

<a name='DiGi.Analytical.Building.Regulation.Enums.OpeningKind.DoorToUnheatedSpace'></a>

`DoorToUnheatedSpace` 7

Door to an unheated space \(cellar, garage, attic\)\.

<a name='DiGi.Analytical.Building.Regulation.Enums.OpeningKind.GarageDoor'></a>

`GarageDoor` 8

Garage door\.

<a name='DiGi.Analytical.Building.Regulation.Enums.RoofType'></a>

## RoofType Enum

Specifies the roof type of a typology building, as TABULA records it \(code\_rooftype\) \(DiGi\-Organization/DiGi\.Analytical\#17\)\.

```csharp
public enum RoofType
```
### Fields

<a name='DiGi.Analytical.Building.Regulation.Enums.RoofType.Undefined'></a>

`Undefined` 0

Undefined roof type\.

<a name='DiGi.Analytical.Building.Regulation.Enums.RoofType.Pitched'></a>

`Pitched` 1

A pitched roof \(TABULA "TR"\)\.

<a name='DiGi.Analytical.Building.Regulation.Enums.RoofType.Flat'></a>

`Flat` 2

A flat roof \(TABULA "FR"\)\.

<a name='DiGi.Analytical.Building.Regulation.Enums.RoomUse'></a>

## RoomUse Enum

Specifies the use of the room an opening of an opening size set serves \(DiGi\-Organization/DiGi\.GIS\.Analytical\#6\)\.

```csharp
public enum RoomUse
```
### Fields

<a name='DiGi.Analytical.Building.Regulation.Enums.RoomUse.Undefined'></a>

`Undefined` 0

Undefined room use\.

<a name='DiGi.Analytical.Building.Regulation.Enums.RoomUse.LivingRoom'></a>

`LivingRoom` 1

Living room or bedroom: a room for the permanent stay of people\.

<a name='DiGi.Analytical.Building.Regulation.Enums.RoomUse.Kitchen'></a>

`Kitchen` 2

Kitchen\.

<a name='DiGi.Analytical.Building.Regulation.Enums.RoomUse.Bathroom'></a>

`Bathroom` 3

Bathroom or WC\.

<a name='DiGi.Analytical.Building.Regulation.Enums.RoomUse.Staircase'></a>

`Staircase` 4

Staircase\.

<a name='DiGi.Analytical.Building.Regulation.Enums.RoomUse.Other'></a>

`Other` 5

Any other room, and the fallback of a lookup by room use\.