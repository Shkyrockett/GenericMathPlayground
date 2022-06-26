// <copyright file="ValueEllipse.cs" company="Shkyrockett" >
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
/// The value ellipse.
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="R"></typeparam>
public class ValueEllipse<T, R>
    : IBounded<R>, IEquatable<ValueEllipse<T, R>?> where T : INumber<T>
    where R : IFloatingPointIeee754<R>
{
    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="ValueEllipse{T, R}"/> class.
    /// </summary>
    /// <param name="center">The center.</param>
    /// <param name="radii">The radii.</param>
    /// <param name="rotation">The rotation.</param>
    public ValueEllipse(IPoint2<T> center, ISize2<T> radii, IRotation2<R> rotation)
    {
        Center = center ?? throw new ArgumentNullException(nameof(center));
        Radii = radii ?? throw new ArgumentNullException(nameof(radii));
        Rotation = rotation ?? throw new ArgumentNullException(nameof(rotation));
        Bounds = default;
    }
    #endregion

    #region Properties
    /// <summary>
    /// Gets or sets the center.
    /// </summary>
    public IPoint2<T> Center { get; set; }

    /// <summary>
    /// Gets or sets the radii.
    /// </summary>
    public ISize2<T> Radii { get; set; }

    /// <summary>
    /// Gets or sets the rotation.
    /// </summary>
    public IRotation2<R> Rotation { get; set; }

    /// <summary>
    /// Gets the bounds.
    /// </summary>
    public IBounds<R>? Bounds { get; }
    #endregion

    #region Operators
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(ValueEllipse<T, R>? left, ValueEllipse<T, R>? right) => EqualityComparer<ValueEllipse<T, R>>.Default.Equals(left, right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(ValueEllipse<T, R>? left, ValueEllipse<T, R>? right) => !(left == right);
    #endregion

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="obj">The obj.</param>
    /// <returns>A bool.</returns>
    public override bool Equals(object? obj) => Equals(obj as ValueEllipse<T, R>);

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>A bool.</returns>
    public bool Equals(ValueEllipse<T, R>? other) => other != null &&
               EqualityComparer<IPoint2<T>>.Default.Equals(Center, other.Center) &&
               EqualityComparer<ISize2<T>>.Default.Equals(Radii, other.Radii) &&
               EqualityComparer<IRotation2<R>>.Default.Equals(Rotation, other.Rotation);

    /// <summary>
    /// Gets the hash code.
    /// </summary>
    /// <returns>An int.</returns>
    public override int GetHashCode() => HashCode.Combine(Center, Radii, Rotation);
}

// Possible enhancement: Override operators for translations, scaling and transforms.
// Ellipse * size = bigger ellipse.
// Ellipse / size = smaller ellipse.
// Ellipse + size = slightly bigger ellipse.
// Ellipse - size = slightly smaller ellipse.
// Ellipse + Vector = vector in new location.
// Ellipse operator matrix = ellipse in new translation/scale/transform.

// Vector = movement
// Size = scale
// Point = ??

// How would skew and rotation come about?
