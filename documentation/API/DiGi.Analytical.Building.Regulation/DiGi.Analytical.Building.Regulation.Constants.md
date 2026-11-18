#### [DiGi\.Analytical\.Building\.Regulation](DiGi.Analytical.Building.Regulation.Overview.md 'DiGi\.Analytical\.Building\.Regulation\.Overview')

## DiGi\.Analytical\.Building\.Regulation\.Constants Namespace
### Classes

<a name='DiGi.Analytical.Building.Regulation.Constants.Default'></a>

## Default Class

Defaults of the construction\-role rules of the regulation library\.

```csharp
public static class Default
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Default
### Fields

<a name='DiGi.Analytical.Building.Regulation.Constants.Default.FlatRoofTilt'></a>

## Default\.FlatRoofTilt Field

The tilt, in degrees, of a roof's external\-shell face against the world up axis below which the roof takes [FlatRoof](DiGi.Analytical.Building.Regulation.Enums.md#DiGi.Analytical.Building.Regulation.Enums.ConstructionRole.FlatRoof 'DiGi\.Analytical\.Building\.Regulation\.Enums\.ConstructionRole\.FlatRoof') \([ConstructionRoles\(this BuildingModel, FloorBoundary, double\)](DiGi.Analytical.Building.Regulation.md#DiGi.Analytical.Building.Regulation.Query.ConstructionRoles(thisDiGi.Analytical.Building.Classes.BuildingModel,DiGi.Analytical.Building.Regulation.Enums.FloorBoundary,double) 'DiGi\.Analytical\.Building\.Regulation\.Query\.ConstructionRoles\(this DiGi\.Analytical\.Building\.Classes\.BuildingModel, DiGi\.Analytical\.Building\.Regulation\.Enums\.FloorBoundary, double\)')\): 5°, the flat threshold of `DiGi.GIS.PostgreSQL.Modify.Update_ExternalComponentsArea`\.

```csharp
public const double FlatRoofTilt = 5;
```

#### Field Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')