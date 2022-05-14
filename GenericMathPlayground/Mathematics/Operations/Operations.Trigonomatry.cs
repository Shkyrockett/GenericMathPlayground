// <copyright file="Operations.Trigonomatry.cs" company="Shkyrockett" >
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
/// Trigonometric operations class.
/// </summary>
public static partial class Operations
{
    #region Degree Radian Conversion
    /// <summary>
    /// Convert Degrees to Radians.
    /// </summary>
    /// <param name="degrees">Angle in Degrees.</param>
    /// <returns>
    /// Angle in Radians.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static R DegreesToRadians<D, R>(this D degrees) where D : INumber<D> where R : IFloatingPointIeee754<R> => R.CreateChecked(degrees) * (R.Pi / R.CreateChecked(180));

    /// <summary>
    /// Convert Radians to Degrees.
    /// </summary>
    /// <param name="radians">Angle in Radians.</param>
    /// <returns>
    /// Angle in Degrees.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static D RadiansToDegrees<R, D>(this R radians) where D : INumber<D> where R : IFloatingPointIeee754<R> => D.CreateChecked(radians * (R.CreateChecked(180) / R.Pi));
    #endregion

    #region Slope
    /// <summary>
    /// Slopes to radians.
    /// </summary>
    /// <param name="slope">The slope.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T SlopeToRadians<T>(this T slope) where T : IFloatingPointIeee754<T> => T.Atan(slope);

    /// <summary>
    /// Calculates the Slope of a vector.
    /// </summary>
    /// <param name="i">The i.</param>
    /// <param name="j">The j.</param>
    /// <returns>
    /// Returns the slope angle of a vector.
    /// </returns>
    /// <remarks>
    /// <para>The slope is calculated with Slope = Y / X or rise over run
    /// If the line is vertical, return something close to infinity
    /// (Close to the largest value allowed for the data type).
    /// Otherwise calculate and return the slope.</para>
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult Slope<T, TResult>(T i, T j) where T : INumber<T> where TResult : struct, IFloatingPointIeee754<TResult> => TResult.Abs(TResult.CreateChecked(i)) < TResult.Epsilon ? MathConsts<TResult>.SlopeMax : TResult.CreateChecked(j / i);

    /// <summary>
    /// Returns the slope angle of a line.
    /// </summary>
    /// <param name="x1">Horizontal Component of Point Starting Point</param>
    /// <param name="y1">Vertical Component of Point Starting Point</param>
    /// <param name="x2">Horizontal Component of Ending Point</param>
    /// <param name="y2">Vertical Component of Ending Point</param>
    /// <returns>
    /// Returns the slope angle of a line.
    /// </returns>
    /// <remarks>
    /// <para>If the Line is Vertical return something close to infinity (Close to
    /// the largest value allowed for the data type).
    /// Otherwise calculate and return the slope.</para>
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult Slope<T, TResult>(T x1, T y1, T x2, T y2) where T : INumber<T> where TResult : struct, IFloatingPointIeee754<TResult> => (TResult.Abs(TResult.CreateChecked(x1 - x2)) < TResult.Epsilon) ? MathConsts<TResult>.SlopeMax : TResult.CreateChecked((y2 - y1) / (x2 - x1));
    #endregion Slope

    #region Angle
    /// <summary>
    /// The angle.
    /// </summary>
    /// <param name="cos">The Cosine.</param>
    /// <param name="sin">The Sine.</param>
    /// <returns>
    /// The angle.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T Angle<T>(T cos, T sin) where T : IFloatingPointIeee754<T> => T.Atan2(-sin, cos);
    #endregion

