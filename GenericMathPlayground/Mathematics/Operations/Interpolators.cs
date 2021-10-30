// <copyright file="Operations.Interpolations.cs" company="Shkyrockett" >
//     Copyright © 2020 - 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using GenericMathPlayground.Geometry;
using Microsoft.Toolkit.HighPerformance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace GenericMathPlayground.Mathematics;

/// <summary>
/// 
/// </summary>
public static partial class Interpolators
{
    #region Interpolate To List
    /// <summary>
    /// Generates a list of points interpolated from a function.
    /// </summary>
    /// <param name="count">The number of points desired.</param>
    /// <param name="func">The function.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static List<IPoint2<T>> Interpolate<T>(int count, Func<T, IPoint2<T>> func) where T : INumber<T> => Interpolate(count, 0, 1, func);

    /// <summary>
    /// Generates a list of points interpolated from a function.
    /// </summary>
    /// <param name="count">The number of points desired.</param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <param name="func">The function.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static List<IPoint2<T>> Interpolate<T>(int count, int min, int max, Func<T, IPoint2<T>> func) where T : INumber<T> => (from i in Enumerable.Range(min, count) select func(T.Create(max) / T.Create(count * i))).ToList();
    #endregion

    #region Linear Interpolation
    /// <summary>
    /// Linear Interpolates the specified a.
    /// </summary>
    /// <param name="a">a.</param>
    /// <param name="b">The b.</param>
    /// <param name="t">The amount.</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] Lerp<T>(Span<T> a, Span<T> b, T t)
        where T : INumber<T>
    {
        var leftLength = a.Length;
        var rightLength = b.Length;

        if (leftLength != rightLength)
        {
            throw new Exception();
        }

        var results = new T[leftLength];
        for (var i = 0; i < leftLength; i++)
        {
            results[i] = a[i] + ((b[i] - a[i]) * t);
        }

        return results;
    }

    /// <summary>
    /// Linear Interpolates the specified a.
    /// </summary>
    /// <param name="a">a.</param>
    /// <param name="b">The b.</param>
    /// <param name="t">The amount.</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] Lerp<T>(Span2D<T> a, Span2D<T> b, T t)
        where T : INumber<T>
    {
        var aRows = a.Height;
        var bRows = b.Height;
        var aCols = a.Width;
        var bCols = b.Width;

        if (aRows != bRows || aCols != bCols)
        {
            throw new Exception();
        }

        var results = new T[aRows, bRows];
        for (var i = 0; i < aRows; i++)
        {
            for (var j = 0; j < aCols; j++)
            {
                results[i, j] = a[i, j] + ((b[i, j] - a[i, j]) * t);
            }
        }

        return results;
    }

    /// <summary>
    /// The linear interpolation method.
    /// </summary>
    /// <param name="u0">The u0.</param>
    /// <param name="u1">The u1.</param>
    /// <param name="t">The t.</param>
    /// <returns>
    /// The linear interpolation method.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T Lerp<T>(T u0, T u1, T t) where T : INumber<T> => u0 + ((u1 - u0) * t);

    /// <summary>
    /// The linear interpolation method.
    /// </summary>
    /// <param name="x0">The x0.</param>
    /// <param name="y0">The y0.</param>
    /// <param name="x1">The x1.</param>
    /// <param name="y1">The y1.</param>
    /// <param name="t">The t.</param>
    /// <returns>The <see cref="ValueTuple{T1, T2}"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) Lerp<T>(T x0, T y0, T x1, T y1, T t) where T : INumber<T> => (x0 + ((x1 - x0) * t), y0 + ((y1 - y0) * t));

