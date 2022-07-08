// <copyright file="ValueSize4.cs" company="Shkyrockett" >
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
/// The value size4.
/// </summary>
/// <typeparam name="T"></typeparam>
[TypeConverter(typeof(ExpandableObjectConverter))]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public struct ValueSize4<T>
    : ISize4<T>,
    IFormattable,
    IParsable<ValueSize4<T>>,
    ISpanParsable<ValueSize4<T>>,
    IComparable,
    IComparable<IVector4<T>>,
    IEquatable<ValueSize4<T>>,
    IAdditiveIdentity<ValueSize4<T>, ValueSize4<T>>,
    IMultiplicativeIdentity<ValueSize4<T>, ValueSize4<T>>,
    IComparisonOperators<ValueSize4<T>, IVector4<T>>,
    IEqualityOperators<ValueSize4<T>, IVector4<T>>,
    IIncrementOperators<ValueSize4<T>>,
    IUnaryPlusOperators<ValueSize4<T>, ValueSize4<T>>,
    IAdditionOperators<ValueSize4<T>, IVector4<T>, ValueSize4<T>>,
    IAdditionOperators2<IVector4<T>, ValueSize4<T>, IVector4<T>>,
    IDecrementOperators<ValueSize4<T>>,
    IUnaryNegationOperators<ValueSize4<T>, ValueSize4<T>>,
    ISubtractionOperators<ValueSize4<T>, IVector4<T>, ValueSize4<T>>,
    ISubtractionOperators2<IVector4<T>, ValueSize4<T>, IVector4<T>>,
    IMultiplyOperators<ValueSize4<T>, T, ValueSize4<T>>,
    IMultiplyOperators<ValueSize4<T>, ValueSize4<T>, ValueSize4<T>>,
    IMultiplyOperators<ValueSize4<T>, IVector4<T>, ValueSize4<T>>,
    IMultiplyOperators2<IVector4<T>, ValueSize4<T>, IVector4<T>>,
    IDivisionOperators<ValueSize4<T>, T, ValueSize4<T>>,
    IDivisionOperators<ValueSize4<T>, ValueSize4<T>, ValueSize4<T>>,
    IDivisionOperators<ValueSize4<T>, IVector4<T>, ValueSize4<T>>,
    IDivisionOperators2<IVector4<T>, ValueSize4<T>, IVector4<T>>,
    IModulusOperators<ValueSize4<T>, T, ValueSize4<T>>,
    IModulusOperators<ValueSize4<T>, ValueSize4<T>, ValueSize4<T>>,
    IModulusOperators2<IVector4<T>, ValueSize4<T>, IVector4<T>>
    where T : INumber<T>
{
    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="ValueSize4{T}"/> class.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public ValueSize4() : this(T.Zero, T.Zero, T.Zero, T.Zero) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueSize4{T}"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public ValueSize4(IVector4<T> value) => (Width, Height, Depth, Breadth) = value;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueSize4{T}"/> class.
    /// </summary>
    /// <param name="tuple">The tuple.</param>
    public ValueSize4((T Width, T Height, T Depth, T Breadth) tuple) => (Width, Height, Depth, Breadth) = tuple;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueSize4{T}"/> class.
    /// </summary>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    /// <param name="depth">The depth.</param>
    /// <param name="breadth">The breadth.</param>
    public ValueSize4(T width, T height, T depth, T breadth) => (Width, Height, Depth, Breadth) = (width, height, depth, breadth);
    #endregion

    #region Deconstructors
    /// <summary>
    /// Deconstructs the.
    /// </summary>
    /// <param name="Width">The width.</param>
    /// <param name="Height">The height.</param>
    /// <param name="Depth">The depth.</param>
    /// <param name="Breadth">The breadth.</param>
    public void Deconstruct(out T Width, out T Height, out T Depth, out T Breadth) => (Width, Height, Depth, Breadth) = this;
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
    /// Gets or sets the items.
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    public T[] Items { get { return new T[] { Width, Height, Depth, Breadth }; } set { (Width, Height, Depth, Breadth) = (value[0], value[1], value[2], value[3]); } }

    /// <summary>
    /// Gets the count.
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public int Count => 4;

    /// <summary>
    /// Gets the additive identity.
    /// </summary>
    public static ValueSize4<T> AdditiveIdentity => new(T.Zero, T.Zero, T.Zero, T.Zero);

    /// <summary>
    /// Gets the multiplicative identity.
    /// </summary>
    public static ValueSize4<T> MultiplicativeIdentity => new(T.One, T.One, T.One, T.One);
    #endregion

    #region Operators
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator <(ValueSize4<T> left, IVector4<T> right)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator <=(ValueSize4<T> left, IVector4<T> right)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(ValueSize4<T> left, IVector4<T> right) => left.Equals(right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(ValueSize4<T> left, ValueSize4<T> right) => left.Equals(right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(ValueSize4<T> left, IVector4<T> right) => !(left == right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(ValueSize4<T> left, ValueSize4<T> right) => !(left == right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator >(ValueSize4<T> left, IVector4<T> right)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator >=(ValueSize4<T> left, IVector4<T> right)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueSize4<T> operator ++(ValueSize4<T> value) => new(Operations.IncrementVector(value.Width, value.Height, value.Depth, value.Breadth));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueSize4<T> operator checked ++(ValueSize4<T> value) => new(Operations.IncrementVector(value.Width, value.Height, value.Depth, value.Breadth));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueSize4<T> operator +(ValueSize4<T> value) => value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize4<T> operator +(ValueSize4<T> left, IVector4<T> right) => new(Operations.AddVectors(left.Width, left.Height, left.Depth, left.Breadth, right.X, right.Y, right.Z, right.W));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize4<T> operator checked +(ValueSize4<T> left, IVector4<T> right) => new(Operations.AddVectors(left.Width, left.Height, left.Depth, left.Breadth, right.X, right.Y, right.Z, right.W));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static IVector4<T> operator +(IVector4<T> left, ValueSize4<T> right) => new ValuePoint4<T>(Operations.AddVectors(left.X, left.Y, left.Z, left.W, right.Width, right.Height, right.Depth, right.Breadth));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static IVector4<T> operator checked +(IVector4<T> left, ValueSize4<T> right) => new ValuePoint4<T>(Operations.AddVectors(left.X, left.Y, left.Z, left.W, right.Width, right.Height, right.Depth, right.Breadth));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueSize4<T> operator --(ValueSize4<T> value) => new(Operations.DecrementVector(value.Width, value.Height, value.Depth, value.Breadth));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueSize4<T> operator checked --(ValueSize4<T> value) => new(Operations.DecrementVector(value.Width, value.Height, value.Depth, value.Breadth));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueSize4<T> operator -(ValueSize4<T> value) => new(Operations.NegateVector(value.Width, value.Height, value.Depth, value.Breadth));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueSize4<T> operator checked -(ValueSize4<T> value) => new(Operations.NegateVector(value.Width, value.Height, value.Depth, value.Breadth));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize4<T> operator -(ValueSize4<T> left, IVector4<T> right) => new(Operations.SubtractVector(left.Width, left.Height, left.Depth, left.Breadth, right.X, right.Y, right.Z, right.W));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize4<T> operator checked -(ValueSize4<T> left, IVector4<T> right) => new(Operations.SubtractVector(left.Width, left.Height, left.Depth, left.Breadth, right.X, right.Y, right.Z, right.W));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static IVector4<T> operator -(IVector4<T> left, ValueSize4<T> right) => new ValuePoint4<T>(Operations.SubtractVector(left.X, left.Y, left.Z, left.W, right.Width, right.Height, right.Depth, right.Breadth));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static IVector4<T> operator checked -(IVector4<T> left, ValueSize4<T> right) => new ValuePoint4<T>(Operations.SubtractVector(left.X, left.Y, left.Z, left.W, right.Width, right.Height, right.Depth, right.Breadth));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize4<T> operator *(ValueSize4<T> left, T right) => new(Operations.ScaleVector(left.Width, left.Height, left.Depth, left.Breadth, right));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize4<T> operator checked *(ValueSize4<T> left, T right) => new(Operations.ScaleVector(left.Width, left.Height, left.Depth, left.Breadth, right));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize4<T> operator *(ValueSize4<T> left, ValueSize4<T> right) => new(left.Width * right.Width, left.Height * right.Height, left.Depth * right.Depth, left.Breadth * right.Breadth);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize4<T> operator checked *(ValueSize4<T> left, ValueSize4<T> right) => new(left.Width * right.Width, left.Height * right.Height, left.Depth * right.Depth, left.Breadth * right.Breadth);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize4<T> operator *(ValueSize4<T> left, IVector4<T> right) => new(left.Width * right.X, left.Height * right.Y, left.Depth * right.Z, left.Breadth * right.W);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize4<T> operator checked *(ValueSize4<T> left, IVector4<T> right) => new(left.Width * right.X, left.Height * right.Y, left.Depth * right.Z, left.Breadth * right.W);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static IVector4<T> operator *(IVector4<T> left, ValueSize4<T> right) => new ValuePoint4<T>(left.X * right.Width, left.Y * right.Height, left.Z * right.Depth, left.W * right.Breadth);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static IVector4<T> operator checked *(IVector4<T> left, ValueSize4<T> right) => new ValuePoint4<T>(left.X * right.Width, left.Y * right.Height, left.Z * right.Depth, left.W * right.Breadth);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize4<T> operator /(ValueSize4<T> left, T right) => new(left.Width / right, left.Height / right, left.Depth / right, left.Breadth / right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize4<T> operator checked /(ValueSize4<T> left, T right) => new(left.Width / right, left.Height / right, left.Depth / right, left.Breadth / right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize4<T> operator /(ValueSize4<T> left, ValueSize4<T> right) => new(left.Width / right.Width, left.Height / right.Height, left.Depth / right.Depth, left.Breadth / right.Breadth);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize4<T> operator checked /(ValueSize4<T> left, ValueSize4<T> right) => new(left.Width / right.Width, left.Height / right.Height, left.Depth / right.Depth, left.Breadth / right.Breadth);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize4<T> operator /(ValueSize4<T> left, IVector4<T> right) => new(left.Width / right.X, left.Height / right.Y, left.Depth / right.Z, left.Breadth / right.W);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize4<T> operator checked /(ValueSize4<T> left, IVector4<T> right) => new(left.Width / right.X, left.Height / right.Y, left.Depth / right.Z, left.Breadth / right.W);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static IVector4<T> operator /(IVector4<T> left, ValueSize4<T> right) => new ValuePoint4<T>(left.X / right.Width, left.Y / right.Height, left.Z / right.Depth, left.W / right.Breadth);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static IVector4<T> operator checked /(IVector4<T> left, ValueSize4<T> right) => new ValuePoint4<T>(left.X / right.Width, left.Y / right.Height, left.Z / right.Depth, left.W / right.Breadth);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize4<T> operator %(ValueSize4<T> left, T right) => new(left.Width % right, left.Height % right, left.Depth % right, left.Breadth % right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueSize4<T> operator %(ValueSize4<T> left, ValueSize4<T> right) => new(left.Width % right.Width, left.Height % right.Height, left.Depth % right.Depth, left.Breadth % right.Breadth);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static IVector4<T> operator %(IVector4<T> left, ValueSize4<T> right) => new ValuePoint4<T>(left.X % right.Width, left.Y % right.Height, left.Z % right.Depth, left.W % right.Breadth);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public static implicit operator ValueSize4<T>(ValueVector4<T> value) => new(value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public static implicit operator ValueSize4<T>(ValuePoint4<T> value) => new(value);
    #endregion

    /// <summary>
    /// Gets the hash code.
    /// </summary>
    /// <returns>An int.</returns>
    public override int GetHashCode() => HashCode.Combine(Width, Height, Depth, Breadth);

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
    public int CompareTo(IVector4<T>? other) => throw new NotImplementedException();

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="obj">The obj.</param>
    /// <returns>A bool.</returns>
    public override bool Equals(object? obj) => obj is ValueSize4<T> size && Equals(size);

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>A bool.</returns>
    public bool Equals(ValueSize4<T> other) => Width.Equals(other.Width) && Height.Equals(other.Height) && Depth.Equals(other.Depth) && Breadth.Equals(other.Breadth);

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>A bool.</returns>
    public bool Equals(IVector4<T>? other) => other is IVector4<T> size && Width.Equals(size.X) && Height.Equals(size.Y) && Depth.Equals(size.Z) && Breadth.Equals(size.W);

    /// <summary>
    /// Parses the.
    /// </summary>
    /// <param name="source">The s.</param>
    /// <param name="formatProvider">The provider.</param>
    /// <returns>A ValueSize4.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static ValueSize4<T> Parse(string source, IFormatProvider? formatProvider) => Parse((ReadOnlySpan<char>)source, formatProvider);

    /// <summary>
    /// Parses the.
    /// </summary>
    /// <param name="source">The s.</param>
    /// <param name="formatProvider">The provider.</param>
    /// <returns>A ValueSize4.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static ValueSize4<T> Parse(ReadOnlySpan<char> source, IFormatProvider? formatProvider) => TryParse(source, formatProvider, out var result) ? result : result;

    /// <summary>
    /// Tries the parse.
    /// </summary>
    /// <param name="source">The s.</param>
    /// <param name="formatProvider">The provider.</param>
    /// <param name="result">The result.</param>
    /// <returns>A bool.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool TryParse([NotNullWhen(true)] string? source, IFormatProvider? formatProvider, out ValueSize4<T> result) => TryParse((ReadOnlySpan<char>)source, formatProvider, out result);

    /// <summary>
    /// Tries the parse.
    /// </summary>
    /// <param name="source">The s.</param>
    /// <param name="formatProvider">The provider.</param>
    /// <param name="result">The result.</param>
    /// <returns>A bool.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool TryParse(ReadOnlySpan<char> source, IFormatProvider? formatProvider, out ValueSize4<T> result)
    {
        var tokenizer = new Tokenizer(source, formatProvider);
        var firstToken = tokenizer.NextTokenRequired();

        T.TryParse(firstToken, formatProvider, out var result1);
        T.TryParse(tokenizer.NextTokenRequired(), formatProvider, out var result2);
        T.TryParse(tokenizer.NextTokenRequired(), formatProvider, out var result3);
        T.TryParse(tokenizer.NextTokenRequired(), formatProvider, out var result4);
        var value = new ValueSize4<T>(result1, result2, result3, result4);

        // There should be no more tokens in this string.
        tokenizer.LastTokenRequired();
        result = value;
        return true;
    }

    /// <summary>
    /// Creates a human-readable string that represents this <see cref="ValueSize4{T}" /> struct.
    /// </summary>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public override string? ToString() => ToString("R", CultureInfo.InvariantCulture);

    /// <summary>
    /// Creates a string representation of this <see cref="ValueSize4{T}" /> struct based on the IFormatProvider
    /// passed in.  If the provider is null, the CurrentCulture is used.
    /// </summary>
    /// <param name="formatProvider">The format provider.</param>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public string ToString(IFormatProvider formatProvider) => ToString("R", formatProvider);

    /// <summary>
    /// Creates a string representation of this <see cref="ValueSize4{T}" /> struct based on the IFormatProvider
    /// passed in.  If the provider is null, the CurrentCulture is used.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="formatProvider">The format provider.</param>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(ValueSize4<T>)}: ({nameof(Width)}: {Width.ToString(format, formatProvider)}, {nameof(Height)}: {Height.ToString(format, formatProvider)}, {nameof(Depth)}: {Depth.ToString(format, formatProvider)}, {nameof(Breadth)}: {Breadth.ToString(format, formatProvider)})";

    /// <summary>
    /// Gets the debugger display.
    /// </summary>
    /// <returns>
    /// A string representation of this object for display in the debugger.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private string? GetDebuggerDisplay() => ToString();
}
