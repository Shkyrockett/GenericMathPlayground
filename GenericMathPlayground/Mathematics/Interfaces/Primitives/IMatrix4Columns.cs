// <copyright file="IMatrix4Columns.cs" company="Shkyrockett" >
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
    /// The matrix4 columns.
    /// </summary>
    public interface IMatrix4Columns<T, TVector>
        : IMatrix3Columns<T, TVector>
        where T : INumber<T>
        where TVector : IVector<T>
    {
        /// <summary>
        /// Gets or sets the column w.
        /// </summary>
        TVector ColumnW { get; set; }
    }
}
