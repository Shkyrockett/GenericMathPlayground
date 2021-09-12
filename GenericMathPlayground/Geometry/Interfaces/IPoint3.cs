using GenericMathPlayground.Mathematics;

namespace GenericMathPlayground.Geometry
{
    public interface IPoint3<T>
        : IPoint<T>, IVector3<T>
        where T : INumber<T>
    {
    }
}