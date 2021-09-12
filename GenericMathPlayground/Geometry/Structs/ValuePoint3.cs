using GenericMathPlayground.Mathematics;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace GenericMathPlayground.Geometry
{
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public struct ValuePoint3<T>
        : IPoint3<T>,
        IFormattable,
        IParseable<ValuePoint3<T>>,
        ISpanParseable<ValuePoint3<T>>,
        IComparable,
        IComparable<IVector3<T>>,
        IEquatable<IVector3<T>>,
        IAdditiveIdentity<ValuePoint3<T>, ValuePoint3<T>>,
        IMultiplicativeIdentity<ValuePoint3<T>, ValuePoint3<T>>,
        IComparisonOperators<ValuePoint3<T>, IVector3<T>>,
        IEqualityOperators<ValuePoint3<T>, IVector3<T>>,
        IIncrementOperators<ValuePoint3<T>>,
        IUnaryPlusOperators<ValuePoint3<T>, ValuePoint3<T>>,
        IAdditionOperators<ValuePoint3<T>, IVector3<T>, ValuePoint3<T>>,
        IDecrementOperators<ValuePoint3<T>>,
        IUnaryNegationOperators<ValuePoint3<T>, ValuePoint3<T>>,
        ISubtractionOperators<ValuePoint3<T>, IVector3<T>, ValuePoint3<T>>,
        IMultiplyOperators<ValuePoint3<T>, T, ValuePoint3<T>>,
        IMultiplyOperators<ValuePoint3<T>, ValueSize3<T>, ValuePoint3<T>>,
        IDivisionOperators<ValuePoint3<T>, T, ValuePoint3<T>>,
        IDivisionOperators<ValuePoint3<T>, ValueSize3<T>, ValuePoint3<T>>,
        IModulusOperators<ValuePoint3<T>, T, ValuePoint3<T>>,
        IModulusOperators<ValuePoint3<T>, ValueSize3<T>, ValuePoint3<T>>
        where T : INumber<T>
    {
        #region Constructors
        public ValuePoint3(IVector3<T> value) => (X, Y, Z) = value;

        public ValuePoint3((T X, T Y, T Z) tuple) => (X, Y, Z) = tuple;

        public ValuePoint3(T x, T y, T z) => (X, Y, Z) = (x, y, z);
        #endregion

        #region Deconstructors
        public void Deconstruct(out T X, out T Y, out T Z) => (X, Y, Z) = (this.X, this.Y, this.Z);
        #endregion

        #region Properties
        public T X { get; set; }

        public T Y { get; set; }

        public T Z { get; set; }

        public static ValuePoint3<T> AdditiveIdentity => new(T.Zero, T.Zero, T.Zero);

        public static ValuePoint3<T> MultiplicativeIdentity => new(T.One, T.One, T.One);
        #endregion

        #region Operators
        public static bool operator <(ValuePoint3<T> left, IVector3<T> right)
        {
            throw new NotImplementedException();
        }

        public static bool operator <=(ValuePoint3<T> left, IVector3<T> right)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(ValuePoint3<T> left, IVector3<T> right) => left.Equals(right);

        public static bool operator ==(ValuePoint3<T> left, ValuePoint3<T> right) => left.Equals(right);

        public static bool operator !=(ValuePoint3<T> left, IVector3<T> right) => !(left == right);

        public static bool operator !=(ValuePoint3<T> left, ValuePoint3<T> right) => !(left == right);

        public static bool operator >(ValuePoint3<T> left, IVector3<T> right)
        {
            throw new NotImplementedException();
        }

        public static bool operator >=(ValuePoint3<T> left, IVector3<T> right)
        {
            throw new NotImplementedException();
        }

        public static ValuePoint3<T> operator ++(ValuePoint3<T> value) => new(++value.X, ++value.Y, ++value.Z);

        public static ValuePoint3<T> operator +(ValuePoint3<T> value) => value;

        public static ValuePoint3<T> operator +(ValuePoint3<T> left, IVector3<T> right) => new(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

        public static ValuePoint3<T> operator --(ValuePoint3<T> value) => new(--value.X, --value.Y, --value.Z);

        public static ValuePoint3<T> operator -(ValuePoint3<T> value) => new(-value.X, -value.Y, -value.Z);

        public static ValuePoint3<T> operator -(ValuePoint3<T> left, IVector3<T> right) => new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

        public static ValuePoint3<T> operator *(ValuePoint3<T> left, T right) => new(left.X * right, left.Y * right, left.Z * right);

        public static ValuePoint3<T> operator *(ValuePoint3<T> left, ValueSize3<T> right) => new(left.X * right.Width, left.Y * right.Height, left.Z * right.Depth);

        public static ValuePoint3<T> operator /(ValuePoint3<T> left, T right) => new(left.X / right, left.Y / right, left.Z / right);

        public static ValuePoint3<T> operator /(ValuePoint3<T> left, ValueSize3<T> right) => new(left.X / right.Width, left.Y / right.Height, left.Z / right.Depth);

        public static ValuePoint3<T> operator %(ValuePoint3<T> left, T right) => new(left.X % right, left.Y % right, left.Z % right);

        public static ValuePoint3<T> operator %(ValuePoint3<T> left, ValueSize3<T> right) => new(left.X % right.Width, left.Y % right.Height, left.Z % right.Depth);
        #endregion

        public override int GetHashCode() => HashCode.Combine(X, Y, Z);

        public int CompareTo(object? obj)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(IVector3<T>? other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object? obj) => obj is ValuePoint3<T> point && Equals(point);

        public bool Equals(ValuePoint3<T> other) => X == other.X && Y == other.Y && Z == other.Z;

        public bool Equals(IVector3<T>? other) => other is IVector3<T> vector && X == vector.X && Y == vector.Y && Z == vector.Z;

        public static ValuePoint3<T> Parse(string s, IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out ValuePoint3<T> result)
        {
            throw new NotImplementedException();
        }

        public static ValuePoint3<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out ValuePoint3<T> result)
        {
            throw new NotImplementedException();
        }

        public override string? ToString() => ToString("R", CultureInfo.InvariantCulture);

        public string ToString(IFormatProvider formatProvider) => ToString("R", formatProvider);

        public string ToString(string? format, IFormatProvider? formatProvider) => $"{nameof(ValuePoint3<T>)}: ({nameof(X)}: {X.ToString(format, formatProvider)}, {nameof(Y)}: {Y.ToString(format, formatProvider)}, {nameof(Z)}: {Z.ToString(format, formatProvider)})";

        private string? GetDebuggerDisplay() => ToString();
    }
}
