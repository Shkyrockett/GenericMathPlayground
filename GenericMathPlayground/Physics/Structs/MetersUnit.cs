// <copyright file="MetersUnit.cs" company="Shkyrockett" >
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
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.Versioning;

namespace GenericMathPlayground.Physics
{
    /// <summary>
    /// 
    /// </summary>
    public readonly struct MetersUnit
        : IComparable,
        IComparable<MetersUnit>,
        IConvertible,
        IEquatable<MetersUnit>,
        ISpanFormattable,
        IFormattable,
        IBinaryFloatingPoint<MetersUnit>,
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
        IParseable<MetersUnit>,
        ISpanParseable<MetersUnit>,
        ISubtractionOperators<MetersUnit, MetersUnit, MetersUnit>,
        IUnaryNegationOperators<MetersUnit, MetersUnit>,
        IUnaryPlusOperators<MetersUnit, MetersUnit>,
        IFloatingPoint<MetersUnit>,
        ISignedNumber<MetersUnit>,
        IMinMaxValue<MetersUnit>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly double value;

        /// <summary>
        /// 
        /// </summary>
        [RequiresPreviewFeatures]
        public static MetersUnit AdditiveIdentity => Zero;

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        [RequiresPreviewFeatures]
        public static MetersUnit NegativeZero => -0d;

        /// <summary>
        /// 
        /// </summary>
        [RequiresPreviewFeatures]
        public static MetersUnit Pi => Math.PI;

        /// <summary>
        /// Represents positive infinity. This field is constant.
        /// </summary>
        [RequiresPreviewFeatures]
        public static MetersUnit PositiveInfinity => double.PositiveInfinity;

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        [RequiresPreviewFeatures]
        public static MetersUnit One => 1d;

        /// <summary>
        /// 
        /// </summary>
        [RequiresPreviewFeatures]
        public static MetersUnit Zero => 0d;

        /// <summary>
        /// 
        /// </summary>
        [RequiresPreviewFeatures]
        public static MetersUnit MultiplicativeIdentity => One;

        /// <summary>
        /// 
        /// </summary>
        [RequiresPreviewFeatures]
        public static MetersUnit NegativeOne => -1d;

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        public MetersUnit(double v) : this() => value = v;
        #endregion

        #region OPerators
        /// <summary>
        /// Returns a value that indicates whether two specified <see cref="MetersUnit" /> values are equal.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>
        ///   <see langword="true" /> if <paramref name="left" /> and <paramref name="right" /> are equal; otherwise, <see langword="false" />.
        /// </returns>
        public static bool operator ==(MetersUnit left, MetersUnit right) => left.value == right.value;

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
        public static bool operator >(MetersUnit left, MetersUnit right) => left.value > right.value;

        /// <summary>
        /// Returns a value that indicates whether a specified <see cref="MetersUnit" /> value is greater than or equal to another specified <see cref="MetersUnit" /> value.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>
        ///   <see langword="true" /> if <paramref name="left" /> is greater than or equal to <paramref name="right" />; otherwise, <see langword="false" />.
        /// </returns>
        public static bool operator >=(MetersUnit left, MetersUnit right) => left.value >= right.value;

        /// <summary>
        /// Returns a value that indicates whether a specified <see cref="MetersUnit" /> value is less than another specified <see cref="MetersUnit" /> value.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>
        ///   <see langword="true" /> if <paramref name="left" /> is less than <paramref name="right" />; otherwise, <see langword="false" />.
        /// </returns>
        public static bool operator <(MetersUnit left, MetersUnit right) => left.value < right.value;

