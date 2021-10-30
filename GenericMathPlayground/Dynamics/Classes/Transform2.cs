// <copyright file="Transform2.cs" company="Shkyrockett" >
//     Copyright © 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using GenericMathPlayground.Geometry;
using GenericMathPlayground.Mathematics;
using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace GenericMathPlayground.Dynamics;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public class Transform2<T>
    : IMatrix<T>
    where T : INumber<T>
{
    #region Fields
    private ValueTransform2<T> value;
    #endregion

    #region Constructors
    /// <summary>
    /// 
    /// </summary>
    public Transform2() => value = new();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public Transform2(ValueTransform2<T> value) => this.value = value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="location"></param>
    /// <param name="skew"></param>
    /// <param name="scale"></param>
    public Transform2(IPoint2<T> location, IVector2<T> skew, ISize2<T> scale) => value = new(location, skew, scale);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tuple"></param>
    public Transform2((T X, T Y, T I, T J, T Width, T Height) tuple) => value = new(tuple);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="i"></param>
    /// <param name="j"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public Transform2(T x, T y, T i, T j, T width, T height) => value = new(x, y, i, j, width, height);
    #endregion

    #region Deconstructors
    /// <summary>
    /// 
    /// </summary>
    /// <param name="X"></param>
    /// <param name="Y"></param>
    /// <param name="I"></param>
    /// <param name="J"></param>
    /// <param name="Width"></param>
    /// <param name="Height"></param>
    public void Deconstruct(out T X, out T Y, out T I, out T J, out T Width, out T Height) => (X, Y, I, J, Width, Height) = value;
    #endregion

    #region Properties
    /// <summary>
    /// 
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public ValueTransform2<T> Value { get { return value; } set { this.value = value; } }

    /// <summary>
    /// 
    /// </summary>
    public T X { get { return value.X; } set { this.value.X = value; } }

    /// <summary>
    /// 
    /// </summary>
    public T Y { get { return value.Y; } set { this.value.Y = value; } }

    /// <summary>
    /// 
    /// </summary>
    public T I { get { return value.I; } set { this.value.I = value; } }

    /// <summary>
    /// 
    /// </summary>
    public T J { get { return value.J; } set { this.value.J = value; } }

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
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public T[,] Items { get { return new T[,] { { X, Y }, { I, J }, { Width, Height } }; } set { (X, Y, I, J, Width, Height) = (value[0, 0], value[0, 1], value[1, 0], value[1, 1], value[2, 0], value[2, 1]); } }

    /// <summary>
    /// 
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public int Rows => value.Rows;

    /// <summary>
    /// 
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public int Columns => value.Columns;

    /// <summary>
    /// 
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public T Determinant => value.Determinant;
    #endregion

    #region Operators
    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public static implicit operator ValueTransform2<T>(Transform2<T> value) => value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public static explicit operator Transform2<T>(ValueTransform2<T> value) => new(value);
    #endregion
}
