// <copyright file="Measurements.Other.cs" company="Shkyrockett" >
//     Copyright © 2005 - 2022 Shkyrockett. All rights reserved.
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

namespace GenericMathPlayground.Geometry;

/// <summary>
/// The measurements static class.
/// </summary>
public static partial class Measurements
{
    /// <summary>
    /// Finds the Aspect ratio of the elliptical arc or rectangle.
    /// </summary>
    /// <param name="x">The Horizontal value.</param>
    /// <param name="y">The Vertical value.</param>
    /// <returns>
    /// Returns the aspect ratio of the horizontal an vertical components.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static R Aspect<T, R>(T x, T y) where T : INumber<T> where R : IFloatingPointIeee754<R> => x == T.Zero ? R.PositiveInfinity : R.CreateChecked(y) / R.CreateChecked(x);

    /// <summary>
    /// Finds the <see cref="Eccentricity" /> of the elliptical arc or rectangle.
    /// </summary>
    /// <param name="rX">The x radius.</param>
    /// <param name="rY">The y radius.</param>
    /// <returns></returns>
    /// <remarks>
    /// <para>Returns a value that represents the <see cref="Eccentricity" /> of an elliptical arc or rectangle.</para>
    /// </remarks>
    /// <acknowledgment>
    /// https://en.wikipedia.org/wiki/Ellipse2D
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static R Eccentricity<T, R>(T rX, T rY)
        where T : INumber<T>
        where R : IFloatingPointIeee754<R>
    {
        var m = R.CreateChecked(rX) / R.CreateChecked(rY);
        return R.Sqrt(R.One - m * m);
    }
}
