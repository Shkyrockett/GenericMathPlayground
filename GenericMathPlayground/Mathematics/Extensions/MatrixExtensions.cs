using System;

namespace GenericMathPlayground.Mathematics
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class MatrixExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="matrix"></param>
        /// <param name="accuracy"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static ValueMatrix<TResult> Round<T, TResult>(this ValueMatrix<T> matrix, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
            where T : IFloatingPoint<T>
            where TResult : INumber<TResult> => new(Operations.Round<T, TResult>(matrix.Items, accuracy, mode));

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="matrix"></param>
        /// <param name="accuracy"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static ValueMatrix2x2<TResult> Round<T, TResult>(this ValueMatrix2x2<T> matrix, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
            where T : IFloatingPoint<T>
            where TResult : INumber<TResult> => new(Operations.Round<T, TResult>((matrix.M1x1, matrix.M1x2, matrix.M2x1, matrix.M2x2), accuracy, mode));

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="matrix"></param>
        /// <param name="accuracy"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static ValueMatrix3x3<TResult> Round<T, TResult>(this ValueMatrix3x3<T> matrix, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
            where T : IFloatingPoint<T>
            where TResult : INumber<TResult> => new(Operations.Round<T, TResult>((matrix.M1x1, matrix.M1x2, matrix.M1x3, matrix.M2x1, matrix.M2x2, matrix.M2x3, matrix.M3x1, matrix.M3x2, matrix.M3x3), accuracy, mode));

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="matrix"></param>
        /// <param name="accuracy"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static ValueMatrix4x4<TResult> Round<T, TResult>(this ValueMatrix4x4<T> matrix, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
            where T : IFloatingPoint<T>
            where TResult : INumber<TResult> => new(Operations.Round<T, TResult>(
                (
                matrix.M1x1, matrix.M1x2, matrix.M1x3, matrix.M1x4,
                matrix.M2x1, matrix.M2x2, matrix.M2x3, matrix.M2x4,
                matrix.M3x1, matrix.M3x2, matrix.M3x3, matrix.M3x4,
                matrix.M4x1, matrix.M4x2, matrix.M4x3, matrix.M4x4), accuracy, mode));

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="matrix"></param>
        /// <param name="accuracy"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static ValueMatrix5x5<TResult> Round<T, TResult>(this ValueMatrix5x5<T> matrix, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
            where T : IFloatingPoint<T>
            where TResult : INumber<TResult> => new(Operations.Round<T, TResult>(
                (
                matrix.M1x1, matrix.M1x2, matrix.M1x3, matrix.M1x4, matrix.M1x5,
                matrix.M2x1, matrix.M2x2, matrix.M2x3, matrix.M2x4, matrix.M2x5,
                matrix.M3x1, matrix.M3x2, matrix.M3x3, matrix.M3x4, matrix.M3x5,
                matrix.M4x1, matrix.M4x2, matrix.M4x3, matrix.M4x4, matrix.M4x5,
                matrix.M5x1, matrix.M5x2, matrix.M5x3, matrix.M5x4, matrix.M5x5), accuracy, mode));
    }
}
