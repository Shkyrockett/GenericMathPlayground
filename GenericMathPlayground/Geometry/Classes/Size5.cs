// <copyright file="Size5.cs" company="Shkyrockett" >
//     Copyright © 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using GenericMathPlayground.Mathematics;
using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace GenericMathPlayground.Geometry;

/// <summary>
/// 
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
    /// 
    /// </summary>
    public Size5() => value = new();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public Size5(ValueSize5<T> value) => this.value = value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public Size5(IVector5<T> value) => this.value = new(value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tuple"></param>
    public Size5((T Width, T Height, T Depth, T Breadth, T Length) tuple) => value = new(tuple);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="depth"></param>
    /// <param name="breadth"></param>
    /// <param name="length"></param>
    public Size5(T width, T height, T depth, T breadth, T length) => value = new(width, height, depth, breadth, length);
    #endregion

    #region Deconstructors
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Width"></param>
    /// <param name="Height"></param>
    /// <param name="Depth"></param>
    /// <param name="Breadth"></param>
    /// <param name="Length"></param>
    public void Deconstruct(out T Width, out T Height, out T Depth, out T Breadth, out T Length) => (Width, Height, Depth, Breadth, Length) = value;
    #endregion

    #region Properties
    /// <summary>
    /// 
    /// </summary>
    public ValueSize5<T> Value { get { return value; } set { this.value = value; } }

    /// <summary>
    /// 
    /// </summary>
    public T Width { get { return value.Width; } set { this.value.Width = value; } }

    /// <summary>
    /// 
    /// </summary>
    public T Height { get { return value.Height; } set { this.value.Height = value; } }

    /// <summary>
    /// 
    /// </summary>
    public T Depth { get { return value.Depth; } set { this.value.Depth = value; } }

    /// <summary>
    /// 
    /// </summary>
    public T Breadth { get { return value.Breadth; } set { this.value.Breadth = value; } }

    /// <summary>
    /// 
    /// </summary>
    public T Length { get { return value.Length; } set { this.value.Length = value; } }

    /// <summary>
    /// 
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public T[] Items { get { return new T[] { Width, Height, Depth, Breadth, Length }; } set { (Width, Height, Depth, Breadth, Length) = (value[0], value[1], value[2], value[3], value[4]); } }

    /// <summary>
    /// 
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
