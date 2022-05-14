// <copyright file="Measurements.Ellipse.cs" company="Shkyrockett" >
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
using System.Numerics;
using System.Runtime.CompilerServices;

namespace GenericMathPlayground.Geometry;

/// <summary>
/// The measurements static class.
/// </summary>
public static partial class Measurements
{
    /// <summary>
    /// Finds the Focus Radius of an ellipse.
    /// </summary>
    /// <param name="rX">The x radius.</param>
    /// <param name="rY">The y radius.</param>
    /// <returns></returns>
    /// <remarks>
    /// <para>Returns a value representing the focus radius of an ellipse.</para>
    /// </remarks>
    /// <acknowledgment>
    /// https://en.wikipedia.org/wiki/Ellipse
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static R EllipseFocusRadius<T, R>(T rX, T rY) where T : IFloatingPointIeee754<T> where R : IFloatingPointIeee754<R> => R.Sqrt(R.CreateChecked((rX * rX) - (rY * rY)));

    /// <summary>
    /// Finds the extreme angles of a circle, that fall within the sweep angle of a circular arc.
    /// </summary>
    /// <param name="startAngle">The start angle.</param>
    /// <param name="sweepAngle">The sweep angle.</param>
    /// <returns>
    /// Returns a list of the angles of the extremes of a circular arc.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static List<T> CirclularArcExtremeAngles<T>(T startAngle, T sweepAngle)
        where T : IFloatingPointIeee754<T> => CircleExtremeAngles<T>().Where((a) => Intersections.AngleWithin(a, startAngle, sweepAngle)).ToList();

    /// <summary>
    /// Find the extreme angles of a circle.
    /// </summary>
    /// <returns>
    /// Returns the angles of the extremes of a circle.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static List<T> CircleExtremeAngles<T>() where T : IFloatingPointIeee754<T> => new() { T.Zero, MathFloatConsts<T>.Hau, T.Pi, MathFloatConsts<T>.Pau };

    /// <summary>
    /// Finds the angles of the extreme points of a rotated ellipse, that fall within the sweep angle of the arc.
    /// </summary>
    /// <param name="rX">The horizontal radius of the ellipse.</param>
    /// <param name="rY">The vertical radius of the ellipse.</param>
    /// <param name="angle">The angle of orientation of the ellipse.</param>
    /// <param name="startAngle">The start angle of the arc.</param>
    /// <param name="sweepAngle">The sweep angle of the arc.</param>
    /// <returns>
    /// Returns the angles of the extreme points of an elliptical arc.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static List<T> EllipticalArcExtremeAngles<T>(T rX, T rY, T angle, T startAngle, T sweepAngle) where T : IFloatingPointIeee754<T> => EllipseExtremeAngles(rX, rY, angle).Where((a) => Intersections.AngleWithin(a, angle + startAngle, sweepAngle)).ToList();

    /// <summary>
    /// Finds the angles of the extreme points of the rotated ellipse.
    /// </summary>
    /// <param name="rX">The horizontal radius of the ellipse.</param>
    /// <param name="rY">The vertical radius of the ellipse.</param>
    /// <param name="angle">The angle of orientation of the ellipse.</param>
    /// <returns>
    /// Returns a list of the extreme angles of a rotated ellipse.
    /// </returns>
    /// <acknowledgment>
    /// Based roughly on the principles found at:
    /// http://stackoverflow.com/questions/87734/how-do-you-calculate-the-axis-aligned-bounding-box-of-an-ellipse
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static List<T> EllipseExtremeAngles<T>(T rX, T rY, T angle)
        where T : IFloatingPointIeee754<T>
    {
        // Get the ellipse rotation transform.
        var cosT = T.Cos(angle);
        var sinT = T.Sin(angle);

        // Calculate the radii of the angle of rotation.
        var a = rX * cosT;
        var b = rY * sinT;
        var c = rX * sinT;
        var d = rY * cosT;

        // Ellipse equation for an ellipse at origin.
        var u1 = rX * T.Cos(T.Atan2(d, c));
        var v1 = -(rY * T.Sin(T.Atan2(d, c)));
        var u2 = rX * T.Cos(T.Atan2(-b, a));
        var v2 = -(rY * T.Sin(T.Atan2(-b, a)));

        // Return the list of angles.
        return new List<T>
            {
                T.Atan2((u1 * sinT) - (v1 * cosT), (u1 * cosT) + (v1 * sinT)),
                T.Atan2((u2 * sinT) - (v2 * cosT), (u2 * cosT) + (v2 * sinT)) + T.Pi,
                T.Atan2((u2 * sinT) - (v2 * cosT), (u2 * cosT) + (v2 * sinT)),
                T.Atan2((u1 * sinT) - (v1 * cosT), (u1 * cosT) + (v1 * sinT)) + T.Pi
            };
    }

