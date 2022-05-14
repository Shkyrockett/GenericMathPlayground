// <copyright file="Intersections.Between.cs" >
//     Copyright © 2005 - 2022 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>

// <copyright company="kevlindev" >
//     Many of the Intersections methods were adapted from Kevin Lindsey's site http://www.kevlindev.com/gui/math/intersection/.
//     Copyright © 2000 - 2003 Kevin Lindsey. All rights reserved.
// </copyright>
// <author id="thelonious">Kevin Lindsey</author>
// <license>
//     Licensed under the BSD-3-Clause https://github.com/thelonious/kld-intersections/blob/development/LICENSE
// </license>

// <copyright company="angusj" >
//     The Point in Polygon method is from the Clipper Library.
//     Copyright © 2010 - 2014 Angus Johnson. All rights reserved.
// </copyright>
// <author id="angusj">Angus Johnson</author>
// <license id="Boost">
//     Licensed under the Boost Software License (http://www.boost.org/LICENSE_1_0.txt).
// </license>

// <copyright company="vb-helper" >
//     Some of the methods came from Rod Stephens excellent blogs vb-helper(http://vb-helper.com), and csharphelper (http://csharphelper.com), as well as from his books.
//     Copyright © Rod Stephens.
// </copyright>
// <author id="RodStephens">Rod Stephens</author>
// <license id="No Restrictions">
//     You can use the code you find on this site or in my books. I request but don’t require an acknowledgment.
//     I also recommend (but again don’t require) that you put the URL where you found the code in a comment inside your code in case you need to look it up later.
//     So really no restrictions. (http://csharphelper.com/blog/rod/)
// </license>

// <summary></summary>
// <remarks></remarks>

