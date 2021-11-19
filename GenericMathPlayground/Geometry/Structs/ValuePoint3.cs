// <copyright file="ValuePoint3.cs" company="Shkyrockett" >
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
public struct ValuePoint3<T>
    : IPoint3<T>,
    IFormattable,
    IParseable<ValuePoint3<T>>,
    ISpanParseable<ValuePoint3<T>>,
    IComparable,
    IComparable<IVector3<T>>,
    IEquatable<IVector3<T>>,
    IAdditiveIdentity<ValuePoint3<T>, ValuePoint3<T>>,
    IMultiplicativeIdentity<ValuePoint3<T>, ValuePoint3<T>>,
    IComparisonOperators<ValuePoint3<T>, IVector3<T>>,
    IEqualityOperators<ValuePoint3<T>, IVector3<T>>,
    IIncrementOperators<ValuePoint3<T>>,
    IUnaryPlusOperators<ValuePoint3<T>, ValuePoint3<T>>,
    IAdditionOperators<ValuePoint3<T>, IVector3<T>, ValuePoint3<T>>,
    IDecrementOperators<ValuePoint3<T>>,
    IUnaryNegationOperators<ValuePoint3<T>, ValuePoint3<T>>,
    ISubtractionOperators<ValuePoint3<T>, IVector3<T>, ValuePoint3<T>>,
    IMultiplyOperators<ValuePoint3<T>, T, ValuePoint3<T>>,
    IMultiplyOperators<ValuePoint3<T>, ValueSize3<T>, ValuePoint3<T>>,
    IDivisionOperators<ValuePoint3<T>, T, ValuePoint3<T>>,
    IDivisionOperators<ValuePoint3<T>, ValueSize3<T>, ValuePoint3<T>>,
    IModulusOperators<ValuePoint3<T>, T, ValuePoint3<T>>,
    IModulusOperators<ValuePoint3<T>, ValueSize3<T>, ValuePoint3<T>>
    where T : INumber<T>
{
    #region Constructors
    /// <summary>
    /// 
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public ValuePoint3() : this(T.Zero, T.Zero, T.Zero) { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public ValuePoint3(IVector3<T> value) => (X, Y, Z) = value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tuple"></param>
    public ValuePoint3((T X, T Y, T Z) tuple) => (X, Y, Z) = tuple;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    public ValuePoint3(T x, T y, T z) => (X, Y, Z) = (x, y, z);
    #endregion

    #region Deconstructors
    /// <summary>
    /// 
    /// </summary>
    /// <param name="X"></param>
    /// <param name="Y"></param>
    /// <param name="Z"></param>
    public void Deconstruct(out T X, out T Y, out T Z) => (X, Y, Z) = (this.X, this.Y, this.Z);
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
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    public T[] Items { get { return new T[] { X, Y, Z }; } set { (X, Y, Z) = (value[0], value[1], value[2]); } }

    /// <summary>
    /// 
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public int Count => 3;

    /// <summary>
    /// 
    /// </summary>
    public static ValuePoint3<T> AdditiveIdentity => new(T.Zero, T.Zero, T.Zero);

    /// <summary>
    /// 
    /// </summary>
    public static ValuePoint3<T> MultiplicativeIdentity => new(T.One, T.One, T.One);
    #endregion

    #region Operators
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator <(ValuePoint3<T> left, IVector3<T> right)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator <=(ValuePoint3<T> left, IVector3<T> right)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(ValuePoint3<T> left, IVector3<T> right) => left.Equals(right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(ValuePoint3<T> left, ValuePoint3<T> right) => left.Equals(right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(ValuePoint3<T> left, IVector3<T> right) => !(left == right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(ValuePoint3<T> left, ValuePoint3<T> right) => !(left == right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator >(ValuePoint3<T> left, IVector3<T> right)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator >=(ValuePoint3<T> left, IVector3<T> right)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValuePoint3<T> operator ++(ValuePoint3<T> value) => new(++value.X, ++value.Y, ++value.Z);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValuePoint3<T> operator +(ValuePoint3<T> value) => value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValuePoint3<T> operator +(ValuePoint3<T> left, IVector3<T> right) => new(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValuePoint3<T> operator --(ValuePoint3<T> value) => new(--value.X, --value.Y, --value.Z);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValuePoint3<T> operator -(ValuePoint3<T> value) => new(-value.X, -value.Y, -value.Z);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValuePoint3<T> operator -(ValuePoint3<T> left, IVector3<T> right) => new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValuePoint3<T> operator *(ValuePoint3<T> left, T right) => new(left.X * right, left.Y * right, left.Z * right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValuePoint3<T> operator *(ValuePoint3<T> left, ValueSize3<T> right) => new(left.X * right.Width, left.Y * right.Height, left.Z * right.Depth);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValuePoint3<T> operator /(ValuePoint3<T> left, T right) => new(left.X / right, left.Y / right, left.Z / right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValuePoint3<T> operator /(ValuePoint3<T> left, ValueSize3<T> right) => new(left.X / right.Width, left.Y / right.Height, left.Z / right.Depth);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValuePoint3<T> operator %(ValuePoint3<T> left, T right) => new(left.X % right, left.Y % right, left.Z % right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValuePoint3<T> operator %(ValuePoint3<T> left, ValueSize3<T> right) => new(left.X % right.Width, left.Y % right.Height, left.Z % right.Depth);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public static implicit operator ValuePoint3<T>(ValueVector3<T> value) => value;
    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode() => HashCode.Combine(X, Y, Z);

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
    public int CompareTo(IVector3<T>? other)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj) => obj is ValuePoint3<T> point && Equals(point);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(ValuePoint3<T> other) => X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(IVector3<T>? other) => other is IVector3<T> vector && X.Equals(vector.X) && Y.Equals(vector.Y) && Z.Equals(vector.Z);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="provider"></param>
    /// <returns></returns>
    public static ValuePoint3<T> Parse(string s, IFormatProvider? provider)
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
    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out ValuePoint3<T> result)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="provider"></param>
    /// <returns></returns>
    public static ValuePoint3<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
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
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out ValuePoint3<T> result)
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
    public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(ValuePoint3<T>)}: ({nameof(X)}: {X.ToString(format, formatProvider)}, {nameof(Y)}: {Y.ToString(format, formatProvider)}, {nameof(Z)}: {Z.ToString(format, formatProvider)})";

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private string? GetDebuggerDisplay() => ToString();
}