    /// <summary>
    /// The linear interpolation method.
    /// </summary>
    /// <param name="x0">The x0.</param>
    /// <param name="y0">The y0.</param>
    /// <param name="z0">The z0.</param>
    /// <param name="x1">The x1.</param>
    /// <param name="y1">The y1.</param>
    /// <param name="z1">The z1.</param>
    /// <param name="t">The t.</param>
    /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z) Lerp<T>(T x0, T y0, T z0, T x1, T y1, T z1, T t) where T : INumber<T> => (x0 + ((x1 - x0) * t), y0 + ((y1 - y0) * t), z0 + ((z1 - z0) * t));

    /// <summary>
    /// The linear interpolation method.
    /// </summary>
    /// <param name="x0">The x0.</param>
    /// <param name="y0">The y0.</param>
    /// <param name="z0">The z0.</param>
    /// <param name="w0">The w0.</param>
    /// <param name="x1">The x1.</param>
    /// <param name="y1">The y1.</param>
    /// <param name="z1">The z1.</param>
    /// <param name="w1">The w1.</param>
    /// <param name="t">The t.</param>
    /// <returns>The <see cref="ValueTuple{T1, T2, T3, T4}"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z, T W) Lerp<T>(T x0, T y0, T z0, T w0, T x1, T y1, T z1, T w1, T t) where T : INumber<T> => (x0 + ((x1 - x0) * t), y0 + ((y1 - y0) * t), z0 + ((z1 - z0) * t), w0 + ((w1 - w0) * t));

    /// <summary>
    /// The linear interpolation method.
    /// </summary>
    /// <param name="x0">The x0.</param>
    /// <param name="y0">The y0.</param>
    /// <param name="z0">The z0.</param>
    /// <param name="w0">The w0.</param>
    /// <param name="v0">The v0.</param>
    /// <param name="x1">The x1.</param>
    /// <param name="y1">The y1.</param>
    /// <param name="z1">The z1.</param>
    /// <param name="w1">The w1.</param>
    /// <param name="v1">The v1.</param>
    /// <param name="t">The t.</param>
    /// <returns>
    /// The <see cref="ValueTuple{T1, T2, T3, T4, T5}" />.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z, T W, T V) Lerp<T>(T x0, T y0, T z0, T w0, T v0, T x1, T y1, T z1, T w1, T v1, T t) where T : INumber<T> => (x0 + ((x1 - x0) * t), y0 + ((y1 - y0) * t), z0 + ((z1 - z0) * t), w0 + ((w1 - w0) * t), v0 + ((v1 - v0) * t));

    /// <summary>
    /// The linear interpolation method.
    /// </summary>
    /// <param name="x0">The x0.</param>
    /// <param name="y0">The y0.</param>
    /// <param name="z0">The z0.</param>
    /// <param name="w0">The w0.</param>
    /// <param name="v0">The v0.</param>
    /// <param name="u0">The u0.</param>
    /// <param name="x1">The x1.</param>
    /// <param name="y1">The y1.</param>
    /// <param name="z1">The z1.</param>
    /// <param name="w1">The w1.</param>
    /// <param name="v1">The v1.</param>
    /// <param name="u1">The u1.</param>
    /// <param name="t">The t.</param>
    /// <returns>
    /// The <see cref="ValueTuple{T1, T2, T3, T4, T5, T6}" />.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z, T W, T V, T U) Lerp<T>(T x0, T y0, T z0, T w0, T v0, T u0, T x1, T y1, T z1, T w1, T v1, T u1, T t) where T : INumber<T> => (x0 + ((x1 - x0) * t), y0 + ((y1 - y0) * t), z0 + ((z1 - z0) * t), w0 + ((w1 - w0) * t), v0 + ((v1 - v0) * t), u0 + ((u1 - u0) * t));

    /// <summary>
    /// Two control point 1D Linear interpolation for ranges from 0 to 1, start to end of curve.
    /// </summary>
    /// <param name="t">The t index of the linear curve.</param>
    /// <param name="aV">The first anchor value.</param>
    /// <param name="bV">The second anchor value.</param>
    /// <returns>
    /// Returns a <see cref="double" /> representing a point on the linear curve at the t index.
    /// </returns>
    /// <acknowledgment>
    /// http://paulbourke.net/geometry/bezier/index.html
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T Linear<T>(T t, T aV, T bV) where T : INumber<T> => ((T.One - t) * aV) + (t * bV);

    /// <summary>
    /// Two control point 2D Linear interpolation for ranges from 0 to 1, start to end of curve.
    /// </summary>
    /// <param name="t">The t index of the linear curve.</param>
    /// <param name="aX">The first anchor point x value.</param>
    /// <param name="aY">The first anchor point y value.</param>
    /// <param name="bX">The second anchor point x value.</param>
    /// <param name="bY">The second anchor point y value.</param>
    /// <returns>Returns a <see cref="ValueTuple{T1, T2}"/> representing a point on the linear curve at the t index.</returns>
    /// <acknowledgment>
    /// http://paulbourke.net/geometry/bezier/index.html
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) Linear<T>(T t, T aX, T aY, T bX, T bY) where T : INumber<T> => (((T.One - t) * aX) + (t * bX), ((T.One - t) * aY) + (t * bY));

    /// <summary>
    /// Two control point 3D Linear interpolation for ranges from 0 to 1, start to end of curve.
    /// </summary>
    /// <param name="t">The t index of the linear curve.</param>
    /// <param name="aX">The first anchor point x value.</param>
    /// <param name="aY">The first anchor point y value.</param>
    /// <param name="aZ">The first anchor point z value.</param>
    /// <param name="bX">The second anchor point x value.</param>
    /// <param name="bY">The second anchor point y value.</param>
    /// <param name="bZ">The second anchor point z value.</param>
    /// <returns>
    /// Returns a <see cref="ValueTuple{T1, T2, T3}" /> representing a point on the linear curve at the t index.
    /// </returns>
    /// <acknowledgment>
    /// http://paulbourke.net/geometry/bezier/index.html
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z) Linear<T>(T t, T aX, T aY, T aZ, T bX, T bY, T bZ) where T : INumber<T> => (((T.One - t) * aX) + (t * bX), ((T.One - t) * aY) + (t * bY), ((T.One - t) * aZ) + (t * bZ));

    /// <summary>
    /// Two control point 2D Linear interpolation for ranges from 0 to 1, start to end of curve.
    /// </summary>
    /// <param name="t">The t index of the linear curve.</param>
    /// <param name="a">The first anchor point.</param>
    /// <param name="b">The second anchor point value.</param>
    /// <returns>
    /// Returns a <see cref="ValuePoint2{T}" /> representing a point on the linear curve at the t index.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) Linear<T>(T t, (T X, T Y) a, (T X, T Y) b) where T : INumber<T> => Linear(t, a.X, a.Y, b.X, b.Y);

    /// <summary>
    /// Two control point 3D Linear interpolation for ranges from 0 to 1, start to end of curve.
    /// </summary>
    /// <param name="t">The t index of the linear curve.</param>
    /// <param name="a">The first anchor point.</param>
    /// <param name="b">The second anchor point value.</param>
    /// <returns>Returns a <see cref="ValuePoint3{T}"/> representing a point on the linear curve at the t index.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z) Linear<T>(T t, (T X, T Y, T Z) a, (T X, T Y, T Z) b) where T : INumber<T> => Linear(t, a.X, a.Y, a.Z, b.X, b.Y, b.Z);
    #endregion

    #region Inverse Linear Interpolation
    /// <summary>
    /// Find the t for a value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://www.gamedev.net/articles/programming/general-and-gameplay-programming/inverse-lerp-a-super-useful-yet-often-overlooked-function-r5230/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T InverseLerp<T>(T a, T b, T value) where T : INumber<T> => (value - a) / (b - a);
    #endregion

    #region Linear Interpolation Remap
    /// <summary>
    /// Remap takes a value within a given input range into a given output range.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="inMin"></param>
    /// <param name="inMax"></param>
    /// <param name="outMin"></param>
    /// <param name="outMax"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://www.gamedev.net/articles/programming/general-and-gameplay-programming/inverse-lerp-a-super-useful-yet-often-overlooked-function-r5230/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T LinearRemap<T>(T inMin, T inMax, T outMin, T outMax, T value)
        where T : INumber<T>
    {
        var t = InverseLerp(inMin, inMax, value);
        return Lerp(outMin, outMax, t);
    }
    #endregion

    #region Normalized Linear Interpolation
    /// <summary>
    /// The nlerp.
    /// </summary>
    /// <param name="t">The percent.</param>
    /// <param name="aV">The start.</param>
    /// <param name="bV">The end.</param>
    /// <returns>The <see cref="Point2{T}"/>.</returns>
    /// <acknowledgment>
    /// https://keithmaggio.wordpress.com/2011/02/15/math-magician-lerp-slerp-and-nlerp/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult Nlerp<T, TResult>(T t, T aV, T bV) where T : INumber<T> where TResult : IFloatingPoint<TResult> => Operations.Normalize<T, TResult>(Linear(t, aV, bV));

    /// <summary>
    /// The nlerp.
    /// </summary>
    /// <param name="t">The percent.</param>
    /// <param name="aX">The startX.</param>
    /// <param name="aY">The startY.</param>
    /// <param name="bX">The endX.</param>
    /// <param name="bY">The endY.</param>
    /// <returns>The <see cref="ValueTuple{T1, T2}"/>.</returns>
    /// <acknowledgment>
    /// https://keithmaggio.wordpress.com/2011/02/15/math-magician-lerp-slerp-and-nlerp/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y) Nlerp<T, TResult>(T t, T aX, T aY, T bX, T bY)
        where T : INumber<T>
        where TResult : IFloatingPoint<TResult>
    {
        var (X, Y) = Linear(t, aX, aY, bX, bY);
        return Operations.Normalize<T, TResult>(X, Y);
    }

    /// <summary>
    /// The nlerp.
    /// </summary>
    /// <param name="t">The percent.</param>
    /// <param name="aX">The startX.</param>
    /// <param name="aY">The startY.</param>
    /// <param name="aZ">The startZ.</param>
    /// <param name="bX">The endX.</param>
    /// <param name="bY">The endY.</param>
    /// <param name="bZ">The endZ.</param>
    /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
    /// <acknowledgment>
    /// https://keithmaggio.wordpress.com/2011/02/15/math-magician-lerp-slerp-and-nlerp/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y, TResult Z) Nlerp<T, TResult>(T t, T aX, T aY, T aZ, T bX, T bY, T bZ)
        where T : INumber<T>
        where TResult : IFloatingPoint<TResult>
    {
        var (X, Y, Z) = Linear(t, aX, aY, aZ, bX, bY, bZ);
        return Operations.Normalize<T, TResult>(X, Y, Z);
    }

    /// <summary>
    /// The nlerp.
    /// </summary>
    /// <param name="t">The percent.</param>
    /// <param name="a">The start.</param>
    /// <param name="b">The end.</param>
    /// <returns>The <see cref="Point2{T}"/>.</returns>
    /// <acknowledgment>
    /// https://keithmaggio.wordpress.com/2011/02/15/math-magician-lerp-slerp-and-nlerp/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y) Nlerp<T, TResult>(T t, (T X, T Y) a, (T X, T Y) b) where T : INumber<T> where TResult : IFloatingPoint<TResult> => Operations.Normalize<T, TResult>(Linear(t, a, b));

    /// <summary>
    /// The nlerp.
    /// </summary>
    /// <param name="t">The percent.</param>
    /// <param name="a">The start.</param>
    /// <param name="b">The end.</param>
    /// <returns>The <see cref="Point2{T}"/>.</returns>
    /// <acknowledgment>
    /// https://keithmaggio.wordpress.com/2011/02/15/math-magician-lerp-slerp-and-nlerp/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y, TResult Z) Nlerp<T, TResult>(T t, (T X, T Y, T Z) a, (T X, T Y, T Z) b) where T : INumber<T> where TResult : IFloatingPoint<TResult> => Operations.Normalize<T, TResult>(Linear(t, a, b));
    #endregion

    #region Spherical Linear Interpolation
    /// <summary>
    /// The slerp.
    /// </summary>
    /// <param name="percent">The percent.</param>
    /// <param name="a">The start.</param>
    /// <param name="b">The end.</param>
    /// <returns>The <see cref="Point2{T}"/>.</returns>
    /// <acknowledgment>
    /// https://keithmaggio.wordpress.com/2011/02/15/math-magician-lerp-slerp-and-nlerp/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static ValuePoint2<T> Slerp<T>(T percent, ValuePoint2<T> a, ValuePoint2<T> b)
        where T : IFloatingPoint<T>
    {
        // Dot product - the cosine of the angle between 2 vectors.
        // Clamp it to be in the range of Acos()
        // This may be unnecessary, but floating point
        // precision can be a fickle mistress.
        var dot = Operations.Clamp(Operations.DotProduct(a.X, a.Y, b.X, b.Y), T.NegativeOne, T.One);

        // Acos(dot) returns the angle between start and end,
        // And multiplying that by percent returns the angle between
        // start and the final result.
        var theta = T.Acos(dot) * percent;
        var RelativeVec = b - (a * dot);

        // Orthonormal basis
        RelativeVec = new(Operations.Normalize<T, T>(RelativeVec.X, RelativeVec.Y));

        // The final result.
        return (a * T.Cos(theta)) + (RelativeVec * T.Sin(theta));
    }

    /// <summary>
    /// The slerp.
    /// </summary>
    /// <param name="percent">The percent.</param>
    /// <param name="a">The start.</param>
    /// <param name="b">The end.</param>
    /// <returns>The <see cref="Point2{T}"/>.</returns>
    /// <acknowledgment>
    /// https://keithmaggio.wordpress.com/2011/02/15/math-magician-lerp-slerp-and-nlerp/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static ValuePoint3<T> Slerp<T>(T percent, ValuePoint3<T> a, ValuePoint3<T> b)
        where T : IFloatingPoint<T>
    {
        // Dot product - the cosine of the angle between 2 vectors.
        // Clamp it to be in the range of Acos()
        // This may be unnecessary, but floating point
        // precision can be a fickle mistress.
        var dot = Operations.Clamp(Operations.DotProduct(a.X, a.Y, a.Y, b.X, b.Y, b.Z), T.NegativeOne, T.One);

        // Acos(dot) returns the angle between start and end,
        // And multiplying that by percent returns the angle between
        // start and the final result.
        var theta = T.Acos(dot) * percent;
        var RelativeVec = b - (a * dot);

        // Orthonormal basis
        RelativeVec = new(Operations.Normalize<T, T>(RelativeVec.X, RelativeVec.Y, RelativeVec.Z));

        // The final result.
        return (a * T.Cos(theta)) + (RelativeVec * T.Sin(theta));
    }
    #endregion

    #region Curve Interpolation
    ///// <summary>
    ///// The curve.
    ///// </summary>
    ///// <param name="t">The t.</param>
    ///// <param name="vCurve">The vCurve.</param>
    ///// <returns>The <see cref="T"/>.</returns>
    ////[DebuggerStepThrough]
    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static T Curve<T>(T t, Polynomial<T> vCurve)
    //    where T : IFloatingPoint<T>
    //{
    //    var v = T.Zero;
    //    for (int s = vCurve.Count - 1, d = 0; s >= 0; s--, d++)
    //    {
    //        var r = T.Zero;
    //        for (var i = 0; i < d; i++)
    //        {
    //            r *= t;
    //        }

    //        v += vCurve[s] * r;
    //    }

    //    return v;
    //}

    ///// <summary>
    ///// The curve.
    ///// </summary>
    ///// <param name="t">The t.</param>
    ///// <param name="xCurve">The xCurve.</param>
    ///// <param name="yCurve">The yCurve.</param>
    ///// <returns>The <see cref="ValueTuple{T1, T2}"/>.</returns>
    ////[DebuggerStepThrough]
    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static (T x, T y) Curve<T>(T t, Polynomial<T> xCurve, Polynomial<T> yCurve)
    //    where T : IFloatingPoint<T>
    //{
    //    var (x, y) = (T.Zero, T.Zero);
    //    for (int s = xCurve.Count - 1, d = 0; s >= 0; s--, d++)
    //    {
    //        var r = T.Zero;
    //        for (var i = 0; i < d; i++)
    //        {
    //            r *= t;
    //        }

    //        x += xCurve[s] * r;
    //        y += yCurve[s] * r;
    //    }

    //    return (x, y);
    //}

    ///// <summary>
    ///// The curve.
    ///// </summary>
    ///// <param name="t">The t.</param>
    ///// <param name="xCurve">The xCurve.</param>
    ///// <param name="yCurve">The yCurve.</param>
    ///// <param name="zCurve">The zCurve.</param>
    ///// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
    ////[DebuggerStepThrough]
    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static (T x, T y, T z) Curve<T>(T t, Polynomial<T> xCurve, Polynomial<T> yCurve, Polynomial<T> zCurve)
    //    where T : IFloatingPoint<T>
    //{
    //    var (x, y, z) = (T.Zero, T.Zero, T.Zero);
    //    for (int s = xCurve.Count - 1, d = 0; s >= 0; s--, d++)
    //    {
    //        var r = T.Zero;
    //        for (var i = 0; i < d; i++)
    //        {
    //            r *= t;
    //        }

    //        x += xCurve[s] * r;
    //        y += yCurve[s] * r;
    //        z += zCurve[s] * r;
    //    }

    //    return (x, y, z);
    //}
    #endregion

    #region Quadratic Bézier Interpolation
    /// <summary>
    /// Three control point Bézier interpolation mu ranges from 0 to 1, start to end of the curve.
    /// </summary>
    /// <param name="t">The time parameter.</param>
    /// <param name="aV">The first parameter.</param>
    /// <param name="bV">The second parameter.</param>
    /// <param name="cV">The third parameter.</param>
    /// <returns>Returns a value interpolated from a Quadratic Bézier.</returns>
    /// <acknowledgment>
    /// http://paulbourke.net/geometry/bezier/index.html
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T QuadraticBezier<T>(T t, T aV, T bV, T cV)
        where T : IFloatingPoint<T>
    {
        // The negative of t.
        var ti = T.One - t;

        return (aV * ti * ti) + (T.Create(2) * bV * ti * t) + (cV * t * t);
    }

    /// <summary>
    /// Three control point Bézier interpolation mu ranges from 0 to 1, start to end of the curve.
    /// </summary>
    /// <param name="t">The time parameter.</param>
    /// <param name="aX">The x-component of the first parameter.</param>
    /// <param name="aY">The y-component of the first parameter.</param>
    /// <param name="bX">The x-component of the second parameter.</param>
    /// <param name="bY">The y-component of the second parameter.</param>
    /// <param name="cX">The x-component of the third parameter.</param>
    /// <param name="cY">The y component of the third parameter.</param>
    /// <returns>Returns a point at t position of a Quadratic Bézier curve.</returns>
    /// <acknowledgment>
    /// http://paulbourke.net/geometry/bezier/index.html
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) QuadraticBezier<T>(T t, T aX, T aY, T bX, T bY, T cX, T cY)
        where T : IFloatingPoint<T>
    {
        T two = T.Create(2);

        // The negative of t.
        var ti = T.One - t;

        // The negative of t squared.
        var ti2 = ti * ti;

        // The t squared.
        var t2 = t * t;

        return (
            (aX * ti2) + two * bX * ti * t + (cX * t2),
            (aY * ti2) + two * bY * ti * t + (cY * t2)
            );
    }

    /// <summary>
    /// Three control point Bézier interpolation mu ranges from 0 to 1, start to end of the curve.
    /// </summary>
    /// <param name="t">The time parameter of the Bézier curve.</param>
    /// <param name="x0">The x-component of the first point on a Bézier curve.</param>
    /// <param name="y0">The y-component of the first point on a Bézier curve.</param>
    /// <param name="z0">The z-component of the first point on a Bézier curve.</param>
    /// <param name="x1">The x-component of the handle point of the Bézier curve.</param>
    /// <param name="y1">The y-component of the handle point of the Bézier curve.</param>
    /// <param name="z1">The z-component of the handle point of the Bézier curve.</param>
    /// <param name="x2">The x-component of the last point on the Bézier curve.</param>
    /// <param name="y2">The y-component of the last point on the Bézier curve.</param>
    /// <param name="z2">The z-component of the last point on the Bézier curve.</param>
    /// <returns>Returns a point on the Bézier curve.</returns>
    /// <acknowledgment>
    /// http://paulbourke.net/geometry/bezier/index.html
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z) QuadraticBezier<T>(T t, T x0, T y0, T z0, T x1, T y1, T z1, T x2, T y2, T z2)
        where T : IFloatingPoint<T>
    {
        T two = T.Create(2);

        // The negative of t.
        var ti = T.One - t;

        // The negative of t squared.
        var ti2 = ti * ti;

        // The t squared.
        var t2 = t * t;

        return (
            (x0 * ti2) + two * x1 * ti * t + (x2 * t2),
            (y0 * ti2) + two * y1 * ti * t + (y2 * t2),
            (z0 * ti2) + two * z1 * ti * t + (z2 * t2));
    }
    #endregion

    #region Cubic Interpolation
    /// <summary>
    /// The cubic.
    /// </summary>
    /// <param name="t">The t.</param>
    /// <param name="aV">The aV.</param>
    /// <param name="bV">The bV.</param>
    /// <param name="cV">The cV.</param>
    /// <param name="dV">The dV.</param>
    /// <returns>The <see cref="double"/>.</returns>
    /// <acknowledgment>
    /// http://paulbourke.net/miscellaneous/interpolation/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T Cubic<T>(T t, T aV, T bV, T cV, T dV)
        where T : IFloatingPoint<T>
    {
        var t2 = t * t;
        var a0 = dV - cV - aV + bV;
        return (a0 * t * t2) + ((aV - bV - a0) * t2) + ((cV - aV) * t) + bV;
    }

    /// <summary>
    /// The cubic.
    /// </summary>
    /// <param name="t">The t.</param>
    /// <param name="aX">The aX.</param>
    /// <param name="aY">The aY.</param>
    /// <param name="bX">The bX.</param>
    /// <param name="bY">The bY.</param>
    /// <param name="cX">The cX.</param>
    /// <param name="cY">The cY.</param>
    /// <param name="dX">The dX.</param>
    /// <param name="dY">The dY.</param>
    /// <returns>The <see cref="ValueTuple{T1, T2}"/>.</returns>
    /// <acknowledgment>
    /// http://paulbourke.net/miscellaneous/interpolation/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) Cubic<T>(T t, T aX, T aY, T bX, T bY, T cX, T cY, T dX, T dY)
        where T : IFloatingPoint<T>
    {
        var t2 = t * t;
        var aX0 = dX - cX - aX + bX;
        var aY0 = dY - cY - aY + bY;
        return (
            (aX0 * t * t2) + ((aX - bX - aX0) * t2) + ((cX - aX) * t) + bX,
            (aY0 * t * t2) + ((aY - bY - aY0) * t2) + ((cY - aY) * t) + bY);
    }

    /// <summary>
    /// The cubic.
    /// </summary>
    /// <param name="t">The t.</param>
    /// <param name="aX">The aX.</param>
    /// <param name="aY">The aY.</param>
    /// <param name="aZ">The aZ.</param>
    /// <param name="bX">The bX.</param>
    /// <param name="bY">The bY.</param>
    /// <param name="bZ">The bZ.</param>
    /// <param name="cX">The cX.</param>
    /// <param name="cY">The cY.</param>
    /// <param name="cZ">The cZ.</param>
    /// <param name="dX">The dX.</param>
    /// <param name="dY">The dY.</param>
    /// <param name="dZ">The dZ.</param>
    /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
    /// <acknowledgment>
    /// http://paulbourke.net/miscellaneous/interpolation/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z) Cubic<T>(T t, T aX, T aY, T aZ, T bX, T bY, T bZ, T cX, T cY, T cZ, T dX, T dY, T dZ)
        where T : IFloatingPoint<T>
    {
        var t2 = t * t;
        var aX0 = dX - cX - aX + bX;
        var aY0 = dY - cY - aY + bY;
        var aZ0 = dZ - cZ - aZ + bZ;
        return (
            (aX0 * t * t2) + ((aX - bX - aX0) * t2) + ((cX - aX) * t) + bX,
            (aY0 * t * t2) + ((aY - bY - aY0) * t2) + ((cY - aY) * t) + bY,
            (aZ0 * t * t2) + ((aZ - bZ - aZ0) * t2) + ((cZ - aZ) * t) + bZ);
    }
    #endregion

    #region Cubic Bézier Interpolation
    /// <summary>
    /// Four control point 1D Quadratic Bézier interpolation for ranges from 0 to 1, start to end of curve.
    /// </summary>
    /// <param name="t">The t index of the curve.</param>
    /// <param name="v0">The first anchor value.</param>
    /// <param name="v1">The first handle value.</param>
    /// <param name="v2">The second handle value.</param>
    /// <param name="v3">The second anchor value.</param>
    /// <returns>Returns a <see cref="double"/> representing a value on the Bézier curve at the t index.</returns>
    /// <acknowledgment>
    /// http://paulbourke.net/geometry/bezier/index.html
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T CubicBezier<T>(T t, T v0, T v1, T v2, T v3)
        where T : IFloatingPoint<T>
    {
        T three = T.Create(3);

        // Negate t.
        var ti = T.One - t;

        // Negated t Cubed.
        var ti3 = ti * ti * ti;

        // The t Cubed.
        var t3 = t * t * t;

        return (ti3 * v0) + three * t * ti * ti * v1 + three * t * t * ti * v2 + (t3 * v3);
    }

    /// <summary>
    /// Four control point 2D Quadratic Bézier interpolation for ranges from 0 to 1, start to end of curve.
    /// </summary>
    /// <param name="t">The t index of the curve.</param>
    /// <param name="x0">The first anchor point x value.</param>
    /// <param name="y0">The first anchor point y value.</param>
    /// <param name="x1">The first handle point x value.</param>
    /// <param name="y1">The first handle point y value.</param>
    /// <param name="x2">The second handle point x value.</param>
    /// <param name="y2">The second handle point y value.</param>
    /// <param name="x3">The second anchor point x value.</param>
    /// <param name="y3">The second anchor point y value.</param>
    /// <returns>Returns a <see cref="ValueTuple{T1, T2}"/> representing a point on the Bézier curve at the t index.</returns>
    /// <acknowledgment>
    /// http://paulbourke.net/geometry/bezier/index.html
    /// https://github.com/burningmime/curves
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) CubicBezier<T>(T t, T x0, T y0, T x1, T y1, T x2, T y2, T x3, T y3)
        where T : IFloatingPoint<T>
    {
        T three = T.Create(3);

        // The negative of t.
        var ti = T.One - t;

        // The negative of t cubed.
        var ti3 = ti * ti * ti;

        // The t cubed.
        var t3 = t * t * t;

        return (
            X: (ti3 * x0) + three * ti * ti * t * x1 + three * ti * t * t * x2 + (t3 * x3),
            Y: (ti3 * y0) + three * ti * ti * t * y1 + three * ti * t * t * y2 + (t3 * y3)
            );
    }

    /// <summary>
    /// Four control point 2D Quadratic Bézier interpolation for ranges from 0 to 1, start to end of curve.
    /// </summary>
    /// <param name="t">The t index of the curve.</param>
    /// <param name="x0">The first anchor point x value.</param>
    /// <param name="y0">The first anchor point y value.</param>
    /// <param name="z0">The first anchor point z value..</param>
    /// <param name="x1">The first handle point x value.</param>
    /// <param name="y1">The first handle point y value.</param>
    /// <param name="z1">The first handle point z value.</param>
    /// <param name="x2">The second handle point x value.</param>
    /// <param name="y2">The second handle point y value.</param>
    /// <param name="z2">The second handle point z value.</param>
    /// <param name="x3">The second anchor point x value.</param>
    /// <param name="y3">The second anchor point y value.</param>
    /// <param name="z3">The second anchor point z value.</param>
    /// <returns>Returns a <see cref="ValueTuple{T1, T2, T3}"/> representing a point on the Bézier curve at the t index.</returns>
    /// <acknowledgment>
    /// http://paulbourke.net/geometry/bezier/index.html
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z) CubicBezier<T>(T t, T x0, T y0, T z0, T x1, T y1, T z1, T x2, T y2, T z2, T x3, T y3, T z3)
        where T : IFloatingPoint<T>
    {
        T three = T.Create(3);

        // The negative of t.
        var ti = T.One - t;

        // The negative of t cubed.
        var ti3 = ti * ti * ti;

        // The t cubed.
        var t3 = t * t * t;

        return (
            (ti3 * x0) + three * t * ti * ti * x1 + three * t * t * ti * x2 + (t3 * x3),
            (ti3 * y0) + three * t * ti * ti * y1 + three * t * t * ti * y2 + (t3 * y3),
            (ti3 * z0) + three * t * ti * ti * z1 + three * t * t * ti * z2 + (t3 * z3)
            );
    }
    #endregion

    #region Quintic Bézier Interpolation
    /// <summary>
    /// Quintics the bezier.
    /// </summary>
    /// <param name="t">The t.</param>
    /// <param name="p0X">The p0 x.</param>
    /// <param name="p0Y">The p0 y.</param>
    /// <param name="p1X">The p1 x.</param>
    /// <param name="p1Y">The p1 y.</param>
    /// <param name="p2X">The p2 x.</param>
    /// <param name="p2Y">The p2 y.</param>
    /// <param name="p3X">The p3 x.</param>
    /// <param name="p3Y">The p3 y.</param>
    /// <param name="p4X">The p4 x.</param>
    /// <param name="p4Y">The p4 y.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) QuinticBezier<T>(T t, T p0X, T p0Y, T p1X, T p1Y, T p2X, T p2Y, T p3X, T p3Y, T p4X, T p4Y) where T : IFloatingPoint<T> => CubicBezierSpline(t, new List<ValuePoint2<T>> { new(p0X, p0Y), new(p1X, p1Y), new(p2X, p2Y), new(p3X, p3Y), new(p4X, p4Y) });
    #endregion

    #region N Bézier Interpolation
    /// <summary>
    /// General Bézier curve Number of control points is n+1 0 less than or equal to mu less than 1
    /// IMPORTANT, the last point is not computed.
    /// </summary>
    /// <param name="t"></param>
    /// <param name="points"></param>
    /// <returns></returns>
    /// <acknowledgment>
    /// http://paulbourke.net/geometry/bezier/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) CubicBezierSpline<T>(T t, List<ValuePoint2<T>> points)
        where T : IFloatingPoint<T>
    {
        var n = points.Count - 1;
        int kn;
        int nn;
        int nkn;

        T blend;
        var muk = T.One;
        var munk = T.Pow(T.One - t, T.Create(n));

        var b = (X: T.Zero, Y: T.Zero);

        for (var k = 0; k <= n; k++)
        {
            nn = n;
            kn = k;
            nkn = n - k;
            blend = muk * munk;
            muk *= t;
            munk /= T.One - t;
            while (nn >= 1)
            {
                blend *= T.Create(nn);
                nn--;
                if (kn > 1)
                {
                    blend /= T.Create(kn);
                    kn--;
                }
                if (nkn > 1)
                {
                    blend /= T.Create(nkn);
                    nkn--;
                }
            }

            b = (
                b.X + (points[k].X * blend),
                b.Y + (points[k].Y * blend)
            );
        }

        return b;
    }
    #endregion

    #region Catmull-Rom Spline Interpolation
    /// <summary>
    /// The catmull rom.
    /// </summary>
    /// <param name="t">The t.</param>
    /// <param name="tangentA">The tangentA.</param>
    /// <param name="positionA">The positionA.</param>
    /// <param name="positionB">The positionB.</param>
    /// <param name="tangentB">The tangentB.</param>
    /// <returns>The <see cref="Point2{T}"/>.</returns>
    /// <acknowledgment>
    /// http://tehc0dez.blogspot.com/2010/04/nice-curves-catmullrom-spline-in-c.html
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) CatmullRom<T>(T t, (T X, T Y) tangentA, (T X, T Y) positionA, (T X, T Y) positionB, (T X, T Y) tangentB)
        where T : INumber<T>
    {
        var t2 = t * t;
        var t3 = t2 * t;

        T two = T.Create(2);
        T four = T.Create(4);
        T three = T.Create(3);
        T five = T.Create(5);

        return (
            (two * positionA.X
            + ((-tangentA.X + positionB.X) * t) + ((two * tangentA.X - five * positionA.X
            + four * positionB.X - tangentB.X) * t2)
            + ((-tangentA.X + three * positionA.X - three * positionB.X + tangentB.X) * t3)) / two,
            two * positionA.Y
            + ((-tangentA.Y + positionB.Y) * t) + ((two * tangentA.Y - five * positionA.Y
            + four * positionB.Y - tangentB.Y) * t2)
            + (-tangentA.Y + three * positionA.Y - three * positionB.Y + tangentB.Y) * t3 / two
        );
    }

    /// <summary>
    /// Performs a Catmull-Rom interpolation using the specified positions.
    /// </summary>
    /// <param name="t">Weighting factor.</param>
    /// <param name="aV">The first position in the interpolation.</param>
    /// <param name="bV">The second position in the interpolation.</param>
    /// <param name="cV">The third position in the interpolation.</param>
    /// <param name="dV">The fourth position in the interpolation.</param>
    /// <returns>A position that is the result of the Catmull-Rom interpolation.</returns>
    /// <acknowledgment>
    /// http://www.mvps.org/directx/articles/catmull/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T CatmullRom<T>(T t, T aV, T bV, T cV, T dV)
        where T : INumber<T>
    {
        var t2 = t * t;
        var t3 = t2 * t;

        T two = T.Create(2);
        T three = T.Create(3);
        T four = T.Create(4);
        T five = T.Create(5);

        return
            (two * bV
            + ((cV - aV) * t)
            + ((two * aV - five * bV + four * cV - dV) * t2)
            + ((three * bV - aV - three * cV + dV) * t3)) / two;
    }

    /// <summary>
    /// Calculates interpolated point between two points using Catmull-Rom Spline
    /// </summary>
    /// <param name="t">
    /// Normalized distance between second and third point
    /// where the spline point will be calculated
    /// </param>
    /// <param name="aX">First Point</param>
    /// <param name="aY">First Point</param>
    /// <param name="bX">Second Point</param>
    /// <param name="bY">Second Point</param>
    /// <param name="cX">Third Point</param>
    /// <param name="cY">Third Point</param>
    /// <param name="dX">Fourth Point</param>
    /// <param name="dY">Fourth Point</param>
    /// <returns>
    /// Calculated Spline Point
    /// </returns>
    /// <remarks>
    /// <para>Points calculated exist on the spline between points two and three.</para>
    /// </remarks>
    /// <acknowledgment>
    /// From: http://tehc0dez.blogspot.com/2010/04/nice-curves-catmullrom-spline-in-c.html
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) CatmullRom<T>(T t, T aX, T aY, T bX, T bY, T cX, T cY, T dX, T dY)
        where T : INumber<T>
    {
        var t2 = t * t;
        var t3 = t2 * t;

        T two = T.Create(2);
        T three = T.Create(3);
        T four = T.Create(4);
        T five = T.Create(5);

        return (
            (two * bX
            + ((-aX + cX) * t)
            + ((two * aX - five * bX + four * cX - dX) * t2)
            + ((-aX + three * bX - three * cX + dX) * t3)) / two,
            (two * bY
            + ((-aY + cY) * t)
            + ((two * aY - five * bY + four * cY - dY) * t2)
            + ((-aY + three * bY - three * cY + dY) * t3)) / two);
    }

    /// <summary>
    /// Performs a Catmull-Rom interpolation using the specified positions.
    /// </summary>
    /// <param name="t">Weighting factor.</param>
    /// <param name="aX">The first position in the interpolation.</param>
    /// <param name="aY">The first position in the interpolation.</param>
    /// <param name="aZ">The first position in the interpolation.</param>
    /// <param name="bX">The second position in the interpolation.</param>
    /// <param name="bY">The second position in the interpolation.</param>
    /// <param name="bZ">The second position in the interpolation.</param>
    /// <param name="cX">The third position in the interpolation.</param>
    /// <param name="cY">The third position in the interpolation.</param>
    /// <param name="cZ">The third position in the interpolation.</param>
    /// <param name="dX">The fourth position in the interpolation.</param>
    /// <param name="dY">The fourth position in the interpolation.</param>
    /// <param name="dZ">The fourth position in the interpolation.</param>
    /// <returns>A position that is the result of the Catmull-Rom interpolation.</returns>
    /// <acknowledgment>
    /// http://www.mvps.org/directx/articles/catmull/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z) CatmullRom<T>(T t, T aX, T aY, T aZ, T bX, T bY, T bZ, T cX, T cY, T cZ, T dX, T dY, T dZ)
        where T : INumber<T>
    {
        var t2 = t * t;
        var t3 = t2 * t;

        T two = T.Create(2);
        T three = T.Create(3);
        T four = T.Create(4);
        T five = T.Create(5);

        return (
            (two * bX
            + ((cX - aX) * t)
            + ((two * aX - five * bX + four * cX - dX) * t2)
            + ((three * bX - aX - three * cX + dX) * t3)) / two,
            (two * bX
            + ((cY - aY) * t)
            + ((two * aY - five * bY + four * cY - dY) * t2)
            + ((three * bY - aY - three * cY + dY) * t3)) / two,
            (two * bZ
            + ((cZ - aZ) * t)
            + ((two * aZ - five * bZ + four * cZ - dZ) * t2)
            + ((three * bZ - aZ - three * cZ + dZ) * t3)) / two);
    }
    #endregion

    #region Hermite Interpolation
    /// <summary>
    /// The hermite.
    /// </summary>
    /// <param name="t">The t time index parameter.</param>
    /// <param name="aV">The aV.</param>
    /// <param name="bV">The bV.</param>
    /// <param name="cV">The cV.</param>
    /// <param name="dV">The dV.</param>
    /// <returns>The <see cref="double"/>.</returns>
    /// <acknowledgment>
    /// http://paulbourke.net/miscellaneous/interpolation/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T Hermite<T>(T t, T aV, T bV, T cV, T dV) where T : INumber<T> => Hermite(t, aV, bV, cV, dV, T.Zero, T.Zero);

    /// <summary>
    /// The hermite.
    /// </summary>
    /// <param name="t">The t time index parameter.</param>
    /// <param name="aV">The aV.</param>
    /// <param name="bV">The bV.</param>
    /// <param name="cV">The cV.</param>
    /// <param name="dV">The dV.</param>
    /// <param name="tension">1 is high, 0 normal, -1 is low</param>
    /// <param name="bias">0 is even,positive is towards first segment, negative towards the other</param>
    /// <returns>The <see cref="double"/>.</returns>
    /// <acknowledgment>
    /// http://paulbourke.net/miscellaneous/interpolation/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T Hermite<T>(T t, T aV, T bV, T cV, T dV, T tension, T bias)
        where T : INumber<T>
    {
        var t2 = t * t;
        var t3 = t2 * t;

        var m0 = (bV - aV) * (T.One + bias) * (T.One - tension) / T.Create(2);
        m0 += (cV - bV) * (T.One - bias) * (T.One - tension) / T.Create(2);

        var m1 = (cV - bV) * (T.One + bias) * (T.One - tension) / T.Create(2);
        m1 += (dV - cV) * (T.One - bias) * (T.One - tension) / T.Create(2);

        return (((T.Create(2) * t3) - (T.Create(3) * t2) + T.One) * bV) + ((t3 - (T.Create(2) * t2) + t) * m0) + ((t3 - t2) * m1) + (((-T.Create(2) * t3) + (T.Create(3) * t2)) * cV);
    }

    /// <summary>
    /// The hermite.
    /// </summary>
    /// <param name="t">The t time index parameter.</param>
    /// <param name="aX">The aX.</param>
    /// <param name="aY">The aY.</param>
    /// <param name="bX">The bX.</param>
    /// <param name="bY">The bY.</param>
    /// <param name="cX">The cX.</param>
    /// <param name="cY">The cY.</param>
    /// <param name="dX">The dX.</param>
    /// <param name="dY">The dY.</param>
    /// <returns>The <see cref="ValueTuple{T1, T2}"/>.</returns>
    /// <acknowledgment>
    /// http://paulbourke.net/miscellaneous/interpolation/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) Hermite<T>(T t, T aX, T aY, T bX, T bY, T cX, T cY, T dX, T dY) where T : INumber<T> => Hermite(t, aX, aY, bX, bY, cX, cY, dX, dY, T.Zero, T.Zero);

    /// <summary>
    /// The hermite.
    /// </summary>
    /// <param name="t">The t time index parameter.</param>
    /// <param name="aX">The aX.</param>
    /// <param name="aY">The aY.</param>
    /// <param name="bX">The bX.</param>
    /// <param name="bY">The bY.</param>
    /// <param name="cX">The cX.</param>
    /// <param name="cY">The cY.</param>
    /// <param name="dX">The dX.</param>
    /// <param name="dY">The dY.</param>
    /// <param name="tension">1 is high, 0 normal, -1 is low</param>
    /// <param name="bias">0 is even,positive is towards first segment, negative towards the other</param>
    /// <returns>The <see cref="ValueTuple{T1, T2}"/>.</returns>
    /// <acknowledgment>
    /// http://paulbourke.net/miscellaneous/interpolation/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) Hermite<T>(T t, T aX, T aY, T bX, T bY, T cX, T cY, T dX, T dY, T tension, T bias)
        where T : INumber<T>
    {
        var t2 = t * t;
        var t3 = t2 * t;

        T one = T.One;
        T two = T.Create(2);
        T three = T.Create(3);
        var mX0 = (bX - aX) * (one + bias) * (one - tension) / two;
        mX0 += (cX - bX) * (one - bias) * (one - tension) / two;

        var mY0 = (bY - aY) * (one + bias) * (one - tension) / two;
        mY0 += (cY - bY) * (one - bias) * (one - tension) / two;

        var mX1 = (cX - bX) * (one + bias) * (one - tension) / two;
        mX1 += (dX - cX) * (one - bias) * (one - tension) / two;

        var mY1 = (cY - bY) * (one + bias) * (one - tension) / two;
        mY1 += (dY - cY) * (one - bias) * (one - tension) / two;

        var a0 = (two * t3) - (three * t2) + one;
        var a1 = t3 - (two * t2) + t;
        var a2 = t3 - t2;
        var a3 = (-two * t3) + (three * t2);

        return (
            (a0 * bX) + (a1 * mX0) + (a2 * mX1) + (a3 * cX),
            (a0 * bY) + (a1 * mY0) + (a2 * mY1) + (a3 * cY));
    }

    /// <summary>
    /// The hermite.
    /// </summary>
    /// <param name="t">The t time index parameter.</param>
    /// <param name="aX">The aX.</param>
    /// <param name="aY">The aY.</param>
    /// <param name="aZ">The aZ.</param>
    /// <param name="bX">The bX.</param>
    /// <param name="bY">The bY.</param>
    /// <param name="bZ">The bZ.</param>
    /// <param name="cX">The cX.</param>
    /// <param name="cY">The cY.</param>
    /// <param name="cZ">The cZ.</param>
    /// <param name="dX">The dX.</param>
    /// <param name="dY">The dY.</param>
    /// <param name="dZ">The dZ.</param>
    /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
    /// <acknowledgment>
    /// http://paulbourke.net/miscellaneous/interpolation/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z) Hermite<T>(T t, T aX, T aY, T aZ, T bX, T bY, T bZ, T cX, T cY, T cZ, T dX, T dY, T dZ) where T : INumber<T> => Hermite(t, aX, aY, aZ, bX, bY, bZ, cX, cY, cZ, dX, dY, dZ, T.Zero, T.Zero);

    /// <summary>
    /// The hermite.
    /// </summary>
    /// <param name="t">The t time index parameter.</param>
    /// <param name="aX">The aX.</param>
    /// <param name="aY">The aY.</param>
    /// <param name="aZ">The aZ.</param>
    /// <param name="bX">The bX.</param>
    /// <param name="bY">The bY.</param>
    /// <param name="bZ">The bZ.</param>
    /// <param name="cX">The cX.</param>
    /// <param name="cY">The cY.</param>
    /// <param name="cZ">The cZ.</param>
    /// <param name="dX">The dX.</param>
    /// <param name="dY">The dY.</param>
    /// <param name="dZ">The dZ.</param>
    /// <param name="tension">1 is high, 0 normal, -1 is low</param>
    /// <param name="bias">0 is even, positive is towards first segment, negative towards the other</param>
    /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
    /// <acknowledgment>
    /// http://paulbourke.net/miscellaneous/interpolation/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z) Hermite<T>(T t, T aX, T aY, T aZ, T bX, T bY, T bZ, T cX, T cY, T cZ, T dX, T dY, T dZ, T tension, T bias)
        where T : INumber<T>
    {
        var t2 = t * t;
        var t3 = t2 * t;

        T one = T.One;
        T two = T.Create(2);
        T three = T.Create(3);
        var mX0 = (bX - aX) * (one + bias) * (one - tension) / two;
        mX0 += (cX - bX) * (one - bias) * (one - tension) / two;

        var mY0 = (bY - aY) * (one + bias) * (one - tension) / two;
        mY0 += (cY - bY) * (one - bias) * (one - tension) / two;

        var mZ0 = (bZ - aZ) * (one + bias) * (one - tension) / two;
        mZ0 += (cZ - bZ) * (one - bias) * (one - tension) / two;

        var mX1 = (cX - bX) * (one + bias) * (one - tension) / two;
        mX1 += (dX - cX) * (one - bias) * (one - tension) / two;

        var mY1 = (cY - bY) * (one + bias) * (one - tension) / two;
        mY1 += (dY - cY) * (one - bias) * (one - tension) / two;

        var mZ1 = (cZ - bZ) * (one + bias) * (one - tension) / two;
        mZ1 += (dZ - cZ) * (one - bias) * (one - tension) / two;

        var a0 = (two * t3) - three * t2 + one;
        var a1 = t3 - (two * t2) + t;
        var a2 = t3 - t2;
        var a3 = (-two * t3) + three * t2;

        return (
            (a0 * bX) + (a1 * mX0) + (a2 * mX1) + (a3 * cX),
            (a0 * bY) + (a1 * mY0) + (a2 * mY1) + (a3 * cY),
            (a0 * bZ) + (a1 * mZ0) + (a2 * mZ1) + (a3 * cZ));
    }
    #endregion

    #region Circle Interpolation
    /// <summary>
    /// Interpolates the Arc.
    /// </summary>
    /// <param name="t">Theta of interpolation.</param>
    /// <param name="cX">Center x-coordinate.</param>
    /// <param name="cY">Center y-coordinate.</param>
    /// <param name="r">Radius of circle.</param>
    /// <param name="startAngle">The angle to start the arc.</param>
    /// <param name="sweepAngle">The difference of the angle to where the arc should end.</param>
    /// <returns>Interpolated point at theta.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) CircularArc<T>(T t, T cX, T cY, T r, T startAngle, T sweepAngle) where T : IFloatingPoint<T> => Circle(startAngle + (sweepAngle * t), cX, cY, r);

    /// <summary>
    /// Interpolate a point on a circle, converting from unit iteration, to Pi radians.
    /// </summary>
    /// <param name="t">Theta of interpolation.</param>
    /// <param name="cX">Center x-coordinate.</param>
    /// <param name="cY">Center y-coordinate.</param>
    /// <param name="r">Radius of circle.</param>
    /// <returns>Interpolated point at theta.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) UnitCircle<T>(T t, T cX, T cY, T r) where T : IFloatingPoint<T> => Circle(T.Tau * t, cX, cY, r);

    /// <summary>
    /// Interpolate a point on a circle, applying translation to equation of circle at origin.
    /// </summary>
    /// <param name="t">Theta of interpolation.</param>
    /// <param name="cX">Center x-coordinate.</param>
    /// <param name="cY">Center y-coordinate.</param>
    /// <param name="r">Radius of circle.</param>
    /// <returns>Interpolated point at theta.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) Circle<T>(T t, T cX, T cY, T r) where T : IFloatingPoint<T> => (cX + (T.Cos(t) * r), cY + (T.Sin(t) * r));
    #endregion

    #region Ellipse Interpolation
    /// <summary>
    /// Interpolates the orthogonal elliptical Arc.
    /// </summary>
    /// <param name="t">Theta of interpolation.</param>
    /// <param name="cX">Center x-coordinate.</param>
    /// <param name="cY">Center y-coordinate.</param>
    /// <param name="r1">The first radius of the Ellipse.</param>
    /// <param name="r2">The second radius of the Ellipse.</param>
    /// <param name="startAngle">The angle to start the arc.</param>
    /// <param name="sweepAngle">The difference of the angle to where the arc should end.</param>
    /// <returns>Interpolated point at theta.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) EllipticalArc<T>(T t, T cX, T cY, T r1, T r2, T startAngle, T sweepAngle)
        where T : IFloatingPoint<T>
    {
        var phi = startAngle + (sweepAngle * t);
        var theta = phi % T.Pi;

        var tanAngle = T.Abs(T.Tan(theta));
        var x = T.Sqrt(r1 * r1 * (r2 * r2) / ((r2 * r2) + (r1 * r1 * (tanAngle * tanAngle))));
        var y = x * tanAngle;

        return (theta >= T.Zero) && (theta < Operations.DegreesToRadians<T, T>(T.Create(90)))
            ? (cX + x, cY + y)
            : (theta >= Operations.DegreesToRadians<T, T>(T.Create(90))) && (theta < Operations.DegreesToRadians<T, T>(T.Create(180)))
            ? (cX - x, cY + y)
            : (theta >= Operations.DegreesToRadians<T, T>(T.Create(180))) && (theta < Operations.DegreesToRadians<T, T>(T.Create(270))) ? (cX - x, cY - y) : (cX + x, cY - y);
    }

    /// <summary>
    /// Interpolates the Elliptical Arc, corrected for Polar coordinates.
    /// </summary>
    /// <param name="t">Theta of interpolation.</param>
    /// <param name="cX">Center x-coordinate.</param>
    /// <param name="cY">Center y-coordinate.</param>
    /// <param name="r1">The first radius of the Ellipse.</param>
    /// <param name="r2">The second radius of the Ellipse.</param>
    /// <param name="angle">Angle of rotation of Ellipse about it's center.</param>
    /// <param name="startAngle">The angle to start the arc.</param>
    /// <param name="sweepAngle">The difference of the angle to where the arc should end.</param>
    /// <returns>Interpolated point at theta.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) EllipticalArc<T>(T t, T cX, T cY, T r1, T r2, T angle, T startAngle, T sweepAngle) where T : IFloatingPoint<T> => PolarEllipse(startAngle + (sweepAngle * t), cX, cY, r1, r2, angle);

    /// <summary>
    /// Interpolates the Elliptical Arc, corrected for Polar coordinates.
    /// </summary>
    /// <param name="t">Theta of interpolation.</param>
    /// <param name="cX">Center x-coordinate.</param>
    /// <param name="cY">Center y-coordinate.</param>
    /// <param name="r1">The first radius of the Ellipse.</param>
    /// <param name="r2">The second radius of the Ellipse.</param>
    /// <param name="cosAngle">Horizontal rotation transform of the Ellipse.</param>
    /// <param name="sinAngle">Vertical rotation transform of the Ellipse.</param>
    /// <param name="startAngle">The angle to start the arc.</param>
    /// <param name="sweepAngle">The difference of the angle to where the arc should end.</param>
    /// <returns>Interpolated point at theta.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) EllipticalArc<T>(T t, T cX, T cY, T r1, T r2, T cosAngle, T sinAngle, T startAngle, T sweepAngle) where T : IFloatingPoint<T> => PolarEllipse(startAngle + (sweepAngle * t), cX, cY, r1, r2, cosAngle, sinAngle);

    /// <summary>
    /// Interpolate a point on an Ellipse with Polar correction using a range from 0 to 1 for unit interpolation.
    /// </summary>
    /// <param name="t">Theta of interpolation.</param>
    /// <param name="cX">Center x-coordinate.</param>
    /// <param name="cY">Center y-coordinate.</param>
    /// <param name="r1">The first radius of the Ellipse.</param>
    /// <param name="r2">The second radius of the Ellipse.</param>
    /// <param name="angle">Angle of rotation of Ellipse about it's center.</param>
    /// <returns>Interpolated point at theta adjusted to Polar angles.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) UnitPolarEllipse<T>(T t, T cX, T cY, T r1, T r2, T angle) where T : IFloatingPoint<T> => PolarEllipse(T.Tau * t, cX, cY, r1, r2, angle);

    /// <summary>
    /// Interpolate a point on an Ellipse with Polar correction using a range from 0 to 1 for unit interpolation.
    /// </summary>
    /// <param name="t">Theta of interpolation.</param>
    /// <param name="cX">Center x-coordinate.</param>
    /// <param name="cY">Center y-coordinate.</param>
    /// <param name="r1">The first radius of the Ellipse.</param>
    /// <param name="r2">The second radius of the Ellipse.</param>
    /// <param name="cosAngle">Horizontal rotation transform of the Ellipse.</param>
    /// <param name="sinAngle">Vertical rotation transform of the Ellipse.</param>
    /// <returns>Interpolated point at theta adjusted to Polar angles.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) UnitPolarEllipse<T>(T t, T cX, T cY, T r1, T r2, T cosAngle, T sinAngle) where T : IFloatingPoint<T> => PolarEllipse(T.Tau * t, cX, cY, r1, r2, cosAngle, sinAngle);

    /// <summary>
    /// Interpolate a point on an Ellipse with Polar correction.
    /// </summary>
    /// <param name="t">Theta of interpolation.</param>
    /// <param name="cX">Center x-coordinate.</param>
    /// <param name="cY">Center y-coordinate.</param>
    /// <param name="r1">The first radius of the Ellipse.</param>
    /// <param name="r2">The second radius of the Ellipse.</param>
    /// <param name="angle">Angle of rotation of Ellipse about it's center.</param>
    /// <returns>Interpolated point at theta adjusted to Polar angles.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) PolarEllipse<T>(T t, T cX, T cY, T r1, T r2, T angle) where T : IFloatingPoint<T> => Ellipse(Operations.EllipticalPolarAngle(t, r1, r2), cX, cY, r1, r2, angle);

    /// <summary>
    /// Interpolate a point on an Ellipse with Polar correction.
    /// </summary>
    /// <param name="t">Theta of interpolation.</param>
    /// <param name="cX">Center x-coordinate.</param>
    /// <param name="cY">Center y-coordinate.</param>
    /// <param name="r1">The first radius of the Ellipse.</param>
    /// <param name="r2">The second radius of the Ellipse.</param>
    /// <param name="cosAngle">Horizontal rotation transform of the Ellipse.</param>
    /// <param name="sinAngle">Vertical rotation transform of the Ellipse.</param>
    /// <returns>Interpolated point at theta adjusted to Polar angles.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) PolarEllipse<T>(T t, T cX, T cY, T r1, T r2, T cosAngle, T sinAngle) where T : IFloatingPoint<T> => Ellipse(Operations.EllipticalPolarAngle(t, r1, r2), cX, cY, r1, r2, cosAngle, sinAngle);

    /// <summary>
    /// Interpolate a point on an Ellipse.
    /// </summary>
    /// <param name="t">Theta of interpolation.</param>
    /// <param name="cX">Center x-coordinate.</param>
    /// <param name="cY">Center y-coordinate.</param>
    /// <param name="r1">The first radius of the Ellipse.</param>
    /// <param name="r2">The second radius of the Ellipse.</param>
    /// <param name="angle">Angle of rotation of Ellipse about it's center.</param>
    /// <returns>Interpolated point at theta.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) Ellipse<T>(T t, T cX, T cY, T r1, T r2, T angle) where T : IFloatingPoint<T> => Ellipse(T.Cos(t), T.Sin(t), cX, cY, r1, r2, T.Cos(angle), T.Sin(angle));

    /// <summary>
    /// Interpolate a point on an Ellipse.
    /// </summary>
    /// <param name="t">Theta of interpolation.</param>
    /// <param name="cX">Center x-coordinate.</param>
    /// <param name="cY">Center y-coordinate.</param>
    /// <param name="r1">The first radius of the Ellipse.</param>
    /// <param name="r2">The second radius of the Ellipse.</param>
    /// <param name="cosAngle">Horizontal rotation transform of the Ellipse.</param>
    /// <param name="sinAngle">Vertical rotation transform of the Ellipse.</param>
    /// <returns>Interpolated point at theta.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) Ellipse<T>(T t, T cX, T cY, T r1, T r2, T cosAngle, T sinAngle) where T : IFloatingPoint<T> => Ellipse(T.Cos(t), T.Sin(t), cX, cY, r1, r2, cosAngle, sinAngle);

    /// <summary>
    /// Interpolate a point on an Ellipse.
    /// </summary>
    /// <param name="cosTheta">Theta cosine of interpolation.</param>
    /// <param name="sinTheta">Theta sine of interpolation.</param>
    /// <param name="cX">Center x-coordinate.</param>
    /// <param name="cY">Center y-coordinate.</param>
    /// <param name="r1">The first radius of the Ellipse.</param>
    /// <param name="r2">The second radius of the Ellipse.</param>
    /// <param name="cosAngle">Horizontal rotation transform of the Ellipse.</param>
    /// <param name="sinAngle">Vertical rotation transform of the Ellipse.</param>
    /// <returns>Interpolated point at theta.</returns>
    /// <acknowledgment>
    /// http://www.vbforums.com/showthread.php?686351-RESOLVED-Elliptical-orbit
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) Ellipse<T>(T cosTheta, T sinTheta, T cX, T cY, T r1, T r2, T cosAngle, T sinAngle)
        where T : IFloatingPoint<T>
    {
        // Ellipse equation for an ellipse at origin.
        var u = r1 * cosTheta;
        var v = -(r2 * sinTheta);

        // Apply the rotation transformation and translate to new center.
        return (
            cX + ((u * cosAngle) + (v * sinAngle)),
            cY + ((u * sinAngle) - (v * cosAngle)));
    }
    #endregion

    #region Cosine Interpolation
    /// <summary>
    /// The cosine.
    /// </summary>
    /// <param name="t">The t.</param>
    /// <param name="aV">The aV.</param>
    /// <param name="bV">The bV.</param>
    /// <returns>The <see cref="double"/>.</returns>
    /// <acknowledgment>
    /// http://paulbourke.net/miscellaneous/interpolation/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T Cosine<T>(T t, T aV, T bV)
        where T : IFloatingPoint<T>
    {
        var mu2 = (T.One - T.Cos(t * T.Pi)) / T.Create(2);
        return (aV * (T.One - mu2)) + (bV * mu2);
    }

    /// <summary>
    /// The cosine.
    /// </summary>
    /// <param name="t">The t.</param>
    /// <param name="aX">The aX.</param>
    /// <param name="aY">The aY.</param>
    /// <param name="bX">The bX.</param>
    /// <param name="bY">The bY.</param>
    /// <returns>The <see cref="ValueTuple{T1, T2}"/>.</returns>
    /// <acknowledgment>
    /// http://paulbourke.net/miscellaneous/interpolation/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) Cosine<T>(T t, T aX, T aY, T bX, T bY)
        where T : IFloatingPoint<T>
    {
        var mu2 = (T.One - T.Cos(t * T.Pi)) / T.Create(2);
        return ((aX * (T.One - mu2)) + (bX * mu2),
                (aY * (T.One - mu2)) + (bY * mu2));
    }

    /// <summary>
    /// The cosine.
    /// </summary>
    /// <param name="t">The t.</param>
    /// <param name="aX">The aX.</param>
    /// <param name="aY">The aY.</param>
    /// <param name="aZ">The aZ.</param>
    /// <param name="bX">The bX.</param>
    /// <param name="bY">The bY.</param>
    /// <param name="bZ">The bZ.</param>
    /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
    /// <acknowledgment>
    /// http://paulbourke.net/miscellaneous/interpolation/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z) Cosine<T>(T t, T aX, T aY, T aZ, T bX, T bY, T bZ)
        where T : IFloatingPoint<T>
    {
        var mu2 = (T.One - T.Cos(t * T.Pi)) / T.Create(2);
        return (
            (aX * (T.One - mu2)) + (bX * mu2),
            (aY * (T.One - mu2)) + (bY * mu2),
            (aZ * (T.One - mu2)) + (bZ * mu2));
    }
    #endregion

    #region Sine Interpolation
    /// <summary>
    /// Interpolate a sine wave.
    /// </summary>
    /// <param name="t">The time parameter.</param>
    /// <param name="v1">The first parameter.</param>
    /// <param name="v2">The second Parameter.</param>
    /// <returns>Returns a value of a Sine wave at t.</returns>
    /// <acknowledgment>
    /// http://paulbourke.net/miscellaneous/interpolation/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T Sine<T>(T t, T v1, T v2)
        where T : IFloatingPoint<T>
    {
        var mu2 = (T.One - T.Sin(t * T.Pi)) * T.Create(0.5);
        return (v1 * (T.One - mu2)) + (v2 * mu2);
    }

    /// <summary>
    /// Interpolates a sine wave in 2 dimensions.
    /// </summary>
    /// <param name="t">The t parameter.</param>
    /// <param name="x1">The first x component.</param>
    /// <param name="y1">The first y-component.</param>
    /// <param name="x2">The second x-component.</param>
    /// <param name="y2">The second y-component.</param>
    /// <returns>Returns a point interpolated of a Sine wave.</returns>
    /// <acknowledgment>
    /// http://paulbourke.net/miscellaneous/interpolation/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) Sine<T>(T t, T x1, T y1, T x2, T y2)
        where T : IFloatingPoint<T>
    {
        var mu2 = (T.One - T.Sin(t * T.Pi)) * T.Create(0.5);
        return (
            (x1 * (T.One - mu2)) + (x2 * mu2),
            (y1 * (T.One - mu2)) + (y2 * mu2));
    }

    /// <summary>
    /// Interpolates a Sine wave at t parameter.
    /// </summary>
    /// <param name="t">The time parameter.</param>
    /// <param name="x1">The x-component of the first parameter.</param>
    /// <param name="y1">The y-component of the first parameter.</param>
    /// <param name="z1">The z-component of the first parameter.</param>
    /// <param name="x2">The x-component of the second parameter.</param>
    /// <param name="y2">The y-component of the second parameter.</param>
    /// <param name="z2">The z-component of the second parameter.</param>
    /// <returns>Returns a point in 2 dimensional space interpolated from a sine wave.</returns>
    /// <acknowledgment>
    /// http://paulbourke.net/miscellaneous/interpolation/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z) Sine<T>(T t, T x1, T y1, T z1, T x2, T y2, T z2)
        where T : IFloatingPoint<T>
    {
        var mu2 = (T.One - T.Sin(t * T.Pi)) * T.Create(0.5);
        return (
            (x1 * (T.One - mu2)) + (x2 * mu2),
            (y1 * (T.One - mu2)) + (y2 * mu2),
            (z1 * (T.One - mu2)) + (z2 * mu2));
    }
    #endregion

    #region Parabola
    /// <summary>
    /// Interpolate a parabola from the standard parabolic equation.
    /// </summary>
    /// <param name="t">The <paramref name="t" />ime index of the iteration.</param>
    /// <param name="a">The <paramref name="a" /> component of the parabola.</param>
    /// <param name="b">The <paramref name="b" /> component of the parabola.</param>
    /// <param name="c">The <paramref name="c" /> component of the parabola.</param>
    /// <param name="x1">The <paramref name="x1" />imum x value to interpolate.</param>
    /// <param name="x2">The <paramref name="x2" />imum x value to interpolate.</param>
    /// <returns>
    /// Returns a <see cref="ValueTuple{T1, T2}" /> representing the interpolated point at the t index.
    /// </returns>
    /// <example>
    ///   <code>
    /// var a = 0.0125d;
    /// var h = 100d;
    /// var k = 100d;
    /// var b = -2d * a * h;
    /// var c = (b * b / (4 * a)) + k;
    /// var min = -100d;
    /// var max = 100d;
    /// var list = new List&lt;(double X, double Y)&gt;();
    /// for (int i = 0; i &lt; 100; i++)
    /// {
    /// list.Add(InterpolateVertexParabola(a, b, c, -100, 100, 1d / i));
    /// }
    /// </code>
    /// </example>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) InterpolateStandardParabola<T>(T t, T a, T b, T c, T x1, T x2)
        where T : INumber<T>
    {
        // Scale the t index to the segment range.
        var x = x1 + ((x2 - x1) * t);
        return (x, Y: (a * (x * x)) + ((b * x) + c));
    }

    /// <summary>
    /// Interpolate a parabola from the general vertex form of the parabolic equation.
    /// </summary>
    /// <param name="t">The <paramref name="t" />ime index of the iteration.</param>
    /// <param name="a">The <paramref name="a" /> component of the parabola.</param>
    /// <param name="h">The horizontal component of the parabola vertex.</param>
    /// <param name="k">The vertical component of the parabola vertex.</param>
    /// <param name="x1">The <paramref name="x1" />imum x value to interpolate.</param>
    /// <param name="x2">The <paramref name="x2" />imum x value to interpolate.</param>
    /// <returns>
    /// Returns a <see cref="ValueTuple{T1, T2}" /> representing the interpolated point at the t index.
    /// </returns>
    /// <example>
    ///   <code>
    /// var a = 0.0125d;
    /// var h = 100d;
    /// var k = 100d;
    /// var min = -100d;
    /// var max = 100d;
    /// var list = new List&lt;(double X, double Y)&gt;();
    /// for (int i = 0; i &lt; 100; i++)
    /// {
    /// list.Add(InterpolateVertexParabola(a, h, k, -100, 100, 1d / i));
    /// }
    /// </code>
    /// </example>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) InterpolateVertexParabola<T>(T t, T a, T h, T k, T x1, T x2)
        where T : INumber<T>
    {
        // Scale the t index to the segment range.
        var x = x1 + ((x2 - x1) * t);
        return (x, Y: (a * (x - h) * (x - h)) + k);
    }

    /// <summary>
    /// Interpolates the parabola.
    /// </summary>
    /// <param name="t">The t.</param>
    /// <param name="x1">The x1.</param>
    /// <param name="y1">The y1.</param>
    /// <param name="x2">The x2.</param>
    /// <param name="y2">The y2.</param>
    /// <param name="k">The k.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) InterpolateParabola<T>(T t, T x1, T y1, T x2, T y2, T k)
        where T : IFloatingPoint<T>
    {
        var parabolicT = (t * T.Create(2)) - T.One;
        var (dX, dY) = (x2 - x1, y2 - y1);
        if (T.Abs(dX) < T.Epsilon && T.Abs(dY) < T.Epsilon)
        {
            // In place Vertical Throw.
            return (x1, y1 + k * ((-T.Create(4) * t * t) + (T.Create(4) * t)));
        }
        if (T.Abs(dX) < T.Epsilon)
        {
            // Vertical throw with different heights.
            return (x1, y1 + (t * dY) + (((-parabolicT * parabolicT) + T.One) * k));
        }
        else if (T.Abs(dY) < T.Epsilon && y1 == k)
        {
            // Horizontal slide.
            return (((T.One - t) * x1) + (t * x2), y1);
        }
        else if (T.Abs(dY) < T.Epsilon)
        {
            // Start and end are roughly level, pretend they are - simpler solution with fewer steps.
            return (x1 + (t * dX), y1 + (t * dY) + (((-parabolicT * parabolicT) + T.One) * k));
        }
        else
        {
            // Other parabola.
            return (T.NaN, T.NaN);
        }
    }
    #endregion
}
