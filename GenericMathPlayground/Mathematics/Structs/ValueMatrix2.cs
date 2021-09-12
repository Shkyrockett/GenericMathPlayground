using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace GenericMathPlayground.Mathematics
{
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public struct ValueMatrix2<T>
        : IMatrix<T>,
        IFormattable,
        IParseable<ValueMatrix2<T>>,
        ISpanParseable<ValueMatrix2<T>>,
        IEquatable<ValueMatrix2<T>>,
        IAdditiveIdentity<ValueMatrix2<T>, ValueMatrix2<T>>,
        IMultiplicativeIdentity<ValueMatrix2<T>, ValueMatrix2<T>>,
        IEqualityOperators<ValueMatrix2<T>, ValueMatrix2<T>>,
        IUnaryPlusOperators<ValueMatrix2<T>, ValueMatrix2<T>>,
        IAdditionOperators<ValueMatrix2<T>, ValueMatrix2<T>, ValueMatrix2<T>>,
        IUnaryNegationOperators<ValueMatrix2<T>, ValueMatrix2<T>>,
        ISubtractionOperators<ValueMatrix2<T>, ValueMatrix2<T>, ValueMatrix2<T>>,
        IMultiplyOperators<ValueMatrix2<T>, T, ValueMatrix2<T>>
        where T : INumber<T>
    {
        #region Constructors
        public ValueMatrix2(IVector2<T> vector1, IVector2<T> vector2) => (M1x1, M1x2, M2x1, M2x2) = (vector1.X, vector1.Y, vector2.X, vector2.Y);

        public ValueMatrix2(ValueMatrix2<T> matrix) => (M1x1, M1x2, M2x1, M2x2) = (matrix.M1x1, matrix.M1x2, matrix.M2x1, matrix.M2x2);

        public ValueMatrix2((T m1x1, T m1x2) tupple1, (T m2x1, T m2x2) tupple2) => ((M1x1, M1x2), (M2x1, M2x2)) = (tupple1, tupple2);

        public ValueMatrix2((T m1x1, T m1x2, T m2x1, T m2x2) tupple) => (M1x1, M1x2, M2x1, M2x2) = tupple;

        public ValueMatrix2(T m1x1, T m1x2, T m2x1, T m2x2) => (M1x1, M1x2, M2x1, M2x2) = (m1x1, m1x2, m2x1, m2x2);
        #endregion

        #region Deconstructors
        public void Deconstruct(out ValueVector2<T> vector1, out ValueVector2<T> vector2) => (vector1, vector2) = (new(M1x1, M1x2), new(M2x1, M2x2));

        public void Deconstruct(out T m1x1, out T m1x2, out T m2x1, out T m2x2) => (m1x1, m1x2, m2x1, m2x2) = (M1x1, M1x2, M2x1, M2x2);
        #endregion

        #region Properties
        public T M1x1 { get; set; }

        public T M1x2 { get; set; }

        public T M2x1 { get; set; }

        public T M2x2 { get; set; }

        public static ValueMatrix2<T> AdditiveIdentity => new(T.Zero, T.Zero, T.Zero, T.Zero);

        public static ValueMatrix2<T> MultiplicativeIdentity => new(T.One, T.Zero, T.Zero, T.One);
        #endregion

        #region Operators
        public static bool operator ==(ValueMatrix2<T> left, ValueMatrix2<T> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ValueMatrix2<T> left, ValueMatrix2<T> right)
        {
            return !(left == right);
        }

        public static ValueMatrix2<T> operator +(ValueMatrix2<T> value)
        {
            throw new NotImplementedException();
        }

        public static ValueMatrix2<T> operator +(ValueMatrix2<T> left, ValueMatrix2<T> right)
        {
            return Operations.AddMatrix(left.M1x1, left.M1x2, left.M2x1, left.M2x2, right.M1x1, right.M1x2, right.M2x1, right.M2x2);
        }

        public static ValueMatrix2<T> operator -(ValueMatrix2<T> value)
        {
            throw new NotImplementedException();
        }

        public static ValueMatrix2<T> operator -(ValueMatrix2<T> left, ValueMatrix2<T> right)
        {
            throw new NotImplementedException();
        }

        public static ValueMatrix2<T> operator *(ValueMatrix2<T> left, T right)
        {
            throw new NotImplementedException();
        }

        public static implicit operator ValueMatrix2<T>((T m1x1, T m1x2, T m2x1, T m2x2) tuple) => new(tuple);

        public static implicit operator ValueMatrix2<T>(((T X, T Y) tuple1, (T X, T Y) tuple2)tuple) => new(tuple.tuple1, tuple.tuple2);
        #endregion

        public override int GetHashCode() => HashCode.Combine(M1x1, M1x2, M2x1, M2x2);

        public override bool Equals(object? obj) => obj is ValueMatrix2<T> matrix && Equals(matrix);

        public bool Equals(ValueMatrix2<T> other)
            => EqualityComparer<T>.Default.Equals(M1x1, other.M1x1) &&
               EqualityComparer<T>.Default.Equals(M1x2, other.M1x2) &&
               EqualityComparer<T>.Default.Equals(M2x1, other.M2x1) &&
               EqualityComparer<T>.Default.Equals(M2x2, other.M2x2);

        public static ValueMatrix2<T> Parse(string s, IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out ValueMatrix2<T> result)
        {
            throw new NotImplementedException();
        }

        public static ValueMatrix2<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out ValueMatrix2<T> result)
        {
            throw new NotImplementedException();
        }

        public override string? ToString() => ToString("R", CultureInfo.InvariantCulture);

        public string ToString(IFormatProvider formatProvider) => ToString("R", formatProvider);

        public string ToString(string? format, IFormatProvider? formatProvider) => $"({M1x1.ToString(format, formatProvider)}, {M1x2.ToString(format, formatProvider)}, {M2x1.ToString(format, formatProvider)}, {M2x2.ToString(format, formatProvider)})";

        private string? GetDebuggerDisplay() => ToString();
    }
}
