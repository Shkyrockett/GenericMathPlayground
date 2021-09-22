// <copyright file="Operations.Matrix.Arithmatic.cs" company="Shkyrockett" >
//     Copyright © 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using Microsoft.Toolkit.HighPerformance;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace GenericMathPlayground.Mathematics;

public static partial class Operations
{
    /// <summary>
    /// Used to add two matrices together.
    /// </summary>
    /// <param name="augendM1x1">The augend M1X1.</param>
    /// <param name="augendM1x2">The augend M1X2.</param>
    /// <param name="augendM2x1">The augend M2X1.</param>
    /// <param name="augendM2x2">The augend M2X2.</param>
    /// <param name="addendM1x1">The addend M1X1.</param>
    /// <param name="addendM1x2">The addend M1X2.</param>
    /// <param name="addendM2x1">The addend M2X1.</param>
    /// <param name="addendM2x2">The addend M2X2.</param>
    /// <returns></returns>
    [DebuggerStepThrough]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (
        T m1x1, T m1x2,
        T m2x1, T m2x2
        ) AddMatrix<T>(
        T augendM1x1, T augendM1x2,
        T augendM2x1, T augendM2x2,
        T addendM1x1, T addendM1x2,
        T addendM2x1, T addendM2x2)
        where T : INumber<T>
        => (augendM1x1 + addendM1x1, augendM1x2 + addendM1x2,
            augendM2x1 + addendM2x1, augendM2x2 + addendM2x2);

    /// <summary>
    /// Adds the specified augend.
    /// </summary>
    /// <param name="augend">The augend.</param>
    /// <param name="addend">The addend.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://www.geeksforgeeks.org/different-operation-matrices/
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TResult[,] Add<T, TResult>(Span2D<T> augend, Span2D<T> addend)
        where T : INumber<T>
        where TResult : INumber<TResult>
    {
        // Commented out because of lack of convertibility...
        //if (augend == null) return addend.ToArray();
        //if (addend == null) return augend.ToArray();
        var m = augend.Height;
        var n = augend.Width;
        var result = new TResult[m, n];
        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                result[i, j] = TResult.Create(augend[i, j] + addend[i, j]);
            }
        }

        return result;
    }

    /// <summary>
    /// Used to subtract two matrices.
    /// </summary>
    /// <param name="minuendM1x1">The minuend M1X1.</param>
    /// <param name="minuendM1x2">The minuend M1X2.</param>
    /// <param name="minuendM2x1">The minuend M2X1.</param>
    /// <param name="minuendM2x2">The minuend M2X2.</param>
    /// <param name="subtrahendM1x1">The subtrahend M1X1.</param>
    /// <param name="subtrahendM1x2">The subtrahend M1X2.</param>
    /// <param name="subtrahendM2x1">The subtrahend M2X1.</param>
    /// <param name="subtrahendM2x2">The subtrahend M2X2.</param>
    /// <returns></returns>
    [DebuggerStepThrough]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (
        T m1x1, T m1x2,
        T m2x1, T m2x2)
        Subtract2x2x2x2<T>(
        T minuendM1x1, T minuendM1x2,
        T minuendM2x1, T minuendM2x2,
        T subtrahendM1x1, T subtrahendM1x2,
        T subtrahendM2x1, T subtrahendM2x2)
        where T : INumber<T>
        => (minuendM1x1 - subtrahendM1x1, minuendM1x2 - subtrahendM1x2,
            minuendM2x1 - subtrahendM2x1, minuendM2x2 - subtrahendM2x2);

    /// <summary>
    /// Subtracts the specified minuend.
    /// </summary>
    /// <param name="minuend">The minuend.</param>
    /// <param name="subtrahend">The subtrahend.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://www.geeksforgeeks.org/different-operation-matrices/
    /// </acknowledgment>
    [DebuggerStepThrough]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TResult[,] Subtract<T, TResult>(T[,] minuend, T[,] subtrahend)
        where T : INumber<T>
        where TResult : INumber<TResult>
    {
        var rows = minuend.GetLength(0);
        var cols = minuend.GetLength(1);

        var result = new TResult[rows, cols];
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                result[i, j] = TResult.Create(minuend[i, j] - subtrahend[i, j]);
            }
        }

        return result;
    }
}
