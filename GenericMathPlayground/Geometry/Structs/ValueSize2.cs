// <copyright file="ValueSize2.cs" company="Shkyrockett" >
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
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace GenericMathPlayground.Geometry
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public struct ValueSize2<T>
        : ISize2<T>,
        IFormattable,
        IParseable<ValueSize2<T>>,
        ISpanParseable<ValueSize2<T>>,
        IComparable,
        IComparable<IVector2<T>>,
        IEquatable<ValueSize2<T>>,
        IAdditiveIdentity<ValueSize2<T>, ValueSize2<T>>,
        IMultiplicativeIdentity<ValueSize2<T>, ValueSize2<T>>,
        IComparisonOperators<ValueSize2<T>, IVector2<T>>,
        IEqualityOperators<ValueSize2<T>, IVector2<T>>,
        IIncrementOperators<ValueSize2<T>>,
        IUnaryPlusOperators<ValueSize2<T>, ValueSize2<T>>,
        IAdditionOperators<ValueSize2<T>, IVector2<T>, ValueSize2<T>>,
        IDecrementOperators<ValueSize2<T>>,
        IUnaryNegationOperators<ValueSize2<T>, ValueSize2<T>>,
        ISubtractionOperators<ValueSize2<T>, IVector2<T>, ValueSize2<T>>,
        IMultiplyOperators<ValueSize2<T>, T, ValuePoint2<T>>,
        IMultiplyOperators<ValueSize2<T>, ValueSize2<T>, ValueSize2<T>>,
        IMultiplyOperators<ValueSize2<T>, IVector2<T>, ValueSize2<T>>,
        IDivisionOperators<ValueSize2<T>, T, ValuePoint2<T>>,
        IDivisionOperators<ValueSize2<T>, ValueSize2<T>, ValueSize2<T>>,
        IDivisionOperators<ValueSize2<T>, IVector2<T>, ValueSize2<T>>,
        IModulusOperators<ValueSize2<T>, T, ValueSize2<T>>,
        IModulusOperators<ValueSize2<T>, ValueSize2<T>, ValueSize2<T>>
        where T : INumber<T>
    {
        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public ValueSize2(IVector2<T> value) => (Width, Height) = value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tuple"></param>
        public ValueSize2((T Width, T Height) tuple) => (Width, Height) = tuple;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public ValueSize2(T width, T height) => (Width, Height) = (width, height);
        #endregion

        #region Deconstructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Deconstruct(out T x, out T y) => (x, y) = this;
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public T Width { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public T Height { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static ValueSize2<T> AdditiveIdentity => new(T.Zero, T.Zero);

        /// <summary>
        /// 
        /// </summary>
        public static ValueSize2<T> MultiplicativeIdentity => new(T.One, T.One);
        #endregion

        #region Operators
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <(ValueSize2<T> left, IVector2<T> right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <=(ValueSize2<T> left, IVector2<T> right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(ValueSize2<T> left, IVector2<T> right) => left.Equals(right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(ValueSize2<T> left, ValueSize2<T> right) => left.Equals(right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(ValueSize2<T> left, IVector2<T> right) => !(left == right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(ValueSize2<T> left, ValueSize2<T> right) => !(left == right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >(ValueSize2<T> left, IVector2<T> right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >=(ValueSize2<T> left, IVector2<T> right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ValueSize2<T> operator ++(ValueSize2<T> value) => new(++value.Width, ++value.Height);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ValueSize2<T> operator +(ValueSize2<T> value) => value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static ValueSize2<T> operator +(ValueSize2<T> left, IVector2<T> right) => new(left.Width + right.X, left.Height + right.Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ValueSize2<T> operator --(ValueSize2<T> value) => new(--value.Width, --value.Height);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ValueSize2<T> operator -(ValueSize2<T> value) => new(-value.Width, -value.Height);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static ValueSize2<T> operator -(ValueSize2<T> left, IVector2<T> right) => new(left.Width - right.X, left.Height - right.Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static ValuePoint2<T> operator *(ValueSize2<T> left, T right) => new(left.Width * right, left.Height * right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static ValueSize2<T> operator *(ValueSize2<T> left, ValueSize2<T> right) => new(left.Width * right.Width, left.Height * right.Height);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static ValueSize2<T> operator *(ValueSize2<T> left, IVector2<T> right) => new(left.Width * right.X, left.Height * right.Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static ValueSize2<T> operator *(IVector2<T> left, ValueSize2<T> right) => new(left.X * right.Width, left.Y * right.Height);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static ValuePoint2<T> operator /(ValueSize2<T> left, T right) => new(left.Width / right, left.Height / right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static ValueSize2<T> operator /(ValueSize2<T> left, ValueSize2<T> right) => new(left.Width / right.Width, left.Height / right.Height);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static ValueSize2<T> operator /(ValueSize2<T> left, IVector2<T> right) => new(left.Width / right.X, left.Height / right.Y);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static ValueSize2<T> operator /(IVector2<T> left, ValueSize2<T> right) => new(left.X / right.Width, left.Y / right.Height);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static ValueSize2<T> operator %(ValueSize2<T> left, T right) => new(left.Width % right, left.Height % right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static ValueSize2<T> operator %(ValueSize2<T> left, ValueSize2<T> right) => new(left.Width % right.Width, left.Height % right.Height);
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => HashCode.Combine(Width, Height);

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
        public override bool Equals(object? obj) => obj is ValueSize2<T> size && Equals(size);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(ValueSize2<T> other) => Width == other.Width && Height == other.Height;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(IVector2<T>? other) => other is IVector2<T> size && Width == size.X && Height == size.Y;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static ValueSize2<T> Parse(string s, IFormatProvider? provider)
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
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out ValueSize2<T> result)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static ValueSize2<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
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
        public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out ValueSize2<T> result)
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
        public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(ValueSize2<T>)}: ({nameof(Width)}: {Width.ToString(format, formatProvider)}, {nameof(Height)}: {Height.ToString(format, formatProvider)})";

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string? GetDebuggerDisplay() => ToString();
    }
}