// <copyright file="ValuePoint4.cs" company="Shkyrockett" >
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
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace GenericMathPlayground.Geometry;

/// <summary>
/// The value point4.
/// </summary>
/// <typeparam name="T"></typeparam>
[TypeConverter(typeof(ExpandableObjectConverter))]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public struct ValuePoint4<T>
    : IPoint4<T>,
    IFormattable,
    IParsable<ValuePoint4<T>>,
    ISpanParsable<ValuePoint4<T>>,
    IComparable,
    IComparable<IVector4<T>>,
    IEquatable<IVector4<T>>,
    IAdditiveIdentity<ValuePoint4<T>, ValuePoint4<T>>,
    IMultiplicativeIdentity<ValuePoint4<T>, ValuePoint4<T>>,
    IComparisonOperators<ValuePoint4<T>, IVector4<T>>,
    IEqualityOperators<ValuePoint4<T>, IVector4<T>>,
    IIncrementOperators<ValuePoint4<T>>,
    IUnaryPlusOperators<ValuePoint4<T>, ValuePoint4<T>>,
    IAdditionOperators<ValuePoint4<T>, IVector4<T>, ValuePoint4<T>>,
    IDecrementOperators<ValuePoint4<T>>,
    IUnaryNegationOperators<ValuePoint4<T>, ValuePoint4<T>>,
    ISubtractionOperators<ValuePoint4<T>, IVector4<T>, ValuePoint4<T>>,
    IMultiplyOperators<ValuePoint4<T>, T, ValuePoint4<T>>,
    IDivisionOperators<ValuePoint4<T>, T, ValuePoint4<T>>,
    IModulusOperators<ValuePoint4<T>, T, ValuePoint4<T>>
    where T : INumber<T>
{
    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="ValuePoint4{T}"/> class.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public ValuePoint4() : this(T.Zero, T.Zero, T.Zero, T.Zero) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValuePoint4{T}"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public ValuePoint4(IVector4<T> value) => (X, Y, Z, W) = value;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValuePoint4{T}"/> class.
    /// </summary>
    /// <param name="tuple">The tuple.</param>
    public ValuePoint4((T X, T Y, T Z, T W) tuple) => (X, Y, Z, W) = tuple;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValuePoint4{T}"/> class.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <param name="z">The z.</param>
    /// <param name="w">The w.</param>
    public ValuePoint4(T x, T y, T z, T w) => (X, Y, Z, W) = (x, y, z, w);
    #endregion

    #region Deconstructors
    /// <summary>
    /// Deconstructs the.
    /// </summary>
    /// <param name="X">The x.</param>
    /// <param name="Y">The y.</param>
    /// <param name="Z">The z.</param>
    /// <param name="W">The w.</param>
    public void Deconstruct(out T X, out T Y, out T Z, out T W) => (X, Y, Z, W) = (this.X, this.Y, this.Z, this.W);
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
    /// Gets or sets the z.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T Z { get; set; }

    /// <summary>
    /// Gets or sets the w.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T W { get; set; }

    /// <summary>
    /// Gets or sets the items.
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    public T[] Items { get { return new T[] { X, Y, Z, W }; } set { (X, Y, Z, W) = (value[0], value[1], value[2], value[3]); } }

    /// <summary>
    /// Gets the count.
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public int Count => 4;

    /// <summary>
    /// Gets the additive identity.
    /// </summary>
    public static ValuePoint4<T> AdditiveIdentity => new(T.Zero, T.Zero, T.Zero, T.Zero);

    /// <summary>
    /// Gets the multiplicative identity.
    /// </summary>
    public static ValuePoint4<T> MultiplicativeIdentity => new(T.One, T.One, T.One, T.One);
    #endregion

    #region Operators
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator <(ValuePoint4<T> left, IVector4<T> right)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator <=(ValuePoint4<T> left, IVector4<T> right)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(ValuePoint4<T> left, IVector4<T> right) => left.Equals(right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(ValuePoint4<T> left, ValuePoint4<T> right) => left.Equals(right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(ValuePoint4<T> left, IVector4<T> right) => !(left == right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(ValuePoint4<T> left, ValuePoint4<T> right) => !(left == right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator >(ValuePoint4<T> left, IVector4<T> right)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator >=(ValuePoint4<T> left, IVector4<T> right)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValuePoint4<T> operator ++(ValuePoint4<T> value) => new(++value.X, ++value.Y, ++value.Z, ++value.W);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValuePoint4<T> operator checked ++(ValuePoint4<T> value) => new(++value.X, ++value.Y, ++value.Z, ++value.W);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValuePoint4<T> operator +(ValuePoint4<T> value) => value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValuePoint4<T> operator +(ValuePoint4<T> left, IVector4<T> right) => new(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValuePoint4<T> operator checked +(ValuePoint4<T> left, IVector4<T> right) => new(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValuePoint4<T> operator --(ValuePoint4<T> value) => new(--value.X, --value.Y, --value.Z, --value.W);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValuePoint4<T> operator checked --(ValuePoint4<T> value) => new(--value.X, --value.Y, --value.Z, --value.W);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValuePoint4<T> operator -(ValuePoint4<T> value) => new(-value.X, -value.Y, -value.Z, -value.W);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValuePoint4<T> operator checked -(ValuePoint4<T> value) => new(-value.X, -value.Y, -value.Z, -value.W);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValuePoint4<T> operator -(ValuePoint4<T> left, IVector4<T> right) => new(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValuePoint4<T> operator checked -(ValuePoint4<T> left, IVector4<T> right) => new(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValuePoint4<T> operator *(ValuePoint4<T> left, T right) => new(left.X * right, left.Y * right, left.Z * right, left.W * right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValuePoint4<T> operator checked *(ValuePoint4<T> left, T right) => new(left.X * right, left.Y * right, left.Z * right, left.W * right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValuePoint4<T> operator /(ValuePoint4<T> left, T right) => new(left.X / right, left.Y / right, left.Z / right, left.W / right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValuePoint4<T> operator checked /(ValuePoint4<T> left, T right) => new(left.X / right, left.Y / right, left.Z / right, left.W / right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValuePoint4<T> operator %(ValuePoint4<T> left, T right) => new(left.X % right, left.Y % right, left.Z % right, left.W % right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public static implicit operator ValuePoint4<T>(ValueVector3<T> value) => value;
    #endregion

    /// <summary>
    /// Gets the hash code.
    /// </summary>
    /// <returns>An int.</returns>
    public override int GetHashCode() => HashCode.Combine(X, Y, Z, W);

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
    public int CompareTo(IVector4<T>? other)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="obj">The obj.</param>
    /// <returns>A bool.</returns>
    public override bool Equals(object? obj) => obj is ValuePoint4<T> point && Equals(point);

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>A bool.</returns>
    public bool Equals(ValuePoint4<T> other) => X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z) && W.Equals(other.W);

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>A bool.</returns>
    public bool Equals(IVector4<T>? other) => other is IVector4<T> vector && X.Equals(vector.X) && Y.Equals(vector.Y) && Z.Equals(vector.Z) && W.Equals(vector.W);

    /// <summary>
    /// Parses the.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="provider">The provider.</param>
    /// <returns>A ValuePoint4.</returns>
    public static ValuePoint4<T> Parse(string s, IFormatProvider? provider)
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
    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out ValuePoint4<T> result)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Parses the.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="provider">The provider.</param>
    /// <returns>A ValuePoint4.</returns>
    public static ValuePoint4<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
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
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out ValuePoint4<T> result)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Tos the string.
    /// </summary>
    /// <returns>A string? .</returns>
    public override string? ToString() => ToString("R", CultureInfo.InvariantCulture);

    /// <summary>
    /// Tos the string.
    /// </summary>
    /// <param name="formatProvider">The format provider.</param>
    /// <returns>A string.</returns>
    public string ToString(IFormatProvider formatProvider) => ToString("R", formatProvider);

    /// <summary>
    /// Tos the string.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="formatProvider">The format provider.</param>
    /// <returns>A string.</returns>
    public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(ValuePoint4<T>)}: ({nameof(X)}: {X.ToString(format, formatProvider)}, {nameof(Y)}: {Y.ToString(format, formatProvider)}, {nameof(Z)}: {Z.ToString(format, formatProvider)}, {nameof(W)}: {W.ToString(format, formatProvider)})";

    /// <summary>
    /// Gets the debugger display.
    /// </summary>
    /// <returns>A string? .</returns>
    private string? GetDebuggerDisplay() => ToString();
}
