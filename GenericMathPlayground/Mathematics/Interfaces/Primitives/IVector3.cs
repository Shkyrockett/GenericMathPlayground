// <copyright file="IVector3.cs" company="Shkyrockett" >
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
/// The vector3.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IVector3<T>
    : IVector2<T>
    where T : INumber<T>
{
    /// <summary>
    /// Gets or sets the z.
    /// </summary>
    public T Z { get; set; }

    /// <summary>
    /// Deconstructs the.
    /// </summary>
    /// <param name="X">The x.</param>
    /// <param name="Y">The y.</param>
    /// <param name="Z">The z.</param>
    public void Deconstruct(out T X, out T Y, out T Z) => (X, Y, Z) = (this.X, this.Y, this.Z);
}
