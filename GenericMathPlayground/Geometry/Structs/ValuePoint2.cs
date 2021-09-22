// <copyright file="ValuePoint2.cs" company="Shkyrockett" >
//     Copyright © 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using GenericMathPlayground.Mathematics;
using GenericMathPlayground.Physics;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace GenericMathPlayground.Geometry
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    //[TypeConverter(typeof(StructConverter<ValuePoint2<MetersUnit>>))]
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public struct ValuePoint2<T>
        : IPoint2<T>,
        IFormattable,
        IParseable<ValuePoint2<T>>,
        ISpanParseable<ValuePoint2<T>>,
        IComparable,
        IComparable<IVector2<T>>,
        IEquatable<IVector2<T>>,
        IAdditiveIdentity<ValuePoint2<T>, ValuePoint2<T>>,
        IMultiplicativeIdentity<ValuePoint2<T>, ValuePoint2<T>>,
        IComparisonOperators<ValuePoint2<T>, IVector2<T>>,
        IEqualityOperators<ValuePoint2<T>, IVector2<T>>,
        IIncrementOperators<ValuePoint2<T>>,
        IUnaryPlusOperators<ValuePoint2<T>, ValuePoint2<T>>,
        IAdditionOperators<ValuePoint2<T>, IVector2<T>, ValuePoint2<T>>,
        IDecrementOperators<ValuePoint2<T>>,
        IUnaryNegationOperators<ValuePoint2<T>, ValuePoint2<T>>,
        ISubtractionOperators<ValuePoint2<T>, IVector2<T>, ValuePoint2<T>>,
        IMultiplyOperators<ValuePoint2<T>, T, ValuePoint2<T>>,
        IMultiplyOperators<ValuePoint2<T>, ValueSize2<T>, ValuePoint2<T>>,
        IDivisionOperators<ValuePoint2<T>, T, ValuePoint2<T>>,
        IDivisionOperators<ValuePoint2<T>, ValueSize2<T>, ValuePoint2<T>>,
        IModulusOperators<ValuePoint2<T>, T, ValuePoint2<T>>,
        IModulusOperators<ValuePoint2<T>, ValueSize2<T>, ValuePoint2<T>>
        where T : INumber<T>
    {
        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public ValuePoint2(IVector2<T> value) => (X, Y) = value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tuple"></param>
        public ValuePoint2((T X, T Y) tuple) => (X, Y) = tuple;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public ValuePoint2(T x, T y) => (X, Y) = (x, y);
        #endregion

        #region Deconstructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public void Deconstruct(out T X, out T Y) => (X, Y) = (this.X, this.Y);
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        [RefreshProperties(RefreshProperties.All)]
        public T X { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [RefreshProperties(RefreshProperties.All)]
        public T Y { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static ValuePoint2<T> AdditiveIdentity => new(T.Zero, T.Zero);

        /// <summary>
        /// 
        /// </summary>
        public static ValuePoint2<T> MultiplicativeIdentity => new(T.One, T.One);
        #endregion

        #region Operators
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <(ValuePoint2<T> left, IVector2<T> right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <=(ValuePoint2<T> left, IVector2<T> right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(ValuePoint2<T> left, IVector2<T> right) => left.Equals(right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(ValuePoint2<T> left, ValuePoint2<T> right) => left.Equals(right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(ValuePoint2<T> left, IVector2<T> right) => !(left == right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(ValuePoint2<T> left, ValuePoint2<T> right) => !(left == right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >(ValuePoint2<T> left, IVector2<T> right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >=(ValuePoint2<T> left, IVector2<T> right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ValuePoint2<T> operator ++(ValuePoint2<T> value) => new(++value.X, ++value.Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ValuePoint2<T> operator +(ValuePoint2<T> value) => value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static ValuePoint2<T> operator +(ValuePoint2<T> left, IVector2<T> right) => new(left.X + right.X, left.Y + right.Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ValuePoint2<T> operator --(ValuePoint2<T> value) => new(--value.X, --value.Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ValuePoint2<T> operator -(ValuePoint2<T> value) => new(-value.X, -value.Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static ValuePoint2<T> operator -(ValuePoint2<T> left, IVector2<T> right) => new(left.X - right.X, left.Y - right.Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static ValuePoint2<T> operator *(ValuePoint2<T> left, T right) => new(left.X * right, left.Y * right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static ValuePoint2<T> operator *(ValuePoint2<T> left, ValueSize2<T> right) => new(left.X * right.Width, left.Y * right.Height);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static ValuePoint2<T> operator /(ValuePoint2<T> left, T right) => new(left.X / right, left.Y / right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static ValuePoint2<T> operator /(ValuePoint2<T> left, ValueSize2<T> right) => new(left.X / right.Width, left.Y / right.Height);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static ValuePoint2<T> operator %(ValuePoint2<T> left, T right) => new(left.X % right, left.Y % right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static ValuePoint2<T> operator %(ValuePoint2<T> left, ValueSize2<T> right) => new(left.X % right.Width, left.Y % right.Height);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator ValuePoint2<T>(ValueVector2<T> value) => value;
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
        public int CompareTo(object? obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(IVector2<T>? other)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj) => obj is ValuePoint2<T> point && Equals(point);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(ValuePoint2<T> other) => X.Equals(other.X) && Y.Equals(other.Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(IVector2<T>? other) => other is IVector2<T> vector && X.Equals(vector.X) && Y.Equals(vector.Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static ValuePoint2<T> Parse(string s, IFormatProvider? provider)
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
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out ValuePoint2<T> result)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static ValuePoint2<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
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
        public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out ValuePoint2<T> result)
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
        public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(ValuePoint2<T>)}: ({nameof(X)}: {X.ToString(format, formatProvider)}, {nameof(Y)}: {Y.ToString(format, formatProvider)})";

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string? GetDebuggerDisplay() => ToString();
    }
}
