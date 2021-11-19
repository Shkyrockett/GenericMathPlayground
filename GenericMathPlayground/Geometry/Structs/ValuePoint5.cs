// <copyright file="ValuePoint5.cs" company="Shkyrockett" >
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
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace GenericMathPlayground.Geometry;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
[TypeConverter(typeof(ExpandableObjectConverter))]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public struct ValuePoint5<T>
    : IPoint5<T>,
    IFormattable,
    IParseable<ValuePoint5<T>>,
    ISpanParseable<ValuePoint5<T>>,
    IComparable,
    IComparable<IVector5<T>>,
    IEquatable<IVector5<T>>,
    IAdditiveIdentity<ValuePoint5<T>, ValuePoint5<T>>,
    IMultiplicativeIdentity<ValuePoint5<T>, ValuePoint5<T>>,
    IComparisonOperators<ValuePoint5<T>, IVector5<T>>,
    IEqualityOperators<ValuePoint5<T>, IVector5<T>>,
    IIncrementOperators<ValuePoint5<T>>,
    IUnaryPlusOperators<ValuePoint5<T>, ValuePoint5<T>>,
    IAdditionOperators<ValuePoint5<T>, IVector5<T>, ValuePoint5<T>>,
    IDecrementOperators<ValuePoint5<T>>,
    IUnaryNegationOperators<ValuePoint5<T>, ValuePoint5<T>>,
    ISubtractionOperators<ValuePoint5<T>, IVector5<T>, ValuePoint5<T>>,
    IMultiplyOperators<ValuePoint5<T>, T, ValuePoint5<T>>,
    IDivisionOperators<ValuePoint5<T>, T, ValuePoint5<T>>,
    IModulusOperators<ValuePoint5<T>, T, ValuePoint5<T>>
    where T : INumber<T>
{
    #region Constructors
    /// <summary>
    /// 
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public ValuePoint5() : this(T.Zero, T.Zero, T.Zero, T.Zero, T.Zero) { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public ValuePoint5(IVector5<T> value) => (X, Y, Z, W, V) = value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tuple"></param>
    public ValuePoint5((T X, T Y, T Z, T W, T V) tuple) => (X, Y, Z, W, V) = tuple;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    /// <param name="w"></param>
    /// <param name="v"></param>
    public ValuePoint5(T x, T y, T z, T w, T v) => (X, Y, Z, W, V) = (x, y, z, w, v);
    #endregion

    #region Deconstructors
    /// <summary>
    /// 
    /// </summary>
    /// <param name="X"></param>
    /// <param name="Y"></param>
    /// <param name="Z"></param>
    /// <param name="W"></param>
    /// <param name="V"></param>
    public void Deconstruct(out T X, out T Y, out T Z, out T W, out T V) => (X, Y, Z, W, V) = (this.X, this.Y, this.Z, this.W, this.V);
    #endregion

    #region Properties
    /// <summary>
    /// 
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T X { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T Y { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T Z { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T W { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T V { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    public T[] Items { get { return new T[] { X, Y, Z, W, V }; } set { (X, Y, Z, W, V) = (value[0], value[1], value[2], value[3], value[4]); } }

    /// <summary>
    /// 
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public int Count => 5;

    /// <summary>
    /// 
    /// </summary>
    public static ValuePoint5<T> AdditiveIdentity => new(T.Zero, T.Zero, T.Zero, T.Zero, T.Zero);

    /// <summary>
    /// 
    /// </summary>
    public static ValuePoint5<T> MultiplicativeIdentity => new(T.One, T.One, T.One, T.One, T.One);
    #endregion

    #region Operators
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator <(ValuePoint5<T> left, IVector5<T> right)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator <=(ValuePoint5<T> left, IVector5<T> right)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(ValuePoint5<T> left, IVector5<T> right) => left.Equals(right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(ValuePoint5<T> left, ValuePoint5<T> right) => left.Equals(right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(ValuePoint5<T> left, IVector5<T> right) => !(left == right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(ValuePoint5<T> left, ValuePoint5<T> right) => !(left == right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator >(ValuePoint5<T> left, IVector5<T> right)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator >=(ValuePoint5<T> left, IVector5<T> right)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValuePoint5<T> operator ++(ValuePoint5<T> value) => new(++value.X, ++value.Y, ++value.Z, ++value.W, ++value.V);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValuePoint5<T> operator +(ValuePoint5<T> value) => value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValuePoint5<T> operator +(ValuePoint5<T> left, IVector5<T> right) => new(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W, left.V + right.V);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValuePoint5<T> operator --(ValuePoint5<T> value) => new(--value.X, --value.Y, --value.Z, --value.W, --value.V);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValuePoint5<T> operator -(ValuePoint5<T> value) => new(-value.X, -value.Y, -value.Z, -value.W, -value.V);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValuePoint5<T> operator -(ValuePoint5<T> left, IVector5<T> right) => new(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W, left.V - right.V);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValuePoint5<T> operator *(ValuePoint5<T> left, T right) => new(left.X * right, left.Y * right, left.Z * right, left.W * right, left.V * right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValuePoint5<T> operator /(ValuePoint5<T> left, T right) => new(left.X / right, left.Y / right, left.Z / right, left.W / right, left.V / right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValuePoint5<T> operator %(ValuePoint5<T> left, T right) => new(left.X % right, left.Y % right, left.Z % right, left.W % right, left.V % right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public static implicit operator ValuePoint5<T>(ValueVector3<T> value) => value;
    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode() => HashCode.Combine(X, Y, Z, W, V);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public int CompareTo(object? obj)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public int CompareTo(IVector5<T>? other)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj) => obj is ValuePoint5<T> point && Equals(point);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(ValuePoint5<T> other) => X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z) && W.Equals(other.W) && V.Equals(other.V);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(IVector5<T>? other) => other is IVector5<T> vector && X.Equals(vector.X) && Y.Equals(vector.Y) && Z.Equals(vector.Z) && W.Equals(vector.W) && V.Equals(vector.V);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="provider"></param>
    /// <returns></returns>
    public static ValuePoint5<T> Parse(string s, IFormatProvider? provider)
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
    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out ValuePoint5<T> result)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="provider"></param>
    /// <returns></returns>
    public static ValuePoint5<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
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
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out ValuePoint5<T> result)
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
    public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(ValuePoint5<T>)}: ({nameof(X)}: {X.ToString(format, formatProvider)}, {nameof(Y)}: {Y.ToString(format, formatProvider)}, {nameof(Z)}: {Z.ToString(format, formatProvider)}, {nameof(W)}: {W.ToString(format, formatProvider)}, {nameof(V)}: {V.ToString(format, formatProvider)})";

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private string? GetDebuggerDisplay() => ToString();
}
