// <copyright file="IBounds2.cs" company="Shkyrockett" >
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
/// The bounds2.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IBounds2<T>
    : IBounds<T>
    where T : INumber<T>
{
    /// <summary>
    /// Gets or sets the location.
    /// </summary>
    public new IPoint2<T> Location { get; set; }

    /// <summary>
    /// Gets or sets the size.
    /// </summary>
    public new ISize2<T> Size { get; set; }
}
