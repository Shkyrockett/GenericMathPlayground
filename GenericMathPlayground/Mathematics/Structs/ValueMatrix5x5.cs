// <copyright file="ValueMatrix5x5.cs" company="Shkyrockett" >
//     Copyright © 2021 - 2022 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace GenericMathPlayground.Mathematics;

/// <summary>
/// The value matrix5x5.
/// </summary>
/// <typeparam name="T"></typeparam>
[TypeConverter(typeof(ExpandableObjectConverter))]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public struct ValueMatrix5x5<T>
    : IMatrix<T>, IMatrix5Columns<T, ValueVector5<T>>, IMatrix5Rows<T, ValueVector5<T>>,
    IFormattable,
    IParsable<ValueMatrix5x5<T>>,
    ISpanParsable<ValueMatrix5x5<T>>,
    IEquatable<ValueMatrix5x5<T>>,
    IAdditiveIdentity<ValueMatrix5x5<T>, ValueMatrix5x5<T>>,
    IMultiplicativeIdentity<ValueMatrix5x5<T>, ValueMatrix5x5<T>>,
    IEqualityOperators<ValueMatrix5x5<T>, ValueMatrix5x5<T>>,
    IUnaryPlusOperators<ValueMatrix5x5<T>, ValueMatrix5x5<T>>,
    IAdditionOperators<ValueMatrix5x5<T>, ValueMatrix5x5<T>, ValueMatrix5x5<T>>,
    IUnaryNegationOperators<ValueMatrix5x5<T>, ValueMatrix5x5<T>>,
    ISubtractionOperators<ValueMatrix5x5<T>, ValueMatrix5x5<T>, ValueMatrix5x5<T>>,
    IMultiplyOperators<ValueMatrix5x5<T>, T, ValueMatrix5x5<T>>,
    IMultiplyOperators2<T, ValueMatrix5x5<T>, ValueMatrix5x5<T>>,
    IMultiplyOperators<ValueMatrix5x5<T>, IVector5<T>, ValueVector5<T>>,
    IMultiplyOperators2<IVector5<T>, ValueMatrix5x5<T>, ValueVector5<T>>,
    IMultiplyOperators<ValueMatrix5x5<T>, ValueMatrix5x5<T>, ValueMatrix5x5<T>>
    where T : INumber<T>
{
    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="ValueMatrix5x5{T}"/> class.
    /// </summary>
    public ValueMatrix5x5() : this(
        T.One, T.Zero, T.Zero, T.Zero, T.Zero,
        T.Zero, T.One, T.Zero, T.Zero, T.Zero,
        T.Zero, T.Zero, T.One, T.Zero, T.Zero,
        T.Zero, T.Zero, T.Zero, T.One, T.Zero,
        T.Zero, T.Zero, T.Zero, T.Zero, T.One
        )
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueMatrix5x5{T}"/> class.
    /// </summary>
    /// <param name="vector1">The vector1.</param>
    /// <param name="vector2">The vector2.</param>
    /// <param name="vector3">The vector3.</param>
    /// <param name="vector4">The vector4.</param>
    /// <param name="vector5">The vector5.</param>
    public ValueMatrix5x5(IVector5<T> vector1, IVector5<T> vector2, IVector5<T> vector3, IVector5<T> vector4, IVector5<T> vector5) => (
        M1x1, M1x2, M1x3, M1x4, M1x5,
        M2x1, M2x2, M2x3, M2x4, M2x5,
        M3x1, M3x2, M3x3, M3x4, M3x5,
        M4x1, M4x2, M4x3, M4x4, M4x5,
        M5x1, M5x2, M5x3, M5x4, M5x5
        ) = (
        vector1.X, vector1.Y, vector1.Z, vector1.W, vector1.V,
        vector2.X, vector2.Y, vector2.Z, vector2.W, vector2.V,
        vector3.X, vector3.Y, vector3.Z, vector3.W, vector3.V,
        vector4.X, vector4.Y, vector4.Z, vector4.W, vector4.V,
        vector5.X, vector5.Y, vector5.Z, vector5.W, vector5.V
        );

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueMatrix5x5{T}"/> class.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    public ValueMatrix5x5(ValueMatrix5x5<T> matrix) => (
        M1x1, M1x2, M1x3, M1x4, M1x5,
        M2x1, M2x2, M2x3, M2x4, M2x5,
        M3x1, M3x2, M3x3, M3x4, M3x5,
        M4x1, M4x2, M4x3, M4x4, M4x5,
        M5x1, M5x2, M5x3, M5x4, M5x5
        ) = (
        matrix.M1x1, matrix.M1x2, matrix.M1x3, matrix.M1x4, matrix.M1x5,
        matrix.M2x1, matrix.M2x2, matrix.M2x3, matrix.M2x4, matrix.M2x5,
        matrix.M3x1, matrix.M3x2, matrix.M3x3, matrix.M3x4, matrix.M3x5,
        matrix.M4x1, matrix.M4x2, matrix.M4x3, matrix.M4x4, matrix.M4x5,
        matrix.M5x1, matrix.M5x2, matrix.M5x3, matrix.M5x4, matrix.M5x5
        );

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueMatrix5x5{T}"/> class.
    /// </summary>
    /// <param name="tuple1">The tuple1.</param>
    /// <param name="tuple2">The tuple2.</param>
    /// <param name="tuple3">The tuple3.</param>
    /// <param name="tuple4">The tuple4.</param>
    /// <param name="tuple5">The tuple5.</param>
    public ValueMatrix5x5(
        (T m1x1, T m1x2, T m1x3, T m1x4, T m1x5) tuple1,
        (T m2x1, T m2x2, T m2x3, T m2x4, T m2x5) tuple2,
        (T m3x1, T m3x2, T m3x3, T m3x4, T m3x5) tuple3,
        (T m4x1, T m4x2, T m4x3, T m4x4, T m4x5) tuple4,
        (T m5x1, T m5x2, T m5x3, T m5x4, T m5x5) tuple5) => (
        (M1x1, M1x2, M1x3, M1x4, M1x5),
        (M2x1, M2x2, M2x3, M2x4, M2x5),
        (M3x1, M3x2, M3x3, M3x4, M3x5),
        (M4x1, M4x2, M4x3, M4x4, M4x5),
        (M5x1, M5x2, M5x3, M5x4, M5x5)
        ) = (
        tuple1,
        tuple2,
        tuple3,
        tuple4,
        tuple5
        );

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueMatrix5x5{T}"/> class.
    /// </summary>
    /// <param name="tuple">The tuple.</param>
    public ValueMatrix5x5((
        T m1x1, T m1x2, T m1x3, T m1x4, T m1x5,
        T m2x1, T m2x2, T m2x3, T m2x4, T m2x5,
        T m3x1, T m3x2, T m3x3, T m3x4, T m3x5,
        T m4x1, T m4x2, T m4x3, T m4x4, T m4x5,
        T m5x1, T m5x2, T m5x3, T m5x4, T m5x5
        ) tuple) => (
        M1x1, M1x2, M1x3, M1x4, M1x5,
        M2x1, M2x2, M2x3, M2x4, M2x5,
        M3x1, M3x2, M3x3, M3x4, M3x5,
        M4x1, M4x2, M4x3, M4x4, M4x5,
        M5x1, M5x2, M5x3, M5x4, M5x5
        ) = tuple;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueMatrix5x5{T}"/> class.
    /// </summary>
    /// <param name="m1x1">The m1x1.</param>
    /// <param name="m1x2">The m1x2.</param>
    /// <param name="m1x3">The m1x3.</param>
    /// <param name="m1x4">The m1x4.</param>
    /// <param name="m1x5">The m1x5.</param>
    /// <param name="m2x1">The m2x1.</param>
    /// <param name="m2x2">The m2x2.</param>
    /// <param name="m2x3">The m2x3.</param>
    /// <param name="m2x4">The m2x4.</param>
    /// <param name="m2x5">The m2x5.</param>
    /// <param name="m3x1">The m3x1.</param>
    /// <param name="m3x2">The m3x2.</param>
    /// <param name="m3x3">The m3x3.</param>
    /// <param name="m3x4">The m3x4.</param>
    /// <param name="m3x5">The m3x5.</param>
    /// <param name="m4x1">The m4x1.</param>
    /// <param name="m4x2">The m4x2.</param>
    /// <param name="m4x3">The m4x3.</param>
    /// <param name="m4x4">The m4x4.</param>
    /// <param name="m4x5">The m4x5.</param>
    /// <param name="m5x1">The m5x1.</param>
    /// <param name="m5x2">The m5x2.</param>
    /// <param name="m5x3">The m5x3.</param>
    /// <param name="m5x4">The m5x4.</param>
    /// <param name="m5x5">The m5x5.</param>
    public ValueMatrix5x5(
        T m1x1, T m1x2, T m1x3, T m1x4, T m1x5,
        T m2x1, T m2x2, T m2x3, T m2x4, T m2x5,
        T m3x1, T m3x2, T m3x3, T m3x4, T m3x5,
        T m4x1, T m4x2, T m4x3, T m4x4, T m4x5,
        T m5x1, T m5x2, T m5x3, T m5x4, T m5x5
        ) => (
        M1x1, M1x2, M1x3, M1x4, M1x5,
        M2x1, M2x2, M2x3, M2x4, M2x5,
        M3x1, M3x2, M3x3, M3x4, M3x5,
        M4x1, M4x2, M4x3, M4x4, M4x5,
        M5x1, M5x2, M5x3, M5x4, M5x5
        ) = (
        m1x1, m1x2, m1x3, m1x4, m1x5,
        m2x1, m2x2, m2x3, m2x4, m2x5,
        m3x1, m3x2, m3x3, m3x4, m3x5,
        m4x1, m4x2, m4x3, m4x4, m4x5,
        m5x1, m5x2, m5x3, m5x4, m5x5
        );
    #endregion

    #region Deconstructors
    /// <summary>
    /// Deconstructs the.
    /// </summary>
    /// <param name="vector1">The vector1.</param>
    /// <param name="vector2">The vector2.</param>
    /// <param name="vector3">The vector3.</param>
    /// <param name="vector4">The vector4.</param>
    /// <param name="vector5">The vector5.</param>
    public void Deconstruct(
        out ValueVector5<T> vector1,
        out ValueVector5<T> vector2,
        out ValueVector5<T> vector3,
        out ValueVector5<T> vector4,
        out ValueVector5<T> vector5
        ) => (vector1, vector2, vector3, vector4, vector5) = (
        new(M1x1, M1x2, M1x3, M1x4, M1x5),
        new(M2x1, M2x2, M2x3, M2x4, M2x5),
        new(M3x1, M3x2, M3x3, M3x4, M3x5),
        new(M4x1, M4x2, M4x3, M4x4, M4x5),
        new(M5x1, M5x2, M5x3, M5x4, M5x5)
        );

    /// <summary>
    /// Deconstructs the.
    /// </summary>
    /// <param name="m1x1">The m1x1.</param>
    /// <param name="m1x2">The m1x2.</param>
    /// <param name="m1x3">The m1x3.</param>
    /// <param name="m1x4">The m1x4.</param>
    /// <param name="m1x5">The m1x5.</param>
    /// <param name="m2x1">The m2x1.</param>
    /// <param name="m2x2">The m2x2.</param>
    /// <param name="m2x3">The m2x3.</param>
    /// <param name="m2x4">The m2x4.</param>
    /// <param name="m2x5">The m2x5.</param>
    /// <param name="m3x1">The m3x1.</param>
    /// <param name="m3x2">The m3x2.</param>
    /// <param name="m3x3">The m3x3.</param>
    /// <param name="m3x4">The m3x4.</param>
    /// <param name="m3x5">The m3x5.</param>
    /// <param name="m4x1">The m4x1.</param>
    /// <param name="m4x2">The m4x2.</param>
    /// <param name="m4x3">The m4x3.</param>
    /// <param name="m4x4">The m4x4.</param>
    /// <param name="m4x5">The m4x5.</param>
    /// <param name="m5x1">The m5x1.</param>
    /// <param name="m5x2">The m5x2.</param>
    /// <param name="m5x3">The m5x3.</param>
    /// <param name="m5x4">The m5x4.</param>
    /// <param name="m5x5">The m5x5.</param>
    public void Deconstruct(
        out T m1x1, out T m1x2, out T m1x3, out T m1x4, out T m1x5,
        out T m2x1, out T m2x2, out T m2x3, out T m2x4, out T m2x5,
        out T m3x1, out T m3x2, out T m3x3, out T m3x4, out T m3x5,
        out T m4x1, out T m4x2, out T m4x3, out T m4x4, out T m4x5,
        out T m5x1, out T m5x2, out T m5x3, out T m5x4, out T m5x5
        ) => (
        m1x1, m1x2, m1x3, m1x4, m1x5,
        m2x1, m2x2, m2x3, m2x4, m2x5,
        m3x1, m3x2, m3x3, m3x4, m3x5,
        m4x1, m4x2, m4x3, m4x4, m4x5,
        m5x1, m5x2, m5x3, m5x4, m5x5
        ) = (
        M1x1, M1x2, M1x3, M1x4, M1x5,
        M2x1, M2x2, M2x3, M2x4, M2x5,
        M3x1, M3x2, M3x3, M3x4, M3x5,
        M4x1, M4x2, M4x3, M4x4, M4x5,
        M5x1, M5x2, M5x3, M5x4, M5x5
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
    /// Gets or sets the m1x3.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M1x3 { get; set; }

    /// <summary>
    /// Gets or sets the m1x4.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M1x4 { get; set; }

    /// <summary>
    /// Gets or sets the m1x5.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M1x5 { get; set; }

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
    /// Gets or sets the m2x3.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M2x3 { get; set; }

    /// <summary>
    /// Gets or sets the m2x4.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M2x4 { get; set; }

    /// <summary>
    /// Gets or sets the m2x5.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M2x5 { get; set; }

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
    /// Gets or sets the m3x3.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M3x3 { get; set; }

    /// <summary>
    /// Gets or sets the m3x4.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M3x4 { get; set; }

    /// <summary>
    /// Gets or sets the m3x5.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M3x5 { get; set; }

    /// <summary>
    /// Gets or sets the m4x1.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M4x1 { get; set; }

    /// <summary>
    /// Gets or sets the m4x2.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M4x2 { get; set; }

    /// <summary>
    /// Gets or sets the m4x3.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M4x3 { get; set; }

    /// <summary>
    /// Gets or sets the m4x4.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M4x4 { get; set; }

    /// <summary>
    /// Gets or sets the m4x5.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M4x5 { get; set; }

    /// <summary>
    /// Gets or sets the m5x1.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M5x1 { get; set; }

    /// <summary>
    /// Gets or sets the m5x2.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M5x2 { get; set; }

    /// <summary>
    /// Gets or sets the m5x3.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M5x3 { get; set; }

    /// <summary>
    /// Gets or sets the m5x4.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M5x4 { get; set; }

    /// <summary>
    /// Gets or sets the m5x5.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T M5x5 { get; set; }

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
                    { M1x1, M1x2, M1x3, M1x4, M1x5 },
                    { M2x1, M2x2, M2x3, M2x4, M2x5 },
                    { M3x1, M3x2, M3x3, M3x4, M3x5 },
                    { M4x1, M4x2, M4x3, M4x4, M4x5 },
                    { M5x1, M5x2, M5x3, M5x4, M5x5 }
                };
        }
        set
        {
            (
                M1x1, M1x2, M1x3, M1x4, M1x5,
                M2x1, M2x2, M2x3, M2x4, M2x5,
                M3x1, M3x2, M3x3, M3x4, M3x5,
                M4x1, M4x2, M4x3, M4x4, M4x5,
                M5x1, M5x2, M5x3, M5x4, M5x5
            ) = (
                value[0, 0], value[0, 1], value[0, 2], value[0, 3], value[0, 4],
                value[1, 0], value[1, 1], value[1, 2], value[1, 3], value[1, 4],
                value[2, 0], value[2, 1], value[2, 2], value[2, 3], value[2, 4],
                value[3, 0], value[3, 1], value[3, 2], value[3, 3], value[3, 4],
                value[4, 0], value[4, 1], value[4, 2], value[4, 3], value[4, 4]
            );
        }
    }

    /// <summary>
    /// Gets the rows.
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public int Rows => 5;

    /// <summary>
    /// Gets the columns.
    /// </summary>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public int Columns => 5;

    /// <summary>
    /// Gets or sets the X-Column.
    /// </summary>
    /// <value>
    /// The cx.
    /// </value>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    [Description("The First column of the " + nameof(ValueMatrix5x5<T>))]
    public ValueVector5<T> ColumnX { get { return new ValueVector5<T>(M1x1, M2x1, M3x1, M4x1, M5x1); } set { (M1x1, M2x1, M3x1, M4x1, M5x1) = value; } }

    /// <summary>
    /// Gets or sets the Y-Column.
    /// </summary>
    /// <value>
    /// The cy.
    /// </value>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    [Description("The Second column of the " + nameof(ValueMatrix5x5<T>))]
    public ValueVector5<T> ColumnY { get { return new ValueVector5<T>(M1x2, M2x2, M3x2, M4x2, M5x2); } set { (M1x2, M2x2, M3x2, M4x2, M5x2) = value; } }

    /// <summary>
    /// Gets or sets the Z-Column.
    /// </summary>
    /// <value>
    /// The cz.
    /// </value>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    [Description("The Third column of the " + nameof(ValueMatrix5x5<T>))]
    public ValueVector5<T> ColumnZ { get { return new ValueVector5<T>(M1x3, M2x3, M3x3, M4x3, M5x3); } set { (M1x3, M2x3, M3x3, M4x3, M5x3) = value; } }

    /// <summary>
    /// Gets or sets the W-Column.
    /// </summary>
    /// <value>
    /// The cw.
    /// </value>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    [Description("The Fourth column of the " + nameof(ValueMatrix5x5<T>))]
    public ValueVector5<T> ColumnW { get { return new ValueVector5<T>(M1x4, M2x4, M3x4, M4x4, M5x4); } set { (M1x4, M2x4, M3x4, M4x4, M5x4) = value; } }

    /// <summary>
    /// Gets or sets the V-Column.
    /// </summary>
    /// <value>
    /// The cv.
    /// </value>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    [Description("The Fourth column of the " + nameof(ValueMatrix5x5<T>))]
    public ValueVector5<T> ColumnV { get { return new ValueVector5<T>(M1x5, M2x5, M3x5, M4x5, M5x5); } set { (M1x5, M2x5, M3x5, M4x5, M5x5) = value; } }

    /// <summary>
    /// Gets or sets the X-Row.
    /// </summary>
    /// <value>
    /// The rx.
    /// </value>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    [Description("The First row of the " + nameof(ValueMatrix5x5<T>))]
    public ValueVector5<T> RowX { get { return new ValueVector5<T>(M1x1, M1x2, M1x3, M1x4, M1x5); } set { (M1x1, M1x2, M1x3, M1x4, M1x5) = value; } }

    /// <summary>
    /// Gets or sets the Y-Row.
    /// </summary>
    /// <value>
    /// The ry.
    /// </value>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    [Description("The Second row of the " + nameof(ValueMatrix5x5<T>))]
    public ValueVector5<T> RowY { get { return new ValueVector5<T>(M2x1, M2x2, M2x3, M2x4, M2x5); } set { (M2x1, M2x2, M2x3, M2x4, M2x5) = value; } }

    /// <summary>
    /// Gets or sets the Z-Row.
    /// </summary>
    /// <value>
    /// The rz.
    /// </value>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    [Description("The Third row of the " + nameof(ValueMatrix5x5<T>))]
    public ValueVector5<T> RowZ { get { return new ValueVector5<T>(M3x1, M3x2, M3x3, M3x4, M3x5); } set { (M3x1, M3x2, M3x3, M3x4, M3x5) = value; } }

    /// <summary>
    /// Gets or sets the W-Row.
    /// </summary>
    /// <value>
    /// The rz.
    /// </value>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    [Description("The Fourth row of the " + nameof(ValueMatrix5x5<T>))]
    public ValueVector5<T> RowW { get { return new ValueVector5<T>(M4x1, M4x2, M4x3, M4x4, M4x5); } set { (M4x1, M4x2, M4x3, M4x4, M4x5) = value; } }

    /// <summary>
    /// Gets or sets the V-Row.
    /// </summary>
    /// <value>
    /// The rv.
    /// </value>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    [Description("The Fourth row of the " + nameof(ValueMatrix5x5<T>))]
    public ValueVector5<T> RowV { get { return new ValueVector5<T>(M5x1, M5x2, M5x3, M5x4, M5x5); } set { (M5x1, M5x2, M5x3, M5x4, M5x5) = value; } }

    /// <summary>
    /// Gets the determinant.
    /// </summary>
    /// <value>
    /// The determinant.
    /// </value>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public T Determinant => Operations.MatrixDeterminant(
        M1x1, M1x2, M1x3, M1x4, M1x5,
        M2x1, M2x2, M2x3, M2x4, M2x5,
        M3x1, M3x2, M3x3, M3x4, M3x5,
        M4x1, M4x2, M4x3, M4x4, M4x5,
        M5x1, M5x2, M5x3, M5x4, M5x5
        );

    /// <summary>
    /// Gets the additive identity.
    /// </summary>
    public static ValueMatrix5x5<T> AdditiveIdentity => new(
        T.Zero, T.Zero, T.Zero, T.Zero, T.Zero,
        T.Zero, T.Zero, T.Zero, T.Zero, T.Zero,
        T.Zero, T.Zero, T.Zero, T.Zero, T.Zero,
        T.Zero, T.Zero, T.Zero, T.Zero, T.Zero,
        T.Zero, T.Zero, T.Zero, T.Zero, T.Zero
        );

    /// <summary>
    /// Gets the multiplicative identity.
    /// </summary>
    public static ValueMatrix5x5<T> MultiplicativeIdentity => new(
        T.One, T.Zero, T.Zero, T.Zero, T.Zero,
        T.Zero, T.One, T.Zero, T.Zero, T.Zero,
        T.Zero, T.Zero, T.One, T.Zero, T.Zero,
        T.Zero, T.Zero, T.Zero, T.One, T.Zero,
        T.Zero, T.Zero, T.Zero, T.Zero, T.One
        );
    #endregion

    #region Operators
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(ValueMatrix5x5<T> left, ValueMatrix5x5<T> right) => left.Equals(right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(ValueMatrix5x5<T> left, ValueMatrix5x5<T> right) => !(left == right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueMatrix5x5<T> operator +(ValueMatrix5x5<T> value) => value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix5x5<T> operator +(ValueMatrix5x5<T> left, ValueMatrix5x5<T> right) => new(Operations.AddMatrix(
            left.M1x1, left.M1x2, left.M1x3, left.M1x4, left.M1x5,
            left.M2x1, left.M2x2, left.M2x3, left.M2x4, left.M2x5,
            left.M3x1, left.M3x2, left.M3x3, left.M3x4, left.M3x5,
            left.M4x1, left.M4x2, left.M4x3, left.M4x4, left.M4x5,
            left.M5x1, left.M5x2, left.M5x3, left.M5x4, left.M5x5,
            right.M1x1, right.M1x2, right.M1x3, right.M1x4, right.M1x5,
            right.M2x1, right.M2x2, right.M2x3, right.M2x4, right.M2x5,
            right.M3x1, right.M3x2, right.M3x3, right.M3x4, right.M3x5,
            right.M4x1, right.M4x2, right.M4x3, right.M4x4, right.M4x5,
            right.M5x1, right.M5x2, right.M5x3, right.M5x4, right.M5x5
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix5x5<T> operator checked +(ValueMatrix5x5<T> left, ValueMatrix5x5<T> right) => new(Operations.AddMatrix(
            left.M1x1, left.M1x2, left.M1x3, left.M1x4, left.M1x5,
            left.M2x1, left.M2x2, left.M2x3, left.M2x4, left.M2x5,
            left.M3x1, left.M3x2, left.M3x3, left.M3x4, left.M3x5,
            left.M4x1, left.M4x2, left.M4x3, left.M4x4, left.M4x5,
            left.M5x1, left.M5x2, left.M5x3, left.M5x4, left.M5x5,
            right.M1x1, right.M1x2, right.M1x3, right.M1x4, right.M1x5,
            right.M2x1, right.M2x2, right.M2x3, right.M2x4, right.M2x5,
            right.M3x1, right.M3x2, right.M3x3, right.M3x4, right.M3x5,
            right.M4x1, right.M4x2, right.M4x3, right.M4x4, right.M4x5,
            right.M5x1, right.M5x2, right.M5x3, right.M5x4, right.M5x5
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueMatrix5x5<T> operator -(ValueMatrix5x5<T> value) => new(Operations.NegateMatrix(
            value.M1x1, value.M1x2, value.M1x3, value.M1x4, value.M1x5,
            value.M2x1, value.M2x2, value.M2x3, value.M2x4, value.M2x5,
            value.M3x1, value.M3x2, value.M3x3, value.M3x4, value.M3x5,
            value.M4x1, value.M4x2, value.M4x3, value.M4x4, value.M4x5,
            value.M5x1, value.M5x2, value.M5x3, value.M5x4, value.M5x5
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueMatrix5x5<T> operator checked -(ValueMatrix5x5<T> value) => new(Operations.NegateMatrix(
            value.M1x1, value.M1x2, value.M1x3, value.M1x4, value.M1x5,
            value.M2x1, value.M2x2, value.M2x3, value.M2x4, value.M2x5,
            value.M3x1, value.M3x2, value.M3x3, value.M3x4, value.M3x5,
            value.M4x1, value.M4x2, value.M4x3, value.M4x4, value.M4x5,
            value.M5x1, value.M5x2, value.M5x3, value.M5x4, value.M5x5
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix5x5<T> operator -(ValueMatrix5x5<T> left, ValueMatrix5x5<T> right) => new(Operations.SubtractMatrix(
            left.M1x1, left.M1x2, left.M1x3, left.M1x4, left.M1x5,
            left.M2x1, left.M2x2, left.M2x3, left.M2x4, left.M2x5,
            left.M3x1, left.M3x2, left.M3x3, left.M3x4, left.M3x5,
            left.M4x1, left.M4x2, left.M4x3, left.M4x4, left.M4x5,
            left.M5x1, left.M5x2, left.M5x3, left.M5x4, left.M5x5,
            right.M1x1, right.M1x2, right.M1x3, right.M1x4, right.M1x5,
            right.M2x1, right.M2x2, right.M2x3, right.M2x4, right.M2x5,
            right.M3x1, right.M3x2, right.M3x3, right.M3x4, right.M3x5,
            right.M4x1, right.M4x2, right.M4x3, right.M4x4, right.M4x5,
            right.M5x1, right.M5x2, right.M5x3, right.M5x4, right.M5x5
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix5x5<T> operator checked -(ValueMatrix5x5<T> left, ValueMatrix5x5<T> right) => new(Operations.SubtractMatrix(
            left.M1x1, left.M1x2, left.M1x3, left.M1x4, left.M1x5,
            left.M2x1, left.M2x2, left.M2x3, left.M2x4, left.M2x5,
            left.M3x1, left.M3x2, left.M3x3, left.M3x4, left.M3x5,
            left.M4x1, left.M4x2, left.M4x3, left.M4x4, left.M4x5,
            left.M5x1, left.M5x2, left.M5x3, left.M5x4, left.M5x5,
            right.M1x1, right.M1x2, right.M1x3, right.M1x4, right.M1x5,
            right.M2x1, right.M2x2, right.M2x3, right.M2x4, right.M2x5,
            right.M3x1, right.M3x2, right.M3x3, right.M3x4, right.M3x5,
            right.M4x1, right.M4x2, right.M4x3, right.M4x4, right.M4x5,
            right.M5x1, right.M5x2, right.M5x3, right.M5x4, right.M5x5
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix5x5<T> operator *(ValueMatrix5x5<T> left, T right) => new(Operations.ScaleMatrixRight(
            left.M1x1, left.M1x2, left.M1x3, left.M1x4, left.M1x5,
            left.M2x1, left.M2x2, left.M2x3, left.M2x4, left.M2x5,
            left.M3x1, left.M3x2, left.M3x3, left.M3x4, left.M3x5,
            left.M4x1, left.M4x2, left.M4x3, left.M4x4, left.M4x5,
            left.M5x1, left.M5x2, left.M5x3, left.M5x4, left.M5x5, right));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix5x5<T> operator checked *(ValueMatrix5x5<T> left, T right) => new(Operations.ScaleMatrixRight(
            left.M1x1, left.M1x2, left.M1x3, left.M1x4, left.M1x5,
            left.M2x1, left.M2x2, left.M2x3, left.M2x4, left.M2x5,
            left.M3x1, left.M3x2, left.M3x3, left.M3x4, left.M3x5,
            left.M4x1, left.M4x2, left.M4x3, left.M4x4, left.M4x5,
            left.M5x1, left.M5x2, left.M5x3, left.M5x4, left.M5x5, right));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix5x5<T> operator *(T left, ValueMatrix5x5<T> right) => new(Operations.ScaleMatrixLeft(left,
            right.M1x1, right.M1x2, right.M1x3, right.M1x4, right.M1x5,
            right.M2x1, right.M2x2, right.M2x3, right.M2x4, right.M2x5,
            right.M3x1, right.M3x2, right.M3x3, right.M3x4, right.M3x5,
            right.M4x1, right.M4x2, right.M4x3, right.M4x4, right.M4x5,
            right.M5x1, right.M5x2, right.M5x3, right.M5x4, right.M5x5));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix5x5<T> operator checked *(T left, ValueMatrix5x5<T> right) => new(Operations.ScaleMatrixLeft(left,
            right.M1x1, right.M1x2, right.M1x3, right.M1x4, right.M1x5,
            right.M2x1, right.M2x2, right.M2x3, right.M2x4, right.M2x5,
            right.M3x1, right.M3x2, right.M3x3, right.M3x4, right.M3x5,
            right.M4x1, right.M4x2, right.M4x3, right.M4x4, right.M4x5,
            right.M5x1, right.M5x2, right.M5x3, right.M5x4, right.M5x5));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static ValueVector5<T> operator *(ValueMatrix5x5<T> left, IVector5<T> right) => new(Operations.MultiplyMatrixVector(
            left.M1x1, left.M1x2, left.M1x3, left.M1x4, left.M1x5,
            left.M2x1, left.M2x2, left.M2x3, left.M2x4, left.M2x5,
            left.M3x1, left.M3x2, left.M3x3, left.M3x4, left.M3x5,
            left.M4x1, left.M4x2, left.M4x3, left.M4x4, left.M4x5,
            left.M5x1, left.M5x2, left.M5x3, left.M5x4, left.M5x5,
            right.X, right.Y, right.Z, right.W, right.V
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector5<T> operator checked *(ValueMatrix5x5<T> left, IVector5<T> right) => new(Operations.MultiplyMatrixVector(
            left.M1x1, left.M1x2, left.M1x3, left.M1x4, left.M1x5,
            left.M2x1, left.M2x2, left.M2x3, left.M2x4, left.M2x5,
            left.M3x1, left.M3x2, left.M3x3, left.M3x4, left.M3x5,
            left.M4x1, left.M4x2, left.M4x3, left.M4x4, left.M4x5,
            left.M5x1, left.M5x2, left.M5x3, left.M5x4, left.M5x5,
            right.X, right.Y, right.Z, right.W, right.V
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static ValueVector5<T> operator *(IVector5<T> left, ValueMatrix5x5<T> right) => new(Operations.MultiplyVectorMatrix(
            left.X, left.Y, left.Z, left.W, left.V,
            right.M1x1, right.M1x2, right.M1x3, right.M1x4, right.M1x5,
            right.M2x1, right.M2x2, right.M2x3, right.M2x4, right.M2x5,
            right.M3x1, right.M3x2, right.M3x3, right.M3x4, right.M3x5,
            right.M4x1, right.M4x2, right.M4x3, right.M4x4, right.M4x5,
            right.M5x1, right.M5x2, right.M5x3, right.M5x4, right.M5x5
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector5<T> operator checked *(IVector5<T> left, ValueMatrix5x5<T> right) => new(Operations.MultiplyVectorMatrix(
            left.X, left.Y, left.Z, left.W, left.V,
            right.M1x1, right.M1x2, right.M1x3, right.M1x4, right.M1x5,
            right.M2x1, right.M2x2, right.M2x3, right.M2x4, right.M2x5,
            right.M3x1, right.M3x2, right.M3x3, right.M3x4, right.M3x5,
            right.M4x1, right.M4x2, right.M4x3, right.M4x4, right.M4x5,
            right.M5x1, right.M5x2, right.M5x3, right.M5x4, right.M5x5
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static ValueMatrix5x5<T> operator *(ValueMatrix5x5<T> left, ValueMatrix5x5<T> right) => new(Operations.MultiplyMatrix(
            left.M1x1, left.M1x2, left.M1x3, left.M1x4, left.M1x5,
            left.M2x1, left.M2x2, left.M2x3, left.M2x4, left.M2x5,
            left.M3x1, left.M3x2, left.M3x3, left.M3x4, left.M3x5,
            left.M4x1, left.M4x2, left.M4x3, left.M4x4, left.M4x5,
            left.M5x1, left.M5x2, left.M5x3, left.M5x4, left.M5x5,
            right.M1x1, right.M1x2, right.M1x3, right.M1x4, right.M1x5,
            right.M2x1, right.M2x2, right.M2x3, right.M2x4, right.M2x5,
            right.M3x1, right.M3x2, right.M3x3, right.M3x4, right.M3x5,
            right.M4x1, right.M4x2, right.M4x3, right.M4x4, right.M4x5,
            right.M5x1, right.M5x2, right.M5x3, right.M5x4, right.M5x5
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix5x5<T> operator checked *(ValueMatrix5x5<T> left, ValueMatrix5x5<T> right) => new(Operations.MultiplyMatrix(
            left.M1x1, left.M1x2, left.M1x3, left.M1x4, left.M1x5,
            left.M2x1, left.M2x2, left.M2x3, left.M2x4, left.M2x5,
            left.M3x1, left.M3x2, left.M3x3, left.M3x4, left.M3x5,
            left.M4x1, left.M4x2, left.M4x3, left.M4x4, left.M4x5,
            left.M5x1, left.M5x2, left.M5x3, left.M5x4, left.M5x5,
            right.M1x1, right.M1x2, right.M1x3, right.M1x4, right.M1x5,
            right.M2x1, right.M2x2, right.M2x3, right.M2x4, right.M2x5,
            right.M3x1, right.M3x2, right.M3x3, right.M3x4, right.M3x5,
            right.M4x1, right.M4x2, right.M4x3, right.M4x4, right.M4x5,
            right.M5x1, right.M5x2, right.M5x3, right.M5x4, right.M5x5
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="matrix"></param>
    public static implicit operator ValueMatrix<T>(ValueMatrix5x5<T> matrix) => new(matrix);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tuple"></param>
    public static implicit operator ValueMatrix5x5<T>((
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
    public static implicit operator ValueMatrix5x5<T>((
        (T m1x1, T m1x2, T m1x3, T m1x4, T m1x5) tuple1,
        (T m2x1, T m2x2, T m2x3, T m2x4, T m2x5) tuple2,
        (T m3x1, T m3x2, T m3x3, T m3x4, T m3x5) tuple3,
        (T m4x1, T m4x2, T m4x3, T m4x4, T m4x5) tuple4,
        (T m5x1, T m5x2, T m5x3, T m5x4, T m5x5) tuple5) tuple
        ) => new(
            tuple.tuple1,
            tuple.tuple2,
            tuple.tuple3,
            tuple.tuple4,
            tuple.tuple5
            );
    #endregion

    /// <summary>
    /// Gets the hash code.
    /// </summary>
    /// <returns>An int.</returns>
    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(M1x1); hash.Add(M1x2); hash.Add(M1x3); hash.Add(M1x4); hash.Add(M1x5);
        hash.Add(M2x1); hash.Add(M2x2); hash.Add(M2x3); hash.Add(M2x4); hash.Add(M2x5);
        hash.Add(M3x1); hash.Add(M3x2); hash.Add(M3x3); hash.Add(M3x4); hash.Add(M3x5);
        hash.Add(M4x1); hash.Add(M4x2); hash.Add(M4x3); hash.Add(M4x4); hash.Add(M4x5);
        hash.Add(M5x1); hash.Add(M5x2); hash.Add(M5x3); hash.Add(M5x4); hash.Add(M5x5);
        return hash.ToHashCode();
    }

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="obj">The obj.</param>
    /// <returns>A bool.</returns>
    public override bool Equals(object? obj) => obj is ValueMatrix5x5<T> matrix && Equals(matrix);

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>A bool.</returns>
    public bool Equals(ValueMatrix5x5<T> other)
        => M1x1.Equals(other.M1x1) && M1x2.Equals(other.M1x2) && M1x2.Equals(other.M1x3) && M1x2.Equals(other.M1x4) && M1x2.Equals(other.M1x5) &&
           M2x1.Equals(other.M2x1) && M2x2.Equals(other.M2x2) && M2x2.Equals(other.M2x3) && M2x2.Equals(other.M2x4) && M2x2.Equals(other.M2x5) &&
           M3x1.Equals(other.M3x1) && M3x2.Equals(other.M3x2) && M3x2.Equals(other.M3x3) && M3x2.Equals(other.M3x4) && M3x2.Equals(other.M3x5) &&
           M4x1.Equals(other.M4x1) && M4x2.Equals(other.M4x2) && M4x2.Equals(other.M4x3) && M4x2.Equals(other.M4x4) && M4x2.Equals(other.M4x5) &&
           M5x1.Equals(other.M5x1) && M5x2.Equals(other.M5x2) && M5x2.Equals(other.M5x3) && M5x2.Equals(other.M5x4) && M5x2.Equals(other.M5x5);

    /// <summary>
    /// Parses the.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="provider">The provider.</param>
    /// <returns>A ValueMatrix5x5.</returns>
    public static ValueMatrix5x5<T> Parse(string s, IFormatProvider? provider)
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
    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out ValueMatrix5x5<T> result)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Parses the.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="provider">The provider.</param>
    /// <returns>A ValueMatrix5x5.</returns>
    public static ValueMatrix5x5<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
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
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out ValueMatrix5x5<T> result)
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
    public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(ValueMatrix5x5<T>)}: ({M1x1.ToString(format, formatProvider)}, {M1x2.ToString(format, formatProvider)}, {M2x1.ToString(format, formatProvider)}, {M2x2.ToString(format, formatProvider)})";

    /// <summary>
    /// Gets the debugger display.
    /// </summary>
    /// <returns>A string? .</returns>
    private string? GetDebuggerDisplay() => ToString();
}
