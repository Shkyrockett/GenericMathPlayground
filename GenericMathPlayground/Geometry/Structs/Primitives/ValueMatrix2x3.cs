// <copyright file="ValueMatrix2x3.cs" company="Shkyrockett" >
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
/// The value matrix2x3.
/// </summary>
/// <typeparam name="T"></typeparam>
[TypeConverter(typeof(ExpandableObjectConverter))]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public struct ValueMatrix2x3<T>
    : IMatrix<T>, IMatrix2Columns<T, ValueVector3<T>>, IMatrix3Rows<T, ValueVector2<T>>,
    IFormattable,
    IParsable<ValueMatrix2x3<T>>,
    ISpanParsable<ValueMatrix2x3<T>>,
    IEquatable<ValueMatrix2x3<T>>,
    IAdditiveIdentity<ValueMatrix2x3<T>, ValueMatrix2x3<T>>,
    IMultiplicativeIdentity<ValueMatrix2x3<T>, ValueMatrix2x3<T>>,
    IEqualityOperators<ValueMatrix2x3<T>, ValueMatrix2x3<T>>,
    IUnaryPlusOperators<ValueMatrix2x3<T>, ValueMatrix2x3<T>>,
    IAdditionOperators<ValueMatrix2x3<T>, ValueMatrix2x3<T>, ValueMatrix2x3<T>>,
    IUnaryNegationOperators<ValueMatrix2x3<T>, ValueMatrix2x3<T>>,
    ISubtractionOperators<ValueMatrix2x3<T>, ValueMatrix2x3<T>, ValueMatrix2x3<T>>,
    IMultiplyOperators<ValueMatrix2x3<T>, T, ValueMatrix2x3<T>>,
    IMultiplyOperators2<T, ValueMatrix2x3<T>, ValueMatrix2x3<T>>,
    IMultiplyOperators<ValueMatrix2x3<T>, IVector2<T>, ValueVector3<T>>,
    IMultiplyOperators2<IVector3<T>, ValueMatrix2x3<T>, ValueVector2<T>>
    where T : INumber<T>
{
    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="ValueMatrix2x3{T}"/> class.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public ValueMatrix2x3() : this(
        T.One, T.Zero,
        T.Zero, T.One,
        T.Zero, T.Zero
        )
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueMatrix2x3{T}"/> class.
    /// </summary>
    /// <param name="vector1">The vector1.</param>
    /// <param name="vector2">The vector2.</param>
    /// <param name="vector3">The vector3.</param>
    public ValueMatrix2x3(IVector2<T> vector1, IVector2<T> vector2, IVector2<T> vector3) => (
        M1x1, M1x2,
        M2x1, M2x2,
        M3x1, M3x2
        ) = (
        vector1.X, vector1.Y,
        vector2.X, vector2.Y,
        vector3.X, vector3.Y
        );

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueMatrix2x3{T}"/> class.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    public ValueMatrix2x3(ValueMatrix2x3<T> matrix) => (
        M1x1, M1x2,
        M2x1, M2x2,
        M3x1, M3x2
        ) = (
        matrix.M1x1, matrix.M1x2,
        matrix.M2x1, matrix.M2x2,
        matrix.M3x1, matrix.M3x2
        );

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueMatrix2x3{T}"/> class.
    /// </summary>
    /// <param name="tuple1">The tuple1.</param>
    /// <param name="tuple2">The tuple2.</param>
    /// <param name="tuple3">The tuple3.</param>
    public ValueMatrix2x3(
        (T m1x1, T m1x2) tuple1,
        (T m2x1, T m2x2) tuple2,
        (T m3x1, T m3x2) tuple3) => (
        (M1x1, M1x2),
        (M2x1, M2x2),
        (M3x1, M3x2)
        ) = (
        tuple1,
        tuple2,
        tuple3
        );

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueMatrix2x3{T}"/> class.
    /// </summary>
    /// <param name="tuple">The tuple.</param>
    public ValueMatrix2x3((
        T m1x1, T m1x2,
        T m2x1, T m2x2,
        T m3x1, T m3x2
        ) tuple) => (
        M1x1, M1x2,
        M2x1, M2x2,
        M3x1, M3x2
        ) = tuple;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueMatrix2x3{T}"/> class.
    /// </summary>
    /// <param name="m1x1">The m1x1.</param>
    /// <param name="m1x2">The m1x2.</param>
    /// <param name="m2x1">The m2x1.</param>
    /// <param name="m2x2">The m2x2.</param>
    /// <param name="m3x1">The m3x1.</param>
    /// <param name="m3x2">The m3x2.</param>
    public ValueMatrix2x3(
        T m1x1, T m1x2,
        T m2x1, T m2x2,
        T m3x1, T m3x2
        ) => (
        M1x1, M1x2,
        M2x1, M2x2,
        M3x1, M3x2
        ) = (
        m1x1, m1x2,
        m2x1, m2x2,
        m3x1, m3x2
        );
    #endregion

    #region Deconstructors
    /// <summary>
    /// Deconstructs the.
    /// </summary>
    /// <param name="vector1">The vector1.</param>
    /// <param name="vector2">The vector2.</param>
    /// <param name="vector3">The vector3.</param>
    public void Deconstruct(
        out ValueVector2<T> vector1,
        out ValueVector2<T> vector2,
        out ValueVector2<T> vector3
        ) => (vector1, vector2, vector3) = (
        new(M1x1, M1x2),
        new(M2x1, M2x2),
        new(M3x1, M3x2)
        );

    /// <summary>
    /// Deconstructs the.
    /// </summary>
    /// <param name="m1x1">The m1x1.</param>
    /// <param name="m1x2">The m1x2.</param>
    /// <param name="m2x1">The m2x1.</param>
    /// <param name="m2x2">The m2x2.</param>
    /// <param name="m3x1">The m3x1.</param>
    /// <param name="m3x2">The m3x2.</param>
    public void Deconstruct(
        out T m1x1, out T m1x2,
        out T m2x1, out T m2x2,
        out T m3x1, out T m3x2
        ) => (
        m1x1, m1x2,
        m2x1, m2x2,
        m3x1, m3x2
        ) = (
        M1x1, M1x2,
        M2x1, M2x2,
        M3x1, M3x2
        );
    #endregion

    #region Properties
    /// <summary>
    /// Gets or sets the m1x1.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M1x1 { get; set; }

    /// <summary>
    /// Gets or sets the m1x2.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M1x2 { get; set; }

    /// <summary>
    /// Gets or sets the m2x1.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M2x1 { get; set; }

    /// <summary>
    /// Gets or sets the m2x2.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M2x2 { get; set; }

    /// <summary>
    /// Gets or sets the m3x1.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M3x1 { get; set; }

    /// <summary>
    /// Gets or sets the m3x2.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M3x2 { get; set; }

    /// <summary>
    /// Gets or sets the items.
    /// </summary>
    [Browsable(false)]
    [RefreshProperties(RefreshProperties.All)]
    public T[,] Items
    {
        get
        {
            return new T[,] {
                    { M1x1, M1x2 },
                    { M2x1, M2x2 },
                    { M3x1, M3x2 }
                };
        }
        set
        {
            (
                M1x1, M1x2,
                M2x1, M2x2,
                M3x1, M3x2
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
    /// Gets or sets the X-Column.
    /// </summary>
    /// <value>
    /// The cx.
    /// </value>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    [Description("The First column of the " + nameof(ValueMatrix2x3<T>))]
    public ValueVector3<T> ColumnX { get { return new ValueVector3<T>(M1x1, M2x1, M3x1); } set { (M1x1, M2x1, M3x1) = value; } }

    /// <summary>
    /// Gets or sets the Y-Column.
    /// </summary>
    /// <value>
    /// The cy.
    /// </value>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    [Description("The Second column of the " + nameof(ValueMatrix2x3<T>))]
    public ValueVector3<T> ColumnY { get { return new ValueVector3<T>(M1x2, M2x2, M3x2); } set { (M1x2, M2x2, M3x2) = value; } }

    /// <summary>
    /// Gets or sets the X-Row.
    /// </summary>
    /// <value>
    /// The rx.
    /// </value>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    [Description("The First row of the " + nameof(ValueMatrix2x3<T>))]
    public ValueVector2<T> RowX { get { return new ValueVector2<T>(M1x1, M1x2); } set { (M1x1, M1x2) = value; } }

    /// <summary>
    /// Gets or sets the Y-Row.
    /// </summary>
    /// <value>
    /// The ry.
    /// </value>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    [Description("The Second row of the " + nameof(ValueMatrix2x3<T>))]
    public ValueVector2<T> RowY { get { return new ValueVector2<T>(M2x1, M2x2); } set { (M2x1, M2x2) = value; } }

    /// <summary>
    /// Gets or sets the Z-Row.
    /// </summary>
    /// <value>
    /// The rz.
    /// </value>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    [Description("The Third row of the " + nameof(ValueMatrix2x3<T>))]
    public ValueVector2<T> RowZ { get { return new ValueVector2<T>(M3x1, M3x2); } set { (M3x1, M3x2) = value; } }

    /// <summary>
    /// Gets the determinant.
    /// </summary>
    /// <value>
    /// The determinant.
    /// </value>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public T Determinant => Operations.MatrixDeterminant(M1x1, M1x2, T.Zero, M2x1, M2x2, T.Zero, M3x1, M3x2, T.One);

    /// <summary>
    /// Gets the additive identity.
    /// </summary>
    public static ValueMatrix2x3<T> AdditiveIdentity => new(
        T.Zero, T.Zero,
        T.Zero, T.Zero,
        T.Zero, T.Zero
        );

    /// <summary>
    /// Gets the multiplicative identity.
    /// </summary>
    public static ValueMatrix2x3<T> MultiplicativeIdentity => new(
        T.One, T.Zero,
        T.Zero, T.One,
        T.Zero, T.Zero
        );
    #endregion

    #region Operators
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(ValueMatrix2x3<T> left, ValueMatrix2x3<T> right) => left.Equals(right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(ValueMatrix2x3<T> left, ValueMatrix2x3<T> right) => !(left == right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueMatrix2x3<T> operator +(ValueMatrix2x3<T> value) => value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix2x3<T> operator +(ValueMatrix2x3<T> left, ValueMatrix2x3<T> right) => Operations.AddMatrix(
            left.M1x1, left.M1x2,
            left.M2x1, left.M2x2,
            left.M3x1, left.M3x2,
            right.M1x1, right.M1x2,
            right.M2x1, right.M2x2,
            right.M3x1, right.M3x2
            );

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix2x3<T> operator checked +(ValueMatrix2x3<T> left, ValueMatrix2x3<T> right) => Operations.AddMatrix(
            left.M1x1, left.M1x2,
            left.M2x1, left.M2x2,
            left.M3x1, left.M3x2,
            right.M1x1, right.M1x2,
            right.M2x1, right.M2x2,
            right.M3x1, right.M3x2
            );

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueMatrix2x3<T> operator -(ValueMatrix2x3<T> value) => new(Operations.NegateMatrix(
            value.M1x1, value.M1x2,
            value.M2x1, value.M2x2,
            value.M3x1, value.M3x2
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueMatrix2x3<T> operator checked -(ValueMatrix2x3<T> value) => new(Operations.NegateMatrix(
            value.M1x1, value.M1x2,
            value.M2x1, value.M2x2,
            value.M3x1, value.M3x2
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix2x3<T> operator -(ValueMatrix2x3<T> left, ValueMatrix2x3<T> right) => Operations.SubtractMatrix(
            left.M1x1, left.M1x2,
            left.M2x1, left.M2x2,
            left.M3x1, left.M3x2,
            right.M1x1, right.M1x2,
            right.M2x1, right.M2x2,
            right.M3x1, right.M3x2
            );

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix2x3<T> operator checked -(ValueMatrix2x3<T> left, ValueMatrix2x3<T> right) => Operations.SubtractMatrix(
            left.M1x1, left.M1x2,
            left.M2x1, left.M2x2,
            left.M3x1, left.M3x2,
            right.M1x1, right.M1x2,
            right.M2x1, right.M2x2,
            right.M3x1, right.M3x2
            );

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix2x3<T> operator *(ValueMatrix2x3<T> left, T right) => new(Operations.ScaleMatrixRight(
            left.M1x1, left.M1x2,
            left.M2x1, left.M2x2,
            left.M3x1, left.M3x2, right));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix2x3<T> operator checked *(ValueMatrix2x3<T> left, T right) => new(Operations.ScaleMatrixRight(
            left.M1x1, left.M1x2,
            left.M2x1, left.M2x2,
            left.M3x1, left.M3x2, right));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix2x3<T> operator *(T left, ValueMatrix2x3<T> right) => new(Operations.ScaleMatrixLeft(left,
            right.M1x1, right.M1x2,
            right.M2x1, right.M2x2,
            right.M3x1, right.M3x2));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix2x3<T> operator checked *(T left, ValueMatrix2x3<T> right) => new(Operations.ScaleMatrixLeft(left,
            right.M1x1, right.M1x2,
            right.M2x1, right.M2x2,
            right.M3x1, right.M3x2));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static ValueVector3<T> operator *(ValueMatrix2x3<T> left, IVector2<T> right) => new(Operations.MultiplyMatrixVector(
            left.M1x1, left.M1x2,
            left.M2x1, left.M2x2,
            left.M3x1, left.M3x2,
            right.X, right.Y
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector3<T> operator checked *(ValueMatrix2x3<T> left, IVector2<T> right) => new(Operations.MultiplyMatrixVector(
            left.M1x1, left.M1x2,
            left.M2x1, left.M2x2,
            left.M3x1, left.M3x2,
            right.X, right.Y
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static ValueVector2<T> operator *(IVector3<T> left, ValueMatrix2x3<T> right) => new(Operations.MultiplyVectorMatrix(
            left.X, left.Y, left.Z,
            right.M1x1, right.M1x2,
            right.M2x1, right.M2x2,
            right.M3x1, right.M3x2
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector2<T> operator checked *(IVector3<T> left, ValueMatrix2x3<T> right) => new(Operations.MultiplyVectorMatrix(
            left.X, left.Y, left.Z,
            right.M1x1, right.M1x2,
            right.M2x1, right.M2x2,
            right.M3x1, right.M3x2
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="matrix"></param>
    public static implicit operator ValueMatrix<T>(ValueMatrix2x3<T> matrix) => new(matrix);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tuple"></param>
    public static implicit operator ValueMatrix2x3<T>((
        T m1x1, T m1x2,
        T m2x1, T m2x2,
        T m3x1, T m3x2
        ) tuple) => new(tuple);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tuple"></param>
    public static implicit operator ValueMatrix2x3<T>((
        (T m1x1, T m1x2) tuple1,
        (T m2x1, T m2x2) tuple2,
        (T m3x1, T m3x2) tuple3) tuple
        ) => new(
            tuple.tuple1,
            tuple.tuple2,
            tuple.tuple3
            );
    #endregion

    /// <summary>
    /// Gets the hash code.
    /// </summary>
    /// <returns>An int.</returns>
    public override int GetHashCode() => HashCode.Combine(M1x1, M1x2, M2x1, M2x2, M3x1, M3x2);

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="obj">The obj.</param>
    /// <returns>A bool.</returns>
    public override bool Equals(object? obj) => obj is ValueMatrix2x3<T> matrix && Equals(matrix);

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>A bool.</returns>
    public bool Equals(ValueMatrix2x3<T> other)
        => M1x1.Equals(other.M1x1) && M1x2.Equals(other.M1x2) &&
           M2x1.Equals(other.M2x1) && M2x2.Equals(other.M2x2) &&
           M3x1.Equals(other.M3x1) && M3x2.Equals(other.M3x2);

    /// <summary>
    /// Parses the.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="provider">The provider.</param>
    /// <returns>A ValueMatrix2x3.</returns>
    public static ValueMatrix2x3<T> Parse(string s, IFormatProvider? provider)
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
    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out ValueMatrix2x3<T> result)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Parses the.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="provider">The provider.</param>
    /// <returns>A ValueMatrix2x3.</returns>
    public static ValueMatrix2x3<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
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
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out ValueMatrix2x3<T> result)
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
    public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(ValueMatrix2x3<T>)}: ({M1x1.ToString(format, formatProvider)}, {M1x2.ToString(format, formatProvider)}, {M2x1.ToString(format, formatProvider)}, {M2x2.ToString(format, formatProvider)}, {M3x1.ToString(format, formatProvider)}, {M3x2.ToString(format, formatProvider)})";

    /// <summary>
    /// Gets the debugger display.
    /// </summary>
    /// <returns>A string? .</returns>
    private string? GetDebuggerDisplay() => ToString();
}
