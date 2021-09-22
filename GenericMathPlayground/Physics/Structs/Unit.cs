// <copyright file="Unit.cs" company="Shkyrockett" >
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
    /// Represents a double-precision floating-point number in a Unit wrapper.
    /// </summary>
    [TypeConverter(typeof(LengthUnitConverter<Unit>))]
    public readonly struct Unit
        : ILengthUnit,
         IComparable,
        IComparable<Unit>,
        IConvertible,
        IEquatable<Unit>,
        ISpanFormattable,
        IFormattable,
        IBinaryFloatingPoint<Unit>,
        IBinaryNumber<Unit>,
        IBitwiseOperators<Unit, Unit, Unit>,
        INumber<Unit>,
        IAdditionOperators<Unit, Unit, Unit>,
        IAdditiveIdentity<Unit, Unit>,
        IComparisonOperators<Unit, Unit>,
        IEqualityOperators<Unit, Unit>,
        IDecrementOperators<Unit>,
        IDivisionOperators<Unit, Unit, Unit>,
        IIncrementOperators<Unit>,
        IModulusOperators<Unit, Unit, Unit>,
        IMultiplicativeIdentity<Unit, Unit>,
        IMultiplyOperators<Unit, Unit, Unit>,
        IParseable<Unit>,
        ISpanParseable<Unit>,
        ISubtractionOperators<Unit, Unit, Unit>,
        IUnaryNegationOperators<Unit, Unit>,
        IUnaryPlusOperators<Unit, Unit>,
        IFloatingPoint<Unit>,
        ISignedNumber<Unit>,
        IMinMaxValue<Unit>
    {
        #region Read-only Fields
        /// <summary>
        /// Represents the smallest positive System.Unit value that is greater than zero. This field is constant.
        /// </summary>
        public static readonly Unit Epsilon = double.Epsilon;

        /// <summary>
        /// Represents the largest possible value of a System.double. This field is constant.
        /// </summary>
        public static readonly Unit MaxValue = double.MaxValue;

        /// <summary>
        /// Represents the smallest possible value of a System.double. This field is constant.
        /// </summary>
        public static readonly Unit MinValue = double.MinValue;

        /// <summary>
        /// Represents a value that is not a number (NaN). This field is constant.
        /// </summary>
        public static readonly Unit NaN = double.NaN;

        /// <summary>
        /// Represents negative infinity. This field is constant.
        /// </summary>
        public static readonly Unit NegativeInfinity = double.NegativeInfinity;

        /// <summary>
        /// Represents positive infinity. This field is constant.
        /// </summary>
        public static readonly Unit PositiveInfinity = double.PositiveInfinity;
        #endregion

        #region Abstract Properties
        /// <summary>
        /// 
        /// </summary>
        [RequiresPreviewFeatures]
        static Unit IAdditiveIdentity<Unit, Unit>.AdditiveIdentity => 0d;

        /// <summary>
        /// 
        /// </summary>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.E => Math.E;

        /// <summary>
        /// 
        /// </summary>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.Epsilon => Epsilon;

        /// <summary>
        /// 
        /// </summary>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.NaN => NaN;

        /// <summary>
        /// 
        /// </summary>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.NegativeInfinity => NegativeInfinity;

        /// <summary>
        /// 
        /// </summary>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.NegativeZero => -0d;

        /// <summary>
        /// 
        /// </summary>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.Pi => Math.PI;

        /// <summary>
        /// 
        /// </summary>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.PositiveInfinity => PositiveInfinity;

        /// <summary>
        /// 
        /// </summary>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.Tau => Math.Tau;

        /// <summary>
        /// 
        /// </summary>
        [RequiresPreviewFeatures]
        static Unit IMinMaxValue<Unit>.MinValue => MinValue;

        /// <summary>
        /// 
        /// </summary>
        [RequiresPreviewFeatures]
        static Unit IMinMaxValue<Unit>.MaxValue => MaxValue;

        /// <summary>
        /// 
        /// </summary>
        [RequiresPreviewFeatures]
        static Unit INumber<Unit>.One => 1d;

        /// <summary>
        /// 
        /// </summary>
        [RequiresPreviewFeatures]
        static Unit INumber<Unit>.Zero => 0d;

        /// <summary>
        /// 
        /// </summary>
        [RequiresPreviewFeatures]
        static Unit IMultiplicativeIdentity<Unit, Unit>.MultiplicativeIdentity => 1d;

        /// <summary>
        /// 
        /// </summary>
        [RequiresPreviewFeatures]
        static Unit ISignedNumber<Unit>.NegativeOne => -1d;

        /// <summary>
        /// 
        /// </summary>
        [RequiresPreviewFeatures]
        public static double InMeters => 1d;
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Unit(double value) => Value = value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Unit(Unit value) => Value = value.Value;
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public double Value { get; }
        #endregion

        /// <summary>
        /// Compares this instance to a specified Unit-precision floating-point number and returns an integer that indicates whether the value of this instance is less than, equal to, or greater than the value of the specified Unit-precision floating-point number.
        /// </summary>
        /// <param name="value"> A Unit-precision floating-point number to compare.</param>
        /// <returns>
        /// A signed number indicating the relative values of this instance and value. Return Value – Description Less than zero – This instance is less than value, or this instance is not a number (System.double.NaN) and value is a number. Zero – This instance is equal to value, or both this instance and value are not a number (System.double.NaN), System.double.PositiveInfinity, or System.double.NegativeInfinity. Greater than zero – This instance is greater than value, or this instance is a number and value is not a number (System.double.NaN).
        /// </returns>
        public int CompareTo(Unit value) => Value.CompareTo(value.Value);

        /// <summary>
        /// Compares this instance to a specified object and returns an integer that indicates whether the value of this instance is less than, equal to, or greater than the value of the specified object.
        /// </summary>
        /// <param name="value">An object to compare, or null.</param>
        /// <returns>
        /// A signed number indicating the relative values of this instance and value. Value – Description A negative integer – This instance is less than value, or this instance is not a number (System.double.NaN) and value is a number. Zero – This instance is equal to value, or this instance and value are both double.NaN, System.double.PositiveInfinity, or System.double.NegativeInfinity A positive integer – This instance is greater than value, OR this instance is a number and value is not a number (System.double.NaN), OR value is null.
        /// </returns>
        /// <exception cref="T:System.ArgumentException">value is not a System.double.</exception>
        public int CompareTo(object? value) => Value.CompareTo(value);

        /// <summary>
        /// Returns a value indicating whether this instance and a specified System.Unit object represent the same value.
        /// </summary>
        /// <param name="other">A System.Unit object to compare to this instance.</param>
        /// <returns>
        /// true if obj is equal to this instance; otherwise, false.
        /// </returns>
        public bool Equals(Unit other) => Value.Equals(other.Value);

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// true if obj is an instance of System.Unit and equals the value of this instance; otherwise, false.
        /// </returns>
        public override bool Equals([NotNullWhen(true)] object? obj) => Value.Equals(obj);

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>
        public override int GetHashCode() => Value.GetHashCode();

        /// <summary>
        /// Returns the System.TypeCode for value type System.double.
        /// </summary>
        /// <returns>
        /// The enumerated constant, System.TypeCode.double.
        /// </returns>
        public TypeCode GetTypeCode() => Value.GetTypeCode();

        /// <summary>
        /// Determines whether the specified value is finite (zero, subnormal, or normal).
        /// </summary>
        /// <param name="d">A Unit-precision floating-point number.</param>
        /// <returns>
        /// true if the value is finite (zero, subnormal or normal); false otherwise.
        /// </returns>
        public static bool IsFinite(Unit d) => double.IsFinite(d.Value);

        /// <summary>
        /// Determines whether the specified value is finite (zero, subnormal, or normal).
        /// </summary>
        /// <param name="d">A Unit-precision floating-point number.</param>
        /// <returns>
        /// true if the value is finite (zero, subnormal or normal); false otherwise.
        /// </returns>
        static bool IFloatingPoint<Unit>.IsFinite(Unit d) => double.IsFinite(d.Value);

        /// <summary>
        /// Returns a value indicating whether the specified number evaluates to negative or positive infinity.
        /// </summary>
        /// <param name="d">A Unit-precision floating-point number.</param>
        /// <returns>
        /// true if d evaluates to System.double.PositiveInfinity or System.double.NegativeInfinity; otherwise, false.
        /// </returns>
        public static bool IsInfinity(Unit d) => double.IsInfinity(d.Value);

        /// <summary>
        /// Returns a value indicating whether the specified number evaluates to negative or positive infinity.
        /// </summary>
        /// <param name="d">A Unit-precision floating-point number.</param>
        /// <returns>
        /// true if d evaluates to System.double.PositiveInfinity or System.double.NegativeInfinity; otherwise, false.
        /// </returns>
        static bool IFloatingPoint<Unit>.IsInfinity(Unit d) => double.IsInfinity(d.Value);

        /// <summary>
        /// Returns a value that indicates whether the specified value is not a number (System.double.NaN).
        /// </summary>
        /// <param name="d">A Unit-precision floating-point number.</param>
        /// <returns>
        /// true if d evaluates to System.double.NaN; otherwise, false.
        /// </returns>
        public static bool IsNaN(Unit d) => double.IsNaN(d.Value);

        /// <summary>
        /// Returns a value that indicates whether the specified value is not a number (System.double.NaN).
        /// </summary>
        /// <param name="d">A Unit-precision floating-point number.</param>
        /// <returns>
        /// true if d evaluates to System.double.NaN; otherwise, false.
        /// </returns>
        static bool IFloatingPoint<Unit>.IsNaN(Unit d) => double.IsNaN(d.Value);

        /// <summary>
        /// Determines whether the specified value is negative.
        /// </summary>
        /// <param name="d">A Unit-precision floating-point number.</param>
        /// <returns>
        /// true if the value is negative; false otherwise.
        /// </returns>
        public static bool IsNegative(Unit d) => double.IsNegative(d.Value);

        /// <summary>
        /// Determines whether the specified value is negative.
        /// </summary>
        /// <param name="d">A Unit-precision floating-point number.</param>
        /// <returns>
        /// true if the value is negative; false otherwise.
        /// </returns>
        static bool IFloatingPoint<Unit>.IsNegative(Unit d) => double.IsNegative(d.Value);

        /// <summary>
        /// Returns a value indicating whether the specified number evaluates to negative infinity.
        /// </summary>
        /// <param name="d">A Unit-precision floating-point number.</param>
        /// <returns>true if d evaluates to System.double.NegativeInfinity; otherwise, false.</returns>
        public static bool IsNegativeInfinity(Unit d) => double.IsNegativeInfinity(d.Value);

        /// <summary>
        /// Returns a value indicating whether the specified number evaluates to negative infinity.
        /// </summary>
        /// <param name="d">A Unit-precision floating-point number.</param>
        /// <returns>true if d evaluates to System.double.NegativeInfinity; otherwise, false.</returns>
        static bool IFloatingPoint<Unit>.IsNegativeInfinity(Unit d) => double.IsNegativeInfinity(d.Value);

        /// <summary>
        /// Determines whether the specified value is normal.
        /// </summary>
        /// <param name="d">A Unit-precision floating-point number.</param>
        /// <returns>
        /// true if the value is normal; false otherwise.
        /// </returns>
        public static bool IsNormal(Unit d) => double.IsNormal(d.Value);

        /// <summary>
        /// Determines whether the specified value is normal.
        /// </summary>
        /// <param name="d">A Unit-precision floating-point number.</param>
        /// <returns>
        /// true if the value is normal; false otherwise.
        /// </returns>
        static bool IFloatingPoint<Unit>.IsNormal(Unit d) => double.IsNormal(d.Value);

        /// <summary>
        /// Returns a value indicating whether the specified number evaluates to positive infinity.
        /// </summary>
        /// <param name="d">A Unit-precision floating-point number.</param>
        /// <returns>
        /// true if d evaluates to System.double.PositiveInfinity; otherwise, false.
        /// </returns>
        public static bool IsPositiveInfinity(Unit d) => double.IsPositiveInfinity(d.Value);

        /// <summary>
        /// Returns a value indicating whether the specified number evaluates to positive infinity.
        /// </summary>
        /// <param name="d">A Unit-precision floating-point number.</param>
        /// <returns>
        /// true if d evaluates to System.double.PositiveInfinity; otherwise, false.
        /// </returns>
        static bool IFloatingPoint<Unit>.IsPositiveInfinity(Unit d) => double.IsPositiveInfinity(d.Value);

        /// <summary>
        /// Determines whether the specified value is subnormal.
        /// </summary>
        /// <param name="d">A Unit-precision floating-point number.</param>
        /// <returns>
        /// true if the value is subnormal; false otherwise.
        /// </returns>
        public static bool IsSubnormal(Unit d) => double.IsSubnormal(d.Value);

        /// <summary>
        /// Determines whether the specified value is subnormal.
        /// </summary>
        /// <param name="d">A Unit-precision floating-point number.</param>
        /// <returns>
        /// true if the value is subnormal; false otherwise.
        /// </returns>
        static bool IFloatingPoint<Unit>.IsSubnormal(Unit d) => double.IsSubnormal(d.Value);

        /// <summary>
        /// Returns a value that indicates whether two specified System.Unit values are equal.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>
        /// true if left and right are equal; otherwise, false.
        /// </returns>
        public static bool operator ==(Unit left, Unit right) => left.Value == right.Value;

        /// <summary>
        /// Returns a value that indicates whether a specified System.Unit value is greater than another specified System.Unit value.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>
        /// true if left is greater than right; otherwise, false.
        /// </returns>
        public static bool operator >(Unit left, Unit right) => left.Value > right.Value;

        /// <summary>
        /// Returns a value that indicates whether a specified System.Unit value is greater than or equal to another specified System.Unit value.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>
        /// true if left is greater than or equal to right; otherwise, false.
        /// </returns>
        public static bool operator >=(Unit left, Unit right) => left.Value >= right.Value;

        /// <summary>
        /// Returns a value that indicates whether two specified System.Unit values are not equal.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>
        /// true if left and right are not equal; otherwise, false.
        /// </returns>
        public static bool operator !=(Unit left, Unit right) => left.Value != right.Value;

        /// <summary>
        /// Returns a value that indicates whether a specified System.Unit value is less than another specified System.Unit value.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>
        /// true if left is less than right; otherwise, false.
        /// </returns>
        public static bool operator <(Unit left, Unit right) => left.Value < right.Value;

        /// <summary>
        /// Returns a value that indicates whether a specified System.Unit value is less than or equal to another specified System.Unit value.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>
        /// true if left is less than or equal to right; otherwise, false.
        /// </returns>
        public static bool operator <=(Unit left, Unit right) => left.Value <= right.Value;

        /// <summary>
        /// Converts a character span that contains the string representation of a number in a specified style and culture-specific format to its Unit-precision floating-point number equivalent.
        /// </summary>
        /// <param name="s">A character span that contains the number to convert.</param>
        /// <param name="style">A bitwise combination of enumeration values that indicate the style elements that can be present in s. A typical value to specify is System.Globalization.NumberStyles.Float combined with System.Globalization.NumberStyles.AllowThousands.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about s.</param>
        /// <returns>
        /// A Unit-precision floating-point number that is equivalent to the numeric value or symbol specified in s.
        /// </returns>
        /// <exception cref="System.FormatException">s does not represent a numeric value.</exception>
        /// <exception cref="System.ArgumentException">style is not a System.Globalization.NumberStyles value. -or- style is the System.Globalization.NumberStyles.AllowHexSpecifier value.</exception>
        public static Unit Parse(ReadOnlySpan<char> s, NumberStyles style = NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands | NumberStyles.AllowExponent, IFormatProvider? provider = null) => double.Parse(s, style, provider);

        /// <summary>
        /// Converts the string representation of a number to its Unit-precision floating-point number equivalent.
        /// </summary>
        /// <param name="s">A string that contains a number to convert.</param>
        /// <returns>
        /// A Unit-precision floating-point number that is equivalent to the numeric value or symbol specified in s.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">s is null.</exception>
        /// <exception cref="System.FormatException">s does not represent a number in a valid format.</exception>
        /// <exception cref="System.OverflowException">.NET Framework and .NET Core 2.2 and earlier versions only: s represents a number that is less than System.double.MinValue or greater than System.double.MaxValue.</exception>
        public static Unit Parse(string s) => double.Parse(s);

        /// <summary>
        /// Converts the string representation of a number in a specified style to its Unit-precision floating-point number equivalent.
        /// </summary>
        /// <param name="s">A string that contains a number to convert.</param>
        /// <param name="style">A bitwise combination of enumeration values that indicate the style elements that can be present in s. A typical value to specify is a combination of System.Globalization.NumberStyles.Float combined with System.Globalization.NumberStyles.AllowThousands.</param>
        /// <returns>
        /// A Unit-precision floating-point number that is equivalent to the numeric value or symbol specified in s.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">s is null.</exception>
        /// <exception cref="System.FormatException">s does not represent a number in a valid format.</exception>
        /// <exception cref="System.OverflowException">.NET Framework and .NET Core 2.2 and earlier versions only: s represents a number that is less than System.double.MinValue or greater than System.double.MaxValue.</exception>
        /// <exception cref="System.ArgumentException">style is not a System.Globalization.NumberStyles value. -or- style includes the System.Globalization.NumberStyles.AllowHexSpecifier value.</exception>
        public static Unit Parse(string s, NumberStyles style) => double.Parse(s, style);

        /// <summary>
        /// Converts the string representation of a number in a specified style and culture-specific format to its Unit-precision floating-point number equivalent.
        /// </summary>
        /// <param name="s">A string that contains a number to convert.</param>
        /// <param name="style">A bitwise combination of enumeration values that indicate the style elements that can be present in s. A typical value to specify is System.Globalization.NumberStyles.Float combined with System.Globalization.NumberStyles.AllowThousands.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about s.</param>
        /// <returns>
        /// A Unit-precision floating-point number that is equivalent to the numeric value or symbol specified in s.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">s is null.</exception>
        /// <exception cref="System.FormatException">s does not represent a numeric value.</exception>
        /// <exception cref="System.ArgumentException">style is not a System.Globalization.NumberStyles value. -or- style is the System.Globalization.NumberStyles.AllowHexSpecifier value.</exception>
        /// <exception cref="System.OverflowException">.NET Framework and .NET Core 2.2 and earlier versions only: s represents a number that is less than System.double.MinValue or greater than System.double.MaxValue.</exception>
        public static Unit Parse(string s, NumberStyles style, IFormatProvider? provider) => double.Parse(s, style, provider);

        /// <summary>
        /// Converts the string representation of a number in a specified culture-specific format to its Unit-precision floating-point number equivalent.
        /// </summary>
        /// <param name="s">A string that contains a number to convert.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about s.</param>
        /// <returns>
        /// A Unit-precision floating-point number that is equivalent to the numeric value or symbol specified in s.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">s is null.</exception>
        /// <exception cref="System.FormatException">s does not represent a number in a valid format.</exception>
        /// <exception cref="System.OverflowException">.NET Framework and .NET Core 2.2 and earlier versions only: s represents a number that is less than System.double.MinValue or greater than System.double.MaxValue.</exception>
        public static Unit Parse(string s, IFormatProvider? provider) => double.Parse(s, provider);

        /// <summary>
        /// For a description of this member, see System.IConvertible.ToBoolean(System.IFormatProvider).
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>
        /// true if the value of the current instance is not zero; otherwise, false.
        /// </returns>
        bool IConvertible.ToBoolean(IFormatProvider? provider) => Convert.ToBoolean(Value, provider);

        /// <summary>
        /// For a description of this member, see System.IConvertible.ToByte(System.IFormatProvider).
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>
        /// The value of the current instance, converted to a System.Byte.
        /// </returns>
        byte IConvertible.ToByte(IFormatProvider? provider) => Convert.ToByte(Value, provider);

        /// <summary>
        /// This conversion is not supported. Attempting to use this method throws an System.InvalidCastException.
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>
        /// This conversion is not supported. No value is returned.
        /// </returns>
        /// <exception cref="System.InvalidCastException">In all cases.</exception>
        char IConvertible.ToChar(IFormatProvider? provider) => Convert.ToChar(Value, provider);

        /// <summary>
        /// This conversion is not supported. Attempting to use this method throws an System.InvalidCastException
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>
        /// This conversion is not supported. No value is returned.
        /// </returns>
        /// <exception cref="System.InvalidCastException">In all cases.</exception>
        DateTime IConvertible.ToDateTime(IFormatProvider? provider) => Convert.ToDateTime(Value, provider);

        /// <summary>
        /// For a description of this member, see System.IConvertible.ToDecimal(System.IFormatProvider).
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>
        /// The value of the current instance, converted to a System.Decimal.
        /// </returns>
        decimal IConvertible.ToDecimal(IFormatProvider? provider) => Convert.ToDecimal(Value, provider);

        /// <summary>
        /// For a description of this member, see System.IConvertible.ToUnit(System.IFormatProvider).
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>
        /// The value of the current instance, unchanged.
        /// </returns>
        double IConvertible.ToDouble(IFormatProvider? provider) => Value;

        /// <summary>
        /// For a description of this member, see System.IConvertible.ToInt16(System.IFormatProvider).
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>
        /// The value of the current instance, converted to an System.Int16.
        /// </returns>
        short IConvertible.ToInt16(IFormatProvider? provider) => Convert.ToInt16(Value, provider);

        /// <summary>
        /// For a description of this member, see System.IConvertible.ToInt32(System.IFormatProvider).
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>
        /// The value of the current instance, converted to an System.Int32.
        /// </returns>
        int IConvertible.ToInt32(IFormatProvider? provider) => Convert.ToInt32(Value, provider);

        /// <summary>
        /// For a description of this member, see System.IConvertible.ToInt64(System.IFormatProvider).
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>
        /// The value of the current instance, converted to an System.Int64.
        /// </returns>
        long IConvertible.ToInt64(IFormatProvider? provider) => Convert.ToInt64(Value, provider);

        /// <summary>
        /// For a description of this member, see System.IConvertible.ToSByte(System.IFormatProvider).
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>
        /// The value of the current instance, converted to an System.SByte.
        /// </returns>
        sbyte IConvertible.ToSByte(IFormatProvider? provider) => Convert.ToSByte(Value, provider);

        /// <summary>
        /// For a description of this member, see System.IConvertible.ToSingle(System.IFormatProvider).
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>
        /// The value of the current instance, converted to a System.Single.
        /// </returns>
        float IConvertible.ToSingle(IFormatProvider? provider) => Convert.ToSingle(Value, provider);

        /// <summary>
        /// For a description of this member, see System.IConvertible.ToType(System.Type,System.IFormatProvider).
        /// </summary>
        /// <param name="type">The type to which to convert this System.Unit value.</param>
        /// <param name="provider">An System.IFormatProvider implementation that supplies culture-specific information about the format of the returned value.</param>
        /// <returns>
        /// The value of the current instance, converted to type.
        /// </returns>
        object IConvertible.ToType(Type type, IFormatProvider? provider) => Convert.ChangeType(Value, type, provider);

        /// <summary>
        /// For a description of this member, see System.IConvertible.ToUInt16(System.IFormatProvider).
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>
        /// The value of the current instance, converted to a System.UInt16.
        /// </returns>
        ushort IConvertible.ToUInt16(IFormatProvider? provider) => Convert.ToUInt16(Value, provider);

        /// <summary>
        /// For a description of this member, see System.IConvertible.ToUInt32(System.IFormatProvider).
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>
        /// The value of the current instance, converted to a System.UInt32.
        /// </returns>
        uint IConvertible.ToUInt32(IFormatProvider? provider) => Convert.ToUInt32(Value, provider);

        /// <summary>
        /// For a description of this member, see System.IConvertible.ToUInt64(System.IFormatProvider).
        /// </summary>
        /// <param name="provider">This parameter is ignored.</param>
        /// <returns>
        /// The value of the current instance, converted to a System.UInt64.
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
        /// The string representation of the value of this instance as specified by provider.
        /// </returns>
        public string ToString(IFormatProvider? provider) => ToString("R", provider);

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation, using the specified format.
        /// </summary>
        /// <param name="format">A numeric format string.</param>
        /// <returns>
        /// The string representation of the value of this instance as specified by format.
        /// </returns>
        /// <exception cref="System.FormatException">format is invalid.</exception>
        public string ToString(string? format) => Value.ToString(format, CultureInfo.InvariantCulture);

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation using the specified format and culture-specific format information.
        /// </summary>
        /// <param name="format">A numeric format string.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>
        /// The string representation of the value of this instance as specified by format and provider.
        /// </returns>
        public string ToString(string? format, IFormatProvider? provider) => Value.ToString(format, provider);

        /// <summary>
        /// Tries to format the value of the current Unit instance into the provided span of characters.
        /// </summary>
        /// <param name="destination">When this method returns, this instance's value formatted as a span of characters.</param>
        /// <param name="charsWritten">When this method returns, the number of characters that were written in destination.</param>
        /// <param name="format">A span containing the characters that represent a standard or custom format string that defines the acceptable format for destination.</param>
        /// <param name="provider">An optional object that supplies culture-specific formatting information for destination.</param>
        /// <returns>
        /// true if the formatting was successful; otherwise, false.
        /// </returns>
        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider? provider = null) => Value.TryFormat(destination, out charsWritten, format, provider);

        /// <summary>
        /// Converts the span representation of a number in a specified style and culture-specific format to its Unit-precision floating-point number equivalent. A return value indicates whether the conversion succeeded or failed.
        /// </summary>
        /// <param name="s">A character span that contains the string representation of the number to convert.</param>
        /// <param name="result">When this method returns, contains the Unit-precision floating-point number equivalent of the numeric value or symbol contained in s parameter, if the conversion succeeded, or zero if the conversion failed. The conversion fails if the s parameter is null or empty, or is not in a format compliant with style. The conversion also fails if style is not a valid combination of System.Globalization.NumberStyles enumerated constants. If s is a valid number less than System.double.MinValue, result is System.double.NegativeInfinity. If s is a valid number greater than System.double.MaxValue, result is System.double.PositiveInfinity. This parameter is passed uninitialized; any value originally supplied in result will be overwritten.</param>
        /// <returns>
        /// true if s was converted successfully; otherwise, false.
        /// </returns>
        public static bool TryParse(ReadOnlySpan<char> s, out Unit result)
        {
            var t = double.TryParse(s, out var r);
            result = r;
            return t;
        }

        /// <summary>
        /// Converts a character span containing the string representation of a number in a specified style and culture-specific format to its Unit-precision floating-point number equivalent. A return value indicates whether the conversion succeeded or failed.
        /// </summary>
        /// <param name="s">A read-only character span that contains the number to convert.</param>
        /// <param name="style">A bitwise combination of System.Globalization.NumberStyles values that indicates the permitted format of s. A typical value to specify is System.Globalization.NumberStyles.Float combined with System.Globalization.NumberStyles.AllowThousands.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about s.</param>
        /// <param name="result">When this method returns and if the conversion succeeded, contains a Unit-precision floating-point number equivalent of the numeric value or symbol contained in s. Contains zero if the conversion failed. The conversion fails if the s parameter is null, an empty character span, or not a number in a format compliant with style. If s is a valid number less than System.double.MinValue, result is System.double.NegativeInfinity. If s is a valid number greater than System.double.MaxValue, result is System.double.PositiveInfinity. This parameter is passed uninitialized; any value originally supplied in result will be overwritten.</param>
        /// <returns>
        /// true if s was converted successfully; otherwise, false.
        /// </returns>
        public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out Unit result)
        {
            var t = double.TryParse(s, style, provider, out var r);
            result = r;
            return t;
        }

        /// <summary>
        /// Converts the string representation of a number to its Unit-precision floating-point number equivalent. A return value indicates whether the conversion succeeded or failed.
        /// </summary>
        /// <param name="s">A string containing a number to convert.</param>
        /// <param name="result">When this method returns, contains the Unit-precision floating-point number equivalent of the s parameter, if the conversion succeeded, or zero if the conversion failed. The conversion fails if the s parameter is null or System.String.Empty or is not a number in a valid format. It also fails on .NET Framework and .NET Core 2.2 and earlier versions if s represents a number less than System.double.MinValue or greater than System.double.MaxValue. This parameter is passed uninitialized; any value originally supplied in result will be overwritten.</param>
        /// <returns>
        /// true if s was converted successfully; otherwise, false.
        /// </returns>
        public static bool TryParse([NotNullWhen(true)] string? s, out Unit result)
        {
            var t = double.TryParse(s, out var r);
            result = r;
            return t;
        }

        /// <summary>
        /// Converts the string representation of a number in a specified style and culture-specific format to its Unit-precision floating-point number equivalent. A return value indicates whether the conversion succeeded or failed.
        /// </summary>
        /// <param name="s">A string containing a number to convert.</param>
        /// <param name="style">A bitwise combination of System.Globalization.NumberStyles values that indicates the permitted format of s. A typical value to specify is System.Globalization.NumberStyles.Float combined with System.Globalization.NumberStyles.AllowThousands.</param>
        /// <param name="provider">An System.IFormatProvider that supplies culture-specific formatting information about s.</param>
        /// <param name="result">When this method returns, contains a Unit-precision floating-point number equivalent of the numeric value or symbol contained in s, if the conversion succeeded, or zero if the conversion failed. The conversion fails if the s parameter is null or System.String.Empty or is not in a format compliant with style, or if style is not a valid combination of System.Globalization.NumberStyles enumeration constants. It also fails on .NET Framework or .NET Core 2.2 and earlier versions if s represents a number less than System.SByte.MinValue or greater than System.SByte.MaxValue. This parameter is passed uninitialized; any value originally supplied in result will be overwritten.</param>
        /// <returns>
        /// true if s was converted successfully; otherwise, false.
        /// </returns>
        /// <exception cref="System.ArgumentException">style is not a System.Globalization.NumberStyles value. -or- style includes the System.Globalization.NumberStyles.AllowHexSpecifier value.</exception>
        public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, out Unit result)
        {
            var t = double.TryParse(s, style, provider, out var r);
            result = r;
            return t;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IAdditionOperators<Unit, Unit, Unit>.operator +(Unit left, Unit right) => left.Value + right.Value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static bool IBinaryNumber<Unit>.IsPow2(Unit value) => value.Value == Math.Pow(2d, Math.Log(value.Value, 2d));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IBinaryNumber<Unit>.Log2(Unit value) => Math.Log2(value.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [RequiresPreviewFeatures]
        static Unit IBitwiseOperators<Unit, Unit, Unit>.operator &(Unit left, Unit right)
        {
            //return left.value & right.value;
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [RequiresPreviewFeatures]
        static Unit IBitwiseOperators<Unit, Unit, Unit>.operator |(Unit left, Unit right)
        {
            //return left.value | right.value;
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [RequiresPreviewFeatures]
        static Unit IBitwiseOperators<Unit, Unit, Unit>.operator ^(Unit left, Unit right)
        {
            //return left.value ^ right.value;
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [RequiresPreviewFeatures]
        static Unit IBitwiseOperators<Unit, Unit, Unit>.operator ~(Unit value)
        {
            //return left.value ~right.value;
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static bool IComparisonOperators<Unit, Unit>.operator <(Unit left, Unit right) => left.Value < right.Value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static bool IComparisonOperators<Unit, Unit>.operator <=(Unit left, Unit right) => left.Value <= right.Value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static bool IComparisonOperators<Unit, Unit>.operator >(Unit left, Unit right) => left.Value > right.Value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static bool IComparisonOperators<Unit, Unit>.operator >=(Unit left, Unit right) => left.Value >= right.Value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IDecrementOperators<Unit>.operator --(Unit value) => value.Value - 1d;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IDivisionOperators<Unit, Unit, Unit>.operator /(Unit left, Unit right) => left.Value / right.Value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static bool IEqualityOperators<Unit, Unit>.operator ==(Unit left, Unit right) => left.Value == right.Value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static bool IEqualityOperators<Unit, Unit>.operator !=(Unit left, Unit right) => left.Value != right.Value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        [RequiresPreviewFeatures]
        public static implicit operator Unit(double v) => new(v);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.Acos(Unit x) => Math.Acos(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.Acosh(Unit x) => Math.Acosh(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.Asin(Unit x) => Math.Asin(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.Asinh(Unit x) => Math.Asinh(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.Atan(Unit x) => Math.Atan(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.Atan2(Unit y, Unit x) => Math.Atan2(y.Value, x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.Atanh(Unit x) => Math.Atanh(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.BitIncrement(Unit x) => x.Value + 1d;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.BitDecrement(Unit x) => x.Value - 1d;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.Cbrt(Unit x) => Math.Cbrt(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.Ceiling(Unit x) => Math.Ceiling(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.CopySign(Unit x, Unit y) => Math.CopySign(x.Value, y.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.Cos(Unit x) => Math.Cos(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.Cosh(Unit x) => Math.Cosh(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.Exp(Unit x) => Math.Exp(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.Floor(Unit x) => Math.Floor(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="addend"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.FusedMultiplyAdd(Unit left, Unit right, Unit addend) => Math.FusedMultiplyAdd(left.Value, right.Value, addend.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.IEEERemainder(Unit left, Unit right) => Math.IEEERemainder(left.Value, right.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TInteger"></typeparam>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static TInteger IFloatingPoint<Unit>.ILogB<TInteger>(Unit x) => TInteger.Create(Math.ILogB(x.Value));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.Log(Unit x) => Math.Log(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="newBase"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.Log(Unit x, Unit newBase) => Math.Log(x.Value, newBase.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.Log2(Unit x) => Math.Log2(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.Log10(Unit x) => Math.Log10(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.MaxMagnitude(Unit x, Unit y) => Math.MaxMagnitude(x.Value, y.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.MinMagnitude(Unit x, Unit y) => Math.MinMagnitude(x.Value, y.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.Pow(Unit x, Unit y) => Math.Pow(x.Value, y.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.Round(Unit x) => Math.Round(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TInteger"></typeparam>
        /// <param name="x"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.Round<TInteger>(Unit x, TInteger digits) => Math.Round(x.Value, Operations.Cast<TInteger, int>(digits));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.Round(Unit x, MidpointRounding mode) => Math.Round(x.Value, mode);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TInteger"></typeparam>
        /// <param name="x"></param>
        /// <param name="digits"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.Round<TInteger>(Unit x, TInteger digits, MidpointRounding mode) => Math.Round(x.Value, Operations.Cast<TInteger, int>(digits), mode);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TInteger"></typeparam>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.ScaleB<TInteger>(Unit x, TInteger n) => Math.Round(x.Value, Operations.Cast<TInteger, int>(n));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.Sin(Unit x) => Math.Sin(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.Sinh(Unit x) => Math.Sinh(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.Sqrt(Unit x) => Math.Sqrt(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.Tan(Unit x) => Math.Tan(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.Tanh(Unit x) => Math.Tanh(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IFloatingPoint<Unit>.Truncate(Unit x) => Math.Truncate(x.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IIncrementOperators<Unit>.operator ++(Unit value) => value.Value + 1d;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IModulusOperators<Unit, Unit, Unit>.operator %(Unit left, Unit right) => left.Value % right.Value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IMultiplyOperators<Unit, Unit, Unit>.operator *(Unit left, Unit right) => left.Value * right.Value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit INumber<Unit>.Abs(Unit value) => Math.Abs(value.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit INumber<Unit>.Clamp(Unit value, Unit min, Unit max) => Math.Clamp(value.Value, min.Value, max.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TOther"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit INumber<Unit>.Create<TOther>(TOther value) => Operations.Cast<TOther, double>(value);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TOther"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit INumber<Unit>.CreateSaturating<TOther>(TOther value) => Operations.CastSaturating<TOther, double>(value);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TOther"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit INumber<Unit>.CreateTruncating<TOther>(TOther value) => Operations.CastTruncating<TOther, double>(value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static (Unit Quotient, Unit Remainder) INumber<Unit>.DivRem(Unit left, Unit right) => Math.DivRem((int)left.Value, (int)right.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit INumber<Unit>.Max(Unit x, Unit y) => Math.Max(x.Value, y.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit INumber<Unit>.Min(Unit x, Unit y) => Math.Min(x.Value, y.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="style"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit INumber<Unit>.Parse(string s, NumberStyles style, IFormatProvider? provider) => double.Parse(s, style, provider);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="style"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit INumber<Unit>.Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider) => double.Parse(s, style, provider);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit INumber<Unit>.Sign(Unit value) => Math.Sign(value.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TOther"></typeparam>
        /// <param name="value"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static bool INumber<Unit>.TryCreate<TOther>(TOther value, out Unit result)
        {
            var t = Operations.TryCast<TOther, double>(value, out var r);
            result = r;
            return t;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="style"></param>
        /// <param name="provider"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static bool INumber<Unit>.TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, out Unit result)
        {
            var t = double.TryParse(s, style, provider, out var r);
            result = r;
            return t;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="style"></param>
        /// <param name="provider"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static bool INumber<Unit>.TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out Unit result)
        {
            var t = double.TryParse(s, style, provider, out var r);
            result = r;
            return t;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IParseable<Unit>.Parse(string s, IFormatProvider? provider) => double.Parse(s, provider);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="provider"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static bool IParseable<Unit>.TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out Unit result)
        {
            var t = double.TryParse(s, NumberStyles.Float, provider, out var r);
            result = r;
            return t;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit ISpanParseable<Unit>.Parse(ReadOnlySpan<char> s, IFormatProvider? provider) => double.Parse(s, NumberStyles.Float, provider);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="provider"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static bool ISpanParseable<Unit>.TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out Unit result)
        {
            var t = double.TryParse(s, NumberStyles.Float, provider, out var r);
            result = r;
            return t;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TOther"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static Unit Create<TOther>(TOther value) where TOther : INumber<TOther> => new(Operations.Cast<TOther, double>(value));

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TOther"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static Unit CreateSaturating<TOther>(TOther value) where TOther : INumber<TOther> => new(Operations.CastSaturating<TOther, double>(value));

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TOther"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static Unit CreateTruncating<TOther>(TOther value) where TOther : INumber<TOther> => new(Operations.CastTruncating<TOther, double>(value));

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TOther"></typeparam>
        /// <param name="value"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        public static bool TryCreate<TOther>(TOther value, out Unit result) where TOther : INumber<TOther>
        {
            result = new(Operations.Cast<TOther, double>(value));
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit ISubtractionOperators<Unit, Unit, Unit>.operator -(Unit left, Unit right) => left.Value - right.Value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IUnaryNegationOperators<Unit, Unit>.operator -(Unit value) => -value.Value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [RequiresPreviewFeatures]
        static Unit IUnaryPlusOperators<Unit, Unit>.operator +(Unit value) => +value.Value;
    }
}