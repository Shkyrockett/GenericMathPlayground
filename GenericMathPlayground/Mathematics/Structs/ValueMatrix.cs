// <copyright file="ValueMatrix.cs" company="Shkyrockett" >
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
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace GenericMathPlayground.Mathematics;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
[TypeConverter(typeof(ExpandableObjectConverter))]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public struct ValueMatrix<T>
    : IMatrix<T>,
    IFormattable,
    IParseable<ValueMatrix<T>>,
    ISpanParseable<ValueMatrix<T>>,
    IEquatable<ValueMatrix<T>>,
    IAdditiveIdentityMethod<ValueMatrix<T>, ValueMatrix<T>>,
    IAdditiveIdentity2DMethod<ValueMatrix<T>, ValueMatrix<T>>,
    IMultiplicativeIdentityMethod<ValueMatrix<T>, ValueMatrix<T>>,
    IMultiplicativeIdentity2DMethod<ValueMatrix<T>, ValueMatrix<T>>,
    IEqualityOperators<ValueMatrix<T>, ValueMatrix<T>>,
    IUnaryPlusOperators<ValueMatrix<T>, ValueMatrix<T>>,
    IAdditionOperators<ValueMatrix<T>, ValueMatrix<T>, ValueMatrix<T>>,
    IUnaryNegationOperators<ValueMatrix<T>, ValueMatrix<T>>,
    ISubtractionOperators<ValueMatrix<T>, ValueMatrix<T>, ValueMatrix<T>>,
    IMultiplyOperators<ValueMatrix<T>, ValueMatrix<T>, ValueMatrix<T>>,
    IMultiplyOperators2<IVector<T>, ValueMatrix<T>, ValueVector<T>>,
    IMultiplyOperators<ValueMatrix<T>, IVector<T>, ValueVector<T>>,
    IMultiplyOperators<ValueMatrix<T>, T, ValueMatrix<T>>,
    IMultiplyOperators2<T, ValueMatrix<T>, ValueMatrix<T>>
    where T : INumber<T>
{
    #region Constructors
    /// <summary>
    /// 
    /// </summary>
    /// <param name="vectors"></param>
    public ValueMatrix(IVector<T>[] vectors) => Items = Factories.MatrixFromVectorRows(vectors);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="matrix"></param>
    public ValueMatrix(IMatrix<T> matrix) => Items = matrix.Items;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="matrix"></param>
    public ValueMatrix(T[,] matrix) => Items = matrix;
    #endregion

    #region Deconstructors
    /// <summary>
    /// 
    /// </summary>
    /// <param name="vectors"></param>
    public void Deconstruct(out ValueVector<T>[] vectors) => vectors = Factories.MatrixVectorRows<T>(Items);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="vectors"></param>
    public void Deconstruct(out T[][] vectors) => vectors = Factories.MatrixRows<T>(Items);
    #endregion

    #region Properties
    /// <summary>
    /// 
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T[,] Items { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public int Rows => Items.GetLength(0);

    /// <summary>
    /// 
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public int Columns => Items.GetLength(1);

    /// <summary>
    /// Gets the determinant.
    /// </summary>
    /// <value>
    /// The determinant.
    /// </value>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public T Determinant => Operations.Determinant<T>(Items);

    /// <summary>
    /// 
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public bool IsScaler => Operations.IsScaler<T>(Items);

    /// <summary>
    /// 
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public bool IsVector => Operations.IsVector<T>(Items);

    /// <summary>
    /// 
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public bool IsSquareMatrix => Operations.IsSquareMatrix<T>(Items);

    /// <summary>
    /// 
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public bool IsAdditiveIdentity => Operations.IsAdditiveIdentity<T>(Items);

    /// <summary>
    /// 
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public bool IsMultiplicativeIdentity => Operations.IsMultiplicativeIdentity<T>(Items);

    /// <summary>
    /// 
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public bool IsLowerMatrix => Operations.IsLowerMatrix<T>(Items);

    /// <summary>
    /// 
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public bool IsUpperMatrix => Operations.IsUpperMatrix<T>(Items);
    #endregion

    #region Operators
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(ValueMatrix<T> left, ValueMatrix<T> right) => left.Equals(right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(ValueMatrix<T> left, ValueMatrix<T> right) => !(left == right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueMatrix<T> operator +(ValueMatrix<T> value) => value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix<T> operator +(ValueMatrix<T> left, ValueMatrix<T> right) => new(Operations.Add<T>(left.Items, right.Items));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueMatrix<T> operator -(ValueMatrix<T> value) => new(Operations.Negate<T>(value.Items));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix<T> operator -(ValueMatrix<T> left, ValueMatrix<T> right) => new(Operations.Subtract<T>(left.Items, right.Items));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix<T> operator *(ValueMatrix<T> left, ValueMatrix<T> right) => new(Operations.Multiply<T>(left.Items, right.Items));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector<T> operator *(IVector<T> left, ValueMatrix<T> right) => new(Operations.Multiply<T>(left.Items, right.Items));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueVector<T> operator *(ValueMatrix<T> left, IVector<T> right) => new(Operations.Multiply<T>(left.Items, right.Items));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix<T> operator *(ValueMatrix<T> left, T right) => new(Operations.Scale(left.Items, right));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix<T> operator *(T left, ValueMatrix<T> right) => new(Operations.Scale(left, right.Items));
    #endregion

    #region Factories
    /// <summary>
    /// 
    /// </summary>
    /// <param name="size"></param>
    /// <returns></returns>
    public static ValueMatrix<T> AdditiveIdentity(int size) => new(Factories.AdditiveIdentity<T>(size, size));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="collumns"></param>
    /// <param name="rows"></param>
    /// <returns></returns>
    public static ValueMatrix<T> AdditiveIdentity(int collumns, int rows) => new(Factories.AdditiveIdentity<T>(collumns, rows));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="size"></param>
    /// <returns></returns>
    public static ValueMatrix<T> MultiplicativeIdentity(int size) => new(Factories.MultiplicativeIdentity<T>(size, size));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="collumns"></param>
    /// <param name="rows"></param>
    /// <returns></returns>
    public static ValueMatrix<T> MultiplicativeIdentity(int collumns, int rows) => new(Factories.MultiplicativeIdentity<T>(collumns, rows));
    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public ValueMatrix<T> Transpose() => new(Operations.Transpose<T>(Items));

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public ValueMatrix<T> RotateClockwise() => new(Operations.RotateMatrixClockwise<T>(Items));

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public ValueMatrix<T> RotateCounterClockwise() => new(Operations.RotateMatrixCounterClockwise<T>(Items));

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode() => Items.GetHashCode();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj) => obj is ValueMatrix<T> matrix && Equals(matrix);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(ValueMatrix<T> other) => Items is T[] vector1
            && other.Items is T[] vector2
            && vector1.Rank == vector2.Rank
            && Enumerable.Range(0, vector1.Rank).All(dimension => vector1.GetLength(dimension) == vector2.GetLength(dimension)) && vector1.Cast<T>().SequenceEqual(vector2.Cast<T>());

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="provider"></param>
    /// <returns></returns>
    public static ValueMatrix<T> Parse(string s, IFormatProvider? provider)
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
    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out ValueMatrix<T> result)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="provider"></param>
    /// <returns></returns>
    public static ValueMatrix<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
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
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out ValueMatrix<T> result)
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
    public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(ValueMatrix<T>)}: ({string.Join(", ", Items.Select((v, i, j) => $"{Operations.MatrixComponentNames[(i, j)]}: {v}").ToArray())})";

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private string? GetDebuggerDisplay() => ToString();
}
