#### [DiGi\.Analytical\.Building\.HVAC](DiGi.Analytical.Building.HVAC.Overview.md 'DiGi\.Analytical\.Building\.HVAC\.Overview')

## DiGi\.Analytical\.Building\.HVAC\.Classes Namespace
### Classes

<a name='DiGi.Analytical.Building.HVAC.Classes.CoolingEmitter'></a>

## CoolingEmitter Class

Represents a cooling emitter component within the HVAC system used to remove heat from a space\.

```csharp
public class CoolingEmitter : DiGi.Analytical.Building.HVAC.Classes.Emitter
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Parameter\.Classes\.ParametrizedObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.parameter.classes.parametrizedobject 'DiGi\.Core\.Parameter\.Classes\.ParametrizedObject') → [Emitter](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.Emitter 'DiGi\.Analytical\.Building\.HVAC\.Classes\.Emitter') → CoolingEmitter
### Constructors

<a name='DiGi.Analytical.Building.HVAC.Classes.CoolingEmitter.CoolingEmitter()'></a>

## CoolingEmitter\(\) Constructor

Initializes a new instance of the [CoolingEmitter](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.CoolingEmitter 'DiGi\.Analytical\.Building\.HVAC\.Classes\.CoolingEmitter') class\.

```csharp
public CoolingEmitter();
```

<a name='DiGi.Analytical.Building.HVAC.Classes.CoolingEmitter.CoolingEmitter(DiGi.Analytical.Building.HVAC.Classes.HeatingEmitter)'></a>

## CoolingEmitter\(HeatingEmitter\) Constructor

Initializes a new instance of the [CoolingEmitter](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.CoolingEmitter 'DiGi\.Analytical\.Building\.HVAC\.Classes\.CoolingEmitter') class using the specified [HeatingEmitter](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.HeatingEmitter 'DiGi\.Analytical\.Building\.HVAC\.Classes\.HeatingEmitter')\.

```csharp
public CoolingEmitter(DiGi.Analytical.Building.HVAC.Classes.HeatingEmitter? heatingEmitter);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.CoolingEmitter.CoolingEmitter(DiGi.Analytical.Building.HVAC.Classes.HeatingEmitter).heatingEmitter'></a>

`heatingEmitter` [HeatingEmitter](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.HeatingEmitter 'DiGi\.Analytical\.Building\.HVAC\.Classes\.HeatingEmitter')

The [HeatingEmitter](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.HeatingEmitter 'DiGi\.Analytical\.Building\.HVAC\.Classes\.HeatingEmitter') instance used to initialize this object\.

<a name='DiGi.Analytical.Building.HVAC.Classes.CoolingEmitter.CoolingEmitter(System.Text.Json.Nodes.JsonObject)'></a>

## CoolingEmitter\(JsonObject\) Constructor

Initializes a new instance of the [CoolingEmitter](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.CoolingEmitter 'DiGi\.Analytical\.Building\.HVAC\.Classes\.CoolingEmitter') class using the specified JSON object\.

```csharp
public CoolingEmitter(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.CoolingEmitter.CoolingEmitter(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject') containing the data used to initialize the cooling emitter\. This value can be null\.

<a name='DiGi.Analytical.Building.HVAC.Classes.Emitter'></a>

## Emitter Class

Represents an abstract base class for HVAC emitter components, defining core properties for thermal radiation and operational temperature thresholds\.

```csharp
public abstract class Emitter : DiGi.Core.Parameter.Classes.ParametrizedObject, DiGi.Analytical.Building.HVAC.Interfaces.IHVACNamedObject, DiGi.Analytical.Building.HVAC.Interfaces.IHVACObject, DiGi.Analytical.Building.Interfaces.IBuildingObject, DiGi.Analytical.Interfaces.IAnalyticalObject, DiGi.Core.Interfaces.IObject, DiGi.Analytical.Building.Interfaces.IBuildingNamedObject, DiGi.Core.Interfaces.INamedObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Parameter\.Classes\.ParametrizedObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.parameter.classes.parametrizedobject 'DiGi\.Core\.Parameter\.Classes\.ParametrizedObject') → Emitter

Derived  
↳ [CoolingEmitter](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.CoolingEmitter 'DiGi\.Analytical\.Building\.HVAC\.Classes\.CoolingEmitter')  
↳ [HeatingEmitter](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.HeatingEmitter 'DiGi\.Analytical\.Building\.HVAC\.Classes\.HeatingEmitter')

