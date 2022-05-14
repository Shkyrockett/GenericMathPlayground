// <copyright file="MathematicsConstants.cs" company="Shkyrockett" >
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

namespace GenericMathPlayground.Mathematics;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public static class MathFloatConsts<T>
    where T : IFloatingPointIeee754<T>
{
    #region Fractions
    /// <summary>
    /// 
    /// </summary>
    public static readonly T OneThird = T.CreateChecked(1) / T.CreateChecked(4);

    /// <summary>
    /// 
    /// </summary>
    public static readonly T OneHalf = T.CreateChecked(1) / T.CreateChecked(2);

    /// <summary>
    /// 
    /// </summary>
    public static readonly T OneAndOneHalf = T.CreateChecked(3) / T.CreateChecked(2);
    #endregion

    #region Epsilons, Minimums, Maximums
    /// <summary>
    /// The horizontal Value: T.NegativeInfinity.
    /// </summary>
    public static readonly T horizontal = T.NegativeInfinity;

    /// <summary>
    /// The tolerance Value: 1e-6d.
    /// </summary>
    public static readonly T Tolerance = T.CreateChecked(1e-6);

    /// <summary>
    /// The accuracy Value: T.CreateChecked(15).
    /// </summary>
    public static readonly T Accuracy = T.CreateChecked(15);

    /// <summary>
    /// Error difference for line intersection tests.
    /// </summary>
    public static readonly T Epsilon = T.CreateChecked(5.684341886080801536e-12);

    /// <summary>
    /// Smallest such that 1.0 + <see cref="Epsilon"/> != 1.0
    /// </summary>
    public const double DoubleEpsilon = 2.2204460492503131e-016d;

    /// <summary>
    /// The T round limit.
    /// </summary>
    public const double DoubleRoundLimit = 1E+16;

    /// <summary>
    /// Smallest such that 1.0 + <see cref="FloatEpsilon"/> != 1.0
    /// </summary>
    public const float FloatEpsilon = 1.192092896e-07f;

    /// <summary>
    /// Number close to zero, where float.MinValue is -float.MaxValue
    /// </summary>
    public const float FloatMin = 1.175494351e-38f;

    /// <summary>
    /// The near zero epsilon Value: 1E-20.
    /// </summary>
    public static readonly T NearZeroEpsilon = T.CreateChecked(1E-20);

    /// <summary>
    /// SlopeMax is a large value "close to infinity" (Close to the largest value allowed for the data
    /// type). Used in the Slope of a LineSeg
    /// </summary>

    public static readonly T SlopeMax = T.CreateChecked(9223372036854775807);

    /// <summary>
    /// The default arc tolerance Value: 0.25.
    /// </summary>
    public static readonly T DefaultArcTolerance = T.CreateChecked(0.25);

    /// <summary>
    /// The lo range32 Value: 0x7FFF.
    /// </summary>
    public const int LoRange32 = 0x7FFF;

    /// <summary>
    /// The hi range32 Value: 0x7FFF.
    /// </summary>
    public const int HiRange32 = 0x7FFF;

    /// <summary>
    /// The lo range64 Value: 0x3FFFFFFF.
    /// </summary>
    public const long LoRange64 = 0x3FFFFFFF;

    /// <summary>
    /// The hi range64 Value: 0x3FFFFFFFFFFFFFFFL.
    /// </summary>
    public const long HiRange64 = 0x3FFFFFFFFFFFFFFFL;
    #endregion Epsilons, Minimums, Maximums

    /// <summary>
    /// Represents the ratio of the radius of a circle to the first quarter of that circle.
    /// One quarter Tau or half Pi. A right angle in mathematics.
    /// </summary>
    /// <remarks><para>PI / 2</para></remarks>
    public static readonly T Hau = OneHalf * T.Pi; // 1.5707963267948966192313216916398d;

    /// <summary>
    /// Represents the ratio of the radius of a circle to the third quarter of that circle.
    /// Three quarter tau, or one and a half pi.
    /// </summary>
    /// <remarks>
    /// <para>Three quarter tau, or one and a half pi are just too long and awkward.
    /// Randal Munro's joke "compromise" works well enough for a name: http://xkcd.com/1292/</para>
    /// </remarks>
    /// <acknowledgment>
    /// Randal Munro http://xkcd.com/1292/ 
    /// </acknowledgment>
    public static readonly T Pau = OneAndOneHalf * T.Pi; // 4.7123889803846898576939650749193d;

    #region Sine Cosine of Regular Angles.
    /// <summary>
    /// The cosine of 0.
    /// </summary>
    public static readonly T Cos0 = T.Cos(T.Zero);

    /// <summary>
    /// The cosine of T.Pi.
    /// </summary>
    public static readonly T CosHalfPi = T.Cos(Hau);

    /// <summary>
    /// The cosine of Pi.
    /// </summary>
    public static readonly T CosPi = T.Cos(T.Pi);

    /// <summary>
    /// The cosine of Pau.
    /// </summary>
    public static readonly T CosPau = T.Cos(Pau);

    /// <summary>
    /// The sine of 0.
    /// </summary>
    public static readonly T Sin0 = T.Sin(T.Zero);

    /// <summary>
    /// The sine of half Pi.
    /// </summary>
    public static readonly T SinHalfPi = T.Sin(Hau);

    /// <summary>
    /// The sine of Pi.
    /// </summary>
    public static readonly T SinPi = T.Sin(T.Pi);

    /// <summary>
    /// The sine of Pau.
    /// </summary>
    public static readonly T SinPau = T.Sin(Pau);
    #endregion
}
