using System.Numerics;
using static GenericMathPlayground.Mathematics.Operations;

namespace GenericMathPlayground.Mathematics
{
    /// <typeparam name="T"></typeparam>
    /// <summary>
    /// The bezier methods.
    /// </summary>
    internal class BezierMethods<T>
            where T : INumber<T>
    {
        public static List<T[]> lut = new()
        {
            new[] { T.One }, // n=0
            new[] { T.One, T.One }, // n=1
            new[] { T.One, T.CreateChecked(2), T.One }, // n=2
            new[] { T.One, T.CreateChecked(3), T.CreateChecked(3), T.One }, // n=3
            new[] { T.One, T.CreateChecked(4), T.CreateChecked(6), T.CreateChecked(4), T.One }, // n=4
            new[] { T.One, T.CreateChecked(5), T.CreateChecked(10), T.CreateChecked(10), T.CreateChecked(5), T.One }, // n=5
            new[] { T.One, T.CreateChecked(6), T.CreateChecked(15), T.CreateChecked(20), T.CreateChecked(15), T.CreateChecked(6), T.One } // n=6
        };

        /// <summary>
        /// Binomials the. https://pomax.github.io/bezierinfo/#explanation
        /// </summary>
        /// <param name="n">The n.</param>
        /// <param name="k">The k.</param>
        /// <returns>A T.</returns>
        public static T Binomial(int n, int k)
        {
            // Append to Pascals Triangle lookup table if n is greater than the height of the triangle.
            while (n >= lut.Count)
            {
                var s = lut.Count;
                var nextRow = new T[s + 1];
                nextRow[0] = nextRow[s] = T.One;
                for (int i = 1, prev = s - 1; i < s; i++)
                {
                    nextRow[i] = lut[prev][i - 1] + lut[prev][i];
                }

                lut.Add(nextRow);
            }

            // Return the value at the desired lookup table index.
            return lut[n][k];
        }

        /// <summary>
        /// Beziers the. https://pomax.github.io/bezierinfo/#control
        /// </summary>
        /// <param name="n">The n.</param>
        /// <param name="t">The t.</param>
        /// <param name="w">The w.</param>
        /// <returns>A T.</returns>
        public static T Bezier(int n, T t, T[] w)
        {
            T sum = T.Zero;
            for (var k = 0; k <= n; k++)
            {
                sum += w[k] * Binomial(n, k) * Power(T.One - t, n - k) * Power(t, k);
            }

            return sum;
        }

        //public static T Bezier(2, T t)
        //{
        //    var t2 = t * t;
        //    var mt = T.One - t;
        //    var mt2 = mt * mt;
        //    return mt2 + 2 * mt * t + t2;
        //}

        //public static T Bezier(3, T t)
        //{
        //    var t2 = t * t;
        //    var t3 = t2 * t;
        //    var mt = T.One - t;
        //    var mt2 = mt * mt;
        //    var mt3 = mt2 * mt;
        //    return mt3 + 3 * mt2 * t + 3 * mt * t2 + t3;
        //}
    }
}
