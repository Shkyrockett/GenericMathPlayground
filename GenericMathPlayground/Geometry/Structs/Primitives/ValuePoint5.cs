// <copyright file="ValuePoint5.cs" company="Shkyrockett" >
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
/// The value point5.
/// </summary>
/// <typeparam name="T"></typeparam>
[TypeConverter(typeof(ExpandableObjectConverter))]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public struct ValuePoint5<T>
    : IPoint5<T>,
    IFormattable,
    IParsable<ValuePoint5<T>>,
    ISpanParsable<ValuePoint5<T>>,
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
    /// Initializes a new instance of the <see cref="ValuePoint5{T}"/> class.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public ValuePoint5() : this(T.Zero, T.Zero, T.Zero, T.Zero, T.Zero) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValuePoint5{T}"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public ValuePoint5(IVector5<T> value) => (X, Y, Z, W, V) = value;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValuePoint5{T}"/> class.
    /// </summary>
    /// <param name="tuple">The tuple.</param>
    public ValuePoint5((T X, T Y, T Z, T W, T V) tuple) => (X, Y, Z, W, V) = tuple;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValuePoint5{T}"/> class.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <param name="z">The z.</param>
    /// <param name="w">The w.</param>
    /// <param name="v">The v.</param>
    public ValuePoint5(T x, T y, T z, T w, T v) => (X, Y, Z, W, V) = (x, y, z, w, v);
    #endregion

    #region Deconstructors
    /// <summary>
    /// Deconstructs the.
    /// </summary>
    /// <param name="X">The x.</param>
    /// <param name="Y">The y.</param>
    /// <param name="Z">The z.</param>
    /// <param name="W">The w.</param>
    /// <param name="V">The v.</param>
    public void Deconstruct(out T X, out T Y, out T Z, out T W, out T V) => (X, Y, Z, W, V) = (this.X, this.Y, this.Z, this.W, this.V);
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
    /// Gets or sets the v.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T V { get; set; }

    /// <summary>
    /// Gets or sets the items.
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    public T[] Items { get { return new T[] { X, Y, Z, W, V }; } set { (X, Y, Z, W, V) = (value[0], value[1], value[2], value[3], value[4]); } }

    /// <summary>
    /// Gets the count.
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public int Count => 5;

    /// <summary>
    /// Gets the additive identity.
    /// </summary>
    public static ValuePoint5<T> AdditiveIdentity => new(T.Zero, T.Zero, T.Zero, T.Zero, T.Zero);

    /// <summary>
    /// Gets the multiplicative identity.
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
    /// <exception cref="NotImplementedException"></exception>
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
    /// <exception cref="NotImplementedException"></exception>
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
    /// <exception cref="NotImplementedException"></exception>
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
    /// <exception cref="NotImplementedException"></exception>
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
    public static ValuePoint5<T> operator checked ++(ValuePoint5<T> value) => new(++value.X, ++value.Y, ++value.Z, ++value.W, ++value.V);

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
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValuePoint5<T> operator checked +(ValuePoint5<T> left, IVector5<T> right) => new(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W, left.V + right.V);

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
    public static ValuePoint5<T> operator checked --(ValuePoint5<T> value) => new(--value.X, --value.Y, --value.Z, --value.W, --value.V);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValuePoint5<T> operator -(ValuePoint5<T> value) => new(-value.X, -value.Y, -value.Z, -value.W, -value.V);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValuePoint5<T> operator checked -(ValuePoint5<T> value) => new(-value.X, -value.Y, -value.Z, -value.W, -value.V);

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
    public static ValuePoint5<T> operator checked -(ValuePoint5<T> left, IVector5<T> right) => new(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W, left.V - right.V);

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
    public static ValuePoint5<T> operator checked *(ValuePoint5<T> left, T right) => new(left.X * right, left.Y * right, left.Z * right, left.W * right, left.V * right);

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
    public static ValuePoint5<T> operator checked /(ValuePoint5<T> left, T right) => new(left.X / right, left.Y / right, left.Z / right, left.W / right, left.V / right);

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
    /// Gets the hash code.
    /// </summary>
    /// <returns>An int.</returns>
    public override int GetHashCode() => HashCode.Combine(X, Y, Z, W, V);

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
    public int CompareTo(IVector5<T>? other) => throw new NotImplementedException();

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="obj">The obj.</param>
    /// <returns>A bool.</returns>
    public override bool Equals(object? obj) => obj is ValuePoint5<T> point && Equals(point);

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>A bool.</returns>
    public bool Equals(ValuePoint5<T> other) => X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z) && W.Equals(other.W) && V.Equals(other.V);

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>A bool.</returns>
    public bool Equals(IVector5<T>? other) => other is IVector5<T> vector && X.Equals(vector.X) && Y.Equals(vector.Y) && Z.Equals(vector.Z) && W.Equals(vector.W) && V.Equals(vector.V);

    /// <summary>
    /// Parses the.
    /// </summary>
    /// <param name="source">The s.</param>
    /// <param name="formatProvider">The provider.</param>
    /// <returns>A ValuePoint5.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static ValuePoint5<T> Parse(string source, IFormatProvider? formatProvider) => Parse((ReadOnlySpan<char>)source, formatProvider);

    /// <summary>
    /// Parses the.
    /// </summary>
    /// <param name="source">The s.</param>
    /// <param name="formatProvider">The provider.</param>
    /// <returns>A ValuePoint5.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static ValuePoint5<T> Parse(ReadOnlySpan<char> source, IFormatProvider? formatProvider) => TryParse(source, formatProvider, out var result) ? result : result;

    /// <summary>
    /// Tries the parse.
    /// </summary>
    /// <param name="source">The s.</param>
    /// <param name="formatProvider">The provider.</param>
    /// <param name="result">The result.</param>
    /// <returns>A bool.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool TryParse([NotNullWhen(true)] string? source, IFormatProvider? formatProvider, out ValuePoint5<T> result) => TryParse((ReadOnlySpan<char>)source, formatProvider, out result);

    /// <summary>
    /// Tries the parse.
    /// </summary>
    /// <param name="source">The s.</param>
    /// <param name="formatProvider">The provider.</param>
    /// <param name="result">The result.</param>
    /// <returns>A bool.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool TryParse(ReadOnlySpan<char> source, IFormatProvider? formatProvider, out ValuePoint5<T> result)
    {
        var tokenizer = new Tokenizer(source, formatProvider);
        var firstToken = tokenizer.NextTokenRequired();

        T.TryParse(firstToken, formatProvider, out var result1);
        T.TryParse(tokenizer.NextTokenRequired(), formatProvider, out var result2);
        T.TryParse(tokenizer.NextTokenRequired(), formatProvider, out var result3);
        T.TryParse(tokenizer.NextTokenRequired(), formatProvider, out var result4);
        T.TryParse(tokenizer.NextTokenRequired(), formatProvider, out var result5);
        var value = new ValuePoint5<T>(result1, result2, result3, result4, result5);

        // There should be no more tokens in this string.
        tokenizer.LastTokenRequired();
        result = value;
        return true;
    }

    /// <summary>
    /// Creates a human-readable string that represents this <see cref="ValuePoint5{T}" /> struct.
    /// </summary>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public override string? ToString() => ToString("R", CultureInfo.InvariantCulture);

    /// <summary>
    /// Creates a string representation of this <see cref="ValuePoint5{T}" /> struct based on the IFormatProvider
    /// passed in.  If the provider is null, the CurrentCulture is used.
    /// </summary>
    /// <param name="formatProvider">The format provider.</param>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public string ToString(IFormatProvider formatProvider) => ToString("R", formatProvider);

    /// <summary>
    /// Creates a string representation of this <see cref="ValuePoint5{T}" /> struct based on the IFormatProvider
    /// passed in.  If the provider is null, the CurrentCulture is used.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="formatProvider">The format provider.</param>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(ValuePoint5<T>)}: ({nameof(X)}: {X.ToString(format, formatProvider)}, {nameof(Y)}: {Y.ToString(format, formatProvider)}, {nameof(Z)}: {Z.ToString(format, formatProvider)}, {nameof(W)}: {W.ToString(format, formatProvider)}, {nameof(V)}: {V.ToString(format, formatProvider)})";

    /// <summary>
    /// Gets the debugger display.
    /// </summary>
    /// <returns>
    /// A string representation of this object for display in the debugger.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private string? GetDebuggerDisplay() => ToString();
}