using GenericMathPlayground.Mathematics;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace GenericMathPlayground.Geometry
{
    /// <summary>
    /// The intersections.
    /// </summary>
    public class Intersections
    {
        #region Between Extension Method Overloads
        /// <summary>
        /// Check whether a vector lies between two other vectors.
        /// </summary>
        /// <param name="a">The vector <paramref name="a"/> to compare.</param>
        /// <param name="b">The start <paramref name="b"/> vector.</param>
        /// <param name="c">The end vector <paramref name="c"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public static bool Between<T>(Vector2<T> a, Vector2<T> b, Vector2<T> c) where T : IFloatingPointIeee754<T> => VectorBetweenVectorVector(a.I, a.J, b.I, b.J, c.I, c.J);

        /// <summary>
        /// Check whether a value lies between two other values.
        /// </summary>
        /// <param name="v">The value <paramref name="v"/> to check whether it is between the other two.</param>
        /// <param name="m">The first value <paramref name="m"/> to compare to.</param>
        /// <param name="M">The second value <paramref name="M"/> to compare to.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <acknowledgment>
        /// http://pomax.github.io/bezierinfo
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public static bool ApproximatelyBetween<T>(T v, T m, T M) where T : IFloatingPointIeee754<T> => (m <= v && v <= M) || Operations.Approximately(v, m) || Operations.Approximately(v, M);

        /// <summary>
        /// Return true iff angle c is between angles
        /// a and b, inclusive. b always follows a in
        /// the positive rotational direction. Operations
        /// against an entire circle cannot be defined.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <acknowledgment>
        /// https://www.khanacademy.org/computer-programming/c/5567955982876672
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public static bool AngleBetween<T>(T c, T a, T b)
            where T : IFloatingPointIeee754<T>
        {
            /* Make sure that a is in the range [0 .. tau). */
            for (a %= T.Tau; a < T.Zero; a += T.Tau) { }
            /* Make sure that both b and c are not less than a. */
            for (b %= T.Tau; b < a; b += T.Tau) { }
            for (c %= T.Tau; c < a; c += T.Tau) { }
            return c <= b;
        }

        /// <summary>
        /// Check whether an angle lies within the sweep angle.
        /// </summary>
        /// <param name="angle">Angle of rotation to check.</param>
        /// <param name="startAngle">The starting angle.</param>
        /// <param name="sweepAngle">The amount of angle to offset from the start angle.</param>
        /// <returns>A <see cref="bool"/> value indicating whether an angle is between two others.</returns>
        /// <acknowledgment>
        /// http://www.xarg.org/2010/06/is-an-angle-between-two-other-angles/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public static bool AngleWithin<T>(T angle, T startAngle, T sweepAngle)
            where T : IFloatingPointIeee754<T>
        {
            // If the sweep angle is greater than 360 degrees it is overlapping, so any angle would intersect the sweep angle.
            if (sweepAngle > T.Tau)
            {
                return true;
            }

            // Wrap the angles to values between 2PI and -2PI.
            var s = startAngle.WrapAngle();
            var e = (s + sweepAngle).WrapAngle();
            var a = angle.WrapAngle();

            // return whether the angle is contained within the sweep angle.
            // The calculations are opposite when the sweep angle is negative.
            return (sweepAngle >= T.Zero) ?
                (s < e) ? a >= s && a <= e : a >= s || a <= e :
                (s > e) ? a <= s && a >= e : a <= s || a >= e;
        }
        #endregion Between Extension Method Overloads

        #region Between Methods
        /// <summary>
        /// Check whether a vector lies between two other vectors.
        /// </summary>
        /// <param name="i0">The horizontal component of the vector to compare.</param>
        /// <param name="j0">The vertical component of the vector to compare.</param>
        /// <param name="i1">The start vector horizontal component.</param>
        /// <param name="j1">The start vector vertical component.</param>
        /// <param name="i2">The end vector horizontal component.</param>
        /// <param name="j2">The end vector vertical component.</param>
        /// <returns>A boolean value representing whether the reference vector is contained within the start and end vectors.</returns>
        /// <acknowledgment>
        /// http://math.stackexchange.com/questions/1698835/find-if-a-vector-is-between-2-vectors
        /// http://stackoverflow.com/questions/13640931/how-to-determine-if-a-vector-is-between-two-other-vectors
        /// http://gamedev.stackexchange.com/questions/22392/what-is-a-good-way-to-determine-if-a-vector-is-between-two-other-vectors-in-2d
        /// http://math.stackexchange.com/questions/169998/figure-out-if-a-fourth-point-resides-within-an-angle-created-by-three-other-poin
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public static bool VectorBetweenVectorVector<T>(T i0, T j0, T i1, T j1, T i2, T j2)
            where T : IFloatingPointIeee754<T> => VectorBetweenVectorVector(i0, j0, i1, j1, i2, j2, T.Epsilon);

        /// <summary>
        /// Check whether a vector lies between two other vectors.
        /// </summary>
        /// <param name="i0">The horizontal component of the vector to compare.</param>
        /// <param name="j0">The vertical component of the vector to compare.</param>
        /// <param name="i1">The start vector horizontal component.</param>
        /// <param name="j1">The start vector vertical component.</param>
        /// <param name="i2">The end vector horizontal component.</param>
        /// <param name="j2">The end vector vertical component.</param>
        /// <param name="epsilon"></param>
        /// <returns>A boolean value representing whether the reference vector is contained within the start and end vectors.</returns>
        /// <acknowledgment>
        /// http://math.stackexchange.com/questions/1698835/find-if-a-vector-is-between-2-vectors
        /// http://stackoverflow.com/questions/13640931/how-to-determine-if-a-vector-is-between-two-other-vectors
        /// http://gamedev.stackexchange.com/questions/22392/what-is-a-good-way-to-determine-if-a-vector-is-between-two-other-vectors-in-2d
        /// http://math.stackexchange.com/questions/169998/figure-out-if-a-fourth-point-resides-within-an-angle-created-by-three-other-poin
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public static bool VectorBetweenVectorVector<T>(T i0, T j0, T i1, T j1, T i2, T j2, T epsilon)
            where T : INumber<T>
            => ((i1 * j0) - (j1 * i0)) * ((i1 * j2) - (j1 * i2)) >= epsilon
            && ((i2 * j0) - (j2 * i0)) * ((i2 * j1) - (j2 * i1)) >= epsilon;
        #endregion Between Methods
    }
}
