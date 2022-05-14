// <copyright file="Factories.Vectors.cs" company="Shkyrockett" >
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
/// The factories.
/// </summary>
public static partial class Factories
{
    #region Vector Multiplicative Identity
    /// <summary>
    /// Creates the multiplicative identity vector.
    /// </summary>
    /// <param name="length">The length.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] MultiplicativeIdentity<T>(int length)
        where T : INumber<T>
    {
        var identity = new T[length];

        for (var i = 0; i < length; i++)
        {
            identity[i] = T.One;
        }

        return identity;
    }
    #endregion

    #region Vector Additive Identity
    /// <summary>
    /// Creates the additive identity matrix.
    /// </summary>
    /// <param name="length">The length.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] AdditiveIdentity<T>(int length)
        where T : INumber<T>
    {
        var identity = new T[length];

        for (var i = 0; i < length; i++)
        {
            identity[i] = T.Zero;
        }

        return identity;
    }
    #endregion

    #region Vector Randomization
    /// <summary>
    /// Random vector generator.
    /// </summary>
    /// <param name="length">The length.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] RandomNonZeroVector<T>(int length) where T : INumber<T> => RandomNonZeroVector(length, T.Zero, T.One / T.CreateChecked(1000));

    /// <summary>
    /// Random vector generator.
    /// </summary>
    /// <param name="length">The length.</param>
    /// <param name="lower"></param>
    /// <param name="upper"></param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] RandomNonZeroVector<T>(int length, T lower, T upper)
        where T : INumber<T>
    {
        var nonZero = false;

        var vector = new T[length];

        while (!nonZero)
        {
            for (var i = 0; i < length; i++)
            {
                vector[i] = Operations.Random(lower, upper);

                if (vector[i] != T.Zero)
                {
                    nonZero = true;
                }
            }
        }

        return vector;
    }
    #endregion
}
