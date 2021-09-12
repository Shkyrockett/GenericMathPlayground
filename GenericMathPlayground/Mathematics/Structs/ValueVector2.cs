// <copyright file="ValueVector2.cs" company="Shkyrockett" >
//     Copyright © 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace GenericMathPlayground.Mathematics
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public struct ValueVector2<T>
        : IVector2<T>,
        IFormattable,
        IParseable<ValueVector2<T>>,
        ISpanParseable<ValueVector2<T>>,
        IEquatable<IVector2<T>>,
        IAdditiveIdentity<ValueVector2<T>, ValueVector2<T>>,
        IMultiplicativeIdentity<ValueVector2<T>, ValueVector2<T>>,
        IEqualityOperators<ValueVector2<T>, IVector2<T>>,
        IEqualityOperators<ValueVector2<T>, ValueVector2<T>>,
        IUnaryPlusOperators<ValueVector2<T>, ValueVector2<T>>,
        IAdditionOperators<ValueVector2<T>, IVector2<T>, ValueVector2<T>>,
        IUnaryNegationOperators<ValueVector2<T>, ValueVector2<T>>,
        ISubtractionOperators<ValueVector2<T>, IVector2<T>, ValueVector2<T>>,
        IMultiplyOperators<ValueVector2<T>, T, ValueVector2<T>>
        where T : INumber<T>
    {
        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        public ValueVector2(IVector2<T> vector) => (X, Y) = vector;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tupple"></param>
        public ValueVector2((T X, T Y) tupple) => (X, Y) = tupple;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public ValueVector2(T x, T y) => (X, Y) = (x, y);
        #endregion

        #region Deconstructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="X"></param>
        /// <param name="y"></param>
        public void Deconstruct(out T X, out T y) => (X, y) = (this.X, this.Y);
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public T X { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public T Y { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static ValueVector2<T> AdditiveIdentity => new(T.Zero, T.Zero);

        /// <summary>
        /// 
        /// </summary>
        public static ValueVector2<T> MultiplicativeIdentity => new(T.One, T.One);
        #endregion

        #region Operators
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(ValueVector2<T> left, IVector2<T> right) => left.Equals(right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(ValueVector2<T> left, ValueVector2<T> right) => left.Equals(right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(ValueVector2<T> left, IVector2<T> right) => !(left == right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(ValueVector2<T> left, ValueVector2<T> right) => !(left == right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ValueVector2<T> operator +(ValueVector2<T> value) => value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static ValueVector2<T> operator +(ValueVector2<T> left, IVector2<T> right) => new(left.X + right.X, left.Y + right.Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ValueVector2<T> operator -(ValueVector2<T> value) => new(-value.X, -value.Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static ValueVector2<T> operator -(ValueVector2<T> left, IVector2<T> right) => new(left.X - right.X, left.Y - right.Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static ValueVector2<T> operator *(ValueVector2<T> left, T right) => new(left.X * right, left.Y * right);
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => HashCode.Combine(X, Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj) => obj is ValueVector2<T> point && Equals(point);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(IVector2<T>? other) => other is IVector2<T> vector && X == vector.X && Y == vector.Y;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(ValueVector2<T> other) => X == other.X && Y == other.Y;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static ValueVector2<T> Parse(string s, IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static ValueVector2<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
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
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out ValueVector2<T> result)
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
        public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out ValueVector2<T> result)
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
        public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(ValueVector2<T>)}: ({nameof(X)}: {X.ToString(format, formatProvider)}, {nameof(Y)}: {Y.ToString(format, formatProvider)})";

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string? GetDebuggerDisplay() => ToString();
    }
}
