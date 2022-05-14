// <copyright file="Operations.Polynomials.cs" company="Shkyrockett" >
//     Copyright © 2020 - 2022 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using System.Numerics;
using System.Runtime.CompilerServices;

namespace GenericMathPlayground.Mathematics;

/// <summary>
/// The operations.
/// </summary>
public static partial class Operations
{
    #region Polynomial Real Degree Order
    /// <summary>
    /// Gets the reals order the degrees.
    /// </summary>
    /// <param name="polynomial">The polynomial.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static PolynomialDegree RealDegreeOrder<T>(Span<T> polynomial) where T : INumber<T> => (PolynomialDegree)(polynomial.Length - 1 - polynomial.ClampStart(T.Zero));

    /// <summary>
    /// Gets the reals order the degrees.
    /// </summary>
    /// <param name="polynomial">The polynomial.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static PolynomialDegree RealDegreeOrderReverse<T>(Span<T> polynomial) where T : INumber<T> => (PolynomialDegree)(polynomial.Length - 1 - polynomial.ClampEnd(polynomial.Length, T.Zero));
    #endregion

    #region Generic Roots
    /// <summary>
    /// Finds the Roots of the specified polynomial.
    /// </summary>
    /// <param name="polynomial">The polynomial.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static R[] Roots<T, R>(Span<T> polynomial)
        where T : INumber<T> where R : IFloatingPointIeee754<R>
    {
        var coefficients = polynomial.TrimStart(T.Zero);
        var polynomialDegree = RealDegreeOrder(coefficients);

        return polynomialDegree switch
        {
            PolynomialDegree.Empty => Array.Empty<R>(),
            PolynomialDegree.Constant => Array.ConvertAll(coefficients.ToArray(), new Converter<T, R>(R.CreateChecked)),
            PolynomialDegree.Linear => LinearRoots<T, R>(coefficients[0], coefficients[1]),
            PolynomialDegree.Quadratic => QuadraticRoots<T, R>(coefficients[0], coefficients[1], coefficients[2]),
            PolynomialDegree.Cubic => CubicRoots<T, R>(coefficients[0], coefficients[1], coefficients[2], coefficients[3]),
            PolynomialDegree.Quartic => QuarticRoots<T, R>(coefficients[0], coefficients[1], coefficients[2], coefficients[3], coefficients[4]),
            PolynomialDegree.Quintic => QuinticRoots<T, R>(coefficients[0], coefficients[1], coefficients[2], coefficients[3], coefficients[4], coefficients[5]),
            //PolynomialDegree.Sextic => SexticRoots(coefficients[0], coefficients[1], coefficients[2], coefficients[3], coefficients[4], coefficients[5], coefficients[5]),
            //PolynomialDegree.Septic => SepticRoots(coefficients[0], coefficients[1], coefficients[2], coefficients[3], coefficients[4], coefficients[5], coefficients[5], coefficients[6]),
            //PolynomialDegree.Octic => OcticRoots(coefficients[0], coefficients[1], coefficients[2], coefficients[3], coefficients[4], coefficients[5], coefficients[5], coefficients[6], coefficients[7]),
            //PolynomialDegree.Nonic => NonicRoots(coefficients[0], coefficients[1], coefficients[2], coefficients[3], coefficients[4], coefficients[5], coefficients[5], coefficients[6], coefficients[7], coefficients[8]),
            //PolynomialDegree.Decic => DecicRoots(coefficients[0], coefficients[1], coefficients[2], coefficients[3], coefficients[4], coefficients[5], coefficients[5], coefficients[6], coefficients[7], coefficients[8], coefficients[9]),
            //_ => RootsInInterval(coefficients),
            _ => throw new NotImplementedException(),
        };
    }
    #endregion

    #region Linear Roots
    /// <summary>
    /// Finds the Linear roots of the specified polynomial.
    /// </summary>
    /// <param name="a">The a coefficient.</param>
    /// <param name="b">The b coefficient.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static R[] LinearRoots<T, R>(T a, T b) where T : INumber<T> where R : IFloatingPointIeee754<R> => a == T.Zero ? b == T.Zero ? Array.Empty<R>() : new R[] { R.CreateChecked(b) } : new R[] { -R.CreateChecked(b) / R.CreateChecked(a) };
    #endregion

