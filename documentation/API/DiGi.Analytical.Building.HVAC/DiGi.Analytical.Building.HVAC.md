#### [DiGi\.Analytical\.Building\.HVAC](DiGi.Analytical.Building.HVAC.Overview.md 'DiGi\.Analytical\.Building\.HVAC\.Overview')

## DiGi\.Analytical\.Building\.HVAC Namespace
### Classes

<a name='DiGi.Analytical.Building.HVAC.Create'></a>

## Create Class

```csharp
public static class Create
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Create
### Fields

<a name='DiGi.Analytical.Building.HVAC.Create.UsageProfileSource_ASHRAE'></a>

## Create\.UsageProfileSource\_ASHRAE Field

The source tag of a value from ASHRAE Standard 90\.1\-1989 and addenda, as published in the Seattle Energy Code 2018, Appendix B \(Tables B102 and B103\)\.

```csharp
public const string UsageProfileSource_ASHRAE = "ASHRAE-90.1";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.HVAC.Create.UsageProfileSource_Default'></a>

## Create\.UsageProfileSource\_Default Field

The source tag of an uncited value, to be replaced by a cited one\.

```csharp
public const string UsageProfileSource_Default = "DEFAULT";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.HVAC.Create.UsageProfileSource_PL376'></a>

## Create\.UsageProfileSource\_PL376 Field

The source tag of a value from the Polish energy\-certificate methodology, Dz\.U\. 2015 poz\. 376, Annex 1 \(amended by Dz\.U\. 2017 poz\. 22, 2019 poz\. 1829 and 2023 poz\. 697, none of which changes Tables 23\-27\)\.

```csharp
public const string UsageProfileSource_PL376 = "PL-376";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.HVAC.Create.UsageProfileSource_PLWT'></a>

## Create\.UsageProfileSource\_PLWT Field

The source tag of a value from the technical conditions, Dz\.U\. 2022 poz\. 1225 \(consolidated text\), § 134 ust\. 2\.

```csharp
public const string UsageProfileSource_PLWT = "PL-WT";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')
### Methods

<a name='DiGi.Analytical.Building.HVAC.Create.InternalCondition(thisDiGi.Analytical.Building.HVAC.Classes.UsageProfile,System.Nullable_int_,System.Nullable_double_,System.Nullable_double_,string)'></a>

## Create\.InternalCondition\(this UsageProfile, Nullable\<int\>, Nullable\<double\>, Nullable\<double\>, string\) Method

Creates the internal condition of a building from its usage profile \(DiGi\-Organization/DiGi\.Analytical\#9\)\.

It holds a thermostat lower limit at [HeatingSetPoint](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.UsageProfile.HeatingSetPoint 'DiGi\.Analytical\.Building\.HVAC\.Classes\.UsageProfile\.HeatingSetPoint') (continuous heating: neither source gives a set-back), a [TotalInternalGain](DiGi.Analytical.Building.HVAC.Enums.md#DiGi.Analytical.Building.HVAC.Enums.InternalGainProfileType.TotalInternalGain 'DiGi\.Analytical\.Building\.HVAC\.Enums\.InternalGainProfileType\.TotalInternalGain') profile [W/m2] - constant, or the weekly profile when the usage profile has one - and an [Infiltration](DiGi.Analytical.Building.HVAC.Enums.md#DiGi.Analytical.Building.HVAC.Enums.InternalGainProfileType.Infiltration 'DiGi\.Analytical\.Building\.HVAC\.Enums\.InternalGainProfileType\.Infiltration') profile [1/h] of 0.2 for a building erected after 1995 and 0.3 otherwise or when unknown (Dz.U. 2015 poz. 376, Annex 1, eq. 70). [SystemProperties](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.SystemProperties 'DiGi\.Analytical\.Building\.HVAC\.Classes\.SystemProperties') holds the hot water V_Wi · k_R [l/(d m2)], the outside airflow per area [l/(s m2)] and the sensible gain per person as the metabolic rate; ventilation stays per area, as converting it to air changes needs the volume of each space.

<b>Occupancy scaling.</b> With [occupancy](DiGi.Analytical.Building.HVAC.md#DiGi.Analytical.Building.HVAC.Create.InternalCondition(thisDiGi.Analytical.Building.HVAC.Classes.UsageProfile,System.Nullable_int_,System.Nullable_double_,System.Nullable_double_,string).occupancy 'DiGi\.Analytical\.Building\.HVAC\.Create\.InternalCondition\(this DiGi\.Analytical\.Building\.HVAC\.Classes\.UsageProfile, System\.Nullable\<int\>, System\.Nullable\<double\>, System\.Nullable\<double\>, string\)\.occupancy') and [floorArea](DiGi.Analytical.Building.HVAC.md#DiGi.Analytical.Building.HVAC.Create.InternalCondition(thisDiGi.Analytical.Building.HVAC.Classes.UsageProfile,System.Nullable_int_,System.Nullable_double_,System.Nullable_double_,string).floorArea 'DiGi\.Analytical\.Building\.HVAC\.Create\.InternalCondition\(this DiGi\.Analytical\.Building\.HVAC\.Classes\.UsageProfile, System\.Nullable\<int\>, System\.Nullable\<double\>, System\.Nullable\<double\>, string\)\.floorArea') both positive, the people share of the values follows the actual persons instead of the standard occupancy of [FloorAreaPerPerson](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.UsageProfile.FloorAreaPerPerson 'DiGi\.Analytical\.Building\.HVAC\.Classes\.UsageProfile\.FloorAreaPerPerson'): the hot water is multiplied by persons · a_std / A, and the internal gain is shifted by (persons / A - 1 / a_std) · [PersonGain](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.UsageProfile.PersonGain 'DiGi\.Analytical\.Building\.HVAC\.Classes\.UsageProfile\.PersonGain'), never below 0. This departs from the per-area values of the methodology, so [OccupancyScaled](DiGi.Analytical.Building.HVAC.Enums.md#DiGi.Analytical.Building.HVAC.Enums.InternalConditionParameter.OccupancyScaled 'DiGi\.Analytical\.Building\.HVAC\.Enums\.InternalConditionParameter\.OccupancyScaled') records it.

<b>Provenance.</b> The name is the usage type, the description and [UsageSource](DiGi.Analytical.Building.HVAC.Enums.md#DiGi.Analytical.Building.HVAC.Enums.InternalConditionParameter.UsageSource 'DiGi\.Analytical\.Building\.HVAC\.Enums\.InternalConditionParameter\.UsageSource') carry [Source](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.UsageProfile.Source 'DiGi\.Analytical\.Building\.HVAC\.Classes\.UsageProfile\.Source'), and [UsageType](DiGi.Analytical.Building.HVAC.Enums.md#DiGi.Analytical.Building.HVAC.Enums.InternalConditionParameter.UsageType 'DiGi\.Analytical\.Building\.HVAC\.Enums\.InternalConditionParameter\.UsageType'), [Occupancy](DiGi.Analytical.Building.HVAC.Enums.md#DiGi.Analytical.Building.HVAC.Enums.InternalConditionParameter.Occupancy 'DiGi\.Analytical\.Building\.HVAC\.Enums\.InternalConditionParameter\.Occupancy'), [OccupancySource](DiGi.Analytical.Building.HVAC.Enums.md#DiGi.Analytical.Building.HVAC.Enums.InternalConditionParameter.OccupancySource 'DiGi\.Analytical\.Building\.HVAC\.Enums\.InternalConditionParameter\.OccupancySource') and [OccupancyScaled](DiGi.Analytical.Building.HVAC.Enums.md#DiGi.Analytical.Building.HVAC.Enums.InternalConditionParameter.OccupancyScaled 'DiGi\.Analytical\.Building\.HVAC\.Enums\.InternalConditionParameter\.OccupancyScaled') are set.

```csharp
public static DiGi.Analytical.Building.Classes.InternalCondition? InternalCondition(this DiGi.Analytical.Building.HVAC.Classes.UsageProfile? usageProfile, System.Nullable<int> yearBuilt=null, System.Nullable<double> occupancy=null, System.Nullable<double> floorArea=null, string? occupancySource=null);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Create.InternalCondition(thisDiGi.Analytical.Building.HVAC.Classes.UsageProfile,System.Nullable_int_,System.Nullable_double_,System.Nullable_double_,string).usageProfile'></a>

