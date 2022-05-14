// <copyright file="IToString.cs" company="Shkyrockett" >
//     Copyright © 2021 - 2022 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace GenericMathPlayground;

/// <summary>
/// 
/// </summary>
public interface IToString
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public virtual string? ToString() => ToString(CultureInfo.InvariantCulture);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="format"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public virtual string? ToString(string? format) => ToString(format, CultureInfo.InvariantCulture);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="formatProvider"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public virtual string? ToString(IFormatProvider? formatProvider) => ToString("", formatProvider);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="format"></param>
    /// <param name="formatProvider"></param>
    /// <returns></returns>
    public abstract string? ToString(string? format, IFormatProvider? formatProvider);
}

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IToString<T>
    : IToString
    where T : INumber<T>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="formatProvider"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public virtual new string? ToString(IFormatProvider? formatProvider) => ToString("R", formatProvider);
}

/// <summary>
/// 
/// </summary>
public static class ToStringExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static string? ToString(this IToString obj) => obj?.ToString();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static string? ToString<T>(this IToString<T> obj) where T : INumber<T> => obj?.ToString();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="format"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static string? ToString(this IToString obj, string? format) => obj?.ToString(format, CultureInfo.InvariantCulture);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <param name="format"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static string? ToString<T>(this IToString<T> obj, string? format) where T : INumber<T> => obj?.ToString(format, CultureInfo.InvariantCulture);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="formatProvider"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static string? ToString(this IToString obj, IFormatProvider? formatProvider) => obj?.ToString(formatProvider);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <param name="formatProvider"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static string? ToString<T>(this IToString obj, IFormatProvider? formatProvider) where T : INumber<T> => obj?.ToString(formatProvider);
}