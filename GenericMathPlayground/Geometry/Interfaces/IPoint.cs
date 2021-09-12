using GenericMathPlayground.Mathematics;

namespace GenericMathPlayground.Geometry
{
    public interface IPoint<T>
        : IVector<T>
        where T : INumber<T>
    {
    }
}