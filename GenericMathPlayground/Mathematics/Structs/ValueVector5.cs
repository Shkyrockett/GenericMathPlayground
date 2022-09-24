// <copyright file="ValueVector5.cs" company="Shkyrockett" >
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
/// The value vector5.
/// </summary>
/// <typeparam name="T"></typeparam>
[TypeConverter(typeof(ExpandableObjectConverter))]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public struct ValueVector5<T>
    : IVector5<T>,
    IFormattable,
    IParsable<ValueVector5<T>>,
    ISpanParsable<ValueVector5<T>>,
    IEquatable<IVector5<T>>,
    IAdditiveIdentity<ValueVector5<T>, ValueVector5<T>>,
    IMultiplicativeIdentity<ValueVector5<T>, ValueVector5<T>>,
    IEqualityOperators<ValueVector5<T>, IVector5<T>, bool>,
    IEqualityOperators<ValueVector5<T>, ValueVector5<T>, bool>,
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
    /// Initializes a new instance of the <see cref="ValueVector5{T}"/> class.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public ValueVector5() : this(T.Zero, T.Zero, T.Zero, T.Zero, T.Zero) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueVector5{T}"/> class.
    /// </summary>
    /// <param name="vector">The vector.</param>
    public ValueVector5(IVector5<T> vector) => (I, J, K, L, M) = vector;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueVector5{T}"/> class.
    /// </summary>
    /// <param name="tuple">The tuple.</param>
    public ValueVector5((T I, T J, T K, T L, T M) tuple) => (I, J, K, L, M) = tuple;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueVector5{T}"/> class.
    /// </summary>
    /// <param name="i">The i.</param>
    /// <param name="j">The j.</param>
    /// <param name="k">The k.</param>
    /// <param name="l">The l.</param>
    /// <param name="m">The m.</param>
    public ValueVector5(T i, T j, T k, T l, T m) => (I, J, K, L, M) = (i, j, k, l, m);
    #endregion

    #region Deconstructors
    /// <summary>
    /// Deconstructs the.
    /// </summary>
    /// <param name="I">The i.</param>
    /// <param name="J">The j.</param>
    /// <param name="K">The k.</param>
    /// <param name="L">The l.</param>
    /// <param name="M">The m.</param>
    public void Deconstruct(out T I, out T J, out T K, out T L, out T M) => (I, J, K, L, M) = (this.I, this.J, this.K, this.L, this.M);
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
    /// Gets or sets the k.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T K { get; set; }

    /// <summary>
    /// Gets or sets the l.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T L { get; set; }

    /// <summary>
    /// Gets or sets the m.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M { get; set; }

    /// <summary>
    /// Gets or sets the x.
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    T IVector2<T>.X { get { return I; } set { I = value; } }

    /// <summary>
    /// Gets or sets the y.
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    T IVector2<T>.Y { get { return J; } set { J = value; } }

    /// <summary>
    /// Gets or sets the z.
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    T IVector3<T>.Z { get { return K; } set { K = value; } }

    /// <summary>
    /// Gets or sets the w.
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    T IVector4<T>.W { get { return L; } set { L = value; } }

    /// <summary>
    /// Gets or sets the v.
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    T IVector5<T>.V { get { return M; } set { M = value; } }

    /// <summary>
    /// Gets or sets the items.
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public T[] Items { get { return new T[] { I, J, K, L, M }; } set { (I, J, K, L, M) = (value[0], value[1], value[2], value[3], value[4]); } }

    /// <summary>
    /// Gets the count.
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public int Count => 5;

    /// <summary>
    /// Gets the additive identity.
    /// </summary>
    public static ValueVector5<T> AdditiveIdentity => new(T.Zero, T.Zero, T.Zero, T.Zero, T.Zero);

    /// <summary>
    /// Gets the multiplicative identity.
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
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector5<T> operator checked +(ValueVector5<T> left, IVector5<T> right) => new(Operations.AddVectors(left.I, left.J, left.K, left.L, left.M, right.X, right.Y, right.Z, right.W, right.V));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueVector5<T> operator -(ValueVector5<T> value) => new(Operations.NegateVector(value.I, value.J, value.K, value.L, value.M));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueVector5<T> operator checked -(ValueVector5<T> value) => new(Operations.NegateVector(value.I, value.J, value.K, value.L, value.M));

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
    public static ValueVector5<T> operator checked -(ValueVector5<T> left, IVector5<T> right) => new(Operations.SubtractVector(left.I, left.J, left.K, left.L, left.M, right.X, right.Y, right.Z, right.W, right.V));

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
    public static ValueVector5<T> operator checked *(ValueVector5<T> left, T right) => new(Operations.ScaleVector(left.I, left.J, left.K, left.L, left.M, right));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector5<T> operator *(T left, ValueVector5<T> right) => new(Operations.ScaleVector(right.I, right.J, right.K, right.L, right.M, left));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector5<T> operator checked *(T left, ValueVector5<T> right) => new(Operations.ScaleVector(right.I, right.J, right.K, right.L, right.M, left));
    #endregion

    /// <summary>
    /// Gets the hash code.
    /// </summary>
    /// <returns>An int.</returns>
    public override int GetHashCode() => HashCode.Combine(I, J, K, L, M);

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="obj">The obj.</param>
    /// <returns>A bool.</returns>
    public override bool Equals(object? obj) => obj is ValueVector5<T> point && Equals(point);

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>A bool.</returns>
    public bool Equals(IVector5<T>? other) => other is IVector5<T> vector && I.Equals(vector.X) && J.Equals(vector.Y) && K.Equals(vector.Z) && L.Equals(vector.W) && M.Equals(vector.V);

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>A bool.</returns>
    public bool Equals(ValueVector5<T> other) => I.Equals(other.I) && J.Equals(other.J) && K.Equals(other.K) && L.Equals(other.L) && M.Equals(other.M);

    /// <summary>
    /// Parse a string for a <see cref="ValueVector5{T}" /> value.
    /// </summary>
    /// <param name="source">The source string.</param>
    /// <param name="formatProvider">The format provider.</param>
    /// <returns>A ValueVector5.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static ValueVector5<T> Parse(string source, IFormatProvider? formatProvider) => Parse((ReadOnlySpan<char>)source, formatProvider);

    /// <summary>
    /// Parse a string for a <see cref="ValueVector5{T}" /> value.
    /// </summary>
    /// <param name="source">The source string.</param>
    /// <param name="formatProvider">The format provider.</param>
    /// <returns>A ValueVector5.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static ValueVector5<T> Parse(ReadOnlySpan<char> source, IFormatProvider? formatProvider) => TryParse(source, formatProvider, out var result) ? result : result;

    /// <summary>
    /// Try Parse a string for a <see cref="ValueVector5{T}" /> value.
    /// </summary>
    /// <param name="source">The source string.</param>
    /// <param name="formatProvider">The format provider.</param>
    /// <param name="result">The result.</param>
    /// <returns>A bool.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool TryParse([NotNullWhen(true)] string? source, IFormatProvider? formatProvider, out ValueVector5<T> result) => TryParse((ReadOnlySpan<char>)source, formatProvider, out result);

    /// <summary>
    /// Try Parse a string for a <see cref="ValueVector5{T}" /> value.
    /// </summary>
    /// <param name="source">The source string.</param>
    /// <param name="formatProvider">The format provider.</param>
    /// <param name="result">The result.</param>
    /// <returns>A bool.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool TryParse(ReadOnlySpan<char> source, IFormatProvider? formatProvider, out ValueVector5<T> result)
    {
        var tokenizer = new Tokenizer(source, formatProvider);
        var firstToken = tokenizer.NextTokenRequired();

        T.TryParse(firstToken, formatProvider, out var result1);
        T.TryParse(tokenizer.NextTokenRequired(), formatProvider, out var result2);
        T.TryParse(tokenizer.NextTokenRequired(), formatProvider, out var result3);
        T.TryParse(tokenizer.NextTokenRequired(), formatProvider, out var result4);
        T.TryParse(tokenizer.NextTokenRequired(), formatProvider, out var result5);
        var value = new ValueVector5<T>(result1, result2, result3, result4, result5);

        // There should be no more tokens in this string.
        tokenizer.LastTokenRequired();
        result = value;
        return true;
    }

    /// <summary>
    /// Creates a human-readable string that represents this <see cref="ValueVector5{T}" /> struct.
    /// </summary>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public override string? ToString() => ToString("R", CultureInfo.InvariantCulture);

    /// <summary>
    /// Creates a string representation of this <see cref="ValueVector5{T}" /> struct based on the IFormatProvider
    /// passed in.  If the provider is null, the CurrentCulture is used.
    /// </summary>
    /// <param name="formatProvider">The format provider.</param>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public string ToString(IFormatProvider formatProvider) => ToString("R", formatProvider);

    /// <summary>
    /// Creates a string representation of this <see cref="ValueVector5{T}" /> struct based on the IFormatProvider
    /// passed in.  If the provider is null, the CurrentCulture is used.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="formatProvider">The format provider.</param>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(ValueVector5<T>)}: ({nameof(I)}: {I.ToString(format, formatProvider)}, {nameof(J)}: {J.ToString(format, formatProvider)}, {nameof(K)}: {K.ToString(format, formatProvider)}, {nameof(L)}: {L.ToString(format, formatProvider)}, {nameof(M)}: {M.ToString(format, formatProvider)})";

    /// <summary>
    /// Gets the debugger display.
    /// </summary>
    /// <returns>
    /// A string representation of this object for display in the debugger.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private string? GetDebuggerDisplay() => ToString();
}
