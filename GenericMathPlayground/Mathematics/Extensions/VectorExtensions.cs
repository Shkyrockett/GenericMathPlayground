using GenericMathPlayground.Geometry;
using System;

namespace GenericMathPlayground.Mathematics
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class VectorExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="vector"></param>
        /// <param name="accuracy"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static ValueVector<TResult> Round<T, TResult>(this ValueVector<T> vector, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
            where T : IFloatingPoint<T>
            where TResult : INumber<TResult> => new(Operations.Round<T, TResult>(vector.Items, accuracy, mode));

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="vector"></param>
        /// <param name="accuracy"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static ValueVector2<TResult> Round<T, TResult>(this ValueVector2<T> vector, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
            where T : IFloatingPoint<T>
            where TResult : INumber<TResult> => new(Operations.Round<T, TResult>((vector.I, vector.J), accuracy, mode));

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="vector"></param>
        /// <param name="accuracy"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static ValueVector3<TResult> Round<T, TResult>(this ValueVector3<T> vector, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
            where T : IFloatingPoint<T>
            where TResult : INumber<TResult> => new(Operations.Round<T, TResult>((vector.I, vector.J, vector.K), accuracy, mode));

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="vector"></param>
        /// <param name="accuracy"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static ValueVector4<TResult> Round<T, TResult>(this ValueVector4<T> vector, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
            where T : IFloatingPoint<T>
            where TResult : INumber<TResult> => new(Operations.Round<T, TResult>((vector.I, vector.J, vector.K, vector.L), accuracy, mode));

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="vector"></param>
        /// <param name="accuracy"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static ValueVector5<TResult> Round<T, TResult>(this ValueVector5<T> vector, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
            where T : IFloatingPoint<T>
            where TResult : INumber<TResult> => new(Operations.Round<T, TResult>((vector.I, vector.J, vector.K, vector.L, vector.M), accuracy, mode));

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="vector"></param>
        /// <param name="accuracy"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static ValuePoint2<TResult> Round<T, TResult>(this ValuePoint2<T> vector, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
            where T : IFloatingPoint<T>
            where TResult : INumber<TResult> => new(Operations.Round<T, TResult>((vector.X, vector.Y), accuracy, mode));

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="vector"></param>
        /// <param name="accuracy"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static ValuePoint3<TResult> Round<T, TResult>(this ValuePoint3<T> vector, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
            where T : IFloatingPoint<T>
            where TResult : INumber<TResult> => new(Operations.Round<T, TResult>((vector.X, vector.Y, vector.Z), accuracy, mode));

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="vector"></param>
        /// <param name="accuracy"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static ValuePoint4<TResult> Round<T, TResult>(this ValuePoint4<T> vector, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
            where T : IFloatingPoint<T>
            where TResult : INumber<TResult> => new(Operations.Round<T, TResult>((vector.X, vector.Y, vector.Z, vector.W), accuracy, mode));

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="vector"></param>
        /// <param name="accuracy"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static ValuePoint5<TResult> Round<T, TResult>(this ValuePoint5<T> vector, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
            where T : IFloatingPoint<T>
            where TResult : INumber<TResult> => new(Operations.Round<T, TResult>((vector.X, vector.Y, vector.Z, vector.W, vector.V), accuracy, mode));

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="vector"></param>
        /// <param name="accuracy"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static ValueSize2<TResult> Round<T, TResult>(this ValueSize2<T> vector, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
            where T : IFloatingPoint<T>
            where TResult : INumber<TResult> => new(Operations.Round<T, TResult>((vector.Width, vector.Height), accuracy, mode));

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="vector"></param>
        /// <param name="accuracy"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static ValueSize3<TResult> Round<T, TResult>(this ValueSize3<T> vector, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
            where T : IFloatingPoint<T>
            where TResult : INumber<TResult> => new(Operations.Round<T, TResult>((vector.Width, vector.Height, vector.Depth), accuracy, mode));

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="vector"></param>
        /// <param name="accuracy"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static ValueSize4<TResult> Round<T, TResult>(this ValueSize4<T> vector, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
            where T : IFloatingPoint<T>
            where TResult : INumber<TResult> => new(Operations.Round<T, TResult>((vector.Width, vector.Height, vector.Depth, vector.Breadth), accuracy, mode));

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="vector"></param>
        /// <param name="accuracy"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static ValueSize5<TResult> Round<T, TResult>(this ValueSize5<T> vector, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
            where T : IFloatingPoint<T>
            where TResult : INumber<TResult> => new(Operations.Round<T, TResult>((vector.Width, vector.Height, vector.Depth, vector.Breadth, vector.Length), accuracy, mode));
    }
}
