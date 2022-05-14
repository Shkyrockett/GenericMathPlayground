// <copyright file="Operations.Algebratics.cs" company="Shkyrockett" >
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
using System.Runtime.CompilerServices;

namespace GenericMathPlayground.Mathematics;

/// <summary>
/// Algebraic Operations class.
/// </summary>
public static partial class Operations
{
    #region Ellipse Helpers
    /// <summary>
    /// Find the elliptical t that matches the coordinates of a circular angle.
    /// </summary>
    /// <param name="angle">The angle to transform into elliptic angle.</param>
    /// <param name="rx">The first radius of the ellipse.</param>
    /// <param name="ry">The second radius of the ellipse.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// Based on the answer by flup at: https://stackoverflow.com/a/17762156/7004229
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult EllipticalPolarAngle<T, TResult>(TResult angle, T rx, T ry)
        where T : INumber<T>
        where TResult : IFloatingPointIeee754<TResult>
    {
        var rxt = TResult.CreateChecked(rx);
        var ryt = TResult.CreateChecked(ry);
        var hau = MathFloatConsts<TResult>.Hau;
        var pau = MathFloatConsts<TResult>.Pau;

        // Wrap the angle between -2PI and 2PI.
        var theta = angle % TResult.Tau;

        // Find the elliptical t that matches the circular angle.
        return theta switch
        {
            var t when TResult.Abs(t) == hau || TResult.Abs(t) == pau => angle,
            var t when t > hau && t < pau => TResult.Atan(rxt * TResult.Tan(t) / ryt) + TResult.Pi,
            var t when t < -hau && t > -pau => TResult.Atan(rxt * TResult.Tan(t) / ryt) - TResult.Pi,
            _ => TResult.Atan(rxt * TResult.Tan(theta) / ryt),
        };
    }

