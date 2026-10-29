#### [DiGi\.Analytical\.Building\.Regulation](DiGi.Analytical.Building.Regulation.Overview.md 'DiGi\.Analytical\.Building\.Regulation\.Overview')

## DiGi\.Analytical\.Building\.Regulation Namespace
### Classes

<a name='DiGi.Analytical.Building.Regulation.Query'></a>

## Query Class

```csharp
public static class Query
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Query
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