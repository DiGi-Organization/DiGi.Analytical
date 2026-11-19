#### [DiGi\.Analytical\.Building\.Energy](DiGi.Analytical.Building.Energy.Overview.md 'DiGi\.Analytical\.Building\.Energy\.Overview')

## DiGi\.Analytical\.Building\.Energy Namespace
### Classes

<a name='DiGi.Analytical.Building.Energy.Create'></a>

## Create Class

```csharp
public static class Create
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Create
### Methods

<a name='DiGi.Analytical.Building.Energy.Create.HeatDemandResult(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Energy.Classes.MonthlyClimate,DiGi.Analytical.Building.Regulation.Classes.TypologyData,DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions,double)'></a>

## Create\.HeatDemandResult\(this BuildingModel, MonthlyClimate, TypologyData, HeatDemandOptions, double\) Method

Calculates the monthly and annual energy need for space heating and the design heat load of a building model, as one continuously heated zone, by the PN\-EN ISO 52016\-1 monthly quasi\-steady method \(DiGi\-Organization/DiGi\.Analytical\#21\), [Method](DiGi.Analytical.Building.Energy.Constants.md#DiGi.Analytical.Building.Energy.Constants.Source.Method 'DiGi\.Analytical\.Building\.Energy\.Constants\.Source\.Method')\.

<b>Components.</b> Walls, roofs and floors are classified by `Regulation.Query.ConstructionRoles`. External walls (net of the outlines of their openings), roofs, windows and doors make H_D = Σ U·A: opaque U per PN-EN ISO 6946 from the model (a declared U wins), walls with a horizontal and roofs with an upward heat flow; window and door U the declared Uw over the whole outline, computed from the pane layout only when none is declared. Party walls are adiabatic. A component or opening whose U is not known is excluded and listed in [ExcludedComponents](DiGi.Analytical.Building.Energy.Classes.md#DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.ExcludedComponents 'DiGi\.Analytical\.Building\.Energy\.Classes\.HeatDemandResult\.ExcludedComponents'), never counted as 0.

<b>Floors.</b> The lowest floor - and any other floor of the external shell standing within [LevelTolerance](DiGi.Analytical.Building.Energy.Constants.md#DiGi.Analytical.Building.Energy.Constants.Default.LevelTolerance 'DiGi\.Analytical\.Building\.Energy\.Constants\.Default\.LevelTolerance') of the lowest level - lies on the ground (H_g, [GroundThermalTransmittance\(double, double, double, double, double\)](DiGi.Analytical.Building.Energy.md#DiGi.Analytical.Building.Energy.Query.GroundThermalTransmittance(double,double,double,double,double) 'DiGi\.Analytical\.Building\.Energy\.Query\.GroundThermalTransmittance\(double, double, double, double, double\)'), R_f from the floor's own layers, never its declared U) or, with a [DiGi\.Analytical\.Building\.Regulation\.Enums\.FloorBoundary\.Cellar](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.regulation.enums.floorboundary.cellar 'DiGi\.Analytical\.Building\.Regulation\.Enums\.FloorBoundary\.Cellar') floor boundary, over the cellar: H_U = b·A / (1/U_f + R_add), U_f from the layers, so the cellar is counted once. A floor of the shell above the lowest level is a floor over outside air and joins H_D with a downward heat flow. Thermal bridges add H_tb = ΔU_tb·ΣA over every heat-loss element.

<b>Ventilation and gains.</b> H_ve = ρ_a·c_a·(q_ve + n_inf·V / 3600), with q_ve the usage profile's outside airflow per area times A_ref and n_inf its infiltration. θ_int, the internal gain per area, the airflow per area and n_inf are the floor-area weighted means of the spaces' first internal condition (its thermostat lower limit: continuous heating); a space without one does not weigh. Solar gains are F_w·g_gl,n·A_g·I_m for glazing - A_g the pane faces, (1 − F_f)·A_w for a construction without panes, counted - and α·R_se·U·A·I_m for opaque elements, I_m the host surface's monthly irradiation from [monthlyClimate](DiGi.Analytical.Building.Energy.md#DiGi.Analytical.Building.Energy.Create.HeatDemandResult(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Energy.Classes.MonthlyClimate,DiGi.Analytical.Building.Regulation.Classes.TypologyData,DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions,double).monthlyClimate 'DiGi\.Analytical\.Building\.Energy\.Create\.HeatDemandResult\(this DiGi\.Analytical\.Building\.Classes\.BuildingModel, DiGi\.Analytical\.Building\.Energy\.Classes\.MonthlyClimate, DiGi\.Analytical\.Building\.Regulation\.Classes\.TypologyData, DiGi\.Analytical\.Building\.Energy\.Classes\.HeatDemandOptions, double\)\.monthlyClimate'); a surface missing there gains nothing and is counted. The extra heat flow to the sky F_r·R_se·U·A·h_r·Δθ_er is subtracted from the gains (Eq. (44)).

<b>Balance.</b> Per month Q_ht = (H_D + H_tb + H_g + H_U + H_ve)·(θ_int − θ_e,m)·t_m, Q_gn = Q_int + Q_sol − Q_sky, γ = Q_gn / Q_ht, a = a_H,0 + τ / τ_H,0 with τ = C_m / 3600 / H, and Q_H,nd,m = max(0, Q_ht − η·Q_gn); a month whose gains are not positive uses η = 1. The design heat load is [DesignHeatLoad\(double, double, double, double, double, double\)](DiGi.Analytical.Building.Energy.md#DiGi.Analytical.Building.Energy.Query.DesignHeatLoad(double,double,double,double,double,double) 'DiGi\.Analytical\.Building\.Energy\.Query\.DesignHeatLoad\(double, double, double, double, double, double\)').

<b>Typology data.</b> F_w, ΔU_tb, F_f, R_add and b come from [typologyData](DiGi.Analytical.Building.Energy.md#DiGi.Analytical.Building.Energy.Create.HeatDemandResult(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Energy.Classes.MonthlyClimate,DiGi.Analytical.Building.Regulation.Classes.TypologyData,DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions,double).typologyData 'DiGi\.Analytical\.Building\.Energy\.Create\.HeatDemandResult\(this DiGi\.Analytical\.Building\.Classes\.BuildingModel, DiGi\.Analytical\.Building\.Energy\.Classes\.MonthlyClimate, DiGi\.Analytical\.Building\.Regulation\.Classes\.TypologyData, DiGi\.Analytical\.Building\.Energy\.Classes\.HeatDemandOptions, double\)\.typologyData') - the TypicalAsBuilt set of the year built - and fall back to [heatDemandOptions](DiGi.Analytical.Building.Energy.md#DiGi.Analytical.Building.Energy.Create.HeatDemandResult(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Energy.Classes.MonthlyClimate,DiGi.Analytical.Building.Regulation.Classes.TypologyData,DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions,double).heatDemandOptions 'DiGi\.Analytical\.Building\.Energy\.Create\.HeatDemandResult\(this DiGi\.Analytical\.Building\.Classes\.BuildingModel, DiGi\.Analytical\.Building\.Energy\.Classes\.MonthlyClimate, DiGi\.Analytical\.Building\.Regulation\.Classes\.TypologyData, DiGi\.Analytical\.Building\.Energy\.Classes\.HeatDemandOptions, double\)\.heatDemandOptions') where it gives none; every value used is recorded in [Sources](DiGi.Analytical.Building.Energy.Classes.md#DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.Sources 'DiGi\.Analytical\.Building\.Energy\.Classes\.HeatDemandResult\.Sources').

```csharp
public static DiGi.Analytical.Building.Energy.Classes.HeatDemandResult? HeatDemandResult(this DiGi.Analytical.Building.Classes.BuildingModel? buildingModel, DiGi.Analytical.Building.Energy.Classes.MonthlyClimate? monthlyClimate, DiGi.Analytical.Building.Regulation.Classes.TypologyData? typologyData, DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions? heatDemandOptions=null, double tolerance=1E-06);
```
#### Parameters

<a name='DiGi.Analytical.Building.Energy.Create.HeatDemandResult(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Energy.Classes.MonthlyClimate,DiGi.Analytical.Building.Regulation.Classes.TypologyData,DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions,double).buildingModel'></a>

`buildingModel` [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')

The building model, with constructions, openings and internal conditions assigned\. This value can be null\.

<a name='DiGi.Analytical.Building.Energy.Create.HeatDemandResult(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Energy.Classes.MonthlyClimate,DiGi.Analytical.Building.Regulation.Classes.TypologyData,DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions,double).monthlyClimate'></a>

`monthlyClimate` [MonthlyClimate](DiGi.Analytical.Building.Energy.Classes.md#DiGi.Analytical.Building.Energy.Classes.MonthlyClimate 'DiGi\.Analytical\.Building\.Energy\.Classes\.MonthlyClimate')

The monthly climate of the building\. This value can be null\.

<a name='DiGi.Analytical.Building.Energy.Create.HeatDemandResult(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Energy.Classes.MonthlyClimate,DiGi.Analytical.Building.Regulation.Classes.TypologyData,DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions,double).typologyData'></a>

`typologyData` [DiGi\.Analytical\.Building\.Regulation\.Classes\.TypologyData](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.regulation.classes.typologydata 'DiGi\.Analytical\.Building\.Regulation\.Classes\.TypologyData')

The TABULA typology data of the TypicalAsBuilt set of the year built\. This value can be null\.

<a name='DiGi.Analytical.Building.Energy.Create.HeatDemandResult(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Energy.Classes.MonthlyClimate,DiGi.Analytical.Building.Regulation.Classes.TypologyData,DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions,double).heatDemandOptions'></a>

`heatDemandOptions` [HeatDemandOptions](DiGi.Analytical.Building.Energy.Classes.md#DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions 'DiGi\.Analytical\.Building\.Energy\.Classes\.HeatDemandOptions')

The options; null uses the defaults of [Default](DiGi.Analytical.Building.Energy.Constants.md#DiGi.Analytical.Building.Energy.Constants.Default 'DiGi\.Analytical\.Building\.Energy\.Constants\.Default')\.

<a name='DiGi.Analytical.Building.Energy.Create.HeatDemandResult(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Energy.Classes.MonthlyClimate,DiGi.Analytical.Building.Regulation.Classes.TypologyData,DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions,double).tolerance'></a>

`tolerance` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The distance tolerance of the external shell and the footprint\.

#### Returns
[HeatDemandResult](DiGi.Analytical.Building.Energy.Classes.md#DiGi.Analytical.Building.Energy.Classes.HeatDemandResult 'DiGi\.Analytical\.Building\.Energy\.Classes\.HeatDemandResult')  
The [HeatDemandResult](DiGi.Analytical.Building.Energy.Classes.md#DiGi.Analytical.Building.Energy.Classes.HeatDemandResult 'DiGi\.Analytical\.Building\.Energy\.Classes\.HeatDemandResult'), or null when the model or the climate is null, the climate has not 12 external temperatures, no space with a floor carries an internal condition with a heating set\-point, or the model has no heat\-loss element\.

<a name='DiGi.Analytical.Building.Energy.Query'></a>

## Query Class

```csharp
public static class Query
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Query
### Methods