    #region Quadratic Roots
    /// <summary>
    /// Quadratics the roots.
    /// </summary>
    /// <param name="a">The a coefficient.</param>
    /// <param name="b">The b coefficient.</param>
    /// <param name="c">The c coefficient.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static R[] QuadraticRoots<T, R>(T a, T b, T c)
        where T : INumber<T> where R : IFloatingPointIeee754<R>
    {
        if (a == T.Zero)
        {
            return LinearRoots<T, R>(b, c);
        }

        var ba = R.CreateChecked(b) / R.CreateChecked(a);
        var ca = R.CreateChecked(c) / R.CreateChecked(a);

        switch (R.CreateChecked(ba * ba) - (R.CreateChecked(4) * R.CreateChecked(ca)))
        {
            case var discriminant when discriminant == R.Zero:
                return new R[] { -ba / R.CreateChecked(2) };
            case var discriminant when discriminant > R.Zero:
                {
                    var e = R.Sqrt(discriminant);
                    return new R[] { (-ba + e) / R.CreateChecked(2), (-ba - e) / R.CreateChecked(2) };
                }
            case var discriminant when discriminant < R.Zero:
                {
                    var e = -R.Sqrt(-discriminant);
                    return new R[] { (-ba + e) / R.CreateChecked(2), (-ba - e) / R.CreateChecked(2) };
                }
            default:
                return Array.Empty<R>();
        }
    }
    #endregion

    #region Cubic Roots
    /// <summary>
    /// Finds the Cubic roots of the specified polynomial.
    /// </summary>
    /// <param name="a">The a coefficient.</param>
    /// <param name="b">The b coefficient.</param>
    /// <param name="c">The c coefficient.</param>
    /// <param name="d">The d coefficient.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static R[] CubicRoots<T, R>(T a, T b, T c, T d)
        where T : INumber<T> where R : IFloatingPointIeee754<R>
    {
        if (a == T.Zero)
        {
            return QuadraticRoots<T, R>(b, c, d);
        }

        var ba = R.CreateChecked(b) / R.CreateChecked(a);
        var ca = R.CreateChecked(c) / R.CreateChecked(a);
        var da = R.CreateChecked(d) / R.CreateChecked(a);

        var q = ((R.CreateChecked(3) * ca) - (ba * ba)) / R.CreateChecked(3);
        var r = ((R.CreateChecked(2) * ba * ba * ba) - (R.CreateChecked(9) * ba * ca) + (R.CreateChecked(27) * da)) / R.CreateChecked(27);

        var offset = ba / R.CreateChecked(3);
        var discriminant = (r * r / R.CreateChecked(4)) + (q * q * q / R.CreateChecked(27));
        var halfB = r / R.CreateChecked(2);

        if (R.Abs(discriminant) <= R.Epsilon)
        {
            discriminant = R.Zero;
        }

        switch (discriminant)
        {
            case var v when v == R.Zero:
                {
                    var f = halfB >= R.Zero ? -R.Cbrt(halfB) : R.Cbrt(-halfB);
                    return new R[] { (R.CreateChecked(2) * f) - offset, -f - offset };
                }
            case var v when v > R.Zero:
                {
                    var e = R.Sqrt(v);
                    var tmp = -halfB + e;
                    var root = tmp >= R.Zero ? R.Cbrt(tmp) : -R.Cbrt(-tmp);
                    tmp = -halfB - e;
                    if (tmp >= R.Zero)
                    {
                        root += R.Cbrt(tmp);
                    }
                    else
                    {
                        root -= R.Cbrt(-tmp);
                    }

                    return new R[] { root - offset };
                }
            case var v when v < R.Zero:
                {
                    var distance = R.Sqrt(-q / R.CreateChecked(3));
                    var angle = R.Atan2(R.Sqrt(-discriminant), -halfB) / R.CreateChecked(3);
                    var cos = R.Cos(angle);
                    var sin = R.Sin(angle);
                    var sqrt3 = R.Sqrt(R.CreateChecked(3));
                    return new R[] {
                            (R.CreateChecked(2) * distance * cos) - offset,
                            (-distance * (cos + (sqrt3 * sin))) - offset,
                            (-distance * (cos - (sqrt3 * sin))) - offset
                        };
                }
            default:
                return Array.Empty<R>();
        }
    }
    #endregion

