#### [DiGi\.Analytical\.Building\.Energy](DiGi.Analytical.Building.Energy.Overview.md 'DiGi\.Analytical\.Building\.Energy\.Overview')

## DiGi\.Analytical\.Building\.Energy\.Enums Namespace
### Enums

<a name='DiGi.Analytical.Building.Energy.Enums.HeatDemandMethod'></a>

## HeatDemandMethod Enum

Specifies the method a heat demand was calculated by \(DiGi\-Organization/DiGi\.Analytical\#23, Heat Demand Method Identity DiGi\-Organization/DiGi\.GIS\.Analytical\#19\)\.

A result is identified by its method and its [MethodVersion](DiGi.Analytical.Building.Energy.Classes.md#DiGi.Analytical.Building.Energy.Classes.HeatDemandResult.MethodVersion 'DiGi\.Analytical\.Building\.Energy\.Classes\.HeatDemandResult\.MethodVersion'), the revision within that method; results of different methods are stored side by side and compared, never mixed. The integer values are stored and sent as integers and never change; a new engine - the hourly method of PN-EN ISO 52016-1, EnergyPlus, a calibrated method - is a new member with its own version 1.

```csharp
public enum HeatDemandMethod
```
### Fields

<a name='DiGi.Analytical.Building.Energy.Enums.HeatDemandMethod.Undefined'></a>

`Undefined` 0

The method is not known; never stored\.

<a name='DiGi.Analytical.Building.Energy.Enums.HeatDemandMethod.Monthly'></a>

`Monthly` 1

The PN\-EN ISO 52016\-1 monthly quasi\-steady method of `Create.HeatDemandResult`, one continuously heated zone \([Method](DiGi.Analytical.Building.Energy.Constants.md#DiGi.Analytical.Building.Energy.Constants.Source.Method 'DiGi\.Analytical\.Building\.Energy\.Constants\.Source\.Method')\); its revision is [HeatDemandMethodVersion](DiGi.Analytical.Building.Energy.Constants.md#DiGi.Analytical.Building.Energy.Constants.Default.HeatDemandMethodVersion 'DiGi\.Analytical\.Building\.Energy\.Constants\.Default\.HeatDemandMethodVersion')\.