using GenericMathPlayground.Mathematics;

namespace GenericMathPlayground.Geometry
{
    public interface IPoint2<T>
        : IPoint<T>, IVector2<T>
        where T : INumber<T>
    {
    }
}