    #region Quartic Roots
    /// <summary>
    /// Finds the Quartic roots of the specified polynomial.
    /// </summary>
    /// <param name="a">The a coefficient.</param>
    /// <param name="b">The b coefficient.</param>
    /// <param name="c">The c coefficient.</param>
    /// <param name="d">The d coefficient.</param>
    /// <param name="e">The e coefficient.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static R[] QuarticRoots<T, R>(T a, T b, T c, T d, T e)
        where T : INumber<T> where R : IFloatingPointIeee754<R>
    {
        if (a == T.Zero)
        {
            return CubicRoots<T, R>(b, c, d, e);
        }

        var ba = R.CreateChecked(b) / R.CreateChecked(a);
        var ca = R.CreateChecked(c) / R.CreateChecked(a);
        var da = R.CreateChecked(d) / R.CreateChecked(a);
        var ea = R.CreateChecked(e) / R.CreateChecked(a);

        var resolveRoots = CubicRoots<R, R>(
            R.One,
            -ca,
            (ba * da) - (R.CreateChecked(4) * ea),
            (-ba * ba * ea) + (R.CreateChecked(4) * ca * ea) - (da * da));

        var y = resolveRoots[0];
        var discriminant = (ba * ba / R.CreateChecked(4)) - ca + y;

        var results = new HashSet<R>();

        switch (discriminant)
        {
            case var v when v == R.Zero:
                {
                    var t2 = (y * y) - (R.CreateChecked(4) * ea);
                    if (t2 >= R.NegativeZero)
                    {
                        if (t2 < R.Zero)
                        {
                            t2 = R.Zero;
                        }

                        t2 = R.CreateChecked(2) * R.Sqrt(t2);
                        var t1 = (R.CreateChecked(3) * ba * ba / R.CreateChecked(4)) - (R.CreateChecked(2) * ca);
                        if (t1 + t2 >= R.Zero)
                        {
                            var d0 = R.Sqrt(t1 + t2);
                            results.Add((-ba / R.CreateChecked(4)) + (d0 / R.CreateChecked(2)));
                            results.Add((-ba / R.CreateChecked(4)) - (d0 / R.CreateChecked(2)));
                        }
                        if (t1 - t2 >= R.Zero)
                        {
                            var d1 = R.Sqrt(t1 - t2);
                            results.Add((-ba / R.CreateChecked(4)) + (d1 / R.CreateChecked(2)));
                            results.Add((-ba / R.CreateChecked(4)) - (d1 / R.CreateChecked(2)));
                        }
                    }
                    return results.ToArray();
                }
            case var v when v > R.Zero:
                {
                    var ee = R.Sqrt(discriminant);
                    var t1 = (R.CreateChecked(3) * ba * ba / R.CreateChecked(4)) - (ee * ee) - (R.CreateChecked(2) * ca);
                    var t2 = ((R.CreateChecked(4) * ba * ca) - (R.CreateChecked(8) * da) - (ba * ba * ba)) / (R.CreateChecked(4) * ee);
                    var plus = t1 + t2;
                    var minus = t1 - t2;

                    if (plus >= R.Zero)
                    {
                        var f = R.Sqrt(plus);
                        results.Add((-ba / R.CreateChecked(4)) + ((ee + f) / R.CreateChecked(2)));
                        results.Add((-ba / R.CreateChecked(4)) + ((ee - f) / R.CreateChecked(2)));
                    }
                    if (minus >= R.Zero)
                    {
                        var f = R.Sqrt(minus);
                        results.Add((-ba / R.CreateChecked(4)) + ((f - ee) / R.CreateChecked(2)));
                        results.Add((-ba / R.CreateChecked(4)) - ((f + ee) / R.CreateChecked(2)));
                    }
                    return results.ToArray();
                }
            case var v when v < R.Zero:
                {
                    // Imaginary roots?
                    return results.ToArray();
                }
            default:
                return Array.Empty<R>();
        }
    }
    #endregion

