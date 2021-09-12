using GenericMathPlayground.Mathematics;

namespace GenericMathPlayground.Geometry
{
    public class Size2<T>
        : IVector2<T>
        where T : INumber<T>
    {
        #region Fields
        private ValueSize2<T> value;
        #endregion

        #region Constructors
        public Size2() => value = new();

        public Size2(ValueSize2<T> value) => this.value = value;

        public Size2(IVector2<T> value) => this.value = new(value);

        public Size2((T Width, T Height) tuple) => value = new(tuple);

        public Size2(T width, T height) => value = new(width, height);
        #endregion

        #region Deconstructors
        public void Deconstruct(out T Width, out T Height) => (Width, Height) = value;
        #endregion

        #region Properties
        public ValueSize2<T> Value { get { return value; } set { this.value = value; } }

        public T Width { get { return value.Width; } set { this.value.Width = value; } }

        public T Height { get { return value.Height; } set { this.value.Height = value; } }

        T IVector2<T>.X { get { return value.Width; } set { this.value.Width = value; } }

        T IVector2<T>.Y { get { return value.Height; } set { this.value.Height = value; } }
        #endregion

        #region Operators
        public static implicit operator ValueSize2<T>(Size2<T> value) => value;

        public static explicit operator Size2<T>(ValueSize2<T> value) => new(value);
        #endregion
    }
}