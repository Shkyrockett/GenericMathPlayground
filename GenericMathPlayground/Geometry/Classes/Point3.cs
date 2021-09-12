using GenericMathPlayground.Mathematics;

namespace GenericMathPlayground.Geometry
{
    public class Point3<T>
        : IPoint3<T>
        where T : INumber<T>
    {
        #region Fields
        private ValuePoint3<T> value;
        #endregion

        #region Constructors
        public Point3() => value = new();

        public Point3(ValuePoint3<T> value) => this.value = value;

        public Point3(IVector3<T> value) => this.value = new(value);

        public Point3((T X, T Y, T Z) tuple) => value = new(tuple);

        public Point3(T x, T y, T z) => value = new(x, y, z);
        #endregion

        #region Deconstructors
        public void Deconstruct(out T X, out T Y, out T Z) => (X, Y, Z) = value;
        #endregion

        #region Properties
        public ValuePoint3<T> Value { get { return value; } set { this.value = value; } }

        public T X { get { return value.X; } set { this.value.X = value; } }

        public T Y { get { return value.Y; } set { this.value.Y = value; } }

        public T Z { get { return value.Z; } set { this.value.Z = value; } }
        #endregion

        #region Operators
        public static implicit operator ValuePoint3<T>(Point3<T> value) => value;

        public static explicit operator Point3<T>(ValuePoint3<T> value) => new(value);
        #endregion
    }
}