    #region Quintic Roots
    /// <summary>
    /// Finds the Quintic roots of the specified polynomial.
    /// </summary>
    /// <param name="a">The a coefficient.</param>
    /// <param name="b">The b coefficient.</param>
    /// <param name="c">The c coefficient.</param>
    /// <param name="d">The d coefficient.</param>
    /// <param name="e">The e coefficient.</param>
    /// <param name="f">The f coefficient.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static R[] QuinticRoots<T, R>(T a, T b, T c, T d, T e, T f)
        where T : INumber<T> where R : IFloatingPointIeee754<R>
    {
        // Is the coefficient of the highest term zero?
        if (a == T.Zero)
        {
            // If the highest term coefficient is 0, then it is a lower degree polynomial.
            return QuarticRoots<T, R>(b, c, d, e, f);
        }

        // Order
        var n = 4; // 5;
        var n1 = 5; // 6;
        var n2 = 6; // 7;

        var a_ = new R[] { R.CreateChecked(f), R.CreateChecked(e), R.CreateChecked(d), R.CreateChecked(c), R.CreateChecked(b), R.CreateChecked(a) };
        var b_ = new R[] { R.Zero, R.Zero, R.Zero, R.Zero, R.Zero, R.Zero };
        //var c_ = new R[] { R.Zero, R.Zero, R.Zero, R.Zero, R.Zero, R.Zero };
        var d_ = new R[] { R.Zero, R.Zero, R.Zero, R.Zero, R.Zero, R.Zero };
        var real = new R[] { R.Zero, R.Zero, R.Zero, R.Zero, R.Zero, R.Zero };
        var imag = new R[] { R.Zero, R.Zero, R.Zero, R.Zero, R.Zero, R.Zero };

        // Initialize root counter
        var count = 0;

        // Start the main Lin-Bairstow iteration loop
        do
        {
            // Initialize the counter and guesses for the coefficients of quadratic factor: p(x) = x^2 + alfa1*x + beta1
            // ToDo: The random alphas make this method non-deterministic. Need a better guess method.
            var alfa1 = Random(R.CreateChecked(0.5), R.One);
            var beta1 = Random(R.CreateChecked(0.5), R.One);
            var limit = R.CreateChecked(1000);

            R delta1;
            do
            {
                b_[0] = R.Zero;
                d_[0] = R.Zero;
                b_[1] = R.One;
                d_[1] = R.One;

                for (int i = 2, j = 1, k = 0; i < a_.Length; i++)
                {
                    b_[i] = a_[i] - (alfa1 * b_[j]) - (beta1 * b_[k]);
                    d_[i] = b_[i] - (alfa1 * d_[j]) - (beta1 * d_[k]);
                    j += 1;
                    k += 1;
                }

                R alfa2;

                R beta2;
                {
                    var j = n - 1;
                    var k = n - 2;
                    delta1 = (d_[j] * d_[j]) - ((d_[n] - b_[n]) * d_[k]);
                    alfa2 = ((b_[n] * d_[j]) - (b_[n1] * d_[k])) / delta1;
                    beta2 = ((b_[n1] * d_[j]) - ((d_[n] - b_[n]) * b_[n])) / delta1;
                    alfa1 += alfa2;
                    beta1 += beta2;
                }

                if (--limit < R.Zero)
                {
                    // Cannot solve
                    return Array.Empty<R>();
                }

                if (alfa2 == R.Zero && beta2 == R.Zero)
                {
                    break;
                }
            }
            while (true);

            delta1 = (alfa1 * alfa1) - (R.CreateChecked(4) * beta1);

            R delta2;
            // Imaginary roots
            if (delta1 < R.Zero)
            {
                delta2 = R.Sqrt(R.Abs(delta1)) / R.CreateChecked(2);
                var delta3 = -alfa1 / R.CreateChecked(2);

                real[count] = delta3;
                imag[count] = delta2;

                real[count + 1] = delta3;
                // Sign is inverted on display
                imag[count + 1] = delta2;
            }
            else
            {
                // Roots are real
                delta2 = R.Sqrt(delta1);

                real[count] = (delta2 - alfa1) / R.CreateChecked(2);
                imag[count] = R.Zero;

                real[count + 1] = (delta2 + alfa1) / R.CreateChecked(2);
                imag[count + 1] = R.Zero;
            }

            // Update root counter
            count += 2;

            // Reduce polynomial order
            n -= 2;
            n1 -= 2;
            n2 -= 2;

            // For n >= 2 calculate coefficients of
            // The new polynomial
            if (n >= 2)
            {
                for (var i = 1; i <= n1; i++)
                {
                    a_[i] = b_[i];
                }
            }

            if (n < 2)
            {
                break;
            }
        }
        while (true);

        if (n == 1)
        {
            // Obtain last single real root
            real[count] = -b_[2];
            imag[count] = R.Zero;
        }

        return real.ToArray();
    }
    #endregion

