// <copyright file="Vector3.cs" company="Shkyrockett" >
//     Copyright © 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace GenericMathPlayground.Mathematics;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public class Vector3<T>
    : IVector3<T>
    where T : INumber<T>
{
    #region Fields
    /// <summary>
    /// 
    /// </summary>
    private ValueVector3<T> value;
    #endregion

    #region Constructors
    /// <summary>
    /// 
    /// </summary>
    public Vector3() => value = new();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public Vector3(ValueVector3<T> value) => this.value = value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public Vector3(IVector3<T> value) => this.value = new(value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tuple"></param>
    public Vector3((T I, T J, T K) tuple) => value = new(tuple);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    /// <param name="k"></param>
    public Vector3(T i, T j, T k) => value = new(i, j, k);
    #endregion

    #region Deconstructors
    /// <summary>
    /// 
    /// </summary>
    /// <param name="I"></param>
    /// <param name="J"></param>
    /// <param name="K"></param>
    public void Deconstruct(out T I, out T J, out T K) => (I, J, K) = value;
    #endregion

    #region Properties
    /// <summary>
    /// 
    /// </summary>
    public ValueVector3<T> Value { get { return value; } set { this.value = value; } }

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
    public T K { get { return value.K; } set { this.value.K = value; } }

    /// <summary>
    /// 
    /// </summary>
    T IVector2<T>.X { get { return I; } set { I = value; } }

    /// <summary>
    /// 
    /// </summary>
    T IVector2<T>.Y { get { return J; } set { J = value; } }

    /// <summary>
    /// 
    /// </summary>
    T IVector3<T>.Z { get { return K; } set { K = value; } }

    /// <summary>
    /// 
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public T[] Items { get { return new T[] { I, J, K }; } set { (I, J, K) = (value[0], value[1], value[2]); } }

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
    public static implicit operator ValueVector3<T>(Vector3<T> value) => value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public static explicit operator Vector3<T>(ValueVector3<T> value) => new(value);
    #endregion
}
