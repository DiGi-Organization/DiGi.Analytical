#### [DiGi\.Analytical\.Building\.Energy](DiGi.Analytical.Building.Energy.Overview.md 'DiGi\.Analytical\.Building\.Energy\.Overview')

## DiGi\.Analytical\.Building\.Energy\.Classes Namespace
### Classes

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions'></a>

## HeatDemandOptions Class

Holds every numeric default of the monthly heat demand, so nothing is hard\-coded in `Create.HeatDemandResult` \(DiGi\-Organization/DiGi\.Analytical\#21\)\.

The defaults are [Default](DiGi.Analytical.Building.Energy.Constants.md#DiGi.Analytical.Building.Energy.Constants.Default 'DiGi\.Analytical\.Building\.Energy\.Constants\.Default'), each with its source. The fallbacks (F_w, ΔU_tb, F_f) apply only where the building's TABULA typology data gives no value.

```csharp
public class HeatDemandOptions : DiGi.Core.Classes.SerializableOptions, DiGi.Analytical.Building.Energy.Interfaces.IEnergySerializableObject, DiGi.Analytical.Building.Energy.Interfaces.IEnergyObject, DiGi.Analytical.Building.Interfaces.IBuildingObject, DiGi.Analytical.Interfaces.IAnalyticalObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Classes\.SerializableOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableoptions 'DiGi\.Core\.Classes\.SerializableOptions') → HeatDemandOptions

Implements [IEnergySerializableObject](DiGi.Analytical.Building.Energy.Interfaces.md#DiGi.Analytical.Building.Energy.Interfaces.IEnergySerializableObject 'DiGi\.Analytical\.Building\.Energy\.Interfaces\.IEnergySerializableObject'), [IEnergyObject](DiGi.Analytical.Building.Energy.Interfaces.md#DiGi.Analytical.Building.Energy.Interfaces.IEnergyObject 'DiGi\.Analytical\.Building\.Energy\.Interfaces\.IEnergyObject'), [DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.ibuildingobject 'DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject'), [DiGi\.Analytical\.Interfaces\.IAnalyticalObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.interfaces.ianalyticalobject 'DiGi\.Analytical\.Interfaces\.IAnalyticalObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions.HeatDemandOptions()'></a>

## HeatDemandOptions\(\) Constructor

Initializes a new instance of the [HeatDemandOptions](DiGi.Analytical.Building.Energy.Classes.md#DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions 'DiGi\.Analytical\.Building\.Energy\.Classes\.HeatDemandOptions') class with the defaults of [Default](DiGi.Analytical.Building.Energy.Constants.md#DiGi.Analytical.Building.Energy.Constants.Default 'DiGi\.Analytical\.Building\.Energy\.Constants\.Default')\.

```csharp
public HeatDemandOptions();
```

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions.HeatDemandOptions(DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions)'></a>

## HeatDemandOptions\(HeatDemandOptions\) Constructor

Initializes a new instance of the [HeatDemandOptions](DiGi.Analytical.Building.Energy.Classes.md#DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions 'DiGi\.Analytical\.Building\.Energy\.Classes\.HeatDemandOptions') class by copying another instance\.

```csharp
public HeatDemandOptions(DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions? heatDemandOptions);
```
#### Parameters

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions.HeatDemandOptions(DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions).heatDemandOptions'></a>

`heatDemandOptions` [HeatDemandOptions](DiGi.Analytical.Building.Energy.Classes.md#DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions 'DiGi\.Analytical\.Building\.Energy\.Classes\.HeatDemandOptions')

The options to copy\. This value can be null\.

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions.HeatDemandOptions(System.Text.Json.Nodes.JsonObject)'></a>

## HeatDemandOptions\(JsonObject\) Constructor

Initializes a new instance of the [HeatDemandOptions](DiGi.Analytical.Building.Energy.Classes.md#DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions 'DiGi\.Analytical\.Building\.Energy\.Classes\.HeatDemandOptions') class from a JSON object\.

```csharp
public HeatDemandOptions(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions.HeatDemandOptions(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the options\. This value can be null\.
### Properties

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions.ExternalEmissivity'></a>

## HeatDemandOptions\.ExternalEmissivity Property

Gets or sets the emissivity ε of the external surfaces for thermal radiation; the external radiative heat transfer coefficient is h\_r = 5·ε \[W/\(m2K\)\]\.

```csharp
public double ExternalEmissivity { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions.FrameAreaFraction'></a>

## HeatDemandOptions\.FrameAreaFraction Property

Gets or sets the fallback frame area fraction F\_f \[\-\] of an opening whose construction has no panes, used when the typology data gives none\.

```csharp
public double FrameAreaFraction { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions.GroundThermalConductivity'></a>

## HeatDemandOptions\.GroundThermalConductivity Property

Gets or sets the thermal conductivity of the ground λ\_g \[W/\(mK\)\]\.

```csharp
public double GroundThermalConductivity { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions.GroundWallThickness'></a>

## HeatDemandOptions\.GroundWallThickness Property

Gets or sets the thickness of the external walls w \[m\] used in the equivalent thickness of a ground floor when no external wall has layers\.

```csharp
public double GroundWallThickness { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions.IncludeOpaqueSolarGains'></a>

## HeatDemandOptions\.IncludeOpaqueSolarGains Property

Gets or sets a value indicating whether the solar gains of opaque elements, α·R\_se·U·A·I, are included\.

```csharp
public bool IncludeOpaqueSolarGains { get; set; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions.IncludeSkyRadiation'></a>

## HeatDemandOptions\.IncludeSkyRadiation Property

Gets or sets a value indicating whether the extra heat flow by thermal radiation to the sky is subtracted from the solar gains\. The source allows a national choice to ignore it\.

```csharp
public bool IncludeSkyRadiation { get; set; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions.InsulationThermalConductivity'></a>

## HeatDemandOptions\.InsulationThermalConductivity Property

Gets or sets the thermal conductivity \[W/\(mK\)\] at or below which a layer ends the effective thickness of the internal heat capacity\.

```csharp
public double InsulationThermalConductivity { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions.InternalHeatCapacityMaximumThickness'></a>

## HeatDemandOptions\.InternalHeatCapacityMaximumThickness Property

Gets or sets the maximum thickness \[m\], from each face, counted in the internal heat capacity of a building element\.

```csharp
public double InternalHeatCapacityMaximumThickness { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions.NonPerpendicularIncidenceFactor'></a>

## HeatDemandOptions\.NonPerpendicularIncidenceFactor Property

Gets or sets the fallback correction for non\-perpendicular incidence F\_w \[\-\], used when the typology data gives none\.

```csharp
public double NonPerpendicularIncidenceFactor { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions.OpaqueSolarAbsorptance'></a>

## HeatDemandOptions\.OpaqueSolarAbsorptance Property

Gets or sets the absorption coefficient for solar radiation α \[\-\] of the opaque external surfaces\.

```csharp
public double OpaqueSolarAbsorptance { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions.RoofSkyFormFactor'></a>

## HeatDemandOptions\.RoofSkyFormFactor Property

Gets or sets the form factor F\_r \[\-\] between a roof and the sky\.

```csharp
public double RoofSkyFormFactor { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions.SkyTemperatureDifference'></a>

## HeatDemandOptions\.SkyTemperatureDifference Property

Gets or sets the average difference Δθ\_er \[K\] between the external air temperature and the apparent sky temperature\.

```csharp
public double SkyTemperatureDifference { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions.ThermalBridgingSurcharge'></a>

## HeatDemandOptions\.ThermalBridgingSurcharge Property

Gets or sets the fallback thermal bridging surcharge ΔU\_tb \[W/\(m2K\)\], used when the typology data gives none\.

```csharp
public double ThermalBridgingSurcharge { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions.UtilisationNumericalParameter'></a>

## HeatDemandOptions\.UtilisationNumericalParameter Property

Gets or sets the dimensionless reference numerical parameter a\_H,0 of the gain utilisation factor\.

```csharp
public double UtilisationNumericalParameter { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions.UtilisationReferenceTimeConstant'></a>

## HeatDemandOptions\.UtilisationReferenceTimeConstant Property

Gets or sets the reference time constant τ\_H,0 \[h\] of the gain utilisation factor\.

```csharp
public double UtilisationReferenceTimeConstant { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions.WallSkyFormFactor'></a>

## HeatDemandOptions\.WallSkyFormFactor Property

Gets or sets the form factor F\_r \[\-\] between a wall and the sky\.

```csharp
public double WallSkyFormFactor { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult'></a>

## HeatDemandResult Class

Represents the monthly heat demand of a building calculated by the PN\-EN ISO 52016\-1 monthly quasi\-steady method \(DiGi\-Organization/DiGi\.Analytical\#21\): the monthly and annual energy need for space heating, the heat transfer coefficients, the dynamic parameters, the design heat load and the provenance of every value\.

Created by `Create.HeatDemandResult`, which does the calculation; the constructor only assigns and copies.

```csharp
public class HeatDemandResult : DiGi.Core.Classes.SerializableResult, DiGi.Analytical.Building.Energy.Interfaces.IEnergySerializableObject, DiGi.Analytical.Building.Energy.Interfaces.IEnergyObject, DiGi.Analytical.Building.Interfaces.IBuildingObject, DiGi.Analytical.Interfaces.IAnalyticalObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Classes\.SerializableResult](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableresult 'DiGi\.Core\.Classes\.SerializableResult') → HeatDemandResult

Implements [IEnergySerializableObject](DiGi.Analytical.Building.Energy.Interfaces.md#DiGi.Analytical.Building.Energy.Interfaces.IEnergySerializableObject 'DiGi\.Analytical\.Building\.Energy\.Interfaces\.IEnergySerializableObject'), [IEnergyObject](DiGi.Analytical.Building.Energy.Interfaces.md#DiGi.Analytical.Building.Energy.Interfaces.IEnergyObject 'DiGi\.Analytical\.Building\.Energy\.Interfaces\.IEnergyObject'), [DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.ibuildingobject 'DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject'), [DiGi\.Analytical\.Interfaces\.IAnalyticalObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.interfaces.ianalyticalobject 'DiGi\.Analytical\.Interfaces\.IAnalyticalObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.HeatDemandResult(DiGi.Analytical.Building.Energy.Classes.HeatDemandResult)'></a>

## HeatDemandResult\(HeatDemandResult\) Constructor

Initializes a new instance of the [HeatDemandResult](DiGi.Analytical.Building.Energy.Classes.md#DiGi.Analytical.Building.Energy.Classes.HeatDemandResult 'DiGi\.Analytical\.Building\.Energy\.Classes\.HeatDemandResult') class by copying an existing instance\.

```csharp
public HeatDemandResult(DiGi.Analytical.Building.Energy.Classes.HeatDemandResult? heatDemandResult);
```
#### Parameters

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.HeatDemandResult(DiGi.Analytical.Building.Energy.Classes.HeatDemandResult).heatDemandResult'></a>

`heatDemandResult` [HeatDemandResult](DiGi.Analytical.Building.Energy.Classes.md#DiGi.Analytical.Building.Energy.Classes.HeatDemandResult 'DiGi\.Analytical\.Building\.Energy\.Classes\.HeatDemandResult')

The [HeatDemandResult](DiGi.Analytical.Building.Energy.Classes.md#DiGi.Analytical.Building.Energy.Classes.HeatDemandResult 'DiGi\.Analytical\.Building\.Energy\.Classes\.HeatDemandResult') to copy\. This value can be null\.

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.HeatDemandResult(double,double,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,double,double,double,double,double,double,string,int,System.Collections.Generic.IDictionary_string,string_,System.Collections.Generic.IEnumerable_string_,int,int)'></a>

## HeatDemandResult\(double, double, IEnumerable\<double\>, IEnumerable\<double\>, IEnumerable\<double\>, IEnumerable\<double\>, IEnumerable\<double\>, IEnumerable\<double\>, IEnumerable\<double\>, IEnumerable\<double\>, double, double, double, double, double, double, double, double, double, double, double, double, double, string, int, IDictionary\<string,string\>, IEnumerable\<string\>, int, int\) Constructor

Initializes a new instance of the [HeatDemandResult](DiGi.Analytical.Building.Energy.Classes.md#DiGi.Analytical.Building.Energy.Classes.HeatDemandResult 'DiGi\.Analytical\.Building\.Energy\.Classes\.HeatDemandResult') class\.

The values are assigned and the collections copied; `Create.HeatDemandResult` computes them.

```csharp
public HeatDemandResult(double heatingEnergyNeed, double heatingEnergyNeedPerArea, System.Collections.Generic.IEnumerable<double>? heatingEnergyNeeds, System.Collections.Generic.IEnumerable<double>? transmissionHeatTransfers, System.Collections.Generic.IEnumerable<double>? ventilationHeatTransfers, System.Collections.Generic.IEnumerable<double>? internalHeatGains, System.Collections.Generic.IEnumerable<double>? solarHeatGains, System.Collections.Generic.IEnumerable<double>? skyRadiationHeatTransfers, System.Collections.Generic.IEnumerable<double>? heatBalanceRatios, System.Collections.Generic.IEnumerable<double>? gainUtilisationFactors, double directHeatTransferCoefficient, double thermalBridgeHeatTransferCoefficient, double groundHeatTransferCoefficient, double unheatedSpaceHeatTransferCoefficient, double ventilationHeatTransferCoefficient, double internalHeatCapacity, double timeConstant, double referenceFloorArea, double heatedVolume, double internalTemperature, double designHeatLoad, double designTransmissionHeatLoss, double designVentilationHeatLoss, string? method, int methodVersion, System.Collections.Generic.IDictionary<string,string>? sources, System.Collections.Generic.IEnumerable<string>? excludedComponents, int glazingFallbackCount, int missingIrradiationCount);
```
#### Parameters

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.HeatDemandResult(double,double,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,double,double,double,double,double,double,string,int,System.Collections.Generic.IDictionary_string,string_,System.Collections.Generic.IEnumerable_string_,int,int).heatingEnergyNeed'></a>

`heatingEnergyNeed` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The annual energy need for space heating Q\_H,nd, the sum of the positive monthly needs \[kWh/a\]\.

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.HeatDemandResult(double,double,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,double,double,double,double,double,double,string,int,System.Collections.Generic.IDictionary_string,string_,System.Collections.Generic.IEnumerable_string_,int,int).heatingEnergyNeedPerArea'></a>

`heatingEnergyNeedPerArea` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The annual energy need for space heating per reference floor area Q\_H,nd / A\_ref \[kWh/\(m2a\)\]\.

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.HeatDemandResult(double,double,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,double,double,double,double,double,double,string,int,System.Collections.Generic.IDictionary_string,string_,System.Collections.Generic.IEnumerable_string_,int,int).heatingEnergyNeeds'></a>

`heatingEnergyNeeds` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The monthly energy needs for space heating Q\_H,nd,m, January to December \[kWh\]\. This value can be null\.

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.HeatDemandResult(double,double,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,double,double,double,double,double,double,string,int,System.Collections.Generic.IDictionary_string,string_,System.Collections.Generic.IEnumerable_string_,int,int).transmissionHeatTransfers'></a>

`transmissionHeatTransfers` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The monthly heat transfer by transmission Q\_tr,m = \(H\_D \+ H\_tb \+ H\_g \+ H\_U\)·\(θ\_int − θ\_e,m\)·t\_m, January to December \[kWh\]\. This value can be null\.

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.HeatDemandResult(double,double,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,double,double,double,double,double,double,string,int,System.Collections.Generic.IDictionary_string,string_,System.Collections.Generic.IEnumerable_string_,int,int).ventilationHeatTransfers'></a>

`ventilationHeatTransfers` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The monthly heat transfer by ventilation Q\_ve,m = H\_ve·\(θ\_int − θ\_e,m\)·t\_m, January to December \[kWh\]\. This value can be null\.

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.HeatDemandResult(double,double,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,double,double,double,double,double,double,string,int,System.Collections.Generic.IDictionary_string,string_,System.Collections.Generic.IEnumerable_string_,int,int).internalHeatGains'></a>

`internalHeatGains` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The monthly internal heat gains Q\_int,m, January to December \[kWh\]\. This value can be null\.

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.HeatDemandResult(double,double,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,double,double,double,double,double,double,string,int,System.Collections.Generic.IDictionary_string,string_,System.Collections.Generic.IEnumerable_string_,int,int).solarHeatGains'></a>

`solarHeatGains` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The monthly solar heat gains of glazed and opaque elements before the sky radiation is subtracted, January to December \[kWh\]\. This value can be null\.

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.HeatDemandResult(double,double,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,double,double,double,double,double,double,string,int,System.Collections.Generic.IDictionary_string,string_,System.Collections.Generic.IEnumerable_string_,int,int).skyRadiationHeatTransfers'></a>

`skyRadiationHeatTransfers` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The monthly extra heat flow by thermal radiation to the sky, subtracted from the solar gains, January to December \[kWh\]\. This value can be null\.

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.HeatDemandResult(double,double,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,double,double,double,double,double,double,string,int,System.Collections.Generic.IDictionary_string,string_,System.Collections.Generic.IEnumerable_string_,int,int).heatBalanceRatios'></a>

`heatBalanceRatios` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The monthly heat balance ratios γ\_H = Q\_gn / Q\_ht, January to December \[\-\]\. This value can be null\.

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.HeatDemandResult(double,double,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,double,double,double,double,double,double,string,int,System.Collections.Generic.IDictionary_string,string_,System.Collections.Generic.IEnumerable_string_,int,int).gainUtilisationFactors'></a>

`gainUtilisationFactors` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The monthly gain utilisation factors η\_H,gn, January to December \[\-\]\. This value can be null\.

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.HeatDemandResult(double,double,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,double,double,double,double,double,double,string,int,System.Collections.Generic.IDictionary_string,string_,System.Collections.Generic.IEnumerable_string_,int,int).directHeatTransferCoefficient'></a>

`directHeatTransferCoefficient` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The direct heat transfer coefficient H\_D = Σ U·A of the external walls, roofs, exposed floors, windows and doors \[W/K\]\.

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.HeatDemandResult(double,double,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,double,double,double,double,double,double,string,int,System.Collections.Generic.IDictionary_string,string_,System.Collections.Generic.IEnumerable_string_,int,int).thermalBridgeHeatTransferCoefficient'></a>

`thermalBridgeHeatTransferCoefficient` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The heat transfer coefficient of thermal bridges H\_tb = ΔU\_tb·ΣA \[W/K\]\.

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.HeatDemandResult(double,double,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,double,double,double,double,double,double,string,int,System.Collections.Generic.IDictionary_string,string_,System.Collections.Generic.IEnumerable_string_,int,int).groundHeatTransferCoefficient'></a>

`groundHeatTransferCoefficient` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The heat transfer coefficient through the ground H\_g of the floors on the ground \[W/K\]\.

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.HeatDemandResult(double,double,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,double,double,double,double,double,double,string,int,System.Collections.Generic.IDictionary_string,string_,System.Collections.Generic.IEnumerable_string_,int,int).unheatedSpaceHeatTransferCoefficient'></a>

`unheatedSpaceHeatTransferCoefficient` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The heat transfer coefficient through the unheated cellar H\_U \[W/K\]\.

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.HeatDemandResult(double,double,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,double,double,double,double,double,double,string,int,System.Collections.Generic.IDictionary_string,string_,System.Collections.Generic.IEnumerable_string_,int,int).ventilationHeatTransferCoefficient'></a>

`ventilationHeatTransferCoefficient` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The ventilation heat transfer coefficient H\_ve \[W/K\]\.

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.HeatDemandResult(double,double,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,double,double,double,double,double,double,string,int,System.Collections.Generic.IDictionary_string,string_,System.Collections.Generic.IEnumerable_string_,int,int).internalHeatCapacity'></a>

`internalHeatCapacity` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The internal heat capacity of the building C\_m \[J/K\]\.

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.HeatDemandResult(double,double,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,double,double,double,double,double,double,string,int,System.Collections.Generic.IDictionary_string,string_,System.Collections.Generic.IEnumerable_string_,int,int).timeConstant'></a>

`timeConstant` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The time constant of the building τ \[h\]\.

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.HeatDemandResult(double,double,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,double,double,double,double,double,double,string,int,System.Collections.Generic.IDictionary_string,string_,System.Collections.Generic.IEnumerable_string_,int,int).referenceFloorArea'></a>

`referenceFloorArea` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The reference floor area A\_ref, the gross floor area of the spaces \[m2\]\.

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.HeatDemandResult(double,double,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,double,double,double,double,double,double,string,int,System.Collections.Generic.IDictionary_string,string_,System.Collections.Generic.IEnumerable_string_,int,int).heatedVolume'></a>

`heatedVolume` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The volume inside the external shell V \[m3\]\.

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.HeatDemandResult(double,double,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,double,double,double,double,double,double,string,int,System.Collections.Generic.IDictionary_string,string_,System.Collections.Generic.IEnumerable_string_,int,int).internalTemperature'></a>

`internalTemperature` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The internal set\-point temperature for heating θ\_int, the floor\-area weighted thermostat lower limit \[°C\]\.

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.HeatDemandResult(double,double,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,double,double,double,double,double,double,string,int,System.Collections.Generic.IDictionary_string,string_,System.Collections.Generic.IEnumerable_string_,int,int).designHeatLoad'></a>

`designHeatLoad` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The design heat load Φ\_HL = Φ\_T \+ Φ\_V \[W\]\.

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.HeatDemandResult(double,double,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,double,double,double,double,double,double,string,int,System.Collections.Generic.IDictionary_string,string_,System.Collections.Generic.IEnumerable_string_,int,int).designTransmissionHeatLoss'></a>

`designTransmissionHeatLoss` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The design transmission heat loss Φ\_T \[W\]\.

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.HeatDemandResult(double,double,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,double,double,double,double,double,double,string,int,System.Collections.Generic.IDictionary_string,string_,System.Collections.Generic.IEnumerable_string_,int,int).designVentilationHeatLoss'></a>

`designVentilationHeatLoss` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The design ventilation heat loss Φ\_V \[W\]\.

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.HeatDemandResult(double,double,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,double,double,double,double,double,double,string,int,System.Collections.Generic.IDictionary_string,string_,System.Collections.Generic.IEnumerable_string_,int,int).method'></a>

`method` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The method the result was calculated by\. This value can be null\.

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.HeatDemandResult(double,double,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,double,double,double,double,double,double,string,int,System.Collections.Generic.IDictionary_string,string_,System.Collections.Generic.IEnumerable_string_,int,int).methodVersion'></a>

`methodVersion` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The version of the method, [HeatDemandMethodVersion](DiGi.Analytical.Building.Energy.Constants.md#DiGi.Analytical.Building.Energy.Constants.Default.HeatDemandMethodVersion 'DiGi\.Analytical\.Building\.Energy\.Constants\.Default\.HeatDemandMethodVersion') when the result was calculated\.

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.HeatDemandResult(double,double,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,double,double,double,double,double,double,string,int,System.Collections.Generic.IDictionary_string,string_,System.Collections.Generic.IEnumerable_string_,int,int).sources'></a>

`sources` [System\.Collections\.Generic\.IDictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2 'System\.Collections\.Generic\.IDictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2 'System\.Collections\.Generic\.IDictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2 'System\.Collections\.Generic\.IDictionary\`2')

The source of each value, keyed by the name of the value\. This value can be null\.

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.HeatDemandResult(double,double,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,double,double,double,double,double,double,string,int,System.Collections.Generic.IDictionary_string,string_,System.Collections.Generic.IEnumerable_string_,int,int).excludedComponents'></a>

`excludedComponents` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The identifiers, in the "D" format, of the components and openings excluded because their thermal transmittance is not known\. This value can be null\.

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.HeatDemandResult(double,double,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,double,double,double,double,double,double,string,int,System.Collections.Generic.IDictionary_string,string_,System.Collections.Generic.IEnumerable_string_,int,int).glazingFallbackCount'></a>

`glazingFallbackCount` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of glazed openings whose glazed area was taken as \(1 − F\_f\)·A\_w because their construction has no panes\.

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.HeatDemandResult(double,double,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,double,double,double,double,double,double,string,int,System.Collections.Generic.IDictionary_string,string_,System.Collections.Generic.IEnumerable_string_,int,int).missingIrradiationCount'></a>

`missingIrradiationCount` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The number of external surfaces with no monthly irradiation in the climate, whose solar gains are 0\.

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.HeatDemandResult(System.Text.Json.Nodes.JsonObject)'></a>

## HeatDemandResult\(JsonObject\) Constructor

Initializes a new instance of the [HeatDemandResult](DiGi.Analytical.Building.Energy.Classes.md#DiGi.Analytical.Building.Energy.Classes.HeatDemandResult 'DiGi\.Analytical\.Building\.Energy\.Classes\.HeatDemandResult') class from a JSON object\.

```csharp
public HeatDemandResult(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.HeatDemandResult(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the result data\. This value can be null\.
### Properties

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.DesignHeatLoad'></a>

## HeatDemandResult\.DesignHeatLoad Property

Gets the design heat load Φ\_HL = Φ\_T \+ Φ\_V \[W\]\.

```csharp
public double DesignHeatLoad { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.DesignTransmissionHeatLoss'></a>

## HeatDemandResult\.DesignTransmissionHeatLoss Property

Gets the design transmission heat loss Φ\_T \[W\]\.

```csharp
public double DesignTransmissionHeatLoss { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.DesignVentilationHeatLoss'></a>

## HeatDemandResult\.DesignVentilationHeatLoss Property

Gets the design ventilation heat loss Φ\_V \[W\]\.

```csharp
public double DesignVentilationHeatLoss { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.DirectHeatTransferCoefficient'></a>

## HeatDemandResult\.DirectHeatTransferCoefficient Property

Gets the direct heat transfer coefficient H\_D = Σ U·A of the external walls, roofs, exposed floors, windows and doors \[W/K\]\.

```csharp
public double DirectHeatTransferCoefficient { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.ExcludedComponents'></a>

## HeatDemandResult\.ExcludedComponents Property

Gets a copy of the identifiers, in the "D" format, of the components and openings excluded because their thermal transmittance is not known\.

```csharp
public System.Collections.Generic.List<string>? ExcludedComponents { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.GainUtilisationFactors'></a>

## HeatDemandResult\.GainUtilisationFactors Property

Gets a copy of the monthly gain utilisation factors η\_H,gn, January to December \[\-\]\.

```csharp
public System.Collections.Generic.List<double>? GainUtilisationFactors { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.GlazingFallbackCount'></a>

## HeatDemandResult\.GlazingFallbackCount Property

Gets the number of glazed openings whose glazed area was taken as \(1 − F\_f\)·A\_w because their construction has no panes\.

```csharp
public int GlazingFallbackCount { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.GroundHeatTransferCoefficient'></a>

## HeatDemandResult\.GroundHeatTransferCoefficient Property

Gets the heat transfer coefficient through the ground H\_g of the floors on the ground \[W/K\]\.

```csharp
public double GroundHeatTransferCoefficient { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.HeatBalanceRatios'></a>

## HeatDemandResult\.HeatBalanceRatios Property

Gets a copy of the monthly heat balance ratios γ\_H = Q\_gn / Q\_ht, January to December \[\-\]\.

```csharp
public System.Collections.Generic.List<double>? HeatBalanceRatios { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.HeatedVolume'></a>

## HeatDemandResult\.HeatedVolume Property

Gets the volume inside the external shell V \[m3\]\.

```csharp
public double HeatedVolume { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.HeatingEnergyNeed'></a>

## HeatDemandResult\.HeatingEnergyNeed Property

Gets the annual energy need for space heating Q\_H,nd, the sum of the positive monthly needs \[kWh/a\]\.

```csharp
public double HeatingEnergyNeed { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.HeatingEnergyNeedPerArea'></a>

## HeatDemandResult\.HeatingEnergyNeedPerArea Property

Gets the annual energy need for space heating per reference floor area Q\_H,nd / A\_ref \[kWh/\(m2a\)\]\.

```csharp
public double HeatingEnergyNeedPerArea { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.HeatingEnergyNeeds'></a>

## HeatDemandResult\.HeatingEnergyNeeds Property

Gets a copy of the monthly energy needs for space heating Q\_H,nd,m, January to December \[kWh\]\.

```csharp
public System.Collections.Generic.List<double>? HeatingEnergyNeeds { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.InternalHeatCapacity'></a>

## HeatDemandResult\.InternalHeatCapacity Property

Gets the internal heat capacity of the building C\_m \[J/K\]\.

```csharp
public double InternalHeatCapacity { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.InternalHeatGains'></a>

## HeatDemandResult\.InternalHeatGains Property

Gets a copy of the monthly internal heat gains Q\_int,m, January to December \[kWh\]\.

```csharp
public System.Collections.Generic.List<double>? InternalHeatGains { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.InternalTemperature'></a>

## HeatDemandResult\.InternalTemperature Property

Gets the internal set\-point temperature for heating θ\_int, the floor\-area weighted thermostat lower limit \[°C\]\.

```csharp
public double InternalTemperature { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.Method'></a>

## HeatDemandResult\.Method Property

Gets the method the result was calculated by\.

```csharp
public string? Method { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.MethodVersion'></a>

## HeatDemandResult\.MethodVersion Property

Gets the version of the method, [HeatDemandMethodVersion](DiGi.Analytical.Building.Energy.Constants.md#DiGi.Analytical.Building.Energy.Constants.Default.HeatDemandMethodVersion 'DiGi\.Analytical\.Building\.Energy\.Constants\.Default\.HeatDemandMethodVersion') when the result was calculated\.

```csharp
public int MethodVersion { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.MissingIrradiationCount'></a>

## HeatDemandResult\.MissingIrradiationCount Property

Gets the number of external surfaces with no monthly irradiation in the climate, whose solar gains are 0\.

```csharp
public int MissingIrradiationCount { get; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.ReferenceFloorArea'></a>

## HeatDemandResult\.ReferenceFloorArea Property

Gets the reference floor area A\_ref, the gross floor area of the spaces \[m2\]\.

```csharp
public double ReferenceFloorArea { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.SkyRadiationHeatTransfers'></a>

## HeatDemandResult\.SkyRadiationHeatTransfers Property

Gets a copy of the monthly extra heat flow by thermal radiation to the sky, subtracted from the solar gains, January to December \[kWh\]\.

```csharp
public System.Collections.Generic.List<double>? SkyRadiationHeatTransfers { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.SolarHeatGains'></a>

## HeatDemandResult\.SolarHeatGains Property

Gets a copy of the monthly solar heat gains of glazed and opaque elements before the sky radiation is subtracted, January to December \[kWh\]\.

```csharp
public System.Collections.Generic.List<double>? SolarHeatGains { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.Sources'></a>

## HeatDemandResult\.Sources Property

Gets a copy of the source of each value, keyed by the name of the value\.

```csharp
public System.Collections.Generic.Dictionary<string,string>? Sources { get; }
```

#### Property Value
[System\.Collections\.Generic\.Dictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.ThermalBridgeHeatTransferCoefficient'></a>

## HeatDemandResult\.ThermalBridgeHeatTransferCoefficient Property

Gets the heat transfer coefficient of thermal bridges H\_tb = ΔU\_tb·ΣA \[W/K\]\.

```csharp
public double ThermalBridgeHeatTransferCoefficient { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.TimeConstant'></a>

## HeatDemandResult\.TimeConstant Property

Gets the time constant of the building τ \[h\]\.

```csharp
public double TimeConstant { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.TransmissionHeatTransfers'></a>

## HeatDemandResult\.TransmissionHeatTransfers Property

Gets a copy of the monthly heat transfer by transmission Q\_tr,m = \(H\_D \+ H\_tb \+ H\_g \+ H\_U\)·\(θ\_int − θ\_e,m\)·t\_m, January to December \[kWh\]\.

```csharp
public System.Collections.Generic.List<double>? TransmissionHeatTransfers { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.UnheatedSpaceHeatTransferCoefficient'></a>

## HeatDemandResult\.UnheatedSpaceHeatTransferCoefficient Property

Gets the heat transfer coefficient through the unheated cellar H\_U \[W/K\]\.

```csharp
public double UnheatedSpaceHeatTransferCoefficient { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.VentilationHeatTransferCoefficient'></a>

## HeatDemandResult\.VentilationHeatTransferCoefficient Property

Gets the ventilation heat transfer coefficient H\_ve \[W/K\]\.

```csharp
public double VentilationHeatTransferCoefficient { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.VentilationHeatTransfers'></a>

## HeatDemandResult\.VentilationHeatTransfers Property

Gets a copy of the monthly heat transfer by ventilation Q\_ve,m = H\_ve·\(θ\_int − θ\_e,m\)·t\_m, January to December \[kWh\]\.

```csharp
public System.Collections.Generic.List<double>? VentilationHeatTransfers { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.Analytical.Building.Energy.Classes.MonthlyClimate'></a>

## MonthlyClimate Class

Represents the monthly climate a building's heat demand is calculated for \(DiGi\-Organization/DiGi\.Analytical\#21\): the 12 monthly mean external temperatures, the design and mean annual temperatures of its climate zone, and the monthly solar irradiation on each of its external surfaces\.

Assembled by DiGi.GIS.Analytical `Create.MonthlyClimate` from the weather file and the solar result of the building; the constructor only assigns and copies.

```csharp
public class MonthlyClimate : DiGi.Core.Classes.SerializableObject, DiGi.Analytical.Building.Energy.Interfaces.IEnergySerializableObject, DiGi.Analytical.Building.Energy.Interfaces.IEnergyObject, DiGi.Analytical.Building.Interfaces.IBuildingObject, DiGi.Analytical.Interfaces.IAnalyticalObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → MonthlyClimate

Implements [IEnergySerializableObject](DiGi.Analytical.Building.Energy.Interfaces.md#DiGi.Analytical.Building.Energy.Interfaces.IEnergySerializableObject 'DiGi\.Analytical\.Building\.Energy\.Interfaces\.IEnergySerializableObject'), [IEnergyObject](DiGi.Analytical.Building.Energy.Interfaces.md#DiGi.Analytical.Building.Energy.Interfaces.IEnergyObject 'DiGi\.Analytical\.Building\.Energy\.Interfaces\.IEnergyObject'), [DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.ibuildingobject 'DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject'), [DiGi\.Analytical\.Interfaces\.IAnalyticalObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.interfaces.ianalyticalobject 'DiGi\.Analytical\.Interfaces\.IAnalyticalObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Analytical.Building.Energy.Classes.MonthlyClimate.MonthlyClimate(DiGi.Analytical.Building.Energy.Classes.MonthlyClimate)'></a>

## MonthlyClimate\(MonthlyClimate\) Constructor

Initializes a new instance of the [MonthlyClimate](DiGi.Analytical.Building.Energy.Classes.md#DiGi.Analytical.Building.Energy.Classes.MonthlyClimate 'DiGi\.Analytical\.Building\.Energy\.Classes\.MonthlyClimate') class by copying an existing instance\.

```csharp
public MonthlyClimate(DiGi.Analytical.Building.Energy.Classes.MonthlyClimate? monthlyClimate);
```
#### Parameters

<a name='DiGi.Analytical.Building.Energy.Classes.MonthlyClimate.MonthlyClimate(DiGi.Analytical.Building.Energy.Classes.MonthlyClimate).monthlyClimate'></a>

`monthlyClimate` [MonthlyClimate](DiGi.Analytical.Building.Energy.Classes.md#DiGi.Analytical.Building.Energy.Classes.MonthlyClimate 'DiGi\.Analytical\.Building\.Energy\.Classes\.MonthlyClimate')

The [MonthlyClimate](DiGi.Analytical.Building.Energy.Classes.md#DiGi.Analytical.Building.Energy.Classes.MonthlyClimate 'DiGi\.Analytical\.Building\.Energy\.Classes\.MonthlyClimate') to copy\. This value can be null\.

<a name='DiGi.Analytical.Building.Energy.Classes.MonthlyClimate.MonthlyClimate(System.Collections.Generic.IEnumerable_double_,double,double,System.Collections.Generic.IDictionary_string,System.Collections.Generic.List_double__,string)'></a>

## MonthlyClimate\(IEnumerable\<double\>, double, double, IDictionary\<string,List\<double\>\>, string\) Constructor

Initializes a new instance of the [MonthlyClimate](DiGi.Analytical.Building.Energy.Classes.md#DiGi.Analytical.Building.Energy.Classes.MonthlyClimate 'DiGi\.Analytical\.Building\.Energy\.Classes\.MonthlyClimate') class\.

The values are assigned and the collections copied; nothing is validated here. `Create.HeatDemandResult` rejects a climate without 12 temperatures.

```csharp
public MonthlyClimate(System.Collections.Generic.IEnumerable<double>? externalTemperatures, double designExternalTemperature, double annualMeanExternalTemperature, System.Collections.Generic.IDictionary<string,System.Collections.Generic.List<double>>? surfaceIrradiations, string? source);
```
#### Parameters

<a name='DiGi.Analytical.Building.Energy.Classes.MonthlyClimate.MonthlyClimate(System.Collections.Generic.IEnumerable_double_,double,double,System.Collections.Generic.IDictionary_string,System.Collections.Generic.List_double__,string).externalTemperatures'></a>

`externalTemperatures` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The monthly mean external air temperatures θ\_e,m, January to December \[°C\]\. This value can be null\.

<a name='DiGi.Analytical.Building.Energy.Classes.MonthlyClimate.MonthlyClimate(System.Collections.Generic.IEnumerable_double_,double,double,System.Collections.Generic.IDictionary_string,System.Collections.Generic.List_double__,string).designExternalTemperature'></a>

`designExternalTemperature` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The design external temperature θ\_e of the design heat load \[°C\]\.

<a name='DiGi.Analytical.Building.Energy.Classes.MonthlyClimate.MonthlyClimate(System.Collections.Generic.IEnumerable_double_,double,double,System.Collections.Generic.IDictionary_string,System.Collections.Generic.List_double__,string).annualMeanExternalTemperature'></a>

`annualMeanExternalTemperature` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The mean annual external temperature θ\_m,e \[°C\]\.

<a name='DiGi.Analytical.Building.Energy.Classes.MonthlyClimate.MonthlyClimate(System.Collections.Generic.IEnumerable_double_,double,double,System.Collections.Generic.IDictionary_string,System.Collections.Generic.List_double__,string).surfaceIrradiations'></a>

`surfaceIrradiations` [System\.Collections\.Generic\.IDictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2 'System\.Collections\.Generic\.IDictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2 'System\.Collections\.Generic\.IDictionary\`2')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2 'System\.Collections\.Generic\.IDictionary\`2')

The monthly solar irradiation on the outward face of each external component, shading included, keyed by the component's identifier in the "D" format, January to December \[kWh/m2\]\. This value can be null\.

<a name='DiGi.Analytical.Building.Energy.Classes.MonthlyClimate.MonthlyClimate(System.Collections.Generic.IEnumerable_double_,double,double,System.Collections.Generic.IDictionary_string,System.Collections.Generic.List_double__,string).source'></a>

`source` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The sources of the values: weather file, solar result\. This value can be null\.

<a name='DiGi.Analytical.Building.Energy.Classes.MonthlyClimate.MonthlyClimate(System.Text.Json.Nodes.JsonObject)'></a>

## MonthlyClimate\(JsonObject\) Constructor

Initializes a new instance of the [MonthlyClimate](DiGi.Analytical.Building.Energy.Classes.md#DiGi.Analytical.Building.Energy.Classes.MonthlyClimate 'DiGi\.Analytical\.Building\.Energy\.Classes\.MonthlyClimate') class from a JSON object\.

```csharp
public MonthlyClimate(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Analytical.Building.Energy.Classes.MonthlyClimate.MonthlyClimate(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the climate data\. This value can be null\.
### Properties

<a name='DiGi.Analytical.Building.Energy.Classes.MonthlyClimate.AnnualMeanExternalTemperature'></a>

## MonthlyClimate\.AnnualMeanExternalTemperature Property

Gets the mean annual external temperature θ\_m,e \[°C\]\.

```csharp
public double AnnualMeanExternalTemperature { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Classes.MonthlyClimate.DesignExternalTemperature'></a>

## MonthlyClimate\.DesignExternalTemperature Property

Gets the design external temperature θ\_e of the design heat load \[°C\]\.

```csharp
public double DesignExternalTemperature { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Classes.MonthlyClimate.ExternalTemperatures'></a>

## MonthlyClimate\.ExternalTemperatures Property

Gets a copy of the monthly mean external air temperatures θ\_e,m, January to December \[°C\]\.

```csharp
public System.Collections.Generic.List<double>? ExternalTemperatures { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.Analytical.Building.Energy.Classes.MonthlyClimate.Source'></a>

## MonthlyClimate\.Source Property

Gets the sources of the values\.

```csharp
public string? Source { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.Energy.Classes.MonthlyClimate.SurfaceIrradiations'></a>

## MonthlyClimate\.SurfaceIrradiations Property

Gets a copy of the monthly solar irradiation on the outward face of each external component, keyed by the component's identifier in the "D" format, January to December \[kWh/m2\]\.

```csharp
public System.Collections.Generic.Dictionary<string,System.Collections.Generic.List<double>>? SurfaceIrradiations { get; }
```

#### Property Value
[System\.Collections\.Generic\.Dictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')