<a name='DiGi.Analytical.Building.Energy.Query.Area(thisDiGi.Analytical.Building.Interfaces.IComponent)'></a>

## Query\.Area\(this IComponent\) Method

Gets the gross area of a component's face, openings included \(DiGi\-Organization/DiGi\.Analytical\#21\)\.

```csharp
public static double Area(this DiGi.Analytical.Building.Interfaces.IComponent? component);
```
#### Parameters

<a name='DiGi.Analytical.Building.Energy.Query.Area(thisDiGi.Analytical.Building.Interfaces.IComponent).component'></a>

`component` [DiGi\.Analytical\.Building\.Interfaces\.IComponent](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.icomponent 'DiGi\.Analytical\.Building\.Interfaces\.IComponent')

The component\. This value can be null\.

#### Returns
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')  
The area \[m2\], or [System\.Double\.NaN](https://learn.microsoft.com/en-us/dotnet/api/system.double.nan 'System\.Double\.NaN') when the component is null or its geometry is not a face\.

<a name='DiGi.Analytical.Building.Energy.Query.Area(thisDiGi.Analytical.Building.Interfaces.IOpening,DiGi.Analytical.Building.Interfaces.IOpeningConstruction)'></a>

## Query\.Area\(this IOpening, IOpeningConstruction\) Method

Gets the area of the whole outline of an opening, frame and glazing together \(DiGi\-Organization/DiGi\.Analytical\#21\)\.

```csharp
public static double Area(this DiGi.Analytical.Building.Interfaces.IOpening? opening, DiGi.Analytical.Building.Interfaces.IOpeningConstruction? openingConstruction);
```
#### Parameters

<a name='DiGi.Analytical.Building.Energy.Query.Area(thisDiGi.Analytical.Building.Interfaces.IOpening,DiGi.Analytical.Building.Interfaces.IOpeningConstruction).opening'></a>

`opening` [DiGi\.Analytical\.Building\.Interfaces\.IOpening](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.iopening 'DiGi\.Analytical\.Building\.Interfaces\.IOpening')

The opening\. This value can be null\.

<a name='DiGi.Analytical.Building.Energy.Query.Area(thisDiGi.Analytical.Building.Interfaces.IOpening,DiGi.Analytical.Building.Interfaces.IOpeningConstruction).openingConstruction'></a>

`openingConstruction` [DiGi\.Analytical\.Building\.Interfaces\.IOpeningConstruction](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.iopeningconstruction 'DiGi\.Analytical\.Building\.Interfaces\.IOpeningConstruction')

The construction giving the opening its outline\. This value can be null\.

#### Returns
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')  
The area \[m2\], or [System\.Double\.NaN](https://learn.microsoft.com/en-us/dotnet/api/system.double.nan 'System\.Double\.NaN') when either argument is null or the outline cannot be placed\.

<a name='DiGi.Analytical.Building.Energy.Query.DesignHeatLoad(double,double,double,double,double,double)'></a>

## Query\.DesignHeatLoad\(double, double, double, double, double, double\) Method

Gets the design heat load Φ\_HL of a building calculated as one heated zone, PN\-EN 12831\-1 simplified \(DiGi\-Organization/DiGi\.Analytical\#21\), [DesignHeatLoad](DiGi.Analytical.Building.Energy.Constants.md#DiGi.Analytical.Building.Energy.Constants.Source.DesignHeatLoad 'DiGi\.Analytical\.Building\.Energy\.Constants\.Source\.DesignHeatLoad')\.

Φ_HL = (H_T + f_g1·f_g2·H_g + H_ve)·(θ_int − θ_e), with f_g1 = [GroundTemperatureVariationFactor](DiGi.Analytical.Building.Energy.Constants.md#DiGi.Analytical.Building.Energy.Constants.Default.GroundTemperatureVariationFactor 'DiGi\.Analytical\.Building\.Energy\.Constants\.Default\.GroundTemperatureVariationFactor') and f_g2 = (θ_int − θ_m,e) / (θ_int − θ_e). The ground loss is counted only when the mean annual temperature is known.

```csharp
public static double DesignHeatLoad(double transmissionHeatTransferCoefficient, double groundHeatTransferCoefficient, double ventilationHeatTransferCoefficient, double internalTemperature, double designExternalTemperature, double annualMeanExternalTemperature);
```
#### Parameters

<a name='DiGi.Analytical.Building.Energy.Query.DesignHeatLoad(double,double,double,double,double,double).transmissionHeatTransferCoefficient'></a>

`transmissionHeatTransferCoefficient` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The transmission heat transfer coefficient to outside air and through unheated spaces, H\_T = H\_D \+ H\_tb \+ H\_U \[W/K\]\.

<a name='DiGi.Analytical.Building.Energy.Query.DesignHeatLoad(double,double,double,double,double,double).groundHeatTransferCoefficient'></a>

`groundHeatTransferCoefficient` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The heat transfer coefficient through the ground H\_g \[W/K\]\.

<a name='DiGi.Analytical.Building.Energy.Query.DesignHeatLoad(double,double,double,double,double,double).ventilationHeatTransferCoefficient'></a>

`ventilationHeatTransferCoefficient` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The ventilation heat transfer coefficient H\_ve \[W/K\]\.

<a name='DiGi.Analytical.Building.Energy.Query.DesignHeatLoad(double,double,double,double,double,double).internalTemperature'></a>

`internalTemperature` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The internal design temperature θ\_int \[°C\]\.

<a name='DiGi.Analytical.Building.Energy.Query.DesignHeatLoad(double,double,double,double,double,double).designExternalTemperature'></a>

`designExternalTemperature` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The design external temperature θ\_e \[°C\]\.

<a name='DiGi.Analytical.Building.Energy.Query.DesignHeatLoad(double,double,double,double,double,double).annualMeanExternalTemperature'></a>

`annualMeanExternalTemperature` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The mean annual external temperature θ\_m,e \[°C\]\.

#### Returns
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')  
The design heat load \[W\], or [System\.Double\.NaN](https://learn.microsoft.com/en-us/dotnet/api/system.double.nan 'System\.Double\.NaN') when a coefficient or a temperature it needs is NaN, or θ\_int is not above θ\_e\.

<a name='DiGi.Analytical.Building.Energy.Query.ExposedPerimeter(thisDiGi.Analytical.Building.Classes.BuildingModel,double)'></a>

## Query\.ExposedPerimeter\(this BuildingModel, double\) Method

Gets the exposed perimeter P of the ground floor of a building model, the perimeter of PN\-EN ISO 13370 \(DiGi\-Organization/DiGi\.Analytical\#21\), [Ground](DiGi.Analytical.Building.Energy.Constants.md#DiGi.Analytical.Building.Energy.Constants.Source.Ground 'DiGi\.Analytical\.Building\.Energy\.Constants\.Source\.Ground')\.

The perimeter of the model's footprint ([DiGi\.Analytical\.Building\.Query\.Footprints\(DiGi\.Analytical\.Building\.Classes\.BuildingModel,System\.Double\)](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.query.footprints#digi-analytical-building-query-footprints(digi-analytical-building-classes-buildingmodel-system-double) 'DiGi\.Analytical\.Building\.Query\.Footprints\(DiGi\.Analytical\.Building\.Classes\.BuildingModel,System\.Double\)'), courtyard edges included) less the base length of every party wall ([DiGi\.Analytical\.Building\.Enums\.ComponentParameter\.PartyWall](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.enums.componentparameter.partywall 'DiGi\.Analytical\.Building\.Enums\.ComponentParameter\.PartyWall')) standing at the lowest level of the model: an edge along a heated neighbour loses no heat through the ground. The base length of a party wall is the horizontal extent of its face, which is vertical.

```csharp
public static double ExposedPerimeter(this DiGi.Analytical.Building.Classes.BuildingModel? buildingModel, double tolerance=1E-06);
```
#### Parameters

<a name='DiGi.Analytical.Building.Energy.Query.ExposedPerimeter(thisDiGi.Analytical.Building.Classes.BuildingModel,double).buildingModel'></a>

`buildingModel` [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')

The building model\. This value can be null\.

<a name='DiGi.Analytical.Building.Energy.Query.ExposedPerimeter(thisDiGi.Analytical.Building.Classes.BuildingModel,double).tolerance'></a>

`tolerance` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The distance tolerance of the footprint\.

#### Returns
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')  
The exposed perimeter \[m\], never below 0, or [System\.Double\.NaN](https://learn.microsoft.com/en-us/dotnet/api/system.double.nan 'System\.Double\.NaN') when the model is null or has no footprint\.

<a name='DiGi.Analytical.Building.Energy.Query.FloorArea(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace)'></a>

## Query\.FloorArea\(this BuildingModel, ISpace\) Method

Gets the gross floor area of a space: the area of the floors bounding it at its lowest level \(DiGi\-Organization/DiGi\.Analytical\#21\)\.

A space is bounded by its own floor and by the floor of the space above, its ceiling, so only the floors whose geometry reaches within [LevelTolerance](DiGi.Analytical.Building.Energy.Constants.md#DiGi.Analytical.Building.Energy.Constants.Default.LevelTolerance 'DiGi\.Analytical\.Building\.Energy\.Constants\.Default\.LevelTolerance') of the lowest of them count.

```csharp
public static double FloorArea(this DiGi.Analytical.Building.Classes.BuildingModel? buildingModel, DiGi.Analytical.Building.Interfaces.ISpace? space);
```
#### Parameters

<a name='DiGi.Analytical.Building.Energy.Query.FloorArea(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace).buildingModel'></a>

`buildingModel` [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')

The building model holding the space\. This value can be null\.

<a name='DiGi.Analytical.Building.Energy.Query.FloorArea(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace).space'></a>

`space` [DiGi\.Analytical\.Building\.Interfaces\.ISpace](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.ispace 'DiGi\.Analytical\.Building\.Interfaces\.ISpace')

The space\. This value can be null\.

#### Returns
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')  
The floor area \[m2\]; 0 when the space has no floor, or [System\.Double\.NaN](https://learn.microsoft.com/en-us/dotnet/api/system.double.nan 'System\.Double\.NaN') when either argument is null\.

<a name='DiGi.Analytical.Building.Energy.Query.GroundThermalTransmittance(double,double,double,double,double)'></a>

## Query\.GroundThermalTransmittance\(double, double, double, double, double\) Method

Gets the thermal transmittance U of a slab\-on\-ground floor including the ground, in the steady state \(DiGi\-Organization/DiGi\.Analytical\#21\), [Ground](DiGi.Analytical.Building.Energy.Constants.md#DiGi.Analytical.Building.Energy.Constants.Source.Ground 'DiGi\.Analytical\.Building\.Energy\.Constants\.Source\.Ground')\.

The characteristic dimension is B′ = A / (0.5·P) and the equivalent thickness d_t = w + λ_g·(R_si + R_f + R_se), with R_si = 0.17 (downward heat flow) and R_se = 0.04 m2K/W. For d_t < B′ (an uninsulated or moderately insulated floor) U = 2·λ_g / (π·B′ + d_t)·ln(π·B′ / d_t + 1); otherwise (a well insulated floor) U = λ_g / (0.457·B′ + d_t).

An exposed perimeter of 0 - a floor every edge of which borders a heated neighbour - gives an infinite B′ and so U = 0, the limit of both forms.

```csharp
public static double GroundThermalTransmittance(double area, double exposedPerimeter, double wallThickness, double floorThermalResistance, double groundThermalConductivity=2.0);
```
#### Parameters

<a name='DiGi.Analytical.Building.Energy.Query.GroundThermalTransmittance(double,double,double,double,double).area'></a>

`area` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The area of the floor on the ground A \[m2\]\.

<a name='DiGi.Analytical.Building.Energy.Query.GroundThermalTransmittance(double,double,double,double,double).exposedPerimeter'></a>

`exposedPerimeter` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The exposed perimeter P of the floor, without the edges along heated neighbours \[m\]\.

<a name='DiGi.Analytical.Building.Energy.Query.GroundThermalTransmittance(double,double,double,double,double).wallThickness'></a>

`wallThickness` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The thickness of the external walls at the floor's edge w \[m\]\.

<a name='DiGi.Analytical.Building.Energy.Query.GroundThermalTransmittance(double,double,double,double,double).floorThermalResistance'></a>

`floorThermalResistance` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The thermal resistance of the floor construction R\_f, its layers without the surface resistances \[m2K/W\]\.

<a name='DiGi.Analytical.Building.Energy.Query.GroundThermalTransmittance(double,double,double,double,double).groundThermalConductivity'></a>

`groundThermalConductivity` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The thermal conductivity of the ground λ\_g \[W/\(mK\)\]\.

#### Returns
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')  
The thermal transmittance \[W/\(m2K\)\], or [System\.Double\.NaN](https://learn.microsoft.com/en-us/dotnet/api/system.double.nan 'System\.Double\.NaN') when an input is NaN, the area is not positive, the perimeter or a resistance is negative or the conductivity is not positive\.

<a name='DiGi.Analytical.Building.Energy.Query.HeatedVolume(thisDiGi.Analytical.Building.Classes.BuildingModel,double)'></a>

## Query\.HeatedVolume\(this BuildingModel, double\) Method

Gets the volume enclosed by the external shell of a building model, the volume V of its single heated zone \(DiGi\-Organization/DiGi\.Analytical\#21\)\.

The faces of [DiGi\.Analytical\.Building\.Classes\.BuildingModel\.GetExternalShell\(System\.Nullable\{DiGi\.Geometry\.Core\.Enums\.Side\},System\.Nullable\{DiGi\.Geometry\.Core\.Enums\.Orientation\},System\.Nullable\{DiGi\.Geometry\.Core\.Enums\.Orientation\},System\.Double\)](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel.getexternalshell#digi-analytical-building-classes-buildingmodel-getexternalshell(system-nullable{digi-geometry-core-enums-side}-system-nullable{digi-geometry-core-enums-orientation}-system-nullable{digi-geometry-core-enums-orientation}-system-double) 'DiGi\.Analytical\.Building\.Classes\.BuildingModel\.GetExternalShell\(System\.Nullable\{DiGi\.Geometry\.Core\.Enums\.Side\},System\.Nullable\{DiGi\.Geometry\.Core\.Enums\.Orientation\},System\.Nullable\{DiGi\.Geometry\.Core\.Enums\.Orientation\},System\.Double\)') with outward normals give V = Σ A_f·(n_f · (p_f − c)) / 3 by the divergence theorem, exact for planar faces; c is the centre of the shell's bounding box. A reference point inside the shell keeps the large map coordinates of a GIS model from costing anything and limits what a residual can cost to the shell's own extent (DiGi-Organization/DiGi.Analytical#22), where c used to be the plane origin of the first face - (0, 0, elevation) for a footprint extruded by `Create.Plane(z)`, about 800 km from the building, which levered the residual of a slightly open shell into a volume a hundredfold too large.

The theorem holds only for a closed shell. A closed shell's area-weighted normals sum to zero, so a shell whose |Σ A_f·n_f| exceeds 1 % of its area is open and the volume is not known; a shell inside that screen is still rejected when its residual could move the result by more than 1 % of it, |Σ A_f·n_f| times half the bounding-box diagonal over 3 (DiGi-Organization/DiGi.Analytical#22). One GIS model in six has an open shell (a storey split leaving a T-junction, adjacent CityGML parts); the caller then falls back to a volume of its own and records it.

```csharp
public static double HeatedVolume(this DiGi.Analytical.Building.Classes.BuildingModel? buildingModel, double tolerance=1E-06);
```
#### Parameters

<a name='DiGi.Analytical.Building.Energy.Query.HeatedVolume(thisDiGi.Analytical.Building.Classes.BuildingModel,double).buildingModel'></a>

`buildingModel` [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')

The building model\. This value can be null\.

<a name='DiGi.Analytical.Building.Energy.Query.HeatedVolume(thisDiGi.Analytical.Building.Classes.BuildingModel,double).tolerance'></a>

`tolerance` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The distance tolerance of the external shell\.

#### Returns
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')  
The volume \[m3\], or [System\.Double\.NaN](https://learn.microsoft.com/en-us/dotnet/api/system.double.nan 'System\.Double\.NaN') when the model is null, has no shell or the shell is open or encloses no volume\.

<a name='DiGi.Analytical.Building.Energy.Query.InternalHeatCapacity(thisDiGi.Analytical.Building.Classes.BuildingModel,double,double)'></a>

## Query\.InternalHeatCapacity\(this BuildingModel, double, double\) Method

Gets the internal heat capacity C\_m = Σ κ\_j·A\_j of a building model calculated as one heated zone \(DiGi\-Organization/DiGi\.Analytical\#21\), [InternalHeatCapacity](DiGi.Analytical.Building.Energy.Constants.md#DiGi.Analytical.Building.Energy.Constants.Source.InternalHeatCapacity 'DiGi\.Analytical\.Building\.Energy\.Constants\.Source\.InternalHeatCapacity')\.

Every wall, roof and floor with a layered construction counts each of its faces that is in contact with the zone's air: a component bounding one space (the envelope, party walls included) with its inner face - the last layer, as layers are ordered from the outside inwards - and a component bounding two spaces (internal walls, intermediate floors) with both faces. A component bounding no space is not counted. κ is [DiGi\.Analytical\.Building\.Energy\.Query\.ArealHeatCapacity\(System\.Collections\.Generic\.IEnumerable\{System\.ValueTuple\{DiGi\.Analytical\.Building\.Interfaces\.IStructureLayer,DiGi\.Analytical\.Interfaces\.IMaterial\}\},System\.Double,System\.Double\)](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.energy.query.arealheatcapacity#digi-analytical-building-energy-query-arealheatcapacity(system-collections-generic-ienumerable{system-valuetuple{digi-analytical-building-interfaces-istructurelayer-digi-analytical-interfaces-imaterial}}-system-double-system-double) 'DiGi\.Analytical\.Building\.Energy\.Query\.ArealHeatCapacity\(System\.Collections\.Generic\.IEnumerable\{System\.ValueTuple\{DiGi\.Analytical\.Building\.Interfaces\.IStructureLayer,DiGi\.Analytical\.Interfaces\.IMaterial\}\},System\.Double,System\.Double\)') of each face; the area of a component is its face less the outlines of the openings it hosts. Openings themselves are not counted.

```csharp
public static double InternalHeatCapacity(this DiGi.Analytical.Building.Classes.BuildingModel? buildingModel, double maximumThickness=0.1, double insulationThermalConductivity=0.1);
```
#### Parameters

<a name='DiGi.Analytical.Building.Energy.Query.InternalHeatCapacity(thisDiGi.Analytical.Building.Classes.BuildingModel,double,double).buildingModel'></a>

`buildingModel` [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')

The building model\. This value can be null\.

<a name='DiGi.Analytical.Building.Energy.Query.InternalHeatCapacity(thisDiGi.Analytical.Building.Classes.BuildingModel,double,double).maximumThickness'></a>

`maximumThickness` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The maximum effective thickness, from each face \[m\]\.

<a name='DiGi.Analytical.Building.Energy.Query.InternalHeatCapacity(thisDiGi.Analytical.Building.Classes.BuildingModel,double,double).insulationThermalConductivity'></a>

`insulationThermalConductivity` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The thermal conductivity \[W/\(mK\)\] at or below which a layer ends the effective thickness\.

#### Returns
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')  
The internal heat capacity \[J/K\]; 0 when no component has layers, or [System\.Double\.NaN](https://learn.microsoft.com/en-us/dotnet/api/system.double.nan 'System\.Double\.NaN') when the model is null\.

<a name='DiGi.Analytical.Building.Energy.Query.MonthDuration(int)'></a>

## Query\.MonthDuration\(int\) Method

Gets the duration t\_m of a month of a non\-leap year, the length of the monthly balance \(DiGi\-Organization/DiGi\.Analytical\#21\)\. The weather years of the solar results are mapped onto a non\-leap year as well \(8 760 hours\)\.

```csharp
public static double MonthDuration(int month);
```
#### Parameters

<a name='DiGi.Analytical.Building.Energy.Query.MonthDuration(int).month'></a>

`month` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The month, 1 \(January\) to 12 \(December\)\.

#### Returns
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')  
The duration \[h\], or [System\.Double\.NaN](https://learn.microsoft.com/en-us/dotnet/api/system.double.nan 'System\.Double\.NaN') for a month outside 1\-12\.

<a name='DiGi.Analytical.Building.Energy.Query.ReferenceFloorArea(thisDiGi.Analytical.Building.Classes.BuildingModel)'></a>

## Query\.ReferenceFloorArea\(this BuildingModel\) Method

Gets the reference floor area A\_ref of a building model calculated as one heated zone: the sum of the gross floor areas of all its spaces \([FloorArea\(this BuildingModel, ISpace\)](DiGi.Analytical.Building.Energy.md#DiGi.Analytical.Building.Energy.Query.FloorArea(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Interfaces.ISpace) 'DiGi\.Analytical\.Building\.Energy\.Query\.FloorArea\(this DiGi\.Analytical\.Building\.Classes\.BuildingModel, DiGi\.Analytical\.Building\.Interfaces\.ISpace\)')\), matching `building_data.TotalArea` \(DiGi\-Organization/DiGi\.Analytical\#21\)\.

```csharp
public static double ReferenceFloorArea(this DiGi.Analytical.Building.Classes.BuildingModel? buildingModel);
```
#### Parameters

<a name='DiGi.Analytical.Building.Energy.Query.ReferenceFloorArea(thisDiGi.Analytical.Building.Classes.BuildingModel).buildingModel'></a>

`buildingModel` [DiGi\.Analytical\.Building\.Classes\.BuildingModel](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.buildingmodel 'DiGi\.Analytical\.Building\.Classes\.BuildingModel')

The building model\. This value can be null\.

#### Returns
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')  
The reference floor area \[m2\]; 0 when the model has no space, or [System\.Double\.NaN](https://learn.microsoft.com/en-us/dotnet/api/system.double.nan 'System\.Double\.NaN') when it is null\.

<a name='DiGi.Analytical.Building.Energy.Query.UtilisationFactor(double,double)'></a>

## Query\.UtilisationFactor\(double, double\) Method

Gets the dimensionless gain utilisation factor for heating η\_H,gn of the monthly method \(DiGi\-Organization/DiGi\.Analytical\#21\), [GainUtilisation](DiGi.Analytical.Building.Energy.Constants.md#DiGi.Analytical.Building.Energy.Constants.Source.GainUtilisation 'DiGi\.Analytical\.Building\.Energy\.Constants\.Source\.GainUtilisation')\.

η = (1 − γ^a) / (1 − γ^(a+1)) for γ ≠ 1, η = a / (a + 1) for γ = 1 and η = 1 / γ for γ < 0 (Equations (53) to (55)). γ is within [DiGi\.Core\.Constants\.Tolerance\.MicroDistance](https://learn.microsoft.com/en-us/dotnet/api/digi.core.constants.tolerance.microdistance 'DiGi\.Core\.Constants\.Tolerance\.MicroDistance') of 1 when the first form loses precision, so the limit is taken there.

```csharp
public static double UtilisationFactor(double gainLossRatio, double a);
```
#### Parameters

<a name='DiGi.Analytical.Building.Energy.Query.UtilisationFactor(double,double).gainLossRatio'></a>

`gainLossRatio` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The heat balance ratio for heating γ\_H = Q\_H,gn / Q\_H,ht \[\-\]\.

<a name='DiGi.Analytical.Building.Energy.Query.UtilisationFactor(double,double).a'></a>

`a` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The numerical parameter a\_H = a\_H,0 \+ τ / τ\_H,0 \[\-\]\.

#### Returns
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')  
The gain utilisation factor \[\-\], or [System\.Double\.NaN](https://learn.microsoft.com/en-us/dotnet/api/system.double.nan 'System\.Double\.NaN') when either value is NaN or [a](DiGi.Analytical.Building.Energy.md#DiGi.Analytical.Building.Energy.Query.UtilisationFactor(double,double).a 'DiGi\.Analytical\.Building\.Energy\.Query\.UtilisationFactor\(double, double\)\.a') is not positive\.