// <copyright file="ValuePolynomial.cs" company="Shkyrockett" >
//     Copyright © 2014 - 2022 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary>
//     Based on code from https://github.com/superlloyd/Poly, http://www.kevlindev.com/geometry/2D/intersections/, and https://github.com/Pomax/bezierjs.
// </summary>
// <remarks></remarks>

using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace GenericMathPlayground.Mathematics
{
    /// <summary>
    /// The value polynomial.
    /// </summary>
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public class ValuePolynomial<T>
        : IPolynomial<T>,
        IParsable<ValuePolynomial<T>>,
        ISpanParsable<ValuePolynomial<T>>,
        IEquatable<ValuePolynomial<T>>,
        IAdditiveIdentity<ValuePolynomial<T>, ValuePolynomial<T>>,
        IMultiplicativeIdentity<ValuePolynomial<T>, ValuePolynomial<T>>,
        IEqualityOperators<ValuePolynomial<T>, IPolynomial<T>, bool>,
        IEqualityOperators<ValuePolynomial<T>, ValuePolynomial<T>, bool>,
        IIncrementOperators<ValuePolynomial<T>>,
        IUnaryPlusOperators<ValuePolynomial<T>, ValuePolynomial<T>>,
        IAdditionOperators<ValuePolynomial<T>, IPolynomial<T>, ValuePolynomial<T>>,
        IAdditionOperators2<IPolynomial<T>, ValuePolynomial<T>, IPolynomial<T>>,
        IDecrementOperators<ValuePolynomial<T>>,
        IUnaryNegationOperators<ValuePolynomial<T>, ValuePolynomial<T>>,
        ISubtractionOperators<ValuePolynomial<T>, IPolynomial<T>, ValuePolynomial<T>>,
        ISubtractionOperators2<IPolynomial<T>, ValuePolynomial<T>, IPolynomial<T>>,
        IMultiplyOperators<ValuePolynomial<T>, T, ValuePolynomial<T>>,
        IMultiplyOperators2<T, ValuePolynomial<T>, ValuePolynomial<T>>,
        IMultiplyOperators<ValuePolynomial<T>, IPolynomial<T>, ValuePolynomial<T>>,
        IMultiplyOperators2<IPolynomial<T>, ValuePolynomial<T>, IPolynomial<T>>,
        IDivisionOperators<ValuePolynomial<T>, T, ValuePolynomial<T>>,
        IDivisionOperators<ValuePolynomial<T>, ValuePolynomial<T>, ValuePolynomial<T>>,
        IDivisionOperators<ValuePolynomial<T>, IPolynomial<T>, ValuePolynomial<T>>,
        IDivisionOperators2<IPolynomial<T>, ValuePolynomial<T>, IPolynomial<T>>
        where T : INumber<T>
    {
        #region Static Properties
        /// <summary>
        /// Gets the additive identity.
        /// </summary>
        public static ValuePolynomial<T> AdditiveIdentity { get; } = new ValuePolynomial<T>(T.Zero, T.Zero);

        /// <summary>
        /// Gets the multiplicative identity.
        /// </summary>
        public static ValuePolynomial<T> MultiplicativeIdentity { get; } = new ValuePolynomial<T>(T.One, T.Zero);
        #endregion

        #region Fields
        /// <summary>
        /// The coefficients of the polynomial in lowest degree to highest degree order.
        /// </summary>
        private T[] coefficients;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ValuePolynomial{T}"/> class.
        /// </summary>
        /// <param name="coefficients">The coefficients.</param>
        public ValuePolynomial(params T[] coefficients)
        {
            this.coefficients = coefficients;
        }
        #endregion

        #region Indexers
        /// <summary>
        /// Gets or sets the coefficient at the given index.
        /// </summary>
        /// <value>
        /// The <see cref="double"/>.
        /// </value>
        /// <param name="index">The index of the coefficient to retrieve.</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="ArgumentOutOfRangeException">index</exception>
        /// <remarks>
        /// <para>The indexer is in highest degree to lowest format.</para>
        /// </remarks>
        /// <acknowledgment>
        /// modified from the indexer used in Super Lloyd's Poly class https://github.com/superlloyd/Poly
        /// </acknowledgment>
        public T this[int index]
        {
            get
            {
                return index < 0 || index >= coefficients.Length ? T.Zero : coefficients[coefficients.Length - 1 - index];
            }
            set
            {
                //if (IsReadonly)
                //{
                //    throw new InvalidOperationException($"{nameof(Polynomial<T>)} is Read-only.");
                //}

                if (index < 0 || index > coefficients.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                coefficients[coefficients.Length - 1 - index] = value;
                //degree = null;
            }
        }

        /// <summary>
        /// Gets or sets the coefficient at the given term index.
        /// </summary>
        /// <value>
        /// The <see cref="double"/>.
        /// </value>
        /// <param name="index">The term index of the coefficient to retrieve.</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="ArgumentOutOfRangeException">index</exception>
        /// <remarks>
        /// <para>The <see cref="PolynomialTerm" /> indexer is in highest degree to lowest format.</para>
        /// </remarks>
        /// <acknowledgment>
        /// modified from the indexer used in Super Lloyd's Poly class https://github.com/superlloyd/Poly
        /// </acknowledgment>
        public T this[PolynomialTerm index]
        {
            get
            {
                return index < 0 || (int)index >= coefficients.Length ? T.Zero : coefficients[coefficients.Length - 1 - (int)index];
            }
            set
            {
                //if (IsReadonly)
                //{
                //    throw new InvalidOperationException($"{nameof(Polynomial<T>)} is Read-only.");
                //}

                if (index < 0 || (int)index > coefficients.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                coefficients[coefficients.Length - 1 - (int)index] = value;
                //degree = null;
            }
        }

        /// <summary>
        /// Gets or sets the coefficient of the given degree index.
        /// </summary>
        /// <value>
        /// The <see cref="double"/>.
        /// </value>
        /// <param name="index">The degree of the coefficient to retrieve.</param>
        /// <returns>
        /// The value of the coefficient of the requested degree.
        /// </returns>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="ArgumentOutOfRangeException">index</exception>
        /// <remarks>
        /// <para>The <see cref="PolynomialDegree" /> indexer is in lowest degree to highest format.</para>
        /// </remarks>
        /// <acknowledgment>
        /// modified from the indexer used in Super Lloyd's Poly class https://github.com/superlloyd/Poly
        /// </acknowledgment>
        public T this[PolynomialDegree index]
        {
            get
            {
                return index < 0 || (int)index >= coefficients.Length ? T.Zero : coefficients[(int)index];
            }
            set
            {
                //if (IsReadonly)
                //{
                //    throw new InvalidOperationException($"{nameof(Polynomial<T>)} is Read-only.");
                //}

                if (index < 0 || (int)index > coefficients.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                coefficients[(int)index] = value;
                //degree = null;
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the coefficients of the polynomial from highest degree to lowest degree order.
        /// </summary>
        /// <value>
        /// The coefficients.
        /// </value>
        /// <remarks>
        /// <para>This property presents the <see cref="Coefficients" /> in the reverse order than they are internally stored.</para>
        /// </remarks>
        [TypeConverter(typeof(ArrayConverter))]
        public unsafe T[] Coefficients
        {
            get => coefficients.Reverse().ToArray();
            set
            {
                //if (IsReadonly)
                //{
                //    throw new InvalidOperationException($"{nameof(Polynomial<T>)} is Read-only.");
                //}

                coefficients = value.Reverse().ToArray();
            }
        }

        /// <summary>
        /// Gets a debug string that represents the text version of the <see cref="ValuePolynomial{T}" />.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text => ToString(string.Empty /* format string */, CultureInfo.InvariantCulture /* format provider */);
        #endregion

        #region Operators
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static ValuePolynomial<T> operator checked ++(ValuePolynomial<T> value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static ValuePolynomial<T> operator ++(ValuePolynomial<T> value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static ValuePolynomial<T> operator +(ValuePolynomial<T> value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static ValuePolynomial<T> operator +(ValuePolynomial<T> left, IPolynomial<T> right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static ValuePolynomial<T> operator checked +(ValuePolynomial<T> left, IPolynomial<T> right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static IPolynomial<T> operator checked +(IPolynomial<T> left, ValuePolynomial<T> right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static IPolynomial<T> operator +(IPolynomial<T> left, ValuePolynomial<T> right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static ValuePolynomial<T> operator checked --(ValuePolynomial<T> value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static ValuePolynomial<T> operator --(ValuePolynomial<T> value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static ValuePolynomial<T> operator checked -(ValuePolynomial<T> value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static ValuePolynomial<T> operator -(ValuePolynomial<T> value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static ValuePolynomial<T> operator checked -(ValuePolynomial<T> left, IPolynomial<T> right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static ValuePolynomial<T> operator -(ValuePolynomial<T> left, IPolynomial<T> right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static IPolynomial<T> operator checked -(IPolynomial<T> left, ValuePolynomial<T> right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static IPolynomial<T> operator -(IPolynomial<T> left, ValuePolynomial<T> right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static ValuePolynomial<T> operator checked *(ValuePolynomial<T> left, T right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static ValuePolynomial<T> operator *(ValuePolynomial<T> left, T right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static ValuePolynomial<T> operator checked *(T left, ValuePolynomial<T> right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static ValuePolynomial<T> operator *(T left, ValuePolynomial<T> right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static ValuePolynomial<T> operator checked *(ValuePolynomial<T> left, IPolynomial<T> right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static ValuePolynomial<T> operator *(ValuePolynomial<T> left, IPolynomial<T> right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static IPolynomial<T> operator checked *(IPolynomial<T> left, ValuePolynomial<T> right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static IPolynomial<T> operator *(IPolynomial<T> left, ValuePolynomial<T> right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static ValuePolynomial<T> operator checked /(ValuePolynomial<T> left, T right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static ValuePolynomial<T> operator /(ValuePolynomial<T> left, T right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static ValuePolynomial<T> operator checked /(ValuePolynomial<T> left, ValuePolynomial<T> right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static ValuePolynomial<T> operator /(ValuePolynomial<T> left, ValuePolynomial<T> right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static ValuePolynomial<T> operator checked /(ValuePolynomial<T> left, IPolynomial<T> right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static ValuePolynomial<T> operator /(ValuePolynomial<T> left, IPolynomial<T> right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static IPolynomial<T> operator checked /(IPolynomial<T> left, ValuePolynomial<T> right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static IPolynomial<T> operator /(IPolynomial<T> left, ValuePolynomial<T> right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(ValuePolynomial<T>? left, ValuePolynomial<T>? right)
        {
            return EqualityComparer<ValuePolynomial<T>>.Default.Equals(left, right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(ValuePolynomial<T>? left, ValuePolynomial<T>? right)
        {
            return !(left == right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static bool operator ==(ValuePolynomial<T> left, IPolynomial<T> right)
        {
            return EqualityComparer<T[]>.Default.Equals(left.Coefficients, right.Coefficients);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(ValuePolynomial<T> left, IPolynomial<T> right)
        {
            return !(left == right);
        }
        #endregion

        /// <summary>
        /// Gets the hash code.
        /// </summary>
        /// <returns>An int.</returns>
        public override int GetHashCode() => HashCode.Combine(coefficients);

        /// <summary>
        /// Equals the.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>A bool.</returns>
        public override bool Equals(object? obj) => obj is ValuePolynomial<T> polynomial && Equals(polynomial.coefficients);

        /// <summary>
        /// Equals the.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>A bool.</returns>
        public bool Equals(ValuePolynomial<T>? other) => EqualityComparer<T[]>.Default.Equals(coefficients, other?.coefficients);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Equals(IPolynomial<T>? other) => throw new NotImplementedException();

        /// <summary>
        /// Parses the.
        /// </summary>
        /// <param name="source">The s.</param>
        /// <param name="formatProvider">The provider.</param>
        /// <returns>A ValuePolynomial.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public static ValuePolynomial<T> Parse(string source, IFormatProvider? formatProvider) => Parse((ReadOnlySpan<char>)source, formatProvider);

        /// <summary>
        /// Parses the.
        /// </summary>
        /// <param name="source">The s.</param>
        /// <param name="formatProvider">The provider.</param>
        /// <returns>A ValuePolynomial.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public static ValuePolynomial<T> Parse(ReadOnlySpan<char> source, IFormatProvider? formatProvider) => TryParse(source, formatProvider, out var result) ? result : result;

        /// <summary>
        /// Tries the parse.
        /// </summary>
        /// <param name="source">The s.</param>
        /// <param name="formatProvider">The provider.</param>
        /// <param name="result">The result.</param>
        /// <returns>A bool.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public static bool TryParse([NotNullWhen(true)] string? source, IFormatProvider? formatProvider, out ValuePolynomial<T> result) => TryParse((ReadOnlySpan<char>)source, formatProvider, out result);

        /// <summary>
        /// Tries the parse.
        /// </summary>
        /// <param name="source">The s.</param>
        /// <param name="formatProvider">The provider.</param>
        /// <param name="result">The result.</param>
        /// <returns>A bool.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public static bool TryParse(ReadOnlySpan<char> source, IFormatProvider? formatProvider, out ValuePolynomial<T> result)
        {
            var tokenizer = new Tokenizer(source, formatProvider);
            var values = new List<T>();
            while (tokenizer.TryGetNextToken(out var token))
            {
                T.TryParse(token, formatProvider, out var tokenValue);
                values.Add(tokenValue);
            }

            var value = new ValuePolynomial<T>(values.ToArray());

            // There should be no more tokens in this string.
            tokenizer.LastTokenRequired();
            result = value;
            return true;
        }

        /// <summary>
        /// Creates a human-readable string that represents this <see cref="ValuePolynomial{T}" /> struct.
        /// </summary>
        /// <returns>
        /// A string representation of this object.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public override string ToString() => ToString(string.Empty /* format string */, CultureInfo.InvariantCulture /* format provider */);

        /// <summary>
        /// Creates a string representation of this <see cref="ValuePolynomial{T}" /> struct based on the IFormatProvider
        /// passed in.  If the provider is null, the CurrentCulture is used.
        /// </summary>
        /// <param name="formatProvider">The provider.</param>
        /// <returns>
        /// A string representation of this object.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public string ToString(IFormatProvider? formatProvider) => ToString(string.Empty /* format string */, formatProvider /* format provider */);

        /// <summary>
        /// Creates a string representation of this <see cref="ValuePolynomial{T}" /> struct based on the IFormatProvider
        /// passed in.  If the provider is null, the CurrentCulture is used.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="formatProvider">The provider.</param>
        /// <returns>
        /// A string representation of this object.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            // ¹²³⁴⁵⁶⁷⁸⁹⁰ ⁱ ₁₂₃₄₅₆₇₈₉₀ ⁻⁼⁺⁽⁾ⁿ‽ ₊₋₌₍₎ₓ
            var coefs = new List<string>();
            var signs = new List<string>();
            for (var i = (coefficients?.Length ?? 0) - 1; i >= 0; i--)
            {
                var value = coefficients![i];
                var powStr = i.ToString(format, formatProvider);
                powStr = powStr.Replace("1", "¹", StringComparison.OrdinalIgnoreCase);
                powStr = powStr.Replace("2", "²", StringComparison.OrdinalIgnoreCase);
                powStr = powStr.Replace("3", "³", StringComparison.OrdinalIgnoreCase);
                powStr = powStr.Replace("4", "⁴", StringComparison.OrdinalIgnoreCase);
                powStr = powStr.Replace("5", "⁵", StringComparison.OrdinalIgnoreCase);
                powStr = powStr.Replace("6", "⁶", StringComparison.OrdinalIgnoreCase);
                powStr = powStr.Replace("7", "⁷", StringComparison.OrdinalIgnoreCase);
                powStr = powStr.Replace("8", "⁸", StringComparison.OrdinalIgnoreCase);
                powStr = powStr.Replace("9", "⁹", StringComparison.OrdinalIgnoreCase);
                powStr = powStr.Replace("0", "⁰", StringComparison.OrdinalIgnoreCase);
                if (value != T.Zero)
                {
                    var sign = (value < T.Zero) ? " - " : " + ";
                    value = T.Abs(value);
                    var valueString = value.ToString(format, formatProvider);
                    if (i > 0)
                    {
                        if (value == T.One)
                        {
                            valueString = "x";
                        }
                        else
                        {
                            valueString += "x";
                        }
                    }

                    if (i > 1)
                    {
                        valueString += powStr;
                    }

                    signs.Add(sign);
                    coefs.Add(valueString);
                }
            }
            if (signs.Count > 0)
            {
                signs[0] = (signs[0] == " + ") ? "" : "-";
            }

            var result = string.Empty;
            for (var i = 0; i < coefs.Count; i++)
            {
                result += signs[i] + coefs[i];
            }

            return result;
        }

        /// <summary>
        /// Gets the debugger display.
        /// </summary>
        /// <returns>
        /// A string representation of this object for display in the debugger.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        private string GetDebuggerDisplay() => ToString();
    }
}