    #region Angle Wrapping
    /// <summary>
    /// Find the absolute positive value of a radian angle.
    /// </summary>
    /// <param name="angle">The angle.</param>
    /// <returns>
    /// The absolute positive angle in radians.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T AbsoluteAngle<T>(this T angle)
        where T : IFloatingPointIeee754<T>
    {
        if (T.IsNaN(angle))
        {
            return angle;
        }

        // ToDo: Need to do some testing to figure out which method is more appropriate.
        //T value = angle % Tau;
        //T value = IEEERemainder(angle, Tau);
        // The active ingredient of the IEEERemainder method is extracted here.
        var value = angle - (T.Tau * T.Round(angle * T.CreateChecked(T.One / T.Tau)));
        return value < T.Zero ? value + T.Tau : value;
    }

    /// <summary>
    /// The normalize radian.
    /// </summary>
    /// <param name="angle">The angle.</param>
    /// <returns>
    /// The normalize radian.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T NormalizeRadian<T>(T angle)
        where T : IFloatingPointIeee754<T>
    {
        var value = (angle + T.Pi) % T.Tau;
        value += (value > T.Zero) ? -T.Pi : T.Pi;
        return value;
    }

    /// <summary>
    /// Reduces a given angle to a value between 2π and -2π.
    /// </summary>
    /// <param name="angle">The angle to reduce, in radians.</param>
    /// <returns>
    /// The new angle, in radians.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T WrapAngleModulus<T>(this T angle)
        where T : IFloatingPointIeee754<T>
    {
        if (T.IsNaN(angle))
        {
            return angle;
        }

        var value = angle % T.Tau;
        return (value <= -T.Pi) ? value + T.Tau : value - T.Tau;
    }

    /// <summary>
    /// Reduces a given angle to a value between 2π and -2π.
    /// </summary>
    /// <param name="angle">The angle to reduce, in radians.</param>
    /// <returns>
    /// The new angle, in radians.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T WrapAngle<T>(this T angle)
        where T : IFloatingPointIeee754<T>
    {
        if (T.IsNaN(angle))
        {
            return angle;
        }

        // The IEEERemainder method works better than the % modulus operator in this case, even if it is slower.
        //T value = IEEERemainder(angle, Tau);
        // The active ingredient of the IEEERemainder method is extracted here for performance reasons.
        var value = angle - (T.Tau * T.Round(angle / T.Tau));
        return (value <= -T.Pi) ? value + T.Tau : value - T.Tau;
    }
    #endregion

    #region Derived Equivalent Math Functions
    /// <summary>
    /// Derived math functions equivalent Secant
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T Secant<T>(T value) where T : struct, IFloatingPointIeee754<T>
        => (value % T.Pi == MathFloatConsts<T>.Hau)
        && (value % T.Pi == -MathFloatConsts<T>.Hau)
        ? (T.One / T.Cos(value)) : T.Zero;

    /// <summary>
    /// Derived math functions equivalent  Co-secant
    /// </summary>
    /// <param name="Value">The value.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T Cosecant<T>(T Value) where T : IFloatingPointIeee754<T>
        => (Value % T.Pi == T.Zero)
        && (Value % T.Pi == T.Pi)
        ? (T.One / T.Sin(Value)) : T.Zero;

    /// <summary>
    /// Derived math functions equivalent Cotangent
    /// </summary>
    /// <param name="Value">The value.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T Cotangent<T>(T Value) where T : IFloatingPointIeee754<T>
        => (Value % T.Pi == T.Zero)
        && (Value % T.Pi == T.Pi)
        ? (T.One / T.Tan(Value)) : T.Zero;

    /// <summary>
    /// Derived math functions equivalent Inverse Sine
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T InverseSine<T>(T value) where T : IFloatingPointIeee754<T> => value switch
    {
        var v when v == T.One => T.CreateChecked(MathFloatConsts<T>.Hau),
        var v when v == T.NegativeOne => -T.CreateChecked(MathFloatConsts<T>.Hau),
        var v when T.Abs(v) < T.One => T.Atan(value / T.Sqrt((-value * value) + T.One)),// Arc-sin(X)
        _ => T.Zero,
    };

