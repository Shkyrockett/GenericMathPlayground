// <copyright file="IVector5.cs" company="Shkyrockett" >
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

namespace GenericMathPlayground.Mathematics;

/// <summary>
/// The vector5.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IVector5<T>
    : IVector4<T>
    where T : INumber<T>
{
    /// <summary>
    /// Gets or sets the v.
    /// </summary>
    public T V { get; set; }

    /// <summary>
    /// Deconstructs the.
    /// </summary>
    /// <param name="X">The x.</param>
    /// <param name="Y">The y.</param>
    /// <param name="Z">The z.</param>
    /// <param name="W">The w.</param>
    /// <param name="V">The v.</param>
    public void Deconstruct(out T X, out T Y, out T Z, out T W, out T V) => (X, Y, Z, W, V) = (this.X, this.Y, this.Z, this.W, this.V);
}
