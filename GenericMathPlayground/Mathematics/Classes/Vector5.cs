// <copyright file="Vector5.cs" company="Shkyrockett" >
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
/// The vector5.
/// </summary>
/// <typeparam name="T"></typeparam>
public class Vector5<T>
    : IVector5<T>
    where T : INumber<T>
{
    #region Fields
    /// <summary>
    /// 
    /// </summary>
    private ValueVector5<T> value;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="Vector5{T}"/> class.
    /// </summary>
    public Vector5() => value = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="Vector5{T}"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public Vector5(ValueVector5<T> value) => this.value = value;

    /// <summary>
    /// Initializes a new instance of the <see cref="Vector5{T}"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public Vector5(IVector5<T> value) => this.value = new(value);

    /// <summary>
    /// Initializes a new instance of the <see cref="Vector5{T}"/> class.
    /// </summary>
    /// <param name="tuple">The tuple.</param>
    public Vector5((T I, T J, T K, T L, T M) tuple) => value = new(tuple);

    /// <summary>
    /// Initializes a new instance of the <see cref="Vector5{T}"/> class.
    /// </summary>
    /// <param name="i">The i.</param>
    /// <param name="j">The j.</param>
    /// <param name="k">The k.</param>
    /// <param name="l">The l.</param>
    /// <param name="m">The m.</param>
    public Vector5(T i, T j, T k, T l, T m) => value = new(i, j, k, l, m);
    #endregion

    #region Deconstructors
    /// <summary>
    /// Deconstructs the.
    /// </summary>
    /// <param name="I">The i.</param>
    /// <param name="J">The j.</param>
    /// <param name="K">The k.</param>
    /// <param name="L">The l.</param>
    /// <param name="M">The m.</param>
    public void Deconstruct(out T I, out T J, out T K, out T L, out T M) => (I, J, K, L, M) = value;
    #endregion

    #region Properties
    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    public ValueVector5<T> Value { get { return value; } set { this.value = value; } }

    /// <summary>
    /// Gets or sets the i.
    /// </summary>
    public T I { get { return value.I; } set { this.value.I = value; } }

    /// <summary>
    /// Gets or sets the j.
    /// </summary>
    public T J { get { return value.J; } set { this.value.J = value; } }

    /// <summary>
    /// Gets or sets the k.
    /// </summary>
    public T K { get { return value.K; } set { this.value.K = value; } }

    /// <summary>
    /// Gets or sets the l.
    /// </summary>
    public T L { get { return value.L; } set { this.value.L = value; } }

    /// <summary>
    /// Gets or sets the m.
    /// </summary>
    public T M { get { return value.M; } set { this.value.M = value; } }

    /// <summary>
    /// Gets or sets the x.
    /// </summary>
    T IVector2<T>.X { get { return I; } set { I = value; } }

    /// <summary>
    /// Gets or sets the y.
    /// </summary>
    T IVector2<T>.Y { get { return J; } set { J = value; } }

    /// <summary>
    /// Gets or sets the z.
    /// </summary>
    T IVector3<T>.Z { get { return K; } set { K = value; } }

    /// <summary>
    /// Gets or sets the w.
    /// </summary>
    T IVector4<T>.W { get { return L; } set { L = value; } }

    /// <summary>
    /// Gets or sets the v.
    /// </summary>
    T IVector5<T>.V { get { return M; } set { M = value; } }

    /// <summary>
    /// Gets or sets the items.
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public T[] Items { get { return new T[] { I, J, K, L, M }; } set { (I, J, K, L, M) = (value[0], value[1], value[2], value[3], value[4]); } }

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
    public static implicit operator ValueVector5<T>(Vector5<T> value) => value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public static explicit operator Vector5<T>(ValueVector5<T> value) => new(value);
    #endregion
}