`usageProfile` [UsageProfile](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.UsageProfile 'DiGi\.Analytical\.Building\.HVAC\.Classes\.UsageProfile')

The usage profile, from [UsageProfile\(this UsageType, Nullable&lt;double&gt;, Nullable&lt;double&gt;, bool, bool\)](DiGi.Analytical.Building.HVAC.md#DiGi.Analytical.Building.HVAC.Create.UsageProfile(thisDiGi.Analytical.Building.HVAC.Enums.UsageType,System.Nullable_double_,System.Nullable_double_,bool,bool) 'DiGi\.Analytical\.Building\.HVAC\.Create\.UsageProfile\(this DiGi\.Analytical\.Building\.HVAC\.Enums\.UsageType, System\.Nullable\<double\>, System\.Nullable\<double\>, bool, bool\)')\.

<a name='DiGi.Analytical.Building.HVAC.Create.InternalCondition(thisDiGi.Analytical.Building.HVAC.Classes.UsageProfile,System.Nullable_int_,System.Nullable_double_,System.Nullable_double_,string).yearBuilt'></a>

`yearBuilt` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The year the building was erected \(or its windows replaced\); null when unknown\.

<a name='DiGi.Analytical.Building.HVAC.Create.InternalCondition(thisDiGi.Analytical.Building.HVAC.Classes.UsageProfile,System.Nullable_int_,System.Nullable_double_,System.Nullable_double_,string).occupancy'></a>

`occupancy` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The number of persons in the building; null when unknown\.

<a name='DiGi.Analytical.Building.HVAC.Create.InternalCondition(thisDiGi.Analytical.Building.HVAC.Classes.UsageProfile,System.Nullable_int_,System.Nullable_double_,System.Nullable_double_,string).floorArea'></a>

`floorArea` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The heated floor area of the building \[m2\], the area the persons share; null when unknown\.

<a name='DiGi.Analytical.Building.HVAC.Create.InternalCondition(thisDiGi.Analytical.Building.HVAC.Classes.UsageProfile,System.Nullable_int_,System.Nullable_double_,System.Nullable_double_,string).occupancySource'></a>

`occupancySource` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

Where [occupancy](DiGi.Analytical.Building.HVAC.md#DiGi.Analytical.Building.HVAC.Create.InternalCondition(thisDiGi.Analytical.Building.HVAC.Classes.UsageProfile,System.Nullable_int_,System.Nullable_double_,System.Nullable_double_,string).occupancy 'DiGi\.Analytical\.Building\.HVAC\.Create\.InternalCondition\(this DiGi\.Analytical\.Building\.HVAC\.Classes\.UsageProfile, System\.Nullable\<int\>, System\.Nullable\<double\>, System\.Nullable\<double\>, string\)\.occupancy') comes from\. This value can be null\.

#### Returns
[DiGi\.Analytical\.Building\.Classes\.InternalCondition](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.internalcondition 'DiGi\.Analytical\.Building\.Classes\.InternalCondition')  
The internal condition, or null when [usageProfile](DiGi.Analytical.Building.HVAC.md#DiGi.Analytical.Building.HVAC.Create.InternalCondition(thisDiGi.Analytical.Building.HVAC.Classes.UsageProfile,System.Nullable_int_,System.Nullable_double_,System.Nullable_double_,string).usageProfile 'DiGi\.Analytical\.Building\.HVAC\.Create\.InternalCondition\(this DiGi\.Analytical\.Building\.HVAC\.Classes\.UsageProfile, System\.Nullable\<int\>, System\.Nullable\<double\>, System\.Nullable\<double\>, string\)\.usageProfile') is null\.

<a name='DiGi.Analytical.Building.HVAC.Create.RegulatedHeatTransferCoefficientsManager()'></a>

## Create\.RegulatedHeatTransferCoefficientsManager\(\) Method

Creates and initializes a new instance of the [RegulatedHeatTransferCoefficientsManager\(\)](DiGi.Analytical.Building.HVAC.md#DiGi.Analytical.Building.HVAC.Create.RegulatedHeatTransferCoefficientsManager() 'DiGi\.Analytical\.Building\.HVAC\.Create\.RegulatedHeatTransferCoefficientsManager\(\)') class populated with predefined regulatory heat transfer coefficients\.

```csharp
public static DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficientsManager RegulatedHeatTransferCoefficientsManager();
```

#### Returns
[RegulatedHeatTransferCoefficientsManager](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficientsManager 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficientsManager')  
A configured instance of [RegulatedHeatTransferCoefficientsManager\(\)](DiGi.Analytical.Building.HVAC.md#DiGi.Analytical.Building.HVAC.Create.RegulatedHeatTransferCoefficientsManager() 'DiGi\.Analytical\.Building\.HVAC\.Create\.RegulatedHeatTransferCoefficientsManager\(\)')\.

<a name='DiGi.Analytical.Building.HVAC.Create.UsageProfile(thisDiGi.Analytical.Building.HVAC.Enums.UsageType,System.Nullable_double_,System.Nullable_double_,bool,bool)'></a>

## Create\.UsageProfile\(this UsageType, Nullable\<double\>, Nullable\<double\>, bool, bool\) Method

Creates the standard\-use profile of a building of the given usage type: heating set\-point, internal gains, outside airflow and hot water per area, each value with its source \(DiGi\-Organization/DiGi\.Analytical\#9\)\.

<b>Sources, in order of precedence.</b> A value is taken from the first source that has it: the Polish energy-certificate methodology ([UsageProfileSource\_PL376](DiGi.Analytical.Building.HVAC.md#DiGi.Analytical.Building.HVAC.Create.UsageProfileSource_PL376 'DiGi\.Analytical\.Building\.HVAC\.Create\.UsageProfileSource\_PL376'): q_int Table 26, k_R and V_Wi Table 27, outside airflow Tables 23-25), the technical conditions ([UsageProfileSource\_PLWT](DiGi.Analytical.Building.HVAC.md#DiGi.Analytical.Building.HVAC.Create.UsageProfileSource_PLWT 'DiGi\.Analytical\.Building\.HVAC\.Create\.UsageProfileSource\_PLWT'): the heating temperatures of § 134 ust. 2), ASHRAE 90.1 ([UsageProfileSource\_ASHRAE](DiGi.Analytical.Building.HVAC.md#DiGi.Analytical.Building.HVAC.Create.UsageProfileSource_ASHRAE 'DiGi\.Analytical\.Building\.HVAC\.Create\.UsageProfileSource\_ASHRAE'): occupancy densities and heat per person of Table B102, occupancy schedules of Tables B103), and only then an uncited default ([UsageProfileSource\_Default](DiGi.Analytical.Building.HVAC.md#DiGi.Analytical.Building.HVAC.Create.UsageProfileSource_Default 'DiGi\.Analytical\.Building\.HVAC\.Create\.UsageProfileSource\_Default')). Every value carries its tag in [Sources](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.UsageProfile.Sources 'DiGi\.Analytical\.Building\.HVAC\.Classes\.UsageProfile\.Sources').

<b>β, the share of the time in use</b>, which the internal gains of most non-residential types depend on (Table 26): the methodology's standard office (P1 = 0.6, β = 0.3); for every other type the ASHRAE occupancy hours per week divided by 168 - the ASHRAE office gives 48.6 / 168 = 0.29 against the methodology's 0.3, which is what this rule rests on. A given [beta](DiGi.Analytical.Building.HVAC.md#DiGi.Analytical.Building.HVAC.Create.UsageProfile(thisDiGi.Analytical.Building.HVAC.Enums.UsageType,System.Nullable_double_,System.Nullable_double_,bool,bool).beta 'DiGi\.Analytical\.Building\.HVAC\.Create\.UsageProfile\(this DiGi\.Analytical\.Building\.HVAC\.Enums\.UsageType, System\.Nullable\<double\>, System\.Nullable\<double\>, bool, bool\)\.beta') overrides it.

<b>Production</b> has no values in the methodology ("individually"): the internal gains and hot water come from ASHRAE light manufacturing (people, receptacles and service hot water of Table B102 weighted by the weekly hours of Table B103(4); lighting is excluded, the document gives no lighting power density), the ventilation is the storage row as a stand-in ([UsageProfileSource\_Default](DiGi.Analytical.Building.HVAC.md#DiGi.Analytical.Building.HVAC.Create.UsageProfileSource_Default 'DiGi\.Analytical\.Building\.HVAC\.Create\.UsageProfileSource\_Default')).

<b>Residential floor area per person</b> has no source - ASHRAE 90.1 has no residential row - and is a 30 m2 default.

With [hourly](DiGi.Analytical.Building.HVAC.md#DiGi.Analytical.Building.HVAC.Create.UsageProfile(thisDiGi.Analytical.Building.HVAC.Enums.UsageType,System.Nullable_double_,System.Nullable_double_,bool,bool).hourly 'DiGi\.Analytical\.Building\.HVAC\.Create\.UsageProfile\(this DiGi\.Analytical\.Building\.HVAC\.Enums\.UsageType, System\.Nullable\<double\>, System\.Nullable\<double\>, bool, bool\)\.hourly') a weekly 168-hour internal gain profile is added for the types whose gain depends on β: q(h) = q_off + (q_use - q_off) · f(h), with f the ASHRAE occupancy fraction scaled so that its mean is β, so the mean of the profile is exactly [InternalHeatGain](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.UsageProfile.InternalHeatGain 'DiGi\.Analytical\.Building\.HVAC\.Classes\.UsageProfile\.InternalHeatGain'). The other types stay constant.

```csharp
public static DiGi.Analytical.Building.HVAC.Classes.UsageProfile? UsageProfile(this DiGi.Analytical.Building.HVAC.Enums.UsageType usageType, System.Nullable<double> beta=null, System.Nullable<double> officeShare=null, bool meteredHotWater=false, bool hourly=false);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Create.UsageProfile(thisDiGi.Analytical.Building.HVAC.Enums.UsageType,System.Nullable_double_,System.Nullable_double_,bool,bool).usageType'></a>

`usageType` [UsageType](DiGi.Analytical.Building.HVAC.Enums.md#DiGi.Analytical.Building.HVAC.Enums.UsageType 'DiGi\.Analytical\.Building\.HVAC\.Enums\.UsageType')

The usage type\.

<a name='DiGi.Analytical.Building.HVAC.Create.UsageProfile(thisDiGi.Analytical.Building.HVAC.Enums.UsageType,System.Nullable_double_,System.Nullable_double_,bool,bool).beta'></a>

`beta` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The share of the time the building is in use, β \[\-\], overriding the default; ignored for types whose gain does not depend on it\.

<a name='DiGi.Analytical.Building.HVAC.Create.UsageProfile(thisDiGi.Analytical.Building.HVAC.Enums.UsageType,System.Nullable_double_,System.Nullable_double_,bool,bool).officeShare'></a>

`officeShare` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The share P1 of office rooms in the floor area of an office building \[\-\], overriding the standard 0\.6\.

<a name='DiGi.Analytical.Building.HVAC.Create.UsageProfile(thisDiGi.Analytical.Building.HVAC.Enums.UsageType,System.Nullable_double_,System.Nullable_double_,bool,bool).meteredHotWater'></a>

`meteredHotWater` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

True for a multi\-family building with hot water billed by individual metering \(1\.60 instead of 2\.00 dm3/\(m2 d\)\)\.

<a name='DiGi.Analytical.Building.HVAC.Create.UsageProfile(thisDiGi.Analytical.Building.HVAC.Enums.UsageType,System.Nullable_double_,System.Nullable_double_,bool,bool).hourly'></a>

`hourly` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

True to add the weekly 168\-hour internal gain profile\.

#### Returns
[UsageProfile](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.UsageProfile 'DiGi\.Analytical\.Building\.HVAC\.Classes\.UsageProfile')  
The [UsageProfile](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.UsageProfile 'DiGi\.Analytical\.Building\.HVAC\.Classes\.UsageProfile'), or null for [Undefined](DiGi.Analytical.Building.HVAC.Enums.md#DiGi.Analytical.Building.HVAC.Enums.UsageType.Undefined 'DiGi\.Analytical\.Building\.HVAC\.Enums\.UsageType\.Undefined')\.

<a name='DiGi.Analytical.Building.HVAC.Modify'></a>

## Modify Class

```csharp
public static class Modify
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Modify
### Methods

<a name='DiGi.Analytical.Building.HVAC.Modify.Assign(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace,DiGi.Analytical.Building.Interfaces.IInternalCondition,string)'></a>

## Modify\.Assign\(this BuildingModel, ISpace, IInternalCondition, string\) Method

Assigns a specified internal condition to a space within the building model\.

```csharp
public static bool Assign(this DiGi.Analytical.Building.Classes.BuildingModel? buildingModel, DiGi.Analytical.Building.Interfaces.ISpace? space, DiGi.Analytical.Building.Interfaces.IInternalCondition? internalCondition, string? id=null);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Modify.Assign(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace,DiGi.Analytical.Building.Interfaces.IInternalCondition,string).buildingModel'></a>

`buildingModel` [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')

The [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel') instance that manages the assignment\.

<a name='DiGi.Analytical.Building.HVAC.Modify.Assign(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace,DiGi.Analytical.Building.Interfaces.IInternalCondition,string).space'></a>

`space` [DiGi\.Analytical\.Building\.Interfaces\.ISpace](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.ispace 'DiGi\.Analytical\.Building\.Interfaces\.ISpace')

The [DiGi\.Analytical\.Building\.Interfaces\.ISpace](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.ispace 'DiGi\.Analytical\.Building\.Interfaces\.ISpace') to which the internal condition is assigned\.

<a name='DiGi.Analytical.Building.HVAC.Modify.Assign(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace,DiGi.Analytical.Building.Interfaces.IInternalCondition,string).internalCondition'></a>

`internalCondition` [DiGi\.Analytical\.Building\.Interfaces\.IInternalCondition](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.iinternalcondition 'DiGi\.Analytical\.Building\.Interfaces\.IInternalCondition')

The [DiGi\.Analytical\.Building\.Interfaces\.IInternalCondition](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.iinternalcondition 'DiGi\.Analytical\.Building\.Interfaces\.IInternalCondition') to be applied to the space\.

<a name='DiGi.Analytical.Building.HVAC.Modify.Assign(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace,DiGi.Analytical.Building.Interfaces.IInternalCondition,string).id'></a>

`id` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

An optional identifier shared by every relation created in one assignment \- a group tag rather than a per\-relation unique identifier\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the internal condition was successfully assigned; otherwise, false\.

<a name='DiGi.Analytical.Building.HVAC.Modify.AssignInternalCondition(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.IInternalCondition,string)'></a>

## Modify\.AssignInternalCondition\(this BuildingModel, IInternalCondition, string\) Method

Assigns an internal condition to every space of a building model, over the hours of its longest profile, as [Assign\(this BuildingModel, ISpace, IInternalCondition, string\)](DiGi.Analytical.Building.HVAC.md#DiGi.Analytical.Building.HVAC.Modify.Assign(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace,DiGi.Analytical.Building.Interfaces.IInternalCondition,string) 'DiGi\.Analytical\.Building\.HVAC\.Modify\.Assign\(this DiGi\.Analytical\.Building\.Classes\.BuildingModel, DiGi\.Analytical\.Building\.Interfaces\.ISpace, DiGi\.Analytical\.Building\.Interfaces\.IInternalCondition, string\)') does for one space \(DiGi\-Organization/DiGi\.Analytical\#9\)\.

```csharp
public static bool AssignInternalCondition(this DiGi.Analytical.Building.Classes.BuildingModel? buildingModel, DiGi.Analytical.Building.Interfaces.IInternalCondition? internalCondition, string? id=null);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Modify.AssignInternalCondition(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.IInternalCondition,string).buildingModel'></a>

`buildingModel` [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')

The building model\.

<a name='DiGi.Analytical.Building.HVAC.Modify.AssignInternalCondition(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.IInternalCondition,string).internalCondition'></a>

`internalCondition` [DiGi\.Analytical\.Building\.Interfaces\.IInternalCondition](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.iinternalcondition 'DiGi\.Analytical\.Building\.Interfaces\.IInternalCondition')

The internal condition, for example from [InternalCondition\(this UsageProfile, Nullable&lt;int&gt;, Nullable&lt;double&gt;, Nullable&lt;double&gt;, string\)](DiGi.Analytical.Building.HVAC.md#DiGi.Analytical.Building.HVAC.Create.InternalCondition(thisDiGi.Analytical.Building.HVAC.Classes.UsageProfile,System.Nullable_int_,System.Nullable_double_,System.Nullable_double_,string) 'DiGi\.Analytical\.Building\.HVAC\.Create\.InternalCondition\(this DiGi\.Analytical\.Building\.HVAC\.Classes\.UsageProfile, System\.Nullable\<int\>, System\.Nullable\<double\>, System\.Nullable\<double\>, string\)')\.

<a name='DiGi.Analytical.Building.HVAC.Modify.AssignInternalCondition(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.IInternalCondition,string).id'></a>

`id` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

An optional identifier shared by every relation created, which the HVAC IndexedDoubles query filters by\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True when the model has spaces and every one was assigned; otherwise, false\.

<a name='DiGi.Analytical.Building.HVAC.Modify.SetCoolingEmitter(thisDiGi.Analytical.Building.Classes.InternalCondition,DiGi.Analytical.Building.HVAC.Classes.CoolingEmitter)'></a>

## Modify\.SetCoolingEmitter\(this InternalCondition, CoolingEmitter\) Method

Sets the cooling emitter for the specified internal condition\.

```csharp
public static bool SetCoolingEmitter(this DiGi.Analytical.Building.Classes.InternalCondition? internalCondition, DiGi.Analytical.Building.HVAC.Classes.CoolingEmitter? coolingEmitter);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Modify.SetCoolingEmitter(thisDiGi.Analytical.Building.Classes.InternalCondition,DiGi.Analytical.Building.HVAC.Classes.CoolingEmitter).internalCondition'></a>

`internalCondition` [DiGi\.Analytical\.Building\.Classes\.InternalCondition](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.internalcondition 'DiGi\.Analytical\.Building\.Classes\.InternalCondition')

The internal condition instance to modify\.

<a name='DiGi.Analytical.Building.HVAC.Modify.SetCoolingEmitter(thisDiGi.Analytical.Building.Classes.InternalCondition,DiGi.Analytical.Building.HVAC.Classes.CoolingEmitter).coolingEmitter'></a>

`coolingEmitter` [CoolingEmitter](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.CoolingEmitter 'DiGi\.Analytical\.Building\.HVAC\.Classes\.CoolingEmitter')

The cooling emitter to assign to the internal condition\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the cooling emitter was successfully set; otherwise, false\.

<a name='DiGi.Analytical.Building.HVAC.Modify.SetHeatingEmitter(thisDiGi.Analytical.Building.Classes.InternalCondition,DiGi.Analytical.Building.HVAC.Classes.HeatingEmitter)'></a>

## Modify\.SetHeatingEmitter\(this InternalCondition, HeatingEmitter\) Method

Sets the heating emitter for the specified internal condition\.

```csharp
public static bool SetHeatingEmitter(this DiGi.Analytical.Building.Classes.InternalCondition? internalCondition, DiGi.Analytical.Building.HVAC.Classes.HeatingEmitter? heatingEmitter);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Modify.SetHeatingEmitter(thisDiGi.Analytical.Building.Classes.InternalCondition,DiGi.Analytical.Building.HVAC.Classes.HeatingEmitter).internalCondition'></a>

`internalCondition` [DiGi\.Analytical\.Building\.Classes\.InternalCondition](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.internalcondition 'DiGi\.Analytical\.Building\.Classes\.InternalCondition')

The internal condition to modify\.

<a name='DiGi.Analytical.Building.HVAC.Modify.SetHeatingEmitter(thisDiGi.Analytical.Building.Classes.InternalCondition,DiGi.Analytical.Building.HVAC.Classes.HeatingEmitter).heatingEmitter'></a>

`heatingEmitter` [HeatingEmitter](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.HeatingEmitter 'DiGi\.Analytical\.Building\.HVAC\.Classes\.HeatingEmitter')

The heating emitter to assign\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if the value was successfully set; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

<a name='DiGi.Analytical.Building.HVAC.Modify.SetInternalGain(thisDiGi.Analytical.Building.Classes.InternalCondition,DiGi.Analytical.Building.HVAC.Classes.InternalGain)'></a>

## Modify\.SetInternalGain\(this InternalCondition, InternalGain\) Method

Sets the internal gain for the specified internal condition\.

```csharp
public static bool SetInternalGain(this DiGi.Analytical.Building.Classes.InternalCondition? internalCondition, DiGi.Analytical.Building.HVAC.Classes.InternalGain? internalGain);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Modify.SetInternalGain(thisDiGi.Analytical.Building.Classes.InternalCondition,DiGi.Analytical.Building.HVAC.Classes.InternalGain).internalCondition'></a>

`internalCondition` [DiGi\.Analytical\.Building\.Classes\.InternalCondition](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.internalcondition 'DiGi\.Analytical\.Building\.Classes\.InternalCondition')

The internal condition instance to modify\.

<a name='DiGi.Analytical.Building.HVAC.Modify.SetInternalGain(thisDiGi.Analytical.Building.Classes.InternalCondition,DiGi.Analytical.Building.HVAC.Classes.InternalGain).internalGain'></a>

`internalGain` [InternalGain](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.InternalGain 'DiGi\.Analytical\.Building\.HVAC\.Classes\.InternalGain')

The internal gain value to be set\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the internal gain was successfully set; otherwise, false\.

<a name='DiGi.Analytical.Building.HVAC.Modify.SetProfile(thisDiGi.Analytical.Building.Classes.InternalCondition,DiGi.Analytical.Building.HVAC.Enums.InternalGainProfileType,DiGi.Analytical.Building.Interfaces.IProfile)'></a>

## Modify\.SetProfile\(this InternalCondition, InternalGainProfileType, IProfile\) Method

Sets a specific internal gain profile for the provided internal condition\.

```csharp
public static bool SetProfile(this DiGi.Analytical.Building.Classes.InternalCondition? internalCondition, DiGi.Analytical.Building.HVAC.Enums.InternalGainProfileType internalGainProfileType, DiGi.Analytical.Building.Interfaces.IProfile? profile);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Modify.SetProfile(thisDiGi.Analytical.Building.Classes.InternalCondition,DiGi.Analytical.Building.HVAC.Enums.InternalGainProfileType,DiGi.Analytical.Building.Interfaces.IProfile).internalCondition'></a>

`internalCondition` [DiGi\.Analytical\.Building\.Classes\.InternalCondition](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.internalcondition 'DiGi\.Analytical\.Building\.Classes\.InternalCondition')

The internal condition instance to modify\.

<a name='DiGi.Analytical.Building.HVAC.Modify.SetProfile(thisDiGi.Analytical.Building.Classes.InternalCondition,DiGi.Analytical.Building.HVAC.Enums.InternalGainProfileType,DiGi.Analytical.Building.Interfaces.IProfile).internalGainProfileType'></a>

`internalGainProfileType` [InternalGainProfileType](DiGi.Analytical.Building.HVAC.Enums.md#DiGi.Analytical.Building.HVAC.Enums.InternalGainProfileType 'DiGi\.Analytical\.Building\.HVAC\.Enums\.InternalGainProfileType')

The type of internal gain profile to be assigned\.

<a name='DiGi.Analytical.Building.HVAC.Modify.SetProfile(thisDiGi.Analytical.Building.Classes.InternalCondition,DiGi.Analytical.Building.HVAC.Enums.InternalGainProfileType,DiGi.Analytical.Building.Interfaces.IProfile).profile'></a>

`profile` [DiGi\.Analytical\.Building\.Interfaces\.IProfile](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.iprofile 'DiGi\.Analytical\.Building\.Interfaces\.IProfile')

The profile implementation to assign to the specified internal gain profile type\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the profile was successfully set; otherwise, false\.

<a name='DiGi.Analytical.Building.HVAC.Modify.SetProfile(thisDiGi.Analytical.Building.Classes.InternalCondition,DiGi.Analytical.Building.HVAC.Enums.ThermostatProfileType,DiGi.Analytical.Building.Interfaces.IProfile)'></a>

## Modify\.SetProfile\(this InternalCondition, ThermostatProfileType, IProfile\) Method

Sets the specified profile for a thermostat of the given profile type within the internal condition\.

```csharp
public static bool SetProfile(this DiGi.Analytical.Building.Classes.InternalCondition? internalCondition, DiGi.Analytical.Building.HVAC.Enums.ThermostatProfileType thermostatProfileType, DiGi.Analytical.Building.Interfaces.IProfile? profile);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Modify.SetProfile(thisDiGi.Analytical.Building.Classes.InternalCondition,DiGi.Analytical.Building.HVAC.Enums.ThermostatProfileType,DiGi.Analytical.Building.Interfaces.IProfile).internalCondition'></a>

`internalCondition` [DiGi\.Analytical\.Building\.Classes\.InternalCondition](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.internalcondition 'DiGi\.Analytical\.Building\.Classes\.InternalCondition')

The internal condition instance to modify\.

<a name='DiGi.Analytical.Building.HVAC.Modify.SetProfile(thisDiGi.Analytical.Building.Classes.InternalCondition,DiGi.Analytical.Building.HVAC.Enums.ThermostatProfileType,DiGi.Analytical.Building.Interfaces.IProfile).thermostatProfileType'></a>

`thermostatProfileType` [ThermostatProfileType](DiGi.Analytical.Building.HVAC.Enums.md#DiGi.Analytical.Building.HVAC.Enums.ThermostatProfileType 'DiGi\.Analytical\.Building\.HVAC\.Enums\.ThermostatProfileType')

The type of thermostat profile to set\.

<a name='DiGi.Analytical.Building.HVAC.Modify.SetProfile(thisDiGi.Analytical.Building.Classes.InternalCondition,DiGi.Analytical.Building.HVAC.Enums.ThermostatProfileType,DiGi.Analytical.Building.Interfaces.IProfile).profile'></a>

`profile` [DiGi\.Analytical\.Building\.Interfaces\.IProfile](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.iprofile 'DiGi\.Analytical\.Building\.Interfaces\.IProfile')

The profile to assign to the specified thermostat profile type\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the profile was successfully set or updated; otherwise, false\.

<a name='DiGi.Analytical.Building.HVAC.Modify.SetSystemProperties(thisDiGi.Analytical.Building.Classes.InternalCondition,DiGi.Analytical.Building.HVAC.Classes.SystemProperties)'></a>

## Modify\.SetSystemProperties\(this InternalCondition, SystemProperties\) Method

Sets the system properties for the specified internal condition\.

```csharp
public static bool SetSystemProperties(this DiGi.Analytical.Building.Classes.InternalCondition? internalCondition, DiGi.Analytical.Building.HVAC.Classes.SystemProperties? systemProperties);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Modify.SetSystemProperties(thisDiGi.Analytical.Building.Classes.InternalCondition,DiGi.Analytical.Building.HVAC.Classes.SystemProperties).internalCondition'></a>

`internalCondition` [DiGi\.Analytical\.Building\.Classes\.InternalCondition](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.internalcondition 'DiGi\.Analytical\.Building\.Classes\.InternalCondition')

The internal condition instance to modify\.

<a name='DiGi.Analytical.Building.HVAC.Modify.SetSystemProperties(thisDiGi.Analytical.Building.Classes.InternalCondition,DiGi.Analytical.Building.HVAC.Classes.SystemProperties).systemProperties'></a>

`systemProperties` [SystemProperties](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.SystemProperties 'DiGi\.Analytical\.Building\.HVAC\.Classes\.SystemProperties')

The system properties to be assigned\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if the system properties were successfully set; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

<a name='DiGi.Analytical.Building.HVAC.Modify.SetThermostat(thisDiGi.Analytical.Building.Classes.InternalCondition,DiGi.Analytical.Building.HVAC.Classes.Thermostat)'></a>

## Modify\.SetThermostat\(this InternalCondition, Thermostat\) Method

Sets the thermostat parameter for the specified internal condition\.

```csharp
public static bool SetThermostat(this DiGi.Analytical.Building.Classes.InternalCondition? internalCondition, DiGi.Analytical.Building.HVAC.Classes.Thermostat? thermostat);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Modify.SetThermostat(thisDiGi.Analytical.Building.Classes.InternalCondition,DiGi.Analytical.Building.HVAC.Classes.Thermostat).internalCondition'></a>

`internalCondition` [DiGi\.Analytical\.Building\.Classes\.InternalCondition](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.internalcondition 'DiGi\.Analytical\.Building\.Classes\.InternalCondition')

The internal condition instance to be modified\.

<a name='DiGi.Analytical.Building.HVAC.Modify.SetThermostat(thisDiGi.Analytical.Building.Classes.InternalCondition,DiGi.Analytical.Building.HVAC.Classes.Thermostat).thermostat'></a>

`thermostat` [Thermostat](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.Thermostat 'DiGi\.Analytical\.Building\.HVAC\.Classes\.Thermostat')

The thermostat object to assign to the internal condition\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the thermostat was successfully set; otherwise, false\.

<a name='DiGi.Analytical.Building.HVAC.Query'></a>

## Query Class

```csharp
public static class Query
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Query
### Methods

<a name='DiGi.Analytical.Building.HVAC.Query.CoolingEmitter(thisDiGi.Analytical.Building.Interfaces.IInternalCondition)'></a>

## Query\.CoolingEmitter\(this IInternalCondition\) Method

Retrieves the cooling emitter associated with the specified internal condition\.

```csharp
public static DiGi.Analytical.Building.HVAC.Classes.CoolingEmitter? CoolingEmitter(this DiGi.Analytical.Building.Interfaces.IInternalCondition? internalCondition);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Query.CoolingEmitter(thisDiGi.Analytical.Building.Interfaces.IInternalCondition).internalCondition'></a>

`internalCondition` [DiGi\.Analytical\.Building\.Interfaces\.IInternalCondition](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.iinternalcondition 'DiGi\.Analytical\.Building\.Interfaces\.IInternalCondition')

The internal condition from which to retrieve the cooling emitter\.

#### Returns
[CoolingEmitter](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.CoolingEmitter 'DiGi\.Analytical\.Building\.HVAC\.Classes\.CoolingEmitter')  
The [CoolingEmitter\(this IInternalCondition\)](DiGi.Analytical.Building.HVAC.md#DiGi.Analytical.Building.HVAC.Query.CoolingEmitter(thisDiGi.Analytical.Building.Interfaces.IInternalCondition) 'DiGi\.Analytical\.Building\.HVAC\.Query\.CoolingEmitter\(this DiGi\.Analytical\.Building\.Interfaces\.IInternalCondition\)') if found; otherwise, `null`\.

<a name='DiGi.Analytical.Building.HVAC.Query.HeatingEmitter(thisDiGi.Analytical.Building.Interfaces.IInternalCondition)'></a>

## Query\.HeatingEmitter\(this IInternalCondition\) Method

Retrieves the heating emitter associated with the specified internal condition\.

```csharp
public static DiGi.Analytical.Building.HVAC.Classes.HeatingEmitter? HeatingEmitter(this DiGi.Analytical.Building.Interfaces.IInternalCondition? internalCondition);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Query.HeatingEmitter(thisDiGi.Analytical.Building.Interfaces.IInternalCondition).internalCondition'></a>

`internalCondition` [DiGi\.Analytical\.Building\.Interfaces\.IInternalCondition](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.iinternalcondition 'DiGi\.Analytical\.Building\.Interfaces\.IInternalCondition')

The internal condition from which to retrieve the heating emitter\.

#### Returns
[HeatingEmitter](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.HeatingEmitter 'DiGi\.Analytical\.Building\.HVAC\.Classes\.HeatingEmitter')  
The [HeatingEmitter\(this IInternalCondition\)](DiGi.Analytical.Building.HVAC.md#DiGi.Analytical.Building.HVAC.Query.HeatingEmitter(thisDiGi.Analytical.Building.Interfaces.IInternalCondition) 'DiGi\.Analytical\.Building\.HVAC\.Query\.HeatingEmitter\(this DiGi\.Analytical\.Building\.Interfaces\.IInternalCondition\)') if found; otherwise, `null`\.

<a name='DiGi.Analytical.Building.HVAC.Query.IndexedDoubles(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace,DiGi.Core.Classes.Range_int_,DiGi.Analytical.Building.HVAC.Enums.InternalGainProfileType,string)'></a>

## Query\.IndexedDoubles\(this BuildingModel, ISpace, Range\<int\>, InternalGainProfileType, string\) Method

Retrieves a collection of double\-precision floating\-point values for the specified internal gain profile within a given space and index range\.

```csharp
public static DiGi.Core.Classes.IndexedDoubles? IndexedDoubles(this DiGi.Analytical.Building.Classes.BuildingModel? buildingModel, DiGi.Analytical.Building.Interfaces.ISpace? space, DiGi.Core.Classes.Range<int>? range, DiGi.Analytical.Building.HVAC.Enums.InternalGainProfileType internalGainProfileType, string? id=null);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Query.IndexedDoubles(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace,DiGi.Core.Classes.Range_int_,DiGi.Analytical.Building.HVAC.Enums.InternalGainProfileType,string).buildingModel'></a>

`buildingModel` [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')

The building model to query\.

<a name='DiGi.Analytical.Building.HVAC.Query.IndexedDoubles(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace,DiGi.Core.Classes.Range_int_,DiGi.Analytical.Building.HVAC.Enums.InternalGainProfileType,string).space'></a>

`space` [DiGi\.Analytical\.Building\.Interfaces\.ISpace](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.ispace 'DiGi\.Analytical\.Building\.Interfaces\.ISpace')

The space from which to retrieve the data\.

<a name='DiGi.Analytical.Building.HVAC.Query.IndexedDoubles(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace,DiGi.Core.Classes.Range_int_,DiGi.Analytical.Building.HVAC.Enums.InternalGainProfileType,string).range'></a>

`range` [DiGi\.Core\.Classes\.Range&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')

The range of indices for the values to be retrieved\.

<a name='DiGi.Analytical.Building.HVAC.Query.IndexedDoubles(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace,DiGi.Core.Classes.Range_int_,DiGi.Analytical.Building.HVAC.Enums.InternalGainProfileType,string).internalGainProfileType'></a>

`internalGainProfileType` [InternalGainProfileType](DiGi.Analytical.Building.HVAC.Enums.md#DiGi.Analytical.Building.HVAC.Enums.InternalGainProfileType 'DiGi\.Analytical\.Building\.HVAC\.Enums\.InternalGainProfileType')

The type of internal gain profile to query\.

<a name='DiGi.Analytical.Building.HVAC.Query.IndexedDoubles(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace,DiGi.Core.Classes.Range_int_,DiGi.Analytical.Building.HVAC.Enums.InternalGainProfileType,string).id'></a>

`id` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

An optional identifier used to filter or specify the data source\.

#### Returns
[DiGi\.Core\.Classes\.IndexedDoubles](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.indexeddoubles 'DiGi\.Core\.Classes\.IndexedDoubles')  
An [DiGi\.Core\.Classes\.IndexedDoubles](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.indexeddoubles 'DiGi\.Core\.Classes\.IndexedDoubles') instance containing the retrieved values, or `null` if any required parameters are null or invalid\.

<a name='DiGi.Analytical.Building.HVAC.Query.IndexedDoubles(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace,DiGi.Core.Classes.Range_int_,DiGi.Analytical.Building.HVAC.Enums.ThermostatProfileType,string)'></a>

## Query\.IndexedDoubles\(this BuildingModel, ISpace, Range\<int\>, ThermostatProfileType, string\) Method

Retrieves a collection of double\-precision floating\-point values mapped to integer indices for a specified thermostat profile within a building space\.

```csharp
public static DiGi.Core.Classes.IndexedDoubles? IndexedDoubles(this DiGi.Analytical.Building.Classes.BuildingModel? buildingModel, DiGi.Analytical.Building.Interfaces.ISpace? space, DiGi.Core.Classes.Range<int>? range, DiGi.Analytical.Building.HVAC.Enums.ThermostatProfileType thermostatProfileType, string? id=null);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Query.IndexedDoubles(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace,DiGi.Core.Classes.Range_int_,DiGi.Analytical.Building.HVAC.Enums.ThermostatProfileType,string).buildingModel'></a>

`buildingModel` [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')

The building model containing the data\.

<a name='DiGi.Analytical.Building.HVAC.Query.IndexedDoubles(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace,DiGi.Core.Classes.Range_int_,DiGi.Analytical.Building.HVAC.Enums.ThermostatProfileType,string).space'></a>

`space` [DiGi\.Analytical\.Building\.Interfaces\.ISpace](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.ispace 'DiGi\.Analytical\.Building\.Interfaces\.ISpace')

The space associated with the thermostat profile\.

<a name='DiGi.Analytical.Building.HVAC.Query.IndexedDoubles(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace,DiGi.Core.Classes.Range_int_,DiGi.Analytical.Building.HVAC.Enums.ThermostatProfileType,string).range'></a>

`range` [DiGi\.Core\.Classes\.Range&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')

The range of indices to retrieve\.

<a name='DiGi.Analytical.Building.HVAC.Query.IndexedDoubles(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace,DiGi.Core.Classes.Range_int_,DiGi.Analytical.Building.HVAC.Enums.ThermostatProfileType,string).thermostatProfileType'></a>

`thermostatProfileType` [ThermostatProfileType](DiGi.Analytical.Building.HVAC.Enums.md#DiGi.Analytical.Building.HVAC.Enums.ThermostatProfileType 'DiGi\.Analytical\.Building\.HVAC\.Enums\.ThermostatProfileType')

The type of thermostat profile to query\.

<a name='DiGi.Analytical.Building.HVAC.Query.IndexedDoubles(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace,DiGi.Core.Classes.Range_int_,DiGi.Analytical.Building.HVAC.Enums.ThermostatProfileType,string).id'></a>

`id` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

An optional identifier for the specific profile or data source\.

#### Returns
[DiGi\.Core\.Classes\.IndexedDoubles](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.indexeddoubles 'DiGi\.Core\.Classes\.IndexedDoubles')  
An [DiGi\.Core\.Classes\.IndexedDoubles](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.indexeddoubles 'DiGi\.Core\.Classes\.IndexedDoubles') instance containing the retrieved values, or `null` if the building model, space, range, or profile type is invalid or undefined\.

<a name='DiGi.Analytical.Building.HVAC.Query.IndexedDoubles(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace,DiGi.Core.Classes.Range_int_,System.Enum,string)'></a>

## Query\.IndexedDoubles\(this BuildingModel, ISpace, Range\<int\>, Enum, string\) Method

Retrieves a collection of indexed double\-precision floating\-point values for a specific space and profile type within the building model\.

```csharp
public static DiGi.Core.Classes.IndexedDoubles? IndexedDoubles(this DiGi.Analytical.Building.Classes.BuildingModel? buildingModel, DiGi.Analytical.Building.Interfaces.ISpace? space, DiGi.Core.Classes.Range<int>? range, System.Enum? @enum, string? id=null);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Query.IndexedDoubles(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace,DiGi.Core.Classes.Range_int_,System.Enum,string).buildingModel'></a>

`buildingModel` [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')

The [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel') instance to query\.

<a name='DiGi.Analytical.Building.HVAC.Query.IndexedDoubles(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace,DiGi.Core.Classes.Range_int_,System.Enum,string).space'></a>

`space` [DiGi\.Analytical\.Building\.Interfaces\.ISpace](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.ispace 'DiGi\.Analytical\.Building\.Interfaces\.ISpace')

The [DiGi\.Analytical\.Building\.Interfaces\.ISpace](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.ispace 'DiGi\.Analytical\.Building\.Interfaces\.ISpace') associated with the data retrieval\.

<a name='DiGi.Analytical.Building.HVAC.Query.IndexedDoubles(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace,DiGi.Core.Classes.Range_int_,System.Enum,string).range'></a>

`range` [DiGi\.Core\.Classes\.Range&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1')

The [DiGi\.Core\.Classes\.Range&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.range-1 'DiGi\.Core\.Classes\.Range\`1') of integers defining the index range\.

<a name='DiGi.Analytical.Building.HVAC.Query.IndexedDoubles(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace,DiGi.Core.Classes.Range_int_,System.Enum,string).enum'></a>

`enum` [System\.Enum](https://learn.microsoft.com/en-us/dotnet/api/system.enum 'System\.Enum')

The enumeration value specifying the profile type, such as [ThermostatProfileType](DiGi.Analytical.Building.HVAC.Enums.md#DiGi.Analytical.Building.HVAC.Enums.ThermostatProfileType 'DiGi\.Analytical\.Building\.HVAC\.Enums\.ThermostatProfileType') or [InternalGainProfileType](DiGi.Analytical.Building.HVAC.Enums.md#DiGi.Analytical.Building.HVAC.Enums.InternalGainProfileType 'DiGi\.Analytical\.Building\.HVAC\.Enums\.InternalGainProfileType')\.

<a name='DiGi.Analytical.Building.HVAC.Query.IndexedDoubles(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace,DiGi.Core.Classes.Range_int_,System.Enum,string).id'></a>

`id` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

An optional identifier shared by the internal condition relations created in one assignment \- a group tag rather than a per\-relation unique identifier\. The query keeps the matching relations\.

#### Returns
[DiGi\.Core\.Classes\.IndexedDoubles](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.indexeddoubles 'DiGi\.Core\.Classes\.IndexedDoubles')  
An [DiGi\.Core\.Classes\.IndexedDoubles](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.indexeddoubles 'DiGi\.Core\.Classes\.IndexedDoubles') instance if matching data is found; otherwise, `null`\.

<a name='DiGi.Analytical.Building.HVAC.Query.IndexedDoubles(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace,int,int,DiGi.Analytical.Building.HVAC.Enums.InternalGainProfileType,string)'></a>

## Query\.IndexedDoubles\(this BuildingModel, ISpace, int, int, InternalGainProfileType, string\) Method

Retrieves a collection of double\-precision floating\-point values mapped to integer indices for a specific internal gain profile within a specified range\.

```csharp
public static DiGi.Core.Classes.IndexedDoubles? IndexedDoubles(this DiGi.Analytical.Building.Classes.BuildingModel? buildingModel, DiGi.Analytical.Building.Interfaces.ISpace? space, int start, int end, DiGi.Analytical.Building.HVAC.Enums.InternalGainProfileType internalGainProfileType, string? id=null);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Query.IndexedDoubles(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace,int,int,DiGi.Analytical.Building.HVAC.Enums.InternalGainProfileType,string).buildingModel'></a>

`buildingModel` [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')

The building model containing the data\.

<a name='DiGi.Analytical.Building.HVAC.Query.IndexedDoubles(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace,int,int,DiGi.Analytical.Building.HVAC.Enums.InternalGainProfileType,string).space'></a>

`space` [DiGi\.Analytical\.Building\.Interfaces\.ISpace](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.ispace 'DiGi\.Analytical\.Building\.Interfaces\.ISpace')

The space associated with the internal gain profile\.

<a name='DiGi.Analytical.Building.HVAC.Query.IndexedDoubles(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace,int,int,DiGi.Analytical.Building.HVAC.Enums.InternalGainProfileType,string).start'></a>

`start` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index of the value range to retrieve\.

<a name='DiGi.Analytical.Building.HVAC.Query.IndexedDoubles(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace,int,int,DiGi.Analytical.Building.HVAC.Enums.InternalGainProfileType,string).end'></a>

`end` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index of the value range to retrieve\.

<a name='DiGi.Analytical.Building.HVAC.Query.IndexedDoubles(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace,int,int,DiGi.Analytical.Building.HVAC.Enums.InternalGainProfileType,string).internalGainProfileType'></a>

`internalGainProfileType` [InternalGainProfileType](DiGi.Analytical.Building.HVAC.Enums.md#DiGi.Analytical.Building.HVAC.Enums.InternalGainProfileType 'DiGi\.Analytical\.Building\.HVAC\.Enums\.InternalGainProfileType')

The type of internal gain profile to be retrieved\.

<a name='DiGi.Analytical.Building.HVAC.Query.IndexedDoubles(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace,int,int,DiGi.Analytical.Building.HVAC.Enums.InternalGainProfileType,string).id'></a>

`id` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

An optional identifier for the specific internal gain profile\.

#### Returns
[DiGi\.Core\.Classes\.IndexedDoubles](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.indexeddoubles 'DiGi\.Core\.Classes\.IndexedDoubles')  
An [DiGi\.Core\.Classes\.IndexedDoubles](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.indexeddoubles 'DiGi\.Core\.Classes\.IndexedDoubles') instance containing the values if successful; otherwise, `null`\.

<a name='DiGi.Analytical.Building.HVAC.Query.IndexedDoubles(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace,int,int,DiGi.Analytical.Building.HVAC.Enums.ThermostatProfileType,string)'></a>

## Query\.IndexedDoubles\(this BuildingModel, ISpace, int, int, ThermostatProfileType, string\) Method

Retrieves a collection of double\-precision floating\-point values mapped to integer indices for a specified thermostat profile within a given space and range\.

```csharp
public static DiGi.Core.Classes.IndexedDoubles? IndexedDoubles(this DiGi.Analytical.Building.Classes.BuildingModel? buildingModel, DiGi.Analytical.Building.Interfaces.ISpace? space, int start, int end, DiGi.Analytical.Building.HVAC.Enums.ThermostatProfileType thermostatProfileType, string? id=null);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Query.IndexedDoubles(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace,int,int,DiGi.Analytical.Building.HVAC.Enums.ThermostatProfileType,string).buildingModel'></a>

`buildingModel` [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')

The building model containing the data\.

<a name='DiGi.Analytical.Building.HVAC.Query.IndexedDoubles(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace,int,int,DiGi.Analytical.Building.HVAC.Enums.ThermostatProfileType,string).space'></a>

`space` [DiGi\.Analytical\.Building\.Interfaces\.ISpace](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.ispace 'DiGi\.Analytical\.Building\.Interfaces\.ISpace')

The space associated with the thermostat profile\.

<a name='DiGi.Analytical.Building.HVAC.Query.IndexedDoubles(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace,int,int,DiGi.Analytical.Building.HVAC.Enums.ThermostatProfileType,string).start'></a>

`start` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The starting index of the requested range\.

<a name='DiGi.Analytical.Building.HVAC.Query.IndexedDoubles(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace,int,int,DiGi.Analytical.Building.HVAC.Enums.ThermostatProfileType,string).end'></a>

`end` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The ending index of the requested range\.

<a name='DiGi.Analytical.Building.HVAC.Query.IndexedDoubles(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace,int,int,DiGi.Analytical.Building.HVAC.Enums.ThermostatProfileType,string).thermostatProfileType'></a>

`thermostatProfileType` [ThermostatProfileType](DiGi.Analytical.Building.HVAC.Enums.md#DiGi.Analytical.Building.HVAC.Enums.ThermostatProfileType 'DiGi\.Analytical\.Building\.HVAC\.Enums\.ThermostatProfileType')

The type of thermostat profile to be retrieved\.

<a name='DiGi.Analytical.Building.HVAC.Query.IndexedDoubles(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace,int,int,DiGi.Analytical.Building.HVAC.Enums.ThermostatProfileType,string).id'></a>

`id` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

An optional identifier for the specific profile instance\.

#### Returns
[DiGi\.Core\.Classes\.IndexedDoubles](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.indexeddoubles 'DiGi\.Core\.Classes\.IndexedDoubles')  
An [DiGi\.Core\.Classes\.IndexedDoubles](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.indexeddoubles 'DiGi\.Core\.Classes\.IndexedDoubles') instance containing the values if successful; otherwise, `null`\.

<a name='DiGi.Analytical.Building.HVAC.Query.InternalGain(thisDiGi.Analytical.Building.Interfaces.IInternalCondition)'></a>

## Query\.InternalGain\(this IInternalCondition\) Method

Retrieves the internal gain from the specified internal condition\.

```csharp
public static DiGi.Analytical.Building.HVAC.Classes.InternalGain? InternalGain(this DiGi.Analytical.Building.Interfaces.IInternalCondition? internalCondition);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Query.InternalGain(thisDiGi.Analytical.Building.Interfaces.IInternalCondition).internalCondition'></a>

`internalCondition` [DiGi\.Analytical\.Building\.Interfaces\.IInternalCondition](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.iinternalcondition 'DiGi\.Analytical\.Building\.Interfaces\.IInternalCondition')

The internal condition to retrieve the internal gain from\.

#### Returns
[InternalGain](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.InternalGain 'DiGi\.Analytical\.Building\.HVAC\.Classes\.InternalGain')  
The [InternalGain\(this IInternalCondition\)](DiGi.Analytical.Building.HVAC.md#DiGi.Analytical.Building.HVAC.Query.InternalGain(thisDiGi.Analytical.Building.Interfaces.IInternalCondition) 'DiGi\.Analytical\.Building\.HVAC\.Query\.InternalGain\(this DiGi\.Analytical\.Building\.Interfaces\.IInternalCondition\)') if successfully retrieved; otherwise, [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

<a name='DiGi.Analytical.Building.HVAC.Query.Profile(thisDiGi.Analytical.Building.Interfaces.IInternalCondition,DiGi.Analytical.Building.HVAC.Enums.InternalGainProfileType)'></a>

## Query\.Profile\(this IInternalCondition, InternalGainProfileType\) Method

Retrieves the internal gain profile for the specified profile type from the given internal condition\.

```csharp
public static DiGi.Analytical.Building.Interfaces.IProfile? Profile(this DiGi.Analytical.Building.Interfaces.IInternalCondition? internalCondition, DiGi.Analytical.Building.HVAC.Enums.InternalGainProfileType internalGainProfileType);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Query.Profile(thisDiGi.Analytical.Building.Interfaces.IInternalCondition,DiGi.Analytical.Building.HVAC.Enums.InternalGainProfileType).internalCondition'></a>

`internalCondition` [DiGi\.Analytical\.Building\.Interfaces\.IInternalCondition](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.iinternalcondition 'DiGi\.Analytical\.Building\.Interfaces\.IInternalCondition')

The internal condition instance to query\.

<a name='DiGi.Analytical.Building.HVAC.Query.Profile(thisDiGi.Analytical.Building.Interfaces.IInternalCondition,DiGi.Analytical.Building.HVAC.Enums.InternalGainProfileType).internalGainProfileType'></a>

`internalGainProfileType` [InternalGainProfileType](DiGi.Analytical.Building.HVAC.Enums.md#DiGi.Analytical.Building.HVAC.Enums.InternalGainProfileType 'DiGi\.Analytical\.Building\.HVAC\.Enums\.InternalGainProfileType')

The specific internal gain profile type to retrieve\.

#### Returns
[DiGi\.Analytical\.Building\.Interfaces\.IProfile](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.iprofile 'DiGi\.Analytical\.Building\.Interfaces\.IProfile')  
The matching [DiGi\.Analytical\.Building\.Interfaces\.IProfile](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.iprofile 'DiGi\.Analytical\.Building\.Interfaces\.IProfile') if found; otherwise, `null`\.

<a name='DiGi.Analytical.Building.HVAC.Query.Profile(thisDiGi.Analytical.Building.Interfaces.IInternalCondition,DiGi.Analytical.Building.HVAC.Enums.ThermostatProfileType)'></a>

## Query\.Profile\(this IInternalCondition, ThermostatProfileType\) Method

Retrieves the specified thermostat profile for the given internal condition\.

```csharp
public static DiGi.Analytical.Building.Interfaces.IProfile? Profile(this DiGi.Analytical.Building.Interfaces.IInternalCondition? internalCondition, DiGi.Analytical.Building.HVAC.Enums.ThermostatProfileType thermostatProfileType);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Query.Profile(thisDiGi.Analytical.Building.Interfaces.IInternalCondition,DiGi.Analytical.Building.HVAC.Enums.ThermostatProfileType).internalCondition'></a>

`internalCondition` [DiGi\.Analytical\.Building\.Interfaces\.IInternalCondition](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.iinternalcondition 'DiGi\.Analytical\.Building\.Interfaces\.IInternalCondition')

The internal condition instance to query\.

<a name='DiGi.Analytical.Building.HVAC.Query.Profile(thisDiGi.Analytical.Building.Interfaces.IInternalCondition,DiGi.Analytical.Building.HVAC.Enums.ThermostatProfileType).thermostatProfileType'></a>

`thermostatProfileType` [ThermostatProfileType](DiGi.Analytical.Building.HVAC.Enums.md#DiGi.Analytical.Building.HVAC.Enums.ThermostatProfileType 'DiGi\.Analytical\.Building\.HVAC\.Enums\.ThermostatProfileType')

The specific type of thermostat profile to retrieve\.

#### Returns
[DiGi\.Analytical\.Building\.Interfaces\.IProfile](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.iprofile 'DiGi\.Analytical\.Building\.Interfaces\.IProfile')  
The matching [DiGi\.Analytical\.Building\.Interfaces\.IProfile](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.iprofile 'DiGi\.Analytical\.Building\.Interfaces\.IProfile') if found; otherwise, [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

<a name='DiGi.Analytical.Building.HVAC.Query.Profiles(thisDiGi.Analytical.Building.Interfaces.IInternalCondition)'></a>

## Query\.Profiles\(this IInternalCondition\) Method

Retrieves a list of all profiles associated with the specified internal condition\.

```csharp
public static System.Collections.Generic.List<DiGi.Analytical.Building.Interfaces.IProfile>? Profiles(this DiGi.Analytical.Building.Interfaces.IInternalCondition? internalCondition);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Query.Profiles(thisDiGi.Analytical.Building.Interfaces.IInternalCondition).internalCondition'></a>

`internalCondition` [DiGi\.Analytical\.Building\.Interfaces\.IInternalCondition](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.iinternalcondition 'DiGi\.Analytical\.Building\.Interfaces\.IInternalCondition')

The internal condition to retrieve profiles from\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[DiGi\.Analytical\.Building\.Interfaces\.IProfile](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.iprofile 'DiGi\.Analytical\.Building\.Interfaces\.IProfile')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of [DiGi\.Analytical\.Building\.Interfaces\.IProfile](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.iprofile 'DiGi\.Analytical\.Building\.Interfaces\.IProfile') instances if the internal condition is not null; otherwise, null\.

<a name='DiGi.Analytical.Building.HVAC.Query.SystemProperties(thisDiGi.Analytical.Building.Interfaces.IInternalCondition)'></a>

## Query\.SystemProperties\(this IInternalCondition\) Method

Retrieves the system properties associated with the specified internal condition\.

```csharp
public static DiGi.Analytical.Building.HVAC.Classes.SystemProperties? SystemProperties(this DiGi.Analytical.Building.Interfaces.IInternalCondition? internalCondition);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Query.SystemProperties(thisDiGi.Analytical.Building.Interfaces.IInternalCondition).internalCondition'></a>

`internalCondition` [DiGi\.Analytical\.Building\.Interfaces\.IInternalCondition](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.iinternalcondition 'DiGi\.Analytical\.Building\.Interfaces\.IInternalCondition')

The internal condition instance to query for system properties\.

#### Returns
[SystemProperties](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.SystemProperties 'DiGi\.Analytical\.Building\.HVAC\.Classes\.SystemProperties')  
The [SystemProperties\(this IInternalCondition\)](DiGi.Analytical.Building.HVAC.md#DiGi.Analytical.Building.HVAC.Query.SystemProperties(thisDiGi.Analytical.Building.Interfaces.IInternalCondition) 'DiGi\.Analytical\.Building\.HVAC\.Query\.SystemProperties\(this DiGi\.Analytical\.Building\.Interfaces\.IInternalCondition\)') if found; otherwise, `null`\.

<a name='DiGi.Analytical.Building.HVAC.Query.Thermostat(thisDiGi.Analytical.Building.Interfaces.IInternalCondition)'></a>

## Query\.Thermostat\(this IInternalCondition\) Method

Retrieves the thermostat associated with the specified internal condition\.

```csharp
public static DiGi.Analytical.Building.HVAC.Classes.Thermostat? Thermostat(this DiGi.Analytical.Building.Interfaces.IInternalCondition? internalCondition);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Query.Thermostat(thisDiGi.Analytical.Building.Interfaces.IInternalCondition).internalCondition'></a>

`internalCondition` [DiGi\.Analytical\.Building\.Interfaces\.IInternalCondition](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.iinternalcondition 'DiGi\.Analytical\.Building\.Interfaces\.IInternalCondition')

The internal condition to query for the thermostat parameter\.

#### Returns
[Thermostat](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.Thermostat 'DiGi\.Analytical\.Building\.HVAC\.Classes\.Thermostat')  
The [Thermostat\(this IInternalCondition\)](DiGi.Analytical.Building.HVAC.md#DiGi.Analytical.Building.HVAC.Query.Thermostat(thisDiGi.Analytical.Building.Interfaces.IInternalCondition) 'DiGi\.Analytical\.Building\.HVAC\.Query\.Thermostat\(this DiGi\.Analytical\.Building\.Interfaces\.IInternalCondition\)') instance if it exists; otherwise, `null`\.