// <copyright file="IMatrix2Columns.cs" company="Shkyrockett" >
//     Copyright © 2021 - 2022 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using System.Numerics;

namespace GenericMathPlayground.Mathematics
{
    /// <summary>
    /// The matrix2 columns.
    /// </summary>
    public interface IMatrix2Columns<T, TVector>
        : IMatrix<T>
        where T : INumber<T>
        where TVector : IVector<T>
    {
        /// <summary>
        /// Gets or sets the column x.
        /// </summary>
        TVector ColumnX { get; set; }

        /// <summary>
        /// Gets or sets the column y.
        /// </summary>
        TVector ColumnY { get; set; }
    }
}
