// <copyright file="Size2.cs" company="Shkyrockett" >
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
/// The size2.
/// </summary>
/// <typeparam name="T"></typeparam>
public class Size2<T>
    : IVector2<T>
    where T : INumber<T>
{
    #region Fields
    /// <summary>
    /// 
    /// </summary>
    private ValueSize2<T> value;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="Size2{T}"/> class.
    /// </summary>
    public Size2() => value = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="Size2{T}"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public Size2(ValueSize2<T> value) => this.value = value;

    /// <summary>
    /// Initializes a new instance of the <see cref="Size2{T}"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public Size2(IVector2<T> value) => this.value = new(value);

    /// <summary>
    /// Initializes a new instance of the <see cref="Size2{T}"/> class.
    /// </summary>
    /// <param name="tuple">The tuple.</param>
    public Size2((T Width, T Height) tuple) => value = new(tuple);

    /// <summary>
    /// Initializes a new instance of the <see cref="Size2{T}"/> class.
    /// </summary>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    public Size2(T width, T height) => value = new(width, height);
    #endregion

    #region Deconstructors
    /// <summary>
    /// Deconstructs the.
    /// </summary>
    /// <param name="Width">The width.</param>
    /// <param name="Height">The height.</param>
    public void Deconstruct(out T Width, out T Height) => (Width, Height) = value;
    #endregion

    #region Properties
    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    public ValueSize2<T> Value { get { return value; } set { this.value = value; } }

    /// <summary>
    /// Gets or sets the width.
    /// </summary>
    public T Width { get { return value.Width; } set { this.value.Width = value; } }

    /// <summary>
    /// Gets or sets the height.
    /// </summary>
    public T Height { get { return value.Height; } set { this.value.Height = value; } }

    /// <summary>
    /// Gets or sets the x.
    /// </summary>
    T IVector2<T>.X { get { return value.Width; } set { this.value.Width = value; } }

    /// <summary>
    /// Gets or sets the y.
    /// </summary>
    T IVector2<T>.Y { get { return value.Height; } set { this.value.Height = value; } }

    /// <summary>
    /// Gets or sets the items.
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public T[] Items { get { return new T[] { Width, Height }; } set { (Width, Height) = (value[0], value[1]); } }

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
    public static implicit operator ValueSize2<T>(Size2<T> value) => value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public static explicit operator Size2<T>(ValueSize2<T> value) => new(value);
    #endregion
}