        /// <summary>
        /// Returns a value that indicates whether a specified <see cref="MetersUnit" /> value is less than or equal to another specified <see cref="MetersUnit" /> value.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>
        ///   <see langword="true" /> if <paramref name="left" /> is less than or equal to <paramref name="right" />; otherwise, <see langword="false" />.
        /// </returns>
        public static bool operator <=(MetersUnit left, MetersUnit right) => left.value <= right.value;

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
        public static MetersUnit operator -(MetersUnit value) => new(-value.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static MetersUnit operator --(MetersUnit value) => new(value.value - One.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static MetersUnit operator -(MetersUnit left, MetersUnit right) => new(left.value - right.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static MetersUnit operator +(MetersUnit value) => new(+value.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static MetersUnit operator ++(MetersUnit value) => new(value.value + One.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static MetersUnit operator +(MetersUnit left, MetersUnit right) => new(left.value + right.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static MetersUnit operator /(MetersUnit left, MetersUnit right) => new(left.value / right.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static MetersUnit operator %(MetersUnit left, MetersUnit right) => new(left.value % right.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static MetersUnit operator *(MetersUnit left, MetersUnit right) => new(left.value * right.value);

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
        public int CompareTo(double value) => this.value.CompareTo(value);

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
        public int CompareTo(object? value) => this.value.CompareTo(value);

        /// <summary>
        /// Returns a value indicating whether this instance and a specified <see cref="MetersUnit" /> object represent the same value.
        /// </summary>
        /// <param name="obj">A <see cref="MetersUnit" /> object to compare to this instance.</param>
        /// <returns>
        ///   <see langword="true" /> if <paramref name="obj" /> is equal to this instance; otherwise, <see langword="false" />.
        /// </returns>
        public bool Equals(double obj) => value.Equals(obj);

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        ///   <see langword="true" /> if <paramref name="obj" /> is an instance of <see cref="MetersUnit" /> and equals the value of this instance; otherwise, <see langword="false" />.
        /// </returns>
        public override bool Equals([NotNullWhen(true)] object? obj) => value.Equals(obj);

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode() => value.GetHashCode();

        /// <summary>
        /// Returns the <see cref="T:System.TypeCode" /> for value type <see cref="MetersUnit" />.
        /// </summary>
        /// <returns>
        /// The enumerated constant, <see cref="F:System.TypeCode.MetersUnit" />.
        /// </returns>
        public TypeCode GetTypeCode() => value.GetTypeCode();

        /// <summary>
        /// Determines whether the specified value is finite (zero, subnormal, or normal).
        /// </summary>
        /// <param name="d">A double-precision floating-point number.</param>
        /// <returns>
        ///   <see langword="true" /> if the value is finite (zero, subnormal or normal); <see langword="false" /> otherwise.
        /// </returns>
        public static bool IsFinite(MetersUnit d) => double.IsFinite(d.value);

        /// <summary>
        /// Returns a value indicating whether the specified number evaluates to negative or positive infinity.
        /// </summary>
        /// <param name="d">A double-precision floating-point number.</param>
        /// <returns>
        ///   <see langword="true" /> if <paramref name="d" /> evaluates to <see cref="F:MetersUnit.PositiveInfinity" /> or <see cref="F:MetersUnit.NegativeInfinity" />; otherwise, <see langword="false" />.
        /// </returns>
        public static bool IsInfinity(MetersUnit d) => double.IsInfinity(d.value);

        /// <summary>
        /// Returns a value that indicates whether the specified value is not a number (<see cref="F:MetersUnit.NaN" />).
        /// </summary>
        /// <param name="d">A double-precision floating-point number.</param>
        /// <returns>
        ///   <see langword="true" /> if <paramref name="d" /> evaluates to <see cref="F:MetersUnit.NaN" />; otherwise, <see langword="false" />.
        /// </returns>
        public static bool IsNaN(MetersUnit d) => double.IsNaN(d.value);

        /// <summary>
        /// Determines whether the specified value is negative.
        /// </summary>
        /// <param name="d">A double-precision floating-point number.</param>
        /// <returns>
        ///   <see langword="true" /> if the value is negative; <see langword="false" /> otherwise.
        /// </returns>
        public static bool IsNegative(MetersUnit d) => double.IsNegative(d.value);

        /// <summary>
        /// Returns a value indicating whether the specified number evaluates to negative infinity.
        /// </summary>
        /// <param name="d">A double-precision floating-point number.</param>
        /// <returns>
        ///   <see langword="true" /> if <paramref name="d" /> evaluates to <see cref="F:MetersUnit.NegativeInfinity" />; otherwise, <see langword="false" />.
        /// </returns>
        public static bool IsNegativeInfinity(MetersUnit d) => double.IsNegativeInfinity(d.value);

        /// <summary>
        /// Determines whether the specified value is normal.
        /// </summary>
        /// <param name="d">A double-precision floating-point number.</param>
        /// <returns>
        ///   <see langword="true" /> if the value is normal; <see langword="false" /> otherwise.
        /// </returns>
        public static bool IsNormal(MetersUnit d) => double.IsNormal(d.value);

        /// <summary>
        /// Returns a value indicating whether the specified number evaluates to positive infinity.
        /// </summary>
        /// <param name="d">A double-precision floating-point number.</param>
        /// <returns>
        ///   <see langword="true" /> if <paramref name="d" /> evaluates to <see cref="F:MetersUnit.PositiveInfinity" />; otherwise, <see langword="false" />.
        /// </returns>
        public static bool IsPositiveInfinity(MetersUnit d) => double.IsPositiveInfinity(d.value);

        /// <summary>
        /// Determines whether the specified value is subnormal.
        /// </summary>
        /// <param name="d">A double-precision floating-point number.</param>
        /// <returns>
        ///   <see langword="true" /> if the value is subnormal; <see langword="false" /> otherwise.
        /// </returns>
        public static bool IsSubnormal(MetersUnit d) => double.IsSubnormal(d.value);

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
        bool IConvertible.ToBoolean(IFormatProvider? provider) => Convert.ToBoolean(value, provider);

        /// <summary>
        /// For a description of this member, see <see cref="M:System.IConvertible.ToByte(System.IFormatProvider)" />.
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>
        /// The value of the current instance, converted to a <see cref="T:System.Byte" />.
        /// </returns>
        byte IConvertible.ToByte(IFormatProvider? provider) => Convert.ToByte(value, provider);

        /// <summary>
        /// This conversion is not supported. Attempting to use this method throws an <see cref="T:System.InvalidCastException" />.
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <exception cref="T:System.InvalidCastException">In all cases.</exception>
        /// <returns>
        /// This conversion is not supported. No value is returned.
        /// </returns>
        char IConvertible.ToChar(IFormatProvider? provider) => Convert.ToChar(value, provider);

        /// <summary>
        /// This conversion is not supported. Attempting to use this method throws an <see cref="T:System.InvalidCastException" />
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <exception cref="T:System.InvalidCastException">In all cases.</exception>
        /// <returns>
        /// This conversion is not supported. No value is returned.
        /// </returns>
        DateTime IConvertible.ToDateTime(IFormatProvider? provider) => Convert.ToDateTime(value, provider);

        /// <summary>
        /// For a description of this member, see <see cref="M:System.IConvertible.ToDecimal(System.IFormatProvider)" />.
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>
        /// The value of the current instance, converted to a <see cref="T:System.Decimal" />.
        /// </returns>
        decimal IConvertible.ToDecimal(IFormatProvider? provider) => Convert.ToInt16(value, provider);

        /// <summary>
        /// For a description of this member, see <see cref="M:System.IConvertible.ToDouble(System.IFormatProvider)" />.
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>
        /// The value of the current instance, unchanged.
        /// </returns>
        double IConvertible.ToDouble(IFormatProvider? provider) => value;

        /// <summary>
        /// For a description of this member, see <see cref="M:System.IConvertible.ToInt16(System.IFormatProvider)" />.
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>
        /// The value of the current instance, converted to an <see cref="T:System.Int16" />.
        /// </returns>
        short IConvertible.ToInt16(IFormatProvider? provider) => Convert.ToInt16(value, provider);

        /// <summary>
        /// For a description of this member, see <see cref="M:System.IConvertible.ToInt32(System.IFormatProvider)" />.
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>
        /// The value of the current instance, converted to an <see cref="T:System.Int32" />.
        /// </returns>
        int IConvertible.ToInt32(IFormatProvider? provider) => Convert.ToInt32(value, provider);

        /// <summary>
        /// For a description of this member, see <see cref="M:System.IConvertible.ToInt64(System.IFormatProvider)" />.
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>The value of the current instance, converted to an <see cref="T:System.Int64" />.</returns>
        long IConvertible.ToInt64(IFormatProvider? provider) => Convert.ToInt64(value, provider);

        /// <summary>
        /// For a description of this member, see <see cref="M:System.IConvertible.ToSByte(System.IFormatProvider)" />.
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>The value of the current instance, converted to an <see cref="T:System.SByte" />.</returns>
        sbyte IConvertible.ToSByte(IFormatProvider? provider) => Convert.ToSByte(value, provider);

        /// <summary>
        /// For a description of this member, see <see cref="M:System.IConvertible.ToSingle(System.IFormatProvider)" />.
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>
        /// The value of the current instance, converted to a <see cref="T:System.Single" />.
        /// </returns>
        float IConvertible.ToSingle(IFormatProvider? provider) => Convert.ToSingle(value, provider);

        /// <summary>
        /// For a description of this member, see <see cref="M:System.IConvertible.ToType(System.Type,System.IFormatProvider)" />.
        /// </summary>
        /// <param name="type">The type to which to convert this <see cref="MetersUnit" /> value.</param>
        /// <param name="provider">An <see cref="T:System.IFormatProvider" /> implementation that supplies culture-specific information about the format of the returned value.</param>
        /// <returns>
        /// The value of the current instance, converted to <paramref name="type" />.
        /// </returns>
        object IConvertible.ToType(Type type, IFormatProvider? provider) => Convert.ChangeType(value, type, provider);

        /// <summary>
        /// For a description of this member, see <see cref="M:System.IConvertible.ToUInt16(System.IFormatProvider)" />.
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>
        /// The value of the current instance, converted to a <see cref="T:System.UInt16" />.
        /// </returns>
        ushort IConvertible.ToUInt16(IFormatProvider? provider) => Convert.ToUInt16(value, provider);

        /// <summary>
        /// For a description of this member, see <see cref="M:System.IConvertible.ToUInt32(System.IFormatProvider)" />.
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>
        /// The value of the current instance, converted to a <see cref="T:System.UInt32" />.
        /// </returns>
        uint IConvertible.ToUInt32(IFormatProvider? provider) => Convert.ToUInt32(value, provider);

        /// <summary>
        /// For a description of this member, see <see cref="M:System.IConvertible.ToUInt64(System.IFormatProvider)" />.
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>
        /// The value of the current instance, converted to a <see cref="T:System.UInt64" />.
        /// </returns>
        ulong IConvertible.ToUInt64(IFormatProvider? provider) => Convert.ToUInt64(value, provider);

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation.
        /// </summary>
        /// <returns>
        /// The string representation of the value of this instance.
        /// </returns>
        public override string ToString() => ToString(null, null);

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation using the specified culture-specific format information.
        /// </summary>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>
        /// The string representation of the value of this instance as specified by <paramref name="provider" />.
        /// </returns>
        public string ToString(IFormatProvider? provider) => ToString(null, provider);

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation, using the specified format.
        /// </summary>
        /// <param name="format">A numeric format string.</param>
        /// <exception cref="T:System.FormatException">
        ///   <paramref name="format" /> is invalid.</exception>
        /// <returns>
        /// The string representation of the value of this instance as specified by <paramref name="format" />.
        /// </returns>
        public string ToString(string? format) => ToString(format);

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation using the specified format and culture-specific format information.
        /// </summary>
        /// <param name="format">A numeric format string.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>
        /// The string representation of the value of this instance as specified by <paramref name="format" /> and <paramref name="provider" />.
        /// </returns>
        public string ToString(string? format, IFormatProvider? provider) => $"{value.ToString(format, provider)} m";

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
        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider? provider = null) => value.TryFormat(destination, out charsWritten, format, provider);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="provider"></param>
        /// <param name="result"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="provider"></param>
        /// <param name="result"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static bool IsPow2(MetersUnit value) => value.value == Math.Pow(2d, Math.Log(value.value, 2d));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit Acos(MetersUnit x) => Math.Acos(x.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit Acosh(MetersUnit x) => Math.Acosh(x.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit Asin(MetersUnit x) => Math.Asin(x.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit Asinh(MetersUnit x) => Math.Asinh(x.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit Atan(MetersUnit x) => Math.Atan(x.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit Atan2(MetersUnit y, MetersUnit x) => Math.Atan2(y.value, x.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit Atanh(MetersUnit x) => Math.Atanh(x.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit BitIncrement(MetersUnit x) => Math.BitIncrement(x.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit BitDecrement(MetersUnit x) => Math.BitDecrement(x.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit Cbrt(MetersUnit x) => Math.Cbrt(x.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit Ceiling(MetersUnit x) => Math.Ceiling(x.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit CopySign(MetersUnit x, MetersUnit y) => Math.CopySign(x.value, y.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit Cos(MetersUnit x) => Math.Cos(x.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit Cosh(MetersUnit x) => Math.Cosh(x.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit Exp(MetersUnit x) => Math.Exp(x.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit Floor(MetersUnit x) => Math.Floor(x.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="addend"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit FusedMultiplyAdd(MetersUnit left, MetersUnit right, MetersUnit addend) => Math.FusedMultiplyAdd(left.value, right.value, addend.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit IEEERemainder(MetersUnit left, MetersUnit right) => Math.IEEERemainder(left.value, right.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit Log(MetersUnit x) => Math.Log(x.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="newBase"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit Log(MetersUnit x, MetersUnit newBase) => Math.Log(x.value, newBase.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit Log2(MetersUnit x) => Math.Log2(x.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit Log10(MetersUnit x) => Math.Log10(x.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit MaxMagnitude(MetersUnit x, MetersUnit y) => new(Math.MaxMagnitude(x.value, y.value));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit MinMagnitude(MetersUnit x, MetersUnit y) => new(Math.MinMagnitude(x.value, y.value));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit Pow(MetersUnit x, MetersUnit y) => Math.Pow(x.value, y.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit Round(MetersUnit x) => Math.Round(x.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit Round(MetersUnit x, MidpointRounding mode) => Math.Round(x.value, mode);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit Sin(MetersUnit x) => Math.Sin(x.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit Sinh(MetersUnit x) => Math.Sinh(x.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit Sqrt(MetersUnit x) => Math.Sqrt(x.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit Tan(MetersUnit x) => Math.Tan(x.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit Tanh(MetersUnit x) => Math.Tanh(x.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit Truncate(MetersUnit x) => Math.Truncate(x.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit Abs(MetersUnit value) => Math.Abs(value.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit Clamp(MetersUnit value, MetersUnit min, MetersUnit max) => Math.Clamp(value.value, min.value, max.value);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TOther"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit Create<TOther>(TOther value) where TOther : INumber<TOther> => new(Operations.Cast<TOther, double>(value));

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TOther"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit CreateSaturating<TOther>(TOther value) where TOther : INumber<TOther> => new(Operations.CastSaturating<TOther, double>(value));

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TOther"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit CreateTruncating<TOther>(TOther value) where TOther : INumber<TOther> => new(Operations.CastTruncating<TOther, double>(value));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static (MetersUnit Quotient, MetersUnit Remainder) DivRem(MetersUnit left, MetersUnit right) => DivRem(left.value, right.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit Max(MetersUnit x, MetersUnit y) => Math.Max(x.value, y.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit Min(MetersUnit x, MetersUnit y) => Math.Min(x.value, y.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static MetersUnit Sign(MetersUnit value) => Math.Sign(value.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(MetersUnit other) => value.CompareTo(other.value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(MetersUnit other) => value.Equals(other.value);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TInteger"></typeparam>
        /// <param name="x"></param>
        /// <returns></returns>
        public static TInteger ILogB<TInteger>(MetersUnit x) where TInteger : IBinaryInteger<TInteger> => Operations.Cast<int, TInteger>(Math.ILogB(x.value)) ?? TInteger.Zero;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TOther"></typeparam>
        /// <param name="value"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool TryCreate<TOther>(TOther value, out MetersUnit result) where TOther : INumber<TOther>
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
        public static MetersUnit Round<TInteger>(MetersUnit x, TInteger digits) where TInteger : IBinaryInteger<TInteger> => Math.Round(x.value, Operations.Cast<TInteger, int>(digits));

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TInteger"></typeparam>
        /// <param name="x"></param>
        /// <param name="digits"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static MetersUnit Round<TInteger>(MetersUnit x, TInteger digits, MidpointRounding mode) where TInteger : IBinaryInteger<TInteger> => Math.Round(x.value, Operations.Cast<TInteger, int>(digits), mode);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TInteger"></typeparam>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static MetersUnit ScaleB<TInteger>(MetersUnit x, TInteger n) where TInteger : IBinaryInteger<TInteger> => Math.ScaleB(x.value, Operations.Cast<TInteger, int>(n));
    }
}