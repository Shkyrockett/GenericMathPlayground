// <copyright file="ValuePoint3.cs" company="Shkyrockett" >
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
/// The value point3.
/// </summary>
/// <typeparam name="T"></typeparam>
[TypeConverter(typeof(ExpandableObjectConverter))]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public struct ValuePoint3<T>
    : IPoint3<T>,
    IFormattable,
    IParsable<ValuePoint3<T>>,
    ISpanParsable<ValuePoint3<T>>,
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
    /// Initializes a new instance of the <see cref="ValuePoint3{T}"/> class.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public ValuePoint3() : this(T.Zero, T.Zero, T.Zero) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValuePoint3{T}"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public ValuePoint3(IVector3<T> value) => (X, Y, Z) = value;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValuePoint3{T}"/> class.
    /// </summary>
    /// <param name="tuple">The tuple.</param>
    public ValuePoint3((T X, T Y, T Z) tuple) => (X, Y, Z) = tuple;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValuePoint3{T}"/> class.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <param name="z">The z.</param>
    public ValuePoint3(T x, T y, T z) => (X, Y, Z) = (x, y, z);
    #endregion

    #region Deconstructors
    /// <summary>
    /// Deconstructs the.
    /// </summary>
    /// <param name="X">The x.</param>
    /// <param name="Y">The y.</param>
    /// <param name="Z">The z.</param>
    public void Deconstruct(out T X, out T Y, out T Z) => (X, Y, Z) = (this.X, this.Y, this.Z);
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
    /// Gets or sets the items.
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    public T[] Items { get { return new T[] { X, Y, Z }; } set { (X, Y, Z) = (value[0], value[1], value[2]); } }

    /// <summary>
    /// Gets the count.
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public int Count => 3;

    /// <summary>
    /// Gets the additive identity.
    /// </summary>
    public static ValuePoint3<T> AdditiveIdentity => new(T.Zero, T.Zero, T.Zero);

    /// <summary>
    /// Gets the multiplicative identity.
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
    public static ValuePoint3<T> operator checked ++(ValuePoint3<T> value) => new(++value.X, ++value.Y, ++value.Z);

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
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValuePoint3<T> operator checked +(ValuePoint3<T> left, IVector3<T> right) => new(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

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
    public static ValuePoint3<T> operator checked --(ValuePoint3<T> value) => new(--value.X, --value.Y, --value.Z);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValuePoint3<T> operator -(ValuePoint3<T> value) => new(-value.X, -value.Y, -value.Z);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValuePoint3<T> operator checked -(ValuePoint3<T> value) => new(-value.X, -value.Y, -value.Z);

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
    public static ValuePoint3<T> operator checked -(ValuePoint3<T> left, IVector3<T> right) => new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

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
    public static ValuePoint3<T> operator checked *(ValuePoint3<T> left, T right) => new(left.X * right, left.Y * right, left.Z * right);

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
    public static ValuePoint3<T> operator checked *(ValuePoint3<T> left, ValueSize3<T> right) => new(left.X * right.Width, left.Y * right.Height, left.Z * right.Depth);

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
    public static ValuePoint3<T> operator checked /(ValuePoint3<T> left, T right) => new(left.X / right, left.Y / right, left.Z / right);

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
    public static ValuePoint3<T> operator checked /(ValuePoint3<T> left, ValueSize3<T> right) => new(left.X / right.Width, left.Y / right.Height, left.Z / right.Depth);

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
    /// Gets the hash code.
    /// </summary>
    /// <returns>An int.</returns>
    public override int GetHashCode() => HashCode.Combine(X, Y, Z);

    /// <summary>
    /// Compares the to.
    /// </summary>
    /// <param name="obj">The obj.</param>
    /// <returns>An int.</returns>
    public int CompareTo(object? obj) => throw new NotImplementedException();

    /// <summary>
    /// Compares the to.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>An int.</returns>
    public int CompareTo(IVector3<T>? other) => throw new NotImplementedException();

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="obj">The obj.</param>
    /// <returns>A bool.</returns>
    public override bool Equals(object? obj) => obj is ValuePoint3<T> point && Equals(point);

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>A bool.</returns>
    public bool Equals(ValuePoint3<T> other) => X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>A bool.</returns>
    public bool Equals(IVector3<T>? other) => other is IVector3<T> vector && X.Equals(vector.X) && Y.Equals(vector.Y) && Z.Equals(vector.Z);

    /// <summary>
    /// Parses the.
    /// </summary>
    /// <param name="source">The s.</param>
    /// <param name="formatProvider">The provider.</param>
    /// <returns>A ValuePoint3.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static ValuePoint3<T> Parse(string source, IFormatProvider? formatProvider) => Parse((ReadOnlySpan<char>)source, formatProvider);

    /// <summary>
    /// Parses the.
    /// </summary>
    /// <param name="source">The s.</param>
    /// <param name="formatProvider">The provider.</param>
    /// <returns>A ValuePoint3.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static ValuePoint3<T> Parse(ReadOnlySpan<char> source, IFormatProvider? formatProvider) => TryParse(source, formatProvider, out var result) ? result : result;

    /// <summary>
    /// Tries the parse.
    /// </summary>
    /// <param name="source">The s.</param>
    /// <param name="formatProvider">The provider.</param>
    /// <param name="result">The result.</param>
    /// <returns>A bool.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool TryParse([NotNullWhen(true)] string? source, IFormatProvider? formatProvider, out ValuePoint3<T> result) => TryParse((ReadOnlySpan<char>)source, formatProvider, out result);

    /// <summary>
    /// Tries the parse.
    /// </summary>
    /// <param name="source">The s.</param>
    /// <param name="formatProvider">The provider.</param>
    /// <param name="result">The result.</param>
    /// <returns>A bool.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool TryParse(ReadOnlySpan<char> source, IFormatProvider? formatProvider, out ValuePoint3<T> result)
    {
        var tokenizer = new Tokenizer(source, formatProvider);
        var firstToken = tokenizer.NextTokenRequired();

        T.TryParse(firstToken, formatProvider, out var result1);
        T.TryParse(tokenizer.NextTokenRequired(), formatProvider, out var result2);
        T.TryParse(tokenizer.NextTokenRequired(), formatProvider, out var result3);
        var value = new ValuePoint3<T>(result1, result2, result3);

        // There should be no more tokens in this string.
        tokenizer.LastTokenRequired();
        result = value;
        return true;
    }

    /// <summary>
    /// Creates a human-readable string that represents this <see cref="ValuePoint3{T}" /> struct.
    /// </summary>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public override string? ToString() => ToString("R", CultureInfo.InvariantCulture);

    /// <summary>
    /// Creates a string representation of this <see cref="ValuePoint3{T}" /> struct based on the IFormatProvider
    /// passed in.  If the provider is null, the CurrentCulture is used.
    /// </summary>
    /// <param name="formatProvider">The format provider.</param>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public string ToString(IFormatProvider formatProvider) => ToString("R", formatProvider);

    /// <summary>
    /// Creates a string representation of this <see cref="ValuePoint3{T}" /> struct based on the IFormatProvider
    /// passed in.  If the provider is null, the CurrentCulture is used.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="formatProvider">The format provider.</param>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(ValuePoint3<T>)}: ({nameof(X)}: {X.ToString(format, formatProvider)}, {nameof(Y)}: {Y.ToString(format, formatProvider)}, {nameof(Z)}: {Z.ToString(format, formatProvider)})";

    /// <summary>
    /// Gets the debugger display.
    /// </summary>
    /// <returns>
    /// A string representation of this object for display in the debugger.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private string? GetDebuggerDisplay() => ToString();
}
