using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace GenericMathPlayground.Mathematics
{
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
        public ValueVector3(IVector3<T> vector) => (X, Y, Z) = vector;

        public ValueVector3((T X, T Y, T Z) tupple) => (X, Y, Z) = tupple;

        public ValueVector3(T x, T y, T z) => (X, Y, Z) = (x, y, z);
        #endregion

        #region Deconstructors
        public void Deconstruct(out T X, out T Y, out T Z) => (X, Y, Z) = (this.X, this.Y, this.Z);
        #endregion

        #region Properties
        public T X { get; set; }

        public T Y { get; set; }

        public T Z { get; set; }

        public static ValueVector3<T> AdditiveIdentity => new(T.Zero, T.Zero, T.Zero);

        public static ValueVector3<T> MultiplicativeIdentity => new(T.One, T.One, T.One);
        #endregion

        #region Operators
        public static bool operator ==(ValueVector3<T> left, IVector3<T> right) => left.Equals(right);

        public static bool operator ==(ValueVector3<T> left, ValueVector3<T> right) => left.Equals(right);

        public static bool operator !=(ValueVector3<T> left, IVector3<T> right) => !(left == right);

        public static bool operator !=(ValueVector3<T> left, ValueVector3<T> right) => !(left == right);

        public static ValueVector3<T> operator +(ValueVector3<T> value) => value;

        public static ValueVector3<T> operator +(ValueVector3<T> left, IVector3<T> right) => new(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

        public static ValueVector3<T> operator -(ValueVector3<T> value) => new(-value.X, -value.Y, -value.Z);

        public static ValueVector3<T> operator -(ValueVector3<T> left, IVector3<T> right) => new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

        public static ValueVector3<T> operator *(ValueVector3<T> left, T right) => new(left.X * right, left.Y * right, left.Z * right);
        #endregion

        public override int GetHashCode() => HashCode.Combine(X, Y, Z);

        public override bool Equals(object? obj) => obj is ValueVector3<T> point && Equals(point);

        public bool Equals(IVector3<T>? other) => other is IVector3<T> vector && X == vector.X && Y == vector.Y && Z == vector.Z;

        public bool Equals(ValueVector3<T> other) => X == other.X && Y == other.Y && Z == other.Z;

        public static ValueVector3<T> Parse(string s, IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public static ValueVector3<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out ValueVector3<T> result)
        {
            throw new NotImplementedException();
        }

        public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out ValueVector3<T> result)
        {
            throw new NotImplementedException();
        }

        public override string? ToString() => ToString("R", CultureInfo.InvariantCulture);

        public string ToString(IFormatProvider formatProvider) => ToString("R", formatProvider);

        public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(ValueVector3<T>)}: ({nameof(X)}: {X.ToString(format, formatProvider)}, {nameof(Y)}: {Y.ToString(format, formatProvider)}, {nameof(Z)}: {Z.ToString(format, formatProvider)})";

        private string? GetDebuggerDisplay() => ToString();
    }
}
