// <copyright file="Point3.cs" company="Shkyrockett" >
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
/// The point3.
/// </summary>
/// <typeparam name="T"></typeparam>
public class Point3<T>
    : IPoint3<T>
    where T : INumber<T>
{
    #region Fields
    /// <summary>
    /// 
    /// </summary>
    private ValuePoint3<T> value;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="Point3{T}"/> class.
    /// </summary>
    public Point3() => value = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="Point3{T}"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public Point3(ValuePoint3<T> value) => this.value = value;

    /// <summary>
    /// Initializes a new instance of the <see cref="Point3{T}"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public Point3(IVector3<T> value) => this.value = new(value);

    /// <summary>
    /// Initializes a new instance of the <see cref="Point3{T}"/> class.
    /// </summary>
    /// <param name="tuple">The tuple.</param>
    public Point3((T X, T Y, T Z) tuple) => value = new(tuple);

    /// <summary>
    /// Initializes a new instance of the <see cref="Point3{T}"/> class.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <param name="z">The z.</param>
    public Point3(T x, T y, T z) => value = new(x, y, z);
    #endregion

    #region Deconstructors
    /// <summary>
    /// Deconstructs the.
    /// </summary>
    /// <param name="X">The x.</param>
    /// <param name="Y">The y.</param>
    /// <param name="Z">The z.</param>
    public void Deconstruct(out T X, out T Y, out T Z) => (X, Y, Z) = value;
    #endregion

    #region Properties
    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    public ValuePoint3<T> Value { get { return value; } set { this.value = value; } }

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
    /// Gets or sets the items.
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public T[] Items { get { return new T[] { X, Y, Z }; } set { (X, Y, Z) = (value[0], value[1], value[2]); } }

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
    public static implicit operator ValuePoint3<T>(Point3<T> value) => value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public static explicit operator Point3<T>(ValuePoint3<T> value) => new(value);
    #endregion
}
