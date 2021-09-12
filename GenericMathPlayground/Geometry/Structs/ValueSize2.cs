using GenericMathPlayground.Mathematics;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace GenericMathPlayground.Geometry
{
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
        public ValueSize2(IVector2<T> value) => (Width, Height) = value;

        public ValueSize2((T Width, T Height) tuple) => (Width, Height) = tuple;

        public ValueSize2(T width, T height) => (Width, Height) = (width, height);
        #endregion

        #region Deconstructors
        public void Deconstruct(out T x, out T y) => (x, y) = this;
        #endregion

        #region Properties
        public T Width { get; set; }

        public T Height { get; set; }

        public static ValueSize2<T> AdditiveIdentity => new(T.Zero, T.Zero);

        public static ValueSize2<T> MultiplicativeIdentity => new(T.One, T.One);
        #endregion

        #region Operators
        public static bool operator <(ValueSize2<T> left, IVector2<T> right)
        {
            throw new NotImplementedException();
        }

        public static bool operator <=(ValueSize2<T> left, IVector2<T> right)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(ValueSize2<T> left, IVector2<T> right) => left.Equals(right);

        public static bool operator ==(ValueSize2<T> left, ValueSize2<T> right) => left.Equals(right);

        public static bool operator !=(ValueSize2<T> left, IVector2<T> right) => !(left == right);

        public static bool operator !=(ValueSize2<T> left, ValueSize2<T> right) => !(left == right);

        public static bool operator >(ValueSize2<T> left, IVector2<T> right)
        {
            throw new NotImplementedException();
        }

        public static bool operator >=(ValueSize2<T> left, IVector2<T> right)
        {
            throw new NotImplementedException();
        }

        public static ValueSize2<T> operator ++(ValueSize2<T> value) => new(++value.Width, ++value.Height);

        public static ValueSize2<T> operator +(ValueSize2<T> value) => value;

        public static ValueSize2<T> operator +(ValueSize2<T> left, IVector2<T> right) => new(left.Width + right.X, left.Height + right.Y);

        public static ValueSize2<T> operator --(ValueSize2<T> value) => new(--value.Width, --value.Height);

        public static ValueSize2<T> operator -(ValueSize2<T> value) => new(-value.Width, -value.Height);

        public static ValueSize2<T> operator -(ValueSize2<T> left, IVector2<T> right) => new(left.Width - right.X, left.Height - right.Y);

        public static ValuePoint2<T> operator *(ValueSize2<T> left, T right) => new(left.Width * right, left.Height * right);

        public static ValueSize2<T> operator *(ValueSize2<T> left, ValueSize2<T> right) => new(left.Width * right.Width, left.Height * right.Height);

        public static ValueSize2<T> operator *(ValueSize2<T> left, IVector2<T> right) => new(left.Width * right.X, left.Height * right.Y);

        public static ValueSize2<T> operator *(IVector2<T> left, ValueSize2<T> right) => new(left.X * right.Width, left.Y * right.Height);

        public static ValuePoint2<T> operator /(ValueSize2<T> left, T right) => new(left.Width / right, left.Height / right);

        public static ValueSize2<T> operator /(ValueSize2<T> left, ValueSize2<T> right) => new(left.Width / right.Width, left.Height / right.Height);

        public static ValueSize2<T> operator /(ValueSize2<T> left, IVector2<T> right) => new(left.Width / right.X, left.Height / right.Y);

        public static ValueSize2<T> operator /(IVector2<T> left, ValueSize2<T> right) => new(left.X / right.Width, left.Y / right.Height);

        public static ValueSize2<T> operator %(ValueSize2<T> left, T right) => new(left.Width % right, left.Height % right);

        public static ValueSize2<T> operator %(ValueSize2<T> left, ValueSize2<T> right) => new(left.Width % right.Width, left.Height % right.Height);
        #endregion

        public override int GetHashCode() => HashCode.Combine(Width, Height);

        public int CompareTo(object? obj)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(IVector2<T>? other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object? obj) => obj is ValueSize2<T> size && Equals(size);

        public bool Equals(ValueSize2<T> other) => Width == other.Width && Height == other.Height;

        public bool Equals(IVector2<T>? other) => other is IVector2<T> size && Width == size.X && Height == size.Y;

        public static ValueSize2<T> Parse(string s, IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out ValueSize2<T> result)
        {
            throw new NotImplementedException();
        }

        public static ValueSize2<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out ValueSize2<T> result)
        {
            throw new NotImplementedException();
        }

        public override string? ToString() => ToString("R", CultureInfo.InvariantCulture);

        public string ToString(IFormatProvider formatProvider) => ToString("R", formatProvider);

        public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(ValueSize2<T>)}: ({nameof(Width)}: {Width.ToString(format, formatProvider)}, {nameof(Height)}: {Height.ToString(format, formatProvider)})";

        private string? GetDebuggerDisplay() => ToString();
    }
}