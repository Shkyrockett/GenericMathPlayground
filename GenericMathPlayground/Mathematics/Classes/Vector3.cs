using GenericMathPlayground.Mathematics;

namespace GenericMathPlayground.Geometry
{
    public class Vector3<T>
        : IVector3<T>
        where T : INumber<T>
    {
        #region Fields
        private ValueVector3<T> value;
        #endregion

        #region Constructors
        public Vector3() => value = new();

        public Vector3(ValueVector3<T> value) => this.value = value;

        public Vector3(IVector3<T> value) => this.value = new(value);

        public Vector3((T X, T Y, T Z) tuple) => value = new(tuple);

        public Vector3(T x, T y, T z) => value = new(x, y, z);
        #endregion

        #region Deconstructors
        public void Deconstruct(out T X, out T Y, out T Z) => (X, Y, Z) = value;
        #endregion

        #region Properties
        public ValueVector3<T> Value { get { return value; } set { this.value = value; } }

        public T X { get { return value.X; } set { this.value.X = value; } }

        public T Y { get { return value.Y; } set { this.value.Y = value; } }

        public T Z { get { return value.Z; } set { this.value.Z = value; } }
        #endregion

        #region Operators
        public static implicit operator ValueVector3<T>(Vector3<T> value) => value;

        public static explicit operator Vector3<T>(ValueVector3<T> value) => new(value);
        #endregion
    }
}