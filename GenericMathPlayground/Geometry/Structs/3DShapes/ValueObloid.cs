// <copyright file="ValueObloid.cs" company="Shkyrockett" >
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
/// The Obloid. 
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="R"></typeparam>
public class ValueObloid<T, R>
    : IBounded<R>
    where T : INumber<T>
    where R : IFloatingPointIeee754<R>
{
    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="ValueObloid{T, R}"/> class.
    /// </summary>
    /// <param name="center">The center.</param>
    /// <param name="radii">The radii.</param>
    /// <param name="rotation">The rotation.</param>
    public ValueObloid(IPoint<T> center!!, ISize<T> radii!!, IRotation<R> rotation!!)
    {
        Center = center;
        Radii = radii;
        Rotation = rotation;
        Bounds = default;
    }
    #endregion

    #region Properties
    /// <summary>
    /// The location or translation of the center of the obloid.
    /// </summary>
    public IPoint<T> Center { get; set; }

    /// <summary>
    /// The radii or scales of the dimensions of the obloid.
    /// </summary>
    public ISize<T> Radii { get; set; }

    /// <summary>
    /// The rotation of the obloid.
    /// </summary>
    public IRotation<R> Rotation { get; set; }

    /// <summary>
    /// Gets the bounds.
    /// </summary>
    public IBounds<R>? Bounds { get; }
    #endregion
}
