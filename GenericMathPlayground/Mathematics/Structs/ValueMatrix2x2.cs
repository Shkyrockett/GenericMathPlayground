// <copyright file="ValueMatrix2x2.cs" company="Shkyrockett" >
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
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace GenericMathPlayground.Mathematics;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
[TypeConverter(typeof(ExpandableObjectConverter))]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public struct ValueMatrix2x2<T>
    : IMatrix<T>, IMatrix2Columns<T, ValueVector2<T>>, IMatrix2Rows<T, ValueVector2<T>>,
    IFormattable,
    IParseable<ValueMatrix2x2<T>>,
    ISpanParseable<ValueMatrix2x2<T>>,
    IEquatable<ValueMatrix2x2<T>>,
    IAdditiveIdentity<ValueMatrix2x2<T>, ValueMatrix2x2<T>>,
    IMultiplicativeIdentity<ValueMatrix2x2<T>, ValueMatrix2x2<T>>,
    IEqualityOperators<ValueMatrix2x2<T>, ValueMatrix2x2<T>>,
    IUnaryPlusOperators<ValueMatrix2x2<T>, ValueMatrix2x2<T>>,
    IAdditionOperators<ValueMatrix2x2<T>, ValueMatrix2x2<T>, ValueMatrix2x2<T>>,
    IUnaryNegationOperators<ValueMatrix2x2<T>, ValueMatrix2x2<T>>,
    ISubtractionOperators<ValueMatrix2x2<T>, ValueMatrix2x2<T>, ValueMatrix2x2<T>>,
    IMultiplyOperators<ValueMatrix2x2<T>, T, ValueMatrix2x2<T>>,
    IMultiplyOperators2<T, ValueMatrix2x2<T>, ValueMatrix2x2<T>>,
    IMultiplyOperators<ValueMatrix2x2<T>, IVector2<T>, ValueVector2<T>>,
    IMultiplyOperators2<IVector2<T>, ValueMatrix2x2<T>, ValueVector2<T>>,
    IMultiplyOperators<ValueMatrix2x2<T>, ValueMatrix2x2<T>, ValueMatrix2x2<T>>
    where T : INumber<T>
{
    #region Constructors
    /// <summary>
    /// 
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public ValueMatrix2x2() : this(T.One, T.Zero, T.Zero, T.One) { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="vector1"></param>
    /// <param name="vector2"></param>
    public ValueMatrix2x2(IVector2<T> vector1, IVector2<T> vector2) => (M1x1, M1x2, M2x1, M2x2) = (vector1.X, vector1.Y, vector2.X, vector2.Y);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="matrix"></param>
    public ValueMatrix2x2(ValueMatrix2x2<T> matrix) => (M1x1, M1x2, M2x1, M2x2) = (matrix.M1x1, matrix.M1x2, matrix.M2x1, matrix.M2x2);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tuple1"></param>
    /// <param name="tuple2"></param>
    public ValueMatrix2x2((T m1x1, T m1x2) tuple1, (T m2x1, T m2x2) tuple2) => ((M1x1, M1x2), (M2x1, M2x2)) = (tuple1, tuple2);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tuple"></param>
    public ValueMatrix2x2((T m1x1, T m1x2, T m2x1, T m2x2) tuple) => (M1x1, M1x2, M2x1, M2x2) = tuple;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="m1x1"></param>
    /// <param name="m1x2"></param>
    /// <param name="m2x1"></param>
    /// <param name="m2x2"></param>
    public ValueMatrix2x2(T m1x1, T m1x2, T m2x1, T m2x2) => (M1x1, M1x2, M2x1, M2x2) = (m1x1, m1x2, m2x1, m2x2);
    #endregion

    #region Deconstructors
    /// <summary>
    /// 
    /// </summary>
    /// <param name="vector1"></param>
    /// <param name="vector2"></param>
    public void Deconstruct(out ValueVector2<T> vector1, out ValueVector2<T> vector2) => (vector1, vector2) = (new(M1x1, M1x2), new(M2x1, M2x2));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="m1x1"></param>
    /// <param name="m1x2"></param>
    /// <param name="m2x1"></param>
    /// <param name="m2x2"></param>
    public void Deconstruct(out T m1x1, out T m1x2, out T m2x1, out T m2x2) => (m1x1, m1x2, m2x1, m2x2) = (M1x1, M1x2, M2x1, M2x2);
    #endregion

    #region Properties
    /// <summary>
    /// 
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M1x1 { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M1x2 { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M2x1 { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M2x2 { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    public T[,] Items
    {
        get
        {
            return new T[,] {
                    { M1x1, M1x2 },
                    { M2x1, M2x2 }
                };
        }
        set
        {
            (
                M1x1, M1x2,
                M2x1, M2x2
            ) = (
                value[0, 0], value[1, 0],
                value[0, 0], value[1, 0]
            );
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public int Rows => 2;

    /// <summary>
    /// 
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public int Columns => 2;

    /// <summary>
    /// Gets or sets the cx.
    /// </summary>
    /// <value>
    /// The cx.
    /// </value>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [Description("The First column of the " + nameof(ValueMatrix2x2<T>))]
    public ValueVector2<T> ColumnX { get { return new ValueVector2<T>(M1x1, M2x1); } set { (M1x1, M2x1) = value; } }

    /// <summary>
    /// Gets or sets the cy.
    /// </summary>
    /// <value>
    /// The cy.
    /// </value>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [Description("The Second column of the " + nameof(ValueMatrix2x2<T>))]
    public ValueVector2<T> ColumnY { get { return new ValueVector2<T>(M1x2, M2x2); } set { (M1x2, M2x2) = value; } }

    /// <summary>
    /// Gets or sets the rx.
    /// </summary>
    /// <value>
    /// The rx.
    /// </value>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [Description("The First row of the " + nameof(ValueMatrix2x2<T>))]
    public ValueVector2<T> RowX { get { return new ValueVector2<T>(M1x1, M1x2); } set { (M1x1, M1x2) = value; } }

    /// <summary>
    /// Gets or sets the ry.
    /// </summary>
    /// <value>
    /// The ry.
    /// </value>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [Description("The Second row of the " + nameof(ValueMatrix2x2<T>))]
    public ValueVector2<T> RowY { get { return new ValueVector2<T>(M2x1, M2x2); } set { (M2x1, M2x2) = value; } }

    /// <summary>
    /// Gets the determinant.
    /// </summary>
    /// <value>
    /// The determinant.
    /// </value>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public T Determinant => Operations.MatrixDeterminant(M1x1, M1x2, M2x1, M2x2);

    /// <summary>
    /// 
    /// </summary>
    public static ValueMatrix2x2<T> AdditiveIdentity => new(T.Zero, T.Zero, T.Zero, T.Zero);

    /// <summary>
    /// 
    /// </summary>
    public static ValueMatrix2x2<T> MultiplicativeIdentity => new(T.One, T.Zero, T.Zero, T.One);
    #endregion

    #region Operators
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(ValueMatrix2x2<T> left, ValueMatrix2x2<T> right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(ValueMatrix2x2<T> left, ValueMatrix2x2<T> right)
    {
        return !(left == right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueMatrix2x2<T> operator +(ValueMatrix2x2<T> value) => value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix2x2<T> operator +(ValueMatrix2x2<T> left, ValueMatrix2x2<T> right)
    {
        return Operations.AddMatrix(left.M1x1, left.M1x2, left.M2x1, left.M2x2, right.M1x1, right.M1x2, right.M2x1, right.M2x2);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueMatrix2x2<T> operator -(ValueMatrix2x2<T> value)
    {
        return new(Operations.NegateMatrix(value.M1x1, value.M1x2, value.M2x1, value.M2x2));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix2x2<T> operator -(ValueMatrix2x2<T> left, ValueMatrix2x2<T> right)
    {
        return Operations.SubtractMatrix(left.M1x1, left.M1x2, left.M2x1, left.M2x2, right.M1x1, right.M1x2, right.M2x1, right.M2x2);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix2x2<T> operator *(ValueMatrix2x2<T> left, T right) => new(Operations.ScaleMatrixRight(
            left.M1x1, left.M1x2,
            left.M2x1, left.M2x2, right));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix2x2<T> operator *(T left, ValueMatrix2x2<T> right) => new(Operations.ScaleMatrixLeft(left,
            right.M1x1, right.M1x2,
            right.M2x1, right.M2x2));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static ValueVector2<T> operator *(ValueMatrix2x2<T> left, IVector2<T> right) => new(Operations.MultiplyMatrixVector(
            left.M1x1, left.M1x2,
            left.M2x1, left.M2x2,
            right.X, right.Y
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static ValueVector2<T> operator *(IVector2<T> left, ValueMatrix2x2<T> right) => new(Operations.MultiplyVectorMatrix(
            left.X, left.Y,
            right.M1x1, right.M1x2,
            right.M2x1, right.M2x2
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static ValueMatrix2x2<T> operator *(ValueMatrix2x2<T> left, ValueMatrix2x2<T> right) => new(Operations.MultiplyMatrix(
            left.M1x1, left.M1x2,
            left.M2x1, left.M2x2,
            right.M1x1, right.M1x2,
            right.M2x1, right.M2x2
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="matrix"></param>
    public static implicit operator ValueMatrix<T>(ValueMatrix2x2<T> matrix) => new(matrix);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tuple"></param>
    public static implicit operator ValueMatrix2x2<T>((T m1x1, T m1x2, T m2x1, T m2x2) tuple) => new(tuple);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tuple"></param>
    public static implicit operator ValueMatrix2x2<T>(((T X, T Y) tuple1, (T X, T Y) tuple2) tuple) => new(tuple.tuple1, tuple.tuple2);
    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode() => HashCode.Combine(M1x1, M1x2, M2x1, M2x2);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj) => obj is ValueMatrix2x2<T> matrix && Equals(matrix);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(ValueMatrix2x2<T> other)
        => M1x1.Equals(other.M1x1) && M1x2.Equals(other.M1x2) &&
           M2x1.Equals(other.M2x1) && M2x2.Equals(other.M2x2);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="provider"></param>
    /// <returns></returns>
    public static ValueMatrix2x2<T> Parse(string s, IFormatProvider? provider)
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
    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out ValueMatrix2x2<T> result)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="provider"></param>
    /// <returns></returns>
    public static ValueMatrix2x2<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
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
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out ValueMatrix2x2<T> result)
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
    public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(ValueMatrix2x2<T>)}: ({M1x1.ToString(format, formatProvider)}, {M1x2.ToString(format, formatProvider)}, {M2x1.ToString(format, formatProvider)}, {M2x2.ToString(format, formatProvider)})";

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private string? GetDebuggerDisplay() => ToString();
}