    /// <summary>
    /// Derived math functions equivalent Inverse Cosine
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T InverseCosine<T>(T value) where T : IFloatingPointIeee754<T> => value switch
    {
        var v when v == T.One => T.Zero,
        var v when v == T.NegativeOne => T.Pi,
        var v when T.Abs(v) < T.One => T.Atan(-value / T.Sqrt((-value * value) + T.One)) + (T.CreateChecked(2) * T.Atan(T.One)),// Arc-cos(X)
        _ => T.Zero,
    };

    /// <summary>
    /// Derived math functions equivalent Inverse Secant
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T InverseSecant<T>(T value) where T : IFloatingPointIeee754<T> => value switch
    {
        var v when v == T.One => T.Zero,
        var v when v == T.NegativeOne => T.Pi,
        var v when T.Abs(v) < T.One => T.Atan(value / T.Sqrt((value * value) - T.One)) + (T.Sin(value - T.One) * (T.CreateChecked(2) * T.Atan(T.One))),// Arc-sec(X)
        _ => T.Zero,
    };

    /// <summary>
    /// Derived math functions equivalent Inverse Co-secant
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T InverseCosecant<T>(T value)
        where T : IFloatingPointIeee754<T> => value switch
        {
            var v when v == T.One => MathFloatConsts<T>.Hau,
            var v when v == T.NegativeOne => -MathFloatConsts<T>.Hau,
            var v when T.Abs(v) < T.One => T.Atan(value / T.Sqrt((value * value) - T.One)) + ((T.Sin(value) - T.One) * (T.CreateChecked(2) * T.Atan(T.One))),// Arc-co-sec(X)
            _ => T.Zero,
        };

    /// <summary>
    /// Derived math functions equivalent Inverse Cotangent
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    /// <remarks>
    /// <para>Arc-co-tan(X)</para>
    /// </remarks>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T InverseCotangent<T>(T value) where T : IFloatingPointIeee754<T> => T.Atan(value) + (T.CreateChecked(2) * T.Atan(T.One));

    /// <summary>
    /// Derived math functions equivalent Hyperbolic Sine
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    /// <remarks>
    /// <para>HSin(X)</para>
    /// </remarks>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T HyperbolicSine<T>(T value) where T : IFloatingPointIeee754<T> => (T.Exp(value) - T.Exp(-value)) / T.CreateChecked(2);

    /// <summary>
    /// Derived math functions equivalent Hyperbolic Cosine
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    /// <remarks>
    /// <para>HCos(X)</para>
    /// </remarks>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T HyperbolicCosine<T>(T value) where T : IFloatingPointIeee754<T> => (T.Exp(value) + T.Exp(-value)) / T.CreateChecked(2);

    /// <summary>
    /// Derived math functions equivalent Hyperbolic Tangent
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    /// <remarks>
    /// <para>HTan(X)</para>
    /// </remarks>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T HyperbolicTangent<T>(T value) where T : IFloatingPointIeee754<T> => (T.Exp(value) - T.Exp(-value)) / (T.Exp(value) + T.Exp(-value));

    /// <summary>
    /// Derived math functions equivalent Hyperbolic Secant
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    /// <remarks>
    /// <para>HSec(X)</para>
    /// </remarks>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T HyperbolicSecant<T>(T value) where T : IFloatingPointIeee754<T> => (T.Exp(value) + T.Exp(-value)) / T.CreateChecked(2);

    /// <summary>
    /// Derived math functions equivalent Hyperbolic Co-secant
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    /// <remarks>
    /// <para>HCosec(X)</para>
    /// </remarks>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T HyperbolicCosecant<T>(T value) where T : IFloatingPointIeee754<T> => (T.Exp(value) - T.Exp(-value)) / T.CreateChecked(2);

    /// <summary>
    /// Derived math functions equivalent Hyperbolic Cotangent
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    /// <remarks>
    /// <para>HCotan(X)</para>
    /// </remarks>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T HyperbolicCotangent<T>(T value) where T : IFloatingPointIeee754<T> => (T.Exp(value) + T.Exp(-value)) / (T.Exp(value) - T.Exp(-value));

