// <copyright file="ValueSize4.cs" company="Shkyrockett" >
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
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public struct ValueSize4<T>
        : ISize4<T>,
        IFormattable,
        IParseable<ValueSize4<T>>,
        ISpanParseable<ValueSize4<T>>,
        IComparable,
        IComparable<IVector4<T>>,
        IEquatable<ValueSize4<T>>,
        IAdditiveIdentity<ValueSize4<T>, ValueSize4<T>>,
        IMultiplicativeIdentity<ValueSize4<T>, ValueSize4<T>>,
        IComparisonOperators<ValueSize4<T>, IVector4<T>>,
        IEqualityOperators<ValueSize4<T>, IVector4<T>>,
        IIncrementOperators<ValueSize4<T>>,
        IUnaryPlusOperators<ValueSize4<T>, ValueSize4<T>>,
        IAdditionOperators<ValueSize4<T>, IVector4<T>, ValueSize4<T>>,
        IAdditionOperators2<IVector4<T>, ValueSize4<T>, IVector4<T>>,
        IDecrementOperators<ValueSize4<T>>,
        IUnaryNegationOperators<ValueSize4<T>, ValueSize4<T>>,
        ISubtractionOperators<ValueSize4<T>, IVector4<T>, ValueSize4<T>>,
        ISubtractionOperators2<IVector4<T>, ValueSize4<T>, IVector4<T>>,
        IMultiplyOperators<ValueSize4<T>, T, ValueSize4<T>>,
        IMultiplyOperators<ValueSize4<T>, ValueSize4<T>, ValueSize4<T>>,
        IMultiplyOperators<ValueSize4<T>, IVector4<T>, ValueSize4<T>>,
        IMultiplyOperators2<IVector4<T>, ValueSize4<T>, IVector4<T>>,
        IDivisionOperators<ValueSize4<T>, T, ValueSize4<T>>,
        IDivisionOperators<ValueSize4<T>, ValueSize4<T>, ValueSize4<T>>,
        IDivisionOperators<ValueSize4<T>, IVector4<T>, ValueSize4<T>>,
        IDivisionOperators2<IVector4<T>, ValueSize4<T>, IVector4<T>>,
        IModulusOperators<ValueSize4<T>, T, ValueSize4<T>>,
        IModulusOperators<ValueSize4<T>, ValueSize4<T>, ValueSize4<T>>,
        IModulusOperators2<IVector4<T>, ValueSize4<T>, IVector4<T>>
        where T : INumber<T>
    {
        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public ValueSize4(IVector4<T> value) => (Width, Height, Depth, Breadth) = value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tuple"></param>
        public ValueSize4((T Width, T Height, T Depth, T Breadth) tuple) => (Width, Height, Depth, Breadth) = tuple;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="depth"></param>
        /// <param name="breadth"></param>
        public ValueSize4(T width, T height, T depth, T breadth) => (Width, Height, Depth, Breadth) = (width, height, depth, breadth);
        #endregion

        #region Deconstructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <param name="Depth"></param>
        /// <param name="Breadth"></param>
        public void Deconstruct(out T Width, out T Height, out T Depth, out T Breadth) => (Width, Height, Depth, Breadth) = this;
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        [RefreshProperties(RefreshProperties.All)]
        public T Width { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [RefreshProperties(RefreshProperties.All)]
        public T Height { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [RefreshProperties(RefreshProperties.All)]
        public T Depth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [RefreshProperties(RefreshProperties.All)]
        public T Breadth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static ValueSize4<T> AdditiveIdentity => new(T.Zero, T.Zero, T.Zero, T.Zero);

        /// <summary>
        /// 
        /// </summary>
        public static ValueSize4<T> MultiplicativeIdentity => new(T.One, T.One, T.One, T.One);
        #endregion

        #region Operators
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <(ValueSize4<T> left, IVector4<T> right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <=(ValueSize4<T> left, IVector4<T> right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(ValueSize4<T> left, IVector4<T> right) => left.Equals(right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(ValueSize4<T> left, ValueSize4<T> right) => left.Equals(right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(ValueSize4<T> left, IVector4<T> right) => !(left == right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(ValueSize4<T> left, ValueSize4<T> right) => !(left == right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >(ValueSize4<T> left, IVector4<T> right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >=(ValueSize4<T> left, IVector4<T> right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ValueSize4<T> operator ++(ValueSize4<T> value) => new(++value.Width, ++value.Height, ++value.Depth, ++value.Breadth);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ValueSize4<T> operator +(ValueSize4<T> value) => value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static ValueSize4<T> operator +(ValueSize4<T> left, IVector4<T> right) => new(left.Width + right.X, left.Height + right.Y, left.Depth + right.Z, left.Breadth + right.W);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static IVector4<T> operator +(IVector4<T> left, ValueSize4<T> right) => new ValuePoint4<T>(left.X + right.Width, left.Y + right.Height, left.Z + right.Depth, left.W + right.Breadth);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ValueSize4<T> operator --(ValueSize4<T> value) => new(--value.Width, --value.Height, --value.Depth, --value.Breadth);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ValueSize4<T> operator -(ValueSize4<T> value) => new(-value.Width, -value.Height, -value.Depth, -value.Breadth);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static ValueSize4<T> operator -(ValueSize4<T> left, IVector4<T> right) => new(left.Width - right.X, left.Height - right.Y, left.Depth - right.Z, left.Breadth - right.W);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static IVector4<T> operator -(IVector4<T> left, ValueSize4<T> right) => new ValuePoint4<T>(left.X - right.Width, left.Y - right.Height, left.Z - right.Depth, left.W - right.Breadth);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static ValueSize4<T> operator *(ValueSize4<T> left, T right) => new (left.Width * right, left.Height * right, left.Depth * right, left.Breadth * right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static ValueSize4<T> operator *(ValueSize4<T> left, ValueSize4<T> right) => new(left.Width * right.Width, left.Height * right.Height, left.Depth * right.Depth, left.Breadth * right.Breadth);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static ValueSize4<T> operator *(ValueSize4<T> left, IVector4<T> right) => new(left.Width * right.X, left.Height * right.Y, left.Depth * right.Z, left.Breadth * right.W);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static IVector4<T> operator *(IVector4<T> left, ValueSize4<T> right) => new ValuePoint4<T>(left.X * right.Width, left.Y * right.Height, left.Z * right.Depth, left.W * right.Breadth);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static ValueSize4<T> operator /(ValueSize4<T> left, T right) => new (left.Width / right, left.Height / right, left.Depth / right, left.Breadth / right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static ValueSize4<T> operator /(ValueSize4<T> left, ValueSize4<T> right) => new(left.Width / right.Width, left.Height / right.Height, left.Depth / right.Depth, left.Breadth / right.Breadth);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static ValueSize4<T> operator /(ValueSize4<T> left, IVector4<T> right) => new(left.Width / right.X, left.Height / right.Y, left.Depth / right.Z, left.Breadth / right.W);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static IVector4<T> operator /(IVector4<T> left, ValueSize4<T> right) => new ValuePoint4<T>(left.X / right.Width, left.Y / right.Height, left.Z / right.Depth, left.W / right.Breadth);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static ValueSize4<T> operator %(ValueSize4<T> left, T right) => new(left.Width % right, left.Height % right, left.Depth % right, left.Breadth % right);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static ValueSize4<T> operator %(ValueSize4<T> left, ValueSize4<T> right) => new(left.Width % right.Width, left.Height % right.Height, left.Depth % right.Depth, left.Breadth % right.Breadth);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static IVector4<T> operator %(IVector4<T> left, ValueSize4<T> right) => new ValuePoint4<T>(left.X % right.Width, left.Y % right.Height, left.Z % right.Depth, left.W % right.Breadth);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator ValueSize4<T>(ValueVector4<T> value) => new(value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator ValueSize4<T>(ValuePoint4<T> value) => new(value);
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => HashCode.Combine(Width, Height, Depth, Breadth);

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
        public int CompareTo(IVector4<T>? other)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj) => obj is ValueSize4<T> size && Equals(size);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(ValueSize4<T> other) => Width.Equals(other.Width) && Height.Equals(other.Height) && Depth.Equals(other.Depth) && Breadth.Equals(other.Breadth);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(IVector4<T>? other) => other is IVector4<T> size && Width.Equals(size.X) && Height.Equals(size.Y) && Depth.Equals(size.Z) && Breadth.Equals(size.W);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static ValueSize4<T> Parse(string s, IFormatProvider? provider)
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
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out ValueSize4<T> result)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static ValueSize4<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
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
        public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out ValueSize4<T> result)
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
        public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(ValueSize4<T>)}: ({nameof(Width)}: {Width.ToString(format, formatProvider)}, {nameof(Height)}: {Height.ToString(format, formatProvider)}, {nameof(Depth)}: {Depth.ToString(format, formatProvider)}, {nameof(Breadth)}: {Breadth.ToString(format, formatProvider)})";

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string? GetDebuggerDisplay() => ToString();
    }
}