// <copyright file="ValueVector4.cs" company="Shkyrockett" >
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
public struct ValueVector4<T>
    : IVector4<T>,
    IFormattable,
    IParseable<ValueVector4<T>>,
    ISpanParseable<ValueVector4<T>>,
    IEquatable<IVector4<T>>,
    IAdditiveIdentity<ValueVector4<T>, ValueVector4<T>>,
    IMultiplicativeIdentity<ValueVector4<T>, ValueVector4<T>>,
    IEqualityOperators<ValueVector4<T>, IVector4<T>>,
    IEqualityOperators<ValueVector4<T>, ValueVector4<T>>,
    IUnaryPlusOperators<ValueVector4<T>, ValueVector4<T>>,
    IAdditionOperators<ValueVector4<T>, IVector4<T>, ValueVector4<T>>,
    IUnaryNegationOperators<ValueVector4<T>, ValueVector4<T>>,
    ISubtractionOperators<ValueVector4<T>, IVector4<T>, ValueVector4<T>>,
    IMultiplyOperators<ValueVector4<T>, T, ValueVector4<T>>,
    IMultiplyOperators2<T, ValueVector4<T>, ValueVector4<T>>
    where T : INumber<T>
{
    #region Constructors
    /// <summary>
    /// 
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public ValueVector4() : this(T.Zero, T.Zero, T.Zero, T.Zero) { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="vector"></param>
    public ValueVector4(IVector4<T> vector) => (I, J, K, L) = vector;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tuple"></param>
    public ValueVector4((T I, T J, T K, T L) tuple) => (I, J, K, L) = tuple;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    /// <param name="k"></param>
    /// <param name="l"></param>
    public ValueVector4(T i, T j, T k, T l) => (I, J, K, L) = (i, j, k, l);
    #endregion

    #region Deconstructors
    /// <summary>
    /// 
    /// </summary>
    /// <param name="I"></param>
    /// <param name="J"></param>
    /// <param name="K"></param>
    /// <param name="L"></param>
    public void Deconstruct(out T I, out T J, out T K, out T L) => (I, J, K, L) = (this.I, this.J, this.K, this.L);
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
    [RefreshProperties(RefreshProperties.All)]
    public T L { get; set; }

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
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    T IVector4<T>.W { get { return L; } set { L = value; } }

    /// <summary>
    /// 
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public T[] Items { get { return new T[] { I, J, K, L }; } set { (I, J, K, L) = (value[0], value[1], value[2], value[3]); } }

    /// <summary>
    /// 
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public int Count => 4;

    /// <summary>
    /// 
    /// </summary>
    public static ValueVector4<T> AdditiveIdentity => new(T.Zero, T.Zero, T.Zero, T.Zero);

    /// <summary>
    /// 
    /// </summary>
    public static ValueVector4<T> MultiplicativeIdentity => new(T.One, T.One, T.One, T.One);
    #endregion

    #region Operators
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(ValueVector4<T> left, IVector4<T> right) => left.Equals(right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(ValueVector4<T> left, ValueVector4<T> right) => left.Equals(right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(ValueVector4<T> left, IVector4<T> right) => !(left == right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(ValueVector4<T> left, ValueVector4<T> right) => !(left == right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueVector4<T> operator +(ValueVector4<T> value) => value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector4<T> operator +(ValueVector4<T> left, IVector4<T> right) => new(Operations.AddVectors(left.I, left.J, left.K, left.L, right.X, right.Y, right.Z, right.W));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueVector4<T> operator -(ValueVector4<T> value) => new(Operations.NegateVector(value.I, value.J, value.K, value.L));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector4<T> operator -(ValueVector4<T> left, IVector4<T> right) => new(Operations.SubtractVector(left.I, left.J, left.K, left.L, right.X, right.Y, right.Z, right.W));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector4<T> operator *(ValueVector4<T> left, T right) => new(Operations.ScaleVector(left.I, left.J, left.K, left.L, right));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector4<T> operator *(T left, ValueVector4<T> right) => new(Operations.ScaleVector(right.I, right.J, right.K, right.L, left));
    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode() => HashCode.Combine(I, J, K, L);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj) => obj is ValueVector4<T> point && Equals(point);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(IVector4<T>? other) => other is IVector4<T> vector && I.Equals(vector.X) && J.Equals(vector.Y) && K.Equals(vector.Z) && L.Equals(vector.W);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(ValueVector4<T> other) => I.Equals(other.I) && J.Equals(other.J) && K.Equals(other.K) && L.Equals(other.L);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="provider"></param>
    /// <returns></returns>
    public static ValueVector4<T> Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="provider"></param>
    /// <returns></returns>
    public static ValueVector4<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
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
    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out ValueVector4<T> result)
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
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out ValueVector4<T> result)
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
    public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(ValueVector4<T>)}: ({nameof(I)}: {I.ToString(format, formatProvider)}, {nameof(J)}: {J.ToString(format, formatProvider)}, {nameof(K)}: {K.ToString(format, formatProvider)}, {nameof(L)}: {L.ToString(format, formatProvider)})";

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private string? GetDebuggerDisplay() => ToString();
}
