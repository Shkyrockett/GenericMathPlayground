// <copyright file="ValueSize3.cs" company="Shkyrockett" >
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
/// The value size3.
/// </summary>
/// <typeparam name="T"></typeparam>
[TypeConverter(typeof(ExpandableObjectConverter))]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public struct ValueSize3<T>
    : ISize3<T>,
    IFormattable,
    IParsable<ValueSize3<T>>,
    ISpanParsable<ValueSize3<T>>,
    IComparable,
    IComparable<IVector3<T>>,
    IEquatable<ValueSize3<T>>,
    IAdditiveIdentity<ValueSize3<T>, ValueSize3<T>>,
    IMultiplicativeIdentity<ValueSize3<T>, ValueSize3<T>>,
    IComparisonOperators<ValueSize3<T>, IVector3<T>, bool>,
    IEqualityOperators<ValueSize3<T>, IVector3<T>, bool>,
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
    /// Initializes a new instance of the <see cref="ValueSize3{T}"/> class.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public ValueSize3() : this(T.Zero, T.Zero, T.Zero) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueSize3{T}"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public ValueSize3(IVector3<T> value) => (Width, Height, Depth) = value;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueSize3{T}"/> class.
    /// </summary>
    /// <param name="tuple">The tuple.</param>
    public ValueSize3((T Width, T Height, T Depth) tuple) => (Width, Height, Depth) = tuple;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueSize3{T}"/> class.
    /// </summary>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    /// <param name="depth">The depth.</param>
    public ValueSize3(T width, T height, T depth) => (Width, Height, Depth) = (width, height, depth);
    #endregion

    #region Deconstructors
    /// <summary>
    /// Deconstructs the.
    /// </summary>
    /// <param name="Width">The width.</param>
    /// <param name="Height">The height.</param>
    /// <param name="Depth">The depth.</param>
    public void Deconstruct(out T Width, out T Height, out T Depth) => (Width, Height, Depth) = this;
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
    /// Gets or sets the items.
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    public T[] Items { get { return new T[] { Width, Height, Depth }; } set { (Width, Height, Depth) = (value[0], value[1], value[2]); } }

    /// <summary>
    /// Gets the count.
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public int Count => 3;

    /// <summary>
    /// Gets the additive identity.
    /// </summary>
    public static ValueSize3<T> AdditiveIdentity => new(T.Zero, T.Zero, T.Zero);

    /// <summary>
    /// Gets the multiplicative identity.
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
    public static ValueSize3<T> operator checked ++(ValueSize3<T> value) => new(++value.Width, ++value.Height, ++value.Depth);

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
    public static ValueSize3<T> operator checked +(ValueSize3<T> left, IVector3<T> right) => new(left.Width + right.X, left.Height + right.Y, left.Depth + right.Z);

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
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static IVector3<T> operator checked +(IVector3<T> left, ValueSize3<T> right) => new ValuePoint3<T>(left.X + right.Width, left.Y + right.Height, left.Z + right.Depth);

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
    public static ValueSize3<T> operator checked --(ValueSize3<T> value) => new(--value.Width, --value.Height, --value.Depth);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueSize3<T> operator -(ValueSize3<T> value) => new(-value.Width, -value.Height, -value.Depth);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueSize3<T> operator checked -(ValueSize3<T> value) => new(-value.Width, -value.Height, -value.Depth);

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
    public static ValueSize3<T> operator checked -(ValueSize3<T> left, IVector3<T> right) => new(left.Width - right.X, left.Height - right.Y, left.Depth - right.Z);

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
    public static IVector3<T> operator checked -(IVector3<T> left, ValueSize3<T> right) => new ValuePoint3<T>(left.X - right.Width, left.Y - right.Height, left.Z - right.Depth);

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
    public static ValueSize3<T> operator checked *(ValueSize3<T> left, T right) => new(left.Width * right, left.Height * right, left.Depth * right);

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
    public static ValueSize3<T> operator checked *(ValueSize3<T> left, ValueSize3<T> right) => new(left.Width * right.Width, left.Height * right.Height, left.Depth * right.Depth);

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
    public static ValueSize3<T> operator checked *(ValueSize3<T> left, IVector3<T> right) => new(left.Width * right.X, left.Height * right.Y, left.Depth * right.Z);

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
    public static IVector3<T> operator checked *(IVector3<T> left, ValueSize3<T> right) => new ValuePoint3<T>(left.X * right.Width, left.Y * right.Height, left.Z * right.Depth);

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
    public static ValueSize3<T> operator checked /(ValueSize3<T> left, T right) => new(left.Width / right, left.Height / right, left.Depth / right);

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
    public static ValueSize3<T> operator checked /(ValueSize3<T> left, ValueSize3<T> right) => new(left.Width / right.Width, left.Height / right.Height, left.Depth / right.Depth);

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
    public static ValueSize3<T> operator checked /(ValueSize3<T> left, IVector3<T> right) => new(left.Width / right.X, left.Height / right.Y, left.Depth / right.Z);

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
    public static IVector3<T> operator checked /(IVector3<T> left, ValueSize3<T> right) => new ValuePoint3<T>(left.X / right.Width, left.Y / right.Height, left.Z / right.Depth);

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
    /// Gets the hash code.
    /// </summary>
    /// <returns>An int.</returns>
    public override int GetHashCode() => HashCode.Combine(Width, Height, Depth);

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
    public override bool Equals(object? obj) => obj is ValueSize3<T> size && Equals(size);

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>A bool.</returns>
    public bool Equals(ValueSize3<T> other) => Width.Equals(other.Width) && Height.Equals(other.Height) && Depth.Equals(other.Depth);

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>A bool.</returns>
    public bool Equals(IVector3<T>? other) => other is IVector3<T> size && Width.Equals(size.X) && Height.Equals(size.Y) && Depth.Equals(size.Z);

    /// <summary>
    /// Parses the.
    /// </summary>
    /// <param name="source">The s.</param>
    /// <param name="formatProvider">The provider.</param>
    /// <returns>A ValueSize3.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static ValueSize3<T> Parse(string source, IFormatProvider? formatProvider) => Parse((ReadOnlySpan<char>)source, formatProvider);

    /// <summary>
    /// Parses the.
    /// </summary>
    /// <param name="source">The s.</param>
    /// <param name="formatProvider">The provider.</param>
    /// <returns>A ValueSize3.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static ValueSize3<T> Parse(ReadOnlySpan<char> source, IFormatProvider? formatProvider) => TryParse(source, formatProvider, out var result) ? result : result;

    /// <summary>
    /// Tries the parse.
    /// </summary>
    /// <param name="source">The s.</param>
    /// <param name="formatProvider">The provider.</param>
    /// <param name="result">The result.</param>
    /// <returns>A bool.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool TryParse([NotNullWhen(true)] string? source, IFormatProvider? formatProvider, out ValueSize3<T> result) => TryParse((ReadOnlySpan<char>)source, formatProvider, out result);

    /// <summary>
    /// Tries the parse.
    /// </summary>
    /// <param name="source">The s.</param>
    /// <param name="formatProvider">The provider.</param>
    /// <param name="result">The result.</param>
    /// <returns>A bool.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool TryParse(ReadOnlySpan<char> source, IFormatProvider? formatProvider, out ValueSize3<T> result)
    {
        var tokenizer = new Tokenizer(source, formatProvider);
        var firstToken = tokenizer.NextTokenRequired();

        T.TryParse(firstToken, formatProvider, out var result1);
        T.TryParse(tokenizer.NextTokenRequired(), formatProvider, out var result2);
        T.TryParse(tokenizer.NextTokenRequired(), formatProvider, out var result3);
        var value = new ValueSize3<T>(result1, result2, result3);

        // There should be no more tokens in this string.
        tokenizer.LastTokenRequired();
        result = value;
        return true;
    }

    /// <summary>
    /// Creates a human-readable string that represents this <see cref="ValueSize3{T}" /> struct.
    /// </summary>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public override string? ToString() => ToString("R", CultureInfo.InvariantCulture);

    /// <summary>
    /// Creates a string representation of this <see cref="ValueSize3{T}" /> struct based on the IFormatProvider
    /// passed in.  If the provider is null, the CurrentCulture is used.
    /// </summary>
    /// <param name="formatProvider">The format provider.</param>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public string ToString(IFormatProvider formatProvider) => ToString("R", formatProvider);

    /// <summary>
    /// Creates a string representation of this <see cref="ValueSize3{T}" /> struct based on the IFormatProvider
    /// passed in.  If the provider is null, the CurrentCulture is used.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="formatProvider">The format provider.</param>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(ValueSize3<T>)}: ({nameof(Width)}: {Width.ToString(format, formatProvider)}, {nameof(Height)}: {Height.ToString(format, formatProvider)}, {nameof(Depth)}: {Depth.ToString(format, formatProvider)})";

    /// <summary>
    /// Gets the debugger display.
    /// </summary>
    /// <returns>
    /// A string representation of this object for display in the debugger.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private string? GetDebuggerDisplay() => ToString();
}
