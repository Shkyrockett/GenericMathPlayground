using GenericMathPlayground.Mathematics;

namespace GenericMathPlayground.Geometry
{
    public class Point2<T>
        : IPoint2<T>
        where T : INumber<T>
    {
        #region Fields
        private ValuePoint2<T> value;
        #endregion

        #region Constructors
        public Point2() => value = new();

        public Point2(ValuePoint2<T> value) => this.value = value;

        public Point2(IVector2<T> value) => this.value = new(value);

        public Point2((T X, T Y) tuple) => value = new(tuple);

        public Point2(T x, T y) => value = new(x, y);
        #endregion

        #region Deconstructors
        public void Deconstruct(out T X, out T Y) => (X, Y) = value;
        #endregion

        #region Properties
        public ValuePoint2<T> Value { get { return value; } set { this.value = value; } }

        public T X { get { return value.X; } set { this.value.X = value; } }

        public T Y { get { return value.Y; } set { this.value.Y = value; } }
        #endregion

        #region Operators
        public static implicit operator ValuePoint2<T>(Point2<T> value) => value;

        public static explicit operator Point2<T>(ValuePoint2<T> value) => new(value);
        #endregion
    }
}