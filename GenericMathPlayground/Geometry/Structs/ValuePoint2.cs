using GenericMathPlayground.Mathematics;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace GenericMathPlayground.Geometry
{
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
        public ValuePoint2(IVector2<T> value) => (X, Y) = value;

        public ValuePoint2((T X, T Y) tuple) => (X, Y) = tuple;

        public ValuePoint2(T x, T y) => (X, Y) = (x, y);
        #endregion

        #region Deconstructors
        public void Deconstruct(out T X, out T Y) => (X, Y) = (this.X, this.Y);
        #endregion

        #region Properties
        public T X { get; set; }

        public T Y { get; set; }

        public static ValuePoint2<T> AdditiveIdentity => new(T.Zero, T.Zero);

        public static ValuePoint2<T> MultiplicativeIdentity => new(T.One, T.One);
        #endregion

        #region Operators
        public static bool operator <(ValuePoint2<T> left, IVector2<T> right)
        {
            throw new NotImplementedException();
        }

        public static bool operator <=(ValuePoint2<T> left, IVector2<T> right)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(ValuePoint2<T> left, IVector2<T> right) => left.Equals(right);

        public static bool operator ==(ValuePoint2<T> left, ValuePoint2<T> right) => left.Equals(right);

        public static bool operator !=(ValuePoint2<T> left, IVector2<T> right) => !(left == right);

        public static bool operator !=(ValuePoint2<T> left, ValuePoint2<T> right) => !(left == right);

        public static bool operator >(ValuePoint2<T> left, IVector2<T> right)
        {
            throw new NotImplementedException();
        }

        public static bool operator >=(ValuePoint2<T> left, IVector2<T> right)
        {
            throw new NotImplementedException();
        }

        public static ValuePoint2<T> operator ++(ValuePoint2<T> value) => new(++value.X, ++value.Y);

        public static ValuePoint2<T> operator +(ValuePoint2<T> value) => value;

        public static ValuePoint2<T> operator +(ValuePoint2<T> left, IVector2<T> right) => new(left.X + right.X, left.Y + right.Y);

        public static ValuePoint2<T> operator --(ValuePoint2<T> value) => new(--value.X, --value.Y);

        public static ValuePoint2<T> operator -(ValuePoint2<T> value) => new(-value.X, -value.Y);

        public static ValuePoint2<T> operator -(ValuePoint2<T> left, IVector2<T> right) => new(left.X - right.X, left.Y - right.Y);

        public static ValuePoint2<T> operator *(ValuePoint2<T> left, T right) => new(left.X * right, left.Y * right);

        public static ValuePoint2<T> operator *(ValuePoint2<T> left, ValueSize2<T> right) => new(left.X * right.Width, left.Y * right.Height);

        public static ValuePoint2<T> operator /(ValuePoint2<T> left, T right) => new(left.X / right, left.Y / right);

        public static ValuePoint2<T> operator /(ValuePoint2<T> left, ValueSize2<T> right) => new(left.X / right.Width, left.Y / right.Height);

        public static ValuePoint2<T> operator %(ValuePoint2<T> left, T right) => new(left.X % right, left.Y % right);

        public static ValuePoint2<T> operator %(ValuePoint2<T> left, ValueSize2<T> right) => new(left.X % right.Width, left.Y % right.Height);
        #endregion

        public override int GetHashCode() => HashCode.Combine(X, Y);

        public int CompareTo(object? obj)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(IVector2<T>? other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object? obj) => obj is ValuePoint2<T> point && Equals(point);

        public bool Equals(ValuePoint2<T> other) => X == other.X && Y == other.Y;

        public bool Equals(IVector2<T>? other) => other is IVector2<T> vector && X == vector.X && Y == vector.Y;

        public static ValuePoint2<T> Parse(string s, IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out ValuePoint2<T> result)
        {
            throw new NotImplementedException();
        }

        public static ValuePoint2<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out ValuePoint2<T> result)
        {
            throw new NotImplementedException();
        }

        public override string? ToString() => ToString("R", CultureInfo.InvariantCulture);

        public string ToString(IFormatProvider formatProvider) => ToString("R", formatProvider);

        public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(ValuePoint2<T>)}: ({nameof(X)}: {X.ToString(format, formatProvider)}, {nameof(Y)}: {Y.ToString(format, formatProvider)})";

        private string? GetDebuggerDisplay() => ToString();
    }
}
