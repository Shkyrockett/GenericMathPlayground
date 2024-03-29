﻿// <copyright file="Operations.cs" company="Shkyrockett" >
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
/// The operations.
/// </summary>
public static partial class Operations
{
    #region Random
    /// <summary>
    /// Initialize random number generator with seed based on time.
    /// </summary>
    [ThreadStatic]
    public static readonly Random RandomNumberGenerator = new((int)DateTime.Now.Ticks & 0x0000FFFF);

    /// <summary>
    /// The random.
    /// </summary>
    /// <param name="lower">The Lower.</param>
    /// <param name="upper">The Upper.</param>
    /// <returns>The random number.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T Random<T>(this T lower, T upper) where T : INumber<T> => (T.CreateChecked(RandomNumberGenerator.Next()) * (upper - lower + T.One)) + lower;
    #endregion

    #region Rounding
    /// <summary>
    /// Rounds the specified number.
    /// </summary>
    /// <param name="number">The number.</param>
    /// <param name="accuracy">The accuracy.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult Round<T, TResult>(T number, int accuracy) where T : IFloatingPointIeee754<T> where TResult : INumber<TResult> => (accuracy < 15) ? TResult.CreateChecked(T.Round(number, accuracy)) : TResult.CreateChecked(number);
    #endregion

    #region Clamp
    /// <summary>
    /// Keep the value between the maximum and minimum.
    /// </summary>
    /// <param name="value">The value to clamp.</param>
    /// <param name="min">The lower limit the value should be above.</param>
    /// <param name="max">The upper limit the value should be under.</param>
    /// <returns>A value clamped between the maximum and minimum values.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T Clamp<T>(this T value, T min, T max) where T : INumber<T> => value > max ? max : value < min ? min : value;
    #endregion

    #region Wrapping
    /// <summary>
    /// The wrap.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="min">The min.</param>
    /// <param name="max">The max.</param>
    /// <returns>The <see cref="double"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T Wrap<T>(this T value, T min, T max) where T : INumber<T> => (value < min) ? max - ((min - value) % (max - min)) : min + ((value - min) % (max - min));
    #endregion Wrapping

    #region Type Conversions
    /// <summary>
    /// Tries the cast.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="result">The result.</param>
    /// <returns>A bool.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool TryCast<T, TResult>(this T value, out TResult result) where T : INumber<T> where TResult : INumber<TResult>
    {
        //return TResult.TryConvertFromChecked(value, out result);
        result = TResult.CreateChecked(value);
        return true;
    }

    /// <summary>
    /// Tries the cast or default.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A TResult? .</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult? TryCastOrDefault<T, TResult>(this T value) where T : INumber<T> where TResult : INumber<TResult> =>
        //return TResult.TryConvertFromChecked(value, out TResult? result) ? result : default;
        TResult.CreateChecked(value) ?? default;

    /// <summary>
    /// Casts the.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A TResult? .</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult? CastChecked<T, TResult>(this T value) where T : INumberBase<T> where TResult : INumberBase<TResult> => TResult.CreateChecked(value);

    /// <summary>
    /// Casts the saturating.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A TResult? .</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult? CastSaturating<T, TResult>(this T value) where T : INumber<T> where TResult : INumber<TResult> => TResult.CreateSaturating(value);

    /// <summary>
    /// Casts the truncating.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A TResult? .</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult? CastTruncating<T, TResult>(this T value) where T : INumber<T> where TResult : INumber<TResult> => TResult.CreateTruncating(value);
    #endregion
}
