// <copyright file="ValueSize5.cs" company="Shkyrockett" >
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
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace GenericMathPlayground.Geometry;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
[TypeConverter(typeof(ExpandableObjectConverter))]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public struct ValueSize5<T>
    : ISize5<T>,
    IFormattable,
    IParseable<ValueSize5<T>>,
    ISpanParseable<ValueSize5<T>>,
    IComparable,
    IComparable<IVector5<T>>,
    IEquatable<ValueSize5<T>>,
    IAdditiveIdentity<ValueSize5<T>, ValueSize5<T>>,
    IMultiplicativeIdentity<ValueSize5<T>, ValueSize5<T>>,
    IComparisonOperators<ValueSize5<T>, IVector5<T>>,
    IEqualityOperators<ValueSize5<T>, IVector5<T>>,
    IIncrementOperators<ValueSize5<T>>,
    IUnaryPlusOperators<ValueSize5<T>, ValueSize5<T>>,
    IAdditionOperators<ValueSize5<T>, IVector5<T>, ValueSize5<T>>,
    IAdditionOperators2<IVector5<T>, ValueSize5<T>, IVector5<T>>,
    IDecrementOperators<ValueSize5<T>>,
    IUnaryNegationOperators<ValueSize5<T>, ValueSize5<T>>,
    ISubtractionOperators<ValueSize5<T>, IVector5<T>, ValueSize5<T>>,
    ISubtractionOperators2<IVector5<T>, ValueSize5<T>, IVector5<T>>,
    IMultiplyOperators<ValueSize5<T>, T, ValueSize5<T>>,
    IMultiplyOperators<ValueSize5<T>, ValueSize5<T>, ValueSize5<T>>,
    IMultiplyOperators<ValueSize5<T>, IVector5<T>, ValueSize5<T>>,
    IMultiplyOperators2<IVector5<T>, ValueSize5<T>, IVector5<T>>,
    IDivisionOperators<ValueSize5<T>, T, ValueSize5<T>>,
    IDivisionOperators<ValueSize5<T>, ValueSize5<T>, ValueSize5<T>>,
    IDivisionOperators<ValueSize5<T>, IVector5<T>, ValueSize5<T>>,
    IDivisionOperators2<IVector5<T>, ValueSize5<T>, IVector5<T>>,
    IModulusOperators<ValueSize5<T>, T, ValueSize5<T>>,
    IModulusOperators<ValueSize5<T>, ValueSize5<T>, ValueSize5<T>>,
    IModulusOperators2<IVector5<T>, ValueSize5<T>, IVector5<T>>
    where T : INumber<T>
{
    #region Constructors
    /// <summary>
    /// 
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public ValueSize5() : this(T.Zero, T.Zero, T.Zero, T.Zero, T.Zero) { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public ValueSize5(IVector5<T> value) => (Width, Height, Depth, Breadth, Length) = value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tuple"></param>
    public ValueSize5((T Width, T Height, T Depth, T Breadth, T Length) tuple) => (Width, Height, Depth, Breadth, Length) = tuple;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="depth"></param>
    /// <param name="breadth"></param>
    /// <param name="length"></param>
    public ValueSize5(T width, T height, T depth, T breadth, T length) => (Width, Height, Depth, Breadth, Length) = (width, height, depth, breadth, length);
    #endregion

    #region Deconstructors
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Width"></param>
    /// <param name="Height"></param>
    /// <param name="Depth"></param>
    /// <param name="Breadth"></param>
    /// <param name="Length"></param>
    public void Deconstruct(out T Width, out T Height, out T Depth, out T Breadth, out T Length) => (Width, Height, Depth, Breadth, Length) = this;
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
    [RefreshProperties(RefreshProperties.All)]
    public T Breadth { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T Length { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    public T[] Items { get { return new T[] { Width, Height, Depth, Breadth, Length }; } set { (Width, Height, Depth, Breadth, Length) = (value[0], value[1], value[2], value[3], value[4]); } }

    /// <summary>
    /// 
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public int Count => 5;

    /// <summary>
    /// 
    /// </summary>
    public static ValueSize5<T> AdditiveIdentity => new(T.Zero, T.Zero, T.Zero, T.Zero, T.Zero);

    /// <summary>
    /// 
    /// </summary>
    public static ValueSize5<T> MultiplicativeIdentity => new(T.One, T.One, T.One, T.One, T.One);
    #endregion

    #region Operators
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator <(ValueSize5<T> left, IVector5<T> right)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator <=(ValueSize5<T> left, IVector5<T> right)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(ValueSize5<T> left, IVector5<T> right) => left.Equals(right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(ValueSize5<T> left, ValueSize5<T> right) => left.Equals(right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(ValueSize5<T> left, IVector5<T> right) => !(left == right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(ValueSize5<T> left, ValueSize5<T> right) => !(left == right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator >(ValueSize5<T> left, IVector5<T> right)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator >=(ValueSize5<T> left, IVector5<T> right)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueSize5<T> operator ++(ValueSize5<T> value) => new(Operations.IncrementVector(++value.Width, ++value.Height, ++value.Depth, ++value.Breadth, ++value.Length));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueSize5<T> operator +(ValueSize5<T> value) => value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize5<T> operator +(ValueSize5<T> left, IVector5<T> right) => new(Operations.AddVectors(left.Width, left.Height, left.Depth, left.Breadth, left.Length, right.X, right.Y, right.Z, right.W, right.V));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static IVector5<T> operator +(IVector5<T> left, ValueSize5<T> right) => new ValuePoint5<T>(Operations.AddVectors(left.X, left.Y, left.Z, left.W, left.V, right.Width, right.Height, right.Depth, right.Breadth, right.Length));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueSize5<T> operator --(ValueSize5<T> value) => new(Operations.DecrementVector(value.Width, value.Height, value.Depth, value.Breadth, value.Length));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueSize5<T> operator -(ValueSize5<T> value) => new(Operations.NegateVector(value.Width, value.Height, value.Depth, value.Breadth, value.Length));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize5<T> operator -(ValueSize5<T> left, IVector5<T> right) => new(Operations.SubtractVector(left.Width, left.Height, left.Depth, left.Breadth, left.Length, right.X, right.Y, right.Z, right.W, right.V));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static IVector5<T> operator -(IVector5<T> left, ValueSize5<T> right) => new ValuePoint5<T>(Operations.SubtractVector(left.X, left.Y, left.Z, left.W, left.V, right.Width, right.Height, right.Depth, right.Breadth, right.Length));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize5<T> operator *(ValueSize5<T> left, T right) => new(Operations.ScaleVector(left.Width, left.Height, left.Depth, left.Breadth, left.Length, right));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize5<T> operator *(ValueSize5<T> left, ValueSize5<T> right) => new(Operations.ScaleVectorParametric(left.Width, left.Height, left.Depth, left.Breadth, left.Length, right.Width, right.Height, right.Depth, right.Breadth, right.Length));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize5<T> operator *(ValueSize5<T> left, IVector5<T> right) => new(Operations.ScaleVectorParametric(left.Width, left.Height, left.Depth, left.Breadth, left.Length, right.X, right.Y, right.Z, right.W, right.V));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static IVector5<T> operator *(IVector5<T> left, ValueSize5<T> right) => new ValuePoint5<T>(Operations.ScaleVectorParametric(left.X, left.Y, left.Z, left.W, left.V, right.Width, right.Height, right.Depth, right.Breadth, right.Length));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize5<T> operator /(ValueSize5<T> left, T right) => new(Operations.DivideVectorUniform(left.Width, left.Height, left.Depth, left.Breadth, left.Length, right));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize5<T> operator /(ValueSize5<T> left, ValueSize5<T> right) => new(Operations.DivideVectorParametric(left.Width, left.Height, left.Depth, left.Breadth, left.Length, right.Width, right.Height, right.Depth, right.Breadth, right.Length));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize5<T> operator /(ValueSize5<T> left, IVector5<T> right) => new(Operations.DivideVectorParametric(left.Width, left.Height, left.Depth, left.Breadth, left.Length, right.X, right.Y, right.Z, right.W, right.V));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static IVector5<T> operator /(IVector5<T> left, ValueSize5<T> right) => new ValuePoint5<T>(Operations.DivideVectorParametric(left.X, left.Y, left.Z, left.W, left.V, right.Width, right.Height, right.Depth, right.Breadth, right.Length));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize5<T> operator %(ValueSize5<T> left, T right) => new(Operations.ModulusVectorRight(left.Width, left.Height, left.Depth, left.Breadth, left.Length, right));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize5<T> operator %(ValueSize5<T> left, ValueSize5<T> right) => new(Operations.ModulusVectorParametric(left.Width, left.Height, left.Depth, left.Breadth, left.Length, right.Width, right.Height, right.Depth, right.Breadth, right.Length));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static IVector5<T> operator %(IVector5<T> left, ValueSize5<T> right) => new ValuePoint5<T>(Operations.ModulusVectorParametric(left.X, left.Y, left.Z, left.W, left.V, right.Width, right.Height, right.Depth, right.Breadth, right.Length));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public static implicit operator ValueSize5<T>(ValueVector5<T> value) => new(value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public static implicit operator ValueSize5<T>(ValuePoint5<T> value) => new(value);
    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode() => HashCode.Combine(Width, Height, Depth, Breadth, Length);

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
    public int CompareTo(IVector5<T>? other)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj) => obj is ValueSize5<T> size && Equals(size);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(ValueSize5<T> other) => Width.Equals(other.Width) && Height.Equals(other.Height) && Depth.Equals(other.Depth) && Breadth.Equals(other.Breadth) && Length.Equals(other.Length);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(IVector5<T>? other) => other is IVector5<T> size && Width.Equals(size.X) && Height.Equals(size.Y) && Depth.Equals(size.Z) && Breadth.Equals(size.W) && Length.Equals(size.V);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="provider"></param>
    /// <returns></returns>
    public static ValueSize5<T> Parse(string s, IFormatProvider? provider)
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
    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out ValueSize5<T> result)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="provider"></param>
    /// <returns></returns>
    public static ValueSize5<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
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
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out ValueSize5<T> result)
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
    public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(ValueSize5<T>)}: ({nameof(Width)}: {Width.ToString(format, formatProvider)}, {nameof(Height)}: {Height.ToString(format, formatProvider)}, {nameof(Depth)}: {Depth.ToString(format, formatProvider)}, {nameof(Breadth)}: {Breadth.ToString(format, formatProvider)}, {nameof(Length)}: {Length.ToString(format, formatProvider)})";

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private string? GetDebuggerDisplay() => ToString();
}
