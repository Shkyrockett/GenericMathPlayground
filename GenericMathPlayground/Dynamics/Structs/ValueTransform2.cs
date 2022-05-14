// <copyright file="ValueTransform2.cs" company="Shkyrockett" >
//     Copyright © 2021 - 2022 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using GenericMathPlayground.Geometry;
using GenericMathPlayground.Mathematics;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace GenericMathPlayground.Dynamics;

/// <summary>
/// The value transform2.
/// </summary>
/// <typeparam name="T"></typeparam>
[TypeConverter(typeof(ExpandableObjectConverter))]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public struct ValueTransform2<T>
    : IMatrix<T>, IMatrix2Columns<T, ValueVector3<T>>, IMatrix3Rows<T, ValueVector2<T>>,
    IFormattable,
    IParsable<ValueTransform2<T>>,
    ISpanParsable<ValueTransform2<T>>,
    IEquatable<ValueTransform2<T>>,
    IAdditiveIdentity<ValueTransform2<T>, ValueTransform2<T>>,
    IMultiplicativeIdentity<ValueTransform2<T>, ValueTransform2<T>>,
    IEqualityOperators<ValueTransform2<T>, ValueTransform2<T>>,
    IUnaryPlusOperators<ValueTransform2<T>, ValueTransform2<T>>,
    IAdditionOperators<ValueTransform2<T>, ValueTransform2<T>, ValueTransform2<T>>,
    IUnaryNegationOperators<ValueTransform2<T>, ValueTransform2<T>>,
    ISubtractionOperators<ValueTransform2<T>, ValueTransform2<T>, ValueTransform2<T>>,
    IMultiplyOperators<ValueTransform2<T>, T, ValueTransform2<T>>,
    IMultiplyOperators2<T, ValueTransform2<T>, ValueTransform2<T>>,
    IMultiplyOperators<ValueTransform2<T>, IVector2<T>, ValueVector3<T>>,
    IMultiplyOperators2<IVector3<T>, ValueTransform2<T>, ValueVector2<T>>
    where T : INumber<T>
{
    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="ValueTransform2{T}"/> class.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public ValueTransform2() : this(
        T.Zero, T.Zero,
        T.Zero, T.One,
        T.One, T.One
        )
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueTransform2{T}"/> class.
    /// </summary>
    /// <param name="location">The location.</param>
    /// <param name="skew">The skew.</param>
    /// <param name="scale">The scale.</param>
    public ValueTransform2(IVector2<T> location, IVector2<T> skew, IVector2<T> scale) => (
        X, Y,
        I, J,
        Width, Height
        ) = (
        location.X, location.Y,
        skew.X, skew.Y,
        scale.X, scale.Y
        );

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueTransform2{T}"/> class.
    /// </summary>
    /// <param name="location">The location.</param>
    /// <param name="skew">The skew.</param>
    /// <param name="scale">The scale.</param>
    public ValueTransform2(IPoint2<T> location, IVector2<T> skew, ISize2<T> scale) => (
        X, Y,
        I, J,
        Width, Height
        ) = (
        location.X, location.Y,
        skew.X, skew.Y,
        scale.Width, scale.Height
        );

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueTransform2{T}"/> class.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    public ValueTransform2(ValueMatrix2x3<T> matrix) => (
        X, Y,
        I, J,
        Width, Height
        ) = (
        matrix.M1x1, matrix.M1x2,
        matrix.M2x1, matrix.M2x2,
        matrix.M3x1, matrix.M3x2
        );

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueTransform2{T}"/> class.
    /// </summary>
    /// <param name="transform">The transform.</param>
    public ValueTransform2(ValueTransform2<T> transform) => (
        X, Y,
        I, J,
        Width, Height
        ) = (
        transform.X, transform.Y,
        transform.I, transform.J,
        transform.Width, transform.Height
        );

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueTransform2{T}"/> class.
    /// </summary>
    /// <param name="location">The location.</param>
    /// <param name="skew">The skew.</param>
    /// <param name="scale">The scale.</param>
    public ValueTransform2(
        (T m1x1, T m1x2) location,
        (T m2x1, T m2x2) skew,
        (T m3x1, T m3x2) scale) => (
        (X, Y),
        (I, J),
        (Width, Height)
        ) = (
        location,
        skew,
        scale
        );

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueTransform2{T}"/> class.
    /// </summary>
    /// <param name="tuple">The tuple.</param>
    public ValueTransform2((
        T X, T Y,
        T I, T J,
        T Width, T Height
        ) tuple) => (
        X, Y,
        I, J,
        Width, Height
        ) = tuple;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueTransform2{T}"/> class.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <param name="i">The i.</param>
    /// <param name="j">The j.</param>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    public ValueTransform2(
        T x, T y,
        T i, T j,
        T width, T height
        ) => (
        X, Y,
        I, J,
        Width, Height
        ) = (
        x, y,
        i, j,
        width, height
        );
    #endregion

    #region Deconstructors
    /// <summary>
    /// Deconstructs the.
    /// </summary>
    /// <param name="location">The location.</param>
    /// <param name="skew">The skew.</param>
    /// <param name="scale">The scale.</param>
    public void Deconstruct(
        out ValuePoint2<T> location,
        out ValueVector2<T> skew,
        out ValueSize2<T> scale
        ) => (location, skew, scale) = (
        new(X, Y),
        new(I, J),
        new(Width, Height)
        );

    /// <summary>
    /// Deconstructs the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <param name="i">The i.</param>
    /// <param name="j">The j.</param>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    public void Deconstruct(
        out T x, out T y,
        out T i, out T j,
        out T width, out T height
        ) => (
        x, y,
        i, j,
        width, height
        ) = (
        X, Y,
        I, J,
        Width, Height
        );
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
    /// Gets or sets the location.
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    public ValuePoint2<T> Location { get => new(X, Y); set => (X, Y) = value; }

    /// <summary>
    /// Gets or sets the skew.
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    public ValueVector2<T> Skew { get => new(X, Y); set => (I, J) = value; }

    /// <summary>
    /// Gets or sets the scale.
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    public ValueSize2<T> Scale { get => new(X, Y); set => (Width, Height) = value; }

    /// <summary>
    /// Gets or sets the rotation.
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    public T Rotation
    {
        get => J;
        set
        {
            var delta = value - J;
            I += delta;
            J += delta;
        }
    }

    /// <summary>
    /// Gets or sets the items.
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    public T[,] Items
    {
        get
        {
            return new T[,] {
                    { X, Y },
                    { I, J },
                    { Width, Height }
                };
        }
        set
        {
            (
                X, Y,
                I, J,
                Width, Height
            ) = (
                value[0, 0], value[0, 1],
                value[1, 0], value[1, 1],
                value[2, 0], value[2, 1]
            );
        }
    }

    /// <summary>
    /// Gets the rows.
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public int Rows => 3;

    /// <summary>
    /// Gets the columns.
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public int Columns => 2;

    /// <summary>
    /// Gets or sets the column x.
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    [Description("The First column of the " + nameof(ValueTransform2<T>))]
    ValueVector3<T> IMatrix2Columns<T, ValueVector3<T>>.ColumnX { get { return new ValueVector3<T>(X, I, Width); } set { (X, I, Width) = value; } }

    /// <summary>
    /// Gets or sets the column y.
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    [Description("The Second column of the " + nameof(ValueTransform2<T>))]
    ValueVector3<T> IMatrix2Columns<T, ValueVector3<T>>.ColumnY { get { return new ValueVector3<T>(Y, J, Height); } set { (Y, J, Height) = value; } }

    /// <summary>
    /// Gets or sets the row z.
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    [Description("The First row of the " + nameof(ValueTransform2<T>))]
    ValueVector2<T> IMatrix3Rows<T, ValueVector2<T>>.RowZ { get { return new ValueVector2<T>(X, Y); } set { (X, Y) = value; } }

    /// <summary>
    /// Gets or sets the row x.
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    [Description("The Second row of the " + nameof(ValueTransform2<T>))]
    ValueVector2<T> IMatrix2Rows<T, ValueVector2<T>>.RowX { get { return new ValueVector2<T>(I, J); } set { (I, J) = value; } }

    /// <summary>
    /// Gets or sets the row y.
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    [Description("The Third row of the " + nameof(ValueTransform2<T>))]
    ValueVector2<T> IMatrix2Rows<T, ValueVector2<T>>.RowY { get { return new ValueVector2<T>(Width, Height); } set { (Width, Height) = value; } }

    /// <summary>
    /// Gets the determinant.
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public T Determinant => Operations.MatrixDeterminant(X, Y, T.Zero, I, J, T.Zero, Width, Height, T.One);

    /// <summary>
    /// Gets the additive identity.
    /// </summary>
    public static ValueTransform2<T> AdditiveIdentity => new(
        T.Zero, T.Zero,
        T.Zero, T.Zero,
        T.Zero, T.Zero
        );

    /// <summary>
    /// Gets the multiplicative identity.
    /// </summary>
    public static ValueTransform2<T> MultiplicativeIdentity => new(
        T.One, T.Zero,
        T.Zero, T.One,
        T.One, T.One
        );
    #endregion

    #region Operators
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(ValueTransform2<T> left, ValueTransform2<T> right) => left.Equals(right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(ValueTransform2<T> left, ValueTransform2<T> right) => !(left == right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueTransform2<T> operator +(ValueTransform2<T> value) => value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueTransform2<T> operator +(ValueTransform2<T> left, ValueTransform2<T> right) => Operations.AddMatrix(
            left.X, left.Y,
            left.I, left.J,
            left.Width, left.Height,
            right.X, right.Y,
            right.I, right.J,
            right.Width, right.Height
            );

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueTransform2<T> operator checked +(ValueTransform2<T> left, ValueTransform2<T> right) => Operations.AddMatrix(
            left.X, left.Y,
            left.I, left.J,
            left.Width, left.Height,
            right.X, right.Y,
            right.I, right.J,
            right.Width, right.Height
            );

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueTransform2<T> operator -(ValueTransform2<T> value) => new(Operations.NegateMatrix(
            value.X, value.Y,
            value.I, value.J,
            value.Width, value.Height
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueTransform2<T> operator checked -(ValueTransform2<T> value) => new(Operations.NegateMatrix(
            value.X, value.Y,
            value.I, value.J,
            value.Width, value.Height
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueTransform2<T> operator -(ValueTransform2<T> left, ValueTransform2<T> right) => Operations.SubtractMatrix(
            left.X, left.Y,
            left.I, left.J,
            left.Width, left.Height,
            right.X, right.Y,
            right.I, right.J,
            right.Width, right.Height
            );

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueTransform2<T> operator checked -(ValueTransform2<T> left, ValueTransform2<T> right) => Operations.SubtractMatrix(
            left.X, left.Y,
            left.I, left.J,
            left.Width, left.Height,
            right.X, right.Y,
            right.I, right.J,
            right.Width, right.Height
            );

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueTransform2<T> operator *(ValueTransform2<T> left, T right) => new(Operations.ScaleMatrixRight(
            left.X, left.Y,
            left.I, left.J,
            left.Width, left.Height, right));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueTransform2<T> operator checked *(ValueTransform2<T> left, T right) => new(Operations.ScaleMatrixRight(
            left.X, left.Y,
            left.I, left.J,
            left.Width, left.Height, right));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueTransform2<T> operator *(T left, ValueTransform2<T> right) => new(Operations.ScaleMatrixLeft(left,
            right.X, right.Y,
            right.I, right.J,
            right.Width, right.Height));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueTransform2<T> operator checked *(T left, ValueTransform2<T> right) => new(Operations.ScaleMatrixLeft(left,
            right.X, right.Y,
            right.I, right.J,
            right.Width, right.Height));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector3<T> operator *(ValueTransform2<T> left, IVector2<T> right) => new(Operations.MultiplyMatrixVector(
            left.X, left.Y,
            left.I, left.J,
            left.Width, left.Height,
            right.X, right.Y
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector3<T> operator checked *(ValueTransform2<T> left, IVector2<T> right) => new(Operations.MultiplyMatrixVector(
            left.X, left.Y,
            left.I, left.J,
            left.Width, left.Height,
            right.X, right.Y
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static ValueVector2<T> operator *(IVector3<T> left, ValueTransform2<T> right) => new(Operations.MultiplyVectorMatrix(
            left.X, left.Y, left.Z,
            right.X, right.Y,
            right.I, right.J,
            right.Width, right.Height
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector2<T> operator checked *(IVector3<T> left, ValueTransform2<T> right) => new(Operations.MultiplyVectorMatrix(
            left.X, left.Y, left.Z,
            right.X, right.Y,
            right.I, right.J,
            right.Width, right.Height
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="matrix"></param>
    public static implicit operator ValueMatrix<T>(ValueTransform2<T> matrix) => new(matrix);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="transform"></param>
    public static implicit operator ValueTransform2<T>((
        T x, T y,
        T i, T j,
        T width, T height
        ) transform) => new(transform);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="transform"></param>
    public static implicit operator ValueTransform2<T>((
        (T X, T Y) location,
        (T I, T J) skew,
        (T Width, T Height) scale) transform
        ) => new(
            transform.location,
            transform.skew,
            transform.scale
            );

    /// <summary>
    /// 
    /// </summary>
    /// <param name="matrix"></param>
    public static implicit operator ValueTransform2<T>(ValueMatrix2x3<T> matrix) => new(matrix);
    #endregion

    /// <summary>
    /// Gets the hash code.
    /// </summary>
    /// <returns>An int.</returns>
    public override int GetHashCode() => HashCode.Combine(X, Y, I, J, Width, Height);

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="obj">The obj.</param>
    /// <returns>A bool.</returns>
    public override bool Equals(object? obj) => obj is ValueTransform2<T> matrix && Equals(matrix);

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>A bool.</returns>
    public bool Equals(ValueTransform2<T> other)
        => X.Equals(other.X) && Y.Equals(other.Y) &&
           I.Equals(other.I) && J.Equals(other.J) &&
           Width.Equals(other.Width) && Height.Equals(other.Height);

    /// <summary>
    /// Parses the.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="provider">The provider.</param>
    /// <returns>A ValueTransform2.</returns>
    public static ValueTransform2<T> Parse(string s, IFormatProvider? provider)
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
    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out ValueTransform2<T> result)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Parses the.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="provider">The provider.</param>
    /// <returns>A ValueTransform2.</returns>
    public static ValueTransform2<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
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
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out ValueTransform2<T> result)
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
    public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(ValueTransform2<T>)}: ({X.ToString(format, formatProvider)}, {Y.ToString(format, formatProvider)}, {I.ToString(format, formatProvider)}, {J.ToString(format, formatProvider)}, {Width.ToString(format, formatProvider)}, {Height.ToString(format, formatProvider)})";

    /// <summary>
    /// Gets the debugger display.
    /// </summary>
    /// <returns>A string? .</returns>
    private string? GetDebuggerDisplay() => ToString();
}
