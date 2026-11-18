#### [DiGi\.Analytical\.Building\.Energy](DiGi.Analytical.Building.Energy.Overview.md 'DiGi\.Analytical\.Building\.Energy\.Overview')

## DiGi\.Analytical\.Building\.Energy\.Interfaces Namespace
### Interfaces

<a name='DiGi.Analytical.Building.Energy.Interfaces.IEnergyObject'></a>

## IEnergyObject Interface

Base interface for the objects of the building energy calculation: the monthly heat demand of PN\-EN ISO 52016\-1 \(DiGi\-Organization/DiGi\.Analytical\#21\)\.

```csharp
public interface IEnergyObject : DiGi.Analytical.Building.Interfaces.IBuildingObject, DiGi.Analytical.Interfaces.IAnalyticalObject, DiGi.Core.Interfaces.IObject
```

Derived  
↳ [HeatDemandOptions](DiGi.Analytical.Building.Energy.Classes.md#DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions 'DiGi\.Analytical\.Building\.Energy\.Classes\.HeatDemandOptions')  
↳ [HeatDemandResult](DiGi.Analytical.Building.Energy.Classes.md#DiGi.Analytical.Building.Energy.Classes.HeatDemandResult 'DiGi\.Analytical\.Building\.Energy\.Classes\.HeatDemandResult')  
↳ [MonthlyClimate](DiGi.Analytical.Building.Energy.Classes.md#DiGi.Analytical.Building.Energy.Classes.MonthlyClimate 'DiGi\.Analytical\.Building\.Energy\.Classes\.MonthlyClimate')  
↳ [IEnergySerializableObject](DiGi.Analytical.Building.Energy.Interfaces.md#DiGi.Analytical.Building.Energy.Interfaces.IEnergySerializableObject 'DiGi\.Analytical\.Building\.Energy\.Interfaces\.IEnergySerializableObject')

Implements [DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.ibuildingobject 'DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject'), [DiGi\.Analytical\.Interfaces\.IAnalyticalObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.interfaces.ianalyticalobject 'DiGi\.Analytical\.Interfaces\.IAnalyticalObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject')

<a name='DiGi.Analytical.Building.Energy.Interfaces.IEnergySerializableObject'></a>

## IEnergySerializableObject Interface

Base interface for the serializable objects of the building energy calculation \(DiGi\-Organization/DiGi\.Analytical\#21\)\.

```csharp
public interface IEnergySerializableObject : DiGi.Analytical.Building.Energy.Interfaces.IEnergyObject, DiGi.Analytical.Building.Interfaces.IBuildingObject, DiGi.Analytical.Interfaces.IAnalyticalObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Derived  
↳ [HeatDemandOptions](DiGi.Analytical.Building.Energy.Classes.md#DiGi.Analytical.Building.Energy.Classes.HeatDemandOptions 'DiGi\.Analytical\.Building\.Energy\.Classes\.HeatDemandOptions')  
↳ [HeatDemandResult](DiGi.Analytical.Building.Energy.Classes.md#DiGi.Analytical.Building.Energy.Classes.HeatDemandResult 'DiGi\.Analytical\.Building\.Energy\.Classes\.HeatDemandResult')  
↳ [MonthlyClimate](DiGi.Analytical.Building.Energy.Classes.md#DiGi.Analytical.Building.Energy.Classes.MonthlyClimate 'DiGi\.Analytical\.Building\.Energy\.Classes\.MonthlyClimate')

Implements [IEnergyObject](DiGi.Analytical.Building.Energy.Interfaces.md#DiGi.Analytical.Building.Energy.Interfaces.IEnergyObject 'DiGi\.Analytical\.Building\.Energy\.Interfaces\.IEnergyObject'), [DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.ibuildingobject 'DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject'), [DiGi\.Analytical\.Interfaces\.IAnalyticalObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.interfaces.ianalyticalobject 'DiGi\.Analytical\.Interfaces\.IAnalyticalObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')