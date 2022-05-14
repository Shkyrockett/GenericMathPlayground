// <copyright file="Size5.cs" company="Shkyrockett" >
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
/// The size5.
/// </summary>
/// <typeparam name="T"></typeparam>
public class Size5<T>
    : ISize5<T>
    where T : INumber<T>
{
    #region Fields
    /// <summary>
    /// 
    /// </summary>
    private ValueSize5<T> value;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="Size5{T}"/> class.
    /// </summary>
    public Size5() => value = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="Size5{T}"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public Size5(ValueSize5<T> value) => this.value = value;

    /// <summary>
    /// Initializes a new instance of the <see cref="Size5{T}"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public Size5(IVector5<T> value) => this.value = new(value);

    /// <summary>
    /// Initializes a new instance of the <see cref="Size5{T}"/> class.
    /// </summary>
    /// <param name="tuple">The tuple.</param>
    public Size5((T Width, T Height, T Depth, T Breadth, T Length) tuple) => value = new(tuple);

    /// <summary>
    /// Initializes a new instance of the <see cref="Size5{T}"/> class.
    /// </summary>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    /// <param name="depth">The depth.</param>
    /// <param name="breadth">The breadth.</param>
    /// <param name="length">The length.</param>
    public Size5(T width, T height, T depth, T breadth, T length) => value = new(width, height, depth, breadth, length);
    #endregion

    #region Deconstructors
    /// <summary>
    /// Deconstructs the.
    /// </summary>
    /// <param name="Width">The width.</param>
    /// <param name="Height">The height.</param>
    /// <param name="Depth">The depth.</param>
    /// <param name="Breadth">The breadth.</param>
    /// <param name="Length">The length.</param>
    public void Deconstruct(out T Width, out T Height, out T Depth, out T Breadth, out T Length) => (Width, Height, Depth, Breadth, Length) = value;
    #endregion

    #region Properties
    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    public ValueSize5<T> Value { get { return value; } set { this.value = value; } }

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
    /// Gets or sets the breadth.
    /// </summary>
    public T Breadth { get { return value.Breadth; } set { this.value.Breadth = value; } }

    /// <summary>
    /// Gets or sets the length.
    /// </summary>
    public T Girth { get { return value.Girth; } set { this.value.Girth = value; } }

    /// <summary>
    /// Gets or sets the items.
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public T[] Items { get { return new T[] { Width, Height, Depth, Breadth, Girth }; } set { (Width, Height, Depth, Breadth, Girth) = (value[0], value[1], value[2], value[3], value[4]); } }

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
    public static implicit operator ValueSize5<T>(Size5<T> value) => value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public static explicit operator Size5<T>(ValueSize5<T> value) => new(value);
    #endregion
}
