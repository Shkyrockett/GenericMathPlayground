// <copyright file="IPolynomial.cs" company="Shkyrockett" >
//     Copyright © 2022 Shkyrockett. All rights reserved.
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
    /// The polynomial.
    /// </summary>
    public interface IPolynomial<T>
        where T : INumber<T>
    {
        /// <summary>
        /// Gets or sets the coefficients.
        /// </summary>
        internal T[] Coefficients { get; set; }
    }
}
