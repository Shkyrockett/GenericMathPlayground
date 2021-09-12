using GenericMathPlayground.Mathematics;

namespace GenericMathPlayground.Geometry
{
    public class Vector2<T>
        : IVector2<T>
        where T : INumber<T>
    {
        #region Fields
        private ValueVector2<T> value;
        #endregion

        #region Constructors
        public Vector2() => value = new();

        public Vector2(ValueVector2<T> value) => this.value = value;

        public Vector2(IVector2<T> value) => this.value = new(value);

        public Vector2((T X, T Y) tuple) => value = new(tuple);

        public Vector2(T x, T y) => value = new(x, y);
        #endregion

        #region Deconstructors
        public void Deconstruct(out T X, out T Y) => (X, Y) = value;
        #endregion

        #region Properties
        public ValueVector2<T> Value { get { return value; } set { this.value = value; } }

        public T X { get { return value.X; } set { this.value.X = value; } }

        public T Y { get { return value.Y; } set { this.value.Y = value; } }
        #endregion

        #region Operators
        public static implicit operator ValueVector2<T>(Vector2<T> value) => value;

        public static explicit operator Vector2<T>(ValueVector2<T> value) => new(value);
        #endregion
    }
}