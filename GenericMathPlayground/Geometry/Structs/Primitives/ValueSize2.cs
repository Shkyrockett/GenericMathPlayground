// <copyright file="ValueSize2.cs" company="Shkyrockett" >
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
/// The value size2.
/// </summary>
/// <typeparam name="T"></typeparam>
[TypeConverter(typeof(ExpandableObjectConverter))]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public struct ValueSize2<T>
    : ISize2<T>,
    IToString<T>,
    IFormattable,
    IParsable<ValueSize2<T>>,
    ISpanParsable<ValueSize2<T>>,
    IComparable,
    IComparable<IVector2<T>>,
    IEquatable<ValueSize2<T>>,
    IAdditiveIdentity<ValueSize2<T>, ValueSize2<T>>,
    IMultiplicativeIdentity<ValueSize2<T>, ValueSize2<T>>,
    IComparisonOperators<ValueSize2<T>, IVector2<T>>,
    IEqualityOperators<ValueSize2<T>, IVector2<T>>,
    IIncrementOperators<ValueSize2<T>>,
    IUnaryPlusOperators<ValueSize2<T>, ValueSize2<T>>,
    IAdditionOperators<ValueSize2<T>, IVector2<T>, ValueSize2<T>>,
    IAdditionOperators2<IVector2<T>, ValueSize2<T>, IVector2<T>>,
    IDecrementOperators<ValueSize2<T>>,
    IUnaryNegationOperators<ValueSize2<T>, ValueSize2<T>>,
    ISubtractionOperators<ValueSize2<T>, IVector2<T>, ValueSize2<T>>,
    ISubtractionOperators2<IVector2<T>, ValueSize2<T>, IVector2<T>>,
    IMultiplyOperators<ValueSize2<T>, T, ValueSize2<T>>,
    IMultiplyOperators<ValueSize2<T>, ValueSize2<T>, ValueSize2<T>>,
    IMultiplyOperators<ValueSize2<T>, IVector2<T>, ValueSize2<T>>,
    IMultiplyOperators2<IVector2<T>, ValueSize2<T>, IVector2<T>>,
    IDivisionOperators<ValueSize2<T>, T, ValueSize2<T>>,
    IDivisionOperators<ValueSize2<T>, ValueSize2<T>, ValueSize2<T>>,
    IDivisionOperators<ValueSize2<T>, IVector2<T>, ValueSize2<T>>,
    IDivisionOperators2<IVector2<T>, ValueSize2<T>, IVector2<T>>,
    IModulusOperators<ValueSize2<T>, T, ValueSize2<T>>,
    IModulusOperators<ValueSize2<T>, ValueSize2<T>, ValueSize2<T>>,
    IModulusOperators2<IVector2<T>, ValueSize2<T>, IVector2<T>>
    where T : INumber<T>
{
    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="ValueSize2{T}"/> class.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public ValueSize2() : this(T.Zero, T.Zero) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueSize2{T}"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public ValueSize2(IVector2<T> value) => (Width, Height) = value;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueSize2{T}"/> class.
    /// </summary>
    /// <param name="tuple">The tuple.</param>
    public ValueSize2((T Width, T Height) tuple) => (Width, Height) = tuple;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueSize2{T}"/> class.
    /// </summary>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    public ValueSize2(T width, T height) => (Width, Height) = (width, height);
    #endregion

    #region Deconstructors
    /// <summary>
    /// Deconstructs the.
    /// </summary>
    /// <param name="Width">The width.</param>
    /// <param name="Height">The height.</param>
    public void Deconstruct(out T Width, out T Height) => (Width, Height) = this;
    #endregion

    #region Properties
    /// <summary>
    /// Gets or sets the width.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T Width { get; set; }

    /// <summary>
    /// Gets or sets the height.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T Height { get; set; }

    /// <summary>
    /// Gets or sets the items.
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    public T[] Items { get { return new T[] { Width, Height }; } set { (Width, Height) = (value[0], value[1]); } }

    /// <summary>
    /// Gets the count.
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public int Count => 2;

    /// <summary>
    /// Gets the additive identity.
    /// </summary>
    public static ValueSize2<T> AdditiveIdentity => new(T.Zero, T.Zero);

    /// <summary>
    /// Gets the multiplicative identity.
    /// </summary>
    public static ValueSize2<T> MultiplicativeIdentity => new(T.One, T.One);
    #endregion

    #region Operators
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator <(ValueSize2<T> left, IVector2<T> right)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator <=(ValueSize2<T> left, IVector2<T> right)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(ValueSize2<T> left, IVector2<T> right) => left.Equals(right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(ValueSize2<T> left, ValueSize2<T> right) => left.Equals(right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(ValueSize2<T> left, IVector2<T> right) => !(left == right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(ValueSize2<T> left, ValueSize2<T> right) => !(left == right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator >(ValueSize2<T> left, IVector2<T> right)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator >=(ValueSize2<T> left, IVector2<T> right)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueSize2<T> operator ++(ValueSize2<T> value) => new(++value.Width, ++value.Height);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueSize2<T> operator checked ++(ValueSize2<T> value) => new(++value.Width, ++value.Height);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueSize2<T> operator +(ValueSize2<T> value) => value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize2<T> operator +(ValueSize2<T> left, IVector2<T> right) => new(left.Width + right.X, left.Height + right.Y);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize2<T> operator checked +(ValueSize2<T> left, IVector2<T> right) => new(left.Width + right.X, left.Height + right.Y);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static IVector2<T> operator +(IVector2<T> left, ValueSize2<T> right) => new ValuePoint2<T>(left.X + right.Width, left.Y + right.Height);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static IVector2<T> operator checked +(IVector2<T> left, ValueSize2<T> right) => new ValuePoint2<T>(left.X + right.Width, left.Y + right.Height);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueSize2<T> operator --(ValueSize2<T> value) => new(--value.Width, --value.Height);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueSize2<T> operator checked --(ValueSize2<T> value) => new(--value.Width, --value.Height);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueSize2<T> operator -(ValueSize2<T> value) => new(-value.Width, -value.Height);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueSize2<T> operator checked -(ValueSize2<T> value) => new(-value.Width, -value.Height);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize2<T> operator -(ValueSize2<T> left, IVector2<T> right) => new(left.Width - right.X, left.Height - right.Y);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize2<T> operator checked -(ValueSize2<T> left, IVector2<T> right) => new(left.Width - right.X, left.Height - right.Y);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static IVector2<T> operator -(IVector2<T> left, ValueSize2<T> right) => new ValuePoint2<T>(left.X - right.Width, left.Y - right.Height);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static IVector2<T> operator checked -(IVector2<T> left, ValueSize2<T> right) => new ValuePoint2<T>(left.X - right.Width, left.Y - right.Height);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize2<T> operator *(ValueSize2<T> left, T right) => new(left.Width * right, left.Height * right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize2<T> operator checked *(ValueSize2<T> left, T right) => new(left.Width * right, left.Height * right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize2<T> operator *(ValueSize2<T> left, ValueSize2<T> right) => new(left.Width * right.Width, left.Height * right.Height);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize2<T> operator checked *(ValueSize2<T> left, ValueSize2<T> right) => new(left.Width * right.Width, left.Height * right.Height);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize2<T> operator *(ValueSize2<T> left, IVector2<T> right) => new(left.Width * right.X, left.Height * right.Y);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize2<T> operator checked *(ValueSize2<T> left, IVector2<T> right) => new(left.Width * right.X, left.Height * right.Y);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static IVector2<T> operator *(IVector2<T> left, ValueSize2<T> right) => new ValuePoint2<T>(left.X * right.Width, left.Y * right.Height);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static IVector2<T> operator checked *(IVector2<T> left, ValueSize2<T> right) => new ValuePoint2<T>(left.X * right.Width, left.Y * right.Height);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize2<T> operator /(ValueSize2<T> left, T right) => new(left.Width / right, left.Height / right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize2<T> operator checked /(ValueSize2<T> left, T right) => new(left.Width / right, left.Height / right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize2<T> operator /(ValueSize2<T> left, ValueSize2<T> right) => new(left.Width / right.Width, left.Height / right.Height);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize2<T> operator checked /(ValueSize2<T> left, ValueSize2<T> right) => new(left.Width / right.Width, left.Height / right.Height);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize2<T> operator /(ValueSize2<T> left, IVector2<T> right) => new(left.Width / right.X, left.Height / right.Y);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize2<T> operator checked /(ValueSize2<T> left, IVector2<T> right) => new(left.Width / right.X, left.Height / right.Y);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static IVector2<T> operator /(IVector2<T> left, ValueSize2<T> right) => new ValuePoint2<T>(left.X / right.Width, left.Y / right.Height);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static IVector2<T> operator checked /(IVector2<T> left, ValueSize2<T> right) => new ValuePoint2<T>(left.X / right.Width, left.Y / right.Height);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize2<T> operator %(ValueSize2<T> left, T right) => new(left.Width % right, left.Height % right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize2<T> operator %(ValueSize2<T> left, ValueSize2<T> right) => new(left.Width % right.Width, left.Height % right.Height);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static IVector2<T> operator %(IVector2<T> left, ValueSize2<T> right) => new ValuePoint2<T>(left.X % right.Width, left.Y % right.Height);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public static implicit operator ValueSize2<T>(ValueVector2<T> value) => new(value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public static implicit operator ValueSize2<T>(ValuePoint2<T> value) => new(value);
    #endregion

    /// <summary>
    /// Gets the hash code.
    /// </summary>
    /// <returns>An int.</returns>
    public override int GetHashCode() => HashCode.Combine(Width, Height);

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
    public override bool Equals(object? obj) => obj is ValueSize2<T> size && Equals(size);

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>A bool.</returns>
    public bool Equals(ValueSize2<T> other) => Width.Equals(other.Width) && Height.Equals(other.Height);

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>A bool.</returns>
    public bool Equals(IVector2<T>? other) => other is IVector2<T> size && Width.Equals(size.X) && Height.Equals(size.Y);

    /// <summary>
    /// Parses the.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="provider">The provider.</param>
    /// <returns>A ValueSize2.</returns>
    public static ValueSize2<T> Parse(string s, IFormatProvider? provider)
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
    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out ValueSize2<T> result)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Parses the.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="provider">The provider.</param>
    /// <returns>A ValueSize2.</returns>
    public static ValueSize2<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
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
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out ValueSize2<T> result)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Tos the string.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="formatProvider">The format provider.</param>
    /// <returns>A string.</returns>
    public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(ValueSize2<T>)}: ({nameof(Width)}: {Width.ToString(format, formatProvider)}, {nameof(Height)}: {Height.ToString(format, formatProvider)})";

    /// <summary>
    /// Gets the debugger display.
    /// </summary>
    /// <returns>A string? .</returns>
    private string? GetDebuggerDisplay() => ToString();
}
