// <copyright file="ValueSize5.cs" company="Shkyrockett" >
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
/// The value size5.
/// </summary>
/// <typeparam name="T"></typeparam>
[TypeConverter(typeof(ExpandableObjectConverter))]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public struct ValueSize5<T>
    : ISize5<T>,
    IFormattable,
    IParsable<ValueSize5<T>>,
    ISpanParsable<ValueSize5<T>>,
    IComparable,
    IComparable<IVector5<T>>,
    IEquatable<ValueSize5<T>>,
    IAdditiveIdentity<ValueSize5<T>, ValueSize5<T>>,
    IMultiplicativeIdentity<ValueSize5<T>, ValueSize5<T>>,
    IComparisonOperators<ValueSize5<T>, IVector5<T>, bool>,
    IEqualityOperators<ValueSize5<T>, IVector5<T>, bool>,
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
    /// Initializes a new instance of the <see cref="ValueSize5{T}"/> class.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public ValueSize5() : this(T.Zero, T.Zero, T.Zero, T.Zero, T.Zero) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueSize5{T}"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public ValueSize5(IVector5<T> value) => (Width, Height, Depth, Breadth, Girth) = value;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueSize5{T}"/> class.
    /// </summary>
    /// <param name="tuple">The tuple.</param>
    public ValueSize5((T Width, T Height, T Depth, T Breadth, T Girth) tuple) => (Width, Height, Depth, Breadth, Girth) = tuple;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueSize5{T}"/> class.
    /// </summary>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    /// <param name="depth">The depth.</param>
    /// <param name="breadth">The breadth.</param>
    /// <param name="girth">The girth.</param>
    public ValueSize5(T width, T height, T depth, T breadth, T girth) => (Width, Height, Depth, Breadth, Girth) = (width, height, depth, breadth, girth);
    #endregion

    #region Deconstructors
    /// <summary>
    /// Deconstructs the.
    /// </summary>
    /// <param name="Width">The width.</param>
    /// <param name="Height">The height.</param>
    /// <param name="Depth">The depth.</param>
    /// <param name="Breadth">The breadth.</param>
    /// <param name="Girth">The girth.</param>
    public void Deconstruct(out T Width, out T Height, out T Depth, out T Breadth, out T Girth) => (Width, Height, Depth, Breadth, Girth) = this;
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
    /// Gets or sets the depth.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T Depth { get; set; }

    /// <summary>
    /// Gets or sets the breadth.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T Breadth { get; set; }

    /// <summary>
    /// Gets or sets the girth.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T Girth { get; set; }

    /// <summary>
    /// Gets or sets the items.
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    public T[] Items { get { return new T[] { Width, Height, Depth, Breadth, Girth }; } set { (Width, Height, Depth, Breadth, Girth) = (value[0], value[1], value[2], value[3], value[4]); } }

    /// <summary>
    /// Gets the count.
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public int Count => 5;

    /// <summary>
    /// Gets the additive identity.
    /// </summary>
    public static ValueSize5<T> AdditiveIdentity => new(T.Zero, T.Zero, T.Zero, T.Zero, T.Zero);

    /// <summary>
    /// Gets the multiplicative identity.
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
    public static ValueSize5<T> operator ++(ValueSize5<T> value) => new(Operations.IncrementVector(++value.Width, ++value.Height, ++value.Depth, ++value.Breadth, ++value.Girth));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueSize5<T> operator checked ++(ValueSize5<T> value) => new(Operations.IncrementVector(++value.Width, ++value.Height, ++value.Depth, ++value.Breadth, ++value.Girth));

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
    public static ValueSize5<T> operator +(ValueSize5<T> left, IVector5<T> right) => new(Operations.AddVectors(left.Width, left.Height, left.Depth, left.Breadth, left.Girth, right.X, right.Y, right.Z, right.W, right.V));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize5<T> operator checked +(ValueSize5<T> left, IVector5<T> right) => new(Operations.AddVectors(left.Width, left.Height, left.Depth, left.Breadth, left.Girth, right.X, right.Y, right.Z, right.W, right.V));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static IVector5<T> operator +(IVector5<T> left, ValueSize5<T> right) => new ValuePoint5<T>(Operations.AddVectors(left.X, left.Y, left.Z, left.W, left.V, right.Width, right.Height, right.Depth, right.Breadth, right.Girth));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static IVector5<T> operator checked +(IVector5<T> left, ValueSize5<T> right) => new ValuePoint5<T>(Operations.AddVectors(left.X, left.Y, left.Z, left.W, left.V, right.Width, right.Height, right.Depth, right.Breadth, right.Girth));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueSize5<T> operator --(ValueSize5<T> value) => new(Operations.DecrementVector(value.Width, value.Height, value.Depth, value.Breadth, value.Girth));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueSize5<T> operator checked --(ValueSize5<T> value) => new(Operations.DecrementVector(value.Width, value.Height, value.Depth, value.Breadth, value.Girth));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueSize5<T> operator -(ValueSize5<T> value) => new(Operations.NegateVector(value.Width, value.Height, value.Depth, value.Breadth, value.Girth));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueSize5<T> operator checked -(ValueSize5<T> value) => new(Operations.NegateVector(value.Width, value.Height, value.Depth, value.Breadth, value.Girth));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize5<T> operator -(ValueSize5<T> left, IVector5<T> right) => new(Operations.SubtractVector(left.Width, left.Height, left.Depth, left.Breadth, left.Girth, right.X, right.Y, right.Z, right.W, right.V));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize5<T> operator checked -(ValueSize5<T> left, IVector5<T> right) => new(Operations.SubtractVector(left.Width, left.Height, left.Depth, left.Breadth, left.Girth, right.X, right.Y, right.Z, right.W, right.V));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static IVector5<T> operator -(IVector5<T> left, ValueSize5<T> right) => new ValuePoint5<T>(Operations.SubtractVector(left.X, left.Y, left.Z, left.W, left.V, right.Width, right.Height, right.Depth, right.Breadth, right.Girth));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static IVector5<T> operator checked -(IVector5<T> left, ValueSize5<T> right) => new ValuePoint5<T>(Operations.SubtractVector(left.X, left.Y, left.Z, left.W, left.V, right.Width, right.Height, right.Depth, right.Breadth, right.Girth));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize5<T> operator *(ValueSize5<T> left, T right) => new(Operations.ScaleVector(left.Width, left.Height, left.Depth, left.Breadth, left.Girth, right));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize5<T> operator checked *(ValueSize5<T> left, T right) => new(Operations.ScaleVector(left.Width, left.Height, left.Depth, left.Breadth, left.Girth, right));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize5<T> operator *(ValueSize5<T> left, ValueSize5<T> right) => new(Operations.ScaleVectorParametric(left.Width, left.Height, left.Depth, left.Breadth, left.Girth, right.Width, right.Height, right.Depth, right.Breadth, right.Girth));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize5<T> operator checked *(ValueSize5<T> left, ValueSize5<T> right) => new(Operations.ScaleVectorParametric(left.Width, left.Height, left.Depth, left.Breadth, left.Girth, right.Width, right.Height, right.Depth, right.Breadth, right.Girth));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize5<T> operator *(ValueSize5<T> left, IVector5<T> right) => new(Operations.ScaleVectorParametric(left.Width, left.Height, left.Depth, left.Breadth, left.Girth, right.X, right.Y, right.Z, right.W, right.V));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize5<T> operator checked *(ValueSize5<T> left, IVector5<T> right) => new(Operations.ScaleVectorParametric(left.Width, left.Height, left.Depth, left.Breadth, left.Girth, right.X, right.Y, right.Z, right.W, right.V));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static IVector5<T> operator *(IVector5<T> left, ValueSize5<T> right) => new ValuePoint5<T>(Operations.ScaleVectorParametric(left.X, left.Y, left.Z, left.W, left.V, right.Width, right.Height, right.Depth, right.Breadth, right.Girth));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static IVector5<T> operator checked *(IVector5<T> left, ValueSize5<T> right) => new ValuePoint5<T>(Operations.ScaleVectorParametric(left.X, left.Y, left.Z, left.W, left.V, right.Width, right.Height, right.Depth, right.Breadth, right.Girth));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize5<T> operator /(ValueSize5<T> left, T right) => new(Operations.DivideVectorUniform(left.Width, left.Height, left.Depth, left.Breadth, left.Girth, right));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize5<T> operator checked /(ValueSize5<T> left, T right) => new(Operations.DivideVectorUniform(left.Width, left.Height, left.Depth, left.Breadth, left.Girth, right));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize5<T> operator /(ValueSize5<T> left, ValueSize5<T> right) => new(Operations.DivideVectorParametric(left.Width, left.Height, left.Depth, left.Breadth, left.Girth, right.Width, right.Height, right.Depth, right.Breadth, right.Girth));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize5<T> operator checked /(ValueSize5<T> left, ValueSize5<T> right) => new(Operations.DivideVectorParametric(left.Width, left.Height, left.Depth, left.Breadth, left.Girth, right.Width, right.Height, right.Depth, right.Breadth, right.Girth));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize5<T> operator /(ValueSize5<T> left, IVector5<T> right) => new(Operations.DivideVectorParametric(left.Width, left.Height, left.Depth, left.Breadth, left.Girth, right.X, right.Y, right.Z, right.W, right.V));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize5<T> operator checked /(ValueSize5<T> left, IVector5<T> right) => new(Operations.DivideVectorParametric(left.Width, left.Height, left.Depth, left.Breadth, left.Girth, right.X, right.Y, right.Z, right.W, right.V));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static IVector5<T> operator /(IVector5<T> left, ValueSize5<T> right) => new ValuePoint5<T>(Operations.DivideVectorParametric(left.X, left.Y, left.Z, left.W, left.V, right.Width, right.Height, right.Depth, right.Breadth, right.Girth));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static IVector5<T> operator checked /(IVector5<T> left, ValueSize5<T> right) => new ValuePoint5<T>(Operations.DivideVectorParametric(left.X, left.Y, left.Z, left.W, left.V, right.Width, right.Height, right.Depth, right.Breadth, right.Girth));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize5<T> operator %(ValueSize5<T> left, T right) => new(Operations.ModulusVectorRight(left.Width, left.Height, left.Depth, left.Breadth, left.Girth, right));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize5<T> operator %(ValueSize5<T> left, ValueSize5<T> right) => new(Operations.ModulusVectorParametric(left.Width, left.Height, left.Depth, left.Breadth, left.Girth, right.Width, right.Height, right.Depth, right.Breadth, right.Girth));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static IVector5<T> operator %(IVector5<T> left, ValueSize5<T> right) => new ValuePoint5<T>(Operations.ModulusVectorParametric(left.X, left.Y, left.Z, left.W, left.V, right.Width, right.Height, right.Depth, right.Breadth, right.Girth));

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
    /// Gets the hash code.
    /// </summary>
    /// <returns>An int.</returns>
    public override int GetHashCode() => HashCode.Combine(Width, Height, Depth, Breadth, Girth);

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
    public override bool Equals(object? obj) => obj is ValueSize5<T> size && Equals(size);

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>A bool.</returns>
    public bool Equals(ValueSize5<T> other) => Width.Equals(other.Width) && Height.Equals(other.Height) && Depth.Equals(other.Depth) && Breadth.Equals(other.Breadth) && Girth.Equals(other.Girth);

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>A bool.</returns>
    public bool Equals(IVector5<T>? other) => other is IVector5<T> size && Width.Equals(size.X) && Height.Equals(size.Y) && Depth.Equals(size.Z) && Breadth.Equals(size.W) && Girth.Equals(size.V);

    /// <summary>
    /// Parses the.
    /// </summary>
    /// <param name="source">The s.</param>
    /// <param name="formatProvider">The provider.</param>
    /// <returns>A ValueSize5.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static ValueSize5<T> Parse(string source, IFormatProvider? formatProvider) => Parse((ReadOnlySpan<char>)source, formatProvider);

    /// <summary>
    /// Parses the.
    /// </summary>
    /// <param name="source">The s.</param>
    /// <param name="formatProvider">The provider.</param>
    /// <returns>A ValueSize5.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static ValueSize5<T> Parse(ReadOnlySpan<char> source, IFormatProvider? formatProvider) => TryParse(source, formatProvider, out var result) ? result : result;

    /// <summary>
    /// Tries the parse.
    /// </summary>
    /// <param name="source">The s.</param>
    /// <param name="formatProvider">The provider.</param>
    /// <param name="result">The result.</param>
    /// <returns>A bool.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool TryParse([NotNullWhen(true)] string? source, IFormatProvider? formatProvider, out ValueSize5<T> result) => TryParse((ReadOnlySpan<char>)source, formatProvider, out result);

    /// <summary>
    /// Tries the parse.
    /// </summary>
    /// <param name="source">The s.</param>
    /// <param name="formatProvider">The provider.</param>
    /// <param name="result">The result.</param>
    /// <returns>A bool.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool TryParse(ReadOnlySpan<char> source, IFormatProvider? formatProvider, out ValueSize5<T> result)
    {
        var tokenizer = new Tokenizer(source, formatProvider);
        var firstToken = tokenizer.NextTokenRequired();

        T.TryParse(firstToken, formatProvider, out var result1);
        T.TryParse(tokenizer.NextTokenRequired(), formatProvider, out var result2);
        T.TryParse(tokenizer.NextTokenRequired(), formatProvider, out var result3);
        T.TryParse(tokenizer.NextTokenRequired(), formatProvider, out var result4);
        T.TryParse(tokenizer.NextTokenRequired(), formatProvider, out var result5);
        var value = new ValueSize5<T>(result1, result2, result3, result4, result5);

        // There should be no more tokens in this string.
        tokenizer.LastTokenRequired();
        result = value;
        return true;
    }

    /// <summary>
    /// Creates a human-readable string that represents this <see cref="ValueSize5{T}" /> struct.
    /// </summary>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public override string? ToString() => ToString("R", CultureInfo.InvariantCulture);

    /// <summary>
    /// Creates a string representation of this <see cref="ValueSize5{T}" /> struct based on the IFormatProvider
    /// passed in.  If the provider is null, the CurrentCulture is used.
    /// </summary>
    /// <param name="formatProvider">The format provider.</param>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public string ToString(IFormatProvider formatProvider) => ToString("R", formatProvider);

    /// <summary>
    /// Creates a string representation of this <see cref="ValueSize5{T}" /> struct based on the IFormatProvider
    /// passed in.  If the provider is null, the CurrentCulture is used.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="formatProvider">The format provider.</param>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(ValueSize5<T>)}: ({nameof(Width)}: {Width.ToString(format, formatProvider)}, {nameof(Height)}: {Height.ToString(format, formatProvider)}, {nameof(Depth)}: {Depth.ToString(format, formatProvider)}, {nameof(Breadth)}: {Breadth.ToString(format, formatProvider)}, {nameof(Girth)}: {Girth.ToString(format, formatProvider)})";

    /// <summary>
    /// Gets the debugger display.
    /// </summary>
    /// <returns>
    /// A string representation of this object for display in the debugger.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private string? GetDebuggerDisplay() => ToString();
}
