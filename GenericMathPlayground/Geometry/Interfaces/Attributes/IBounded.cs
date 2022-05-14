// <copyright file="IBounded.cs" company="Shkyrockett" >
//     Copyright © 2022 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using System.Numerics;

namespace GenericMathPlayground.Geometry;

/// <summary>
/// The bounded.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IBounded<T>
    where T : INumber<T>
{
    /// <summary>
    /// Gets the bounds.
    /// </summary>
    IBounds<T>? Bounds { get; }
}
