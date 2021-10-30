// <copyright file="MathematicsConstants.cs" company="Shkyrockett" >
//     Copyright © 2020 - 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using System;

namespace GenericMathPlayground.Mathematics;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public static class MathConsts<T>
    where T : struct, INumber<T>
{
    /// <summary>
    /// SlopeMax is a large value "close to infinity" (Close to the largest value allowed for the data
    /// type). Used in the Slope of a LineSeg
    /// </summary>
    public static readonly T SlopeMax = T.Zero switch
    {
        float => T.Create(9.223372E+18f),
        double => T.Create(9.223372036854776E+18d),
        decimal => T.Create(9223372036854775807),
        _ => T.Create(9223372036854775807),
    };

    /// <summary>
    /// 
    /// </summary>
    public static readonly T? MaxValue = T.Zero switch
    {
        char => T.Create(char.MaxValue),
        sbyte => T.Create(sbyte.MaxValue),
        byte => T.Create(byte.MaxValue),
        short => T.Create(short.MaxValue),
        ushort => T.Create(ushort.MaxValue),
        int => T.Create(int.MaxValue),
        uint => T.Create(uint.MaxValue),
        long => T.Create(long.MaxValue),
        ulong => T.Create(ulong.MaxValue),
        Half => T.Create(Half.MaxValue),
        float => T.Create(float.MaxValue),
        double => T.Create(double.MaxValue),
        decimal => T.Create(decimal.MaxValue),
        _ => null
    };

    /// <summary>
    /// 
    /// </summary>
    public static readonly T? MinValue = T.Zero switch
    {
        char => T.Create(char.MinValue),
        sbyte => T.Create(sbyte.MinValue),
        byte => T.Create(byte.MinValue),
        short => T.Create(short.MinValue),
        ushort => T.Create(ushort.MinValue),
        int => T.Create(int.MinValue),
        uint => T.Create(uint.MinValue),
        long => T.Create(long.MinValue),
        ulong => T.Create(ulong.MinValue),
        Half => T.Create(Half.MinValue),
        float => T.Create(float.MinValue),
        double => T.Create(double.MinValue),
        decimal => T.Create(decimal.MinValue),
        _ => null
    };
}
