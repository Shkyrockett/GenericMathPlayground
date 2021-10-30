// <copyright file="ISize5.cs" company="Shkyrockett" >
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
public interface ISize5<T>
    : ISize4<T>, IVector5<T>
    where T : INumber<T>
{
    /// <summary>
    /// 
    /// </summary>
    public T Length { get; set; }

    /// <summary>
    /// 
    /// </summary>
    T IVector5<T>.V { get { return Length; } set { Length = value; } }
}
