// <copyright file="Factories.Matricies.cs" company="Shkyrockett" >
//     Copyright © 2020 - 2022 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using Microsoft.Toolkit.HighPerformance;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace GenericMathPlayground.Mathematics;

/// <summary>
/// The factories.
/// </summary>
public static partial class Factories
{
    #region Create a Matrix from a List of Row Vectors
    /// <summary>
    /// Matrices the from vector rows.
    /// </summary>
    /// <param name="vectors">The vectors.</param>
    /// <returns>An array of TS.</returns>
    public static T[,] MatrixFromVectorRows<T>(IVector<T>[] vectors)
        where T : INumber<T>
    {
        var columns = 0;
        var rows = vectors.Length;
        foreach (var vector in vectors)
        {
            columns = vector.Items.Length is int len ? len > columns ? len : columns : columns;
        }

        var matrix = new T[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                matrix[i, j] = vectors[i].Items[j] ?? T.Zero;
            }
        }

        return matrix;
    }

    /// <summary>
    /// Matrices the from vector rows.
    /// </summary>
    /// <param name="vectors">The vectors.</param>
    /// <returns>An array of TS.</returns>
    public static T[,] MatrixFromVectorRows<T>(Span<T[]> vectors)
        where T : INumber<T>
    {
        var columns = 0;
        var rows = vectors.Length;
        foreach (var vector in vectors)
        {
            columns = vector.Length is int len ? len > columns ? len : columns : columns;
        }

        var matrix = new T[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                matrix[i, j] = vectors[i][j] ?? T.Zero;
            }
        }

        return matrix;
    }
    #endregion

    #region Create a Matrix from a list of Vector Columns
    /// <summary>
    /// Matrices the from vector columns.
    /// </summary>
    /// <param name="vectors">The vectors.</param>
    /// <returns>An array of TS.</returns>
    public static T[,] MatrixFromVectorColumns<T>(IVector<T>[] vectors)
        where T : INumber<T>
    {
        var rows = 0;
        var columns = vectors.Length;
        foreach (var vector in vectors)
        {
            rows = vector.Items.Length is int len ? len > rows ? len : rows : rows;
        }

        var matrix = new T[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                matrix[i, j] = vectors[j].Items[i] ?? T.Zero;
            }
        }

        return matrix;
    }

    /// <summary>
    /// Matrices the from vector columns.
    /// </summary>
    /// <param name="vectors">The vectors.</param>
    /// <returns>An array of TS.</returns>
    public static T[,] MatrixFromVectorColumns<T>(Span<T[]> vectors)
        where T : INumber<T>
    {
        var rows = 0;
        var columns = vectors.Length;
        foreach (var vector in vectors)
        {
            rows = vector.Length is int len ? len > rows ? len : rows : rows;
        }

        var matrix = new T[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                matrix[i, j] = vectors[j][i] ?? T.Zero;
            }
        }

        return matrix;
    }
    #endregion

    #region List the Columns of a Matrix
    /// <summary>
    /// Matrices the columns.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <returns>An array of TS.</returns>
    public static T[][] MatrixColumns<T>(Span2D<T> matrix)
    {
        var rows = matrix.Height;

        var vectors = new T[rows][];

        for (int i = 0; i < rows; i++)
        {
            vectors[i] = matrix.GetColumn(i).ToArray();
        }

        return vectors;
    }

    /// <summary>
    /// Matrices the vector columns.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <returns>An array of ValueVector.</returns>
    public static ValueVector<T>[] MatrixVectorColumns<T>(Span2D<T> matrix)
        where T : INumber<T>
    {
        var rows = matrix.Height;

        var vectors = new ValueVector<T>[rows];

        for (int i = 0; i < rows; i++)
        {
            vectors[i] = new ValueVector<T>(matrix.GetColumn(i).ToArray());
        }

        return vectors;
    }
    #endregion

    #region List the Rows of a Matrix
    /// <summary>
    /// Matrices the rows.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <returns>An array of TS.</returns>
    public static T[][] MatrixRows<T>(Span2D<T> matrix)
    {
        var columns = matrix.Width;

        var vectors = new T[columns][];

        for (int i = 0; i < columns; i++)
        {
            vectors[i] = matrix.GetRow(i).ToArray();
        }

        return vectors;
    }

    /// <summary>
    /// Matrices the vector rows.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <returns>An array of ValueVector.</returns>
    public static ValueVector<T>[] MatrixVectorRows<T>(Span2D<T> matrix)
        where T : INumber<T>
    {
        var columns = matrix.Width;

        var vectors = new ValueVector<T>[columns];

        for (int i = 0; i < columns; i++)
        {
            vectors[i] = new ValueVector<T>(matrix.GetRow(i).ToArray());
        }

        return vectors;
    }
    #endregion

    #region Matrix Multiplicative Identity
    /// <summary>
    /// Creates the multiplicative identity matrix.
    /// </summary>
    /// <param name="rows">The rows.</param>
    /// <param name="columns">The columns.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] MultiplicativeIdentity<T>(int rows, int columns)
        where T : INumber<T>
    {
        var identity = new T[rows, columns];

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                identity[i, j] = i == j ? T.One : T.Zero;
            }
        }

        return identity;
    }
    #endregion

    #region Matrix Additive Identity
    /// <summary>
    /// Creates the additive identity matrix.
    /// </summary>
    /// <param name="rows">The rows.</param>
    /// <param name="columns">The columns.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] AdditiveIdentity<T>(int rows, int columns)
        where T : INumber<T>
    {
        var identity = new T[rows, columns];

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                identity[i, j] = T.Zero;
            }
        }

        return identity;
    }
    #endregion

    #region Matrix Randomization
    /// <summary>
    /// Random matrix generator.
    /// </summary>
    /// <param name="rows">The rows.</param>
    /// <param name="columns">The columns.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] RandomNonZeroMatrix<T>(int rows, int columns) where T : INumber<T> => RandomNonZeroMatrix(rows, columns, T.Zero, T.One / T.CreateChecked(1000));

    /// <summary>
    /// Random matrix generator.
    /// </summary>
    /// <param name="rows">The rows.</param>
    /// <param name="columns">The columns.</param>
    /// <param name="lower"></param>
    /// <param name="upper"></param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] RandomNonZeroMatrix<T>(int rows, int columns, T lower, T upper)
        where T : INumber<T>
    {
        var nonZero = false;

        var matrix = new T[rows, columns];

        while (!nonZero)
        {
            for (var i = 0; i < rows; i++)
            {
                nonZero = false;

                for (var j = 0; j < columns; j++)
                {
                    matrix[i, j] = Operations.Random(lower, upper);

                    if (matrix[i, j] != T.Zero)
                    {
                        nonZero = true;
                    }
                }
            }
        }

        return matrix;
    }
    #endregion
}
