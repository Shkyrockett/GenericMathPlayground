// <copyright file="Operations.Statistics.cs" company="Shkyrockett" >
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
    #region Summation
    /// <summary>
    /// Sums the.
    /// </summary>
    /// <param name="values">The values.</param>
    /// <returns>A TResult.</returns>
    /// <acknowledgment>
    /// https://devblogs.microsoft.com/dotnet/preview-features-in-net-6-generic-math/#generic-math
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult Sum<T, TResult>(Span<T> values)
        where T : INumber<T>
        where TResult : INumber<TResult>
    {
        var result = TResult.Zero;

        foreach (var value in values)
        {
            result += TResult.CreateChecked(value);
        }

        return result;
    }
    #endregion

    #region Averaging
    /// <summary>
    /// Averages the.
    /// </summary>
    /// <param name="values">The values.</param>
    /// <returns>A TResult.</returns>
    /// <acknowledgment>
    /// https://devblogs.microsoft.com/dotnet/preview-features-in-net-6-generic-math/#generic-math
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult Average<T, TResult>(Span<T> values)
        where T : INumber<T>
        where TResult : INumber<TResult>
    {
        var sum = Sum<T, TResult>(values);
        return TResult.CreateChecked(sum) / TResult.CreateChecked(values.Length);
    }
    #endregion

    #region Standard Deviation
    /// <summary>
    /// Standards the deviation.
    /// </summary>
    /// <param name="values">The values.</param>
    /// <returns>A TResult.</returns>
    /// <acknowledgment>
    /// https://devblogs.microsoft.com/dotnet/preview-features-in-net-6-generic-math/#generic-math
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult StandardDeviation<T, TResult>(Span<T> values)
        where T : INumber<T>
        where TResult : IFloatingPointIeee754<TResult>
    {
        var standardDeviation = TResult.Zero;

        if (!values.IsEmpty)
        {
            TResult average = Average<T, TResult>(values);
            TResult sum = Sum<TResult, TResult>(values.Select((value) =>
            {
                var deviation = TResult.CreateChecked(value) - average;
                return deviation * deviation;
            }));
            standardDeviation = TResult.Sqrt(sum / TResult.CreateChecked(values.Length - 1));
        }

        return standardDeviation;
    }
    #endregion
}
