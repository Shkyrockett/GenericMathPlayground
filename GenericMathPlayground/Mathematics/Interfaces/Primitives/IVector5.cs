﻿// <copyright file="IVector5.cs" company="Shkyrockett" >
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
public interface IVector5<T>
    : IVector4<T>
    where T : INumber<T>
{
    /// <summary>
    /// 
    /// </summary>
    public T V { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="X"></param>
    /// <param name="Y"></param>
    /// <param name="Z"></param>
    /// <param name="W"></param>
    /// <param name="V"></param>
    public void Deconstruct(out T X, out T Y, out T Z, out T W, out T V) => (X, Y, Z, W, V) = (this.X, this.Y, this.Z, this.W, this.V);
}
