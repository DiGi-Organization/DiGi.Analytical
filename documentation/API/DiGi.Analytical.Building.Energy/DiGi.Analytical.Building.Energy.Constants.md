#### [DiGi\.Analytical\.Building\.Energy](DiGi.Analytical.Building.Energy.Overview.md 'DiGi\.Analytical\.Building\.Energy\.Overview')

## DiGi\.Analytical\.Building\.Energy\.Constants Namespace
### Classes

<a name='DiGi.Analytical.Building.Energy.Constants.Default'></a>

## Default Class

The defaults of the monthly heat demand \(DiGi\-Organization/DiGi\.Analytical\#21\)\. Each value names its source \([Source](DiGi.Analytical.Building.Energy.Constants.md#DiGi.Analytical.Building.Energy.Constants.Source 'DiGi\.Analytical\.Building\.Energy\.Constants\.Source')\); a value marked `DEFAULT` is a decided default with no cited source, to be calibrated\.

```csharp
public static class Default
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Default
### Fields

<a name='DiGi.Analytical.Building.Energy.Constants.Default.AirHeatCapacity'></a>

## Default\.AirHeatCapacity Field

The heat capacity of air per volume, ρ\_a·c\_a = 1200 J/\(m3K\) \([Ventilation](DiGi.Analytical.Building.Energy.Constants.md#DiGi.Analytical.Building.Energy.Constants.Source.Ventilation 'DiGi\.Analytical\.Building\.Energy\.Constants\.Source\.Ventilation')\)\.

```csharp
public const double AirHeatCapacity = 1200;
```

#### Field Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Constants.Default.ExternalEmissivity'></a>

## Default\.ExternalEmissivity Field

The emissivity for thermal radiation of external surfaces, ε = 0\.9, which gives h\_r = 5·ε = 4\.5 W/\(m2K\) \([SkyRadiation](DiGi.Analytical.Building.Energy.Constants.md#DiGi.Analytical.Building.Energy.Constants.Source.SkyRadiation 'DiGi\.Analytical\.Building\.Energy\.Constants\.Source\.SkyRadiation')\)\. `DEFAULT` for ε\.

```csharp
public const double ExternalEmissivity = 0.9;
```

#### Field Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Constants.Default.FrameAreaFraction'></a>

## Default\.FrameAreaFraction Field

The frame area fraction F\_f = 0\.30, the glazed area of an opening whose construction has no panes being \(1 − F\_f\)·A\_w, used when the typology data gives none: the fixed value the source names for heating\-dominated climates \([SolarGlazed](DiGi.Analytical.Building.Energy.Constants.md#DiGi.Analytical.Building.Energy.Constants.Source.SolarGlazed 'DiGi\.Analytical\.Building\.Energy\.Constants\.Source\.SolarGlazed'), 11\.4\.5\) and TABULA's value\.

```csharp
public const double FrameAreaFraction = 0.3;
```

#### Field Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Constants.Default.GroundTemperatureVariationFactor'></a>

## Default\.GroundTemperatureVariationFactor Field

The correction factor f\_g1 = 1\.45 of the annual variation of the outdoor temperature in the ground heat loss of the design heat load \([DesignHeatLoad](DiGi.Analytical.Building.Energy.Constants.md#DiGi.Analytical.Building.Energy.Constants.Source.DesignHeatLoad 'DiGi\.Analytical\.Building\.Energy\.Constants\.Source\.DesignHeatLoad')\)\.

```csharp
public const double GroundTemperatureVariationFactor = 1.45;
```

#### Field Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Constants.Default.GroundThermalConductivity'></a>

## Default\.GroundThermalConductivity Field

The thermal conductivity of the ground, λ\_g = 2\.0 W/\(mK\): sand or gravel, the value PN\-EN ISO 13370 uses when the soil is not known \([Ground](DiGi.Analytical.Building.Energy.Constants.md#DiGi.Analytical.Building.Energy.Constants.Source.Ground 'DiGi\.Analytical\.Building\.Energy\.Constants\.Source\.Ground')\)\.

```csharp
public const double GroundThermalConductivity = 2;
```

#### Field Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Constants.Default.GroundWallThickness'></a>

## Default\.GroundWallThickness Field

The thickness of the external walls, w = 0\.30 m, used in the equivalent thickness of a ground floor when no external wall has layers\. `DEFAULT`\.

```csharp
public const double GroundWallThickness = 0.3;
```

#### Field Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Constants.Default.HeatDemandMethodVersion'></a>

## Default\.HeatDemandMethodVersion Field

The version of the heat\-demand method that stored results are keyed by \(`building_data.heat_demand_method_version`\)\. Bump it whenever the method, a default or an input rule changes, so that results of an older version are recomputed\.

```csharp
public const int HeatDemandMethodVersion = 1;
```

#### Field Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.Analytical.Building.Energy.Constants.Default.InsulationThermalConductivity'></a>

## Default\.InsulationThermalConductivity Field

The thermal conductivity, in W/\(mK\), at or below which a layer is an insulating layer that ends the effective thickness of the internal heat capacity \(PN\-EN ISO 13786 Annex A\)\. `DEFAULT`\.

```csharp
public const double InsulationThermalConductivity = 0.1;
```

#### Field Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Constants.Default.InternalHeatCapacityMaximumThickness'></a>

## Default\.InternalHeatCapacityMaximumThickness Field

The maximum thickness, from each face, counted in the internal heat capacity of a building element, 0\.10 m for a one\-day period of variation \([InternalHeatCapacity](DiGi.Analytical.Building.Energy.Constants.md#DiGi.Analytical.Building.Energy.Constants.Source.InternalHeatCapacity 'DiGi\.Analytical\.Building\.Energy\.Constants\.Source\.InternalHeatCapacity'), Table 11\)\.

```csharp
public const double InternalHeatCapacityMaximumThickness = 0.1;
```

#### Field Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Constants.Default.LevelTolerance'></a>

## Default\.LevelTolerance Field

The height, in m, within which a floor carried by the external shell counts as standing at the lowest level of the building and so as a floor on the ground\. `DEFAULT`\.

```csharp
public const double LevelTolerance = 0.1;
```

#### Field Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Constants.Default.NonPerpendicularIncidenceFactor'></a>

## Default\.NonPerpendicularIncidenceFactor Field

The correction of the glazing's solar transmittance at normal incidence for non\-perpendicular incidence, F\_w = 0\.90, used when the typology data gives none \([SolarGlazed](DiGi.Analytical.Building.Energy.Constants.md#DiGi.Analytical.Building.Energy.Constants.Source.SolarGlazed 'DiGi\.Analytical\.Building\.Energy\.Constants\.Source\.SolarGlazed'), Eq\. \(48\)\)\.

```csharp
public const double NonPerpendicularIncidenceFactor = 0.9;
```

#### Field Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Constants.Default.OpaqueSolarAbsorptance'></a>

## Default\.OpaqueSolarAbsorptance Field

The absorption coefficient for solar radiation of opaque external surfaces, α = 0\.6: a medium colour\. The source gives no default \("from appropriate national sources", [SolarOpaque](DiGi.Analytical.Building.Energy.Constants.md#DiGi.Analytical.Building.Energy.Constants.Source.SolarOpaque 'DiGi\.Analytical\.Building\.Energy\.Constants\.Source\.SolarOpaque')\)\. `DEFAULT`\.

```csharp
public const double OpaqueSolarAbsorptance = 0.6;
```

#### Field Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Constants.Default.RoofSkyFormFactor'></a>

## Default\.RoofSkyFormFactor Field

The form factor between an unshaded horizontal roof and the sky, F\_r = 1\.0 \([SkyRadiation](DiGi.Analytical.Building.Energy.Constants.md#DiGi.Analytical.Building.Energy.Constants.Source.SkyRadiation 'DiGi\.Analytical\.Building\.Energy\.Constants\.Source\.SkyRadiation')\)\. It is applied to every roof, pitched or flat\.

```csharp
public const double RoofSkyFormFactor = 1;
```

#### Field Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Constants.Default.SkyTemperatureDifference'></a>

## Default\.SkyTemperatureDifference Field

The average difference between the external air temperature and the apparent sky temperature, Δθ\_er = 11 K, the value for intermediate climatic zones \([SkyRadiation](DiGi.Analytical.Building.Energy.Constants.md#DiGi.Analytical.Building.Energy.Constants.Source.SkyRadiation 'DiGi\.Analytical\.Building\.Energy\.Constants\.Source\.SkyRadiation')\)\.

```csharp
public const double SkyTemperatureDifference = 11;
```

#### Field Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Constants.Default.ThermalBridgingSurcharge'></a>

## Default\.ThermalBridgingSurcharge Field

The thermal bridging surcharge ΔU\_tb = 0\.10 W/\(m2K\), the middle of TABULA's 0\.05\-0\.15 range, used when the typology data gives none\. `DEFAULT`\.

```csharp
public const double ThermalBridgingSurcharge = 0.1;
```

#### Field Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Constants.Default.UtilisationNumericalParameter'></a>

## Default\.UtilisationNumericalParameter Field

The dimensionless reference numerical parameter of the gain utilisation factor for heating, a\_H,0 = 1\.0 for the monthly method \([GainUtilisation](DiGi.Analytical.Building.Energy.Constants.md#DiGi.Analytical.Building.Energy.Constants.Source.GainUtilisation 'DiGi\.Analytical\.Building\.Energy\.Constants\.Source\.GainUtilisation'), Table 9\)\.

```csharp
public const double UtilisationNumericalParameter = 1;
```

#### Field Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Constants.Default.UtilisationReferenceTimeConstant'></a>

## Default\.UtilisationReferenceTimeConstant Field

The reference time constant of the gain utilisation factor for heating, τ\_H,0 = 15 h for the monthly method \([GainUtilisation](DiGi.Analytical.Building.Energy.Constants.md#DiGi.Analytical.Building.Energy.Constants.Source.GainUtilisation 'DiGi\.Analytical\.Building\.Energy\.Constants\.Source\.GainUtilisation'), Table 9\)\.

```csharp
public const double UtilisationReferenceTimeConstant = 15;
```

#### Field Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Constants.Default.WallSkyFormFactor'></a>

## Default\.WallSkyFormFactor Field

The form factor between an unshaded vertical wall and the sky, F\_r = 0\.5 \([SkyRadiation](DiGi.Analytical.Building.Energy.Constants.md#DiGi.Analytical.Building.Energy.Constants.Source.SkyRadiation 'DiGi\.Analytical\.Building\.Energy\.Constants\.Source\.SkyRadiation')\)\.

```csharp
public const double WallSkyFormFactor = 0.5;
```

#### Field Value
[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

<a name='DiGi.Analytical.Building.Energy.Constants.Source'></a>

## Source Class

The source tags of the monthly heat demand \(DiGi\-Organization/DiGi\.Analytical\#21\)\. None of the standards is in hand, so every equation and default is tagged with the public reproduction it was taken from and counts as not checked against the original \(wiki \<i\>Required Standards\</i\>\)\.

```csharp
public static class Source
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → Source
### Fields

<a name='DiGi.Analytical.Building.Energy.Constants.Source.Cellar'></a>

## Source\.Cellar Field

The floor over an unheated cellar, from the TABULA typology data of the building\.

```csharp
public const string Cellar = "TABULA additional floor resistance and temperature reduction factor (TypologyData)";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.Energy.Constants.Source.DesignHeatLoad'></a>

## Source\.DesignHeatLoad Field

The design heat load of PN\-EN 12831\-1, simplified\.

```csharp
public const string DesignHeatLoad = "PN-EN 12831-1 simplified, from secondary knowledge (f_g1 = 1.45, f_g2 = (θ_int − θ_m,e) / (θ_int − θ_e)); θ_e and θ_m,e per zone as reproduced in Strzeszewski and Wereszczyński (Purmo 2009), Table 2.1";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.Energy.Constants.Source.GainUtilisation'></a>

## Source\.GainUtilisation Field

The gain utilisation factor, Equations \(53\) to \(57\), and the numerical parameter a\_H,0 = 1 and reference time constant τ\_H,0 = 15 h of the monthly method, Table 9\.

```csharp
public const string GainUtilisation = "PN-EN ISO 52016-1 as reproduced in ISO/FDIS 13790:2007, 12.2.1.1, Eq. (53)-(57), Table 9";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.Energy.Constants.Source.Ground'></a>

## Source\.Ground Field

Heat transfer through a slab on ground in the steady state\.

```csharp
public const string Ground = "PN-EN ISO 13370 slab on ground (steady state), from secondary knowledge; conventions (λ_g = 2.0 for sand/gravel, R_f without R_si, party walls out of the exposed perimeter) as reproduced in BRE BR 443 (2019), chapter 9";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.Energy.Constants.Source.InternalHeatCapacity'></a>

## Source\.InternalHeatCapacity Field

The internal heat capacity C\_m = Σ κ\_j·A\_j, Equation \(67\), κ\_j per ISO 13786 Annex A up to 0\.10 m, Table 11\.

```csharp
public const string InternalHeatCapacity = "PN-EN ISO 52016-1 as reproduced in ISO/FDIS 13790:2007, 12.3.1.1, Eq. (67), Table 11; κ per PN-EN ISO 13786 Annex A (simplified), from secondary knowledge";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.Energy.Constants.Source.Method'></a>

## Source\.Method Field

The monthly quasi\-steady method\. ISO/TR 52016\-2:2017, 5\.2\.4 \(public preview at sis\.se\) states that the monthly method of ISO 52016\-1 "is basically the same as the monthly method in ISO 13790"; its listed differences \(intermittent heating, unconditioned adjacent zones, sunspaces, the free\-floating temperature, overheating\) are outside a continuously heated single zone\. The equations are therefore those of ISO 13790 as reproduced in its approval draft ISO/FDIS 13790:2007 \(public copy, ETH Zürich OptiControl literature\)\.

```csharp
public const string Method = "PN-EN ISO 52016-1 monthly method as reproduced in ISO/FDIS 13790:2007 (via ISO/TR 52016-2:2017, 5.2.4)";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.Energy.Constants.Source.SkyRadiation'></a>

## Source\.SkyRadiation Field

The extra heat flow by thermal radiation to the sky, Equations \(44\) and \(47\): F\_r·R\_se·U·A·h\_r·Δθ\_er, subtracted from the solar gains; h\_r = 5·ε, Δθ\_er = 11 K in intermediate zones, F\_r = 1 for a roof and 0\.5 for a wall\.

```csharp
public const string SkyRadiation = "PN-EN ISO 52016-1 as reproduced in ISO/FDIS 13790:2007, 11.3.5, 11.4.6, Eq. (44), (47)";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.Energy.Constants.Source.SolarGlazed'></a>

## Source\.SolarGlazed Field

The solar gains of glazed elements, Equations \(44\), \(45\) and \(48\): F\_w·g\_gl,n·\(1 − F\_f\)·A\_w·I, with F\_w = 0\.90 in absence of national values\.

```csharp
public const string SolarGlazed = "PN-EN ISO 52016-1 as reproduced in ISO/FDIS 13790:2007, 11.3.3, Eq. (45), (48)";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.Energy.Constants.Source.SolarOpaque'></a>

## Source\.SolarOpaque Field

The solar gains of opaque elements, Equation \(46\): α·R\_se·U·A·I\.

```csharp
public const string SolarOpaque = "PN-EN ISO 52016-1 as reproduced in ISO/FDIS 13790:2007, 11.3.4, Eq. (46)";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.Energy.Constants.Source.ThermalBridges'></a>

## Source\.ThermalBridges Field

The thermal bridging surcharge ΔU\_tb on the area of every heat\-loss element\.

```csharp
public const string ThermalBridges = "TABULA ΔU_tb surcharge (TypologyData.ThermalBridgingSurcharge)";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.Energy.Constants.Source.TimeConstant'></a>

## Source\.TimeConstant Field

The building time constant τ = \(C\_m / 3600\) / \(H\_tr \+ H\_ve\), Equation \(63\)\.

```csharp
public const string TimeConstant = "PN-EN ISO 52016-1 as reproduced in ISO/FDIS 13790:2007, 12.2.1.3, Eq. (63)";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.Analytical.Building.Energy.Constants.Source.Ventilation'></a>

## Source\.Ventilation Field

The ventilation heat transfer coefficient H\_ve = ρ\_a·c\_a·\(q\_ve \+ n\_inf·V / 3600\), ρ\_a·c\_a = 1200 J/\(m3K\)\.

```csharp
public const string Ventilation = "Dz.U. 2015 poz. 376, Annex 1, Eq. (57) (ρ_a·c_a = 1200 J/(m3K)); airflows of the usage profile (DiGi-Organization/DiGi.Analytical#9)";
```

#### Field Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')