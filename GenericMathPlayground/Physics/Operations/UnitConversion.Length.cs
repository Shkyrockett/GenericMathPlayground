// <copyright file="UnitConversion.Length.cs" company="Shkyrockett" >
//     Copyright © 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using System;
using System.Collections.Generic;

namespace GenericMathPlayground.Physics;

/// <summary>
/// 
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
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="sourceType"></param>
    /// <param name="destType"></param>
    /// <returns></returns>
    public static double ConvertToUnit(double value, Type sourceType, Type destType) => value * (MetricLengthUnitConversions[sourceType] / MetricLengthUnitConversions[destType]);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="R"></typeparam>
    /// <param name="value"></param>
    /// <param name="result"></param>
    public static void ConvertTo<T, R>(this T value, out R result) where T : INumber<T>, ILengthUnit where R : INumber<R>, ILengthUnit => result = R.Create(value.Value * (T.InMeters * (1d / R.InMeters)));
}
