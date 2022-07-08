// <copyright file="UnitConversion.Length.cs" company="Shkyrockett" >
//     Copyright © 2021 - 2022 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using System.Numerics;
using System.Runtime.CompilerServices;

namespace GenericMathPlayground.Physics;

/// <summary>
/// The unit conversion.
/// </summary>
public static partial class UnitConversion
{
    /// <summary>
    /// 
    /// </summary>
    public static readonly Dictionary<Type, double> MetricLengthUnitConversions = new()
    {
        [typeof(InchesUnit)] = 0.0254d,
        [typeof(FeetUnit)] = 0.3048d,
        [typeof(MetersUnit)] = 1d,
    };

    /// <summary>
    /// Converts the to unit.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="sourceType">The source type.</param>
    /// <param name="destType">The dest type.</param>
    /// <returns>A double.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static double ConvertToUnit(double value, Type sourceType, Type destType) => value * (MetricLengthUnitConversions[sourceType] / MetricLengthUnitConversions[destType]);

    /// <summary>
    /// Converts the to.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="result">The result.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void ConvertTo<T, R>(this T value, out R result) where T : INumber<T>, ILengthUnit where R : INumber<R>, ILengthUnit => result = R.CreateChecked(value.Value * (T.UnitOfMeters * (1d / R.UnitOfMeters)));
}