    /// <summary>
    /// Find the elliptical (cos(t), sin(t)) that matches the coordinates of a circular angle.
    /// </summary>
    /// <param name="cosA">The cos a.</param>
    /// <param name="sinA">The sin a.</param>
    /// <param name="rx">The first radius of the ellipse.</param>
    /// <param name="ry">The second radius of the ellipse.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// Vectorized version of the answer by flup at: https://stackoverflow.com/a/17762156/7004229
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult cosT, TResult sinT) EllipticalPolarVector<T, TResult>(TResult cosA, TResult sinA, T rx, T ry)
        where T : INumber<T>
        where TResult : IFloatingPointIeee754<TResult>
    {
        // Find the elliptical t that matches the circular angle.
        if (cosA > TResult.NegativeOne && cosA < TResult.Zero || cosA > TResult.Zero && cosA < TResult.One)
        {
            var sign = TResult.CreateChecked(TResult.Sign(cosA));
            var eCos = TResult.Sqrt(TResult.One + (TResult.CreateChecked(rx * rx) * sinA * sinA / (TResult.CreateChecked(ry * ry) * cosA * cosA)));
            return (
                sign / eCos,
                sign * (TResult.CreateChecked(rx) * sinA / (TResult.CreateChecked(ry) * cosA * eCos))
                );
        }

        return (cosA, sinA);
    }

    /// <summary>
    /// Return a "correction" angle that converts a subtended angle to a parametric angle for an
    /// ellipse with radii a and b.
    /// </summary>
    /// <param name="subtendedAngle">The subtended.</param>
    /// <param name="a">a.</param>
    /// <param name="b">The b.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult SubtendedToParametric<T, TResult>(TResult subtendedAngle, T a, T b) where T : INumber<T> where TResult : IFloatingPointIeee754<TResult> => SubtendedToParametric(TResult.Cos(subtendedAngle), TResult.Sin(subtendedAngle), a, b);

    /// <summary>
    /// Return a "correction" angle that converts a subtended angle to a parametric angle for an
    /// ellipse with radii a and b.
    /// </summary>
    /// <param name="subtendedCos">The subtended cos.</param>
    /// <param name="subtendedSin">The subtended sin.</param>
    /// <param name="a">a.</param>
    /// <param name="b">The b.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// Code ported from: https://www.khanacademy.org/computer-programming/e/6221186997551104
    /// Math from: http://mathworld.wolfram.com/Ellipse-LineIntersection.html
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult SubtendedToParametric<T, TResult>(TResult subtendedCos, TResult subtendedSin, T a, T b)
        where T : INumber<T>
        where TResult : IFloatingPointIeee754<TResult>
    {
        if (a == b)
        {
            // Circle needs no correction.
            return TResult.Zero;

            // Should test to see if this might be causing problems and should be the following instead:
            //return TResult.Atan2(subtendedSin, subtendedCos);
        }

        // A ray from the origin.
        var e = TResult.CreateChecked(a * b) / TResult.Sqrt((TResult.CreateChecked(a * a) * subtendedSin * subtendedSin) + (TResult.CreateChecked(b * b) * subtendedCos * subtendedCos));

        // Where ray intersects ellipse.
        var ex = e * subtendedCos;
        var ey = e * subtendedSin;

        // Normalized.
        var parametric = TResult.Atan2(TResult.CreateChecked(a) * ey, TResult.CreateChecked(b) * ex);
        var subtended = TResult.Atan2(subtendedSin, subtendedCos);
        return parametric - subtended;
    }
    #endregion

    #region Polar Cartesian Conversion
    /// <summary>
    /// The polar to Cartesian.
    /// </summary>
    /// <param name="centerX">The centerX.</param>
    /// <param name="centerY">The centerY.</param>
    /// <param name="radius">The radius.</param>
    /// <param name="theta">The angleInRadians.</param>
    /// <returns>
    /// The <see cref="ValueTuple{T1, T2}" />.
    /// </returns>
    /// <acknowledgment>
    /// https://codereview.stackexchange.com/q/183
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) PolarToCartesian<T>(T centerX, T centerY, T radius, T theta)
        where T : IFloatingPointIeee754<T>
    {
        var sin = T.Sin(theta);

        // This is faster than:
        // T cos = Math.Cos(theta);
        var cos = -T.Sqrt(T.One - (sin * sin));

        return (
            X: centerX + (radius * cos),
            Y: centerY + (radius * sin)
            );
    }

    /// <summary>
    /// The Cartesian to polar.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <returns>
    /// The <see cref="ValueTuple{T1, T2}" />.
    /// </returns>
    /// <acknowledgment>
    /// https://stackoverflow.com/a/34315013
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult Radius, TResult Theta) CartesianToPolar<T, TResult>(T x, T y) where T : INumber<T> where TResult : IFloatingPointIeee754<TResult> => CartesianToPolar<T, TResult>(x, y, T.Zero, T.Zero);

    /// <summary>
    /// The Cartesian to polar.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <param name="centerX">The centerX.</param>
    /// <param name="centerY">The centerY.</param>
    /// <returns>
    /// The <see cref="ValueTuple{T1, T2}" />.
    /// </returns>
    /// <acknowledgment>
    /// https://stackoverflow.com/a/34315013
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult Radius, TResult Theta) CartesianToPolar<T, TResult>(T x, T y, T centerX, T centerY)
        where T : INumber<T>
        where TResult : IFloatingPointIeee754<TResult>
    {
        var dx = TResult.CreateChecked(x - centerX);
        var dy = TResult.CreateChecked(y - centerY);
        var radius = TResult.Sqrt((dx * dx) + (dy * dy));
        var angle = TResult.Atan2(dy, dx);
        return (radius, angle);
    }
    #endregion

    /// <summary>
    /// In implementation of Pow that supports integers.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://stackoverflow.com/a/58110671
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T Power<T>(T value, int index)
    where T : INumber<T>
    {
        T result;
        if (index == 0)
        {
            result = T.One;
        }
        else if (index < 0)
        {
            index *= -1;
            result = T.One / value;
            for (int i = 1; i < index; i++)
            {
                result /= value;
            }
        }
        else
        {
            result = value;
            for (int i = 0; i <= index; i++)
            {
                result *= value;
            }
        }

        return result;
    }
}
