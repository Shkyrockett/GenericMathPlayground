// <copyright file="ISize2.cs" company="Shkyrockett" >
//     Copyright © 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using GenericMathPlayground.Mathematics;
using System;

namespace GenericMathPlayground.Geometry;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public interface ISize2<T>
    : ISize<T>, IVector2<T>
    where T : INumber<T>
{
    /// <summary>
    /// 
    /// </summary>
    public T Width { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public T Height { get; set; }

    /// <summary>
    /// 
    /// </summary>
    T IVector2<T>.X { get { return Width; } set { Width = value; } }

    /// <summary>
    /// 
    /// </summary>
    T IVector2<T>.Y { get { return Height; } set { Height = value; } }
}
