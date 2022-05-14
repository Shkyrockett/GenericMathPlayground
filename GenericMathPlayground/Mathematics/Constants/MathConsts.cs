// <copyright file="MathematicsConstants.cs" company="Shkyrockett" >
//     Copyright © 2020 - 2022 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using System.Numerics;

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
        float => T.CreateChecked(9.223372E+18f),
        double => T.CreateChecked(9.223372036854776E+18d),
        decimal => T.CreateChecked(9223372036854775807),
        _ => T.CreateChecked(9223372036854775807),
    };

    /// <summary>
    /// 
    /// </summary>
    public static readonly T? MaxValue = T.Zero switch
    {
        char => T.CreateChecked(char.MaxValue),
        sbyte => T.CreateChecked(sbyte.MaxValue),
        byte => T.CreateChecked(byte.MaxValue),
        short => T.CreateChecked(short.MaxValue),
        ushort => T.CreateChecked(ushort.MaxValue),
        int => T.CreateChecked(int.MaxValue),
        uint => T.CreateChecked(uint.MaxValue),
        long => T.CreateChecked(long.MaxValue),
        ulong => T.CreateChecked(ulong.MaxValue),
        Half => T.CreateChecked(Half.MaxValue),
        float => T.CreateChecked(float.MaxValue),
        double => T.CreateChecked(double.MaxValue),
        decimal => T.CreateChecked(decimal.MaxValue),
        _ => null
    };

    /// <summary>
    /// 
    /// </summary>
    public static readonly T? MinValue = T.Zero switch
    {
        char => T.CreateChecked(char.MinValue),
        sbyte => T.CreateChecked(sbyte.MinValue),
        byte => T.CreateChecked(byte.MinValue),
        short => T.CreateChecked(short.MinValue),
        ushort => T.CreateChecked(ushort.MinValue),
        int => T.CreateChecked(int.MinValue),
        uint => T.CreateChecked(uint.MinValue),
        long => T.CreateChecked(long.MinValue),
        ulong => T.CreateChecked(ulong.MinValue),
        Half => T.CreateChecked(Half.MinValue),
        float => T.CreateChecked(float.MinValue),
        double => T.CreateChecked(double.MinValue),
        decimal => T.CreateChecked(decimal.MinValue),
        _ => null
    };
}
