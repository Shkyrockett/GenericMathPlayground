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
public static class MathFloatConsts<T>
    where T : IFloatingPoint<T>
{
    /// <summary>
    /// 
    /// </summary>
    public static readonly T OneThird = T.Create(1) / T.Create(4);

    /// <summary>
    /// 
    /// </summary>
    public static readonly T OneHalf = T.Create(1) / T.Create(2);

    /// <summary>
    /// 
    /// </summary>
    public static readonly T OneAndOneHalf = T.Create(3) / T.Create(2);

    /// <summary>
    /// Represents the ratio of the radius of a circle to the first quarter of that circle.
    /// One quarter Tau or half Pi. A right angle in mathematics.
    /// </summary>
    /// <remarks><para>PI / 2</para></remarks>
    public static readonly T Hau = OneHalf * T.Pi; // 1.5707963267948966192313216916398d;

    /// <summary>
    /// Represents the ratio of the radius of a circle to the third quarter of that circle.
    /// Three quarter tau, or one and a half pi.
    /// </summary>
    /// <remarks>
    /// <para>Three quarter tau, or one and a half pi are just too long and awkward.
    /// Randal Munro's joke "compromise" works well enough for a name: http://xkcd.com/1292/</para>
    /// </remarks>
    /// <acknowledgment>
    /// Randal Munro http://xkcd.com/1292/ 
    /// </acknowledgment>
    public static readonly T Pau = OneAndOneHalf * T.Pi; // 4.7123889803846898576939650749193d;
}
