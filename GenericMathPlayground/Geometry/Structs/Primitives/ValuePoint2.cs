// <copyright file="ValuePoint2.cs" company="Shkyrockett" >
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
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace GenericMathPlayground.Geometry;

/// <summary>
/// The value point2.
/// </summary>
/// <typeparam name="T"></typeparam>
[TypeConverter(typeof(ExpandableObjectConverter))]
//[TypeConverter(typeof(StructConverter<ValuePoint2<MetersUnit>>))]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public struct ValuePoint2<T>
    : IPoint2<T>,
    IToString<T>,
    IFormattable,
    IParsable<ValuePoint2<T>>,
    ISpanParsable<ValuePoint2<T>>,
    IComparable,
    IComparable<IVector2<T>>,
    IEquatable<IVector2<T>>,
    IAdditiveIdentity<ValuePoint2<T>, ValuePoint2<T>>,
    IMultiplicativeIdentity<ValuePoint2<T>, ValuePoint2<T>>,
    IComparisonOperators<ValuePoint2<T>, IVector2<T>>,
    IEqualityOperators<ValuePoint2<T>, IVector2<T>>,
    IIncrementOperators<ValuePoint2<T>>,
    IUnaryPlusOperators<ValuePoint2<T>, ValuePoint2<T>>,
    IAdditionOperators<ValuePoint2<T>, IVector2<T>, ValuePoint2<T>>,
    IDecrementOperators<ValuePoint2<T>>,
    IUnaryNegationOperators<ValuePoint2<T>, ValuePoint2<T>>,
    ISubtractionOperators<ValuePoint2<T>, IVector2<T>, ValuePoint2<T>>,
    IMultiplyOperators<ValuePoint2<T>, T, ValuePoint2<T>>,
    IMultiplyOperators<ValuePoint2<T>, ValueSize2<T>, ValuePoint2<T>>,
    IDivisionOperators<ValuePoint2<T>, T, ValuePoint2<T>>,
    IDivisionOperators<ValuePoint2<T>, ValueSize2<T>, ValuePoint2<T>>,
    IModulusOperators<ValuePoint2<T>, T, ValuePoint2<T>>,
    IModulusOperators<ValuePoint2<T>, ValueSize2<T>, ValuePoint2<T>>
    where T : INumber<T>
{
    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="ValuePoint2{T}"/> class.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public ValuePoint2() : this(T.Zero, T.Zero) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValuePoint2{T}"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public ValuePoint2(IVector2<T> value) => (X, Y) = value;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValuePoint2{T}"/> class.
    /// </summary>
    /// <param name="tuple">The tuple.</param>
    public ValuePoint2((T X, T Y) tuple) => (X, Y) = tuple;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValuePoint2{T}"/> class.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    public ValuePoint2(T x, T y) => (X, Y) = (x, y);
    #endregion

    #region Deconstructors
    /// <summary>
    /// Deconstructs the.
    /// </summary>
    /// <param name="X">The x.</param>
    /// <param name="Y">The y.</param>
    public void Deconstruct(out T X, out T Y) => (X, Y) = (this.X, this.Y);
    #endregion

    #region Properties
    /// <summary>
    /// Gets or sets the x.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T X { get; set; }

    /// <summary>
    /// Gets or sets the y.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T Y { get; set; }

    /// <summary>
    /// Gets or sets the items.
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    public T[] Items { get { return new T[] { X, Y }; } set { (X, Y) = (value[0], value[1]); } }

    /// <summary>
    /// Gets the count.
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public int Count => 2;

    /// <summary>
    /// Gets the additive identity.
    /// </summary>
    public static ValuePoint2<T> AdditiveIdentity => new(T.Zero, T.Zero);

    /// <summary>
    /// Gets the multiplicative identity.
    /// </summary>
    public static ValuePoint2<T> MultiplicativeIdentity => new(T.One, T.One);
    #endregion

    #region Operators
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator <(ValuePoint2<T> left, IVector2<T> right)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator <=(ValuePoint2<T> left, IVector2<T> right)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(ValuePoint2<T> left, IVector2<T> right) => left.Equals(right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(ValuePoint2<T> left, ValuePoint2<T> right) => left.Equals(right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(ValuePoint2<T> left, IVector2<T> right) => !(left == right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(ValuePoint2<T> left, ValuePoint2<T> right) => !(left == right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator >(ValuePoint2<T> left, IVector2<T> right)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator >=(ValuePoint2<T> left, IVector2<T> right)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValuePoint2<T> operator ++(ValuePoint2<T> value) => new(++value.X, ++value.Y);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValuePoint2<T> operator checked ++(ValuePoint2<T> value) => new(++value.X, ++value.Y);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValuePoint2<T> operator +(ValuePoint2<T> value) => value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValuePoint2<T> operator +(ValuePoint2<T> left, IVector2<T> right) => new(left.X + right.X, left.Y + right.Y);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValuePoint2<T> operator checked +(ValuePoint2<T> left, IVector2<T> right) => new(left.X + right.X, left.Y + right.Y);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValuePoint2<T> operator --(ValuePoint2<T> value) => new(--value.X, --value.Y);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValuePoint2<T> operator checked --(ValuePoint2<T> value) => new(--value.X, --value.Y);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValuePoint2<T> operator -(ValuePoint2<T> value) => new(-value.X, -value.Y);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValuePoint2<T> operator checked -(ValuePoint2<T> value) => new(-value.X, -value.Y);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValuePoint2<T> operator -(ValuePoint2<T> left, IVector2<T> right) => new(left.X - right.X, left.Y - right.Y);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValuePoint2<T> operator checked -(ValuePoint2<T> left, IVector2<T> right) => new(left.X - right.X, left.Y - right.Y);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValuePoint2<T> operator *(ValuePoint2<T> left, T right) => new(left.X * right, left.Y * right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValuePoint2<T> operator checked *(ValuePoint2<T> left, T right) => new(left.X * right, left.Y * right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValuePoint2<T> operator *(ValuePoint2<T> left, ValueSize2<T> right) => new(left.X * right.Width, left.Y * right.Height);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValuePoint2<T> operator checked *(ValuePoint2<T> left, ValueSize2<T> right) => new(left.X * right.Width, left.Y * right.Height);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValuePoint2<T> operator /(ValuePoint2<T> left, T right) => new(left.X / right, left.Y / right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValuePoint2<T> operator checked /(ValuePoint2<T> left, T right) => new(left.X / right, left.Y / right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValuePoint2<T> operator /(ValuePoint2<T> left, ValueSize2<T> right) => new(left.X / right.Width, left.Y / right.Height);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValuePoint2<T> operator checked /(ValuePoint2<T> left, ValueSize2<T> right) => new(left.X / right.Width, left.Y / right.Height);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValuePoint2<T> operator %(ValuePoint2<T> left, T right) => new(left.X % right, left.Y % right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValuePoint2<T> operator %(ValuePoint2<T> left, ValueSize2<T> right) => new(left.X % right.Width, left.Y % right.Height);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public static implicit operator ValuePoint2<T>(ValueVector2<T> value) => value;
    #endregion

    /// <summary>
    /// Gets the hash code.
    /// </summary>
    /// <returns>An int.</returns>
    public override int GetHashCode() => HashCode.Combine(X, Y);

    /// <summary>
    /// Compares the to.
    /// </summary>
    /// <param name="obj">The obj.</param>
    /// <returns>An int.</returns>
    public int CompareTo(object? obj)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Compares the to.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>An int.</returns>
    public int CompareTo(IVector2<T>? other)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="obj">The obj.</param>
    /// <returns>A bool.</returns>
    public override bool Equals(object? obj) => obj is ValuePoint2<T> point && Equals(point);

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>A bool.</returns>
    public bool Equals(ValuePoint2<T> other) => X.Equals(other.X) && Y.Equals(other.Y);

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>A bool.</returns>
    public bool Equals(IVector2<T>? other) => other is IVector2<T> vector && X.Equals(vector.X) && Y.Equals(vector.Y);

    /// <summary>
    /// Parses the.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="provider">The provider.</param>
    /// <returns>A ValuePoint2.</returns>
    public static ValuePoint2<T> Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Tries the parse.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="provider">The provider.</param>
    /// <param name="result">The result.</param>
    /// <returns>A bool.</returns>
    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out ValuePoint2<T> result)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Parses the.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="provider">The provider.</param>
    /// <returns>A ValuePoint2.</returns>
    public static ValuePoint2<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Tries the parse.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="provider">The provider.</param>
    /// <param name="result">The result.</param>
    /// <returns>A bool.</returns>
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out ValuePoint2<T> result)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Tos the string.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="formatProvider">The format provider.</param>
    /// <returns>A string.</returns>
    public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(ValuePoint2<T>)}: ({nameof(X)}: {X.ToString(format, formatProvider)}, {nameof(Y)}: {Y.ToString(format, formatProvider)})";

    /// <summary>
    /// Gets the debugger display.
    /// </summary>
    /// <returns>A string? .</returns>
    private string? GetDebuggerDisplay() => ToString();
}