Implements [IHVACNamedObject](DiGi.Analytical.Building.HVAC.Interfaces.md#DiGi.Analytical.Building.HVAC.Interfaces.IHVACNamedObject 'DiGi\.Analytical\.Building\.HVAC\.Interfaces\.IHVACNamedObject'), [IHVACObject](DiGi.Analytical.Building.HVAC.Interfaces.md#DiGi.Analytical.Building.HVAC.Interfaces.IHVACObject 'DiGi\.Analytical\.Building\.HVAC\.Interfaces\.IHVACObject'), [DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.ibuildingobject 'DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject'), [DiGi\.Analytical\.Interfaces\.IAnalyticalObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.interfaces.ianalyticalobject 'DiGi\.Analytical\.Interfaces\.IAnalyticalObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Analytical\.Building\.Interfaces\.IBuildingNamedObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.ibuildingnamedobject 'DiGi\.Analytical\.Building\.Interfaces\.IBuildingNamedObject'), [DiGi\.Core\.Interfaces\.INamedObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.inamedobject 'DiGi\.Core\.Interfaces\.INamedObject')
### Constructors

<a name='DiGi.Analytical.Building.HVAC.Classes.Emitter.Emitter()'></a>

## Emitter\(\) Constructor

Initializes a new instance of the [Emitter](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.Emitter 'DiGi\.Analytical\.Building\.HVAC\.Classes\.Emitter') class\.

```csharp
public Emitter();
```

<a name='DiGi.Analytical.Building.HVAC.Classes.Emitter.Emitter(DiGi.Analytical.Building.HVAC.Classes.Emitter)'></a>

## Emitter\(Emitter\) Constructor

Initializes a new instance of the [Emitter](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.Emitter 'DiGi\.Analytical\.Building\.HVAC\.Classes\.Emitter') class by copying the properties from another [Emitter](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.Emitter 'DiGi\.Analytical\.Building\.HVAC\.Classes\.Emitter') instance\.

```csharp
public Emitter(DiGi.Analytical.Building.HVAC.Classes.Emitter? emitter);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.Emitter.Emitter(DiGi.Analytical.Building.HVAC.Classes.Emitter).emitter'></a>

`emitter` [Emitter](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.Emitter 'DiGi\.Analytical\.Building\.HVAC\.Classes\.Emitter')

The source [Emitter](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.Emitter 'DiGi\.Analytical\.Building\.HVAC\.Classes\.Emitter') object to copy values from; if null, only base class initialization is performed\.

<a name='DiGi.Analytical.Building.HVAC.Classes.Emitter.Emitter(System.Text.Json.Nodes.JsonObject)'></a>

## Emitter\(JsonObject\) Constructor

Initializes a new instance of the [Emitter](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.Emitter 'DiGi\.Analytical\.Building\.HVAC\.Classes\.Emitter') class using the specified JSON object\.

```csharp
public Emitter(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.Emitter.Emitter(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object used to initialize the properties of the emitter; may be [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.
### Properties

<a name='DiGi.Analytical.Building.HVAC.Classes.Emitter.Description'></a>

## Emitter\.Description Property

Gets or sets the description of the emitter\.

```csharp
public string? Description { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.HVAC.Classes.Emitter.MaxOutsideTemperature'></a>

## Emitter\.MaxOutsideTemperature Property

Gets or sets the maximum outside temperature\.

```csharp
public double MaxOutsideTemperature { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.HVAC.Classes.Emitter.Name'></a>

## Emitter\.Name Property

Gets or sets the name of the emitter\.

```csharp
public string? Name { get; set; }
```

Implements [Name](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.inamedobject.name 'DiGi\.Core\.Interfaces\.INamedObject\.Name')

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.HVAC.Classes.Emitter.OffOutsideTemperature'></a>

## Emitter\.OffOutsideTemperature Property

Gets or sets the outside temperature threshold at which the emitter is turned off\.

```csharp
public double OffOutsideTemperature { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.HVAC.Classes.Emitter.RadiantProportion'></a>

## Emitter\.RadiantProportion Property

Gets or sets the radiant proportion of the emitter as a value between 0 and 1\.

```csharp
public DiGi.Core.Classes.Factor RadiantProportion { get; set; }
```

#### Property Value
[DiGi\.Core\.Classes\.Factor](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.factor 'DiGi\.Core\.Classes\.Factor')

<a name='DiGi.Analytical.Building.HVAC.Classes.Emitter.ViewCoefficient'></a>

## Emitter\.ViewCoefficient Property

Gets or sets the view coefficient of the emitter as a normalization factor between 0 and 1\.

```csharp
public DiGi.Core.Classes.Factor ViewCoefficient { get; set; }
```

#### Property Value
[DiGi\.Core\.Classes\.Factor](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.factor 'DiGi\.Core\.Classes\.Factor')

<a name='DiGi.Analytical.Building.HVAC.Classes.HeatingEmitter'></a>

## HeatingEmitter Class

Represents a heating emitter component within the HVAC system used for thermal analysis\.

```csharp
public class HeatingEmitter : DiGi.Analytical.Building.HVAC.Classes.Emitter
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Parameter\.Classes\.ParametrizedObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.parameter.classes.parametrizedobject 'DiGi\.Core\.Parameter\.Classes\.ParametrizedObject') → [Emitter](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.Emitter 'DiGi\.Analytical\.Building\.HVAC\.Classes\.Emitter') → HeatingEmitter
### Constructors

<a name='DiGi.Analytical.Building.HVAC.Classes.HeatingEmitter.HeatingEmitter()'></a>

## HeatingEmitter\(\) Constructor

Initializes a new instance of the [HeatingEmitter](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.HeatingEmitter 'DiGi\.Analytical\.Building\.HVAC\.Classes\.HeatingEmitter') class\.

```csharp
public HeatingEmitter();
```

<a name='DiGi.Analytical.Building.HVAC.Classes.HeatingEmitter.HeatingEmitter(DiGi.Analytical.Building.HVAC.Classes.HeatingEmitter)'></a>

## HeatingEmitter\(HeatingEmitter\) Constructor

Initializes a new instance of the [HeatingEmitter](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.HeatingEmitter 'DiGi\.Analytical\.Building\.HVAC\.Classes\.HeatingEmitter') class using an existing [HeatingEmitter](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.HeatingEmitter 'DiGi\.Analytical\.Building\.HVAC\.Classes\.HeatingEmitter') instance\.

```csharp
public HeatingEmitter(DiGi.Analytical.Building.HVAC.Classes.HeatingEmitter? heatingEmitter);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.HeatingEmitter.HeatingEmitter(DiGi.Analytical.Building.HVAC.Classes.HeatingEmitter).heatingEmitter'></a>

`heatingEmitter` [HeatingEmitter](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.HeatingEmitter 'DiGi\.Analytical\.Building\.HVAC\.Classes\.HeatingEmitter')

The source [HeatingEmitter](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.HeatingEmitter 'DiGi\.Analytical\.Building\.HVAC\.Classes\.HeatingEmitter') instance to copy from\.

<a name='DiGi.Analytical.Building.HVAC.Classes.HeatingEmitter.HeatingEmitter(System.Text.Json.Nodes.JsonObject)'></a>

## HeatingEmitter\(JsonObject\) Constructor

Initializes a new instance of the [HeatingEmitter](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.HeatingEmitter 'DiGi\.Analytical\.Building\.HVAC\.Classes\.HeatingEmitter') class using the specified JSON object\.

```csharp
public HeatingEmitter(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.HeatingEmitter.HeatingEmitter(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject') used to populate the properties of the heating emitter; can be null\.

<a name='DiGi.Analytical.Building.HVAC.Classes.InternalGain'></a>

## InternalGain Class

Represents the internal heat gain parameters for a building space, including radiant proportions and view coefficients for lighting, occupants, and equipment\.

```csharp
public class InternalGain : DiGi.Core.Parameter.Classes.ParametrizedObject, DiGi.Analytical.Building.HVAC.Interfaces.IHVACNamedObject, DiGi.Analytical.Building.HVAC.Interfaces.IHVACObject, DiGi.Analytical.Building.Interfaces.IBuildingObject, DiGi.Analytical.Interfaces.IAnalyticalObject, DiGi.Core.Interfaces.IObject, DiGi.Analytical.Building.Interfaces.IBuildingNamedObject, DiGi.Core.Interfaces.INamedObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Parameter\.Classes\.ParametrizedObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.parameter.classes.parametrizedobject 'DiGi\.Core\.Parameter\.Classes\.ParametrizedObject') → InternalGain

Implements [IHVACNamedObject](DiGi.Analytical.Building.HVAC.Interfaces.md#DiGi.Analytical.Building.HVAC.Interfaces.IHVACNamedObject 'DiGi\.Analytical\.Building\.HVAC\.Interfaces\.IHVACNamedObject'), [IHVACObject](DiGi.Analytical.Building.HVAC.Interfaces.md#DiGi.Analytical.Building.HVAC.Interfaces.IHVACObject 'DiGi\.Analytical\.Building\.HVAC\.Interfaces\.IHVACObject'), [DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.ibuildingobject 'DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject'), [DiGi\.Analytical\.Interfaces\.IAnalyticalObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.interfaces.ianalyticalobject 'DiGi\.Analytical\.Interfaces\.IAnalyticalObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Analytical\.Building\.Interfaces\.IBuildingNamedObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.ibuildingnamedobject 'DiGi\.Analytical\.Building\.Interfaces\.IBuildingNamedObject'), [DiGi\.Core\.Interfaces\.INamedObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.inamedobject 'DiGi\.Core\.Interfaces\.INamedObject')
### Constructors

<a name='DiGi.Analytical.Building.HVAC.Classes.InternalGain.InternalGain()'></a>

## InternalGain\(\) Constructor

Initializes a new instance of the [InternalGain](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.InternalGain 'DiGi\.Analytical\.Building\.HVAC\.Classes\.InternalGain') class\.

```csharp
public InternalGain();
```

<a name='DiGi.Analytical.Building.HVAC.Classes.InternalGain.InternalGain(DiGi.Analytical.Building.HVAC.Classes.InternalGain)'></a>

## InternalGain\(InternalGain\) Constructor

Initializes a new instance of the [InternalGain](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.InternalGain 'DiGi\.Analytical\.Building\.HVAC\.Classes\.InternalGain') class by copying values from an existing [InternalGain](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.InternalGain 'DiGi\.Analytical\.Building\.HVAC\.Classes\.InternalGain') instance\.

```csharp
public InternalGain(DiGi.Analytical.Building.HVAC.Classes.InternalGain? internalGain);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.InternalGain.InternalGain(DiGi.Analytical.Building.HVAC.Classes.InternalGain).internalGain'></a>

`internalGain` [InternalGain](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.InternalGain 'DiGi\.Analytical\.Building\.HVAC\.Classes\.InternalGain')

The source [InternalGain](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.InternalGain 'DiGi\.Analytical\.Building\.HVAC\.Classes\.InternalGain') instance to copy data from, or [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

<a name='DiGi.Analytical.Building.HVAC.Classes.InternalGain.InternalGain(System.Text.Json.Nodes.JsonObject)'></a>

## InternalGain\(JsonObject\) Constructor

Initializes a new instance of the [InternalGain](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.InternalGain 'DiGi\.Analytical\.Building\.HVAC\.Classes\.InternalGain') class using the specified JSON object\.

```csharp
public InternalGain(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.InternalGain.InternalGain(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the initialization data, or [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.
### Properties

<a name='DiGi.Analytical.Building.HVAC.Classes.InternalGain.Description'></a>

## InternalGain\.Description Property

Gets or sets the description of the internal gain\.

```csharp
public string? Description { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.HVAC.Classes.InternalGain.EquipmentRadiantProportion'></a>

## InternalGain\.EquipmentRadiantProportion Property

Gets or sets the proportion of equipment internal heat gain that is radiant, expressed as a factor between 0 and 1\.

```csharp
public DiGi.Core.Classes.Factor EquipmentRadiantProportion { get; set; }
```

#### Property Value
[DiGi\.Core\.Classes\.Factor](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.factor 'DiGi\.Core\.Classes\.Factor')

<a name='DiGi.Analytical.Building.HVAC.Classes.InternalGain.EquipmentViewCoefficient'></a>

## InternalGain\.EquipmentViewCoefficient Property

Gets or sets the view coefficient for equipment internal gains, represented as a factor between 0 and 1\.

```csharp
public DiGi.Core.Classes.Factor EquipmentViewCoefficient { get; set; }
```

#### Property Value
[DiGi\.Core\.Classes\.Factor](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.factor 'DiGi\.Core\.Classes\.Factor')

<a name='DiGi.Analytical.Building.HVAC.Classes.InternalGain.LightingRadiantProportion'></a>

## InternalGain\.LightingRadiantProportion Property

Gets or sets the proportion of lighting heat gain that is radiant\.

```csharp
public DiGi.Core.Classes.Factor LightingRadiantProportion { get; set; }
```

#### Property Value
[DiGi\.Core\.Classes\.Factor](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.factor 'DiGi\.Core\.Classes\.Factor')

<a name='DiGi.Analytical.Building.HVAC.Classes.InternalGain.LightingViewCoefficient'></a>

## InternalGain\.LightingViewCoefficient Property

Gets or sets the lighting view coefficient, represented as a factor between 0 and 1\.

```csharp
public DiGi.Core.Classes.Factor LightingViewCoefficient { get; set; }
```

#### Property Value
[DiGi\.Core\.Classes\.Factor](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.factor 'DiGi\.Core\.Classes\.Factor')

<a name='DiGi.Analytical.Building.HVAC.Classes.InternalGain.Name'></a>

## InternalGain\.Name Property

Gets or sets the name of the internal gain\.

```csharp
public string? Name { get; set; }
```

Implements [Name](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.inamedobject.name 'DiGi\.Core\.Interfaces\.INamedObject\.Name')

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.HVAC.Classes.InternalGain.OccupantRadiantProportion'></a>

## InternalGain\.OccupantRadiantProportion Property

Gets or sets the proportion of occupant internal heat gain that is radiant, expressed as a factor between 0 and 1\.

```csharp
public DiGi.Core.Classes.Factor OccupantRadiantProportion { get; set; }
```

#### Property Value
[DiGi\.Core\.Classes\.Factor](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.factor 'DiGi\.Core\.Classes\.Factor')

<a name='DiGi.Analytical.Building.HVAC.Classes.InternalGain.OccupantViewCoefficient'></a>

## InternalGain\.OccupantViewCoefficient Property

Gets or sets the view coefficient for occupant internal gains, representing a normalization factor between 0 and 1\.

```csharp
public DiGi.Core.Classes.Factor OccupantViewCoefficient { get; set; }
```

#### Property Value
[DiGi\.Core\.Classes\.Factor](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.factor 'DiGi\.Core\.Classes\.Factor')

<a name='DiGi.Analytical.Building.HVAC.Classes.InternalGain.this[DiGi.Analytical.Building.HVAC.Enums.InternalGainProfileType]'></a>

## InternalGain\.this\[InternalGainProfileType\] Property

Gets or sets the profile associated with the specified internal gain profile type\.

```csharp
public DiGi.Analytical.Building.Interfaces.IProfile? this[DiGi.Analytical.Building.HVAC.Enums.InternalGainProfileType internalGainProfileType] { get; set; }
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.InternalGain.this[DiGi.Analytical.Building.HVAC.Enums.InternalGainProfileType].internalGainProfileType'></a>

`internalGainProfileType` [InternalGainProfileType](DiGi.Analytical.Building.HVAC.Enums.md#DiGi.Analytical.Building.HVAC.Enums.InternalGainProfileType 'DiGi\.Analytical\.Building\.HVAC\.Enums\.InternalGainProfileType')

The type of the internal gain profile to retrieve or set\.

#### Property Value
[DiGi\.Analytical\.Building\.Interfaces\.IProfile](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.iprofile 'DiGi\.Analytical\.Building\.Interfaces\.IProfile')

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_'></a>

## RegulatedHeatTransferCoefficients\<TEnum\> Class

Provides an abstract base implementation for regulated heat transfer coefficients, associating specific regulatory categories with their corresponding numerical values\.

Besides the maximum heat transfer coefficients U(max) [W/(m2K)], a regulation may limit a partition by a minimum thermal resistance R(min) [(m2K)/W] instead - the 2002 regulation does so for floors on ground. The two are kept apart, so a resistance is never read or displayed as a heat transfer coefficient (DiGi-Organization/DiGi.Analytical#12).

```csharp
public abstract class RegulatedHeatTransferCoefficients<TEnum> : DiGi.Core.Classes.SerializableObject, DiGi.Analytical.Building.HVAC.Interfaces.IRegulatedHeatTransferCoefficients, DiGi.Analytical.Building.Interfaces.IBuildingSerializableObject, DiGi.Analytical.Building.Interfaces.IBuildingObject, DiGi.Analytical.Interfaces.IAnalyticalObject, DiGi.Core.Interfaces.IObject, DiGi.Core.Interfaces.ISerializableObject, DiGi.Core.Interfaces.ICloneableObject<DiGi.Core.Interfaces.ISerializableObject>, DiGi.Core.Interfaces.ICloneableObject
    where TEnum : System.Enum
```
#### Type parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_.TEnum'></a>

`TEnum`

The enumeration type used to define the keys for the heat transfer coefficient values\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → RegulatedHeatTransferCoefficients\<TEnum\>

Derived  
↳ [RegulatedHeatTransferCoefficients\_1997](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_1997 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\_1997')  
↳ [RegulatedHeatTransferCoefficients\_2002](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2002 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\_2002')  
↳ [RegulatedHeatTransferCoefficients\_2009](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2009 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\_2009')  
↳ [RegulatedHeatTransferCoefficients\_2014](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2014 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\_2014')

Implements [IRegulatedHeatTransferCoefficients](DiGi.Analytical.Building.HVAC.Interfaces.md#DiGi.Analytical.Building.HVAC.Interfaces.IRegulatedHeatTransferCoefficients 'DiGi\.Analytical\.Building\.HVAC\.Interfaces\.IRegulatedHeatTransferCoefficients'), [DiGi\.Analytical\.Building\.Interfaces\.IBuildingSerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.ibuildingserializableobject 'DiGi\.Analytical\.Building\.Interfaces\.IBuildingSerializableObject'), [DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.ibuildingobject 'DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject'), [DiGi\.Analytical\.Interfaces\.IAnalyticalObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.interfaces.ianalyticalobject 'DiGi\.Analytical\.Interfaces\.IAnalyticalObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject'), [DiGi\.Core\.Interfaces\.ICloneableObject&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1')[DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject-1 'DiGi\.Core\.Interfaces\.ICloneableObject\`1'), [DiGi\.Core\.Interfaces\.ICloneableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.icloneableobject 'DiGi\.Core\.Interfaces\.ICloneableObject')
### Constructors

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_.RegulatedHeatTransferCoefficients(DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_)'></a>

## RegulatedHeatTransferCoefficients\(RegulatedHeatTransferCoefficients\<TEnum\>\) Constructor

Initializes a new instance of the [RegulatedHeatTransferCoefficients&lt;TEnum&gt;](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_ 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\<TEnum\>') class by copying the values from an existing instance\.

```csharp
public RegulatedHeatTransferCoefficients(DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients<TEnum> regulatedHeatTransferCoefficients);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_.RegulatedHeatTransferCoefficients(DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_).regulatedHeatTransferCoefficients'></a>

`regulatedHeatTransferCoefficients` [DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients&lt;](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_ 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\<TEnum\>')[TEnum](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_.TEnum 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\<TEnum\>\.TEnum')[&gt;](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_ 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\<TEnum\>')

The source instance to copy heat transfer coefficients, minimum thermal resistances and regulation act from\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_.RegulatedHeatTransferCoefficients(DiGi.Analytical.Building.HVAC.Classes.RegulationAct)'></a>

## RegulatedHeatTransferCoefficients\(RegulationAct\) Constructor

Initializes a new instance of the [RegulatedHeatTransferCoefficients&lt;TEnum&gt;](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_ 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\<TEnum\>') class with the specified regulation act\.

```csharp
public RegulatedHeatTransferCoefficients(DiGi.Analytical.Building.HVAC.Classes.RegulationAct? regulationAct);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_.RegulatedHeatTransferCoefficients(DiGi.Analytical.Building.HVAC.Classes.RegulationAct).regulationAct'></a>

`regulationAct` [RegulationAct](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulationAct 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulationAct')

The regulation act associated with the heat transfer coefficients, or [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') if not specified\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_.RegulatedHeatTransferCoefficients(System.Text.Json.Nodes.JsonObject)'></a>

## RegulatedHeatTransferCoefficients\(JsonObject\) Constructor

Initializes a new instance of the [RegulatedHeatTransferCoefficients&lt;TEnum&gt;](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_ 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\<TEnum\>') class using the specified JSON object\.

```csharp
public RegulatedHeatTransferCoefficients(System.Text.Json.Nodes.JsonObject jsonObject);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_.RegulatedHeatTransferCoefficients(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject') containing the serialized data for initialization\.
### Properties

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_.RegulationAct'></a>

## RegulatedHeatTransferCoefficients\<TEnum\>\.RegulationAct Property

Gets the regulation act associated with the regulated heat transfer coefficients\.

```csharp
public DiGi.Analytical.Building.HVAC.Classes.RegulationAct? RegulationAct { get; }
```

Implements [RegulationAct](DiGi.Analytical.Building.HVAC.Interfaces.md#DiGi.Analytical.Building.HVAC.Interfaces.IRegulatedHeatTransferCoefficients.RegulationAct 'DiGi\.Analytical\.Building\.HVAC\.Interfaces\.IRegulatedHeatTransferCoefficients\.RegulationAct')

#### Property Value
[RegulationAct](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulationAct 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulationAct')

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_.this[TEnum]'></a>

## RegulatedHeatTransferCoefficients\<TEnum\>\.this\[TEnum\] Property

Gets or sets the heat transfer coefficient associated with the specified enumeration member\.

```csharp
public double this[TEnum @enum] { get; set; }
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_.this[TEnum].enum'></a>

`enum` [TEnum](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_.TEnum 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\<TEnum\>\.TEnum')

The enumeration member used to access the heat transfer coefficient\.

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')
### Methods

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_.GetEnums()'></a>

## RegulatedHeatTransferCoefficients\<TEnum\>\.GetEnums\(\) Method

Retrieves the list of enumeration values used as keys for the heat transfer coefficients\.

```csharp
public System.Collections.Generic.List<TEnum> GetEnums();
```

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[TEnum](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_.TEnum 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\<TEnum\>\.TEnum')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A [System\.Collections\.Generic\.List&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1') containing all the enumeration values currently defined in the coefficients collection\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_.GetMinimumThermalResistanceNames()'></a>

## RegulatedHeatTransferCoefficients\<TEnum\>\.GetMinimumThermalResistanceNames\(\) Method

Retrieves a list of names or descriptions for the regulated minimum thermal resistances\.

```csharp
public System.Collections.Generic.List<string> GetMinimumThermalResistanceNames();
```

Implements [GetMinimumThermalResistanceNames\(\)](DiGi.Analytical.Building.HVAC.Interfaces.md#DiGi.Analytical.Building.HVAC.Interfaces.IRegulatedHeatTransferCoefficients.GetMinimumThermalResistanceNames() 'DiGi\.Analytical\.Building\.HVAC\.Interfaces\.IRegulatedHeatTransferCoefficients\.GetMinimumThermalResistanceNames\(\)')

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of strings representing the names of the minimum thermal resistances\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_.GetNames()'></a>

## RegulatedHeatTransferCoefficients\<TEnum\>\.GetNames\(\) Method

Retrieves a list of names or descriptions for the regulated heat transfer coefficients\.

```csharp
public System.Collections.Generic.List<string> GetNames();
```

Implements [GetNames\(\)](DiGi.Analytical.Building.HVAC.Interfaces.md#DiGi.Analytical.Building.HVAC.Interfaces.IRegulatedHeatTransferCoefficients.GetNames() 'DiGi\.Analytical\.Building\.HVAC\.Interfaces\.IRegulatedHeatTransferCoefficients\.GetNames\(\)')

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of strings representing the names of the coefficients\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_.SetMinimumThermalResistance(TEnum,double)'></a>

## RegulatedHeatTransferCoefficients\<TEnum\>\.SetMinimumThermalResistance\(TEnum, double\) Method

Sets the minimum thermal resistance R\(min\) \[\(m2K\)/W\] for the specified enumeration member\.

```csharp
public bool SetMinimumThermalResistance(TEnum @enum, double value);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_.SetMinimumThermalResistance(TEnum,double).enum'></a>

`enum` [TEnum](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_.TEnum 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\<TEnum\>\.TEnum')

The enumeration member identifying the partition the minimum thermal resistance applies to\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_.SetMinimumThermalResistance(TEnum,double).value'></a>

`value` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The minimum thermal resistance \[\(m2K\)/W\]\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the value was successfully set; false if the provided value is [System\.Double\.NaN](https://learn.microsoft.com/en-us/dotnet/api/system.double.nan 'System\.Double\.NaN')\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_.SetValue(TEnum,double)'></a>

## RegulatedHeatTransferCoefficients\<TEnum\>\.SetValue\(TEnum, double\) Method

Sets the heat transfer coefficient value for the specified enumeration member\.

```csharp
public bool SetValue(TEnum @enum, double value);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_.SetValue(TEnum,double).enum'></a>

`enum` [TEnum](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_.TEnum 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\<TEnum\>\.TEnum')

The enumeration member identifying the coefficient to set\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_.SetValue(TEnum,double).value'></a>

`value` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The numeric value to assign to the coefficient\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the value was successfully set; false if the provided value is [System\.Double\.NaN](https://learn.microsoft.com/en-us/dotnet/api/system.double.nan 'System\.Double\.NaN')\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_.TryGetMinimumThermalResistance(string,double)'></a>

## RegulatedHeatTransferCoefficients\<TEnum\>\.TryGetMinimumThermalResistance\(string, double\) Method

Attempts to retrieve the minimum thermal resistance R\(min\) \[\(m2K\)/W\] associated with the specified name\.

```csharp
public bool TryGetMinimumThermalResistance(string name, out double value);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_.TryGetMinimumThermalResistance(string,double).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the minimum thermal resistance to retrieve, matching either the enum description or its string representation\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_.TryGetMinimumThermalResistance(string,double).value'></a>

`value` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

When this method returns, contains the retrieved value if successful; otherwise, [System\.Double\.NaN](https://learn.microsoft.com/en-us/dotnet/api/system.double.nan 'System\.Double\.NaN')\.

Implements [TryGetMinimumThermalResistance\(string, double\)](DiGi.Analytical.Building.HVAC.Interfaces.md#DiGi.Analytical.Building.HVAC.Interfaces.IRegulatedHeatTransferCoefficients.TryGetMinimumThermalResistance(string,double) 'DiGi\.Analytical\.Building\.HVAC\.Interfaces\.IRegulatedHeatTransferCoefficients\.TryGetMinimumThermalResistance\(string, double\)')

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the value was successfully retrieved; otherwise, false\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_.TryGetMinimumThermalResistance(TEnum,double)'></a>

## RegulatedHeatTransferCoefficients\<TEnum\>\.TryGetMinimumThermalResistance\(TEnum, double\) Method

Attempts to retrieve the minimum thermal resistance R\(min\) \[\(m2K\)/W\] associated with the specified enumeration member\.

```csharp
public bool TryGetMinimumThermalResistance(TEnum @enum, out double value);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_.TryGetMinimumThermalResistance(TEnum,double).enum'></a>

`enum` [TEnum](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_.TEnum 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\<TEnum\>\.TEnum')

The enumeration member used as the key for retrieval\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_.TryGetMinimumThermalResistance(TEnum,double).value'></a>

`value` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

When this method returns, contains the retrieved value if successful; otherwise, [System\.Double\.NaN](https://learn.microsoft.com/en-us/dotnet/api/system.double.nan 'System\.Double\.NaN')\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the value was successfully retrieved; otherwise, false\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_.TryGetValue(string,double)'></a>

## RegulatedHeatTransferCoefficients\<TEnum\>\.TryGetValue\(string, double\) Method

Attempts to retrieve the heat transfer coefficient value associated with the specified name\.

```csharp
public bool TryGetValue(string name, out double value);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_.TryGetValue(string,double).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the coefficient to retrieve, matching either the enum description or its string representation\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_.TryGetValue(string,double).value'></a>

`value` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

When this method returns, contains the retrieved value if successful; otherwise, [System\.Double\.NaN](https://learn.microsoft.com/en-us/dotnet/api/system.double.nan 'System\.Double\.NaN')\.

Implements [TryGetValue\(string, double\)](DiGi.Analytical.Building.HVAC.Interfaces.md#DiGi.Analytical.Building.HVAC.Interfaces.IRegulatedHeatTransferCoefficients.TryGetValue(string,double) 'DiGi\.Analytical\.Building\.HVAC\.Interfaces\.IRegulatedHeatTransferCoefficients\.TryGetValue\(string, double\)')

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the value was successfully retrieved; otherwise, false\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_.TryGetValue(TEnum,double)'></a>

## RegulatedHeatTransferCoefficients\<TEnum\>\.TryGetValue\(TEnum, double\) Method

Attempts to retrieve the heat transfer coefficient value associated with the specified enumeration member\.

```csharp
public bool TryGetValue(TEnum @enum, out double value);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_.TryGetValue(TEnum,double).enum'></a>

`enum` [TEnum](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_.TEnum 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\<TEnum\>\.TEnum')

The enumeration member used as the key for retrieval\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_.TryGetValue(TEnum,double).value'></a>

`value` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

When this method returns, contains the retrieved value if successful; otherwise, [System\.Double\.NaN](https://learn.microsoft.com/en-us/dotnet/api/system.double.nan 'System\.Double\.NaN')\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the value was successfully retrieved; otherwise, false\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficientsManager'></a>

## RegulatedHeatTransferCoefficientsManager Class

Manages the collection and retrieval of regulated heat transfer coefficients associated with specific timestamps\.

```csharp
public class RegulatedHeatTransferCoefficientsManager : DiGi.Core.Classes.SerializableObject, DiGi.Analytical.Building.HVAC.Interfaces.IHVACObject, DiGi.Analytical.Building.Interfaces.IBuildingObject, DiGi.Analytical.Interfaces.IAnalyticalObject, DiGi.Core.Interfaces.IObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → RegulatedHeatTransferCoefficientsManager

Implements [IHVACObject](DiGi.Analytical.Building.HVAC.Interfaces.md#DiGi.Analytical.Building.HVAC.Interfaces.IHVACObject 'DiGi\.Analytical\.Building\.HVAC\.Interfaces\.IHVACObject'), [DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.ibuildingobject 'DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject'), [DiGi\.Analytical\.Interfaces\.IAnalyticalObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.interfaces.ianalyticalobject 'DiGi\.Analytical\.Interfaces\.IAnalyticalObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject')
### Constructors

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficientsManager.RegulatedHeatTransferCoefficientsManager()'></a>

## RegulatedHeatTransferCoefficientsManager\(\) Constructor

Initializes a new instance of the [RegulatedHeatTransferCoefficientsManager](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficientsManager 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficientsManager') class\.

```csharp
public RegulatedHeatTransferCoefficientsManager();
```

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficientsManager.RegulatedHeatTransferCoefficientsManager(DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficientsManager)'></a>

## RegulatedHeatTransferCoefficientsManager\(RegulatedHeatTransferCoefficientsManager\) Constructor

Initializes a new instance of the [RegulatedHeatTransferCoefficientsManager](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficientsManager 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficientsManager') class by copying the specified instance\.

```csharp
public RegulatedHeatTransferCoefficientsManager(DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficientsManager regulatedHeatTransferCoefficientsManager);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficientsManager.RegulatedHeatTransferCoefficientsManager(DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficientsManager).regulatedHeatTransferCoefficientsManager'></a>

`regulatedHeatTransferCoefficientsManager` [RegulatedHeatTransferCoefficientsManager](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficientsManager 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficientsManager')

The source [RegulatedHeatTransferCoefficientsManager](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficientsManager 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficientsManager') instance to copy from; each of its regulated heat transfer coefficients is cloned\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficientsManager.RegulatedHeatTransferCoefficientsManager(System.Text.Json.Nodes.JsonObject)'></a>

## RegulatedHeatTransferCoefficientsManager\(JsonObject\) Constructor

Initializes a new instance of the [RegulatedHeatTransferCoefficientsManager](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficientsManager 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficientsManager') class from the specified JSON object\.

```csharp
public RegulatedHeatTransferCoefficientsManager(System.Text.Json.Nodes.JsonObject jsonObject);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficientsManager.RegulatedHeatTransferCoefficientsManager(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject') used to populate the properties of the manager\.
### Methods

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficientsManager.Add(DiGi.Analytical.Building.HVAC.Interfaces.IRegulatedHeatTransferCoefficients)'></a>

## RegulatedHeatTransferCoefficientsManager\.Add\(IRegulatedHeatTransferCoefficients\) Method

Adds a regulated heat transfer coefficient to the manager\.

```csharp
public bool Add(DiGi.Analytical.Building.HVAC.Interfaces.IRegulatedHeatTransferCoefficients? regulatedHeatTransferCoefficients);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficientsManager.Add(DiGi.Analytical.Building.HVAC.Interfaces.IRegulatedHeatTransferCoefficients).regulatedHeatTransferCoefficients'></a>

`regulatedHeatTransferCoefficients` [IRegulatedHeatTransferCoefficients](DiGi.Analytical.Building.HVAC.Interfaces.md#DiGi.Analytical.Building.HVAC.Interfaces.IRegulatedHeatTransferCoefficients 'DiGi\.Analytical\.Building\.HVAC\.Interfaces\.IRegulatedHeatTransferCoefficients')

The regulated heat transfer coefficients to add\.

#### Returns
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')  
True if the regulated heat transfer coefficients were successfully added; otherwise, false\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficientsManager.GetRegulatedHeatTransferCoefficients(System.DateTime)'></a>

## RegulatedHeatTransferCoefficientsManager\.GetRegulatedHeatTransferCoefficients\(DateTime\) Method

Retrieves the regulated heat transfer coefficients applicable for the specified date and time\.

```csharp
public DiGi.Analytical.Building.HVAC.Interfaces.IRegulatedHeatTransferCoefficients? GetRegulatedHeatTransferCoefficients(System.DateTime dateTime);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficientsManager.GetRegulatedHeatTransferCoefficients(System.DateTime).dateTime'></a>

`dateTime` [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')

The date and time used to determine the active regulated heat transfer coefficients\.

#### Returns
[IRegulatedHeatTransferCoefficients](DiGi.Analytical.Building.HVAC.Interfaces.md#DiGi.Analytical.Building.HVAC.Interfaces.IRegulatedHeatTransferCoefficients 'DiGi\.Analytical\.Building\.HVAC\.Interfaces\.IRegulatedHeatTransferCoefficients')  
The [IRegulatedHeatTransferCoefficients](DiGi.Analytical.Building.HVAC.Interfaces.md#DiGi.Analytical.Building.HVAC.Interfaces.IRegulatedHeatTransferCoefficients 'DiGi\.Analytical\.Building\.HVAC\.Interfaces\.IRegulatedHeatTransferCoefficients') corresponding to the provided date, or `null` if no applicable coefficients are found\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficientsManager.GetRegulatedHeatTransferCoefficients(System.DateTime,bool)'></a>

## RegulatedHeatTransferCoefficientsManager\.GetRegulatedHeatTransferCoefficients\(DateTime, bool\) Method

Retrieves the regulated heat transfer coefficients applicable for the specified date and time, for a building of a public authority or for any other building\.

The coefficients that apply are those with the latest date on or before [dateTime](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficientsManager.GetRegulatedHeatTransferCoefficients(System.DateTime,bool).dateTime 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficientsManager\.GetRegulatedHeatTransferCoefficients\(System\.DateTime, bool\)\.dateTime'). For a public-authority building that date is the act's [PublicAuthorityEffectiveDate](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulationAct.PublicAuthorityEffectiveDate 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulationAct\.PublicAuthorityEffectiveDate') where the act sets one, so the last stage of the U-value limits applies to it from 1 January 2019 instead of 31 December 2020 (DiGi-Organization/DiGi.Analytical#11).

```csharp
public DiGi.Analytical.Building.HVAC.Interfaces.IRegulatedHeatTransferCoefficients? GetRegulatedHeatTransferCoefficients(System.DateTime dateTime, bool publicAuthority);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficientsManager.GetRegulatedHeatTransferCoefficients(System.DateTime,bool).dateTime'></a>

`dateTime` [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')

The date and time used to determine the active regulated heat transfer coefficients\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficientsManager.GetRegulatedHeatTransferCoefficients(System.DateTime,bool).publicAuthority'></a>

`publicAuthority` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Whether the building is occupied and owned by a judicial body, a prosecutor's office or a public administration body\.

#### Returns
[IRegulatedHeatTransferCoefficients](DiGi.Analytical.Building.HVAC.Interfaces.md#DiGi.Analytical.Building.HVAC.Interfaces.IRegulatedHeatTransferCoefficients 'DiGi\.Analytical\.Building\.HVAC\.Interfaces\.IRegulatedHeatTransferCoefficients')  
The [IRegulatedHeatTransferCoefficients](DiGi.Analytical.Building.HVAC.Interfaces.md#DiGi.Analytical.Building.HVAC.Interfaces.IRegulatedHeatTransferCoefficients 'DiGi\.Analytical\.Building\.HVAC\.Interfaces\.IRegulatedHeatTransferCoefficients') corresponding to the provided date, or `null` if no applicable coefficients are found\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficientsManager.RegulatedHeatTransferCoefficients_TRegulatedHeatTransferCoefficients_()'></a>

## RegulatedHeatTransferCoefficientsManager\.RegulatedHeatTransferCoefficients\<TRegulatedHeatTransferCoefficients\>\(\) Method

Retrieves a list of regulated heat transfer coefficients filtered by the specified type\.

```csharp
public System.Collections.Generic.List<TRegulatedHeatTransferCoefficients> RegulatedHeatTransferCoefficients<TRegulatedHeatTransferCoefficients>()
    where TRegulatedHeatTransferCoefficients : DiGi.Analytical.Building.HVAC.Interfaces.IRegulatedHeatTransferCoefficients;
```
#### Type parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficientsManager.RegulatedHeatTransferCoefficients_TRegulatedHeatTransferCoefficients_().TRegulatedHeatTransferCoefficients'></a>

`TRegulatedHeatTransferCoefficients`

The specific type of regulated heat transfer coefficients to retrieve, which must implement [IRegulatedHeatTransferCoefficients](DiGi.Analytical.Building.HVAC.Interfaces.md#DiGi.Analytical.Building.HVAC.Interfaces.IRegulatedHeatTransferCoefficients 'DiGi\.Analytical\.Building\.HVAC\.Interfaces\.IRegulatedHeatTransferCoefficients')\.

#### Returns
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[TRegulatedHeatTransferCoefficients](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficientsManager.RegulatedHeatTransferCoefficients_TRegulatedHeatTransferCoefficients_().TRegulatedHeatTransferCoefficients 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficientsManager\.RegulatedHeatTransferCoefficients\<TRegulatedHeatTransferCoefficients\>\(\)\.TRegulatedHeatTransferCoefficients')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')  
A list of all instances that match the specified type [TRegulatedHeatTransferCoefficients](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficientsManager.RegulatedHeatTransferCoefficients_TRegulatedHeatTransferCoefficients_().TRegulatedHeatTransferCoefficients 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficientsManager\.RegulatedHeatTransferCoefficients\<TRegulatedHeatTransferCoefficients\>\(\)\.TRegulatedHeatTransferCoefficients')\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_1997'></a>

## RegulatedHeatTransferCoefficients\_1997 Class

Represents the regulated heat transfer coefficients according to the 1997 amendment of the technical conditions \(Dz\.U\. 1997 nr 132 poz\. 878\) for external partition types, in force from 29 April 1998 until the 2002 regulation \(DiGi\-Organization/DiGi\.Analytical\#14\)\.

The annex sets k(max) limits for a single-family residential building and a public building only - for windows and doors as well. A multi-family or collective-residence building has no U(max) at all: it meets the regulation by its seasonal heat demand indicator E not exceeding E0 (§ 329).

A floor on ground is limited by a minimum sum of thermal resistances R(min) of 1.5 (m2K)/W at ti > 16 °C (point 1.4), not by a heat transfer coefficient; it is held as a minimum thermal resistance.

```csharp
public class RegulatedHeatTransferCoefficients_1997 : DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients<DiGi.Analytical.Building.HVAC.Enums.ExternalPartitionType_1997>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients&lt;](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_ 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\<TEnum\>')[ExternalPartitionType\_1997](DiGi.Analytical.Building.HVAC.Enums.md#DiGi.Analytical.Building.HVAC.Enums.ExternalPartitionType_1997 'DiGi\.Analytical\.Building\.HVAC\.Enums\.ExternalPartitionType\_1997')[&gt;](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_ 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\<TEnum\>') → RegulatedHeatTransferCoefficients\_1997
### Constructors

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_1997.RegulatedHeatTransferCoefficients_1997(DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_1997)'></a>

## RegulatedHeatTransferCoefficients\_1997\(RegulatedHeatTransferCoefficients\_1997\) Constructor

Initializes a new instance of the [RegulatedHeatTransferCoefficients\_1997](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_1997 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\_1997') class using another instance of the same type\.

```csharp
public RegulatedHeatTransferCoefficients_1997(DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_1997 regulatedHeatTransferCoefficients_1997);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_1997.RegulatedHeatTransferCoefficients_1997(DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_1997).regulatedHeatTransferCoefficients_1997'></a>

`regulatedHeatTransferCoefficients_1997` [RegulatedHeatTransferCoefficients\_1997](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_1997 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\_1997')

The source instance to copy from\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_1997.RegulatedHeatTransferCoefficients_1997(DiGi.Analytical.Building.HVAC.Classes.RegulationAct)'></a>

## RegulatedHeatTransferCoefficients\_1997\(RegulationAct\) Constructor

Initializes a new instance of the [RegulatedHeatTransferCoefficients\_1997](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_1997 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\_1997') class\.

```csharp
public RegulatedHeatTransferCoefficients_1997(DiGi.Analytical.Building.HVAC.Classes.RegulationAct? regulationAct);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_1997.RegulatedHeatTransferCoefficients_1997(DiGi.Analytical.Building.HVAC.Classes.RegulationAct).regulationAct'></a>

`regulationAct` [RegulationAct](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulationAct 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulationAct')

The regulation act used to initialize the heat transfer coefficients\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_1997.RegulatedHeatTransferCoefficients_1997(System.Text.Json.Nodes.JsonObject)'></a>

## RegulatedHeatTransferCoefficients\_1997\(JsonObject\) Constructor

Initializes a new instance of the [RegulatedHeatTransferCoefficients\_1997](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_1997 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\_1997') class using the specified JSON object\.

```csharp
public RegulatedHeatTransferCoefficients_1997(System.Text.Json.Nodes.JsonObject jsonObject);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_1997.RegulatedHeatTransferCoefficients_1997(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject') containing the data used to initialize this instance\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2002'></a>

## RegulatedHeatTransferCoefficients\_2002 Class

Represents the regulated heat transfer coefficients according to the 2002 regulation standards for external partition types\.

Annex 2 of the regulation (Dz.U. 2002 nr 75 poz. 690) sets the wall, roof and basement ceiling limits of a residential building in the single-family building table only. A multi-family or collective-residence building has no wall or roof U(max): it meets the regulation by its seasonal heat demand indicator E not exceeding E0 (§ 329). The window and door limits apply to every residential building.

A floor on ground is limited by a minimum sum of thermal resistances R(min) of 1.5 (m2K)/W at ti > 16 °C (point 1.4), not by a heat transfer coefficient; it is held as a minimum thermal resistance (DiGi-Organization/DiGi.Analytical#12).

```csharp
public class RegulatedHeatTransferCoefficients_2002 : DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients<DiGi.Analytical.Building.HVAC.Enums.ExternalPartitionType_2002>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients&lt;](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_ 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\<TEnum\>')[ExternalPartitionType\_2002](DiGi.Analytical.Building.HVAC.Enums.md#DiGi.Analytical.Building.HVAC.Enums.ExternalPartitionType_2002 'DiGi\.Analytical\.Building\.HVAC\.Enums\.ExternalPartitionType\_2002')[&gt;](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_ 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\<TEnum\>') → RegulatedHeatTransferCoefficients\_2002
### Constructors

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2002.RegulatedHeatTransferCoefficients_2002(DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2002)'></a>

## RegulatedHeatTransferCoefficients\_2002\(RegulatedHeatTransferCoefficients\_2002\) Constructor

Initializes a new instance of the [RegulatedHeatTransferCoefficients\_2002](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2002 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\_2002') class using another instance of the same type\.

```csharp
public RegulatedHeatTransferCoefficients_2002(DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2002 regulatedHeatTransferCoefficients_2002);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2002.RegulatedHeatTransferCoefficients_2002(DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2002).regulatedHeatTransferCoefficients_2002'></a>

`regulatedHeatTransferCoefficients_2002` [RegulatedHeatTransferCoefficients\_2002](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2002 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\_2002')

The source instance to copy from\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2002.RegulatedHeatTransferCoefficients_2002(DiGi.Analytical.Building.HVAC.Classes.RegulationAct)'></a>

## RegulatedHeatTransferCoefficients\_2002\(RegulationAct\) Constructor

Initializes a new instance of the [RegulatedHeatTransferCoefficients\_2002](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2002 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\_2002') class\.

```csharp
public RegulatedHeatTransferCoefficients_2002(DiGi.Analytical.Building.HVAC.Classes.RegulationAct? regulationAct);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2002.RegulatedHeatTransferCoefficients_2002(DiGi.Analytical.Building.HVAC.Classes.RegulationAct).regulationAct'></a>

`regulationAct` [RegulationAct](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulationAct 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulationAct')

The regulation act used to initialize the heat transfer coefficients\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2002.RegulatedHeatTransferCoefficients_2002(System.Text.Json.Nodes.JsonObject)'></a>

## RegulatedHeatTransferCoefficients\_2002\(JsonObject\) Constructor

Initializes a new instance of the [RegulatedHeatTransferCoefficients\_2002](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2002 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\_2002') class using the specified JSON object\.

```csharp
public RegulatedHeatTransferCoefficients_2002(System.Text.Json.Nodes.JsonObject jsonObject);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2002.RegulatedHeatTransferCoefficients_2002(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject') containing the data used to initialize this instance\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2009'></a>

## RegulatedHeatTransferCoefficients\_2009 Class

Provides the regulated heat transfer coefficients based on the 2009 regulations for external partition types\.

```csharp
public class RegulatedHeatTransferCoefficients_2009 : DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients<DiGi.Analytical.Building.HVAC.Enums.ExternalPartitionType_2009>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients&lt;](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_ 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\<TEnum\>')[ExternalPartitionType\_2009](DiGi.Analytical.Building.HVAC.Enums.md#DiGi.Analytical.Building.HVAC.Enums.ExternalPartitionType_2009 'DiGi\.Analytical\.Building\.HVAC\.Enums\.ExternalPartitionType\_2009')[&gt;](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_ 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\<TEnum\>') → RegulatedHeatTransferCoefficients\_2009
### Constructors

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2009.RegulatedHeatTransferCoefficients_2009(DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2009)'></a>

## RegulatedHeatTransferCoefficients\_2009\(RegulatedHeatTransferCoefficients\_2009\) Constructor

Initializes a new instance of the [RegulatedHeatTransferCoefficients\_2009](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2009 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\_2009') class using another instance of the same type\.

```csharp
public RegulatedHeatTransferCoefficients_2009(DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2009 regulatedHeatTransferCoefficients_2009);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2009.RegulatedHeatTransferCoefficients_2009(DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2009).regulatedHeatTransferCoefficients_2009'></a>

`regulatedHeatTransferCoefficients_2009` [RegulatedHeatTransferCoefficients\_2009](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2009 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\_2009')

The source instance to copy from\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2009.RegulatedHeatTransferCoefficients_2009(DiGi.Analytical.Building.HVAC.Classes.RegulationAct)'></a>

## RegulatedHeatTransferCoefficients\_2009\(RegulationAct\) Constructor

Initializes a new instance of the [RegulatedHeatTransferCoefficients\_2009](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2009 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\_2009') class\.

```csharp
public RegulatedHeatTransferCoefficients_2009(DiGi.Analytical.Building.HVAC.Classes.RegulationAct? regulationAct);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2009.RegulatedHeatTransferCoefficients_2009(DiGi.Analytical.Building.HVAC.Classes.RegulationAct).regulationAct'></a>

`regulationAct` [RegulationAct](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulationAct 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulationAct')

The regulation act used to determine the heat transfer coefficients\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2009.RegulatedHeatTransferCoefficients_2009(System.Text.Json.Nodes.JsonObject)'></a>

## RegulatedHeatTransferCoefficients\_2009\(JsonObject\) Constructor

Initializes a new instance of the [RegulatedHeatTransferCoefficients\_2009](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2009 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\_2009') class using the specified JSON object\.

```csharp
public RegulatedHeatTransferCoefficients_2009(System.Text.Json.Nodes.JsonObject jsonObject);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2009.RegulatedHeatTransferCoefficients_2009(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject') containing the data used to initialize this instance\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2014'></a>

## RegulatedHeatTransferCoefficients\_2014 Class

Represents the regulated heat transfer coefficients according to the 2014 regulations for external partition types\.

```csharp
public class RegulatedHeatTransferCoefficients_2014 : DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients<DiGi.Analytical.Building.HVAC.Enums.ExternalPartitionType_2014>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients&lt;](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_ 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\<TEnum\>')[ExternalPartitionType\_2014](DiGi.Analytical.Building.HVAC.Enums.md#DiGi.Analytical.Building.HVAC.Enums.ExternalPartitionType_2014 'DiGi\.Analytical\.Building\.HVAC\.Enums\.ExternalPartitionType\_2014')[&gt;](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_TEnum_ 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\<TEnum\>') → RegulatedHeatTransferCoefficients\_2014
### Constructors

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2014.RegulatedHeatTransferCoefficients_2014(DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2014)'></a>

## RegulatedHeatTransferCoefficients\_2014\(RegulatedHeatTransferCoefficients\_2014\) Constructor

Initializes a new instance of the [RegulatedHeatTransferCoefficients\_2014](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2014 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\_2014') class using an existing instance of the same type\.

```csharp
public RegulatedHeatTransferCoefficients_2014(DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2014 regulatedHeatTransferCoefficients_2014);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2014.RegulatedHeatTransferCoefficients_2014(DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2014).regulatedHeatTransferCoefficients_2014'></a>

`regulatedHeatTransferCoefficients_2014` [RegulatedHeatTransferCoefficients\_2014](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2014 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\_2014')

The source [RegulatedHeatTransferCoefficients\_2014](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2014 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\_2014') instance to copy from\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2014.RegulatedHeatTransferCoefficients_2014(DiGi.Analytical.Building.HVAC.Classes.RegulationAct)'></a>

## RegulatedHeatTransferCoefficients\_2014\(RegulationAct\) Constructor

Initializes a new instance of the [RegulatedHeatTransferCoefficients\_2014](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2014 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\_2014') class using the specified regulation act\.

```csharp
public RegulatedHeatTransferCoefficients_2014(DiGi.Analytical.Building.HVAC.Classes.RegulationAct? regulationAct);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2014.RegulatedHeatTransferCoefficients_2014(DiGi.Analytical.Building.HVAC.Classes.RegulationAct).regulationAct'></a>

`regulationAct` [RegulationAct](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulationAct 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulationAct')

The regulation act used to determine the heat transfer coefficients\. This value can be null\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2014.RegulatedHeatTransferCoefficients_2014(System.Text.Json.Nodes.JsonObject)'></a>

## RegulatedHeatTransferCoefficients\_2014\(JsonObject\) Constructor

Initializes a new instance of the [RegulatedHeatTransferCoefficients\_2014](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2014 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulatedHeatTransferCoefficients\_2014') class using the specified JSON object\.

```csharp
public RegulatedHeatTransferCoefficients_2014(System.Text.Json.Nodes.JsonObject jsonObject);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulatedHeatTransferCoefficients_2014.RegulatedHeatTransferCoefficients_2014(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject') containing the data used to initialize this instance\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulationAct'></a>

## RegulationAct Class

Represents a regulatory act associated with HVAC systems, providing details such as publication date, effective date, reference, name, and description\.

```csharp
public class RegulationAct : DiGi.Core.Classes.SerializableObject, DiGi.Analytical.Building.HVAC.Interfaces.IHVACNamedObject, DiGi.Analytical.Building.HVAC.Interfaces.IHVACObject, DiGi.Analytical.Building.Interfaces.IBuildingObject, DiGi.Analytical.Interfaces.IAnalyticalObject, DiGi.Core.Interfaces.IObject, DiGi.Analytical.Building.Interfaces.IBuildingNamedObject, DiGi.Core.Interfaces.INamedObject, DiGi.Core.Interfaces.IDescribableObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → RegulationAct

Implements [IHVACNamedObject](DiGi.Analytical.Building.HVAC.Interfaces.md#DiGi.Analytical.Building.HVAC.Interfaces.IHVACNamedObject 'DiGi\.Analytical\.Building\.HVAC\.Interfaces\.IHVACNamedObject'), [IHVACObject](DiGi.Analytical.Building.HVAC.Interfaces.md#DiGi.Analytical.Building.HVAC.Interfaces.IHVACObject 'DiGi\.Analytical\.Building\.HVAC\.Interfaces\.IHVACObject'), [DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.ibuildingobject 'DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject'), [DiGi\.Analytical\.Interfaces\.IAnalyticalObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.interfaces.ianalyticalobject 'DiGi\.Analytical\.Interfaces\.IAnalyticalObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Analytical\.Building\.Interfaces\.IBuildingNamedObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.ibuildingnamedobject 'DiGi\.Analytical\.Building\.Interfaces\.IBuildingNamedObject'), [DiGi\.Core\.Interfaces\.INamedObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.inamedobject 'DiGi\.Core\.Interfaces\.INamedObject'), [DiGi\.Core\.Interfaces\.IDescribableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.idescribableobject 'DiGi\.Core\.Interfaces\.IDescribableObject')
### Constructors

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulationAct.RegulationAct(DiGi.Analytical.Building.HVAC.Classes.RegulationAct)'></a>

## RegulationAct\(RegulationAct\) Constructor

Initializes a new instance of the [RegulationAct](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulationAct 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulationAct') class by copying the values from an existing [RegulationAct](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulationAct 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulationAct') instance\.

```csharp
public RegulationAct(DiGi.Analytical.Building.HVAC.Classes.RegulationAct regulationAct);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulationAct.RegulationAct(DiGi.Analytical.Building.HVAC.Classes.RegulationAct).regulationAct'></a>

`regulationAct` [RegulationAct](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulationAct 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulationAct')

The source [RegulationAct](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulationAct 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulationAct') object to copy data from\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulationAct.RegulationAct(System.DateTime,System.DateTime,string,string,string)'></a>

## RegulationAct\(DateTime, DateTime, string, string, string\) Constructor

Initializes a new instance of the [RegulationAct](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulationAct 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulationAct') class\.

```csharp
public RegulationAct(System.DateTime publicationDate, System.DateTime effectiveDate, string? reference, string? name, string? descriprion);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulationAct.RegulationAct(System.DateTime,System.DateTime,string,string,string).publicationDate'></a>

`publicationDate` [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')

The date when the regulation act was published\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulationAct.RegulationAct(System.DateTime,System.DateTime,string,string,string).effectiveDate'></a>

`effectiveDate` [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')

The date when the regulation act becomes effective\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulationAct.RegulationAct(System.DateTime,System.DateTime,string,string,string).reference'></a>

`reference` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The reference identifier for the regulation act\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulationAct.RegulationAct(System.DateTime,System.DateTime,string,string,string).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the regulation act\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulationAct.RegulationAct(System.DateTime,System.DateTime,string,string,string).descriprion'></a>

`descriprion` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The description of the regulation act\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulationAct.RegulationAct(System.DateTime,System.DateTime,System.Nullable_System.DateTime_,string,string,string)'></a>

## RegulationAct\(DateTime, DateTime, Nullable\<DateTime\>, string, string, string\) Constructor

Initializes a new instance of the [RegulationAct](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulationAct 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulationAct') class whose requirements apply earlier to buildings of public authorities\.

```csharp
public RegulationAct(System.DateTime publicationDate, System.DateTime effectiveDate, System.Nullable<System.DateTime> publicAuthorityEffectiveDate, string? reference, string? name, string? descriprion);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulationAct.RegulationAct(System.DateTime,System.DateTime,System.Nullable_System.DateTime_,string,string,string).publicationDate'></a>

`publicationDate` [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')

The date when the regulation act was published\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulationAct.RegulationAct(System.DateTime,System.DateTime,System.Nullable_System.DateTime_,string,string,string).effectiveDate'></a>

`effectiveDate` [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')

The date from which the requirements apply\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulationAct.RegulationAct(System.DateTime,System.DateTime,System.Nullable_System.DateTime_,string,string,string).publicAuthorityEffectiveDate'></a>

`publicAuthorityEffectiveDate` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The earlier date from which the requirements apply to a building occupied and owned by a public authority, or null when the act sets none\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulationAct.RegulationAct(System.DateTime,System.DateTime,System.Nullable_System.DateTime_,string,string,string).reference'></a>

`reference` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The reference identifier for the regulation act\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulationAct.RegulationAct(System.DateTime,System.DateTime,System.Nullable_System.DateTime_,string,string,string).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the regulation act\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulationAct.RegulationAct(System.DateTime,System.DateTime,System.Nullable_System.DateTime_,string,string,string).descriprion'></a>

`descriprion` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The description of the regulation act\.

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulationAct.RegulationAct(System.Text.Json.Nodes.JsonObject)'></a>

## RegulationAct\(JsonObject\) Constructor

Initializes a new instance of the [RegulationAct](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.RegulationAct 'DiGi\.Analytical\.Building\.HVAC\.Classes\.RegulationAct') class using the provided [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')\.

```csharp
public RegulationAct(System.Text.Json.Nodes.JsonObject jsonObject);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulationAct.RegulationAct(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject') used to populate the properties of the regulation act\.
### Properties

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulationAct.Description'></a>

## RegulationAct\.Description Property

Gets the description of the regulation act\.

```csharp
public string? Description { get; }
```

Implements [Description](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.idescribableobject.description 'DiGi\.Core\.Interfaces\.IDescribableObject\.Description')

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulationAct.EffectiveDate'></a>

## RegulationAct\.EffectiveDate Property

Gets the date from which the requirements of the regulation act apply\.

For an act that sets its requirements in stages this is the date of the stage, not the date the act came into force: the 2017 U-value limits of Dz.U. 2013 poz. 926 apply from 1 January 2017 (DiGi-Organization/DiGi.Analytical#11).

```csharp
public System.DateTime EffectiveDate { get; }
```

#### Property Value
[System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulationAct.Name'></a>

## RegulationAct\.Name Property

Gets the name of the regulation act\.

```csharp
public string? Name { get; }
```

Implements [Name](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.inamedobject.name 'DiGi\.Core\.Interfaces\.INamedObject\.Name')

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulationAct.PublicationDate'></a>

## RegulationAct\.PublicationDate Property

Gets the publication date of the regulation act\.

```csharp
public System.DateTime PublicationDate { get; }
```

#### Property Value
[System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulationAct.PublicAuthorityEffectiveDate'></a>

## RegulationAct\.PublicAuthorityEffectiveDate Property

Gets the earlier date from which the requirements apply to a building occupied and owned by a public authority, or null when the act sets none\.

The last stage of the U-value limits applies from 31 December 2020, but from 1 January 2019 to a building occupied and owned by a judicial body, a prosecutor's office or a public administration body (Dz.U. 2017 poz. 2285, Annex 2).

```csharp
public System.Nullable<System.DateTime> PublicAuthorityEffectiveDate { get; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.Analytical.Building.HVAC.Classes.RegulationAct.Reference'></a>

## RegulationAct\.Reference Property

Gets the reference identifier for the regulation act\.

```csharp
public string? Reference { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.HVAC.Classes.SystemProperties'></a>

## SystemProperties Class

Represents the configuration properties for an HVAC system, encompassing parameters such as metabolic rate, domestic hot water usage, outside air requirements, and target illuminance\.

```csharp
public class SystemProperties : DiGi.Core.Parameter.Classes.ParametrizedObject, DiGi.Analytical.Building.HVAC.Interfaces.IHVACObject, DiGi.Analytical.Building.Interfaces.IBuildingObject, DiGi.Analytical.Interfaces.IAnalyticalObject, DiGi.Core.Interfaces.IObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Parameter\.Classes\.ParametrizedObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.parameter.classes.parametrizedobject 'DiGi\.Core\.Parameter\.Classes\.ParametrizedObject') → SystemProperties

Implements [IHVACObject](DiGi.Analytical.Building.HVAC.Interfaces.md#DiGi.Analytical.Building.HVAC.Interfaces.IHVACObject 'DiGi\.Analytical\.Building\.HVAC\.Interfaces\.IHVACObject'), [DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.ibuildingobject 'DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject'), [DiGi\.Analytical\.Interfaces\.IAnalyticalObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.interfaces.ianalyticalobject 'DiGi\.Analytical\.Interfaces\.IAnalyticalObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject')
### Constructors

<a name='DiGi.Analytical.Building.HVAC.Classes.SystemProperties.SystemProperties()'></a>

## SystemProperties\(\) Constructor

Initializes a new instance of the [SystemProperties](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.SystemProperties 'DiGi\.Analytical\.Building\.HVAC\.Classes\.SystemProperties') class\.

```csharp
public SystemProperties();
```

<a name='DiGi.Analytical.Building.HVAC.Classes.SystemProperties.SystemProperties(DiGi.Analytical.Building.HVAC.Classes.SystemProperties)'></a>

## SystemProperties\(SystemProperties\) Constructor

Initializes a new instance of the [SystemProperties](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.SystemProperties 'DiGi\.Analytical\.Building\.HVAC\.Classes\.SystemProperties') class using the properties of another [SystemProperties](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.SystemProperties 'DiGi\.Analytical\.Building\.HVAC\.Classes\.SystemProperties') instance\.

```csharp
public SystemProperties(DiGi.Analytical.Building.HVAC.Classes.SystemProperties? systemProperties);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.SystemProperties.SystemProperties(DiGi.Analytical.Building.HVAC.Classes.SystemProperties).systemProperties'></a>

`systemProperties` [SystemProperties](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.SystemProperties 'DiGi\.Analytical\.Building\.HVAC\.Classes\.SystemProperties')

The source [SystemProperties](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.SystemProperties 'DiGi\.Analytical\.Building\.HVAC\.Classes\.SystemProperties') instance to copy values from\. If null, the object is initialized with default values\.

<a name='DiGi.Analytical.Building.HVAC.Classes.SystemProperties.SystemProperties(System.Text.Json.Nodes.JsonObject)'></a>

## SystemProperties\(JsonObject\) Constructor

Initializes a new instance of the [SystemProperties](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.SystemProperties 'DiGi\.Analytical\.Building\.HVAC\.Classes\.SystemProperties') class using the specified JSON object\.

```csharp
public SystemProperties(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.SystemProperties.SystemProperties(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject') containing the system properties data, or [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.
### Properties

<a name='DiGi.Analytical.Building.HVAC.Classes.SystemProperties.DomesticHotWater'></a>

## SystemProperties\.DomesticHotWater Property

Gets or sets the domestic hot water usage in liters per day per square meter \[l/d/m2\]\.

```csharp
public double DomesticHotWater { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.HVAC.Classes.SystemProperties.MetabolicRate'></a>

## SystemProperties\.MetabolicRate Property

Gets or sets the metabolic rate \[W/p\]\.

```csharp
public double MetabolicRate { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.HVAC.Classes.SystemProperties.OutsideAir'></a>

## SystemProperties\.OutsideAir Property

Gets or sets the outside air flow rate in liters per second per person \[l/s/p\]\.

```csharp
public double OutsideAir { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.HVAC.Classes.SystemProperties.OutsideAirPerArea'></a>

## SystemProperties\.OutsideAirPerArea Property

Gets or sets the outside air flow rate per square meter of floor area \[l/\(s m2\)\] \(DiGi\-Organization/DiGi\.Analytical\#9\)\.

The Polish energy-certificate methodology sets the basic outside airflow per area of the heated zone (V_ve,1,s, Dz.U. 2015 poz. 376, Annex 1, Tables 23-25, in m3/(s m2)); this property holds it in l/(s m2), that value times 1000.

```csharp
public double OutsideAirPerArea { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.HVAC.Classes.SystemProperties.TargetIlluminance'></a>

## SystemProperties\.TargetIlluminance Property

Gets or sets the target illuminance \[lx\]\.

```csharp
public double TargetIlluminance { get; set; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.HVAC.Classes.Thermostat'></a>

## Thermostat Class

Represents a thermostat device used for controlling heating, ventilation, and air conditioning \(HVAC\) systems within a building analytical model\.

```csharp
public class Thermostat : DiGi.Core.Parameter.Classes.ParametrizedObject, DiGi.Analytical.Building.HVAC.Interfaces.IHVACNamedObject, DiGi.Analytical.Building.HVAC.Interfaces.IHVACObject, DiGi.Analytical.Building.Interfaces.IBuildingObject, DiGi.Analytical.Interfaces.IAnalyticalObject, DiGi.Core.Interfaces.IObject, DiGi.Analytical.Building.Interfaces.IBuildingNamedObject, DiGi.Core.Interfaces.INamedObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Parameter\.Classes\.ParametrizedObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.parameter.classes.parametrizedobject 'DiGi\.Core\.Parameter\.Classes\.ParametrizedObject') → Thermostat

Implements [IHVACNamedObject](DiGi.Analytical.Building.HVAC.Interfaces.md#DiGi.Analytical.Building.HVAC.Interfaces.IHVACNamedObject 'DiGi\.Analytical\.Building\.HVAC\.Interfaces\.IHVACNamedObject'), [IHVACObject](DiGi.Analytical.Building.HVAC.Interfaces.md#DiGi.Analytical.Building.HVAC.Interfaces.IHVACObject 'DiGi\.Analytical\.Building\.HVAC\.Interfaces\.IHVACObject'), [DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.ibuildingobject 'DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject'), [DiGi\.Analytical\.Interfaces\.IAnalyticalObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.interfaces.ianalyticalobject 'DiGi\.Analytical\.Interfaces\.IAnalyticalObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject'), [DiGi\.Analytical\.Building\.Interfaces\.IBuildingNamedObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.ibuildingnamedobject 'DiGi\.Analytical\.Building\.Interfaces\.IBuildingNamedObject'), [DiGi\.Core\.Interfaces\.INamedObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.inamedobject 'DiGi\.Core\.Interfaces\.INamedObject')
### Constructors

<a name='DiGi.Analytical.Building.HVAC.Classes.Thermostat.Thermostat()'></a>

## Thermostat\(\) Constructor

Initializes a new instance of the [Thermostat](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.Thermostat 'DiGi\.Analytical\.Building\.HVAC\.Classes\.Thermostat') class\.

```csharp
public Thermostat();
```

<a name='DiGi.Analytical.Building.HVAC.Classes.Thermostat.Thermostat(DiGi.Analytical.Building.HVAC.Classes.Thermostat)'></a>

## Thermostat\(Thermostat\) Constructor

Initializes a new instance of the [Thermostat](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.Thermostat 'DiGi\.Analytical\.Building\.HVAC\.Classes\.Thermostat') class by copying the properties and profiles from an existing thermostat instance\.

```csharp
public Thermostat(DiGi.Analytical.Building.HVAC.Classes.Thermostat? thermostat);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.Thermostat.Thermostat(DiGi.Analytical.Building.HVAC.Classes.Thermostat).thermostat'></a>

`thermostat` [Thermostat](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.Thermostat 'DiGi\.Analytical\.Building\.HVAC\.Classes\.Thermostat')

The source [Thermostat](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.Thermostat 'DiGi\.Analytical\.Building\.HVAC\.Classes\.Thermostat') instance to copy data from, or [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

<a name='DiGi.Analytical.Building.HVAC.Classes.Thermostat.Thermostat(System.Text.Json.Nodes.JsonObject)'></a>

## Thermostat\(JsonObject\) Constructor

Initializes a new instance of the [Thermostat](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.Thermostat 'DiGi\.Analytical\.Building\.HVAC\.Classes\.Thermostat') class using the specified JSON object\.

```csharp
public Thermostat(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.Thermostat.Thermostat(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject') containing the data used to initialize the thermostat instance\.
### Properties

<a name='DiGi.Analytical.Building.HVAC.Classes.Thermostat.Description'></a>

## Thermostat\.Description Property

Gets or sets the description of the thermostat\.

```csharp
public string? Description { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.HVAC.Classes.Thermostat.Name'></a>

## Thermostat\.Name Property

Gets or sets the name of the thermostat\.

```csharp
public string? Name { get; set; }
```

Implements [Name](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.inamedobject.name 'DiGi\.Core\.Interfaces\.INamedObject\.Name')

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.HVAC.Classes.Thermostat.this[DiGi.Analytical.Building.HVAC.Enums.ThermostatProfileType]'></a>

## Thermostat\.this\[ThermostatProfileType\] Property

Gets or sets the profile associated with the specified thermostat profile type\.

```csharp
public DiGi.Analytical.Building.Interfaces.IProfile? this[DiGi.Analytical.Building.HVAC.Enums.ThermostatProfileType thermostatProfileType] { get; set; }
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.Thermostat.this[DiGi.Analytical.Building.HVAC.Enums.ThermostatProfileType].thermostatProfileType'></a>

`thermostatProfileType` [ThermostatProfileType](DiGi.Analytical.Building.HVAC.Enums.md#DiGi.Analytical.Building.HVAC.Enums.ThermostatProfileType 'DiGi\.Analytical\.Building\.HVAC\.Enums\.ThermostatProfileType')

The type of the thermostat profile to retrieve or assign\.

#### Property Value
[DiGi\.Analytical\.Building\.Interfaces\.IProfile](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.iprofile 'DiGi\.Analytical\.Building\.Interfaces\.IProfile')

<a name='DiGi.Analytical.Building.HVAC.Classes.UsageProfile'></a>

## UsageProfile Class

Represents the standard use of a building of one usage type: heating set\-point, internal gains, outside airflow and hot water per area, with the source of every value \(DiGi\-Organization/DiGi\.Analytical\#9\)\.

Created by `Create.UsageProfile`, which holds the data and does the calculation; the constructor only assigns and copies. `Create.InternalCondition` turns a usage profile into an [DiGi\.Analytical\.Building\.Classes\.InternalCondition](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.classes.internalcondition 'DiGi\.Analytical\.Building\.Classes\.InternalCondition') for a building.

Every value has a source tag in [Sources](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.UsageProfile.Sources 'DiGi\.Analytical\.Building\.HVAC\.Classes\.UsageProfile\.Sources'), keyed by the property name: `PL-376` (Dz.U. 2015 poz. 376, Annex 1), `PL-WT` (Dz.U. 2022 poz. 1225, § 134), `ASHRAE-90.1` (ASHRAE Standard 90.1-1989 and addenda, via the Seattle Energy Code 2018, Appendix B) or `DEFAULT` (uncited, to be replaced), each followed by the table it comes from.

```csharp
public class UsageProfile : DiGi.Core.Classes.SerializableObject, DiGi.Analytical.Building.HVAC.Interfaces.IHVACObject, DiGi.Analytical.Building.Interfaces.IBuildingObject, DiGi.Analytical.Interfaces.IAnalyticalObject, DiGi.Core.Interfaces.IObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → UsageProfile

Implements [IHVACObject](DiGi.Analytical.Building.HVAC.Interfaces.md#DiGi.Analytical.Building.HVAC.Interfaces.IHVACObject 'DiGi\.Analytical\.Building\.HVAC\.Interfaces\.IHVACObject'), [DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.building.interfaces.ibuildingobject 'DiGi\.Analytical\.Building\.Interfaces\.IBuildingObject'), [DiGi\.Analytical\.Interfaces\.IAnalyticalObject](https://learn.microsoft.com/en-us/dotnet/api/digi.analytical.interfaces.ianalyticalobject 'DiGi\.Analytical\.Interfaces\.IAnalyticalObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject')
### Constructors

<a name='DiGi.Analytical.Building.HVAC.Classes.UsageProfile.UsageProfile(DiGi.Analytical.Building.HVAC.Classes.UsageProfile)'></a>

## UsageProfile\(UsageProfile\) Constructor

Initializes a new instance of the [UsageProfile](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.UsageProfile 'DiGi\.Analytical\.Building\.HVAC\.Classes\.UsageProfile') class by copying an existing instance\.

```csharp
public UsageProfile(DiGi.Analytical.Building.HVAC.Classes.UsageProfile? usageProfile);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.UsageProfile.UsageProfile(DiGi.Analytical.Building.HVAC.Classes.UsageProfile).usageProfile'></a>

`usageProfile` [UsageProfile](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.UsageProfile 'DiGi\.Analytical\.Building\.HVAC\.Classes\.UsageProfile')

The [UsageProfile](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.UsageProfile 'DiGi\.Analytical\.Building\.HVAC\.Classes\.UsageProfile') to copy\. This value can be null\.

<a name='DiGi.Analytical.Building.HVAC.Classes.UsageProfile.UsageProfile(DiGi.Analytical.Building.HVAC.Enums.UsageType,double,double,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,System.Collections.Generic.IDictionary_string,string_,string)'></a>

## UsageProfile\(UsageType, double, double, IEnumerable\<double\>, double, double, double, double, double, double, double, IDictionary\<string,string\>, string\) Constructor

Initializes a new instance of the [UsageProfile](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.UsageProfile 'DiGi\.Analytical\.Building\.HVAC\.Classes\.UsageProfile') class\.

The values are assigned as given and the profile and the sources are copied; `Create.UsageProfile` computes them.

```csharp
public UsageProfile(DiGi.Analytical.Building.HVAC.Enums.UsageType usageType, double heatingSetPoint, double internalHeatGain, System.Collections.Generic.IEnumerable<double>? internalHeatGainProfile, double outsideAirPerArea, double domesticHotWater, double domesticHotWaterCorrection, double floorAreaPerPerson, double personGain, double personLatentGain, double beta, System.Collections.Generic.IDictionary<string,string>? sources, string? source);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.UsageProfile.UsageProfile(DiGi.Analytical.Building.HVAC.Enums.UsageType,double,double,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,System.Collections.Generic.IDictionary_string,string_,string).usageType'></a>

`usageType` [UsageType](DiGi.Analytical.Building.HVAC.Enums.md#DiGi.Analytical.Building.HVAC.Enums.UsageType 'DiGi\.Analytical\.Building\.HVAC\.Enums\.UsageType')

The usage type\.

<a name='DiGi.Analytical.Building.HVAC.Classes.UsageProfile.UsageProfile(DiGi.Analytical.Building.HVAC.Enums.UsageType,double,double,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,System.Collections.Generic.IDictionary_string,string_,string).heatingSetPoint'></a>

`heatingSetPoint` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The heating set\-point \[°C\]\.

<a name='DiGi.Analytical.Building.HVAC.Classes.UsageProfile.UsageProfile(DiGi.Analytical.Building.HVAC.Enums.UsageType,double,double,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,System.Collections.Generic.IDictionary_string,string_,string).internalHeatGain'></a>

`internalHeatGain` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The mean internal heat gain q\_int \[W/m2\]\.

<a name='DiGi.Analytical.Building.HVAC.Classes.UsageProfile.UsageProfile(DiGi.Analytical.Building.HVAC.Enums.UsageType,double,double,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,System.Collections.Generic.IDictionary_string,string_,string).internalHeatGainProfile'></a>

`internalHeatGainProfile` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The weekly profile of the internal heat gain \[W/m2\], 168 values from Monday 0:00, whose mean is [internalHeatGain](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.UsageProfile.UsageProfile(DiGi.Analytical.Building.HVAC.Enums.UsageType,double,double,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,System.Collections.Generic.IDictionary_string,string_,string).internalHeatGain 'DiGi\.Analytical\.Building\.HVAC\.Classes\.UsageProfile\.UsageProfile\(DiGi\.Analytical\.Building\.HVAC\.Enums\.UsageType, double, double, System\.Collections\.Generic\.IEnumerable\<double\>, double, double, double, double, double, double, double, System\.Collections\.Generic\.IDictionary\<string,string\>, string\)\.internalHeatGain'); null when the gain is constant\.

<a name='DiGi.Analytical.Building.HVAC.Classes.UsageProfile.UsageProfile(DiGi.Analytical.Building.HVAC.Enums.UsageType,double,double,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,System.Collections.Generic.IDictionary_string,string_,string).outsideAirPerArea'></a>

`outsideAirPerArea` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The basic outside airflow during use \[l/\(s m2\)\]\.

<a name='DiGi.Analytical.Building.HVAC.Classes.UsageProfile.UsageProfile(DiGi.Analytical.Building.HVAC.Enums.UsageType,double,double,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,System.Collections.Generic.IDictionary_string,string_,string).domesticHotWater'></a>

`domesticHotWater` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The unit daily hot water demand V\_Wi \[dm3/\(m2 d\)\]\.

<a name='DiGi.Analytical.Building.HVAC.Classes.UsageProfile.UsageProfile(DiGi.Analytical.Building.HVAC.Enums.UsageType,double,double,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,System.Collections.Generic.IDictionary_string,string_,string).domesticHotWaterCorrection'></a>

`domesticHotWaterCorrection` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The correction for breaks in hot water use k\_R \[\-\]\.

<a name='DiGi.Analytical.Building.HVAC.Classes.UsageProfile.UsageProfile(DiGi.Analytical.Building.HVAC.Enums.UsageType,double,double,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,System.Collections.Generic.IDictionary_string,string_,string).floorAreaPerPerson'></a>

`floorAreaPerPerson` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The floor area per person of the standard occupancy \[m2/person\]\.

<a name='DiGi.Analytical.Building.HVAC.Classes.UsageProfile.UsageProfile(DiGi.Analytical.Building.HVAC.Enums.UsageType,double,double,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,System.Collections.Generic.IDictionary_string,string_,string).personGain'></a>

`personGain` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The sensible heat gain per person \[W/person\]\.

<a name='DiGi.Analytical.Building.HVAC.Classes.UsageProfile.UsageProfile(DiGi.Analytical.Building.HVAC.Enums.UsageType,double,double,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,System.Collections.Generic.IDictionary_string,string_,string).personLatentGain'></a>

`personLatentGain` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The latent heat gain per person \[W/person\]\.

<a name='DiGi.Analytical.Building.HVAC.Classes.UsageProfile.UsageProfile(DiGi.Analytical.Building.HVAC.Enums.UsageType,double,double,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,System.Collections.Generic.IDictionary_string,string_,string).beta'></a>

`beta` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The share of the time the building is in use, β \[\-\]; NaN when the internal gain does not depend on it\.

<a name='DiGi.Analytical.Building.HVAC.Classes.UsageProfile.UsageProfile(DiGi.Analytical.Building.HVAC.Enums.UsageType,double,double,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,System.Collections.Generic.IDictionary_string,string_,string).sources'></a>

`sources` [System\.Collections\.Generic\.IDictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2 'System\.Collections\.Generic\.IDictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2 'System\.Collections\.Generic\.IDictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2 'System\.Collections\.Generic\.IDictionary\`2')

The source tag of every value, keyed by property name\. This value can be null\.

<a name='DiGi.Analytical.Building.HVAC.Classes.UsageProfile.UsageProfile(DiGi.Analytical.Building.HVAC.Enums.UsageType,double,double,System.Collections.Generic.IEnumerable_double_,double,double,double,double,double,double,double,System.Collections.Generic.IDictionary_string,string_,string).source'></a>

`source` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The sources as text\. This value can be null\.

<a name='DiGi.Analytical.Building.HVAC.Classes.UsageProfile.UsageProfile(System.Text.Json.Nodes.JsonObject)'></a>

## UsageProfile\(JsonObject\) Constructor

Initializes a new instance of the [UsageProfile](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.UsageProfile 'DiGi\.Analytical\.Building\.HVAC\.Classes\.UsageProfile') class from a JSON object\.

```csharp
public UsageProfile(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.Analytical.Building.HVAC.Classes.UsageProfile.UsageProfile(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the data\. This value can be null\.
### Properties

<a name='DiGi.Analytical.Building.HVAC.Classes.UsageProfile.Beta'></a>

## UsageProfile\.Beta Property

Gets the share of the time the building is in use, β \[\-\]; NaN when the internal gain does not depend on it\.

```csharp
public double Beta { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.HVAC.Classes.UsageProfile.DomesticHotWater'></a>

## UsageProfile\.DomesticHotWater Property

Gets the unit daily hot water demand V\_Wi \[dm3/\(m2 d\)\]\.

```csharp
public double DomesticHotWater { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.HVAC.Classes.UsageProfile.DomesticHotWaterCorrection'></a>

## UsageProfile\.DomesticHotWaterCorrection Property

Gets the correction for breaks in hot water use k\_R \[\-\]\.

```csharp
public double DomesticHotWaterCorrection { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.HVAC.Classes.UsageProfile.FloorAreaPerPerson'></a>

## UsageProfile\.FloorAreaPerPerson Property

Gets the floor area per person of the standard occupancy \[m2/person\] \- the occupancy the per\-area values stand for\.

```csharp
public double FloorAreaPerPerson { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.HVAC.Classes.UsageProfile.HeatingSetPoint'></a>

## UsageProfile\.HeatingSetPoint Property

Gets the heating set\-point \[°C\]\.

```csharp
public double HeatingSetPoint { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.HVAC.Classes.UsageProfile.InternalHeatGain'></a>

## UsageProfile\.InternalHeatGain Property

Gets the mean internal heat gain q\_int \[W/m2\]: people, lighting and equipment together\.

```csharp
public double InternalHeatGain { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.HVAC.Classes.UsageProfile.InternalHeatGainProfile'></a>

## UsageProfile\.InternalHeatGainProfile Property

Gets a copy of the weekly profile of the internal heat gain \[W/m2\], 168 values from Monday 0:00 whose mean is [InternalHeatGain](DiGi.Analytical.Building.HVAC.Classes.md#DiGi.Analytical.Building.HVAC.Classes.UsageProfile.InternalHeatGain 'DiGi\.Analytical\.Building\.HVAC\.Classes\.UsageProfile\.InternalHeatGain'), or null when the gain is constant\.

```csharp
public System.Collections.Generic.List<double>? InternalHeatGainProfile { get; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.Analytical.Building.HVAC.Classes.UsageProfile.OutsideAirPerArea'></a>

## UsageProfile\.OutsideAirPerArea Property

Gets the basic outside airflow during use \[l/\(s m2\)\]\.

```csharp
public double OutsideAirPerArea { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.HVAC.Classes.UsageProfile.PersonGain'></a>

## UsageProfile\.PersonGain Property

Gets the sensible heat gain per person \[W/person\]\.

```csharp
public double PersonGain { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.HVAC.Classes.UsageProfile.PersonLatentGain'></a>

## UsageProfile\.PersonLatentGain Property

Gets the latent heat gain per person \[W/person\]\.

```csharp
public double PersonLatentGain { get; }
```

#### Property Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.HVAC.Classes.UsageProfile.Source'></a>

## UsageProfile\.Source Property

Gets the sources of the values as text\.

```csharp
public string? Source { get; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.HVAC.Classes.UsageProfile.Sources'></a>

## UsageProfile\.Sources Property

Gets a copy of the source tag of every value, keyed by property name, or null\.

```csharp
public System.Collections.Generic.Dictionary<string,string>? Sources { get; }
```

#### Property Value
[System\.Collections\.Generic\.Dictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2 'System\.Collections\.Generic\.Dictionary\`2')

<a name='DiGi.Analytical.Building.HVAC.Classes.UsageProfile.UsageType'></a>

## UsageProfile\.UsageType Property

Gets the usage type\.

```csharp
public DiGi.Analytical.Building.HVAC.Enums.UsageType UsageType { get; }
```

#### Property Value
[UsageType](DiGi.Analytical.Building.HVAC.Enums.md#DiGi.Analytical.Building.HVAC.Enums.UsageType 'DiGi\.Analytical\.Building\.HVAC\.Enums\.UsageType')