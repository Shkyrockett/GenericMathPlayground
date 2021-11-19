// <copyright file="ValueMatrix4x4.cs" company="Shkyrockett" >
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
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace GenericMathPlayground.Mathematics;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
[TypeConverter(typeof(ExpandableObjectConverter))]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public struct ValueMatrix4x4<T>
    : IMatrix<T>, IMatrix4Columns<T, ValueVector4<T>>, IMatrix4Rows<T, ValueVector4<T>>,
    IFormattable,
    IParseable<ValueMatrix4x4<T>>,
    ISpanParseable<ValueMatrix4x4<T>>,
    IEquatable<ValueMatrix4x4<T>>,
    IAdditiveIdentity<ValueMatrix4x4<T>, ValueMatrix4x4<T>>,
    IMultiplicativeIdentity<ValueMatrix4x4<T>, ValueMatrix4x4<T>>,
    IEqualityOperators<ValueMatrix4x4<T>, ValueMatrix4x4<T>>,
    IUnaryPlusOperators<ValueMatrix4x4<T>, ValueMatrix4x4<T>>,
    IAdditionOperators<ValueMatrix4x4<T>, ValueMatrix4x4<T>, ValueMatrix4x4<T>>,
    IUnaryNegationOperators<ValueMatrix4x4<T>, ValueMatrix4x4<T>>,
    ISubtractionOperators<ValueMatrix4x4<T>, ValueMatrix4x4<T>, ValueMatrix4x4<T>>,
    IMultiplyOperators<ValueMatrix4x4<T>, T, ValueMatrix4x4<T>>,
    IMultiplyOperators2<T, ValueMatrix4x4<T>, ValueMatrix4x4<T>>,
    IMultiplyOperators<ValueMatrix4x4<T>, IVector4<T>, ValueVector4<T>>,
    IMultiplyOperators2<IVector4<T>, ValueMatrix4x4<T>, ValueVector4<T>>,
    IMultiplyOperators<ValueMatrix4x4<T>, ValueMatrix4x4<T>, ValueMatrix4x4<T>>
    where T : INumber<T>
{
    #region Constructors
    /// <summary>
    /// 
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public ValueMatrix4x4() : this(
        T.One, T.Zero, T.Zero, T.Zero,
        T.Zero, T.One, T.Zero, T.Zero,
        T.Zero, T.Zero, T.One, T.Zero,
        T.Zero, T.Zero, T.Zero, T.One
        )
    { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="vector1"></param>
    /// <param name="vector2"></param>
    /// <param name="vector3"></param>
    /// <param name="vector4"></param>
    public ValueMatrix4x4(IVector4<T> vector1, IVector4<T> vector2, IVector4<T> vector3, IVector4<T> vector4) => (
        M1x1, M1x2, M1x3, M1x4,
        M2x1, M2x2, M2x3, M2x4,
        M3x1, M3x2, M3x3, M3x4,
        M4x1, M4x2, M4x3, M4x4
        ) = (
        vector1.X, vector1.Y, vector1.Z, vector1.W,
        vector2.X, vector2.Y, vector2.Z, vector2.W,
        vector3.X, vector3.Y, vector3.Z, vector3.W,
        vector4.X, vector4.Y, vector4.Z, vector4.W
        );

    /// <summary>
    /// 
    /// </summary>
    /// <param name="matrix"></param>
    public ValueMatrix4x4(ValueMatrix4x4<T> matrix) => (
        M1x1, M1x2, M1x3, M1x4,
        M2x1, M2x2, M2x3, M2x4,
        M3x1, M3x2, M3x3, M3x4,
        M4x1, M4x2, M4x3, M4x4
        ) = (
        matrix.M1x1, matrix.M1x2, matrix.M1x3, matrix.M1x4,
        matrix.M2x1, matrix.M2x2, matrix.M2x3, matrix.M2x4,
        matrix.M3x1, matrix.M3x2, matrix.M3x3, matrix.M3x4,
        matrix.M4x1, matrix.M4x2, matrix.M4x3, matrix.M4x4
        );

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tuple1"></param>
    /// <param name="tuple2"></param>
    /// <param name="tuple3"></param>
    /// <param name="tuple4"></param>
    public ValueMatrix4x4(
        (T m1x1, T m1x2, T m1x3, T m1x4) tuple1,
        (T m2x1, T m2x2, T m2x3, T m2x4) tuple2,
        (T m3x1, T m3x2, T m3x3, T m3x4) tuple3,
        (T m4x1, T m4x2, T m4x3, T m4x4) tuple4) => (
        (M1x1, M1x2, M1x3, M1x4),
        (M2x1, M2x2, M2x3, M2x4),
        (M3x1, M3x2, M3x3, M3x4),
        (M4x1, M4x2, M4x3, M4x4)
        ) = (
        tuple1,
        tuple2,
        tuple3,
        tuple4
        );

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tuple"></param>
    public ValueMatrix4x4((
        T m1x1, T m1x2, T m1x3, T m1x4,
        T m2x1, T m2x2, T m2x3, T m2x4,
        T m3x1, T m3x2, T m3x3, T m3x4,
        T m4x1, T m4x2, T m4x3, T m4x4
        ) tuple) => (
        M1x1, M1x2, M1x3, M1x4,
        M2x1, M2x2, M2x3, M2x4,
        M3x1, M3x2, M3x3, M3x4,
        M4x1, M4x2, M4x3, M4x4
        ) = tuple;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="m1x1"></param>
    /// <param name="m1x2"></param>
    /// <param name="m1x3"></param>
    /// <param name="m1x4"></param>
    /// <param name="m2x1"></param>
    /// <param name="m2x2"></param>
    /// <param name="m2x3"></param>
    /// <param name="m2x4"></param>
    /// <param name="m3x1"></param>
    /// <param name="m3x2"></param>
    /// <param name="m3x3"></param>
    /// <param name="m3x4"></param>
    /// <param name="m4x1"></param>
    /// <param name="m4x2"></param>
    /// <param name="m4x3"></param>
    /// <param name="m4x4"></param>
    public ValueMatrix4x4(
        T m1x1, T m1x2, T m1x3, T m1x4,
        T m2x1, T m2x2, T m2x3, T m2x4,
        T m3x1, T m3x2, T m3x3, T m3x4,
        T m4x1, T m4x2, T m4x3, T m4x4
        ) => (
        M1x1, M1x2, M1x3, M1x4,
        M2x1, M2x2, M2x3, M2x4,
        M3x1, M3x2, M3x3, M3x4,
        M4x1, M4x2, M4x3, M4x4
        ) = (
        m1x1, m1x2, m1x3, m1x4,
        m2x1, m2x2, m2x3, m2x4,
        m3x1, m3x2, m3x3, m3x4,
        m4x1, m4x2, m4x3, m4x4
        );
    #endregion

    #region Deconstructors
    /// <summary>
    /// 
    /// </summary>
    /// <param name="vector1"></param>
    /// <param name="vector2"></param>
    /// <param name="vector3"></param>
    /// <param name="vector4"></param>
    public void Deconstruct(
        out ValueVector4<T> vector1,
        out ValueVector4<T> vector2,
        out ValueVector4<T> vector3,
        out ValueVector4<T> vector4
        ) => (vector1, vector2, vector3, vector4) = (
        new(M1x1, M1x2, M1x3, M1x4),
        new(M2x1, M2x2, M2x3, M2x4),
        new(M3x1, M3x2, M3x3, M3x4),
        new(M4x1, M4x2, M4x3, M4x4)
        );

    /// <summary>
    /// 
    /// </summary>
    /// <param name="m1x1"></param>
    /// <param name="m1x2"></param>
    /// <param name="m1x3"></param>
    /// <param name="m1x4"></param>
    /// <param name="m2x1"></param>
    /// <param name="m2x2"></param>
    /// <param name="m2x3"></param>
    /// <param name="m2x4"></param>
    /// <param name="m3x1"></param>
    /// <param name="m3x2"></param>
    /// <param name="m3x3"></param>
    /// <param name="m3x4"></param>
    /// <param name="m4x1"></param>
    /// <param name="m4x2"></param>
    /// <param name="m4x3"></param>
    /// <param name="m4x4"></param>
    public void Deconstruct(
        out T m1x1, out T m1x2, out T m1x3, out T m1x4,
        out T m2x1, out T m2x2, out T m2x3, out T m2x4,
        out T m3x1, out T m3x2, out T m3x3, out T m3x4,
        out T m4x1, out T m4x2, out T m4x3, out T m4x4
        ) => (
        m1x1, m1x2, m1x3, m1x4,
        m2x1, m2x2, m2x3, m2x4,
        m3x1, m3x2, m3x3, m3x4,
        m4x1, m4x2, m4x3, m4x4
        ) = (
        M1x1, M1x2, M1x3, M1x4,
        M2x1, M2x2, M2x3, M2x4,
        M3x1, M3x2, M3x3, M3x4,
        M4x1, M4x2, M4x3, M4x4
        );
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
    public T M1x3 { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M1x4 { get; set; }

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
    [RefreshProperties(RefreshProperties.All)]
    public T M2x3 { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M2x4 { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M3x1 { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M3x2 { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M3x3 { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M3x4 { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M4x1 { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M4x2 { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M4x3 { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M4x4 { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    public T[,] Items
    {
        get
        {
            return new T[,] {
                    { M1x1, M1x2, M1x3, M1x4 },
                    { M2x1, M2x2, M2x3, M2x4 },
                    { M3x1, M3x2, M3x3, M3x4 },
                    { M4x1, M4x2, M4x3, M4x4 }
                };
        }
        set
        {
            (
                M1x1, M1x2, M1x3, M1x4,
                M2x1, M2x2, M2x3, M2x4,
                M3x1, M3x2, M3x3, M3x4,
                M4x1, M4x2, M4x3, M4x4
            ) = (
                value[0, 0], value[0, 1], value[0, 3], value[0, 4],
                value[1, 0], value[1, 1], value[1, 3], value[1, 4],
                value[2, 0], value[2, 1], value[2, 3], value[2, 4],
                value[3, 0], value[3, 1], value[3, 3], value[3, 4]
            );
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public int Rows => 4;

    /// <summary>
    /// 
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public int Columns => 4;

    /// <summary>
    /// Gets or sets the X-Column.
    /// </summary>
    /// <value>
    /// The cx.
    /// </value>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    [Description("The First column of the " + nameof(ValueMatrix4x4<T>))]
    public ValueVector4<T> ColumnX { get { return new ValueVector4<T>(M1x1, M2x1, M3x1, M4x1); } set { (M1x1, M2x1, M3x1, M4x1) = value; } }

    /// <summary>
    /// Gets or sets the Y-Column.
    /// </summary>
    /// <value>
    /// The cy.
    /// </value>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    [Description("The Second column of the " + nameof(ValueMatrix4x4<T>))]
    public ValueVector4<T> ColumnY { get { return new ValueVector4<T>(M1x2, M2x2, M3x2, M4x2); } set { (M1x2, M2x2, M3x2, M4x2) = value; } }

    /// <summary>
    /// Gets or sets the Z-Column.
    /// </summary>
    /// <value>
    /// The cz.
    /// </value>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    [Description("The Third column of the " + nameof(ValueMatrix4x4<T>))]
    public ValueVector4<T> ColumnZ { get { return new ValueVector4<T>(M1x3, M2x3, M3x3, M4x3); } set { (M1x3, M2x3, M3x3, M4x3) = value; } }

    /// <summary>
    /// Gets or sets the W-Column.
    /// </summary>
    /// <value>
    /// The cw.
    /// </value>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    [Description("The Fourth column of the " + nameof(ValueMatrix4x4<T>))]
    public ValueVector4<T> ColumnW { get { return new ValueVector4<T>(M1x4, M2x4, M3x4, M4x4); } set { (M1x4, M2x4, M3x4, M4x4) = value; } }

    /// <summary>
    /// Gets or sets the X-Row.
    /// </summary>
    /// <value>
    /// The rx.
    /// </value>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    [Description("The First row of the " + nameof(ValueMatrix4x4<T>))]
    public ValueVector4<T> RowX { get { return new ValueVector4<T>(M1x1, M1x2, M1x3, M1x4); } set { (M1x1, M1x2, M1x3, M1x4) = value; } }

    /// <summary>
    /// Gets or sets the Y-Row.
    /// </summary>
    /// <value>
    /// The ry.
    /// </value>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    [Description("The Second row of the " + nameof(ValueMatrix4x4<T>))]
    public ValueVector4<T> RowY { get { return new ValueVector4<T>(M2x1, M2x2, M2x3, M2x4); } set { (M2x1, M2x2, M2x3, M2x4) = value; } }

    /// <summary>
    /// Gets or sets the Z-Row.
    /// </summary>
    /// <value>
    /// The rz.
    /// </value>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    [Description("The Third row of the " + nameof(ValueMatrix4x4<T>))]
    public ValueVector4<T> RowZ { get { return new ValueVector4<T>(M3x1, M3x2, M3x3, M3x4); } set { (M3x1, M3x2, M3x3, M3x4) = value; } }

    /// <summary>
    /// Gets or sets the W-Row.
    /// </summary>
    /// <value>
    /// The rz.
    /// </value>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    [Description("The Fourth row of the " + nameof(ValueMatrix4x4<T>))]
    public ValueVector4<T> RowW { get { return new ValueVector4<T>(M4x1, M4x2, M4x3, M4x4); } set { (M4x1, M4x2, M4x3, M4x4) = value; } }

    /// <summary>
    /// Gets the determinant.
    /// </summary>
    /// <value>
    /// The determinant.
    /// </value>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public T Determinant => Operations.MatrixDeterminant(
        M1x1, M1x2, M1x3, M1x4,
        M2x1, M2x2, M2x3, M2x4,
        M3x1, M3x2, M3x3, M3x4,
        M4x1, M4x2, M4x3, M4x4
        );

    /// <summary>
    /// 
    /// </summary>
    public static ValueMatrix4x4<T> AdditiveIdentity => new(
        T.Zero, T.Zero, T.Zero, T.Zero,
        T.Zero, T.Zero, T.Zero, T.Zero,
        T.Zero, T.Zero, T.Zero, T.Zero,
        T.Zero, T.Zero, T.Zero, T.Zero
        );

    /// <summary>
    /// 
    /// </summary>
    public static ValueMatrix4x4<T> MultiplicativeIdentity => new(
        T.One, T.Zero, T.Zero, T.Zero,
        T.Zero, T.One, T.Zero, T.Zero,
        T.Zero, T.Zero, T.One, T.Zero,
        T.Zero, T.Zero, T.Zero, T.One
        );
    #endregion

    #region Operators
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(ValueMatrix4x4<T> left, ValueMatrix4x4<T> right) => left.Equals(right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(ValueMatrix4x4<T> left, ValueMatrix4x4<T> right) => !(left == right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueMatrix4x4<T> operator +(ValueMatrix4x4<T> value) => value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix4x4<T> operator +(ValueMatrix4x4<T> left, ValueMatrix4x4<T> right) => new(Operations.AddMatrix(
            left.M1x1, left.M1x2, left.M1x3, left.M1x4,
            left.M2x1, left.M2x2, left.M2x3, left.M2x4,
            left.M3x1, left.M3x2, left.M3x3, left.M3x4,
            left.M4x1, left.M4x2, left.M4x3, left.M4x4,
            right.M1x1, right.M1x2, right.M1x3, right.M1x4,
            right.M2x1, right.M2x2, right.M2x3, right.M2x4,
            right.M3x1, right.M3x2, right.M3x3, right.M3x4,
            right.M4x1, right.M4x2, right.M4x3, right.M4x4
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueMatrix4x4<T> operator -(ValueMatrix4x4<T> value) => new(Operations.NegateMatrix(
            value.M1x1, value.M1x2, value.M1x3, value.M1x4,
            value.M2x1, value.M2x2, value.M2x3, value.M2x4,
            value.M3x1, value.M3x2, value.M3x3, value.M3x4,
            value.M4x1, value.M4x2, value.M4x3, value.M4x4
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix4x4<T> operator -(ValueMatrix4x4<T> left, ValueMatrix4x4<T> right) => new(Operations.SubtractMatrix(
            left.M1x1, left.M1x2, left.M1x3, left.M1x4,
            left.M2x1, left.M2x2, left.M2x3, left.M2x4,
            left.M3x1, left.M3x2, left.M3x3, left.M3x4,
            left.M4x1, left.M4x2, left.M4x3, left.M4x4,
            right.M1x1, right.M1x2, right.M1x3, right.M1x4,
            right.M2x1, right.M2x2, right.M2x3, right.M2x4,
            right.M3x1, right.M3x2, right.M3x3, right.M3x4,
            right.M4x1, right.M4x2, right.M4x3, right.M4x4
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix4x4<T> operator *(ValueMatrix4x4<T> left, T right) => new(Operations.ScaleMatrixRight(
            left.M1x1, left.M1x2, left.M1x3, left.M1x4,
            left.M2x1, left.M2x2, left.M2x3, left.M2x4,
            left.M3x1, left.M3x2, left.M3x3, left.M3x4,
            left.M4x1, left.M4x2, left.M4x3, left.M4x4, right));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix4x4<T> operator *(T left, ValueMatrix4x4<T> right) => new(Operations.ScaleMatrixLeft(left,
            right.M1x1, right.M1x2, right.M1x3, right.M1x4,
            right.M2x1, right.M2x2, right.M2x3, right.M2x4,
            right.M3x1, right.M3x2, right.M3x3, right.M3x4,
            right.M4x1, right.M4x2, right.M4x3, right.M4x4));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static ValueVector4<T> operator *(ValueMatrix4x4<T> left, IVector4<T> right) => new(Operations.MultiplyMatrixVector(
            left.M1x1, left.M1x2, left.M1x3, left.M1x4,
            left.M2x1, left.M2x2, left.M2x3, left.M2x4,
            left.M3x1, left.M3x2, left.M3x3, left.M3x4,
            left.M4x1, left.M4x2, left.M4x3, left.M4x4,
            right.X, right.Y, right.Z, right.W
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static ValueVector4<T> operator *(IVector4<T> left, ValueMatrix4x4<T> right) => new(Operations.MultiplyVectorMatrix(
            left.X, left.Y, left.Z, left.W,
            right.M1x1, right.M1x2, right.M1x3, right.M1x4,
            right.M2x1, right.M2x2, right.M2x3, right.M2x4,
            right.M3x1, right.M3x2, right.M3x3, right.M3x4,
            right.M4x1, right.M4x2, right.M4x3, right.M4x4
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static ValueMatrix4x4<T> operator *(ValueMatrix4x4<T> left, ValueMatrix4x4<T> right) => new(Operations.MultiplyMatrix(
            left.M1x1, left.M1x2, left.M1x3, left.M1x4,
            left.M2x1, left.M2x2, left.M2x3, left.M2x4,
            left.M3x1, left.M3x2, left.M3x3, left.M3x4,
            left.M4x1, left.M4x2, left.M4x3, left.M4x4,
            right.M1x1, right.M1x2, right.M1x3, right.M1x4,
            right.M2x1, right.M2x2, right.M2x3, right.M2x4,
            right.M3x1, right.M3x2, right.M3x3, right.M3x4,
            right.M4x1, right.M4x2, right.M4x3, right.M4x4
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="matrix"></param>
    public static implicit operator ValueMatrix<T>(ValueMatrix4x4<T> matrix) => new(matrix);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tuple"></param>
    public static implicit operator ValueMatrix4x4<T>((
        T m1x1, T m1x2, T m1x3, T m1x4, T m1x5,
        T m2x1, T m2x2, T m2x3, T m2x4, T m2x5,
        T m3x1, T m3x2, T m3x3, T m3x4, T m3x5,
        T m4x1, T m4x2, T m4x3, T m4x4, T m4x5,
        T m5x1, T m5x2, T m5x3, T m5x4, T m5x5
        ) tuple) => new(tuple);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tuple"></param>
    public static implicit operator ValueMatrix4x4<T>((
        (T m1x1, T m1x2, T m1x3, T m1x4) tuple1,
        (T m2x1, T m2x2, T m2x3, T m2x4) tuple2,
        (T m3x1, T m3x2, T m3x3, T m3x4) tuple3,
        (T m4x1, T m4x2, T m4x3, T m4x4) tuple4) tuple
        ) => new(
            tuple.tuple1,
            tuple.tuple2,
            tuple.tuple3,
            tuple.tuple4
            );
    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(M1x1); hash.Add(M1x2); hash.Add(M1x3); hash.Add(M1x4);
        hash.Add(M2x1); hash.Add(M2x2); hash.Add(M2x3); hash.Add(M2x4);
        hash.Add(M3x1); hash.Add(M3x2); hash.Add(M3x3); hash.Add(M3x4);
        hash.Add(M4x1); hash.Add(M4x2); hash.Add(M4x3); hash.Add(M4x4);
        return hash.ToHashCode();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj) => obj is ValueMatrix4x4<T> matrix && Equals(matrix);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(ValueMatrix4x4<T> other)
        => M1x1.Equals(other.M1x1) && M1x2.Equals(other.M1x2) && M1x2.Equals(other.M1x3) && M1x2.Equals(other.M1x4) &&
           M2x1.Equals(other.M2x1) && M2x2.Equals(other.M2x2) && M2x2.Equals(other.M2x3) && M2x2.Equals(other.M2x4) &&
           M3x1.Equals(other.M3x1) && M3x2.Equals(other.M3x2) && M3x2.Equals(other.M3x3) && M3x2.Equals(other.M3x4) &&
           M4x1.Equals(other.M4x1) && M4x2.Equals(other.M4x2) && M4x2.Equals(other.M4x3) && M4x2.Equals(other.M4x4);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="provider"></param>
    /// <returns></returns>
    public static ValueMatrix4x4<T> Parse(string s, IFormatProvider? provider)
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
    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out ValueMatrix4x4<T> result)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="provider"></param>
    /// <returns></returns>
    public static ValueMatrix4x4<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
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
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out ValueMatrix4x4<T> result)
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
    public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(ValueMatrix4x4<T>)}: ({M1x1.ToString(format, formatProvider)}, {M1x2.ToString(format, formatProvider)}, {M2x1.ToString(format, formatProvider)}, {M2x2.ToString(format, formatProvider)})";

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private string? GetDebuggerDisplay() => ToString();
}
