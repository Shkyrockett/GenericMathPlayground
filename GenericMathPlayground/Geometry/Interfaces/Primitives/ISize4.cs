// <copyright file="ISize4.cs" company="Shkyrockett" >
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
/// The size4.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface ISize4<T>
    : ISize3<T>, IVector4<T>
    where T : INumber<T>
{
    /// <summary>
    /// Gets or sets the breadth.
    /// </summary>
    public T Breadth { get; set; }

    /// <summary>
    /// Gets or sets the w.
    /// </summary>
    T IVector4<T>.W { get { return Breadth; } set { Breadth = value; } }
}
