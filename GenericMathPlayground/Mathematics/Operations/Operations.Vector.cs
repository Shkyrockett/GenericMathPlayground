// <copyright file="Operations.cs" company="Shkyrockett" >
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
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace GenericMathPlayground.Mathematics;

/// <summary>
/// 
/// </summary>
public static partial class Operations
{
    /// <summary>
    /// Convert Degrees to Radians.
    /// </summary>
    /// <param name="degrees">Angle in Degrees.</param>
    /// <returns>
    /// Angle in Radians.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static R DegreesToRadians<D, R>(this D degrees) where D : INumber<D> where R : IFloatingPoint<R> => R.Create(degrees) * R.Create(R.Pi / R.Create(180));

    /// <summary>
    /// Convert Radians to Degrees.
    /// </summary>
    /// <param name="radians">Angle in Radians.</param>
    /// <returns>
    /// Angle in Degrees.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static D RadiansToDegrees<R, D>(this R radians) where D : INumber<D> where R : IFloatingPoint<R> => D.Create(radians * R.Create(R.Create(180) / R.Pi));

    /// <summary>
    /// The angle.
    /// </summary>
    /// <param name="cos">The Cosine.</param>
    /// <param name="sin">The Sine.</param>
    /// <returns>
    /// The <see cref="double" />.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Angle<T>(T cos, T sin) where T : IFloatingPoint<T> => T.Atan2(-sin, cos);

    /// <summary>
    /// Returns the Angle of a line.
    /// </summary>
    /// <param name="x1">Horizontal Component of Point Starting Point</param>
    /// <param name="y1">Vertical Component of Point Starting Point</param>
    /// <param name="x2">Horizontal Component of Ending Point</param>
    /// <param name="y2">Vertical Component of Ending Point</param>
    /// <returns>
    /// Returns the Angle of a line.
    /// </returns>
    //[DebuggerStepThrough]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Angle<T>(T x1, T y1, T x2, T y2) where T : IFloatingPoint<T> => T.Atan2(y1 - y2, x1 - x2);

    /// <summary>
    /// The angle.
    /// </summary>
    /// <param name="x1">The x1.</param>
    /// <param name="y1">The y1.</param>
    /// <param name="z1">The z1.</param>
    /// <param name="x2">The x2.</param>
    /// <param name="y2">The y2.</param>
    /// <param name="z2">The z2.</param>
    /// <returns>
    /// The <see cref="double" />.
    /// </returns>
    /// <acknowledgment>
    /// http://www.codeproject.com/Articles/17425/A-Vector-Type-for-C
    /// </acknowledgment>
    //[DebuggerStepThrough]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Angle<T>(T x1, T y1, T z1, T x2, T y2, T z2) where T : IFloatingPoint<T> => (T.Abs(x1 - x2) < T.Epsilon && T.Abs(y1 - y2) < T.Epsilon && T.Abs(z1 - z2) < T.Epsilon) ? T.Zero : T.Acos(T.Min(T.One, DotProduct(Normalize(x1, y1, z1), Normalize(x2, y2, z2))));

    /// <summary>
    /// Calculates the dot Aka. scalar or inner product of a vector.
    /// </summary>
    /// <param name="tuple1">First set of X, Y, Z components in tuple form.</param>
    /// <param name="tuple2">Second set of X, Y, Z components in tuple form.</param>
    /// <returns>
    /// The Dot Product.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T DotProduct<T>((T X, T Y, T Z) tuple1, (T X, T Y, T Z) tuple2) where T : INumber<T> => DotProduct(tuple1.X, tuple1.Y, tuple1.Z, tuple2.X, tuple2.Y, tuple2.Z);

    /// <summary>
    /// Calculates the dot Aka. scalar or inner product of a vector.
    /// </summary>
    /// <param name="x1">First Point X component.</param>
    /// <param name="y1">First Point Y component.</param>
    /// <param name="x2">Second Point X component.</param>
    /// <param name="y2">Second Point Y component.</param>
    /// <returns>
    /// The Dot Product.
    /// </returns>
    /// <remarks>
    /// <para>The dot product "·" is calculated with DotProduct = X ^ 2 + Y ^ 2</para>
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T DotProduct<T>(T x1, T y1, T x2, T y2) where T : INumber<T> => (x1 * x2) + (y1 * y2);

    /// <summary>
    /// Calculates the dot Aka. scalar or inner product of a vector.
    /// </summary>
    /// <param name="x1">First Point X component.</param>
    /// <param name="y1">First Point Y component.</param>
    /// <param name="z1">First Point Z component.</param>
    /// <param name="x2">Second Point X component.</param>
    /// <param name="y2">Second Point Y component.</param>
    /// <param name="z2">Second Point Z component.</param>
    /// <returns>
    /// The Dot Product.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T DotProduct<T>(T x1, T y1, T z1, T x2, T y2, T z2) where T : INumber<T> => (x1 * x2) + (y1 * y2) + (z1 * z2);

    /// <summary>
    /// Calculates the dot Aka. scalar or inner product of a vector.
    /// </summary>
    /// <param name="x1">First Point X component.</param>
    /// <param name="y1">First Point Y component.</param>
    /// <param name="z1">First Point Z component.</param>
    /// <param name="w1">First Point W component.</param>
    /// <param name="x2">Second Point X component.</param>
    /// <param name="y2">Second Point Y component.</param>
    /// <param name="z2">Second Point Z component.</param>
    /// <param name="w2">Second Point W component.</param>
    /// <returns>
    /// The Dot Product.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T DotProduct<T>(T x1, T y1, T z1, T w1, T x2, T y2, T z2, T w2) where T : INumber<T> => (x1 * x2) + (y1 * y2) + (z1 * z2) + (w1 * w2);

