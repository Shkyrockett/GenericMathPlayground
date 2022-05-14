// <copyright file="IVector4.cs" company="Shkyrockett" >
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
/// The vector4.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IVector4<T>
    : IVector3<T>
    where T : INumber<T>
{
    /// <summary>
    /// Gets or sets the w.
    /// </summary>
    public T W { get; set; }

    /// <summary>
    /// Deconstructs the.
    /// </summary>
    /// <param name="X">The x.</param>
    /// <param name="Y">The y.</param>
    /// <param name="Z">The z.</param>
    /// <param name="W">The w.</param>
    public void Deconstruct(out T X, out T Y, out T Z, out T W) => (X, Y, Z, W) = (this.X, this.Y, this.Z, this.W);
}
