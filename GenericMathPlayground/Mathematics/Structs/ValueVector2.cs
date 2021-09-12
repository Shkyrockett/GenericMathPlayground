using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace GenericMathPlayground.Mathematics
{
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
        public ValueVector2(IVector2<T> vector) => (X, Y) = vector;

        public ValueVector2((T X, T Y) tupple) => (X, Y) = tupple;

        public ValueVector2(T x, T y) => (X, Y) = (x, y);
        #endregion

        #region Deconstructors
        public void Deconstruct(out T X, out T y) => (X, y) = (this.X, this.Y);
        #endregion

        #region Properties
        public T X { get; set; }

        public T Y { get; set; }

        public static ValueVector2<T> AdditiveIdentity => new(T.Zero, T.Zero);

        public static ValueVector2<T> MultiplicativeIdentity => new(T.One, T.One);
        #endregion

        #region Operators
        public static bool operator ==(ValueVector2<T> left, IVector2<T> right) => left.Equals(right);

        public static bool operator ==(ValueVector2<T> left, ValueVector2<T> right) => left.Equals(right);

        public static bool operator !=(ValueVector2<T> left, IVector2<T> right) => !(left == right);

        public static bool operator !=(ValueVector2<T> left, ValueVector2<T> right) => !(left == right);

        public static ValueVector2<T> operator +(ValueVector2<T> value) => value;

        public static ValueVector2<T> operator +(ValueVector2<T> left, IVector2<T> right) => new(left.X + right.X, left.Y + right.Y);

        public static ValueVector2<T> operator -(ValueVector2<T> value) => new(-value.X, -value.Y);

        public static ValueVector2<T> operator -(ValueVector2<T> left, IVector2<T> right) => new(left.X - right.X, left.Y - right.Y);

        public static ValueVector2<T> operator *(ValueVector2<T> left, T right) => new(left.X * right, left.Y * right);
        #endregion

        public override int GetHashCode() => HashCode.Combine(X, Y);

        public override bool Equals(object? obj) => obj is ValueVector2<T> point && Equals(point);

        public bool Equals(IVector2<T>? other) => other is IVector2<T> vector && X == vector.X && Y == vector.Y;

        public bool Equals(ValueVector2<T> other) => X == other.X && Y == other.Y;

        public static ValueVector2<T> Parse(string s, IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public static ValueVector2<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out ValueVector2<T> result)
        {
            throw new NotImplementedException();
        }

        public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out ValueVector2<T> result)
        {
            throw new NotImplementedException();
        }

        public override string? ToString() => ToString("R", CultureInfo.InvariantCulture);

        public string ToString(IFormatProvider formatProvider) => ToString("R", formatProvider);

        public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(ValueVector2<T>)}: ({nameof(X)}: {X.ToString(format, formatProvider)}, {nameof(Y)}: {Y.ToString(format, formatProvider)})";

        private string? GetDebuggerDisplay() => ToString();
    }
}
