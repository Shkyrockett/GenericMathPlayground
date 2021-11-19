// <copyright file="ValueVector5.cs" company="Shkyrockett" >
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
public struct ValueVector5<T>
    : IVector5<T>,
    IFormattable,
    IParseable<ValueVector5<T>>,
    ISpanParseable<ValueVector5<T>>,
    IEquatable<IVector5<T>>,
    IAdditiveIdentity<ValueVector5<T>, ValueVector5<T>>,
    IMultiplicativeIdentity<ValueVector5<T>, ValueVector5<T>>,
    IEqualityOperators<ValueVector5<T>, IVector5<T>>,
    IEqualityOperators<ValueVector5<T>, ValueVector5<T>>,
    IUnaryPlusOperators<ValueVector5<T>, ValueVector5<T>>,
    IAdditionOperators<ValueVector5<T>, IVector5<T>, ValueVector5<T>>,
    IUnaryNegationOperators<ValueVector5<T>, ValueVector5<T>>,
    ISubtractionOperators<ValueVector5<T>, IVector5<T>, ValueVector5<T>>,
    IMultiplyOperators<ValueVector5<T>, T, ValueVector5<T>>,
    IMultiplyOperators2<T, ValueVector5<T>, ValueVector5<T>>
    where T : INumber<T>
{
    #region Constructors
    /// <summary>
    /// 
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public ValueVector5() : this(T.Zero, T.Zero, T.Zero, T.Zero, T.Zero) { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="vector"></param>
    public ValueVector5(IVector5<T> vector) => (I, J, K, L, M) = vector;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tuple"></param>
    public ValueVector5((T I, T J, T K, T L, T M) tuple) => (I, J, K, L, M) = tuple;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    /// <param name="k"></param>
    /// <param name="l"></param>
    /// <param name="m"></param>
    public ValueVector5(T i, T j, T k, T l, T m) => (I, J, K, L, M) = (i, j, k, l, m);
    #endregion

    #region Deconstructors
    /// <summary>
    /// 
    /// </summary>
    /// <param name="I"></param>
    /// <param name="J"></param>
    /// <param name="K"></param>
    /// <param name="L"></param>
    /// <param name="M"></param>
    public void Deconstruct(out T I, out T J, out T K, out T L, out T M) => (I, J, K, L, M) = (this.I, this.J, this.K, this.L, this.M);
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
    [RefreshProperties(RefreshProperties.All)]
    public T M { get; set; }

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
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    T IVector5<T>.V { get { return M; } set { M = value; } }

    /// <summary>
    /// 
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public T[] Items { get { return new T[] { I, J, K, L, M }; } set { (I, J, K, L, M) = (value[0], value[1], value[2], value[3], value[4]); } }

    /// <summary>
    /// 
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public int Count => 5;

    /// <summary>
    /// 
    /// </summary>
    public static ValueVector5<T> AdditiveIdentity => new(T.Zero, T.Zero, T.Zero, T.Zero, T.Zero);

    /// <summary>
    /// 
    /// </summary>
    public static ValueVector5<T> MultiplicativeIdentity => new(T.One, T.One, T.One, T.One, T.One);
    #endregion

    #region Operators
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(ValueVector5<T> left, IVector5<T> right) => left.Equals(right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(ValueVector5<T> left, ValueVector5<T> right) => left.Equals(right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(ValueVector5<T> left, IVector5<T> right) => !(left == right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(ValueVector5<T> left, ValueVector5<T> right) => !(left == right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueVector5<T> operator +(ValueVector5<T> value) => value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector5<T> operator +(ValueVector5<T> left, IVector5<T> right) => new(Operations.AddVectors(left.I, left.J, left.K, left.L, left.M, right.X, right.Y, right.Z, right.W, right.V));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueVector5<T> operator -(ValueVector5<T> value) => new(Operations.NegateVector(value.I, value.J, value.K, value.L, value.M));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector5<T> operator -(ValueVector5<T> left, IVector5<T> right) => new(Operations.SubtractVector(left.I, left.J, left.K, left.L, left.M, right.X, right.Y, right.Z, right.W, right.V));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector5<T> operator *(ValueVector5<T> left, T right) => new(Operations.ScaleVector(left.I, left.J, left.K, left.L, left.M, right));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector5<T> operator *(T left, ValueVector5<T> right) => new(Operations.ScaleVector(right.I, right.J, right.K, right.L, right.M, left));
    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode() => HashCode.Combine(I, J, K, L, M);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj) => obj is ValueVector5<T> point && Equals(point);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(IVector5<T>? other) => other is IVector5<T> vector && I.Equals(vector.X) && J.Equals(vector.Y) && K.Equals(vector.Z) && L.Equals(vector.W) && M.Equals(vector.V);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(ValueVector5<T> other) => I.Equals(other.I) && J.Equals(other.J) && K.Equals(other.K) && L.Equals(other.L) && M.Equals(other.M);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="provider"></param>
    /// <returns></returns>
    public static ValueVector5<T> Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="provider"></param>
    /// <returns></returns>
    public static ValueVector5<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
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
    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out ValueVector5<T> result)
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
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out ValueVector5<T> result)
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
    public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(ValueVector5<T>)}: ({nameof(I)}: {I.ToString(format, formatProvider)}, {nameof(J)}: {J.ToString(format, formatProvider)}, {nameof(K)}: {K.ToString(format, formatProvider)}, {nameof(L)}: {L.ToString(format, formatProvider)}, {nameof(M)}: {M.ToString(format, formatProvider)})";

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private string? GetDebuggerDisplay() => ToString();
}
