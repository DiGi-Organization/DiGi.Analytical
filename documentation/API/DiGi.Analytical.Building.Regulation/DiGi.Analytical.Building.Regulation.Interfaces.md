#### [DiGi\.Analytical\.Building\.Regulation](DiGi.Analytical.Building.Regulation.Overview.md 'DiGi\.Analytical\.Building\.Regulation\.Overview')

## DiGi\.Analytical\.Building\.Regulation\.Interfaces Namespace
### Interfaces

<a name='DiGi.Analytical.Building.Regulation.Interfaces.IRegulationObject'></a>

## IRegulationObject Interface

Base interface for the objects describing building regulations and the construction libraries keyed by them \(DiGi\-Organization/DiGi\.Analytical\#8\)\.

```csharp
public interface IRegulationObject : DiGi.Analytical.Building.Interfaces.IBuildingObject, DiGi.Analytical.Interfaces.IAnalyticalObject, DiGi.Core.Interfaces.IObject
```

Derived  
↳ [ConstructionLibrary](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionLibrary')  
↳ [ConstructionSet](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionSet 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionSet')  
↳ [IRegulationSerializableObject](DiGi.Analytical.Building.Regulation.Interfaces.md#DiGi.Analytical.Building.Regulation.Interfaces.IRegulationSerializableObject 'DiGi\.Analytical\.Building\.Regulation\.Interfaces\.IRegulationSerializableObject')

Implements [DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.ibuildingobject 'DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject'), [DiGi\.Analytical\.Interfaces\.IAnalyticalObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.interfaces.ianalyticalobject 'DiGi\.Analytical\.Interfaces\.IAnalyticalObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject')

<a name='DiGi.Analytical.Building.Regulation.Interfaces.IRegulationSerializableObject'></a>

## IRegulationSerializableObject Interface

Base interface for the serializable regulation objects \(DiGi\-Organization/DiGi\.Analytical\#8\)\.

```csharp
public interface IRegulationSerializableObject : DiGi.Analytical.Building.Regulation.Interfaces.IRegulationObject, DiGi.Analytical.Building.Interfaces.IBuildingObject, DiGi.Analytical.Interfaces.IAnalyticalObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
```

Derived  
↳ [ConstructionLibrary](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionLibrary 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionLibrary')  
↳ [ConstructionSet](DiGi.Analytical.Building.Regulation.Classes.md#DiGi.Analytical.Building.Regulation.Classes.ConstructionSet 'DiGi\.Analytical\.Building\.Regulation\.Classes\.ConstructionSet')

Implements [IRegulationObject](DiGi.Analytical.Building.Regulation.Interfaces.md#DiGi.Analytical.Building.Regulation.Interfaces.IRegulationObject 'DiGi\.Analytical\.Building\.Regulation\.Interfaces\.IRegulationObject'), [DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.ibuildingobject 'DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject'), [DiGi\.Analytical\.Interfaces\.IAnalyticalObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.interfaces.ianalyticalobject 'DiGi\.Analytical\.Interfaces\.IAnalyticalObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')