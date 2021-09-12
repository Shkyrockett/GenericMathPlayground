namespace GenericMathPlayground.Physics
{
    public interface ILengthUnit
        : INumber<double>
    {
        double Value { get; set; }
    }
}
