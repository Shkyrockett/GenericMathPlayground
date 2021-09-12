using GenericMathPlayground.Mathematics;

namespace GenericMathPlayground.Geometry
{
    public interface ISize3<T>
        : ISize2<T>, IVector3<T>
        where T : INumber<T>
    {
        public T Depth { get; set; }

        T IVector3<T>.Z { get { return Depth; } set { Depth = value; } }
    }
}