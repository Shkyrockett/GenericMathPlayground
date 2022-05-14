using System.Numerics;

namespace GenericMathPlayground.Mathematics
{
    /// <summary>
    /// The matrix extensions.
    /// </summary>
    public static partial class MatrixExtensions
    {
        /// <summary>
        /// Rounds the matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <param name="mode">The mode.</param>
        /// <returns>A ValueMatrix.</returns>
        public static ValueMatrix<TResult> Round<T, TResult>(this ValueMatrix<T> matrix, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
            where T : IFloatingPointIeee754<T>
            where TResult : INumber<TResult> => new(Operations.Round<T, TResult>(matrix.Items, accuracy, mode));

        /// <summary>
        /// Rounds the matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <param name="mode">The mode.</param>
        /// <returns>A ValueMatrix2x2.</returns>
        public static ValueMatrix2x2<TResult> Round<T, TResult>(this ValueMatrix2x2<T> matrix, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
            where T : IFloatingPointIeee754<T>
            where TResult : INumber<TResult> => new(Operations.Round<T, TResult>((matrix.M1x1, matrix.M1x2, matrix.M2x1, matrix.M2x2), accuracy, mode));

        /// <summary>
        /// Rounds the matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <param name="mode">The mode.</param>
        /// <returns>A ValueMatrix3x3.</returns>
        public static ValueMatrix3x3<TResult> Round<T, TResult>(this ValueMatrix3x3<T> matrix, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
            where T : IFloatingPointIeee754<T>
            where TResult : INumber<TResult> => new(Operations.Round<T, TResult>((matrix.M1x1, matrix.M1x2, matrix.M1x3, matrix.M2x1, matrix.M2x2, matrix.M2x3, matrix.M3x1, matrix.M3x2, matrix.M3x3), accuracy, mode));

        /// <summary>
        /// Rounds the matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <param name="mode">The mode.</param>
        /// <returns>A ValueMatrix4x4.</returns>
        public static ValueMatrix4x4<TResult> Round<T, TResult>(this ValueMatrix4x4<T> matrix, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
            where T : IFloatingPointIeee754<T>
            where TResult : INumber<TResult> => new(Operations.Round<T, TResult>(
                (
                matrix.M1x1, matrix.M1x2, matrix.M1x3, matrix.M1x4,
                matrix.M2x1, matrix.M2x2, matrix.M2x3, matrix.M2x4,
                matrix.M3x1, matrix.M3x2, matrix.M3x3, matrix.M3x4,
                matrix.M4x1, matrix.M4x2, matrix.M4x3, matrix.M4x4), accuracy, mode));

        /// <summary>
        /// Rounds the matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <param name="mode">The mode.</param>
        /// <returns>A ValueMatrix5x5.</returns>
        public static ValueMatrix5x5<TResult> Round<T, TResult>(this ValueMatrix5x5<T> matrix, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
            where T : IFloatingPointIeee754<T>
            where TResult : INumber<TResult> => new(Operations.Round<T, TResult>(
                (
                matrix.M1x1, matrix.M1x2, matrix.M1x3, matrix.M1x4, matrix.M1x5,
                matrix.M2x1, matrix.M2x2, matrix.M2x3, matrix.M2x4, matrix.M2x5,
                matrix.M3x1, matrix.M3x2, matrix.M3x3, matrix.M3x4, matrix.M3x5,
                matrix.M4x1, matrix.M4x2, matrix.M4x3, matrix.M4x4, matrix.M4x5,
                matrix.M5x1, matrix.M5x2, matrix.M5x3, matrix.M5x4, matrix.M5x5), accuracy, mode));
    }
}
