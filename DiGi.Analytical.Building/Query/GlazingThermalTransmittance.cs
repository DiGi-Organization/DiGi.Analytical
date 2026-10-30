using DiGi.Analytical.Building.Enums;
using DiGi.Analytical.Building.Interfaces;
using DiGi.Analytical.Classes;
using DiGi.Analytical.Interfaces;
using System;
using System.Collections.Generic;

namespace DiGi.Analytical.Building
{
    public static partial class Query
    {
        /// <summary>
        /// Calculates the centre-of-glass thermal transmittance Ug of a glazing unit per EN 673 (DiGi-Organization/DiGi.Analytical#8).
        /// <para>The layers run from the outside inwards and alternate glass and gas: glass (<see cref="TransparentMaterial"/>), gas (<see cref="FluidMaterial"/>), glass…, with one to four panes. 1/Ug = 1/he + Σ d/λ + Σ 1/hs + 1/hi, with he = 23 W/(m2K) and hi = 3.6 + 4.4·ε/0.837 W/(m2K), ε being the emissivity of the inner face of the innermost pane (8 for uncoated glass). The conductance of each gas space hs = hr + hg combines radiation, hr = 4σ·(1/ε1 + 1/ε2 − 1)⁻¹·Tm³ with the emissivities of the two faces bounding the space, and gas conduction and convection, hg = Nu·λ/s with Nu = A·(Gr·Pr)ⁿ and at least 1. The gas properties are taken at the mean temperature (<see cref="Analytical.Query.FluidProperties(FluidMaterial?, double)"/>).</para>
        /// <para>The Nusselt constants follow the inclination: vertical glazing (horizontal heat flow) A = 0.035, n = 0.38; horizontal glazing with heat flowing upward A = 0.16, n = 0.28; with heat flowing downward there is no convection, Nu = 1. The 45° constants (A = 0.10, n = 0.31) have no <see cref="HeatFlowDirection"/>. Source of he, hi and the Nusselt constants: PN-EN 673 as quoted by Z. Respondek, "Przejmowanie ciepła w szybach zespolonych" (oknoserwis.pl, 2008) and Świat Szkła; the mean temperature 283 K and the temperature difference 15 K are the usual EN 673 declared-value conditions, not confirmed against the standard text.</para>
        /// <para>With two or more gas spaces the temperature difference is shared between them in proportion to their resistances, iterated to convergence - this interpretation is not confirmed against the standard text either.</para>
        /// <para>The result is <see cref="double.NaN"/> when the layer sequence is not glass-gas-glass, a glass has no conductivity or no emissivity, a glass transmits thermal infrared (<see cref="TransparentMaterial.InfraredTransmittance"/> above 0: ISO 15099 is needed), a gas has a property of 0 or less, a thickness is not above 0, or the direction is undefined.</para>
        /// </summary>
        /// <param name="structureLayers">The layers of the glazing unit with their materials, from the outside inwards. This value can be null.</param>
        /// <param name="heatFlowDirection">The direction of the heat flow: <see cref="HeatFlowDirection.Horizontal"/> for vertical glazing.</param>
        /// <param name="meanTemperature">The mean temperature of the glazing Tm [K].</param>
        /// <param name="temperatureDifference">The temperature difference across the gas spaces ΔT [K].</param>
        /// <returns>The thermal transmittance Ug [W/(m2K)], or <see cref="double.NaN"/> when it cannot be determined.</returns>
        public static double GlazingThermalTransmittance(IEnumerable<(IStructureLayer StructureLayer, IMaterial? Material)>? structureLayers, HeatFlowDirection heatFlowDirection = HeatFlowDirection.Horizontal, double meanTemperature = 283.0, double temperatureDifference = 15.0)
        {
            if (structureLayers is null || heatFlowDirection == HeatFlowDirection.Undefined || double.IsNaN(meanTemperature) || meanTemperature <= 0 || double.IsNaN(temperatureDifference) || temperatureDifference < 0)
            {
                return double.NaN;
            }

            List<(IStructureLayer StructureLayer, IMaterial? Material)> layers = [.. structureLayers];
            if (layers.Count == 0 || layers.Count % 2 == 0 || layers.Count > 7)
            {
                return double.NaN;
            }

            const double stefanBoltzmannConstant = 5.67e-8;
            const double gravitationalAcceleration = 9.81;

            double thermalResistance_Glass = 0;
            List<(double Thickness, double Conductivity, double Density, double DynamicViscosity, double SpecificHeat, double RadiativeConductance)> gasSpaces = [];
            double emissivity_Inner = double.NaN;

            for (int i = 0; i < layers.Count; i++)
            {
                (IStructureLayer structureLayer, IMaterial? material) = layers[i];
                double thickness = structureLayer?.Thickness ?? double.NaN;
                if (double.IsNaN(thickness) || thickness <= 0)
                {
                    return double.NaN;
                }

                if (i % 2 == 0)
                {
                    if (material is not TransparentMaterial transparentMaterial || transparentMaterial.Conductivity <= 0 || transparentMaterial.InfraredTransmittance > 0 || transparentMaterial.Emissivity is not SurfaceValue emissivity)
                    {
                        return double.NaN;
                    }

                    if (emissivity.External <= 0 || emissivity.External > 1 || emissivity.Internal <= 0 || emissivity.Internal > 1)
                    {
                        return double.NaN;
                    }

                    thermalResistance_Glass += thickness / transparentMaterial.Conductivity;
                    emissivity_Inner = emissivity.Internal;
                    continue;
                }

                if (material is not FluidMaterial fluidMaterial)
                {
                    return double.NaN;
                }

                (double conductivity, double density, double dynamicViscosity, double specificHeat) = fluidMaterial.FluidProperties(meanTemperature);
                if (!(conductivity > 0) || !(density > 0) || !(dynamicViscosity > 0) || !(specificHeat > 0))
                {
                    return double.NaN;
                }

                // The faces bounding the gas space: the back of the pane outside it and the front of the pane inside it.
                double emissivity_1 = ((TransparentMaterial)layers[i - 1].Material!).Emissivity!.Internal;
                if (layers[i + 1].Material is not TransparentMaterial { Emissivity: SurfaceValue emissivity_Next })
                {
                    return double.NaN;
                }

                double emissivity_2 = emissivity_Next.External;
                if (emissivity_2 <= 0 || emissivity_2 > 1)
                {
                    return double.NaN;
                }

                double radiativeConductance = 4 * stefanBoltzmannConstant * Math.Pow(meanTemperature, 3) / ((1 / emissivity_1) + (1 / emissivity_2) - 1);
                gasSpaces.Add((thickness, conductivity, density, dynamicViscosity, specificHeat, radiativeConductance));
            }

            (double A, double N)? nusseltConstants = heatFlowDirection switch
            {
                HeatFlowDirection.Horizontal => (0.035, 0.38),
                HeatFlowDirection.Upward => (0.16, 0.28),
                _ => null,
            };

            double Conductance((double Thickness, double Conductivity, double Density, double DynamicViscosity, double SpecificHeat, double RadiativeConductance) gasSpace, double temperatureDifference_GasSpace)
            {
                double nusseltNumber = 1;
                if (nusseltConstants is (double a, double n))
                {
                    double grashofNumber = gravitationalAcceleration * Math.Pow(gasSpace.Thickness, 3) * temperatureDifference_GasSpace * gasSpace.Density * gasSpace.Density / (meanTemperature * gasSpace.DynamicViscosity * gasSpace.DynamicViscosity);
                    double prandtlNumber = gasSpace.DynamicViscosity * gasSpace.SpecificHeat / gasSpace.Conductivity;
                    nusseltNumber = Math.Max(1.0, a * Math.Pow(grashofNumber * prandtlNumber, n));
                }

                return (nusseltNumber * gasSpace.Conductivity / gasSpace.Thickness) + gasSpace.RadiativeConductance;
            }

            double thermalResistance_GasSpaces = 0;
            if (gasSpaces.Count != 0)
            {
                double[] temperatureDifferences = new double[gasSpaces.Count];
                double[] thermalResistances = new double[gasSpaces.Count];
                for (int i = 0; i < gasSpaces.Count; i++)
                {
                    temperatureDifferences[i] = temperatureDifference / gasSpaces.Count;
                }

                for (int iteration = 0; iteration < 100; iteration++)
                {
                    thermalResistance_GasSpaces = 0;
                    for (int i = 0; i < gasSpaces.Count; i++)
                    {
                        thermalResistances[i] = 1.0 / Conductance(gasSpaces[i], temperatureDifferences[i]);
                        thermalResistance_GasSpaces += thermalResistances[i];
                    }

                    double change = 0;
                    for (int i = 0; i < gasSpaces.Count; i++)
                    {
                        double temperatureDifference_New = temperatureDifference * thermalResistances[i] / thermalResistance_GasSpaces;
                        change = Math.Max(change, Math.Abs(temperatureDifference_New - temperatureDifferences[i]));
                        temperatureDifferences[i] = temperatureDifference_New;
                    }

                    if (change < 1e-9)
                    {
                        break;
                    }
                }
            }

            double externalSurfaceConductance = 23.0;
            double internalSurfaceConductance = 3.6 + (4.4 * emissivity_Inner / 0.837);

            return 1.0 / ((1.0 / externalSurfaceConductance) + thermalResistance_Glass + thermalResistance_GasSpaces + (1.0 / internalSurfaceConductance));
        }
    }
}
