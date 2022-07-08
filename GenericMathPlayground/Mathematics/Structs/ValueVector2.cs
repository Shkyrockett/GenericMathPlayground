// <copyright file="ValueVector2.cs" company="Shkyrockett" >
//     Copyright © 2021 - 2022 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace GenericMathPlayground.Mathematics;

/// <summary>
/// The value vector2.
/// </summary>
/// <typeparam name="T"></typeparam>
[TypeConverter(typeof(ExpandableObjectConverter))]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public struct ValueVector2<T>
    : IVector2<T>,
    IFormattable,
    IParsable<ValueVector2<T>>,
    ISpanParsable<ValueVector2<T>>,
    IEquatable<IVector2<T>>,
    IAdditiveIdentity<ValueVector2<T>, ValueVector2<T>>,
    IMultiplicativeIdentity<ValueVector2<T>, ValueVector2<T>>,
    IEqualityOperators<ValueVector2<T>, IVector2<T>>,
    IEqualityOperators<ValueVector2<T>, ValueVector2<T>>,
    IUnaryPlusOperators<ValueVector2<T>, ValueVector2<T>>,
    IAdditionOperators<ValueVector2<T>, IVector2<T>, ValueVector2<T>>,
    IUnaryNegationOperators<ValueVector2<T>, ValueVector2<T>>,
    ISubtractionOperators<ValueVector2<T>, IVector2<T>, ValueVector2<T>>,
    IMultiplyOperators<ValueVector2<T>, T, ValueVector2<T>>,
    IMultiplyOperators2<T, ValueVector2<T>, ValueVector2<T>>
    where T : INumber<T>
{
    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="ValueVector2{T}"/> class.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public ValueVector2() : this(T.Zero, T.Zero) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueVector2{T}"/> class.
    /// </summary>
    /// <param name="vector">The vector.</param>
    public ValueVector2(IVector2<T> vector) => (I, J) = vector;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueVector2{T}"/> class.
    /// </summary>
    /// <param name="tuple">The tuple.</param>
    public ValueVector2((T I, T J) tuple) => (I, J) = tuple;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueVector2{T}"/> class.
    /// </summary>
    /// <param name="i">The i.</param>
    /// <param name="j">The j.</param>
    public ValueVector2(T i, T j) => (I, J) = (i, j);
    #endregion

    #region Deconstructors
    /// <summary>
    /// Deconstructs the.
    /// </summary>
    /// <param name="I">The i.</param>
    /// <param name="J">The j.</param>
    public void Deconstruct(out T I, out T J) => (I, J) = (this.I, this.J);
    #endregion

    #region Properties
    /// <summary>
    /// Gets or sets the i.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T I { get; set; }

    /// <summary>
    /// Gets or sets the j.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T J { get; set; }

    /// <summary>
    /// Gets or sets the x.
    /// </summary>
    T IVector2<T>.X { get { return I; } set { I = value; } }

    /// <summary>
    /// Gets or sets the y.
    /// </summary>
    T IVector2<T>.Y { get { return J; } set { J = value; } }

    /// <summary>
    /// Gets or sets the items.
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public T[] Items { get { return new T[] { I, J }; } set { (I, J) = (value[0], value[1]); } }

    /// <summary>
    /// Gets the count.
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public int Count => 2;

    /// <summary>
    /// Gets the additive identity.
    /// </summary>
    public static ValueVector2<T> AdditiveIdentity => new(T.Zero, T.Zero);

    /// <summary>
    /// Gets the multiplicative identity.
    /// </summary>
    public static ValueVector2<T> MultiplicativeIdentity => new(T.One, T.One);
    #endregion

    #region Operators
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(ValueVector2<T> left, IVector2<T> right) => left.Equals(right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(ValueVector2<T> left, ValueVector2<T> right) => left.Equals(right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(ValueVector2<T> left, IVector2<T> right) => !(left == right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(ValueVector2<T> left, ValueVector2<T> right) => !(left == right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueVector2<T> operator +(ValueVector2<T> value) => value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector2<T> operator +(ValueVector2<T> left, IVector2<T> right) => new(Operations.AddVectors(left.I, left.J, right.X, right.Y));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector2<T> operator checked +(ValueVector2<T> left, IVector2<T> right) => new(Operations.AddVectors(left.I, left.J, right.X, right.Y));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueVector2<T> operator -(ValueVector2<T> value) => new(Operations.NegateVector(value.I, value.J));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueVector2<T> operator checked -(ValueVector2<T> value) => new(Operations.NegateVector(value.I, value.J));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector2<T> operator -(ValueVector2<T> left, IVector2<T> right) => new(Operations.SubtractVector(left.I, left.J, right.X, right.Y));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector2<T> operator checked -(ValueVector2<T> left, IVector2<T> right) => new(Operations.SubtractVector(left.I, left.J, right.X, right.Y));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector2<T> operator *(ValueVector2<T> left, T right) => new(Operations.ScaleVector(left.I, left.J, right));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector2<T> operator checked *(ValueVector2<T> left, T right) => new(Operations.ScaleVector(left.I, left.J, right));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector2<T> operator *(T left, ValueVector2<T> right) => new(Operations.ScaleVector(right.I, right.J, left));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector2<T> operator checked *(T left, ValueVector2<T> right) => new(Operations.ScaleVector(right.I, right.J, left));
    #endregion

    /// <summary>
    /// Crosses the product.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>A T.</returns>
    public T CrossProduct(ValueVector2<T> other) => Operations.CrossProduct(I, J, other.I, other.J);

    /// <summary>
    /// Gets the hash code.
    /// </summary>
    /// <returns>An int.</returns>
    public override int GetHashCode() => HashCode.Combine(I, J);

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="obj">The obj.</param>
    /// <returns>A bool.</returns>
    public override bool Equals(object? obj) => obj is ValueVector2<T> point && Equals(point);

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>A bool.</returns>
    public bool Equals(IVector2<T>? other) => other is IVector2<T> vector && I.Equals(vector.X) && J.Equals(vector.Y);

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>A bool.</returns>
    public bool Equals(ValueVector2<T> other) => I.Equals(other.I) && J.Equals(other.J);

    /// <summary>
    /// Parse a string for a <see cref="ValueVector2{T}" /> value.
    /// </summary>
    /// <param name="source">The source string.</param>
    /// <param name="formatProvider">The format provider.</param>
    /// <returns>A ValueVector2.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static ValueVector2<T> Parse(string source, IFormatProvider? formatProvider) => Parse((ReadOnlySpan<char>)source, formatProvider);

    /// <summary>
    /// Parse a string for a <see cref="ValueVector2{T}" /> value.
    /// </summary>
    /// <param name="source">The s.</param>
    /// <param name="formatProvider">The format provider.</param>
    /// <returns>A ValueVector2.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static ValueVector2<T> Parse(ReadOnlySpan<char> source, IFormatProvider? formatProvider) => TryParse(source, formatProvider, out var result) ? result : result;

    /// <summary>
    /// Tries the parse.
    /// </summary>
    /// <param name="source">The s.</param>
    /// <param name="formatProvider">The provider.</param>
    /// <param name="result">The result.</param>
    /// <returns>A bool.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool TryParse([NotNullWhen(true)] string? source, IFormatProvider? formatProvider, out ValueVector2<T> result) => TryParse((ReadOnlySpan<char>)source, formatProvider, out result);

    /// <summary>
    /// Tries the parse.
    /// </summary>
    /// <param name="source">The s.</param>
    /// <param name="formatProvider">The provider.</param>
    /// <param name="result">The result.</param>
    /// <returns>A bool.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool TryParse(ReadOnlySpan<char> source, IFormatProvider? formatProvider, out ValueVector2<T> result)
    {
        var tokenizer = new Tokenizer(source, formatProvider);
        var firstToken = tokenizer.NextTokenRequired();

        T.TryParse(firstToken, formatProvider, out var result1);
        T.TryParse(tokenizer.NextTokenRequired(), formatProvider, out var result2);
        var value = new ValueVector2<T>(result1, result2);

        // There should be no more tokens in this string.
        tokenizer.LastTokenRequired();
        result = value;
        return true;
    }

    /// <summary>
    /// Creates a human-readable string that represents this <see cref="ValueVector2{T}" /> struct.
    /// </summary>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public override string? ToString() => ToString("R", CultureInfo.InvariantCulture);

    /// <summary>
    /// Creates a string representation of this <see cref="ValueVector2{T}" /> struct based on the IFormatProvider
    /// passed in.  If the provider is null, the CurrentCulture is used.
    /// </summary>
    /// <param name="formatProvider">The format provider.</param>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public string ToString(IFormatProvider formatProvider) => ToString("R", formatProvider);

    /// <summary>
    /// Creates a string representation of this <see cref="ValueVector2{T}" /> struct based on the IFormatProvider
    /// passed in.  If the provider is null, the CurrentCulture is used.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="formatProvider">The format provider.</param>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(ValueVector2<T>)}: ({nameof(I)}: {I.ToString(format, formatProvider)}, {nameof(J)}: {J.ToString(format, formatProvider)})";

    /// <summary>
    /// Gets the debugger display.
    /// </summary>
    /// <returns>
    /// A string representation of this object for display in the debugger.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private string? GetDebuggerDisplay() => ToString();
}