    #region Sextic Roots
    /// <summary>
    /// Finds the Decic roots of the specified polynomial.
    /// </summary>
    /// <param name="a">The a coefficient.</param>
    /// <param name="b">The b coefficient.</param>
    /// <param name="c">The c coefficient.</param>
    /// <param name="d">The d coefficient.</param>
    /// <param name="e">The e coefficient.</param>
    /// <param name="f">The f coefficient.</param>
    /// <param name="g">The g coefficient.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static R[] SexticRoots<T, R>(T a, T b, T c, T d, T e, T f, T g) where T : INumber<T> where R : IFloatingPointIeee754<R>
    {
        _ = a;
        _ = b;
        _ = c;
        _ = d;
        _ = e;
        _ = f;
        _ = g;
        throw new NotImplementedException();
    }
    #endregion

    #region Septic Roots
    /// <summary>
    /// Finds the Decic roots of the specified polynomial.
    /// </summary>
    /// <param name="a">The a coefficient.</param>
    /// <param name="b">The b coefficient.</param>
    /// <param name="c">The c coefficient.</param>
    /// <param name="d">The d coefficient.</param>
    /// <param name="e">The e coefficient.</param>
    /// <param name="f">The f coefficient.</param>
    /// <param name="g">The g coefficient.</param>
    /// <param name="h">The h coefficient.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static R[] SepticRoots<T, R>(T a, T b, T c, T d, T e, T f, T g, T h) where T : INumber<T> where R : IFloatingPointIeee754<R>
    {
        _ = a;
        _ = b;
        _ = c;
        _ = d;
        _ = e;
        _ = f;
        _ = g;
        _ = h;
        throw new NotImplementedException();
    }
    #endregion

    #region Octic Roots
    /// <summary>
    /// Finds the Decic roots of the specified polynomial.
    /// </summary>
    /// <param name="a">The a coefficient.</param>
    /// <param name="b">The b coefficient.</param>
    /// <param name="c">The c coefficient.</param>
    /// <param name="d">The d coefficient.</param>
    /// <param name="e">The e coefficient.</param>
    /// <param name="f">The f coefficient.</param>
    /// <param name="g">The g coefficient.</param>
    /// <param name="h">The h coefficient.</param>
    /// <param name="i">The i coefficient.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static R[] OcticRoots<T, R>(T a, T b, T c, T d, T e, T f, T g, T h, T i) where T : INumber<T> where R : IFloatingPointIeee754<R>
    {
        _ = a;
        _ = b;
        _ = c;
        _ = d;
        _ = e;
        _ = f;
        _ = g;
        _ = h;
        _ = i;
        throw new NotImplementedException();
    }
    #endregion

    #region Nonic Roots
    /// <summary>
    /// Finds the Decic roots of the specified polynomial.
    /// </summary>
    /// <param name="a">The a coefficient.</param>
    /// <param name="b">The b coefficient.</param>
    /// <param name="c">The c coefficient.</param>
    /// <param name="d">The d coefficient.</param>
    /// <param name="e">The e coefficient.</param>
    /// <param name="f">The f coefficient.</param>
    /// <param name="g">The g coefficient.</param>
    /// <param name="h">The h coefficient.</param>
    /// <param name="i">The i coefficient.</param>
    /// <param name="j">The j coefficient.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static R[] NonicRoots<T, R>(T a, T b, T c, T d, T e, T f, T g, T h, T i, T j) where T : INumber<T> where R : IFloatingPointIeee754<R>
    {
        _ = a;
        _ = b;
        _ = c;
        _ = d;
        _ = e;
        _ = f;
        _ = g;
        _ = h;
        _ = i;
        _ = j;
        throw new NotImplementedException();
    }
    #endregion

    #region Decic Roots
    /// <summary>
    /// Finds the Decic roots of the specified polynomial.
    /// </summary>
    /// <param name="a">The a coefficient.</param>
    /// <param name="b">The b coefficient.</param>
    /// <param name="c">The c coefficient.</param>
    /// <param name="d">The d coefficient.</param>
    /// <param name="e">The e coefficient.</param>
    /// <param name="f">The f coefficient.</param>
    /// <param name="g">The g coefficient.</param>
    /// <param name="h">The h coefficient.</param>
    /// <param name="i">The i coefficient.</param>
    /// <param name="j">The j coefficient.</param>
    /// <param name="k">The k coefficient.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static R[] DecicRoots<T, R>(T a, T b, T c, T d, T e, T f, T g, T h, T i, T j, T k) where T : INumber<T> where R : IFloatingPointIeee754<R>
    {
        _ = a;
        _ = b;
        _ = c;
        _ = d;
        _ = e;
        _ = f;
        _ = g;
        _ = h;
        _ = i;
        _ = j;
        _ = k;
        throw new NotImplementedException();
    }
    #endregion
}
