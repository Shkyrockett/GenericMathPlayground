// <copyright file="Size3.cs" company="Shkyrockett" >
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
/// The size3.
/// </summary>
/// <typeparam name="T"></typeparam>
public class Size3<T>
    : ISize3<T>
    where T : INumber<T>
{
    #region Fields
    /// <summary>
    /// 
    /// </summary>
    private ValueSize3<T> value;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="Size3{T}"/> class.
    /// </summary>
    public Size3() => value = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="Size3{T}"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public Size3(ValueSize3<T> value) => this.value = value;

    /// <summary>
    /// Initializes a new instance of the <see cref="Size3{T}"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public Size3(IVector3<T> value) => this.value = new(value);

    /// <summary>
    /// Initializes a new instance of the <see cref="Size3{T}"/> class.
    /// </summary>
    /// <param name="tuple">The tuple.</param>
    public Size3((T Width, T Height, T Depth) tuple) => value = new(tuple);

    /// <summary>
    /// Initializes a new instance of the <see cref="Size3{T}"/> class.
    /// </summary>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    /// <param name="depth">The depth.</param>
    public Size3(T width, T height, T depth) => value = new(width, height, depth);
    #endregion

    #region Deconstructors
    /// <summary>
    /// Deconstructs the.
    /// </summary>
    /// <param name="Width">The width.</param>
    /// <param name="Height">The height.</param>
    /// <param name="Depth">The depth.</param>
    public void Deconstruct(out T Width, out T Height, out T Depth) => (Width, Height, Depth) = value;
    #endregion

    #region Properties
    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    public ValueSize3<T> Value { get { return value; } set { this.value = value; } }

    /// <summary>
    /// Gets or sets the width.
    /// </summary>
    public T Width { get { return value.Width; } set { this.value.Width = value; } }

    /// <summary>
    /// Gets or sets the height.
    /// </summary>
    public T Height { get { return value.Height; } set { this.value.Height = value; } }

    /// <summary>
    /// Gets or sets the depth.
    /// </summary>
    public T Depth { get { return value.Depth; } set { this.value.Depth = value; } }

    /// <summary>
    /// Gets or sets the items.
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public T[] Items { get { return new T[] { Width, Height, Depth }; } set { (Width, Height, Depth) = (value[0], value[1], value[2]); } }

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
    public static implicit operator ValueSize3<T>(Size3<T> value) => value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public static explicit operator Size3<T>(ValueSize3<T> value) => new(value);
    #endregion
}