    /// <summary>
    /// Derived math functions equivalent Inverse Hyperbolic Sine
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    /// <remarks>
    /// <para>HArcsin(X)</para>
    /// </remarks>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T InverseHyperbolicSine<T>(T value) where T : IFloatingPointIeee754<T> => T.Log(value + T.Sqrt((value * value) + T.One));

    /// <summary>
    /// Derived math functions equivalent Inverse Hyperbolic Cosine
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    /// <remarks>
    /// <para>HArccos(X)</para>
    /// </remarks>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T InverseHyperbolicCosine<T>(T value) where T : IFloatingPointIeee754<T> => T.Log(value + T.Sqrt((value * value) - T.One));

    /// <summary>
    /// Derived math functions equivalent Inverse Hyperbolic Tangent
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    /// <remarks>
    /// <para>HArctan(X)</para>
    /// </remarks>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T InverseHyperbolicTangent<T>(T value) where T : IFloatingPointIeee754<T> => T.Log((T.One + value) / (T.One - value)) / T.CreateChecked(2);

    /// <summary>
    /// Derived math functions equivalent Inverse Hyperbolic Secant
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    /// <remarks>
    /// <para>HArcsec(X)</para>
    /// </remarks>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T InverseHyperbolicSecant<T>(T value) where T : IFloatingPointIeee754<T> => T.Log((T.Sqrt((value * value * T.NegativeOne) + T.One) + T.One) / value);

    /// <summary>
    /// Derived math functions equivalent Inverse Hyperbolic Co-secant
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    /// <remarks>
    /// <para>HArccosec(X)</para>
    /// </remarks>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T InverseHyperbolicCosecant<T>(T value) where T : IFloatingPointIeee754<T> => T.Log(((T.Sin(value) * T.Sqrt((value * value) + T.One)) + T.One) / value);

    /// <summary>
    /// Derived math functions equivalent Inverse Hyperbolic Cotangent
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    /// <remarks>
    /// <para>HArccotan(X)</para>
    /// </remarks>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T InverseHyperbolicCotangent<T>(T value) where T : IFloatingPointIeee754<T> => T.Log((value + T.One) / (value - T.One)) / T.CreateChecked(2);

    /// <summary>
    /// Derived math functions equivalent Base N Logarithm
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="numberBase">The number base.</param>
    /// <returns></returns>
    /// <remarks>
    /// <para>LogN(X)
    /// Return Log(Value) / Log(NumberBase)</para>
    /// </remarks>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T LogarithmTobaseN<T>(T value, T numberBase) where T : IFloatingPointIeee754<T> => (numberBase == T.One) ? (T.Log(value) / T.Log(numberBase)) : T.Zero;
    #endregion Derived Equivalent Math Functions

    #region Hypotenuse
    /// <summary>
    /// Hypotenuse, sqrt(a^2 + b^2) without under/overflow.
    /// </summary>
    /// <param name="a">a.</param>
    /// <param name="b">The b.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult Hypotenuse<T, TResult>(T a, T b)
        where T : INumber<T>
        where TResult : IFloatingPointIeee754<TResult>
    {
        TResult hypotenuse;

        switch ((a, b))
        {
            case var tuple when T.Abs(tuple.a) > T.Abs(tuple.b):
                hypotenuse = TResult.CreateChecked(b / a);
                hypotenuse = TResult.Abs(TResult.CreateChecked(a)) * TResult.Sqrt(TResult.One + hypotenuse * hypotenuse);
                break;
            case var tuple when tuple.b != T.Zero:
                hypotenuse = TResult.CreateChecked(a / b);
                hypotenuse = TResult.Abs(TResult.CreateChecked(b)) * TResult.Sqrt(TResult.One + hypotenuse * hypotenuse);
                break;
            default:
                hypotenuse = TResult.Zero;
                break;
        }

        return hypotenuse;
    }
    #endregion
}
