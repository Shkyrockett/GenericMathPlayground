using GenericMathPlayground.Mathematics;

namespace GenericMathPlayground.Geometry
{
    public interface ISize2<T>
        : ISize<T>, IVector2<T>
        where T : INumber<T>
    {
        public T Width { get; set; }

        public T Height { get; set; }

        T IVector2<T>.X { get { return Width; } set { Width = value; } }

        T IVector2<T>.Y { get { return Height; } set { Height = value; } }
    }
}