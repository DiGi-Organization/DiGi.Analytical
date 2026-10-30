#### [DiGi\.Analytical\.Building](DiGi.Analytical.Building.Overview.md 'DiGi\.Analytical\.Building\.Overview')

## DiGi\.Analytical\.Building\.Enums Namespace
### Enums

<a name='DiGi.Analytical.Building.Enums.BuildingModelDetailLevel'></a>

## BuildingModelDetailLevel Enum

```csharp
public enum BuildingModelDetailLevel
```
### Fields

<a name='DiGi.Analytical.Building.Enums.BuildingModelDetailLevel.Component'></a>

`Component` 0

Each component \(wall, roof, floor, window\) becomes a separate selectable node\.

<a name='DiGi.Analytical.Building.Enums.BuildingModelDetailLevel.Envelope'></a>

`Envelope` 1

All components are merged into a single node per building, making the building selectable as a whole\.

<a name='DiGi.Analytical.Building.Enums.HeatFlowDirection'></a>

## HeatFlowDirection Enum

Specifies the direction of the heat flow through a construction, which decides its surface and air\-layer resistances \(PN\-EN ISO 6946; DiGi\-Organization/DiGi\.Analytical\#8\)\.

A heat flow within ±30° of the horizontal plane is horizontal. Where the direction is not fixed or a value independent of it is required, the standard recommends the horizontal values.

```csharp
public enum HeatFlowDirection
```
### Fields

<a name='DiGi.Analytical.Building.Enums.HeatFlowDirection.Undefined'></a>

`Undefined` 0

The direction is not known; surface and air\-layer resistances are not available\.

<a name='DiGi.Analytical.Building.Enums.HeatFlowDirection.Upward'></a>

`Upward` 1

Upward heat flow \- a roof or a ceiling heated from below\.

<a name='DiGi.Analytical.Building.Enums.HeatFlowDirection.Horizontal'></a>

`Horizontal` 2

Horizontal heat flow \- a wall\.

<a name='DiGi.Analytical.Building.Enums.HeatFlowDirection.Downward'></a>

`Downward` 3

Downward heat flow \- a floor over an unheated or outside space\.

<a name='DiGi.Analytical.Building.Enums.OpeningConstructionParameter'></a>

## OpeningConstructionParameter Enum

Defines the declared thermal and solar values of an opening construction \(DiGi\-Organization/DiGi\.Analytical\#8\)\.

Historical windows and doors are known by their declared values rather than by a layer build-up. The frame and glazing areas and the glazing perimeter are not declared: they come from the construction's outline, a face whose holes are the glazing and whose remainder is the frame.

```csharp
public enum OpeningConstructionParameter
```
### Fields

<a name='DiGi.Analytical.Building.Enums.OpeningConstructionParameter.ThermalTransmittance'></a>

`ThermalTransmittance` 0

The declared thermal transmittance of the whole window or door, Uw \[W/\(m2K\)\]\.

<a name='DiGi.Analytical.Building.Enums.OpeningConstructionParameter.GlazingThermalTransmittance'></a>

`GlazingThermalTransmittance` 1

The thermal transmittance of the glazing in its centre, Ug \[W/\(m2K\)\]\.

<a name='DiGi.Analytical.Building.Enums.OpeningConstructionParameter.FrameThermalTransmittance'></a>

`FrameThermalTransmittance` 2

The thermal transmittance of the frame, Uf \[W/\(m2K\)\]\.

<a name='DiGi.Analytical.Building.Enums.OpeningConstructionParameter.GlazingLinearThermalTransmittance'></a>

`GlazingLinearThermalTransmittance` 3

The linear thermal transmittance of the junction between glazing and frame \(spacer\), Ψg \[W/\(mK\)\]\.

<a name='DiGi.Analytical.Building.Enums.OpeningConstructionParameter.TotalSolarEnergyTransmittance'></a>

`TotalSolarEnergyTransmittance` 4

The total solar energy transmittance of the glazing at normal incidence, g \[\-\]\.

<a name='DiGi.Analytical.Building.Enums.OpeningConstructionParameter.LightTransmittance'></a>

`LightTransmittance` 5

The light \(visible\) transmittance of the glazing at normal incidence, τv \[\-\] \- with Uw and g, the third value a glazing is declared by \(EnergyPlus WindowMaterial:SimpleGlazingSystem: U\-factor, SHGC, visible transmittance\)\.

<a name='DiGi.Analytical.Building.Enums.OpeningConstructionPart'></a>

## OpeningConstructionPart Enum

Specifies the various components that constitute an opening construction, such as panes and frames\.

```csharp
public enum OpeningConstructionPart
```
### Fields

<a name='DiGi.Analytical.Building.Enums.OpeningConstructionPart.Undefined'></a>

`Undefined` 0

The opening construction part is undefined\.

<a name='DiGi.Analytical.Building.Enums.OpeningConstructionPart.Pane'></a>

`Pane` 1

Represents the pane part of an opening construction\.

<a name='DiGi.Analytical.Building.Enums.OpeningConstructionPart.Frame'></a>

`Frame` 2

Represents the frame part of the opening construction\.

<a name='DiGi.Analytical.Building.Enums.PhysicalComponentConstructionParameter'></a>

## PhysicalComponentConstructionParameter Enum

Defines the declared values of a wall, roof or floor construction \(DiGi\-Organization/DiGi\.Analytical\#8\)\.

```csharp
public enum PhysicalComponentConstructionParameter
```
### Fields

<a name='DiGi.Analytical.Building.Enums.PhysicalComponentConstructionParameter.ThermalTransmittance'></a>

`ThermalTransmittance` 0

The declared thermal transmittance U \[W/\(m2K\)\], for a construction known by its U rather than by its layers \- a floor on ground, or a historical assembly\. When set it takes precedence over the value computed from the layers\.

<a name='DiGi.Analytical.Building.Enums.PhysicalComponentType'></a>

## PhysicalComponentType Enum

Specifies the kind of physical building component an element represents or is to be converted into\.

The value drives the class created by [ConvertAir\(IAir, PhysicalComponentType, IPhysicalComponent\)](DiGi.Analytical.Building.Classes.md#DiGi.Analytical.Building.Classes.BuildingModel.ConvertAir(DiGi.Analytical.Building.Interfaces.IAir,DiGi.Analytical.Building.Enums.PhysicalComponentType,DiGi.Analytical.Building.Interfaces.IPhysicalComponent) 'DiGi\.Analytical\.Building\.Classes\.BuildingModel\.ConvertAir\(DiGi\.Analytical\.Building\.Interfaces\.IAir, DiGi\.Analytical\.Building\.Enums\.PhysicalComponentType, DiGi\.Analytical\.Building\.Interfaces\.IPhysicalComponent\)').

```csharp
public enum PhysicalComponentType
```
### Fields

<a name='DiGi.Analytical.Building.Enums.PhysicalComponentType.Undefined'></a>

`Undefined` 0

The physical component type could not be determined\. No conversion is performed for this value\.

<a name='DiGi.Analytical.Building.Enums.PhysicalComponentType.Wall'></a>

`Wall` 1

A vertical component, i\.e\. one whose normal is roughly perpendicular to the world Z axis\. Converts into a [SurfaceWall](DiGi.Analytical.Building.Classes.md#DiGi.Analytical.Building.Classes.SurfaceWall 'DiGi\.Analytical\.Building\.Classes\.SurfaceWall')\.

<a name='DiGi.Analytical.Building.Enums.PhysicalComponentType.Roof'></a>

`Roof` 2

A horizontal component facing upwards\. Converts into a [SurfaceRoof](DiGi.Analytical.Building.Classes.md#DiGi.Analytical.Building.Classes.SurfaceRoof 'DiGi\.Analytical\.Building\.Classes\.SurfaceRoof')\.

<a name='DiGi.Analytical.Building.Enums.PhysicalComponentType.Floor'></a>

`Floor` 3

A horizontal component facing downwards\. Converts into a [FaceFloor](DiGi.Analytical.Building.Classes.md#DiGi.Analytical.Building.Classes.FaceFloor 'DiGi\.Analytical\.Building\.Classes\.FaceFloor')\.

<a name='DiGi.Analytical.Building.Enums.SpaceParameter'></a>

## SpaceParameter Enum

Defines the set of parameters associated with a space in the analytical building model\.

```csharp
public enum SpaceParameter
```
### Fields

<a name='DiGi.Analytical.Building.Enums.SpaceParameter.CalculatedArea'></a>

`CalculatedArea` 0

Represents the calculated area of the space in square meters \(m2\)\.

<a name='DiGi.Analytical.Building.Enums.SpaceParameter.CalculatedVolume'></a>

`CalculatedVolume` 1

Represents the calculated volume of a space, typically measured in cubic meters \(m3\)\.

<a name='DiGi.Analytical.Building.Enums.StructurePosition'></a>

## StructurePosition Enum

Specifies the relative position of a structural element within a building\.

```csharp
public enum StructurePosition
```
### Fields

<a name='DiGi.Analytical.Building.Enums.StructurePosition.Undefined'></a>

`Undefined` 0

Undefined

<a name='DiGi.Analytical.Building.Enums.StructurePosition.Center'></a>

`Center` 1

Indicates that the structure position is at the center\.

<a name='DiGi.Analytical.Building.Enums.StructurePosition.External'></a>

`External` 2

Represents the external structure position\.

<a name='DiGi.Analytical.Building.Enums.StructurePosition.Internal'></a>

`Internal` 3

Represents the internal structure position\.