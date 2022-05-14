// <copyright file="IRotation2.cs" company="Shkyrockett" >
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
/// The rotation2.
/// </summary>
public interface IRotation2<T>
    : IRotation<T>
    where T : IFloatingPointIeee754<T>
{
    /// <summary>
    /// Gets or sets the angle.
    /// </summary>
    public T Angle { get; set; }

    /// <summary>
    /// Gets or sets the sin.
    /// </summary>
    public T Sin { get; set; }

    /// <summary>
    /// Gets or sets the cos.
    /// </summary>
    public T Cos { get; set; }
}
