// <copyright file="Vector2.cs" company="Shkyrockett" >
//     Copyright © 2021 - 2022 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using System.Numerics;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace GenericMathPlayground.Mathematics;

/// <summary>
/// The vector2.
/// </summary>
/// <typeparam name="T"></typeparam>
public class Vector2<T>
    : IVector2<T>
    where T : INumber<T>
{
    #region Fields
    private ValueVector2<T> value;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="Vector2{T}"/> class.
    /// </summary>
    public Vector2() => value = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="Vector2{T}"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public Vector2(ValueVector2<T> value) => this.value = value;

    /// <summary>
    /// Initializes a new instance of the <see cref="Vector2{T}"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public Vector2(IVector2<T> value) => this.value = new(value);

    /// <summary>
    /// Initializes a new instance of the <see cref="Vector2{T}"/> class.
    /// </summary>
    /// <param name="tuple">The tuple.</param>
    public Vector2((T I, T J) tuple) => value = new(tuple);

    /// <summary>
    /// Initializes a new instance of the <see cref="Vector2{T}"/> class.
    /// </summary>
    /// <param name="i">The i.</param>
    /// <param name="j">The j.</param>
    public Vector2(T i, T j) => value = new(i, j);
    #endregion

    #region Deconstructors
    /// <summary>
    /// Deconstructs the.
    /// </summary>
    /// <param name="I">The i.</param>
    /// <param name="J">The j.</param>
    public void Deconstruct(out T I, out T J) => (I, J) = value;
    #endregion

    #region Properties
    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    public ValueVector2<T> Value { get { return value; } set { this.value = value; } }

    /// <summary>
    /// Gets or sets the i.
    /// </summary>
    public T I { get { return value.I; } set { this.value.I = value; } }

    /// <summary>
    /// Gets or sets the j.
    /// </summary>
    public T J { get { return value.J; } set { this.value.J = value; } }

    /// <summary>
    /// Gets or sets the x.
    /// </summary>
    T IVector2<T>.X { get { return I; } set { I = value; } }

    /// <summary>
    /// Gets or sets the y.
    /// </summary>
    T IVector2<T>.Y { get { return J; } set { J = value; } }

    /// <summary>
    /// Gets or sets the items.
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public T[] Items { get { return new T[] { I, J }; } set { (I, J) = (value[0], value[1]); } }

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
    public static implicit operator ValueVector2<T>(Vector2<T> value) => value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public static explicit operator Vector2<T>(ValueVector2<T> value) => new(value);
    #endregion
}
