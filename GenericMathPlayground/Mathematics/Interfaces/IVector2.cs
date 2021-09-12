namespace GenericMathPlayground.Mathematics
{
    public interface IVector2<T>
        : IVector<T>
        where T : INumber<T>
    {
        public T X { get; set; }

        public T Y { get; set; }

        public void Deconstruct(out T X, out T Y) => (X, Y) = (this.X, this.Y);
    }
}
