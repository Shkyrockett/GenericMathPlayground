namespace GenericMathPlayground.Mathematics
{
    public interface IVector3<T>
        : IVector2<T>
        where T : INumber<T>
    {
        public T Z { get; set; }

        public void Deconstruct(out T X, out T Y, out T Z) => (X, Y, Z) = (this.X, this.Y, this.Z);
    }
}
