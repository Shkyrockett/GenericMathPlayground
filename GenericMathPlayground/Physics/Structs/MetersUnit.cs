// <copyright file="MetersUnit.cs" company="Shkyrockett" >
//     Copyright � 2021 - 2022 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using GenericMathPlayground.Mathematics;
using Microsoft.Toolkit.HighPerformance;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

namespace GenericMathPlayground.Physics;

/// <summary>
/// 
/// </summary>
[TypeConverter(typeof(LengthUnitConverter<MetersUnit>))]
public readonly struct MetersUnit
    : ILengthUnit,
    IComparable,
    IComparable<MetersUnit>,
    IConvertible,
    IEquatable<MetersUnit>,
    ISpanFormattable,
    IFormattable,
    IBinaryFloatingPointIeee754<MetersUnit>,
    IBinaryNumber<MetersUnit>,
    IBitwiseOperators<MetersUnit, MetersUnit, MetersUnit>,
    INumber<MetersUnit>,
    IAdditionOperators<MetersUnit, MetersUnit, MetersUnit>,
    IAdditiveIdentity<MetersUnit, MetersUnit>,
    IComparisonOperators<MetersUnit, MetersUnit>,
    IEqualityOperators<MetersUnit, MetersUnit>,
    IDecrementOperators<MetersUnit>,
    IDivisionOperators<MetersUnit, MetersUnit, MetersUnit>,
    IIncrementOperators<MetersUnit>,
    IModulusOperators<MetersUnit, MetersUnit, MetersUnit>,
    IMultiplicativeIdentity<MetersUnit, MetersUnit>,
    IMultiplyOperators<MetersUnit, MetersUnit, MetersUnit>,
    IParsable<MetersUnit>,
    ISpanParsable<MetersUnit>,
    ISubtractionOperators<MetersUnit, MetersUnit, MetersUnit>,
    IUnaryNegationOperators<MetersUnit, MetersUnit>,
    IUnaryPlusOperators<MetersUnit, MetersUnit>,
    IFloatingPointIeee754<MetersUnit>,
    ISignedNumber<MetersUnit>,
    IMinMaxValue<MetersUnit>
{
    #region Abstract Properties
    /// <summary>
    /// Gets the additive identity.
    /// </summary>
    [RequiresPreviewFeatures]
    public static MetersUnit AdditiveIdentity => Zero;

    /// <summary>
    /// Gets the e.
    /// </summary>
    [RequiresPreviewFeatures]
    public static MetersUnit E => Math.E;

    /// <summary>
    /// Represents the smallest positive <see cref="MetersUnit" /> value that is greater than zero. This field is constant.
    /// </summary>
    [RequiresPreviewFeatures]
    public static MetersUnit Epsilon => double.Epsilon;

    /// <summary>
    /// Represents a value that is not a number (<see langword="NaN" />). This field is constant.
    /// </summary>
    [RequiresPreviewFeatures]
    public static MetersUnit NaN => double.NaN;

    /// <summary>
    /// Represents negative infinity. This field is constant.
    /// </summary>
    [RequiresPreviewFeatures]
    public static MetersUnit NegativeInfinity => double.NegativeInfinity;

    /// <summary>
    /// Gets the negative zero.
    /// </summary>
    [RequiresPreviewFeatures]
    public static MetersUnit NegativeZero => -0d;

    /// <summary>
    /// Gets the pi.
    /// </summary>
    [RequiresPreviewFeatures]
    public static MetersUnit Pi => Math.PI;

    /// <summary>
    /// Represents positive infinity. This field is constant.
    /// </summary>
    [RequiresPreviewFeatures]
    public static MetersUnit PositiveInfinity => double.PositiveInfinity;

    /// <summary>
    /// Gets the tau.
    /// </summary>
    [RequiresPreviewFeatures]
    public static MetersUnit Tau => Math.Tau;

    /// <summary>
    /// Represents the smallest possible value of a <see cref="MetersUnit" />. This field is constant.
    /// </summary>
    [RequiresPreviewFeatures]
    public static MetersUnit MinValue => double.MinValue;

    /// <summary>
    /// Represents the largest possible value of a <see cref="MetersUnit" />. This field is constant.
    /// </summary>
    [RequiresPreviewFeatures]
    public static MetersUnit MaxValue => double.MaxValue;

    /// <summary>
    /// Gets the one.
    /// </summary>
    [RequiresPreviewFeatures]
    public static MetersUnit One => 1d;

    /// <summary>
    /// Gets the zero.
    /// </summary>
    [RequiresPreviewFeatures]
    public static MetersUnit Zero => 0d;

    /// <summary>
    /// Gets the multiplicative identity.
    /// </summary>
    [RequiresPreviewFeatures]
    public static MetersUnit MultiplicativeIdentity => One;

    /// <summary>
    /// Gets the negative one.
    /// </summary>
    [RequiresPreviewFeatures]
    public static MetersUnit NegativeOne => -1d;

    /// <summary>
    /// Gets the in meters.
    /// </summary>
    [RequiresPreviewFeatures]
    public static double InMeters => 1d;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="MetersUnit"/> class.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public MetersUnit() : this(0d) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="MetersUnit"/> class.
    /// </summary>
    /// <param name="v">The v.</param>
    public MetersUnit(double v) => Value = v;

    /// <summary>
    /// Initializes a new instance of the <see cref="MetersUnit"/> class.
    /// </summary>
    /// <param name="v">The v.</param>
    public MetersUnit(MetersUnit v) => Value = v.Value;
    #endregion

    #region Properties
    /// <summary>
    /// Gets the value.
    /// </summary>
    public double Value { get; }
    #endregion

    #region Operators
    /// <summary>
    /// Returns a value that indicates whether two specified <see cref="MetersUnit" /> values are equal.
    /// </summary>
    /// <param name="left">The first value to compare.</param>
    /// <param name="right">The second value to compare.</param>
    /// <returns>
    ///   <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are equal; otherwise, <see langword="false" />.
    /// </returns>
    public static bool operator ==(MetersUnit left, MetersUnit right) => left.Value == right.Value;

    /// <summary>
    /// Returns a value that indicates whether two specified <see cref="MetersUnit" /> values are not equal.
    /// </summary>
    /// <param name="left">The first value to compare.</param>
    /// <param name="right">The second value to compare.</param>
    /// <returns>
    ///   <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are not equal; otherwise, <see langword="false" />.
    /// </returns>
    public static bool operator !=(MetersUnit left, MetersUnit right) => !(left == right);

    /// <summary>
    /// Returns a value that indicates whether a specified <see cref="MetersUnit" /> value is greater than another specified <see cref="MetersUnit" /> value.
    /// </summary>
    /// <param name="left">The first value to compare.</param>
    /// <param name="right">The second value to compare.</param>
    /// <returns>
    ///   <see langword="true" /> if <paramref name="left" /> is greater than <paramref name="right" />; otherwise, <see langword="false" />.
    /// </returns>
    public static bool operator >(MetersUnit left, MetersUnit right) => left.Value > right.Value;

    /// <summary>
    /// Returns a value that indicates whether a specified <see cref="MetersUnit" /> value is greater than or equal to another specified <see cref="MetersUnit" /> value.
    /// </summary>
    /// <param name="left">The first value to compare.</param>
    /// <param name="right">The second value to compare.</param>
    /// <returns>
    ///   <see langword="true" /> if <paramref name="left" /> is greater than or equal to <paramref name="right" />; otherwise, <see langword="false" />.
    /// </returns>
    public static bool operator >=(MetersUnit left, MetersUnit right) => left.Value >= right.Value;

    /// <summary>
    /// Returns a value that indicates whether a specified <see cref="MetersUnit" /> value is less than another specified <see cref="MetersUnit" /> value.
    /// </summary>
    /// <param name="left">The first value to compare.</param>
    /// <param name="right">The second value to compare.</param>
    /// <returns>
    ///   <see langword="true" /> if <paramref name="left" /> is less than <paramref name="right" />; otherwise, <see langword="false" />.
    /// </returns>
    public static bool operator <(MetersUnit left, MetersUnit right) => left.Value < right.Value;

    /// <summary>
    /// Returns a value that indicates whether a specified <see cref="MetersUnit" /> value is less than or equal to another specified <see cref="MetersUnit" /> value.
    /// </summary>
    /// <param name="left">The first value to compare.</param>
    /// <param name="right">The second value to compare.</param>
    /// <returns>
    ///   <see langword="true" /> if <paramref name="left" /> is less than or equal to <paramref name="right" />; otherwise, <see langword="false" />.
    /// </returns>
    public static bool operator <=(MetersUnit left, MetersUnit right) => left.Value <= right.Value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static MetersUnit operator &(MetersUnit left, MetersUnit right)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static MetersUnit operator |(MetersUnit left, MetersUnit right)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static MetersUnit operator ^(MetersUnit left, MetersUnit right)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static MetersUnit operator ~(MetersUnit value)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static MetersUnit operator -(MetersUnit value) => new(-value.Value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static MetersUnit operator checked -(MetersUnit value) => new(-value.Value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static MetersUnit operator --(MetersUnit value) => new(value.Value - One.Value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static MetersUnit operator checked --(MetersUnit value) => new(value.Value - One.Value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static MetersUnit operator -(MetersUnit left, MetersUnit right) => new(left.Value - right.Value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static MetersUnit operator checked -(MetersUnit left, MetersUnit right) => new(left.Value - right.Value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static MetersUnit operator +(MetersUnit value) => new(+value.Value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static MetersUnit operator ++(MetersUnit value) => new(value.Value + One.Value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static MetersUnit operator checked ++(MetersUnit value) => new(value.Value + One.Value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static MetersUnit operator +(MetersUnit left, MetersUnit right) => new(left.Value + right.Value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static MetersUnit operator checked +(MetersUnit left, MetersUnit right) => new(left.Value + right.Value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static MetersUnit operator /(MetersUnit left, MetersUnit right) => new(left.Value / right.Value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static MetersUnit operator checked /(MetersUnit left, MetersUnit right) => new(left.Value / right.Value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static MetersUnit operator %(MetersUnit left, MetersUnit right) => new(left.Value % right.Value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static MetersUnit operator *(MetersUnit left, MetersUnit right) => new(left.Value * right.Value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static MetersUnit operator checked *(MetersUnit left, MetersUnit right) => new(left.Value * right.Value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="v"></param>
    public static implicit operator MetersUnit(double v) => new(v);
    #endregion

    /// <summary>
    /// Compares this instance to a specified double-precision floating-point number and returns an integer that indicates whether the value of this instance is less than, equal to, or greater than the value of the specified double-precision floating-point number.
    /// </summary>
    /// <param name="value">A double-precision floating-point number to compare.</param>
    /// <returns>
    /// A signed number indicating the relative values of this instance and <paramref name="value" />.  
    /// <list type="table"><listheader><term> Return Value</term><description> Description</description></listheader><item><term> Less than zero</term><description> This instance is less than <paramref name="value" />, or this instance is not a number (<see cref="F:MetersUnit.NaN" />) and <paramref name="value" /> is a number.</description></item><item><term> Zero</term><description> This instance is equal to <paramref name="value" />, or both this instance and <paramref name="value" /> are not a number (<see cref="F:MetersUnit.NaN" />), <see cref="F:MetersUnit.PositiveInfinity" />, or <see cref="F:MetersUnit.NegativeInfinity" />.</description></item><item><term> Greater than zero</term><description> This instance is greater than <paramref name="value" />, or this instance is a number and <paramref name="value" /> is not a number (<see cref="F:MetersUnit.NaN" />).</description></item></list>
    /// </returns>
    public int CompareTo(double value) => Value.CompareTo(value);

    /// <summary>
    /// Compares this instance to a specified object and returns an integer that indicates whether the value of this instance is less than, equal to, or greater than the value of the specified object.
    /// </summary>
    /// <param name="value">An object to compare, or <see langword="null" />.</param>
    /// <exception cref="T:System.ArgumentException">
    ///   <paramref name="value" /> is not a <see cref="MetersUnit" />.</exception>
    /// <returns>
    /// A signed number indicating the relative values of this instance and <paramref name="value" />.  
    /// <list type="table"><listheader><term> Value</term><description> Description</description></listheader><item><term> A negative integer</term><description> This instance is less than <paramref name="value" />, or this instance is not a number (<see cref="F:MetersUnit.NaN" />) and <paramref name="value" /> is a number.</description></item><item><term> Zero</term><description> This instance is equal to <paramref name="value" />, or this instance and <paramref name="value" /> are both <see langword="MetersUnit.NaN" />, <see cref="F:MetersUnit.PositiveInfinity" />, or <see cref="F:MetersUnit.NegativeInfinity" /></description></item><item><term> A positive integer</term><description> This instance is greater than <paramref name="value" />, OR this instance is a number and <paramref name="value" /> is not a number (<see cref="F:MetersUnit.NaN" />), OR <paramref name="value" /> is <see langword="null" />.</description></item></list>
    /// </returns>
    public int CompareTo(object? value) => Value.CompareTo(value);

    /// <summary>
    /// Returns a value indicating whether this instance and a specified <see cref="MetersUnit" /> object represent the same value.
    /// </summary>
    /// <param name="obj">A <see cref="MetersUnit" /> object to compare to this instance.</param>
    /// <returns>
    ///   <see langword="true" /> if <paramref name="obj" /> is equal to this instance; otherwise, <see langword="false" />.
    /// </returns>
    public bool Equals(double obj) => Value.Equals(obj);

    /// <summary>
    /// Returns a value indicating whether this instance is equal to a specified object.
    /// </summary>
    /// <param name="obj">An object to compare with this instance.</param>
    /// <returns>
    ///   <see langword="true" /> if <paramref name="obj" /> is an instance of <see cref="MetersUnit" /> and equals the value of this instance; otherwise, <see langword="false" />.
    /// </returns>
    public override bool Equals([NotNullWhen(true)] object? obj) => Value.Equals(obj);

    /// <summary>
    /// Returns the hash code for this instance.
    /// </summary>
    /// <returns>A 32-bit signed integer hash code.</returns>
    public override int GetHashCode() => Value.GetHashCode();

    /// <summary>
    /// Returns the <see cref="T:System.TypeCode" /> for value type <see cref="MetersUnit" />.
    /// </summary>
    /// <returns>
    /// The enumerated constant, <see cref="F:System.TypeCode.MetersUnit" />.
    /// </returns>
    public TypeCode GetTypeCode() => Value.GetTypeCode();

    /// <summary>
    /// Determines whether the specified value is finite (zero, subnormal, or normal).
    /// </summary>
    /// <param name="d">A double-precision floating-point number.</param>
    /// <returns>
    ///   <see langword="true" /> if the value is finite (zero, subnormal or normal); <see langword="false" /> otherwise.
    /// </returns>
    public static bool IsFinite(MetersUnit d) => double.IsFinite(d.Value);

    /// <summary>
    /// Returns a value indicating whether the specified number evaluates to negative or positive infinity.
    /// </summary>
    /// <param name="d">A double-precision floating-point number.</param>
    /// <returns>
    ///   <see langword="true" /> if <paramref name="d" /> evaluates to <see cref="F:MetersUnit.PositiveInfinity" /> or <see cref="F:MetersUnit.NegativeInfinity" />; otherwise, <see langword="false" />.
    /// </returns>
    public static bool IsInfinity(MetersUnit d) => double.IsInfinity(d.Value);

    /// <summary>
    /// Returns a value that indicates whether the specified value is not a number (<see cref="F:MetersUnit.NaN" />).
    /// </summary>
    /// <param name="d">A double-precision floating-point number.</param>
    /// <returns>
    ///   <see langword="true" /> if <paramref name="d" /> evaluates to <see cref="F:MetersUnit.NaN" />; otherwise, <see langword="false" />.
    /// </returns>
    public static bool IsNaN(MetersUnit d) => double.IsNaN(d.Value);

    /// <summary>
    /// Determines whether the specified value is negative.
    /// </summary>
    /// <param name="d">A double-precision floating-point number.</param>
    /// <returns>
    ///   <see langword="true" /> if the value is negative; <see langword="false" /> otherwise.
    /// </returns>
    public static bool IsNegative(MetersUnit d) => double.IsNegative(d.Value);

    /// <summary>
    /// Returns a value indicating whether the specified number evaluates to negative infinity.
    /// </summary>
    /// <param name="d">A double-precision floating-point number.</param>
    /// <returns>
    ///   <see langword="true" /> if <paramref name="d" /> evaluates to <see cref="F:MetersUnit.NegativeInfinity" />; otherwise, <see langword="false" />.
    /// </returns>
    public static bool IsNegativeInfinity(MetersUnit d) => double.IsNegativeInfinity(d.Value);

    /// <summary>
    /// Determines whether the specified value is normal.
    /// </summary>
    /// <param name="d">A double-precision floating-point number.</param>
    /// <returns>
    ///   <see langword="true" /> if the value is normal; <see langword="false" /> otherwise.
    /// </returns>
    public static bool IsNormal(MetersUnit d) => double.IsNormal(d.Value);

    /// <summary>
    /// Returns a value indicating whether the specified number evaluates to positive infinity.
    /// </summary>
    /// <param name="d">A double-precision floating-point number.</param>
    /// <returns>
    ///   <see langword="true" /> if <paramref name="d" /> evaluates to <see cref="F:MetersUnit.PositiveInfinity" />; otherwise, <see langword="false" />.
    /// </returns>
    public static bool IsPositiveInfinity(MetersUnit d) => double.IsPositiveInfinity(d.Value);

    /// <summary>
    /// Determines whether the specified value is subnormal.
    /// </summary>
    /// <param name="d">A double-precision floating-point number.</param>
    /// <returns>
    ///   <see langword="true" /> if the value is subnormal; <see langword="false" /> otherwise.
    /// </returns>
    public static bool IsSubnormal(MetersUnit d) => double.IsSubnormal(d.Value);

    /// <summary>
    /// Converts a character span that contains the string representation of a number in a specified style and culture-specific format to its double-precision floating-point number equivalent.
    /// </summary>
    /// <param name="s">A character span that contains the number to convert.</param>
    /// <param name="style">A bitwise combination of enumeration values that indicate the style elements that can be present in <paramref name="s" />.  A typical value to specify is <see cref="F:System.Globalization.NumberStyles.Float" /> combined with <see cref="F:System.Globalization.NumberStyles.AllowThousands" />.</param>
    /// <param name="provider">An object that supplies culture-specific formatting information about <paramref name="s" />.</param>
    /// <exception cref="T:System.FormatException">
    ///   <paramref name="s" /> does not represent a numeric value.</exception>
    /// <exception cref="T:System.ArgumentException">
    ///   <paramref name="style" /> is not a <see cref="T:System.Globalization.NumberStyles" /> value.  
    ///  -or-  
    ///  <paramref name="style" /> is the <see cref="F:System.Globalization.NumberStyles.AllowHexSpecifier" /> value.</exception>
    /// <returns>
    /// A double-precision floating-point number that is equivalent to the numeric value or symbol specified in <paramref name="s" />.
    /// </returns>
    public static MetersUnit Parse(ReadOnlySpan<char> s, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands, IFormatProvider? provider = null) => double.Parse(s, style, provider);

    /// <summary>
    /// Converts the string representation of a number to its double-precision floating-point number equivalent.
    /// </summary>
    /// <param name="s">A string that contains a number to convert.</param>
    /// <exception cref="T:System.ArgumentNullException">
    ///   <paramref name="s" /> is <see langword="null" />.</exception>
    /// <exception cref="T:System.FormatException">
    ///   <paramref name="s" /> does not represent a number in a valid format.</exception>
    /// <exception cref="T:System.OverflowException">
    ///     .NET Framework and .NET Core 2.2 and earlier versions only: <paramref name="s" /> represents a number that is less than <see cref="F:MetersUnit.MinValue" /> or greater than <see cref="F:MetersUnit.MaxValue" />.</exception>
    /// <returns>
    /// A double-precision floating-point number that is equivalent to the numeric value or symbol specified in <paramref name="s" />.
    /// </returns>
    public static MetersUnit Parse(string s) => double.Parse(s);

    /// <summary>
    /// Converts the string representation of a number in a specified style to its double-precision floating-point number equivalent.
    /// </summary>
    /// <param name="s">A string that contains a number to convert.</param>
    /// <param name="style">A bitwise combination of enumeration values that indicate the style elements that can be present in <paramref name="s" />. A typical value to specify is a combination of <see cref="F:System.Globalization.NumberStyles.Float" /> combined with <see cref="F:System.Globalization.NumberStyles.AllowThousands" />.</param>
    /// <exception cref="T:System.ArgumentNullException">
    ///   <paramref name="s" /> is <see langword="null" />.</exception>
    /// <exception cref="T:System.FormatException">
    ///   <paramref name="s" /> does not represent a number in a valid format.</exception>
    /// <exception cref="T:System.OverflowException">
    ///     .NET Framework and .NET Core 2.2 and earlier versions only: <paramref name="s" /> represents a number that is less than <see cref="F:MetersUnit.MinValue" /> or greater than <see cref="F:MetersUnit.MaxValue" />.</exception>
    /// <exception cref="T:System.ArgumentException">
    ///   <paramref name="style" /> is not a <see cref="T:System.Globalization.NumberStyles" /> value.  
    ///  -or-  
    ///  <paramref name="style" /> includes the <see cref="F:System.Globalization.NumberStyles.AllowHexSpecifier" /> value.</exception>
    /// <returns>
    /// A double-precision floating-point number that is equivalent to the numeric value or symbol specified in <paramref name="s" />.
    /// </returns>
    public static MetersUnit Parse(string s, NumberStyles style) => double.Parse(s, style);

    /// <summary>
    /// Converts the string representation of a number in a specified style and culture-specific format to its double-precision floating-point number equivalent.
    /// </summary>
    /// <param name="s">A string that contains a number to convert.</param>
    /// <param name="style">A bitwise combination of enumeration values that indicate the style elements that can be present in <paramref name="s" />. A typical value to specify is <see cref="F:System.Globalization.NumberStyles.Float" /> combined with <see cref="F:System.Globalization.NumberStyles.AllowThousands" />.</param>
    /// <param name="provider">An object that supplies culture-specific formatting information about <paramref name="s" />.</param>
    /// <exception cref="T:System.ArgumentNullException">
    ///   <paramref name="s" /> is <see langword="null" />.</exception>
    /// <exception cref="T:System.FormatException">
    ///   <paramref name="s" /> does not represent a numeric value.</exception>
    /// <exception cref="T:System.ArgumentException">
    ///   <paramref name="style" /> is not a <see cref="T:System.Globalization.NumberStyles" /> value.  
    ///  -or-  
    ///  <paramref name="style" /> is the <see cref="F:System.Globalization.NumberStyles.AllowHexSpecifier" /> value.</exception>
    /// <exception cref="T:System.OverflowException">
    ///     .NET Framework and .NET Core 2.2 and earlier versions only: <paramref name="s" /> represents a number that is less than <see cref="F:MetersUnit.MinValue" /> or greater than <see cref="F:MetersUnit.MaxValue" />.</exception>
    /// <returns>
    /// A double-precision floating-point number that is equivalent to the numeric value or symbol specified in <paramref name="s" />.
    /// </returns>
    public static MetersUnit Parse(string s, NumberStyles style, IFormatProvider? provider) => double.Parse(s, style, provider);

    /// <summary>
    /// Converts the string representation of a number in a specified culture-specific format to its double-precision floating-point number equivalent.
    /// </summary>
    /// <param name="s">A string that contains a number to convert.</param>
    /// <param name="provider">An object that supplies culture-specific formatting information about <paramref name="s" />.</param>
    /// <exception cref="T:System.ArgumentNullException">
    ///   <paramref name="s" /> is <see langword="null" />.</exception>
    /// <exception cref="T:System.FormatException">
    ///   <paramref name="s" /> does not represent a number in a valid format.</exception>
    /// <exception cref="T:System.OverflowException">
    ///     .NET Framework and .NET Core 2.2 and earlier versions only: <paramref name="s" /> represents a number that is less than <see cref="F:MetersUnit.MinValue" /> or greater than <see cref="F:MetersUnit.MaxValue" />.</exception>
    /// <returns>
    /// A double-precision floating-point number that is equivalent to the numeric value or symbol specified in <paramref name="s" />.
    /// </returns>
    public static MetersUnit Parse(string s, IFormatProvider? provider) => double.Parse(s, provider);

    /// <summary>
    /// For a description of this member, see <see cref="M:System.IConvertible.ToBoolean(System.IFormatProvider)" />.
    /// </summary>
    /// <param name="provider">This parameter is ignored.</param>
    /// <returns>
    ///   <see langword="true" /> if the value of the current instance is not zero; otherwise, <see langword="false" />.
    /// </returns>
    bool IConvertible.ToBoolean(IFormatProvider? provider) => Convert.ToBoolean(Value, provider);

    /// <summary>
    /// For a description of this member, see <see cref="M:System.IConvertible.ToByte(System.IFormatProvider)" />.
    /// </summary>
    /// <param name="provider">This parameter is ignored.</param>
    /// <returns>
    /// The value of the current instance, converted to a <see cref="T:System.Byte" />.
    /// </returns>
    byte IConvertible.ToByte(IFormatProvider? provider) => Convert.ToByte(Value, provider);

    /// <summary>
    /// This conversion is not supported. Attempting to use this method throws an <see cref="T:System.InvalidCastException" />.
    /// </summary>
    /// <param name="provider">This parameter is ignored.</param>
    /// <exception cref="T:System.InvalidCastException">In all cases.</exception>
    /// <returns>
    /// This conversion is not supported. No value is returned.
    /// </returns>
    char IConvertible.ToChar(IFormatProvider? provider) => Convert.ToChar(Value, provider);

    /// <summary>
    /// This conversion is not supported. Attempting to use this method throws an <see cref="T:System.InvalidCastException" />
    /// </summary>
    /// <param name="provider">This parameter is ignored.</param>
    /// <exception cref="T:System.InvalidCastException">In all cases.</exception>
    /// <returns>
    /// This conversion is not supported. No value is returned.
    /// </returns>
    DateTime IConvertible.ToDateTime(IFormatProvider? provider) => Convert.ToDateTime(Value, provider);

    /// <summary>
    /// For a description of this member, see <see cref="M:System.IConvertible.ToDecimal(System.IFormatProvider)" />.
    /// </summary>
    /// <param name="provider">This parameter is ignored.</param>
    /// <returns>
    /// The value of the current instance, converted to a <see cref="T:System.Decimal" />.
    /// </returns>
    decimal IConvertible.ToDecimal(IFormatProvider? provider) => Convert.ToInt16(Value, provider);

    /// <summary>
    /// For a description of this member, see <see cref="M:System.IConvertible.ToDouble(System.IFormatProvider)" />.
    /// </summary>
    /// <param name="provider">This parameter is ignored.</param>
    /// <returns>
    /// The value of the current instance, unchanged.
    /// </returns>
    double IConvertible.ToDouble(IFormatProvider? provider) => Value;

    /// <summary>
    /// For a description of this member, see <see cref="M:System.IConvertible.ToInt16(System.IFormatProvider)" />.
    /// </summary>
    /// <param name="provider">This parameter is ignored.</param>
    /// <returns>
    /// The value of the current instance, converted to an <see cref="T:System.Int16" />.
    /// </returns>
    short IConvertible.ToInt16(IFormatProvider? provider) => Convert.ToInt16(Value, provider);

    /// <summary>
    /// For a description of this member, see <see cref="M:System.IConvertible.ToInt32(System.IFormatProvider)" />.
    /// </summary>
    /// <param name="provider">This parameter is ignored.</param>
    /// <returns>
    /// The value of the current instance, converted to an <see cref="T:System.Int32" />.
    /// </returns>
    int IConvertible.ToInt32(IFormatProvider? provider) => Convert.ToInt32(Value, provider);

    /// <summary>
    /// For a description of this member, see <see cref="M:System.IConvertible.ToInt64(System.IFormatProvider)" />.
    /// </summary>
    /// <param name="provider">This parameter is ignored.</param>
    /// <returns>The value of the current instance, converted to an <see cref="T:System.Int64" />.</returns>
    long IConvertible.ToInt64(IFormatProvider? provider) => Convert.ToInt64(Value, provider);

    /// <summary>
    /// For a description of this member, see <see cref="M:System.IConvertible.ToSByte(System.IFormatProvider)" />.
    /// </summary>
    /// <param name="provider">This parameter is ignored.</param>
    /// <returns>The value of the current instance, converted to an <see cref="T:System.SByte" />.</returns>
    sbyte IConvertible.ToSByte(IFormatProvider? provider) => Convert.ToSByte(Value, provider);

    /// <summary>
    /// For a description of this member, see <see cref="M:System.IConvertible.ToSingle(System.IFormatProvider)" />.
    /// </summary>
    /// <param name="provider">This parameter is ignored.</param>
    /// <returns>
    /// The value of the current instance, converted to a <see cref="T:System.Single" />.
    /// </returns>
    float IConvertible.ToSingle(IFormatProvider? provider) => Convert.ToSingle(Value, provider);

    /// <summary>
    /// For a description of this member, see <see cref="M:System.IConvertible.ToType(System.Type,System.IFormatProvider)" />.
    /// </summary>
    /// <param name="type">The type to which to convert this <see cref="MetersUnit" /> value.</param>
    /// <param name="provider">An <see cref="T:System.IFormatProvider" /> implementation that supplies culture-specific information about the format of the returned value.</param>
    /// <returns>
    /// The value of the current instance, converted to <paramref name="type" />.
    /// </returns>
    object IConvertible.ToType(Type type, IFormatProvider? provider) => Convert.ChangeType(Value, type, provider);

    /// <summary>
    /// For a description of this member, see <see cref="M:System.IConvertible.ToUInt16(System.IFormatProvider)" />.
    /// </summary>
    /// <param name="provider">This parameter is ignored.</param>
    /// <returns>
    /// The value of the current instance, converted to a <see cref="T:System.UInt16" />.
    /// </returns>
    ushort IConvertible.ToUInt16(IFormatProvider? provider) => Convert.ToUInt16(Value, provider);

    /// <summary>
    /// For a description of this member, see <see cref="M:System.IConvertible.ToUInt32(System.IFormatProvider)" />.
    /// </summary>
    /// <param name="provider">This parameter is ignored.</param>
    /// <returns>
    /// The value of the current instance, converted to a <see cref="T:System.UInt32" />.
    /// </returns>
    uint IConvertible.ToUInt32(IFormatProvider? provider) => Convert.ToUInt32(Value, provider);

    /// <summary>
    /// For a description of this member, see <see cref="M:System.IConvertible.ToUInt64(System.IFormatProvider)" />.
    /// </summary>
    /// <param name="provider">This parameter is ignored.</param>
    /// <returns>
    /// The value of the current instance, converted to a <see cref="T:System.UInt64" />.
    /// </returns>
    ulong IConvertible.ToUInt64(IFormatProvider? provider) => Convert.ToUInt64(Value, provider);

    /// <summary>
    /// Converts the numeric value of this instance to its equivalent string representation.
    /// </summary>
    /// <returns>
    /// The string representation of the value of this instance.
    /// </returns>
    public override string ToString() => ToString("R", CultureInfo.InvariantCulture);

    /// <summary>
    /// Converts the numeric value of this instance to its equivalent string representation using the specified culture-specific format information.
    /// </summary>
    /// <param name="provider">An object that supplies culture-specific formatting information.</param>
    /// <returns>
    /// The string representation of the value of this instance as specified by <paramref name="provider" />.
    /// </returns>
    public string ToString(IFormatProvider? provider) => ToString("R", provider);

    /// <summary>
    /// Converts the numeric value of this instance to its equivalent string representation, using the specified format.
    /// </summary>
    /// <param name="format">A numeric format string.</param>
    /// <exception cref="T:System.FormatException">
    ///   <paramref name="format" /> is invalid.</exception>
    /// <returns>
    /// The string representation of the value of this instance as specified by <paramref name="format" />.
    /// </returns>
    public string ToString(string? format) => ToString(format, CultureInfo.InvariantCulture);

    /// <summary>
    /// Converts the numeric value of this instance to its equivalent string representation using the specified format and culture-specific format information.
    /// </summary>
    /// <param name="format">A numeric format string.</param>
    /// <param name="provider">An object that supplies culture-specific formatting information.</param>
    /// <returns>
    /// The string representation of the value of this instance as specified by <paramref name="format" /> and <paramref name="provider" />.
    /// </returns>
    public string ToString(string? format, IFormatProvider? provider) => $"{Value.ToString(format, provider)} m";

    /// <summary>
    /// Tries to format the value of the current double instance into the provided span of characters.
    /// </summary>
    /// <param name="destination">When this method returns, this instance's value formatted as a span of characters.</param>
    /// <param name="charsWritten">When this method returns, the number of characters that were written in <paramref name="destination" />.</param>
    /// <param name="format">A span containing the characters that represent a standard or custom format string that defines the acceptable format for <paramref name="destination" />.</param>
    /// <param name="provider">An optional object that supplies culture-specific formatting information for <paramref name="destination" />.</param>
    /// <returns>
    ///   <see langword="true" /> if the formatting was successful; otherwise, <see langword="false" />.
    /// </returns>
    public unsafe bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider? provider = null)
    {
        var text = ToString(format.ToString(), provider).AsSpan();
        charsWritten = text.Length;
        text.CopyTo(destination);
        return true;
    }

    /// <summary>
    /// Parses the.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="provider">The provider.</param>
    /// <returns>A MetersUnit.</returns>
    public static MetersUnit Parse(ReadOnlySpan<char> s, IFormatProvider? provider) => double.Parse(s.ToString(), provider);

    /// <summary>
    /// Converts the span representation of a number in a specified style and culture-specific format to its double-precision floating-point number equivalent. A return value indicates whether the conversion succeeded or failed.
    /// </summary>
    /// <param name="s">A character span that contains the string representation of the number to convert.</param>
    /// <param name="result">When this method returns, contains the double-precision floating-point number equivalent of the numeric value or symbol contained in <paramref name="s" /> parameter, if the conversion succeeded, or zero if the conversion failed. The conversion fails if the <paramref name="s" /> parameter is <see langword="null" /> or empty, or is not in a format compliant with style. The conversion also fails if style is not a valid combination of <see cref="T:System.Globalization.NumberStyles" /> enumerated constants. If <paramref name="s" /> is a valid number less than <see cref="F:MetersUnit.MinValue" />, <paramref name="result" /> is <see cref="F:MetersUnit.NegativeInfinity" />. If <paramref name="s" /> is a valid number greater than <see cref="F:MetersUnit.MaxValue" />, <paramref name="result" /> is <see cref="F:MetersUnit.PositiveInfinity" />. This parameter is passed uninitialized; any value originally supplied in <paramref name="result" /> will be overwritten.</param>
    /// <returns>
    ///   <see langword="true" /> if <paramref name="s" /> was converted successfully; otherwise, <see langword="false" />.
    /// </returns>
    public static bool TryParse(ReadOnlySpan<char> s, out double result) => double.TryParse(s, out result);

    /// <summary>
    /// Tries the parse.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="provider">The provider.</param>
    /// <param name="result">The result.</param>
    /// <returns>A bool.</returns>
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out MetersUnit result)
    {
        if (double.TryParse(s, NumberStyles.Float, provider, out var r))
        {
            result = r;
            return true;
        }
        result = default;
        return false;
    }

    /// <summary>
    /// Tries the parse.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="provider">The provider.</param>
    /// <param name="result">The result.</param>
    /// <returns>A bool.</returns>
    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out MetersUnit result)
    {
        if (double.TryParse(s, NumberStyles.Float, provider, out var r))
        {
            result = r;
            return true;
        }
        result = default;
        return false;
    }

    /// <summary>
    /// Converts a character span containing the string representation of a number in a specified style and culture-specific format to its double-precision floating-point number equivalent. A return value indicates whether the conversion succeeded or failed.
    /// </summary>
    /// <param name="s">A read-only character span that contains the number to convert.</param>
    /// <param name="style">A bitwise combination of <see cref="T:System.Globalization.NumberStyles" /> values that indicates the permitted format of <paramref name="s" />. A typical value to specify is <see cref="F:System.Globalization.NumberStyles.Float" /> combined with <see cref="F:System.Globalization.NumberStyles.AllowThousands" />.</param>
    /// <param name="provider">An object that supplies culture-specific formatting information about <paramref name="s" />.</param>
    /// <param name="result">When this method returns and if the conversion succeeded, contains a double-precision floating-point number equivalent of the numeric value or symbol contained in <paramref name="s" />. Contains zero if the conversion failed. The conversion fails if the <paramref name="s" /> parameter is <see langword="null" />, an empty character span, or not a number in a format compliant with <paramref name="style" />. If <paramref name="s" /> is a valid number less than <see cref="F:MetersUnit.MinValue" />, <paramref name="result" /> is <see cref="F:MetersUnit.NegativeInfinity" />. If <paramref name="s" /> is a valid number greater than <see cref="F:MetersUnit.MaxValue" />, <paramref name="result" /> is <see cref="F:MetersUnit.PositiveInfinity" />. This parameter is passed uninitialized; any value originally supplied in <paramref name="result" /> will be overwritten.</param>
    /// <returns>
    ///   <see langword="true" /> if <paramref name="s" /> was converted successfully; otherwise, <see langword="false" />.
    /// </returns>
    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out MetersUnit result)
    {
        if (double.TryParse(s, style, provider, out var r))
        {
            result = r;
            return true;
        }
        result = default;
        return false;
    }

    /// <summary>
    /// Converts the string representation of a number to its double-precision floating-point number equivalent. A return value indicates whether the conversion succeeded or failed.
    /// </summary>
    /// <param name="s">A string containing a number to convert.</param>
    /// <param name="result">When this method returns, contains the double-precision floating-point number equivalent of the <paramref name="s" /> parameter, if the conversion succeeded, or zero if the conversion failed. The conversion fails if the <paramref name="s" /> parameter is <see langword="null" /> or <see cref="F:System.String.Empty" /> or is not a number in a valid format. It also fails on .NET Framework and .NET Core 2.2 and earlier versions if <paramref name="s" /> represents a number less than <see cref="F:MetersUnit.MinValue" /> or greater than <see cref="F:MetersUnit.MaxValue" />. This parameter is passed uninitialized; any value originally supplied in <paramref name="result" /> will be overwritten.</param>
    /// <returns>
    ///   <see langword="true" /> if <paramref name="s" /> was converted successfully; otherwise, <see langword="false" />.
    /// </returns>
    public static bool TryParse([NotNullWhen(true)] string? s, out MetersUnit result)
    {
        if (double.TryParse(s, out var r))
        {
            result = r;
            return true;
        }
        result = default;
        return false;
    }

    /// <summary>
    /// Converts the string representation of a number in a specified style and culture-specific format to its double-precision floating-point number equivalent. A return value indicates whether the conversion succeeded or failed.
    /// </summary>
    /// <param name="s">A string containing a number to convert.</param>
    /// <param name="style">A bitwise combination of <see cref="T:System.Globalization.NumberStyles" /> values that indicates the permitted format of <paramref name="s" />. A typical value to specify is <see cref="F:System.Globalization.NumberStyles.Float" /> combined with <see cref="F:System.Globalization.NumberStyles.AllowThousands" />.</param>
    /// <param name="provider">An <see cref="T:System.IFormatProvider" /> that supplies culture-specific formatting information about <paramref name="s" />.</param>
    /// <param name="result">When this method returns, contains a double-precision floating-point number equivalent of the numeric value or symbol contained in <paramref name="s" />, if the conversion succeeded, or zero if the conversion failed. The conversion fails if the <paramref name="s" /> parameter is <see langword="null" /> or <see cref="F:System.String.Empty" /> or is not in a format compliant with <paramref name="style" />, or if <paramref name="style" /> is not a valid combination of <see cref="T:System.Globalization.NumberStyles" /> enumeration constants. It also fails on .NET Framework or .NET Core 2.2 and earlier versions if <paramref name="s" /> represents a number less than <see cref="F:System.SByte.MinValue" /> or greater than <see cref="F:System.SByte.MaxValue" />. This parameter is passed uninitialized; any value originally supplied in <paramref name="result" /> will be overwritten.</param>
    /// <exception cref="T:System.ArgumentException">
    ///   <paramref name="style" /> is not a <see cref="T:System.Globalization.NumberStyles" /> value.  
    ///  -or-  
    ///  <paramref name="style" /> includes the <see cref="F:System.Globalization.NumberStyles.AllowHexSpecifier" /> value.</exception>
    /// <returns>
    ///   <see langword="true" /> if <paramref name="s" /> was converted successfully; otherwise, <see langword="false" />.
    /// </returns>
    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, out MetersUnit result)
    {
        if (double.TryParse(s, style, provider, out var r))
        {
            result = r;
            return true;
        }
        result = default;
        return false;
    }

    /// <summary>
    /// Are the pow2.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A bool.</returns>
    [RequiresPreviewFeatures]
    public static bool IsPow2(MetersUnit value) => value.Value == Math.Pow(2d, Math.Log(value.Value, 2d));

    /// <summary>
    /// Acos the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit Acos(MetersUnit x) => Math.Acos(x.Value);

    /// <summary>
    /// Acoshes the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit Acosh(MetersUnit x) => Math.Acosh(x.Value);

    /// <summary>
    /// Asins the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit Asin(MetersUnit x) => Math.Asin(x.Value);

    /// <summary>
    /// Asinhs the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit Asinh(MetersUnit x) => Math.Asinh(x.Value);

    /// <summary>
    /// Atans the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit Atan(MetersUnit x) => Math.Atan(x.Value);

    /// <summary>
    /// Atan2S the.
    /// </summary>
    /// <param name="y">The y.</param>
    /// <param name="x">The x.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit Atan2(MetersUnit y, MetersUnit x) => Math.Atan2(y.Value, x.Value);

    /// <summary>
    /// Atanhs the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit Atanh(MetersUnit x) => Math.Atanh(x.Value);

    /// <summary>
    /// Bits the increment.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit BitIncrement(MetersUnit x) => Math.BitIncrement(x.Value);

    /// <summary>
    /// Bits the decrement.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit BitDecrement(MetersUnit x) => Math.BitDecrement(x.Value);

    /// <summary>
    /// Cbrts the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit Cbrt(MetersUnit x) => Math.Cbrt(x.Value);

    /// <summary>
    /// Ceilings the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit Ceiling(MetersUnit x) => Math.Ceiling(x.Value);

    /// <summary>
    /// Copies the sign.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit CopySign(MetersUnit x, MetersUnit y) => Math.CopySign(x.Value, y.Value);

    /// <summary>
    /// Cos the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit Cos(MetersUnit x) => Math.Cos(x.Value);

    /// <summary>
    /// Coshes the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit Cosh(MetersUnit x) => Math.Cosh(x.Value);

    /// <summary>
    /// Exps the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit Exp(MetersUnit x) => Math.Exp(x.Value);

    /// <summary>
    /// Floors the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit Floor(MetersUnit x) => Math.Floor(x.Value);

    /// <summary>
    /// Fuseds the multiply add.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <param name="addend">The addend.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit FusedMultiplyAdd(MetersUnit left, MetersUnit right, MetersUnit addend) => Math.FusedMultiplyAdd(left.Value, right.Value, addend.Value);

    /// <summary>
    /// IS the e e e remainder.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit IEEERemainder(MetersUnit left, MetersUnit right) => Math.IEEERemainder(left.Value, right.Value);

    /// <summary>
    /// Logs the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit Log(MetersUnit x) => Math.Log(x.Value);

    /// <summary>
    /// Logs the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="newBase">The new base.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit Log(MetersUnit x, MetersUnit newBase) => Math.Log(x.Value, newBase.Value);

    /// <summary>
    /// Log2S the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit Log2(MetersUnit x) => Math.Log2(x.Value);

    /// <summary>
    /// Log10S the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit Log10(MetersUnit x) => Math.Log10(x.Value);

    /// <summary>
    /// Maxes the magnitude.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit MaxMagnitude(MetersUnit x, MetersUnit y) => new(Math.MaxMagnitude(x.Value, y.Value));

    /// <summary>
    /// Mins the magnitude.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit MinMagnitude(MetersUnit x, MetersUnit y) => new(Math.MinMagnitude(x.Value, y.Value));

    /// <summary>
    /// Pows the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit Pow(MetersUnit x, MetersUnit y) => Math.Pow(x.Value, y.Value);

    /// <summary>
    /// Rounds the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit Round(MetersUnit x) => Math.Round(x.Value);

    /// <summary>
    /// Rounds the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="mode">The mode.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit Round(MetersUnit x, MidpointRounding mode) => Math.Round(x.Value, mode);

    /// <summary>
    /// Sins the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit Sin(MetersUnit x) => Math.Sin(x.Value);

    /// <summary>
    /// Sinhs the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit Sinh(MetersUnit x) => Math.Sinh(x.Value);

    /// <summary>
    /// Sqrts the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit Sqrt(MetersUnit x) => Math.Sqrt(x.Value);

    /// <summary>
    /// Tans the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit Tan(MetersUnit x) => Math.Tan(x.Value);

    /// <summary>
    /// Tanhs the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit Tanh(MetersUnit x) => Math.Tanh(x.Value);

    /// <summary>
    /// Truncates the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit Truncate(MetersUnit x) => Math.Truncate(x.Value);

    /// <summary>
    /// Abs the.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit Abs(MetersUnit value) => Math.Abs(value.Value);

    /// <summary>
    /// Clamps the.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="min">The min.</param>
    /// <param name="max">The max.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit Clamp(MetersUnit value, MetersUnit min, MetersUnit max) => Math.Clamp(value.Value, min.Value, max.Value);

    /// <summary>
    /// Creates the.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit Create<TOther>(TOther value) where TOther : INumber<TOther> => new(Operations.Cast<TOther, double>(value));

    /// <summary>
    /// Creates the saturating.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit CreateSaturating<TOther>(TOther value) where TOther : INumber<TOther> => new(Operations.CastSaturating<TOther, double>(value));

    /// <summary>
    /// Creates the truncating.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit CreateTruncating<TOther>(TOther value) where TOther : INumber<TOther> => new(Operations.CastTruncating<TOther, double>(value));

    /// <summary>
    /// Divs the rem.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>A (MetersUnit Quotient, MetersUnit Remainder) .</returns>
    [RequiresPreviewFeatures]
    public static (MetersUnit Quotient, MetersUnit Remainder) DivRem(MetersUnit left, MetersUnit right) => DivRem(left.Value, right.Value);

    /// <summary>
    /// Maxes the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit Max(MetersUnit x, MetersUnit y) => Math.Max(x.Value, y.Value);

    /// <summary>
    /// Mins the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit Min(MetersUnit x, MetersUnit y) => Math.Min(x.Value, y.Value);

    /// <summary>
    /// Signs the.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A MetersUnit.</returns>
    [RequiresPreviewFeatures]
    public static MetersUnit Sign(MetersUnit value) => Math.Sign(value.Value);

    /// <summary>
    /// Compares the to.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>An int.</returns>
    public int CompareTo(MetersUnit other) => Value.CompareTo(other.Value);

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>A bool.</returns>
    public bool Equals(MetersUnit other) => Value.Equals(other.Value);

    /// <summary>
    /// IS the log b.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A TInteger.</returns>
    public static TInteger ILogB<TInteger>(MetersUnit x) where TInteger : IBinaryInteger<TInteger> => Operations.Cast<int, TInteger>(Math.ILogB(x.Value)) ?? TInteger.Zero;

    /// <summary>
    /// Tries the create.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="result">The result.</param>
    /// <returns>A bool.</returns>
    public static bool TryCreate<TOther>(TOther value, out MetersUnit result) where TOther : INumber<TOther>
    {
        result = new(Operations.Cast<TOther, double>(value));
        return true;
    }

    /// <summary>
    /// Rounds the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="digits">The digits.</param>
    /// <returns>A MetersUnit.</returns>
    public static MetersUnit Round<TInteger>(MetersUnit x, TInteger digits) where TInteger : IBinaryInteger<TInteger> => Math.Round(x.Value, Operations.Cast<TInteger, int>(digits));

    /// <summary>
    /// Rounds the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="digits">The digits.</param>
    /// <param name="mode">The mode.</param>
    /// <returns>A MetersUnit.</returns>
    public static MetersUnit Round<TInteger>(MetersUnit x, TInteger digits, MidpointRounding mode) where TInteger : IBinaryInteger<TInteger> => Math.Round(x.Value, Operations.Cast<TInteger, int>(digits), mode);

    /// <summary>
    /// Scales the b.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="n">The n.</param>
    /// <returns>A MetersUnit.</returns>
    public static MetersUnit ScaleB<TInteger>(MetersUnit x, TInteger n) where TInteger : IBinaryInteger<TInteger> => Math.ScaleB(x.Value, Operations.Cast<TInteger, int>(n));

    /// <summary>
    /// Ieee754S the remainder.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>A MetersUnit.</returns>
    public static MetersUnit Ieee754Remainder(MetersUnit left, MetersUnit right) => Math.IEEERemainder(left.Value, right.Value);

    /// <summary>
    /// IS the log b.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>An int.</returns>
    public static int ILogB(MetersUnit x) => Math.ILogB(x.Value);

    /// <summary>
    /// Reciprocals the estimate.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A MetersUnit.</returns>
    public static MetersUnit ReciprocalEstimate(MetersUnit x) => Math.ReciprocalEstimate(x.Value);

    /// <summary>
    /// Reciprocals the sqrt estimate.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A MetersUnit.</returns>
    public static MetersUnit ReciprocalSqrtEstimate(MetersUnit x) => Math.ReciprocalSqrtEstimate(x.Value);

    /// <summary>
    /// Scales the b.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="n">The n.</param>
    /// <returns>A MetersUnit.</returns>
    public static MetersUnit ScaleB(MetersUnit x, int n) => Math.ScaleB(x.Value, n);

    /// <summary>
    /// Gets the exponent byte count.
    /// </summary>
    /// <returns>An int.</returns>
    public int GetExponentByteCount()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets the exponent shortest bit length.
    /// </summary>
    /// <returns>A long.</returns>
    public long GetExponentShortestBitLength()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets the significand byte count.
    /// </summary>
    /// <returns>An int.</returns>
    public int GetSignificandByteCount()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets the significand bit length.
    /// </summary>
    /// <returns>A long.</returns>
    public long GetSignificandBitLength()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Rounds the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="digits">The digits.</param>
    /// <returns>A MetersUnit.</returns>
    public static MetersUnit Round(MetersUnit x, int digits) => Math.Round(x.Value, digits);

    /// <summary>
    /// Rounds the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="digits">The digits.</param>
    /// <param name="mode">The mode.</param>
    /// <returns>A MetersUnit.</returns>
    public static MetersUnit Round(MetersUnit x, int digits, MidpointRounding mode) => Math.Round(x.Value, digits, mode);

    /// <summary>
    /// Tries the write exponent little endian.
    /// </summary>
    /// <param name="destination">The destination.</param>
    /// <param name="bytesWritten">The bytes written.</param>
    /// <returns>A bool.</returns>
    public bool TryWriteExponentLittleEndian(Span<byte> destination, out int bytesWritten)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Tries the write significand little endian.
    /// </summary>
    /// <param name="destination">The destination.</param>
    /// <param name="bytesWritten">The bytes written.</param>
    /// <returns>A bool.</returns>
    public bool TryWriteSignificandLittleEndian(Span<byte> destination, out int bytesWritten)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Creates the checked.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A MetersUnit.</returns>
    public static MetersUnit CreateChecked<TOther>(TOther value) where TOther : INumber<TOther> => new(Operations.Cast<TOther, double>(value));

    /// <summary>
    /// Signs the.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>An int.</returns>
    static int INumber<MetersUnit>.Sign(MetersUnit value) => Math.Sign(value.Value);

    /// <summary>
    /// Sins the cos.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A (MetersUnit Sin, MetersUnit Cos) .</returns>
    public static (MetersUnit Sin, MetersUnit Cos) SinCos(MetersUnit x) => Math.SinCos(x.Value);
}
