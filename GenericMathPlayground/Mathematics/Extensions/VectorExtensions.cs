using GenericMathPlayground.Geometry;
using System.Numerics;

namespace GenericMathPlayground.Mathematics
{
    /// <summary>
    /// The vector extensions.
    /// </summary>
    public static partial class VectorExtensions
    {
        /// <summary>
        /// Rounds the vector.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <param name="mode">The mode.</param>
        /// <returns>A ValueVector.</returns>
        public static ValueVector<TResult> Round<T, TResult>(this ValueVector<T> vector, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
            where T : IFloatingPointIeee754<T>
            where TResult : INumber<TResult> => new(Operations.Round<T, TResult>(vector.Items, accuracy, mode));

        /// <summary>
        /// Rounds the vector.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <param name="mode">The mode.</param>
        /// <returns>A ValueVector2.</returns>
        public static ValueVector2<TResult> Round<T, TResult>(this ValueVector2<T> vector, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
            where T : IFloatingPointIeee754<T>
            where TResult : INumber<TResult> => new(Operations.Round<T, TResult>((vector.I, vector.J), accuracy, mode));

        /// <summary>
        /// Rounds the vector.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <param name="mode">The mode.</param>
        /// <returns>A ValueVector3.</returns>
        public static ValueVector3<TResult> Round<T, TResult>(this ValueVector3<T> vector, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
            where T : IFloatingPointIeee754<T>
            where TResult : INumber<TResult> => new(Operations.Round<T, TResult>((vector.I, vector.J, vector.K), accuracy, mode));

        /// <summary>
        /// Rounds the vector.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <param name="mode">The mode.</param>
        /// <returns>A ValueVector4.</returns>
        public static ValueVector4<TResult> Round<T, TResult>(this ValueVector4<T> vector, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
            where T : IFloatingPointIeee754<T>
            where TResult : INumber<TResult> => new(Operations.Round<T, TResult>((vector.I, vector.J, vector.K, vector.L), accuracy, mode));

        /// <summary>
        /// Rounds the vector.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <param name="mode">The mode.</param>
        /// <returns>A ValueVector5.</returns>
        public static ValueVector5<TResult> Round<T, TResult>(this ValueVector5<T> vector, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
            where T : IFloatingPointIeee754<T>
            where TResult : INumber<TResult> => new(Operations.Round<T, TResult>((vector.I, vector.J, vector.K, vector.L, vector.M), accuracy, mode));

        /// <summary>
        /// Rounds the vector.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <param name="mode">The mode.</param>
        /// <returns>A ValuePoint2.</returns>
        public static ValuePoint2<TResult> Round<T, TResult>(this ValuePoint2<T> vector, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
            where T : IFloatingPointIeee754<T>
            where TResult : INumber<TResult> => new(Operations.Round<T, TResult>((vector.X, vector.Y), accuracy, mode));

        /// <summary>
        /// Rounds the vector.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <param name="mode">The mode.</param>
        /// <returns>A ValuePoint3.</returns>
        public static ValuePoint3<TResult> Round<T, TResult>(this ValuePoint3<T> vector, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
            where T : IFloatingPointIeee754<T>
            where TResult : INumber<TResult> => new(Operations.Round<T, TResult>((vector.X, vector.Y, vector.Z), accuracy, mode));

        /// <summary>
        /// Rounds the vector.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <param name="mode">The mode.</param>
        /// <returns>A ValuePoint4.</returns>
        public static ValuePoint4<TResult> Round<T, TResult>(this ValuePoint4<T> vector, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
            where T : IFloatingPointIeee754<T>
            where TResult : INumber<TResult> => new(Operations.Round<T, TResult>((vector.X, vector.Y, vector.Z, vector.W), accuracy, mode));

        /// <summary>
        /// Rounds the vector.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <param name="mode">The mode.</param>
        /// <returns>A ValuePoint5.</returns>
        public static ValuePoint5<TResult> Round<T, TResult>(this ValuePoint5<T> vector, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
            where T : IFloatingPointIeee754<T>
            where TResult : INumber<TResult> => new(Operations.Round<T, TResult>((vector.X, vector.Y, vector.Z, vector.W, vector.V), accuracy, mode));

        /// <summary>
        /// Rounds the vector.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <param name="mode">The mode.</param>
        /// <returns>A ValueSize2.</returns>
        public static ValueSize2<TResult> Round<T, TResult>(this ValueSize2<T> vector, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
            where T : IFloatingPointIeee754<T>
            where TResult : INumber<TResult> => new(Operations.Round<T, TResult>((vector.Width, vector.Height), accuracy, mode));

        /// <summary>
        /// Rounds the vector.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <param name="mode">The mode.</param>
        /// <returns>A ValueSize3.</returns>
        public static ValueSize3<TResult> Round<T, TResult>(this ValueSize3<T> vector, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
            where T : IFloatingPointIeee754<T>
            where TResult : INumber<TResult> => new(Operations.Round<T, TResult>((vector.Width, vector.Height, vector.Depth), accuracy, mode));

        /// <summary>
        /// Rounds the vector.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <param name="mode">The mode.</param>
        /// <returns>A ValueSize4.</returns>
        public static ValueSize4<TResult> Round<T, TResult>(this ValueSize4<T> vector, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
            where T : IFloatingPointIeee754<T>
            where TResult : INumber<TResult> => new(Operations.Round<T, TResult>((vector.Width, vector.Height, vector.Depth, vector.Breadth), accuracy, mode));

        /// <summary>
        /// Rounds the vector.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <param name="mode">The mode.</param>
        /// <returns>A ValueSize5.</returns>
        public static ValueSize5<TResult> Round<T, TResult>(this ValueSize5<T> vector, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
            where T : IFloatingPointIeee754<T>
            where TResult : INumber<TResult> => new(Operations.Round<T, TResult>((vector.Width, vector.Height, vector.Depth, vector.Breadth, vector.Girth), accuracy, mode));
    }
}
