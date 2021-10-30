// <copyright file="IVector2.cs" company="Shkyrockett" >
//     Copyright © 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using System;

namespace GenericMathPlayground.Mathematics;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IVector2<T>
    : IVector<T>
    where T : INumber<T>
{
    /// <summary>
    /// 
    /// </summary>
    public T X { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public T Y { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="X"></param>
    /// <param name="Y"></param>
    public void Deconstruct(out T X, out T Y) => (X, Y) = (this.X, this.Y);
}
