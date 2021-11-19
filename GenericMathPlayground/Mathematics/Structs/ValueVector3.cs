// <copyright file="ValueVector3.cs" company="Shkyrockett" >
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
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace GenericMathPlayground.Mathematics;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
[TypeConverter(typeof(ExpandableObjectConverter))]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public struct ValueVector3<T>
    : IVector3<T>,
    IFormattable,
    IParseable<ValueVector3<T>>,
    ISpanParseable<ValueVector3<T>>,
    IEquatable<IVector3<T>>,
    IAdditiveIdentity<ValueVector3<T>, ValueVector3<T>>,
    IMultiplicativeIdentity<ValueVector3<T>, ValueVector3<T>>,
    IEqualityOperators<ValueVector3<T>, IVector3<T>>,
    IEqualityOperators<ValueVector3<T>, ValueVector3<T>>,
    IUnaryPlusOperators<ValueVector3<T>, ValueVector3<T>>,
    IAdditionOperators<ValueVector3<T>, IVector3<T>, ValueVector3<T>>,
    IUnaryNegationOperators<ValueVector3<T>, ValueVector3<T>>,
    ISubtractionOperators<ValueVector3<T>, IVector3<T>, ValueVector3<T>>,
    IMultiplyOperators<ValueVector3<T>, T, ValueVector3<T>>,
    IMultiplyOperators2<T, ValueVector3<T>, ValueVector3<T>>
    where T : INumber<T>
{
    #region Constructors
    /// <summary>
    /// 
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public ValueVector3() : this(T.Zero, T.Zero, T.Zero) { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="vector"></param>
    public ValueVector3(IVector3<T> vector) => (I, J, K) = vector;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tuple"></param>
    public ValueVector3((T I, T J, T K) tuple) => (I, J, K) = tuple;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    /// <param name="k"></param>
    public ValueVector3(T i, T j, T k) => (I, J, K) = (i, j, k);
    #endregion

    #region Deconstructors
    /// <summary>
    /// 
    /// </summary>
    /// <param name="I"></param>
    /// <param name="J"></param>
    /// <param name="K"></param>
    public void Deconstruct(out T I, out T J, out T K) => (I, J, K) = (this.I, this.J, this.K);
    #endregion

    #region Properties
    /// <summary>
    /// 
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T I { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T J { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T K { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    T IVector2<T>.X { get { return I; } set { I = value; } }

    /// <summary>
    /// 
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    T IVector2<T>.Y { get { return J; } set { J = value; } }

    /// <summary>
    /// 
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    T IVector3<T>.Z { get { return K; } set { K = value; } }

    /// <summary>
    /// 
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public T[] Items { get { return new T[] { I, J, K }; } set { (I, J, K) = (value[0], value[1], value[2]); } }

    /// <summary>
    /// 
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public int Count => 3;

    /// <summary>
    /// 
    /// </summary>
    public static ValueVector3<T> AdditiveIdentity => new(T.Zero, T.Zero, T.Zero);

    /// <summary>
    /// 
    /// </summary>
    public static ValueVector3<T> MultiplicativeIdentity => new(T.One, T.One, T.One);
    #endregion

    #region Operators
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(ValueVector3<T> left, IVector3<T> right) => left.Equals(right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(ValueVector3<T> left, ValueVector3<T> right) => left.Equals(right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(ValueVector3<T> left, IVector3<T> right) => !(left == right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(ValueVector3<T> left, ValueVector3<T> right) => !(left == right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueVector3<T> operator +(ValueVector3<T> value) => value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector3<T> operator +(ValueVector3<T> left, IVector3<T> right) => new(Operations.AddVectors(left.I, left.J, left.K, right.X, right.Y, right.Z));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueVector3<T> operator -(ValueVector3<T> value) => new(Operations.NegateVector(value.I, value.J, value.K));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector3<T> operator -(ValueVector3<T> left, IVector3<T> right) => new(Operations.SubtractVector(left.I, left.J, left.K, right.X, right.Y, right.Z));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector3<T> operator *(ValueVector3<T> left, T right) => new(Operations.ScaleVector(left.I, left.J, left.K, right));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector3<T> operator *(T left, ValueVector3<T> right) => new(Operations.ScaleVector(right.I, right.J, right.K, left));
    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public ValueVector3<T> CrossProduct(ValueVector3<T> other) => new(Operations.CrossProduct(I, J, K, other.I, other.J, other.K));

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode() => HashCode.Combine(I, J, K);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj) => obj is ValueVector3<T> point && Equals(point);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(IVector3<T>? other) => other is IVector3<T> vector && I.Equals(vector.X) && J.Equals(vector.Y) && K.Equals(vector.Z);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(ValueVector3<T> other) => I.Equals(other.I) && J.Equals(other.J) && K.Equals(other.K);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="provider"></param>
    /// <returns></returns>
    public static ValueVector3<T> Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="provider"></param>
    /// <returns></returns>
    public static ValueVector3<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="provider"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out ValueVector3<T> result)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="provider"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out ValueVector3<T> result)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override string? ToString() => ToString("R", CultureInfo.InvariantCulture);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="formatProvider"></param>
    /// <returns></returns>
    public string ToString(IFormatProvider formatProvider) => ToString("R", formatProvider);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="format"></param>
    /// <param name="formatProvider"></param>
    /// <returns></returns>
    public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(ValueVector3<T>)}: ({nameof(I)}: {I.ToString(format, formatProvider)}, {nameof(J)}: {J.ToString(format, formatProvider)}, {nameof(K)}: {K.ToString(format, formatProvider)})";

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private string? GetDebuggerDisplay() => ToString();
}