    /// <summary>
    /// Calculates the dot Aka. scalar or inner product of a vector.
    /// </summary>
    /// <param name="x1">First Point X component.</param>
    /// <param name="y1">First Point Y component.</param>
    /// <param name="z1">First Point Z component.</param>
    /// <param name="w1">First Point W component.</param>
    /// <param name="v1">First Point V component.</param>
    /// <param name="x2">Second Point X component.</param>
    /// <param name="y2">Second Point Y component.</param>
    /// <param name="z2">Second Point Z component.</param>
    /// <param name="w2">Second Point W component.</param>
    /// <param name="v2">Second Point V component.</param>
    /// <returns>
    /// The Dot Product.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T DotProduct<T>(T x1, T y1, T z1, T w1, T v1, T x2, T y2, T z2, T w2, T v2) where T : INumber<T> => (x1 * x2) + (y1 * y2) + (z1 * z2) + (w1 * w2) + (v1 * v2);

    /// <summary>
    /// Calculates the dot Aka. scalar or inner product of a vector.
    /// </summary>
    /// <param name="x1">First Point X component.</param>
    /// <param name="y1">First Point Y component.</param>
    /// <param name="z1">First Point Z component.</param>
    /// <param name="w1">First Point W component.</param>
    /// <param name="v1">First Point V component.</param>
    /// <param name="u1">The u1.</param>
    /// <param name="x2">Second Point X component.</param>
    /// <param name="y2">Second Point Y component.</param>
    /// <param name="z2">Second Point Z component.</param>
    /// <param name="w2">Second Point W component.</param>
    /// <param name="v2">Second Point V component.</param>
    /// <param name="u2">The u2.</param>
    /// <returns>
    /// The Dot Product.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T DotProduct<T>(T x1, T y1, T z1, T w1, T v1, T u1, T x2, T y2, T z2, T w2, T v2, T u2) where T : INumber<T> => (x1 * x2) + (y1 * y2) + (z1 * z2) + (w1 * w2) + (v1 * v2) + (u1 * u2);

    /// <summary>
    /// Normalize a Vector.
    /// </summary>
    /// <param name="tuple">The tuple.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (T X, T Y) Normalize<T>((T i, T j) tuple) where T : INumber<T> => Normalize(tuple.i, tuple.j);

    /// <summary>
    /// Normalize a Vector.
    /// </summary>
    /// <param name="tuple">The tuple.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (T X, T Y, T Z) Normalize<T>((T i, T j, T k) tuple) where T : INumber<T> => Normalize(tuple.i, tuple.j, tuple.k);

    /// <summary>
    /// Normalize a Vector.
    /// </summary>
    /// <param name="tuple">The tuple.</param>
    /// <returns></returns>
    [DebuggerStepThrough]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (T X, T Y, T Z, T W) Normalize<T>((T i, T j, T k, T l) tuple) where T : INumber<T> => Normalize(tuple.i, tuple.j, tuple.k, tuple.l);

    /// <summary>
    /// Normalize a Vector.
    /// </summary>
    /// <param name="i">The i.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Normalize<T>(T i) where T : INumber<T> => i / T.Create(Math.Sqrt(Cast<T, double>(i * i)));

    /// <summary>
    /// Normalize a Vector.
    /// </summary>
    /// <param name="i">The i.</param>
    /// <param name="j">The j.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (T X, T Y) Normalize<T>(T i, T j) where T : INumber<T> => (i / T.Create(Math.Sqrt(Cast<T, double>((i * i) + (j * j)))), j / T.Create(Math.Sqrt(Cast<T, double>((i * i) + (j * j)))));

    /// <summary>
    /// Normalize a Vector.
    /// </summary>
    /// <param name="i">The i.</param>
    /// <param name="j">The j.</param>
    /// <param name="k">The k.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (T X, T Y, T Z) Normalize<T>(T i, T j, T k) where T : INumber<T> => (i / T.Create(Math.Sqrt(Cast<T, double>((i * i) + (j * j) + (k * k)))), j / T.Create(Math.Sqrt(Cast<T, double>((i * i) + (j * j) + (k * k)))), k / T.Create(Math.Sqrt(Cast<T, double>((i * i) + (j * j) + (k * k)))));

    /// <summary>
    /// Normalize a Vector.
    /// </summary>
    /// <param name="i">The i.</param>
    /// <param name="j">The j.</param>
    /// <param name="k">The k.</param>
    /// <param name="l">The l.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (T X, T Y, T Z, T W) Normalize<T>(T i, T j, T k, T l) where T : INumber<T> => (i / T.Create(Math.Sqrt(Cast<T, double>((i * i) + (j * j) + (k * k) + (l * l)))), j / T.Create(Math.Sqrt(Cast<T, double>((i * i) + (j * j) + (k * k) + (l * l)))), k / T.Create(Math.Sqrt(Cast<T, double>((i * i) + (j * j) + (k * k) + (l * l)))), l / T.Create(Math.Sqrt(Cast<T, double>((i * i) + (j * j) + (k * k) + (l * l)))));
}
