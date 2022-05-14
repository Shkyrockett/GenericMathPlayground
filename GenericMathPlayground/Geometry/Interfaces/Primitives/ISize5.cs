// <copyright file="ISize5.cs" company="Shkyrockett" >
//     Copyright © 2021 - 2022 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using GenericMathPlayground.Mathematics;
using System.Numerics;

namespace GenericMathPlayground.Geometry;

/// <summary>
/// The size5.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface ISize5<T>
    : ISize4<T>, IVector5<T>
    where T : INumber<T>
{
    /// <summary>
    /// Gets or sets the length.
    /// </summary>
    public T Girth { get; set; }

    /// <summary>
    /// Gets or sets the v.
    /// </summary>
    T IVector5<T>.V { get { return Girth; } set { Girth = value; } }
}