    /// <summary>
    /// Finds the angles of the extreme points of a rotated ellipse, that fall within the sweep angle of the arc.
    /// </summary>
    /// <param name="rX">The horizontal radius of the ellipse.</param>
    /// <param name="rY">The vertical radius of the ellipse.</param>
    /// <param name="angle">The angle of orientation of the ellipse.</param>
    /// <param name="startAngle">The start angle of the arc.</param>
    /// <param name="sweepAngle">The sweep angle of the arc.</param>
    /// <returns>
    /// Returns the angles of the extreme points of an elliptical arc.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static List<T> EllipticalArcVerticalExtremeAngles<T>(T rX, T rY, T angle, T startAngle, T sweepAngle)
        where T : IFloatingPointIeee754<T> => EllipseVerticalExtremeAngles(rX, rY, angle).Where((a) => Intersections.AngleWithin(a, angle + startAngle, sweepAngle)).ToList();

    /// <summary>
    /// Finds the angles of the extreme points of the rotated ellipse.
    /// </summary>
    /// <param name="rX">The horizontal radius of the ellipse.</param>
    /// <param name="rY">The vertical radius of the ellipse.</param>
    /// <param name="angle">The angle of orientation of the ellipse.</param>
    /// <returns>
    /// Returns a list of the extreme angles of a rotated ellipse.
    /// </returns>
    /// <acknowledgment>
    /// Based roughly on the principles found at:
    /// http://stackoverflow.com/questions/87734/how-do-you-calculate-the-axis-aligned-bounding-box-of-an-ellipse
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static List<T> EllipseVerticalExtremeAngles<T>(T rX, T rY, T angle)
        where T : IFloatingPointIeee754<T>
    {
        // Get the ellipse rotation transform.
        var cosT = T.Cos(angle);
        var sinT = T.Sin(angle);

        // Calculate the radii of the angle of rotation.
        //var a = rX * cosT;
        //var b = rY * sinT;
        var c = rX * sinT;
        var d = rY * cosT;

        // Ellipse equation for an ellipse at origin.
        var u1 = rX * T.Cos(T.Atan2(d, c));
        var v1 = -(rY * T.Sin(T.Atan2(d, c)));
        //var u2 = rX * Cos(Atan2(-b, a));
        //var v2 = -(rY * Sin(Atan2(-b, a)));

        // Return the list of angles.
        return new List<T>
            {
                T.Atan2((u1 * sinT) - (v1 * cosT), (u1 * cosT) + (v1 * sinT)),
                //T.Atan2(u2 * sinT - v2 * cosT, u2 * cosT + v2 * sinT),
                //T.Atan2(u2 * sinT - v2 * cosT, u2 * cosT + v2 * sinT) + T.Pi,
                T.Atan2((u1 * sinT) - (v1 * cosT), (u1 * cosT) + (v1 * sinT)) + T.Pi
            };
    }

    /// <summary>
    /// Calculates the points of the Cartesian extremes of a circle.
    /// </summary>
    /// <param name="x">The x-coordinate of the center of the circle.</param>
    /// <param name="y">The y-coordinate of the center of the circle.</param>
    /// <param name="radius">The radius of the circle.</param>
    /// <returns>
    /// Returns a list of the points representing the extremes of a circle.
    /// </returns>
    /// <acknowledgment>
    /// Based roughly on the principles found at:
    /// http://stackoverflow.com/questions/87734/how-do-you-calculate-the-axis-aligned-bounding-box-of-an-ellipse
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static List<IPoint2<T>> CircleExtremePoints<T>(T x, T y, T radius)
        where T : IFloatingPointIeee754<T>
        => new()
        {
            new Point2<T>(Interpolators.Circle(T.Zero, x, y, radius)),
            new Point2<T>(Interpolators.Circle(MathFloatConsts<T>.Hau, x, y, radius)),
            new Point2<T>(Interpolators.Circle(T.Pi, x, y, radius)),
            new Point2<T>(Interpolators.Circle(MathFloatConsts<T>.Pau, x, y, radius))
        };

    /// <summary>
    /// Get the points of the Cartesian extremes of an orthogonal Ellipse.
    /// </summary>
    /// <param name="x">The x-coordinate of the center of the ellipse.</param>
    /// <param name="y">The y-coordinate of the center of the ellipse.</param>
    /// <param name="rX">The horizontal radius of the ellipse.</param>
    /// <param name="rY">The vertical radius of the ellipse.</param>
    /// <returns>
    /// Returns the points of extreme for an ellipse.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static List<IPoint2<T>> OrthogonalEllipseExtremePoints<T>(T x, T y, T rX, T rY)
        where T : IFloatingPointIeee754<T> => rX == rY
            ? CircleExtremePoints(x, y, rX)
            : new List<IPoint2<T>>
        {
            new Point2<T>(x,  y - rY),
            new Point2<T>(x - rX,  y),
            new Point2<T>(x,  y + rY),
            new Point2<T>(x + rX, y),
        };

