// <copyright file="ISize3.cs" company="Shkyrockett" >
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
/// The size3.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface ISize3<T>
    : ISize2<T>, IVector3<T>
    where T : INumber<T>
{
    /// <summary>
    /// Gets or sets the depth.
    /// </summary>
    public T Depth { get; set; }

    /// <summary>
    /// Gets or sets the z.
    /// </summary>
    T IVector3<T>.Z { get { return Depth; } set { Depth = value; } }
}
