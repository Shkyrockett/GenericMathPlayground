﻿// <copyright file="ValueMatrix3x3.cs" company="Shkyrockett" >
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
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace GenericMathPlayground.Mathematics;

/// <summary>
/// The value matrix3x3.
/// </summary>
/// <typeparam name="T"></typeparam>
[TypeConverter(typeof(ExpandableObjectConverter))]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public struct ValueMatrix3x3<T>
    : IMatrix<T>, IMatrix3Columns<T, ValueVector3<T>>, IMatrix3Rows<T, ValueVector3<T>>,
    IFormattable,
    IParsable<ValueMatrix3x3<T>>,
    ISpanParsable<ValueMatrix3x3<T>>,
    IEquatable<ValueMatrix3x3<T>>,
    IAdditiveIdentity<ValueMatrix3x3<T>, ValueMatrix3x3<T>>,
    IMultiplicativeIdentity<ValueMatrix3x3<T>, ValueMatrix3x3<T>>,
    IEqualityOperators<ValueMatrix3x3<T>, ValueMatrix3x3<T>, bool>,
    IUnaryPlusOperators<ValueMatrix3x3<T>, ValueMatrix3x3<T>>,
    IAdditionOperators<ValueMatrix3x3<T>, ValueMatrix3x3<T>, ValueMatrix3x3<T>>,
    IUnaryNegationOperators<ValueMatrix3x3<T>, ValueMatrix3x3<T>>,
    ISubtractionOperators<ValueMatrix3x3<T>, ValueMatrix3x3<T>, ValueMatrix3x3<T>>,
    IMultiplyOperators<ValueMatrix3x3<T>, T, ValueMatrix3x3<T>>,
    IMultiplyOperators2<T, ValueMatrix3x3<T>, ValueMatrix3x3<T>>,
    IMultiplyOperators<ValueMatrix3x3<T>, IVector3<T>, ValueVector3<T>>,
    IMultiplyOperators2<IVector3<T>, ValueMatrix3x3<T>, ValueVector3<T>>,
    IMultiplyOperators<ValueMatrix3x3<T>, ValueMatrix3x3<T>, ValueMatrix3x3<T>>
    where T : INumber<T>
{
    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="ValueMatrix3x3{T}"/> class.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public ValueMatrix3x3() : this(
        T.One, T.Zero, T.Zero,
        T.Zero, T.One, T.Zero,
        T.Zero, T.Zero, T.One
        )
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueMatrix3x3{T}"/> class.
    /// </summary>
    /// <param name="vector1">The vector1.</param>
    /// <param name="vector2">The vector2.</param>
    /// <param name="vector3">The vector3.</param>
    public ValueMatrix3x3(IVector3<T> vector1, IVector3<T> vector2, IVector3<T> vector3) => (
        M1x1, M1x2, M1x3,
        M2x1, M2x2, M2x3,
        M3x1, M3x2, M3x3
        ) = (
        vector1.X, vector1.Y, vector1.Z,
        vector2.X, vector2.Y, vector2.Z,
        vector3.X, vector3.Y, vector3.Z
        );

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueMatrix3x3{T}"/> class.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    public ValueMatrix3x3(ValueMatrix3x3<T> matrix) => (
        M1x1, M1x2, M1x3,
        M2x1, M2x2, M2x3,
        M3x1, M3x2, M3x3
        ) = (
        matrix.M1x1, matrix.M1x2, matrix.M1x3,
        matrix.M2x1, matrix.M2x2, matrix.M2x3,
        matrix.M3x1, matrix.M3x2, matrix.M3x3
        );

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueMatrix3x3{T}"/> class.
    /// </summary>
    /// <param name="tuple1">The tuple1.</param>
    /// <param name="tuple2">The tuple2.</param>
    /// <param name="tuple3">The tuple3.</param>
    public ValueMatrix3x3(
        (T m1x1, T m1x2, T m1x3) tuple1,
        (T m2x1, T m2x2, T m2x3) tuple2,
        (T m3x1, T m3x2, T m3x3) tuple3) => (
        (M1x1, M1x2, M1x3),
        (M2x1, M2x2, M2x3),
        (M3x1, M3x2, M3x3)
        ) = (
        tuple1,
        tuple2,
        tuple3
        );

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueMatrix3x3{T}"/> class.
    /// </summary>
    /// <param name="tuple">The tuple.</param>
    public ValueMatrix3x3((
        T m1x1, T m1x2, T m1x3,
        T m2x1, T m2x2, T m2x3,
        T m3x1, T m3x2, T m3x3
        ) tuple) => (
        M1x1, M1x2, M1x3,
        M2x1, M2x2, M2x3,
        M3x1, M3x2, M3x3
        ) = tuple;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueMatrix3x3{T}"/> class.
    /// </summary>
    /// <param name="m1x1">The m1x1.</param>
    /// <param name="m1x2">The m1x2.</param>
    /// <param name="m1x3">The m1x3.</param>
    /// <param name="m2x1">The m2x1.</param>
    /// <param name="m2x2">The m2x2.</param>
    /// <param name="m2x3">The m2x3.</param>
    /// <param name="m3x1">The m3x1.</param>
    /// <param name="m3x2">The m3x2.</param>
    /// <param name="m3x3">The m3x3.</param>
    public ValueMatrix3x3(
        T m1x1, T m1x2, T m1x3,
        T m2x1, T m2x2, T m2x3,
        T m3x1, T m3x2, T m3x3
        ) => (
        M1x1, M1x2, M1x3,
        M2x1, M2x2, M2x3,
        M3x1, M3x2, M3x3
        ) = (
        m1x1, m1x2, m1x3,
        m2x1, m2x2, m2x3,
        m3x1, m3x2, m3x3
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
        out ValueVector3<T> vector1,
        out ValueVector3<T> vector2,
        out ValueVector3<T> vector3
        ) => (vector1, vector2, vector3) = (
        new(M1x1, M1x2, M1x3),
        new(M2x1, M2x2, M2x3),
        new(M3x1, M3x2, M3x3)
        );

    /// <summary>
    /// Deconstructs the.
    /// </summary>
    /// <param name="m1x1">The m1x1.</param>
    /// <param name="m1x2">The m1x2.</param>
    /// <param name="m1x3">The m1x3.</param>
    /// <param name="m2x1">The m2x1.</param>
    /// <param name="m2x2">The m2x2.</param>
    /// <param name="m2x3">The m2x3.</param>
    /// <param name="m3x1">The m3x1.</param>
    /// <param name="m3x2">The m3x2.</param>
    /// <param name="m3x3">The m3x3.</param>
    public void Deconstruct(
        out T m1x1, out T m1x2, out T m1x3,
        out T m2x1, out T m2x2, out T m2x3,
        out T m3x1, out T m3x2, out T m3x3
        ) => (
        m1x1, m1x2, m1x3,
        m2x1, m2x2, m2x3,
        m3x1, m3x2, m3x3
        ) = (
        M1x1, M1x2, M1x3,
        M2x1, M2x2, M2x3,
        M3x1, M3x2, M3x3
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
                    { M1x1, M1x2, M1x3 },
                    { M2x1, M2x2, M2x3 },
                    { M3x1, M3x2, M3x3 }
                };
        }
        set
        {
            (
                M1x1, M1x2, M1x3,
                M2x1, M2x2, M2x3,
                M3x1, M3x2, M3x3
            ) = (
                value[0, 0], value[0, 1], value[0, 2],
                value[1, 0], value[1, 1], value[1, 2],
                value[2, 0], value[2, 1], value[2, 2]
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
    public int Columns => 3;

    /// <summary>
    /// Gets or sets the X-Column.
    /// </summary>
    /// <value>
    /// The cx.
    /// </value>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    [Description("The First column of the " + nameof(ValueMatrix3x3<T>))]
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
    [Description("The Second column of the " + nameof(ValueMatrix3x3<T>))]
    public ValueVector3<T> ColumnY { get { return new ValueVector3<T>(M1x2, M2x2, M3x2); } set { (M1x2, M2x2, M3x2) = value; } }

    /// <summary>
    /// Gets or sets the Z-Column.
    /// </summary>
    /// <value>
    /// The cz.
    /// </value>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    [Description("The Third column of the " + nameof(ValueMatrix3x3<T>))]
    public ValueVector3<T> ColumnZ { get { return new ValueVector3<T>(M1x3, M2x3, M3x3); } set { (M1x3, M2x3, M3x3) = value; } }

    /// <summary>
    /// Gets or sets the X-Row.
    /// </summary>
    /// <value>
    /// The rx.
    /// </value>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    [Description("The First row of the " + nameof(ValueMatrix3x3<T>))]
    public ValueVector3<T> RowX { get { return new ValueVector3<T>(M1x1, M1x2, M1x3); } set { (M1x1, M1x2, M1x3) = value; } }

    /// <summary>
    /// Gets or sets the Y-Row.
    /// </summary>
    /// <value>
    /// The ry.
    /// </value>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    [Description("The Second row of the " + nameof(ValueMatrix3x3<T>))]
    public ValueVector3<T> RowY { get { return new ValueVector3<T>(M2x1, M2x2, M2x3); } set { (M2x1, M2x2, M2x3) = value; } }

    /// <summary>
    /// Gets or sets the Z-Row.
    /// </summary>
    /// <value>
    /// The rz.
    /// </value>
    [Browsable(false)]
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    [RefreshProperties(RefreshProperties.All)]
    [Description("The Third row of the " + nameof(ValueMatrix3x3<T>))]
    public ValueVector3<T> RowZ { get { return new ValueVector3<T>(M3x1, M3x2, M3x3); } set { (M3x1, M3x2, M3x3) = value; } }

    /// <summary>
    /// Gets the determinant.
    /// </summary>
    /// <value>
    /// The determinant.
    /// </value>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public T Determinant => Operations.MatrixDeterminant(M1x1, M1x2, M1x3, M2x1, M2x2, M2x3, M3x1, M3x2, M3x3);

    /// <summary>
    /// Gets the additive identity.
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public static ValueMatrix3x3<T> AdditiveIdentity => new(
        T.Zero, T.Zero, T.Zero,
        T.Zero, T.Zero, T.Zero,
        T.Zero, T.Zero, T.Zero
        );

    /// <summary>
    /// Gets the multiplicative identity.
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public static ValueMatrix3x3<T> MultiplicativeIdentity => new(
        T.One, T.Zero, T.Zero,
        T.Zero, T.One, T.Zero,
        T.Zero, T.Zero, T.One
        );
    #endregion

    #region Operators
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(ValueMatrix3x3<T> left, ValueMatrix3x3<T> right) => left.Equals(right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(ValueMatrix3x3<T> left, ValueMatrix3x3<T> right) => !(left == right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueMatrix3x3<T> operator +(ValueMatrix3x3<T> value) => value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix3x3<T> operator +(ValueMatrix3x3<T> left, ValueMatrix3x3<T> right) => Operations.AddMatrix(
            left.M1x1, left.M1x2, left.M1x3,
            left.M2x1, left.M2x2, left.M2x3,
            left.M3x1, left.M3x2, left.M3x3,
            right.M1x1, right.M1x2, right.M1x3,
            right.M2x1, right.M2x2, right.M2x3,
            right.M3x1, right.M3x2, right.M3x3
            );

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix3x3<T> operator checked +(ValueMatrix3x3<T> left, ValueMatrix3x3<T> right) => Operations.AddMatrix(
            left.M1x1, left.M1x2, left.M1x3,
            left.M2x1, left.M2x2, left.M2x3,
            left.M3x1, left.M3x2, left.M3x3,
            right.M1x1, right.M1x2, right.M1x3,
            right.M2x1, right.M2x2, right.M2x3,
            right.M3x1, right.M3x2, right.M3x3
            );

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueMatrix3x3<T> operator -(ValueMatrix3x3<T> value) => new(Operations.NegateMatrix(
            value.M1x1, value.M1x2, value.M1x3,
            value.M2x1, value.M2x2, value.M2x3,
            value.M3x1, value.M3x2, value.M3x3
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueMatrix3x3<T> operator checked -(ValueMatrix3x3<T> value) => new(Operations.NegateMatrix(
            value.M1x1, value.M1x2, value.M1x3,
            value.M2x1, value.M2x2, value.M2x3,
            value.M3x1, value.M3x2, value.M3x3
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix3x3<T> operator -(ValueMatrix3x3<T> left, ValueMatrix3x3<T> right) => Operations.SubtractMatrix(
            left.M1x1, left.M1x2, left.M1x3,
            left.M2x1, left.M2x2, left.M2x3,
            left.M3x1, left.M3x2, left.M3x3,
            right.M1x1, right.M1x2, right.M1x3,
            right.M2x1, right.M2x2, right.M2x3,
            right.M3x1, right.M3x2, right.M3x3
            );

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix3x3<T> operator checked -(ValueMatrix3x3<T> left, ValueMatrix3x3<T> right) => Operations.SubtractMatrix(
            left.M1x1, left.M1x2, left.M1x3,
            left.M2x1, left.M2x2, left.M2x3,
            left.M3x1, left.M3x2, left.M3x3,
            right.M1x1, right.M1x2, right.M1x3,
            right.M2x1, right.M2x2, right.M2x3,
            right.M3x1, right.M3x2, right.M3x3
            );

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix3x3<T> operator *(ValueMatrix3x3<T> left, T right) => new(Operations.ScaleMatrixRight(
            left.M1x1, left.M1x2, left.M1x3,
            left.M2x1, left.M2x2, left.M2x3,
            left.M3x1, left.M3x2, left.M3x3, right));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix3x3<T> operator checked *(ValueMatrix3x3<T> left, T right) => new(Operations.ScaleMatrixRight(
            left.M1x1, left.M1x2, left.M1x3,
            left.M2x1, left.M2x2, left.M2x3,
            left.M3x1, left.M3x2, left.M3x3, right));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix3x3<T> operator *(T left, ValueMatrix3x3<T> right) => new(Operations.ScaleMatrixLeft(left,
            right.M1x1, right.M1x2, right.M1x3,
            right.M2x1, right.M2x2, right.M2x3,
            right.M3x1, right.M3x2, right.M3x3));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix3x3<T> operator checked *(T left, ValueMatrix3x3<T> right) => new(Operations.ScaleMatrixLeft(left,
            right.M1x1, right.M1x2, right.M1x3,
            right.M2x1, right.M2x2, right.M2x3,
            right.M3x1, right.M3x2, right.M3x3));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static ValueVector3<T> operator *(ValueMatrix3x3<T> left, IVector3<T> right) => new(Operations.MultiplyMatrixVector(
            left.M1x1, left.M1x2, left.M1x3,
            left.M2x1, left.M2x2, left.M2x3,
            left.M3x1, left.M3x2, left.M3x3,
            right.X, right.Y, right.Z
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector3<T> operator checked *(ValueMatrix3x3<T> left, IVector3<T> right) => new(Operations.MultiplyMatrixVector(
            left.M1x1, left.M1x2, left.M1x3,
            left.M2x1, left.M2x2, left.M2x3,
            left.M3x1, left.M3x2, left.M3x3,
            right.X, right.Y, right.Z
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static ValueVector3<T> operator *(IVector3<T> left, ValueMatrix3x3<T> right) => new(Operations.MultiplyVectorMatrix(
            left.X, left.Y, left.Z,
            right.M1x1, right.M1x2, right.M1x3,
            right.M2x1, right.M2x2, right.M2x3,
            right.M3x1, right.M3x2, right.M3x3
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector3<T> operator checked *(IVector3<T> left, ValueMatrix3x3<T> right) => new(Operations.MultiplyVectorMatrix(
            left.X, left.Y, left.Z,
            right.M1x1, right.M1x2, right.M1x3,
            right.M2x1, right.M2x2, right.M2x3,
            right.M3x1, right.M3x2, right.M3x3
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static ValueMatrix3x3<T> operator *(ValueMatrix3x3<T> left, ValueMatrix3x3<T> right) => new(Operations.MultiplyMatrix(
            left.M1x1, left.M1x2, left.M1x3,
            left.M2x1, left.M2x2, left.M2x3,
            left.M3x1, left.M3x2, left.M3x3,
            right.M1x1, right.M1x2, right.M1x3,
            right.M2x1, right.M2x2, right.M2x3,
            right.M3x1, right.M3x2, right.M3x3
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix3x3<T> operator checked *(ValueMatrix3x3<T> left, ValueMatrix3x3<T> right) => new(Operations.MultiplyMatrix(
            left.M1x1, left.M1x2, left.M1x3,
            left.M2x1, left.M2x2, left.M2x3,
            left.M3x1, left.M3x2, left.M3x3,
            right.M1x1, right.M1x2, right.M1x3,
            right.M2x1, right.M2x2, right.M2x3,
            right.M3x1, right.M3x2, right.M3x3
            ));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="matrix"></param>
    public static implicit operator ValueMatrix<T>(ValueMatrix3x3<T> matrix) => new(matrix);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tuple"></param>
    public static implicit operator ValueMatrix3x3<T>((
        T m1x1, T m1x2, T m1x3,
        T m2x1, T m2x2, T m2x3,
        T m3x1, T m3x2, T m3x3
        ) tuple) => new(tuple);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tuple"></param>
    public static implicit operator ValueMatrix3x3<T>((
        (T m1x1, T m1x2, T m1x3) tuple1,
        (T m2x1, T m2x2, T m2x3) tuple2,
        (T m3x1, T m3x2, T m3x3) tuple3) tuple
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
    public override int GetHashCode()
    {
        HashCode hash = new();
        hash.Add(M1x1);
        hash.Add(M1x2);
        hash.Add(M1x3);
        hash.Add(M2x1);
        hash.Add(M2x2);
        hash.Add(M2x3);
        hash.Add(M3x1);
        hash.Add(M3x2);
        hash.Add(M3x3);
        return hash.ToHashCode();
    }

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="obj">The obj.</param>
    /// <returns>A bool.</returns>
    public override bool Equals(object? obj) => obj is ValueMatrix3x3<T> matrix && Equals(matrix);

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>A bool.</returns>
    public bool Equals(ValueMatrix3x3<T> other)
        => M1x1.Equals(other.M1x1) && M1x2.Equals(other.M1x2) && M1x2.Equals(other.M1x3) &&
           M2x1.Equals(other.M2x1) && M2x2.Equals(other.M2x2) && M2x2.Equals(other.M2x3) &&
           M3x1.Equals(other.M3x1) && M3x2.Equals(other.M3x2) && M3x2.Equals(other.M3x3);

    /// <summary>
    /// Parses the.
    /// </summary>
    /// <param name="source">The s.</param>
    /// <param name="formatProvider">The provider.</param>
    /// <returns>A ValueMatrix3x3.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static ValueMatrix3x3<T> Parse(string source, IFormatProvider? formatProvider) => Parse((ReadOnlySpan<char>)source, formatProvider);

    /// <summary>
    /// Parses the.
    /// </summary>
    /// <param name="source">The s.</param>
    /// <param name="formatProvider">The provider.</param>
    /// <returns>A ValueMatrix3x3.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static ValueMatrix3x3<T> Parse(ReadOnlySpan<char> source, IFormatProvider? formatProvider) => TryParse(source, formatProvider, out var result) ? result : result;

    /// <summary>
    /// Tries the parse.
    /// </summary>
    /// <param name="source">The s.</param>
    /// <param name="formatProvider">The provider.</param>
    /// <param name="result">The result.</param>
    /// <returns>A bool.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool TryParse([NotNullWhen(true)] string? source, IFormatProvider? formatProvider, out ValueMatrix3x3<T> result) => TryParse((ReadOnlySpan<char>)source, formatProvider, out result);

    /// <summary>
    /// Tries the parse.
    /// </summary>
    /// <param name="source">The s.</param>
    /// <param name="formatProvider">The provider.</param>
    /// <param name="result">The result.</param>
    /// <returns>A bool.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool TryParse(ReadOnlySpan<char> source, IFormatProvider? formatProvider, out ValueMatrix3x3<T> result)
    {
        var tokenizer = new Tokenizer(source, formatProvider);
        T.TryParse(tokenizer.NextTokenRequired(), formatProvider, out var result1);
        T.TryParse(tokenizer.NextTokenRequired(), formatProvider, out var result2);
        T.TryParse(tokenizer.NextTokenRequired(), formatProvider, out var result3);
        T.TryParse(tokenizer.NextTokenRequired(), formatProvider, out var result4);
        T.TryParse(tokenizer.NextTokenRequired(), formatProvider, out var result5);
        T.TryParse(tokenizer.NextTokenRequired(), formatProvider, out var result6);
        T.TryParse(tokenizer.NextTokenRequired(), formatProvider, out var result7);
        T.TryParse(tokenizer.NextTokenRequired(), formatProvider, out var result8);
        T.TryParse(tokenizer.NextTokenRequired(), formatProvider, out var result9);
        var value = new ValueMatrix3x3<T>(result1, result2, result3, result4, result5, result6, result7, result8, result9);

        // There should be no more tokens in this string.
        tokenizer.LastTokenRequired();
        result = value;
        return true;
    }

    /// <summary>
    /// Creates a human-readable string that represents this <see cref="ValueMatrix3x3{T}" /> struct.
    /// </summary>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public override string? ToString() => ToString("R", CultureInfo.InvariantCulture);

    /// <summary>
    /// Creates a string representation of this <see cref="ValueMatrix3x3{T}" /> struct based on the IFormatProvider
    /// passed in.  If the provider is null, the CurrentCulture is used.
    /// </summary>
    /// <param name="formatProvider">The format provider.</param>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public string ToString(IFormatProvider formatProvider) => ToString("R", formatProvider);

    /// <summary>
    /// Creates a string representation of this <see cref="ValueMatrix3x3{T}" /> struct based on the IFormatProvider
    /// passed in.  If the provider is null, the CurrentCulture is used.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="formatProvider">The format provider.</param>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(ValueMatrix3x3<T>)}: ({M1x1.ToString(format, formatProvider)}, {M1x2.ToString(format, formatProvider)}, {M2x1.ToString(format, formatProvider)}, {M2x2.ToString(format, formatProvider)})";

    /// <summary>
    /// Gets the debugger display.
    /// </summary>
    /// <returns>
    /// A string representation of this object for display in the debugger.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private string? GetDebuggerDisplay() => ToString();
}