    /// <summary>
    /// Get the points of the Cartesian extremes of a rotated ellipse.
    /// </summary>
    /// <param name="x">The x-coordinate of the center of the ellipse.</param>
    /// <param name="y">The y-coordinate of the center of the ellipse.</param>
    /// <param name="rX">The horizontal radius of the ellipse.</param>
    /// <param name="rY">The vertical radius of the ellipse.</param>
    /// <param name="angle">The angle of orientation of the ellipse.</param>
    /// <returns>
    /// Returns the points of extreme for an ellipse.
    /// </returns>
    /// <acknowledgment>
    /// Based roughly on the principles found at:
    /// http://stackoverflow.com/questions/87734/how-do-you-calculate-the-axis-aligned-bounding-box-of-an-ellipse
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static List<IPoint2<T>> EllipseExtremePoints<T>(T x, T y, T rX, T rY, T angle) where T : IFloatingPointIeee754<T> => EllipseExtremePoints(x, y, rX, rY, T.Cos(angle), T.Sin(angle));

    /// <summary>
    /// Get the points of the Cartesian extremes of a rotated ellipse.
    /// </summary>
    /// <param name="x">The x-coordinate of the center of the ellipse.</param>
    /// <param name="y">The y-coordinate of the center of the ellipse.</param>
    /// <param name="rX">The horizontal radius of the ellipse.</param>
    /// <param name="rY">The vertical radius of the ellipse.</param>
    /// <param name="cosAngle">The cosine component of the angle of orientation of the ellipse.</param>
    /// <param name="sinAngle">The sine component of the angle of orientation of the ellipse.</param>
    /// <returns>
    /// Returns the points of extreme for an ellipse.
    /// </returns>
    /// <acknowledgment>
    /// Based roughly on the principles found at:
    /// http://stackoverflow.com/questions/87734/how-do-you-calculate-the-axis-aligned-bounding-box-of-an-ellipse
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static List<IPoint2<T>> EllipseExtremePoints<T>(T x, T y, T rX, T rY, T cosAngle, T sinAngle)
        where T : IFloatingPointIeee754<T>
    {
        if (rX == rY)
            return CircleExtremePoints(x, y, rX);

        if (cosAngle == MathFloatConsts<T>.Cos0 && sinAngle == MathFloatConsts<T>.Sin0)
            return OrthogonalEllipseExtremePoints(x, y, rX, rY);

        // Calculate the radii of the angle of rotation.
        var a = rX * cosAngle;
        var b = rY * sinAngle;
        var c = rX * sinAngle;
        var d = rY * cosAngle;

        // Find the angles of the Cartesian extremes.
        var a1 = T.Atan2(-b, a);
        var a2 = T.Atan2(b, -a); // + T.Pi; // sin(t + pi) = -sin(t); cos(t + pi)=-cos(t)
        var a3 = T.Atan2(d, c);
        var a4 = T.Atan2(-d, -c); // + T.Pi; // sin(t + pi) = -sin(t); cos(t + pi)=-cos(t)

        // Return the points of Cartesian extreme of the rotated ellipse.
        return new List<IPoint2<T>>
            {
                new Point2<T>(Interpolators.Ellipse(a1, x, y, rX, rY, cosAngle, sinAngle)),
                new Point2<T>(Interpolators.Ellipse(a3, x, y, rX, rY, cosAngle, sinAngle)),
                new Point2<T>(Interpolators.Ellipse(a2, x, y, rX, rY, cosAngle, sinAngle)),
                new Point2<T>(Interpolators.Ellipse(a4, x, y, rX, rY, cosAngle, sinAngle))
            };

        //// ToDo: Replace the previous two sections with this return and profile to see if there is a performance improvement, and check for accuracy.
        //var hypotonuseAB = Sqrt((a * a) + (b * b));
        //var hypotonuseCD = Sqrt((c * c) + (d * d));
        //return new List<Point2D>
        //{
        //    new Point2<T>(x + hypotonuseAB,
        //                y + (((a * a) - (b * b)) / hypotonuseAB)),
        //    new Point2<T>(x + (((d * a) - (b * c)) / hypotonuseCD),
        //                y + (rX * rY / hypotonuseCD)),
        //    new Point2<T>(x - hypotonuseAB,
        //                y - (((a * a) - (b * b)) / hypotonuseAB)),
        //    new Point2<T>(x - (((d * a) - (b * c)) / hypotonuseCD),
        //                y - (rX * rY / hypotonuseCD)),
        //};
    }
}
