// <copyright file="ValueSize3.cs" company="Shkyrockett" >
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
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace GenericMathPlayground.Geometry;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
[TypeConverter(typeof(ExpandableObjectConverter))]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public struct ValueSize3<T>
    : ISize3<T>,
    IFormattable,
    IParseable<ValueSize3<T>>,
    ISpanParseable<ValueSize3<T>>,
    IComparable,
    IComparable<IVector3<T>>,
    IEquatable<ValueSize3<T>>,
    IAdditiveIdentity<ValueSize3<T>, ValueSize3<T>>,
    IMultiplicativeIdentity<ValueSize3<T>, ValueSize3<T>>,
    IComparisonOperators<ValueSize3<T>, IVector3<T>>,
    IEqualityOperators<ValueSize3<T>, IVector3<T>>,
    IIncrementOperators<ValueSize3<T>>,
    IUnaryPlusOperators<ValueSize3<T>, ValueSize3<T>>,
    IAdditionOperators<ValueSize3<T>, IVector3<T>, ValueSize3<T>>,
    IAdditionOperators2<IVector3<T>, ValueSize3<T>, IVector3<T>>,
    IDecrementOperators<ValueSize3<T>>,
    IUnaryNegationOperators<ValueSize3<T>, ValueSize3<T>>,
    ISubtractionOperators<ValueSize3<T>, IVector3<T>, ValueSize3<T>>,
    ISubtractionOperators2<IVector3<T>, ValueSize3<T>, IVector3<T>>,
    IMultiplyOperators<ValueSize3<T>, T, ValueSize3<T>>,
    IMultiplyOperators<ValueSize3<T>, ValueSize3<T>, ValueSize3<T>>,
    IMultiplyOperators<ValueSize3<T>, IVector3<T>, ValueSize3<T>>,
    IMultiplyOperators2<IVector3<T>, ValueSize3<T>, IVector3<T>>,
    IDivisionOperators<ValueSize3<T>, T, ValueSize3<T>>,
    IDivisionOperators<ValueSize3<T>, ValueSize3<T>, ValueSize3<T>>,
    IDivisionOperators<ValueSize3<T>, IVector3<T>, ValueSize3<T>>,
    IDivisionOperators2<IVector3<T>, ValueSize3<T>, IVector3<T>>,
    IModulusOperators<ValueSize3<T>, T, ValueSize3<T>>,
    IModulusOperators<ValueSize3<T>, ValueSize3<T>, ValueSize3<T>>,
    IModulusOperators2<IVector3<T>, ValueSize3<T>, IVector3<T>>
    where T : INumber<T>
{
    #region Constructors
    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public ValueSize3(IVector3<T> value) => (Width, Height, Depth) = value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tuple"></param>
    public ValueSize3((T Width, T Height, T Depth) tuple) => (Width, Height, Depth) = tuple;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="depth"></param>
    public ValueSize3(T width, T height, T depth) => (Width, Height, Depth) = (width, height, depth);
    #endregion

    #region Deconstructors
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Width"></param>
    /// <param name="Height"></param>
    /// <param name="Depth"></param>
    public void Deconstruct(out T Width, out T Height, out T Depth) => (Width, Height, Depth) = this;
    #endregion

    #region Properties
    /// <summary>
    /// 
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T Width { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T Height { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T Depth { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    public T[] Items { get { return new T[] { Width, Height, Depth }; } set { (Width, Height, Depth) = (value[0], value[1], value[2]); } }

    /// <summary>
    /// 
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public int Count => 3;

    /// <summary>
    /// 
    /// </summary>
    public static ValueSize3<T> AdditiveIdentity => new(T.Zero, T.Zero, T.Zero);

    /// <summary>
    /// 
    /// </summary>
    public static ValueSize3<T> MultiplicativeIdentity => new(T.One, T.One, T.One);
    #endregion

    #region Operators
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator <(ValueSize3<T> left, IVector3<T> right)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator <=(ValueSize3<T> left, IVector3<T> right)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(ValueSize3<T> left, IVector3<T> right) => left.Equals(right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(ValueSize3<T> left, ValueSize3<T> right) => left.Equals(right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(ValueSize3<T> left, IVector3<T> right) => !(left == right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(ValueSize3<T> left, ValueSize3<T> right) => !(left == right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator >(ValueSize3<T> left, IVector3<T> right)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator >=(ValueSize3<T> left, IVector3<T> right)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueSize3<T> operator ++(ValueSize3<T> value) => new(++value.Width, ++value.Height, ++value.Depth);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueSize3<T> operator +(ValueSize3<T> value) => value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize3<T> operator +(ValueSize3<T> left, IVector3<T> right) => new(left.Width + right.X, left.Height + right.Y, left.Depth + right.Z);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static IVector3<T> operator +(IVector3<T> left, ValueSize3<T> right) => new ValuePoint3<T>(left.X + right.Width, left.Y + right.Height, left.Z + right.Depth);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueSize3<T> operator --(ValueSize3<T> value) => new(--value.Width, --value.Height, --value.Depth);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueSize3<T> operator -(ValueSize3<T> value) => new(-value.Width, -value.Height, -value.Depth);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize3<T> operator -(ValueSize3<T> left, IVector3<T> right) => new(left.Width - right.X, left.Height - right.Y, left.Depth - right.Z);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static IVector3<T> operator -(IVector3<T> left, ValueSize3<T> right) => new ValuePoint3<T>(left.X - right.Width, left.Y - right.Height, left.Z - right.Depth);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize3<T> operator *(ValueSize3<T> left, T right) => new(left.Width * right, left.Height * right, left.Depth * right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize3<T> operator *(ValueSize3<T> left, ValueSize3<T> right) => new(left.Width * right.Width, left.Height * right.Height, left.Depth * right.Depth);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize3<T> operator *(ValueSize3<T> left, IVector3<T> right) => new(left.Width * right.X, left.Height * right.Y, left.Depth * right.Z);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static IVector3<T> operator *(IVector3<T> left, ValueSize3<T> right) => new ValuePoint3<T>(left.X * right.Width, left.Y * right.Height, left.Z * right.Depth);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize3<T> operator /(ValueSize3<T> left, T right) => new(left.Width / right, left.Height / right, left.Depth / right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize3<T> operator /(ValueSize3<T> left, ValueSize3<T> right) => new(left.Width / right.Width, left.Height / right.Height, left.Depth / right.Depth);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize3<T> operator /(ValueSize3<T> left, IVector3<T> right) => new(left.Width / right.X, left.Height / right.Y, left.Depth / right.Z);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static IVector3<T> operator /(IVector3<T> left, ValueSize3<T> right) => new ValuePoint3<T>(left.X / right.Width, left.Y / right.Height, left.Z / right.Depth);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize3<T> operator %(ValueSize3<T> left, T right) => new(left.Width % right, left.Height % right, left.Depth % right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize3<T> operator %(ValueSize3<T> left, ValueSize3<T> right) => new(left.Width % right.Width, left.Height % right.Height, left.Depth % right.Depth);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static IVector3<T> operator %(IVector3<T> left, ValueSize3<T> right) => new ValuePoint3<T>(left.X % right.Width, left.Y % right.Height, left.Z % right.Depth);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public static implicit operator ValueSize3<T>(ValueVector3<T> value) => new(value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public static implicit operator ValueSize3<T>(ValuePoint3<T> value) => new(value);
    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode() => HashCode.Combine(Width, Height, Depth);

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
    public override bool Equals(object? obj) => obj is ValueSize3<T> size && Equals(size);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(ValueSize3<T> other) => Width.Equals(other.Width) && Height.Equals(other.Height) && Depth.Equals(other.Depth);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(IVector3<T>? other) => other is IVector3<T> size && Width.Equals(size.X) && Height.Equals(size.Y) && Depth.Equals(size.Z);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="provider"></param>
    /// <returns></returns>
    public static ValueSize3<T> Parse(string s, IFormatProvider? provider)
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
    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out ValueSize3<T> result)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="provider"></param>
    /// <returns></returns>
    public static ValueSize3<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
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
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out ValueSize3<T> result)
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
    public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(ValueSize3<T>)}: ({nameof(Width)}: {Width.ToString(format, formatProvider)}, {nameof(Height)}: {Height.ToString(format, formatProvider)}, {nameof(Depth)}: {Depth.ToString(format, formatProvider)})";

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private string? GetDebuggerDisplay() => ToString();
}
