// <copyright file="Point5.cs" company="Shkyrockett" >
//     Copyright © 2021 - 2022 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using GenericMathPlayground.Mathematics;
using System.Numerics;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace GenericMathPlayground.Geometry;

/// <summary>
/// The point5.
/// </summary>
/// <typeparam name="T"></typeparam>
public class Point5<T>
    : IPoint5<T>
    where T : INumber<T>
{
    #region Fields
    /// <summary>
    /// 
    /// </summary>
    private ValuePoint5<T> value;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="Point5{T}"/> class.
    /// </summary>
    public Point5() => value = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="Point5{T}"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public Point5(ValuePoint5<T> value) => this.value = value;

    /// <summary>
    /// Initializes a new instance of the <see cref="Point5{T}"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public Point5(IVector5<T> value) => this.value = new(value);

    /// <summary>
    /// Initializes a new instance of the <see cref="Point5{T}"/> class.
    /// </summary>
    /// <param name="tuple">The tuple.</param>
    public Point5((T X, T Y, T Z, T W, T V) tuple) => value = new(tuple);

    /// <summary>
    /// Initializes a new instance of the <see cref="Point5{T}"/> class.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <param name="z">The z.</param>
    /// <param name="w">The w.</param>
    /// <param name="v">The v.</param>
    public Point5(T x, T y, T z, T w, T v) => value = new(x, y, z, w, v);
    #endregion

    #region Deconstructors
    /// <summary>
    /// Deconstructs the.
    /// </summary>
    /// <param name="X">The x.</param>
    /// <param name="Y">The y.</param>
    /// <param name="Z">The z.</param>
    /// <param name="W">The w.</param>
    /// <param name="V">The v.</param>
    public void Deconstruct(out T X, out T Y, out T Z, out T W, out T V) => (X, Y, Z, W, V) = value;
    #endregion

    #region Properties
    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    public ValuePoint5<T> Value { get { return value; } set { this.value = value; } }

    /// <summary>
    /// Gets or sets the x.
    /// </summary>
    public T X { get { return value.X; } set { this.value.X = value; } }

    /// <summary>
    /// Gets or sets the y.
    /// </summary>
    public T Y { get { return value.Y; } set { this.value.Y = value; } }

    /// <summary>
    /// Gets or sets the z.
    /// </summary>
    public T Z { get { return value.Z; } set { this.value.Z = value; } }

    /// <summary>
    /// Gets or sets the w.
    /// </summary>
    public T W { get { return value.W; } set { this.value.W = value; } }

    /// <summary>
    /// Gets or sets the v.
    /// </summary>
    public T V { get { return value.V; } set { this.value.V = value; } }

    /// <summary>
    /// Gets or sets the items.
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public T[] Items { get { return new T[] { X, Y, Z, W, V }; } set { (X, Y, Z, W, V) = (value[0], value[1], value[2], value[3], value[4]); } }

    /// <summary>
    /// Gets the count.
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public int Count => value.Count;
    #endregion

    #region Operators
    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public static implicit operator ValuePoint5<T>(Point5<T> value) => value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public static explicit operator Point5<T>(ValuePoint5<T> value) => new(value);
    #endregion
}
