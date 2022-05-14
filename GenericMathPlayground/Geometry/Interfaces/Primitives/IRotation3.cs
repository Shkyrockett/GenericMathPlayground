// <copyright file="IRotation3.cs" company="Shkyrockett" >
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
/// The rotation3.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRotation3<T>
    : IRotation<T>
    where T : IFloatingPointIeee754<T>
{
    /// <summary>
    /// Gets or sets the yaw.
    /// </summary>
    public T Yaw { get; set; }

    /// <summary>
    /// Gets or sets the pitch.
    /// </summary>
    public T Pitch { get; set; }

    /// <summary>
    /// Gets or sets the roll.
    /// </summary>
    public T Roll { get; set; }
}
