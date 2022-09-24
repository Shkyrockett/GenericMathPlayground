// <copyright file="ValueMatrix.cs" company="Shkyrockett" >
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
/// The value matrix.
/// </summary>
/// <typeparam name="T"></typeparam>
[TypeConverter(typeof(ExpandableObjectConverter))]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public struct ValueMatrix<T>
    : IMatrix<T>,
    IFormattable,
    IParsable<ValueMatrix<T>>,
    ISpanParsable<ValueMatrix<T>>,
    IEquatable<ValueMatrix<T>>,
    IAdditiveIdentityMethod<ValueMatrix<T>, ValueMatrix<T>>,
    IAdditiveIdentity2DMethod<ValueMatrix<T>, ValueMatrix<T>>,
    IMultiplicativeIdentityMethod<ValueMatrix<T>, ValueMatrix<T>>,
    IMultiplicativeIdentity2DMethod<ValueMatrix<T>, ValueMatrix<T>>,
    IEqualityOperators<ValueMatrix<T>, ValueMatrix<T>, bool>,
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
    /// Initializes a new instance of the <see cref="ValueMatrix{T}"/> class.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public ValueMatrix() : this(new T[,] { }) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueMatrix{T}"/> class.
    /// </summary>
    /// <param name="vectors">The vectors.</param>
    public ValueMatrix(IVector<T>[] vectors) => Items = Factories.MatrixFromVectorRows(vectors);

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueMatrix{T}"/> class.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    public ValueMatrix(IMatrix<T> matrix) => Items = matrix.Items;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValueMatrix{T}"/> class.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    public ValueMatrix(T[,] matrix) => Items = matrix;
    #endregion

    #region Deconstructors
    /// <summary>
    /// Deconstructs the.
    /// </summary>
    /// <param name="vectors">The vectors.</param>
    public void Deconstruct(out ValueVector<T>[] vectors) => vectors = Factories.MatrixVectorRows<T>(Items);

    /// <summary>
    /// Deconstructs the.
    /// </summary>
    /// <param name="vectors">The vectors.</param>
    public void Deconstruct(out T[][] vectors) => vectors = Factories.MatrixRows<T>(Items);
    #endregion

    #region Properties
    /// <summary>
    /// Gets or sets the items.
    /// </summary>
    [RefreshProperties(RefreshProperties.All)]
    public T[,] Items { get; set; }

    /// <summary>
    /// Gets the rows.
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public int Rows => Items.GetLength(0);

    /// <summary>
    /// Gets the columns.
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
    /// Gets a value indicating whether is scaler.
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public bool IsScaler => Operations.IsScaler<T>(Items);

    /// <summary>
    /// Gets a value indicating whether is vector.
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public bool IsVector => Operations.IsVector<T>(Items);

    /// <summary>
    /// Gets a value indicating whether square is matrix.
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public bool IsSquareMatrix => Operations.IsSquareMatrix<T>(Items);

    /// <summary>
    /// Gets a value indicating whether additive is identity.
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public bool IsAdditiveIdentity => Operations.IsAdditiveIdentity<T>(Items);

    /// <summary>
    /// Gets a value indicating whether multiplicative is identity.
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public bool IsMultiplicativeIdentity => Operations.IsMultiplicativeIdentity<T>(Items);

    /// <summary>
    /// Gets a value indicating whether lower is matrix.
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public bool IsLowerMatrix => Operations.IsLowerMatrix<T>(Items);

    /// <summary>
    /// Gets a value indicating whether upper is matrix.
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
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix<T> operator checked +(ValueMatrix<T> left, ValueMatrix<T> right) => new(Operations.Add<T>(left.Items, right.Items));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueMatrix<T> operator -(ValueMatrix<T> value) => new(Operations.Negate<T>(value.Items));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ValueMatrix<T> operator checked -(ValueMatrix<T> value) => new(Operations.Negate<T>(value.Items));

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
    public static ValueMatrix<T> operator checked -(ValueMatrix<T> left, ValueMatrix<T> right) => new(Operations.Subtract<T>(left.Items, right.Items));

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
    public static ValueMatrix<T> operator checked *(ValueMatrix<T> left, ValueMatrix<T> right) => new(Operations.Multiply<T>(left.Items, right.Items));

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
    public static ValueVector<T> operator checked *(IVector<T> left, ValueMatrix<T> right) => new(Operations.Multiply<T>(left.Items, right.Items));

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
    public static ValueVector<T> operator checked *(ValueMatrix<T> left, IVector<T> right) => new(Operations.Multiply<T>(left.Items, right.Items));

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
    public static ValueMatrix<T> operator checked *(ValueMatrix<T> left, T right) => new(Operations.Scale(left.Items, right));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix<T> operator *(T left, ValueMatrix<T> right) => new(Operations.Scale(left, right.Items));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ValueMatrix<T> operator checked *(T left, ValueMatrix<T> right) => new(Operations.Scale(left, right.Items));
    #endregion

    #region Factories
    /// <summary>
    /// Additives the identity.
    /// </summary>
    /// <param name="size">The size.</param>
    /// <returns>A ValueMatrix.</returns>
    public static ValueMatrix<T> AdditiveIdentity(int size) => new(Factories.AdditiveIdentity<T>(size, size));

    /// <summary>
    /// Additives the identity.
    /// </summary>
    /// <param name="collumns">The collumns.</param>
    /// <param name="rows">The rows.</param>
    /// <returns>A ValueMatrix.</returns>
    public static ValueMatrix<T> AdditiveIdentity(int collumns, int rows) => new(Factories.AdditiveIdentity<T>(collumns, rows));

    /// <summary>
    /// Multiplicatives the identity.
    /// </summary>
    /// <param name="size">The size.</param>
    /// <returns>A ValueMatrix.</returns>
    public static ValueMatrix<T> MultiplicativeIdentity(int size) => new(Factories.MultiplicativeIdentity<T>(size, size));

    /// <summary>
    /// Multiplicatives the identity.
    /// </summary>
    /// <param name="collumns">The collumns.</param>
    /// <param name="rows">The rows.</param>
    /// <returns>A ValueMatrix.</returns>
    public static ValueMatrix<T> MultiplicativeIdentity(int collumns, int rows) => new(Factories.MultiplicativeIdentity<T>(collumns, rows));
    #endregion

    /// <summary>
    /// Transposes the.
    /// </summary>
    /// <returns>A ValueMatrix.</returns>
    public ValueMatrix<T> Transpose() => new(Operations.Transpose<T>(Items));

    /// <summary>
    /// Rotates the clockwise.
    /// </summary>
    /// <returns>A ValueMatrix.</returns>
    public ValueMatrix<T> RotateClockwise() => new(Operations.RotateMatrixClockwise<T>(Items));

    /// <summary>
    /// Rotates the counter clockwise.
    /// </summary>
    /// <returns>A ValueMatrix.</returns>
    public ValueMatrix<T> RotateCounterClockwise() => new(Operations.RotateMatrixCounterClockwise<T>(Items));

    /// <summary>
    /// Gets the hash code.
    /// </summary>
    /// <returns>An int.</returns>
    public override int GetHashCode() => Items.GetHashCode();

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="obj">The obj.</param>
    /// <returns>A bool.</returns>
    public override bool Equals(object? obj) => obj is ValueMatrix<T> matrix && Equals(matrix);

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>A bool.</returns>
    public bool Equals(ValueMatrix<T> other) => Items is T[] vector1
            && other.Items is T[] vector2
            && vector1.Rank == vector2.Rank
            && Enumerable.Range(0, vector1.Rank).All(dimension => vector1.GetLength(dimension) == vector2.GetLength(dimension)) && vector1.Cast<T>().SequenceEqual(vector2.Cast<T>());

    /// <summary>
    /// Parses the.
    /// </summary>
    /// <param name="source">The s.</param>
    /// <param name="formatProvider">The provider.</param>
    /// <returns>A ValueMatrix.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static ValueMatrix<T> Parse(string source, IFormatProvider? formatProvider) => Parse((ReadOnlySpan<char>)source, formatProvider);

    /// <summary>
    /// Parses the.
    /// </summary>
    /// <param name="source">The s.</param>
    /// <param name="formatProvider">The provider.</param>
    /// <returns>A ValueMatrix.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static ValueMatrix<T> Parse(ReadOnlySpan<char> source, IFormatProvider? formatProvider) => TryParse(source, formatProvider, out var result) ? result : result;

    /// <summary>
    /// Tries the parse.
    /// </summary>
    /// <param name="source">The s.</param>
    /// <param name="formatProvider">The provider.</param>
    /// <param name="result">The result.</param>
    /// <returns>A bool.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool TryParse([NotNullWhen(true)] string? source, IFormatProvider? formatProvider, out ValueMatrix<T> result) => TryParse((ReadOnlySpan<char>)source, formatProvider, out result);

    /// <summary>
    /// Tries the parse.
    /// </summary>
    /// <param name="source">The s.</param>
    /// <param name="formatProvider">The provider.</param>
    /// <param name="result">The result.</param>
    /// <returns>A bool.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool TryParse(ReadOnlySpan<char> source, IFormatProvider? formatProvider, out ValueMatrix<T> result)
    {
        var tokenizer = new Tokenizer(source, formatProvider);
        var values = new List<T>();
        while (tokenizer.TryGetNextToken(out var token))
        {
            T.TryParse(token, formatProvider, out var tokenValue);
            values.Add(tokenValue);
        }

        var value = new ValueMatrix<T>(/*values*/);

        // There should be no more tokens in this string.
        tokenizer.LastTokenRequired();
        result = value;
        return true;
    }

    /// <summary>
    /// Creates a human-readable string that represents this <see cref="ValueMatrix{T}" /> struct.
    /// </summary>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public override string? ToString() => ToString("R", CultureInfo.InvariantCulture);

    /// <summary>
    /// Creates a string representation of this <see cref="ValueMatrix{T}" /> struct based on the IFormatProvider
    /// passed in.  If the provider is null, the CurrentCulture is used.
    /// </summary>
    /// <param name="formatProvider">The format provider.</param>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public string ToString(IFormatProvider formatProvider) => ToString("R", formatProvider);

    /// <summary>
    /// Creates a string representation of this <see cref="ValueMatrix{T}" /> struct based on the IFormatProvider
    /// passed in.  If the provider is null, the CurrentCulture is used.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="formatProvider">The format provider.</param>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(ValueMatrix<T>)}: ({string.Join(", ", Items.Select((v, i, j) => $"{Operations.MatrixComponentNames[(i, j)]}: {v}").ToArray())})";

    /// <summary>
    /// Gets the debugger display.
    /// </summary>
    /// <returns>
    /// A string representation of this object for display in the debugger.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private string? GetDebuggerDisplay() => ToString();
}
