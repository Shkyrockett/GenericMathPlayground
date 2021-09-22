// <copyright file="FeetUnit.cs" company="Shkyrockett" >
//     Copyright © 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using GenericMathPlayground.Mathematics;
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.Versioning;

namespace GenericMathPlayground.Physics
{
    /// <summary>
    /// 
    /// </summary>
    [TypeConverter(typeof(LengthUnitConverter<FeetUnit>))]
    public readonly struct FeetUnit
        : ILengthUnit,
        IComparable,
        IComparable<FeetUnit>,
        IConvertible,
        IEquatable<FeetUnit>,
        ISpanFormattable,
        IFormattable,
        IBinaryFloatingPoint<FeetUnit>,
        IBinaryNumber<FeetUnit>,
        IBitwiseOperators<FeetUnit, FeetUnit, FeetUnit>,
        INumber<FeetUnit>,
        IAdditionOperators<FeetUnit, FeetUnit, FeetUnit>,
        IAdditiveIdentity<FeetUnit, FeetUnit>,
        IComparisonOperators<FeetUnit, FeetUnit>,
        IEqualityOperators<FeetUnit, FeetUnit>,
        IDecrementOperators<FeetUnit>,
        IDivisionOperators<FeetUnit, FeetUnit, FeetUnit>,
        IIncrementOperators<FeetUnit>,
        IModulusOperators<FeetUnit, FeetUnit, FeetUnit>,
        IMultiplicativeIdentity<FeetUnit, FeetUnit>,
        IMultiplyOperators<FeetUnit, FeetUnit, FeetUnit>,
        IParseable<FeetUnit>,
        ISpanParseable<FeetUnit>,
        ISubtractionOperators<FeetUnit, FeetUnit, FeetUnit>,
        IUnaryNegationOperators<FeetUnit, FeetUnit>,
        IUnaryPlusOperators<FeetUnit, FeetUnit>,
        IFloatingPoint<FeetUnit>,
        ISignedNumber<FeetUnit>,
        IMinMaxValue<FeetUnit>
    {
        #region Abstract Properties
        /// <summary>
        /// 
        /// </summary>
        [RequiresPreviewFeatures]
        public static FeetUnit AdditiveIdentity => Zero;

        /// <summary>
        /// 
        /// </summary>
        [RequiresPreviewFeatures]
        public static FeetUnit E => Math.E;

        /// <summary>
        /// Represents the smallest positive <see cref="FeetUnit" /> value that is greater than zero. This field is constant.
        /// </summary>
        [RequiresPreviewFeatures]
        public static FeetUnit Epsilon => double.Epsilon;

        /// <summary>
        /// Represents a value that is not a number (<see langword="NaN" />). This field is constant.
        /// </summary>
        [RequiresPreviewFeatures]
        public static FeetUnit NaN => double.NaN;

        /// <summary>
        /// Represents negative infinity. This field is constant.
        /// </summary>
        [RequiresPreviewFeatures]
        public static FeetUnit NegativeInfinity => double.NegativeInfinity;

        /// <summary>
        /// 
        /// </summary>
        [RequiresPreviewFeatures]
        public static FeetUnit NegativeZero => -0d;

        /// <summary>
        /// 
        /// </summary>
        [RequiresPreviewFeatures]
        public static FeetUnit Pi => Math.PI;

        /// <summary>
        /// Represents positive infinity. This field is constant.
        /// </summary>
        [RequiresPreviewFeatures]
        public static FeetUnit PositiveInfinity => double.PositiveInfinity;

        /// <summary>
        /// 
        /// </summary>
        [RequiresPreviewFeatures]
        public static FeetUnit Tau => Math.Tau;

        /// <summary>
        /// Represents the smallest possible value of a <see cref="FeetUnit" />. This field is constant.
        /// </summary>
        [RequiresPreviewFeatures]
        public static FeetUnit MinValue => double.MinValue;

        /// <summary>
        /// Represents the largest possible value of a <see cref="FeetUnit" />. This field is constant.
        /// </summary>
        [RequiresPreviewFeatures]
        public static FeetUnit MaxValue => double.MaxValue;

        /// <summary>
        /// 
        /// </summary>
        [RequiresPreviewFeatures]
        public static FeetUnit One => 1d;

        /// <summary>
        /// 
        /// </summary>
        [RequiresPreviewFeatures]
        public static FeetUnit Zero => 0d;

        /// <summary>
        /// 
        /// </summary>
        [RequiresPreviewFeatures]
        public static FeetUnit MultiplicativeIdentity => One;

        /// <summary>
        /// 
        /// </summary>
        [RequiresPreviewFeatures]
        public static FeetUnit NegativeOne => -1d;

        /// <summary>
        /// 
        /// </summary>
        [RequiresPreviewFeatures]
        public static double InMeters => 0.3048d;
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        public FeetUnit(double v) : this() => Value = v;
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public double Value { get; }
        #endregion

        #region OPerators
        /// <summary>
        /// Returns a value that indicates whether two specified <see cref="FeetUnit" /> values are equal.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>
        ///   <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are equal; otherwise, <see langword="false" />.
        /// </returns>
        public static bool operator ==(FeetUnit left, FeetUnit right) => left.Value == right.Value;

        /// <summary>
        /// Returns a value that indicates whether two specified <see cref="FeetUnit" /> values are not equal.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>
        ///   <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are not equal; otherwise, <see langword="false" />.
        /// </returns>
        public static bool operator !=(FeetUnit left, FeetUnit right) => !(left == right);

        /// <summary>
        /// Returns a value that indicates whether a specified <see cref="FeetUnit" /> value is greater than another specified <see cref="FeetUnit" /> value.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>
        ///   <see langword="true" /> if <paramref name="left" /> is greater than <paramref name="right" />; otherwise, <see langword="false" />.
        /// </returns>
        public static bool operator >(FeetUnit left, FeetUnit right) => left.Value > right.Value;

        /// <summary>
        /// Returns a value that indicates whether a specified <see cref="FeetUnit" /> value is greater than or equal to another specified <see cref="FeetUnit" /> value.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>
        ///   <see langword="true" /> if <paramref name="left" /> is greater than or equal to <paramref name="right" />; otherwise, <see langword="false" />.
        /// </returns>
        public static bool operator >=(FeetUnit left, FeetUnit right) => left.Value >= right.Value;

        /// <summary>
        /// Returns a value that indicates whether a specified <see cref="FeetUnit" /> value is less than another specified <see cref="FeetUnit" /> value.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>
        ///   <see langword="true" /> if <paramref name="left" /> is less than <paramref name="right" />; otherwise, <see langword="false" />.
        /// </returns>
        public static bool operator <(FeetUnit left, FeetUnit right) => left.Value < right.Value;

        /// <summary>
        /// Returns a value that indicates whether a specified <see cref="FeetUnit" /> value is less than or equal to another specified <see cref="FeetUnit" /> value.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>
        ///   <see langword="true" /> if <paramref name="left" /> is less than or equal to <paramref name="right" />; otherwise, <see langword="false" />.
        /// </returns>
        public static bool operator <=(FeetUnit left, FeetUnit right) => left.Value <= right.Value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static FeetUnit operator &(FeetUnit left, FeetUnit right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static FeetUnit operator |(FeetUnit left, FeetUnit right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static FeetUnit operator ^(FeetUnit left, FeetUnit right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static FeetUnit operator ~(FeetUnit value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static FeetUnit operator -(FeetUnit value) => new(-value.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static FeetUnit operator --(FeetUnit value) => new(value.Value - One.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static FeetUnit operator -(FeetUnit left, FeetUnit right) => new(left.Value - right.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static FeetUnit operator +(FeetUnit value) => new(+value.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static FeetUnit operator ++(FeetUnit value) => new(value.Value + One.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static FeetUnit operator +(FeetUnit left, FeetUnit right) => new(left.Value + right.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static FeetUnit operator /(FeetUnit left, FeetUnit right) => new(left.Value / right.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static FeetUnit operator %(FeetUnit left, FeetUnit right) => new(left.Value % right.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static FeetUnit operator *(FeetUnit left, FeetUnit right) => new(left.Value * right.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        public static implicit operator FeetUnit(double v) => new(v);
        #endregion

        /// <summary>
        /// Compares this instance to a specified double-precision floating-point number and returns an integer that indicates whether the value of this instance is less than, equal to, or greater than the value of the specified double-precision floating-point number.
        /// </summary>
        /// <param name="value">A double-precision floating-point number to compare.</param>
        /// <returns>
        /// A signed number indicating the relative values of this instance and <paramref name="value" />.  
        /// <list type="table"><listheader><term> Return Value</term><description> Description</description></listheader><item><term> Less than zero</term><description> This instance is less than <paramref name="value" />, or this instance is not a number (<see cref="F:FeetUnit.NaN" />) and <paramref name="value" /> is a number.</description></item><item><term> Zero</term><description> This instance is equal to <paramref name="value" />, or both this instance and <paramref name="value" /> are not a number (<see cref="F:FeetUnit.NaN" />), <see cref="F:FeetUnit.PositiveInfinity" />, or <see cref="F:FeetUnit.NegativeInfinity" />.</description></item><item><term> Greater than zero</term><description> This instance is greater than <paramref name="value" />, or this instance is a number and <paramref name="value" /> is not a number (<see cref="F:FeetUnit.NaN" />).</description></item></list>
        /// </returns>
        public int CompareTo(double value) => Value.CompareTo(value);

        /// <summary>
        /// Compares this instance to a specified object and returns an integer that indicates whether the value of this instance is less than, equal to, or greater than the value of the specified object.
        /// </summary>
        /// <param name="value">An object to compare, or <see langword="null" />.</param>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="value" /> is not a <see cref="FeetUnit" />.</exception>
        /// <returns>
        /// A signed number indicating the relative values of this instance and <paramref name="value" />.  
        /// <list type="table"><listheader><term> Value</term><description> Description</description></listheader><item><term> A negative integer</term><description> This instance is less than <paramref name="value" />, or this instance is not a number (<see cref="F:FeetUnit.NaN" />) and <paramref name="value" /> is a number.</description></item><item><term> Zero</term><description> This instance is equal to <paramref name="value" />, or this instance and <paramref name="value" /> are both <see langword="FeetUnit.NaN" />, <see cref="F:FeetUnit.PositiveInfinity" />, or <see cref="F:FeetUnit.NegativeInfinity" /></description></item><item><term> A positive integer</term><description> This instance is greater than <paramref name="value" />, OR this instance is a number and <paramref name="value" /> is not a number (<see cref="F:FeetUnit.NaN" />), OR <paramref name="value" /> is <see langword="null" />.</description></item></list>
        /// </returns>
        public int CompareTo(object? value) => Value.CompareTo(value);

        /// <summary>
        /// Returns a value indicating whether this instance and a specified <see cref="FeetUnit" /> object represent the same value.
        /// </summary>
        /// <param name="obj">A <see cref="FeetUnit" /> object to compare to this instance.</param>
        /// <returns>
        ///   <see langword="true" /> if <paramref name="obj" /> is equal to this instance; otherwise, <see langword="false" />.
        /// </returns>
        public bool Equals(double obj) => Value.Equals(obj);

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        ///   <see langword="true" /> if <paramref name="obj" /> is an instance of <see cref="FeetUnit" /> and equals the value of this instance; otherwise, <see langword="false" />.
        /// </returns>
        public override bool Equals([NotNullWhen(true)] object? obj) => Value.Equals(obj);

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode() => Value.GetHashCode();

        /// <summary>
        /// Returns the <see cref="T:System.TypeCode" /> for value type <see cref="FeetUnit" />.
        /// </summary>
        /// <returns>
        /// The enumerated constant, <see cref="F:System.TypeCode.FeetUnit" />.
        /// </returns>
        public TypeCode GetTypeCode() => Value.GetTypeCode();

        /// <summary>
        /// Determines whether the specified value is finite (zero, subnormal, or normal).
        /// </summary>
        /// <param name="d">A double-precision floating-point number.</param>
        /// <returns>
        ///   <see langword="true" /> if the value is finite (zero, subnormal or normal); <see langword="false" /> otherwise.
        /// </returns>
        public static bool IsFinite(FeetUnit d) => double.IsFinite(d.Value);

        /// <summary>
        /// Returns a value indicating whether the specified number evaluates to negative or positive infinity.
        /// </summary>
        /// <param name="d">A double-precision floating-point number.</param>
        /// <returns>
        ///   <see langword="true" /> if <paramref name="d" /> evaluates to <see cref="F:FeetUnit.PositiveInfinity" /> or <see cref="F:FeetUnit.NegativeInfinity" />; otherwise, <see langword="false" />.
        /// </returns>
        public static bool IsInfinity(FeetUnit d) => double.IsInfinity(d.Value);

        /// <summary>
        /// Returns a value that indicates whether the specified value is not a number (<see cref="F:FeetUnit.NaN" />).
        /// </summary>
        /// <param name="d">A double-precision floating-point number.</param>
        /// <returns>
        ///   <see langword="true" /> if <paramref name="d" /> evaluates to <see cref="F:FeetUnit.NaN" />; otherwise, <see langword="false" />.
        /// </returns>
        public static bool IsNaN(FeetUnit d) => double.IsNaN(d.Value);

        /// <summary>
        /// Determines whether the specified value is negative.
        /// </summary>
        /// <param name="d">A double-precision floating-point number.</param>
        /// <returns>
        ///   <see langword="true" /> if the value is negative; <see langword="false" /> otherwise.
        /// </returns>
        public static bool IsNegative(FeetUnit d) => double.IsNegative(d.Value);

        /// <summary>
        /// Returns a value indicating whether the specified number evaluates to negative infinity.
        /// </summary>
        /// <param name="d">A double-precision floating-point number.</param>
        /// <returns>
        ///   <see langword="true" /> if <paramref name="d" /> evaluates to <see cref="F:FeetUnit.NegativeInfinity" />; otherwise, <see langword="false" />.
        /// </returns>
        public static bool IsNegativeInfinity(FeetUnit d) => double.IsNegativeInfinity(d.Value);

        /// <summary>
        /// Determines whether the specified value is normal.
        /// </summary>
        /// <param name="d">A double-precision floating-point number.</param>
        /// <returns>
        ///   <see langword="true" /> if the value is normal; <see langword="false" /> otherwise.
        /// </returns>
        public static bool IsNormal(FeetUnit d) => double.IsNormal(d.Value);

        /// <summary>
        /// Returns a value indicating whether the specified number evaluates to positive infinity.
        /// </summary>
        /// <param name="d">A double-precision floating-point number.</param>
        /// <returns>
        ///   <see langword="true" /> if <paramref name="d" /> evaluates to <see cref="F:FeetUnit.PositiveInfinity" />; otherwise, <see langword="false" />.
        /// </returns>
        public static bool IsPositiveInfinity(FeetUnit d) => double.IsPositiveInfinity(d.Value);

        /// <summary>
        /// Determines whether the specified value is subnormal.
        /// </summary>
        /// <param name="d">A double-precision floating-point number.</param>
        /// <returns>
        ///   <see langword="true" /> if the value is subnormal; <see langword="false" /> otherwise.
        /// </returns>
        public static bool IsSubnormal(FeetUnit d) => double.IsSubnormal(d.Value);

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
        public static FeetUnit Parse(ReadOnlySpan<char> s, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands, IFormatProvider? provider = null) => double.Parse(s, style, provider);

        /// <summary>
        /// Converts the string representation of a number to its double-precision floating-point number equivalent.
        /// </summary>
        /// <param name="s">A string that contains a number to convert.</param>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="s" /> is <see langword="null" />.</exception>
        /// <exception cref="T:System.FormatException">
        ///   <paramref name="s" /> does not represent a number in a valid format.</exception>
        /// <exception cref="T:System.OverflowException">
        ///     .NET Framework and .NET Core 2.2 and earlier versions only: <paramref name="s" /> represents a number that is less than <see cref="F:FeetUnit.MinValue" /> or greater than <see cref="F:FeetUnit.MaxValue" />.</exception>
        /// <returns>
        /// A double-precision floating-point number that is equivalent to the numeric value or symbol specified in <paramref name="s" />.
        /// </returns>
        public static FeetUnit Parse(string s) => double.Parse(s);

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
        ///     .NET Framework and .NET Core 2.2 and earlier versions only: <paramref name="s" /> represents a number that is less than <see cref="F:FeetUnit.MinValue" /> or greater than <see cref="F:FeetUnit.MaxValue" />.</exception>
        /// <exception cref="T:System.ArgumentException">
        ///   <paramref name="style" /> is not a <see cref="T:System.Globalization.NumberStyles" /> value.  
        ///  -or-  
        ///  <paramref name="style" /> includes the <see cref="F:System.Globalization.NumberStyles.AllowHexSpecifier" /> value.</exception>
        /// <returns>
        /// A double-precision floating-point number that is equivalent to the numeric value or symbol specified in <paramref name="s" />.
        /// </returns>
        public static FeetUnit Parse(string s, NumberStyles style) => double.Parse(s, style);

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
        ///     .NET Framework and .NET Core 2.2 and earlier versions only: <paramref name="s" /> represents a number that is less than <see cref="F:FeetUnit.MinValue" /> or greater than <see cref="F:FeetUnit.MaxValue" />.</exception>
        /// <returns>
        /// A double-precision floating-point number that is equivalent to the numeric value or symbol specified in <paramref name="s" />.
        /// </returns>
        public static FeetUnit Parse(string s, NumberStyles style, IFormatProvider? provider) => double.Parse(s, style, provider);

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
        ///     .NET Framework and .NET Core 2.2 and earlier versions only: <paramref name="s" /> represents a number that is less than <see cref="F:FeetUnit.MinValue" /> or greater than <see cref="F:FeetUnit.MaxValue" />.</exception>
        /// <returns>
        /// A double-precision floating-point number that is equivalent to the numeric value or symbol specified in <paramref name="s" />.
        /// </returns>
        public static FeetUnit Parse(string s, IFormatProvider? provider) => double.Parse(s, provider);

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
        /// <param name="type">The type to which to convert this <see cref="FeetUnit" /> value.</param>
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
        public string ToString(string? format, IFormatProvider? provider) => $"{Value.ToString(format, provider)} ft";

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
        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider? provider = null) => Value.TryFormat(destination, out charsWritten, format, provider);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static FeetUnit Parse(ReadOnlySpan<char> s, IFormatProvider? provider) => double.Parse(s.ToString(), provider);

        /// <summary>
        /// Converts the span representation of a number in a specified style and culture-specific format to its double-precision floating-point number equivalent. A return value indicates whether the conversion succeeded or failed.
        /// </summary>
        /// <param name="s">A character span that contains the string representation of the number to convert.</param>
        /// <param name="result">When this method returns, contains the double-precision floating-point number equivalent of the numeric value or symbol contained in <paramref name="s" /> parameter, if the conversion succeeded, or zero if the conversion failed. The conversion fails if the <paramref name="s" /> parameter is <see langword="null" /> or empty, or is not in a format compliant with style. The conversion also fails if style is not a valid combination of <see cref="T:System.Globalization.NumberStyles" /> enumerated constants. If <paramref name="s" /> is a valid number less than <see cref="F:FeetUnit.MinValue" />, <paramref name="result" /> is <see cref="F:FeetUnit.NegativeInfinity" />. If <paramref name="s" /> is a valid number greater than <see cref="F:FeetUnit.MaxValue" />, <paramref name="result" /> is <see cref="F:FeetUnit.PositiveInfinity" />. This parameter is passed uninitialized; any value originally supplied in <paramref name="result" /> will be overwritten.</param>
        /// <returns>
        ///   <see langword="true" /> if <paramref name="s" /> was converted successfully; otherwise, <see langword="false" />.
        /// </returns>
        public static bool TryParse(ReadOnlySpan<char> s, out double result) => double.TryParse(s, out result);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="provider"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out FeetUnit result)
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
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="provider"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out FeetUnit result)
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
        /// <param name="result">When this method returns and if the conversion succeeded, contains a double-precision floating-point number equivalent of the numeric value or symbol contained in <paramref name="s" />. Contains zero if the conversion failed. The conversion fails if the <paramref name="s" /> parameter is <see langword="null" />, an empty character span, or not a number in a format compliant with <paramref name="style" />. If <paramref name="s" /> is a valid number less than <see cref="F:FeetUnit.MinValue" />, <paramref name="result" /> is <see cref="F:FeetUnit.NegativeInfinity" />. If <paramref name="s" /> is a valid number greater than <see cref="F:FeetUnit.MaxValue" />, <paramref name="result" /> is <see cref="F:FeetUnit.PositiveInfinity" />. This parameter is passed uninitialized; any value originally supplied in <paramref name="result" /> will be overwritten.</param>
        /// <returns>
        ///   <see langword="true" /> if <paramref name="s" /> was converted successfully; otherwise, <see langword="false" />.
        /// </returns>
        public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out FeetUnit result)
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
        /// <param name="result">When this method returns, contains the double-precision floating-point number equivalent of the <paramref name="s" /> parameter, if the conversion succeeded, or zero if the conversion failed. The conversion fails if the <paramref name="s" /> parameter is <see langword="null" /> or <see cref="F:System.String.Empty" /> or is not a number in a valid format. It also fails on .NET Framework and .NET Core 2.2 and earlier versions if <paramref name="s" /> represents a number less than <see cref="F:FeetUnit.MinValue" /> or greater than <see cref="F:FeetUnit.MaxValue" />. This parameter is passed uninitialized; any value originally supplied in <paramref name="result" /> will be overwritten.</param>
        /// <returns>
        ///   <see langword="true" /> if <paramref name="s" /> was converted successfully; otherwise, <see langword="false" />.
        /// </returns>
        public static bool TryParse([NotNullWhen(true)] string? s, out FeetUnit result)
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
        public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, out FeetUnit result)
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
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static bool IsPow2(FeetUnit value) => value.Value == Math.Pow(2d, Math.Log(value.Value, 2d));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit Acos(FeetUnit x) => Math.Acos(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit Acosh(FeetUnit x) => Math.Acosh(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit Asin(FeetUnit x) => Math.Asin(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit Asinh(FeetUnit x) => Math.Asinh(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit Atan(FeetUnit x) => Math.Atan(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit Atan2(FeetUnit y, FeetUnit x) => Math.Atan2(y.Value, x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit Atanh(FeetUnit x) => Math.Atanh(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit BitIncrement(FeetUnit x) => Math.BitIncrement(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit BitDecrement(FeetUnit x) => Math.BitDecrement(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit Cbrt(FeetUnit x) => Math.Cbrt(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit Ceiling(FeetUnit x) => Math.Ceiling(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit CopySign(FeetUnit x, FeetUnit y) => Math.CopySign(x.Value, y.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit Cos(FeetUnit x) => Math.Cos(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit Cosh(FeetUnit x) => Math.Cosh(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit Exp(FeetUnit x) => Math.Exp(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit Floor(FeetUnit x) => Math.Floor(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="addend"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit FusedMultiplyAdd(FeetUnit left, FeetUnit right, FeetUnit addend) => Math.FusedMultiplyAdd(left.Value, right.Value, addend.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit IEEERemainder(FeetUnit left, FeetUnit right) => Math.IEEERemainder(left.Value, right.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit Log(FeetUnit x) => Math.Log(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="newBase"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit Log(FeetUnit x, FeetUnit newBase) => Math.Log(x.Value, newBase.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit Log2(FeetUnit x) => Math.Log2(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit Log10(FeetUnit x) => Math.Log10(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit MaxMagnitude(FeetUnit x, FeetUnit y) => new(Math.MaxMagnitude(x.Value, y.Value));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit MinMagnitude(FeetUnit x, FeetUnit y) => new(Math.MinMagnitude(x.Value, y.Value));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit Pow(FeetUnit x, FeetUnit y) => Math.Pow(x.Value, y.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit Round(FeetUnit x) => Math.Round(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit Round(FeetUnit x, MidpointRounding mode) => Math.Round(x.Value, mode);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit Sin(FeetUnit x) => Math.Sin(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit Sinh(FeetUnit x) => Math.Sinh(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit Sqrt(FeetUnit x) => Math.Sqrt(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit Tan(FeetUnit x) => Math.Tan(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit Tanh(FeetUnit x) => Math.Tanh(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit Truncate(FeetUnit x) => Math.Truncate(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit Abs(FeetUnit value) => Math.Abs(value.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit Clamp(FeetUnit value, FeetUnit min, FeetUnit max) => Math.Clamp(value.Value, min.Value, max.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TOther"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit Create<TOther>(TOther value) where TOther : INumber<TOther> => new(Operations.Cast<TOther, double>(value));

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TOther"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit CreateSaturating<TOther>(TOther value) where TOther : INumber<TOther> => new(Operations.CastSaturating<TOther, double>(value));

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TOther"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit CreateTruncating<TOther>(TOther value) where TOther : INumber<TOther> => new(Operations.CastTruncating<TOther, double>(value));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static (FeetUnit Quotient, FeetUnit Remainder) DivRem(FeetUnit left, FeetUnit right) => DivRem(left.Value, right.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit Max(FeetUnit x, FeetUnit y) => Math.Max(x.Value, y.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit Min(FeetUnit x, FeetUnit y) => Math.Min(x.Value, y.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static FeetUnit Sign(FeetUnit value) => Math.Sign(value.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(FeetUnit other) => Value.CompareTo(other.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(FeetUnit other) => Value.Equals(other.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TInteger"></typeparam>
        /// <param name="x"></param>
        /// <returns></returns>
        public static TInteger ILogB<TInteger>(FeetUnit x) where TInteger : IBinaryInteger<TInteger> => Operations.Cast<int, TInteger>(Math.ILogB(x.Value)) ?? TInteger.Zero;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TOther"></typeparam>
        /// <param name="value"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool TryCreate<TOther>(TOther value, out FeetUnit result) where TOther : INumber<TOther>
        {
            result = new(Operations.Cast<TOther, double>(value));
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TInteger"></typeparam>
        /// <param name="x"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static FeetUnit Round<TInteger>(FeetUnit x, TInteger digits) where TInteger : IBinaryInteger<TInteger> => Math.Round(x.Value, Operations.Cast<TInteger, int>(digits));

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TInteger"></typeparam>
        /// <param name="x"></param>
        /// <param name="digits"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static FeetUnit Round<TInteger>(FeetUnit x, TInteger digits, MidpointRounding mode) where TInteger : IBinaryInteger<TInteger> => Math.Round(x.Value, Operations.Cast<TInteger, int>(digits), mode);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TInteger"></typeparam>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static FeetUnit ScaleB<TInteger>(FeetUnit x, TInteger n) where TInteger : IBinaryInteger<TInteger> => Math.ScaleB(x.Value, Operations.Cast<TInteger, int>(n));
    }
}