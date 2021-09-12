// <copyright file="ValueVector3.cs" company="Shkyrockett" >
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
    public struct ValueVector3<T>
        : IVector3<T>,
        IFormattable,
        IParseable<ValueVector3<T>>,
        ISpanParseable<ValueVector3<T>>,
        IEquatable<IVector3<T>>,
        IAdditiveIdentity<ValueVector3<T>, ValueVector3<T>>,
        IMultiplicativeIdentity<ValueVector3<T>, ValueVector3<T>>,
        IEqualityOperators<ValueVector3<T>, IVector3<T>>,
        IEqualityOperators<ValueVector3<T>, ValueVector3<T>>,
        IUnaryPlusOperators<ValueVector3<T>, ValueVector3<T>>,
        IAdditionOperators<ValueVector3<T>, IVector3<T>, ValueVector3<T>>,
        IUnaryNegationOperators<ValueVector3<T>, ValueVector3<T>>,
        ISubtractionOperators<ValueVector3<T>, IVector3<T>, ValueVector3<T>>,
        IMultiplyOperators<ValueVector3<T>, T, ValueVector3<T>>
        where T : INumber<T>
    {
        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        public ValueVector3(IVector3<T> vector) => (X, Y, Z) = vector;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tupple"></param>
        public ValueVector3((T X, T Y, T Z) tupple) => (X, Y, Z) = tupple;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public ValueVector3(T x, T y, T z) => (X, Y, Z) = (x, y, z);
        #endregion

        #region Deconstructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        public void Deconstruct(out T X, out T Y, out T Z) => (X, Y, Z) = (this.X, this.Y, this.Z);
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
        public T Z { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static ValueVector3<T> AdditiveIdentity => new(T.Zero, T.Zero, T.Zero);

        /// <summary>
        /// 
        /// </summary>
        public static ValueVector3<T> MultiplicativeIdentity => new(T.One, T.One, T.One);
        #endregion

        #region Operators
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(ValueVector3<T> left, IVector3<T> right) => left.Equals(right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(ValueVector3<T> left, ValueVector3<T> right) => left.Equals(right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(ValueVector3<T> left, IVector3<T> right) => !(left == right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(ValueVector3<T> left, ValueVector3<T> right) => !(left == right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ValueVector3<T> operator +(ValueVector3<T> value) => value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static ValueVector3<T> operator +(ValueVector3<T> left, IVector3<T> right) => new(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ValueVector3<T> operator -(ValueVector3<T> value) => new(-value.X, -value.Y, -value.Z);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static ValueVector3<T> operator -(ValueVector3<T> left, IVector3<T> right) => new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static ValueVector3<T> operator *(ValueVector3<T> left, T right) => new(left.X * right, left.Y * right, left.Z * right);
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => HashCode.Combine(X, Y, Z);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj) => obj is ValueVector3<T> point && Equals(point);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(IVector3<T>? other) => other is IVector3<T> vector && X == vector.X && Y == vector.Y && Z == vector.Z;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(ValueVector3<T> other) => X == other.X && Y == other.Y && Z == other.Z;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static ValueVector3<T> Parse(string s, IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static ValueVector3<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
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
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out ValueVector3<T> result)
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
        public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out ValueVector3<T> result)
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
        public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(ValueVector3<T>)}: ({nameof(X)}: {X.ToString(format, formatProvider)}, {nameof(Y)}: {Y.ToString(format, formatProvider)}, {nameof(Z)}: {Z.ToString(format, formatProvider)})";

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string? GetDebuggerDisplay() => ToString();
    }
}
