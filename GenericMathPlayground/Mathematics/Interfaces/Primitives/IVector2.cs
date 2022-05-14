// <copyright file="IVector2.cs" company="Shkyrockett" >
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
/// The vector2.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IVector2<T>
    : IVector<T>
    where T : INumber<T>
{
    /// <summary>
    /// Gets or sets the x.
    /// </summary>
    public T X { get; set; }

    /// <summary>
    /// Gets or sets the y.
    /// </summary>
    public T Y { get; set; }

    /// <summary>
    /// Deconstructs the.
    /// </summary>
    /// <param name="X">The x.</param>
    /// <param name="Y">The y.</param>
    public void Deconstruct(out T X, out T Y) => (X, Y) = (this.X, this.Y);
}
