// <copyright file="ValueVector.cs" company="Shkyrockett" >
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
/// The value vector.
/// </summary>
/// <typeparam name="T"></typeparam>
[TypeConverter(typeof(ExpandableObjectConverter))]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public struct ValueVector<T>
    : IVector<T>,
    IFormattable,
    IParsable<ValueVector<T>>,
    ISpanParsable<ValueVector<T>>,
    IEquatable<IVector<T>>,
    IAdditiveIdentityMethod<ValueVector<T>, ValueVector<T>>,
    IMultiplicativeIdentityMethod<ValueVector<T>, ValueVector<T>>,
    IEqualityOperators<ValueVector<T>, IVector<T>>,
    IEqualityOperators<ValueVector<T>, ValueVector<T>>,
    IUnaryPlusOperators<ValueVector<T>, ValueVector<T>>,
    IAdditionOperators<ValueVector<T>, IVector<T>, ValueVector<T>>,
    IUnaryNegationOperators<ValueVector<T>, ValueVector<T>>,
    ISubtractionOperators<ValueVector<T>, IVector<T>, ValueVector<T>>,
    IMultiplyOperators<ValueVector<T>, T, ValueVector<T>>,
    IMultiplyOperators2<T, ValueVector<T>, ValueVector<T>>
    where T : INumber<T>
{
    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="ValueVector{T}"/> class.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public ValueVector() : this(Array.Empty<T>()) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueVector{T}"/> class.
    /// </summary>
    /// <param name="vector">The vector.</param>
    public ValueVector(IVector<T> vector) => Items = vector.Items;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueVector{T}"/> class.
    /// </summary>
    /// <param name="vector">The vector.</param>
    public ValueVector(IEnumerable<T> vector) => Items = vector.ToArray();

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueVector{T}"/> class.
    /// </summary>
    /// <param name="vector">The vector.</param>
    public ValueVector(params T[] vector) => Items = vector;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueVector{T}"/> class.
    /// </summary>
    /// <param name="vector">The vector.</param>
    public ValueVector(Span<T> vector) => Items = vector.ToArray();
    #endregion

    #region Deconstructors
    /// <summary>
    /// Deconstructs the.
    /// </summary>
    /// <param name="Items">The items.</param>
    public void Deconstruct(out T[] Items) => Items = this.Items;
    #endregion

    #region Properties
    /// <summary>
    /// Gets or sets the items.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T[] Items { get; set; }

    /// <summary>
    /// Gets the count.
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public int Count => Items.Length;

    /// <summary>
    /// Gets a value indicating whether is scaler.
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public bool IsScaler => Operations.IsScaler<T>(Items);

    /// <summary>
    /// Gets a value indicating whether additive is identity.
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public bool IsAdditiveIdentity => Operations.IsAdditiveIdentity<T>(Items);

    /// <summary>
    /// Gets a value indicating whether multiplicative is identity.
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public bool IsMultiplicativeIdentity => Operations.IsMultiplicativeIdentity<T>(Items);
    #endregion

    #region Operators
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(ValueVector<T> left, IVector<T> right) => left.Equals(right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(ValueVector<T> left, ValueVector<T> right) => left.Equals(right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(ValueVector<T> left, IVector<T> right) => !(left == right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(ValueVector<T> left, ValueVector<T> right) => !(left == right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueVector<T> operator +(ValueVector<T> value) => value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector<T> operator +(ValueVector<T> left, IVector<T> right) => new(Operations.Add<T>(left.Items, right.Items));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector<T> operator checked +(ValueVector<T> left, IVector<T> right) => new(Operations.Add<T>(left.Items, right.Items));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueVector<T> operator -(ValueVector<T> value) => new(Operations.Negate<T>(value.Items));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueVector<T> operator checked -(ValueVector<T> value) => new(Operations.Negate<T>(value.Items));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector<T> operator -(ValueVector<T> left, IVector<T> right) => new(Operations.Subtract<T>(left.Items, right.Items));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector<T> operator checked -(ValueVector<T> left, IVector<T> right) => new(Operations.Subtract<T>(left.Items, right.Items));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector<T> operator *(ValueVector<T> left, T right) => new(Operations.Scale(left.Items, right));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector<T> operator checked *(ValueVector<T> left, T right) => new(Operations.Scale(left.Items, right));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector<T> operator *(T left, ValueVector<T> right) => new(Operations.Scale(left, right.Items));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector<T> operator checked *(T left, ValueVector<T> right) => new(Operations.Scale(left, right.Items));

    ///// <summary>
    ///// 
    ///// </summary>
    ///// <param name="value"></param>
    //public static implicit operator ValueVector<T>(IVector<T> value) => new(value.Items);
    #endregion

    /// <summary>
    /// Magnitudes the squared.
    /// </summary>
    /// <returns>A T.</returns>
    public T MagnitudeSquared() => Operations.MagnitudeSquared<T>(Items);

    /// <summary>
    /// Magnitudes the.
    /// </summary>
    /// <returns>A TResult.</returns>
    public TResult Magnitude<TResult>() where TResult : IFloatingPointIeee754<TResult> => Operations.Magnitude<T, TResult>(Items);

    /// <summary>
    /// Dots the product.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>A ValueVector.</returns>
    public ValueVector<T> DotProduct(ValueVector<T> other) => new(Operations.DotProduct<T>(Items, other.Items));

    /// <summary>
    /// Dots the product.
    /// </summary>
    /// <param name="middle">The middle.</param>
    /// <param name="other">The other.</param>
    /// <returns>A ValueVector.</returns>
    public ValueVector<T> DotProduct(ValueVector<T> middle, ValueVector<T> other) => new(Operations.DotProduct<T>(Items, middle.Items, other.Items));

    ///// <summary>
    ///// 
    ///// </summary>
    ///// <param name="other"></param>
    ///// <returns></returns>
    //public ValueVector<T> CrossProduct(ValueVector<T> other) => new(Operations.CrossProduct<T>(Items, other.Items));

    ///// <summary>
    ///// 
    ///// </summary>
    ///// <param name="middle"></param>
    ///// <param name="other"></param>
    ///// <returns></returns>
    //public ValueVector<T> CrossProduct(ValueVector<T> middle, ValueVector<T> other) => new(Operations.CrossProduct<T>(Items, middle.Items, other.Items));

    /// <summary>
    /// Additives the identity.
    /// </summary>
    /// <param name="length">The length.</param>
    /// <returns>A ValueVector.</returns>
    public static ValueVector<T> AdditiveIdentity(int length) => new(Factories.AdditiveIdentity<T>(length));

    /// <summary>
    /// Multiplicatives the identity.
    /// </summary>
    /// <param name="length">The length.</param>
    /// <returns>A ValueVector.</returns>
    public static ValueVector<T> MultiplicativeIdentity(int length) => new(Factories.MultiplicativeIdentity<T>(length));

    /// <summary>
    /// Gets the hash code.
    /// </summary>
    /// <returns>An int.</returns>
    public override int GetHashCode() => Items.GetHashCode();

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="obj">The obj.</param>
    /// <returns>A bool.</returns>
    public override bool Equals(object? obj) => obj is ValueVector<T> point && Equals(point);

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>A bool.</returns>
    public bool Equals(IVector<T>? other) => other is IVector<T> vector && Enumerable.SequenceEqual(Items, vector.Items);

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>A bool.</returns>
    public bool Equals(ValueVector<T> other) => Enumerable.SequenceEqual(Items, other.Items);

    /// <summary>
    /// Parses the.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="provider">The provider.</param>
    /// <returns>A ValueVector.</returns>
    public static ValueVector<T> Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Parses the.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="provider">The provider.</param>
    /// <returns>A ValueVector.</returns>
    public static ValueVector<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
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
    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out ValueVector<T> result)
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
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out ValueVector<T> result)
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
    public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(ValueVector<T>)}: ({string.Join(", ", Items.Select((x, i) => $"{Operations.VectorComponentNames[i]}: {x}").ToArray())})";

    /// <summary>
    /// Gets the debugger display.
    /// </summary>
    /// <returns>A string? .</returns>
    private string? GetDebuggerDisplay() => ToString();
}
