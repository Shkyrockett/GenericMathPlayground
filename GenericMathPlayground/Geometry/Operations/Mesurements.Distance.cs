// <copyright file="Measurements.Distance.cs" company="Shkyrockett" >
//     Copyright © 2005 - 2022 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using GenericMathPlayground.Mathematics;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace GenericMathPlayground.Geometry;

/// <summary>
/// The measurements static class.
/// </summary>
public static partial class Measurements
{
    /// <summary>
    /// Calculates the distance between two points in 2-dimensional euclidean space.
    /// </summary>
    /// <param name="x1">First X component.</param>
    /// <param name="y1">First Y component.</param>
    /// <param name="x2">Second X component.</param>
    /// <param name="y2">Second Y component.</param>
    /// <returns>
    /// Returns the distance between two points.
    /// </returns>
    [DebuggerStepThrough]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static R Distance<T, R>(T x1, T y1, T x2, T y2) where T : INumber<T> where R : IFloatingPointIeee754<R> => R.Sqrt(R.CreateChecked(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1))));

    /// <summary>
    /// Calculates the distance between two points in 3-dimensional euclidean space.
    /// </summary>
    /// <param name="x1">First X component.</param>
    /// <param name="y1">First Y component.</param>
    /// <param name="z1">First Z component.</param>
    /// <param name="x2">Second X component.</param>
    /// <param name="y2">Second Y component.</param>
    /// <param name="z2">Second Z component.</param>
    /// <returns>
    /// Returns the distance between two points.
    /// </returns>
    [DebuggerStepThrough]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static R Distance<T, R>(T x1, T y1, T z1, T x2, T y2, T z2) where T : INumber<T> where R : IFloatingPointIeee754<R> => R.Sqrt(R.CreateChecked(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)) + ((z2 - z1) * (z2 - z1))));

    /// <summary>
    /// Calculates the distance between two points in 4-dimensional space.
    /// </summary>
    /// <param name="x1">First X component.</param>
    /// <param name="y1">First Y component.</param>
    /// <param name="z1">First Z component.</param>
    /// <param name="w1">First W component.</param>
    /// <param name="x2">Second X component.</param>
    /// <param name="y2">Second Y component.</param>
    /// <param name="z2">Second Z component.</param>
    /// <param name="w2">Second W component.</param>
    /// <returns>
    /// Returns the distance between two points.
    /// </returns>
    [DebuggerStepThrough]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static R Distance<T, R>(T x1, T y1, T z1, T w1, T x2, T y2, T z2, T w2) where T : INumber<T> where R : IFloatingPointIeee754<R> => R.Sqrt(R.CreateChecked(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)) + ((z2 - z1) * (z2 - z1)) + ((w2 - w1) * (w2 - w1))));

    /// <summary>
    /// Calculates the distance between a point and a line segment, constrained to the area perpendicular to the line segment.
    /// </summary>
    /// <param name="aX">The x-component of the first point of the line segment.</param>
    /// <param name="aY">The y-component of the first point of the line segment.</param>
    /// <param name="bX">The x-component of the second point of the line segment.</param>
    /// <param name="bY">The y-component of the second point of the line segment.</param>
    /// <param name="pX">The x-component of the point.</param>
    /// <param name="pY">The y-component of the point.</param>
    /// <returns>
    /// Returns the distance to the line segment or null if the point is not in the area of perpendicularity.
    /// </returns>
    [DebuggerStepThrough]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static R? ConstrainedDistanceLineSegmentPoint<T, R>(
        T aX, T aY, T bX, T bY,
        T pX, T pY)
        where T : INumber<T>
        where R : struct, IFloatingPointIeee754<R>
    {
        // Vector of line segment a->b
        (var ui, var uj) = (R.CreateChecked(bX - aX), R.CreateChecked(bY - aY));

        // Vector a->p
        (var vi, var vj) = (R.CreateChecked(aX - pX), R.CreateChecked(aY - pY));

        // Get the determinant or squared length of the line segment.
        var d = R.CreateChecked((ui * ui) + (uj * uj));

        // Get the length of the line segment.
        var length = R.Sqrt(d);

        // Check whether the line is a line or a point.
        if (length == R.Zero)
        {
            return null;
        }

        // Find the interpolation value.
        var t = -((vi * ui) + (vj * uj)) / d;

        // Check whether the closest point falls on the line segment.
        if (t < R.Zero || t > R.One)
        {
            return null;
        }

        // Return the length to the nearest point on the line segment.
        return (length == R.Zero)
            ? R.Sqrt((vi * vi) + (vj * vj))
            : (R.Abs((ui * vj) - (vi * uj)) / length);
    }

    /// <summary>
    /// Calculates the distance between a point and a line.
    /// </summary>
    /// <param name="aX">The x-component of the location point of the line.</param>
    /// <param name="aY">The y-component of the location point of the line.</param>
    /// <param name="ai">The i-component of the vector of the line.</param>
    /// <param name="aj">The j-component of the vector of the line.</param>
    /// <param name="pX">The x-component of the test point.</param>
    /// <param name="pY">The y-component of the test point.</param>
    /// <returns>
    /// Returns the shortest distance to the line from the point.
    /// </returns>
    /// <acknowledgment>
    /// From answer at: http://stackoverflow.com/a/2255848
    /// formula here: http://mathworld.wolfram.com/Point-LineDistance2-Dimensional.html
    /// </acknowledgment>
    [DebuggerStepThrough]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static R DistanceLinePoint<T, R>(
        T aX, T aY, T ai, T aj,
        T pX, T pY)
        where T : INumber<T>
        where R : IFloatingPointIeee754<R>
    {
        // Vector a->p
        (var vi, var vj) = (R.CreateChecked(aX - pX), R.CreateChecked(aY - pY));

        // Get the length of the line segment.
        var length = R.Sqrt(R.CreateChecked((ai * ai) + (aj * aj)));

        // Return the length to the nearest point on the line.
        return (length == R.Zero)
            ? R.Sqrt((vi * vi) + (vj * vj))
            : (R.Abs((R.CreateChecked(ai) * vj) - (vi * R.CreateChecked(aj))) / length);
    }

    /// <summary>
    /// Calculates the distance between a point and a line segment.
    /// </summary>
    /// <param name="aX">The x-component of the first point of the line segment.</param>
    /// <param name="aY">The y-component of the first point of the line segment.</param>
    /// <param name="bX">The x-component of the second point of the line segment.</param>
    /// <param name="bY">The y-component of the second point of the line segment.</param>
    /// <param name="pX">The x-component of the point.</param>
    /// <param name="pY">The y-component of the point.</param>
    /// <returns>
    /// Returns the distance between the line segment and the point.
    /// </returns>
    [DebuggerStepThrough]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static R DistanceLineSegmentPoint<T, R>(
        T aX, T aY, T bX, T bY,
        T pX, T pY)
        where T : INumber<T>
        where R : IFloatingPointIeee754<R>
    {
        // Vector of line segment a->b
        (var ui, var uj) = (R.CreateChecked(bX - aX), R.CreateChecked(bY - aY));

        // Vector a->p
        (var vi, var vj) = (R.CreateChecked(aX - pX), R.CreateChecked(aY - pY));

        // Vector b->p
        (var wi, var wj) = (R.CreateChecked(bX - pX), R.CreateChecked(bY - pY));

        // Get the determinant or squared length of the line segment.
        var d = R.CreateChecked((ui * ui) + (uj * uj));

        // Get the length of the line segment.
        var length = R.Sqrt(d);

        // Find the interpolation value.
        var t = -((vi * ui) + (vj * uj)) / d;

        // Return the distance to the nearest point on the line segment.
        return (t < R.Zero) /* Check whether the closest point falls between the ends of line segment. */
            ? R.Sqrt((vi * vi) + (vj * vj))
            : (t > R.One)
            ? R.Sqrt((wi * wi) + (wj * wj))
            : (length == R.Zero)
            ? R.Sqrt((vi * vi) + (vj * vj))
            : (R.Abs((ui * vj) - (vi * uj)) / length);
    }

    /// <summary>
    /// Finds the shortest distance between a point and a line.
    /// </summary>
    /// <param name="segment">The line segment.</param>
    /// <param name="point">The point to test.</param>
    /// <returns>
    /// The perpendicular distance to the line.
    /// </returns>
    /// <acknowledgment>
    /// Based on: https://github.com/burningmime/curves
    /// See: http://en.wikipedia.org/wiki/Distance_from_a_point_to_a_line
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static R PerpendicularDistance<T, R>(((T X, T Y) A, (T X, T Y) B) segment, Point2<T> point)
        where T : INumber<T>
        where R : IFloatingPointIeee754<R>
    {
        var area = R.Abs(R.CreateChecked(Operations.CrossProduct(segment.A.X, segment.A.Y, segment.B.X, segment.B.Y) + (segment.B.X * point.Y) + (point.X * segment.A.Y) - (point.X * segment.B.Y) - (segment.A.X * point.Y)));
        var height = area / Distance<T, R>(segment.A.X, segment.A.Y, segment.B.X, segment.B.Y);
        return height;
    }
}
