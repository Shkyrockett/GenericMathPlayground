using GenericMathPlayground.Mathematics;

namespace GenericMathPlayground.Geometry
{
    public class Size3<T>
        : ISize3<T>
        where T : INumber<T>
    {
        #region Fields
        private ValueSize3<T> value;
        #endregion

        #region Constructors
        public Size3() => value = new();

        public Size3(ValueSize3<T> value) => this.value = value;

        public Size3(IVector3<T> value) => this.value = new(value);

        public Size3((T Width, T Height, T Depth) tuple) => value = new(tuple);

        public Size3(T width, T height, T depth) => value = new(width, height, depth);
        #endregion

        #region Deconstructors
        public void Deconstruct(out T Width, out T Height) => (Width, Height) = value;
        #endregion

        #region Properties
        public ValueSize3<T> Value { get { return value; } set { this.value = value; } }

        public T Width { get { return value.Width; } set { this.value.Width = value; } }

        public T Height { get { return value.Height; } set { this.value.Height = value; } }

        public T Depth { get { return value.Depth; } set { this.value.Depth = value; } }
        #endregion

        #region Operators
        public static implicit operator ValueSize3<T>(Size3<T> value) => value;

        public static explicit operator Size3<T>(ValueSize3<T> value) => new(value);
        #endregion
    }
}