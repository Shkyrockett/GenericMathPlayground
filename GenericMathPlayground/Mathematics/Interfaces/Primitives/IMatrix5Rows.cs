// <copyright file="IMatrix5Rows.cs" company="Shkyrockett" >
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
    /// The matrix5 rows.
    /// </summary>
    public interface IMatrix5Rows<T, TVector>
        : IMatrix4Rows<T, TVector>
        where T : INumber<T>
        where TVector : IVector<T>
    {
        /// <summary>
        /// Gets or sets the row v.
        /// </summary>
        TVector RowV { get; set; }
    }
}
