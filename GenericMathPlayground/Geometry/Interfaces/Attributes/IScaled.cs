// <copyright file="IScaled.cs" company="Shkyrockett" >
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
/// The scaled.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IScaled<T>
    where T : INumber<T>
{
    /// <summary>
    /// Gets or sets the size.
    /// </summary>
    public ISize<T> Size { get; set; }
}
