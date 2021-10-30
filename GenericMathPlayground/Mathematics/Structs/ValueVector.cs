// <copyright file="ValueVector.cs" company="Shkyrockett" >
//     Copyright © 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace GenericMathPlayground.Mathematics;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
[TypeConverter(typeof(ExpandableObjectConverter))]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public struct ValueVector<T>
    : IVector<T>,
    IFormattable,
    IParseable<ValueVector<T>>,
    ISpanParseable<ValueVector<T>>,
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
    /// 
    /// </summary>
    /// <param name="vector"></param>
    public ValueVector(IVector<T> vector) => Items = vector.Items;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="vector"></param>
    public ValueVector(IEnumerable<T> vector) => Items = vector.ToArray();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="vector"></param>
    public ValueVector(params T[] vector) => Items = vector;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="vector"></param>
    public ValueVector(Span<T> vector) => Items = vector.ToArray();
    #endregion

    #region Deconstructors
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Items"></param>
    public void Deconstruct(out T[] Items) => Items = this.Items;
    #endregion

    #region Properties
    /// <summary>
    /// 
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T[] Items { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public int Count => Items.Length;

    /// <summary>
    /// 
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public bool IsScaler => Operations.IsScaler<T>(Items);

    /// <summary>
    /// 
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public bool IsAdditiveIdentity => Operations.IsAdditiveIdentity<T>(Items);

    /// <summary>
    /// 
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
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueVector<T> operator -(ValueVector<T> value) => new(Operations.Negate<T>(value.Items));

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
    public static ValueVector<T> operator *(ValueVector<T> left, T right) => new(Operations.Scale(left.Items, right));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector<T> operator *(T left, ValueVector<T> right) => new(Operations.Scale(left, right.Items));

    ///// <summary>
    ///// 
    ///// </summary>
    ///// <param name="value"></param>
    //public static implicit operator ValueVector<T>(IVector<T> value) => new(value.Items);
    #endregion

    /// <summary>
    /// 
    /// </summary>
    public T MagnitudeSquared() => Operations.MagnitudeSquared<T>(Items);

    /// <summary>
    /// 
    /// </summary>
    public TResult Magnitude<TResult>() where TResult : IFloatingPoint<TResult> => Operations.Magnitude<T, TResult>(Items);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public ValueVector<T> DotProduct(ValueVector<T> other) => new(Operations.DotProduct<T>(Items, other.Items));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="middle"></param>
    /// <param name="other"></param>
    /// <returns></returns>
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
    /// 
    /// </summary>
    public static ValueVector<T> AdditiveIdentity(int length) => new(Factories.AdditiveIdentity<T>(length));

    /// <summary>
    /// 
    /// </summary>
    public static ValueVector<T> MultiplicativeIdentity(int length) => new(Factories.MultiplicativeIdentity<T>(length));

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode() => Items.GetHashCode();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj) => obj is ValueVector<T> point && Equals(point);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(IVector<T>? other) => other is IVector<T> vector && Enumerable.SequenceEqual(Items, vector.Items);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(ValueVector<T> other) => Enumerable.SequenceEqual(Items, other.Items);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="provider"></param>
    /// <returns></returns>
    public static ValueVector<T> Parse(string s, IFormatProvider? provider)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="provider"></param>
    /// <returns></returns>
    public static ValueVector<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
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
    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out ValueVector<T> result)
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
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out ValueVector<T> result)
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
    public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(ValueVector<T>)}: ({string.Join(", ", Items.Select((x, i) => $"{Operations.VectorComponentNames[i]}: {x}").ToArray())})";

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private string? GetDebuggerDisplay() => ToString();
}
