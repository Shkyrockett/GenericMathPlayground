// <copyright file="MetersUnit.cs" company="Shkyrockett" >
//     Copyright © 2021 - 2022 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace GenericMathPlayground.Physics;

/// <summary>
/// The metric meters unit.
/// </summary>
[TypeConverter(typeof(LengthUnitConverter<MetersUnit>))]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)]
public readonly struct MetersUnit
    : ILengthUnit,
    IComparable, IComparable<MetersUnit>, IEquatable<MetersUnit>,
    IConvertible, IFormattable, ISpanFormattable,
    IParsable<MetersUnit>, ISpanParsable<MetersUnit>,
    IAdditiveIdentity<MetersUnit, MetersUnit>, IMultiplicativeIdentity<MetersUnit, MetersUnit>,
    ISignedNumber<MetersUnit>, INumber<MetersUnit>, INumberBase<MetersUnit>, IBinaryNumber<MetersUnit>, IFloatingPoint<MetersUnit>, IFloatingPointIeee754<MetersUnit>, IBinaryFloatingPointIeee754<MetersUnit>,
    ITrigonometricFunctions<MetersUnit>, ILogarithmicFunctions<MetersUnit>, IExponentialFunctions<MetersUnit>, IHyperbolicFunctions<MetersUnit>, IPowerFunctions<MetersUnit>, IRootFunctions<MetersUnit>,
    IBitwiseOperators<MetersUnit, MetersUnit, MetersUnit>, IComparisonOperators<MetersUnit, MetersUnit>, IEqualityOperators<MetersUnit, MetersUnit>, IUnaryNegationOperators<MetersUnit, MetersUnit>, IUnaryPlusOperators<MetersUnit, MetersUnit>, IDecrementOperators<MetersUnit>, IIncrementOperators<MetersUnit>, IAdditionOperators<MetersUnit, MetersUnit, MetersUnit>, ISubtractionOperators<MetersUnit, MetersUnit, MetersUnit>, IMultiplyOperators<MetersUnit, MetersUnit, MetersUnit>, IDivisionOperators<MetersUnit, MetersUnit, MetersUnit>, IModulusOperators<MetersUnit, MetersUnit, MetersUnit>,
    IMinMaxValue<MetersUnit>
{
    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="MetersUnit"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public MetersUnit(double value)
    {
        Value = value;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MetersUnit"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public MetersUnit(ILengthUnit value)
    {
        Value = value.Value * (value.UnitInMeters * UnitOfMeters);
    }
    #endregion

    #region Properties
    /// <summary>
    /// Gets the value.
    /// </summary>
    public double Value { get; }

    /// <summary>
    /// Gets the conversion unit in meters.
    /// </summary>
    public double UnitInMeters => 1d / UnitOfMeters;

    /// <summary>
    /// Gets the conversion of unit in meters.
    /// </summary>
    public static double UnitOfMeters => 1d / 1d;

    /// <summary>
    /// Gets the e.
    /// </summary>
    public static MetersUnit E => new(Math.E);

    /// <summary>
    /// Gets the epsilon.
    /// </summary>
    public static MetersUnit Epsilon => new(double.Epsilon);

    /// <summary>
    /// Gets the na n.
    /// </summary>
    public static MetersUnit NaN => new(double.NaN);

    /// <summary>
    /// Gets the negative infinity.
    /// </summary>
    public static MetersUnit NegativeInfinity => new(double.NegativeInfinity);

    /// <summary>
    /// Gets the negative zero.
    /// </summary>
    public static MetersUnit NegativeZero => new(double.NegativeZero);

    /// <summary>
    /// Gets the pi.
    /// </summary>
    public static MetersUnit Pi => new(double.Pi);

    /// <summary>
    /// Gets the positive infinity.
    /// </summary>
    public static MetersUnit PositiveInfinity => new(double.PositiveInfinity);

    /// <summary>
    /// Gets the tau.
    /// </summary>
    public static MetersUnit Tau => new(double.Tau);

    /// <summary>
    /// Gets the one.
    /// </summary>
    public static MetersUnit One => new(1d);

    /// <summary>
    /// Gets the radix.
    /// </summary>
    public static int Radix => 10;

    /// <summary>
    /// Gets the zero.
    /// </summary>
    public static MetersUnit Zero => new(0d);

    /// <summary>
    /// Gets the additive identity.
    /// </summary>
    public static MetersUnit AdditiveIdentity => new(0d);

    /// <summary>
    /// Gets the multiplicative identity.
    /// </summary>
    public static MetersUnit MultiplicativeIdentity => new(1d);

    /// <summary>
    /// Gets the negative one.
    /// </summary>
    public static MetersUnit NegativeOne => new(-1d);

    /// <summary>
    /// Gets the max value.
    /// </summary>
    public static MetersUnit MaxValue => new(double.MaxValue);

    /// <summary>
    /// Gets the min value.
    /// </summary>
    public static MetersUnit MinValue => new(double.MinValue);
    #endregion

    #region Operators
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(MetersUnit left, MetersUnit right) => left.Equals(right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(MetersUnit left, MetersUnit right) => !(left == right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator <(MetersUnit left, MetersUnit right) => left.CompareTo(right) < 0;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator >(MetersUnit left, MetersUnit right) => left.CompareTo(right) > 0;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator <=(MetersUnit left, MetersUnit right) => left.CompareTo(right) <= 0;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator >=(MetersUnit left, MetersUnit right) => left.CompareTo(right) >= 0;

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
    public static MetersUnit operator ++(MetersUnit value) => new(value.Value + 1d);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static MetersUnit operator checked ++(MetersUnit value) => new(value.Value + 1d);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static MetersUnit operator --(MetersUnit value) => new(value.Value - 1d);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static MetersUnit operator checked --(MetersUnit value) => new(value.Value - 1d);

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
    /// <exception cref="NotImplementedException"></exception>
    public static MetersUnit operator &(MetersUnit left, MetersUnit right) => throw new NotImplementedException();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static MetersUnit operator |(MetersUnit left, MetersUnit right) => throw new NotImplementedException();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static MetersUnit operator ^(MetersUnit left, MetersUnit right) => throw new NotImplementedException();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static MetersUnit operator ~(MetersUnit value) => throw new NotImplementedException();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="v"></param>
    public static implicit operator MetersUnit(double v) => new(v);
    #endregion

    #region Comparison Equatable
    /// <summary>
    /// Gets the hash code.
    /// </summary>
    /// <returns>An int.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public override int GetHashCode() => HashCode.Combine(Value);

    /// <summary>
    /// Compares the to.
    /// </summary>
    /// <param name="obj">The obj.</param>
    /// <returns>An int.</returns>
    public int CompareTo(object? obj) => obj switch
    {
        null => 1,
        MetersUnit metric => CompareTo(metric),
        double num => Value.CompareTo(num),
        _ => throw new ArgumentException("Object must be double or Metric"),
    };

    /// <summary>
    /// Compares the to.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>An int.</returns>
    public int CompareTo(MetersUnit other) => Value.CompareTo(other.Value);

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="obj">The obj.</param>
    /// <returns>A bool.</returns>
    public override bool Equals(object? obj) => obj is MetersUnit metric && Value == metric.Value;

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>A bool.</returns>
    public bool Equals(MetersUnit other) => Value.Equals(other.Value);
    #endregion

    #region Conversion
    /// <summary>
    /// Gets the type code.
    /// </summary>
    /// <returns>A TypeCode.</returns>
    public TypeCode GetTypeCode() => TypeCode.Double;

    /// <summary>
    /// Tries the convert from checked.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="result">The result.</param>
    /// <returns>A bool.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    static bool INumberBase<MetersUnit>.TryConvertFromChecked<TOther>(TOther value, out MetersUnit result) => TryConvertFrom(value, out result);

    /// <summary>
    /// Tries the convert from saturating.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="result">The result.</param>
    /// <returns>A bool.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    static bool INumberBase<MetersUnit>.TryConvertFromSaturating<TOther>(TOther value, out MetersUnit result) => TryConvertFrom(value, out result);

    /// <summary>
    /// Tries the convert from truncating.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="result">The result.</param>
    /// <returns>A bool.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    static bool INumberBase<MetersUnit>.TryConvertFromTruncating<TOther>(TOther value, out MetersUnit result) => TryConvertFrom(value, out result);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TOther"></typeparam>
    /// <param name="value"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private static bool TryConvertFrom<TOther>(TOther value, out MetersUnit result)
        where TOther : INumberBase<TOther>
    {
        Type type = typeof(TOther);
        if (type == typeof(Half))
        {
            Half half = (Half)(object)value;
            result = new((double)half);
            return true;
        }
        else if (type == typeof(short))
        {
            short num = (short)(object)value;
            result = new(num);
            return true;
        }
        else if (type == typeof(int))
        {
            int num2 = (int)(object)value;
            result = new(num2);
            return true;
        }
        else if (type == typeof(long))
        {
            long num3 = (long)(object)value;
            result = new(num3);
            return true;
        }
        else if (type == typeof(Int128))
        {
            Int128 @int = (Int128)(object)value;
            result = new((double)@int);
            return true;
        }
        else if (type == typeof(IntPtr))
        {
            IntPtr intPtr = (IntPtr)(object)value;
            result = new((nint)intPtr);
            return true;
        }
        else if (type == typeof(sbyte))
        {
            sbyte b = (sbyte)(object)value;
            result = new(b);
            return true;
        }
        else if (type == typeof(float))
        {
            float num4 = (float)(object)value;
            result = new(num4);
            return true;
        }
        else if (type == typeof(double))
        {
            double num4 = (double)(object)value;
            result = new(num4);
            return true;
        }
        result = default;
        return false;
    }

    /// <summary>
    /// Tries the convert to checked.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="result">The result.</param>
    /// <returns>A bool.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    static bool INumberBase<MetersUnit>.TryConvertToChecked<TOther>(MetersUnit value, out TOther result)
        where TOther : default
    {
        Type type = typeof(TOther);
        if (type == typeof(byte))
        {
            byte b = checked((byte)value.Value);
            result = (TOther)(object)b;
            return true;
        }
        if (type == typeof(char))
        {
            char c = (char)checked((ushort)value.Value);
            result = (TOther)(object)c;
            return true;
        }
        if (type == typeof(decimal))
        {
            decimal num = (decimal)value.Value;
            result = (TOther)(object)num;
            return true;
        }
        if (type == typeof(float))
        {
            float num = (float)value.Value;
            result = (TOther)(object)num;
            return true;
        }
        if (type == typeof(double))
        {
            double num = (double)value.Value;
            result = (TOther)(object)num;
            return true;
        }
        checked
        {
            if (type == typeof(ushort))
            {
                ushort num2 = (ushort)value.Value;
                result = (TOther)(object)num2;
                return true;
            }
            if (type == typeof(uint))
            {
                uint num3 = (uint)value.Value;
                result = (TOther)(object)num3;
                return true;
            }
            if (type == typeof(ulong))
            {
                ulong num4 = (ulong)value.Value;
                result = (TOther)(object)num4;
                return true;
            }
            if (type == typeof(UInt128))
            {
                UInt128 uInt = (UInt128)value.Value;
                result = (TOther)(object)uInt;
                return true;
            }
            if (type == typeof(UIntPtr))
            {
                nuint num5 = (nuint)value.Value;
                result = (TOther)(object)num5;
                return true;
            }
            result = default!;
            return false;
        }
    }

    /// <summary>
    /// Tries the convert to saturating.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="result">The result.</param>
    /// <returns>A bool.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    static bool INumberBase<MetersUnit>.TryConvertToSaturating<TOther>(MetersUnit value, out TOther result)
        where TOther : default => TryConvertTo<TOther>(value, out result);

    /// <summary>
    /// Tries the convert to truncating.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="result">The result.</param>
    /// <returns>A bool.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    static bool INumberBase<MetersUnit>.TryConvertToTruncating<TOther>(MetersUnit value, out TOther result)
        where TOther : default => TryConvertTo<TOther>(value, out result);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TOther"></typeparam>
    /// <param name="value"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private static bool TryConvertTo<TOther>(MetersUnit value, [NotNullWhen(true)] out TOther result)
        where TOther : INumberBase<TOther>
    {
        Type type = typeof(TOther);
        if (type == typeof(byte))
        {
            byte b = (byte)((value.Value >= 255.0) ? byte.MaxValue : ((!(value <= 0.0)) ? ((byte)value.Value) : 0));
            result = (TOther)(object)b;
            return true;
        }
        if (type == typeof(char))
        {
            char c = (value.Value >= 65535.0) ? '\uffff' : ((!(value.Value <= 0.0)) ? ((char)value.Value) : '\0');
            result = (TOther)(object)c;
            return true;
        }
        if (type == typeof(decimal))
        {
            decimal num = (value.Value >= 7.9228162514264338E+28) ? decimal.MaxValue : ((value.Value <= -7.9228162514264338E+28) ? decimal.MinValue : (IsNaN(value.Value) ? 0.0m : ((decimal)value.Value)));
            result = (TOther)(object)num;
            return true;
        }
        if (type == typeof(ushort))
        {
            ushort num2 = (ushort)((value.Value >= 65535.0) ? ushort.MaxValue : ((!(value.Value <= 0.0)) ? ((ushort)value.Value) : 0));
            result = (TOther)(object)num2;
            return true;
        }
        if (type == typeof(uint))
        {
            uint num3 = (value.Value >= 4294967295.0) ? uint.MaxValue : ((!(value.Value <= 0.0)) ? ((uint)value.Value) : 0u);
            result = (TOther)(object)num3;
            return true;
        }
        if (type == typeof(ulong))
        {
            ulong num4 = (value.Value >= 1.8446744073709552E+19) ? ulong.MaxValue : ((value.Value <= 0.0) ? 0 : (IsNaN(value.Value) ? 0 : ((ulong)value.Value)));
            result = (TOther)(object)num4;
            return true;
        }
        if (type == typeof(UInt128))
        {
            UInt128 uInt = (value.Value >= 3.4028236692093846E+38) ? UInt128.MaxValue : ((value.Value <= 0.0) ? UInt128.MinValue : ((UInt128)value.Value));
            result = (TOther)(object)uInt;
            return true;
        }
        if (type == typeof(UIntPtr))
        {
            UIntPtr uIntPtr = (value.Value >= 1.8446744073709552E+19) ? ((UIntPtr)unchecked((nuint)(-1))) : ((value.Value <= 0.0) ? ((UIntPtr)(nuint)0u) : ((UIntPtr)value.Value));
            result = (TOther)(object)uIntPtr;
            return true;
        }
        if (type == typeof(float))
        {
            float ff = (float)value.Value;
            result = (TOther)(object)ff;
            return true;
        }
        if (type == typeof(double))
        {
            double dd = (double)value.Value;
            result = (TOther)(object)dd;
            return true;
        }
        result = default!;
        return false;
    }

    /// <summary>
    /// Tos the boolean.
    /// </summary>
    /// <param name="provider">The provider.</param>
    /// <returns>A bool.</returns>
    public bool ToBoolean(IFormatProvider? provider) => Convert.ToBoolean(Value, provider);

    /// <summary>
    /// Tos the byte.
    /// </summary>
    /// <param name="provider">The provider.</param>
    /// <returns>A byte.</returns>
    public byte ToByte(IFormatProvider? provider) => Convert.ToByte(Value, provider);

    /// <summary>
    /// Tos the char.
    /// </summary>
    /// <param name="provider">The provider.</param>
    /// <returns>A char.</returns>
    public char ToChar(IFormatProvider? provider) => Convert.ToChar(Value, provider);

    /// <summary>
    /// Tos the date time.
    /// </summary>
    /// <param name="provider">The provider.</param>
    /// <returns>A DateTime.</returns>
    public DateTime ToDateTime(IFormatProvider? provider) => Convert.ToDateTime(Value, provider);

    /// <summary>
    /// Tos the decimal.
    /// </summary>
    /// <param name="provider">The provider.</param>
    /// <returns>A decimal.</returns>
    public decimal ToDecimal(IFormatProvider? provider) => Convert.ToDecimal(Value, provider);

    /// <summary>
    /// Tos the double.
    /// </summary>
    /// <param name="provider">The provider.</param>
    /// <returns>A double.</returns>
    public double ToDouble(IFormatProvider? provider) => Convert.ToDouble(Value, provider);

    /// <summary>
    /// Tos the int16.
    /// </summary>
    /// <param name="provider">The provider.</param>
    /// <returns>A short.</returns>
    public short ToInt16(IFormatProvider? provider) => Convert.ToInt16(Value, provider);

    /// <summary>
    /// Tos the int32.
    /// </summary>
    /// <param name="provider">The provider.</param>
    /// <returns>An int.</returns>
    public int ToInt32(IFormatProvider? provider) => Convert.ToInt32(Value, provider);

    /// <summary>
    /// Tos the int64.
    /// </summary>
    /// <param name="provider">The provider.</param>
    /// <returns>A long.</returns>
    public long ToInt64(IFormatProvider? provider) => Convert.ToInt64(Value, provider);

    /// <summary>
    /// Tos the s byte.
    /// </summary>
    /// <param name="provider">The provider.</param>
    /// <returns>A sbyte.</returns>
    public sbyte ToSByte(IFormatProvider? provider) => Convert.ToSByte(Value, provider);

    /// <summary>
    /// Tos the single.
    /// </summary>
    /// <param name="provider">The provider.</param>
    /// <returns>A float.</returns>
    public float ToSingle(IFormatProvider? provider) => Convert.ToSingle(Value, provider);

    /// <summary>
    /// Tos the u int16.
    /// </summary>
    /// <param name="provider">The provider.</param>
    /// <returns>An ushort.</returns>
    public ushort ToUInt16(IFormatProvider? provider) => Convert.ToUInt16(Value, provider);

    /// <summary>
    /// Tos the u int32.
    /// </summary>
    /// <param name="provider">The provider.</param>
    /// <returns>An uint.</returns>
    public uint ToUInt32(IFormatProvider? provider) => Convert.ToUInt32(Value, provider);

    /// <summary>
    /// Tos the u int64.
    /// </summary>
    /// <param name="provider">The provider.</param>
    /// <returns>An ulong.</returns>
    public ulong ToUInt64(IFormatProvider? provider) => Convert.ToUInt64(Value, provider);

    /// <summary>
    /// Tos the type.
    /// </summary>
    /// <param name="conversionType">The conversion type.</param>
    /// <param name="provider">The provider.</param>
    /// <returns>An object.</returns>
    public object ToType(Type conversionType, IFormatProvider? provider) => Convert.ChangeType(this, conversionType, provider);

    /// <summary>
    /// Converts the numeric value of this instance to its equivalent string representation.
    /// </summary>
    /// <returns>
    /// The string representation of the value of this instance.
    /// </returns>
    public override string ToString() => ToString("R", CultureInfo.InvariantCulture);

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
    /// Converts the numeric value of this instance to its equivalent string representation using the specified culture-specific format information.
    /// </summary>
    /// <param name="provider">An object that supplies culture-specific formatting information.</param>
    /// <returns>
    /// The string representation of the value of this instance as specified by <paramref name="provider" />.
    /// </returns>
    public string ToString(IFormatProvider? provider) => ToString("R", provider);

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
    /// Gets the debugger display.
    /// </summary>
    /// <returns>
    /// A string representation of this object for display in the debugger.
    /// </returns>
    private string? GetDebuggerDisplay() => ToString();

    /// <summary>
    /// Tries the format.
    /// </summary>
    /// <param name="destination">The destination.</param>
    /// <param name="charsWritten">The chars written.</param>
    /// <param name="format">The format.</param>
    /// <param name="provider">The provider.</param>
    /// <returns>A bool.</returns>
    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
    {
        var text = ToString(format.ToString(), provider).AsSpan();
        charsWritten = text.Length;
        text.CopyTo(destination);
        return true;
    }
    #endregion

    #region Parsing
    /// <summary>
    /// Parses the.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="provider">The provider.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Parse(ReadOnlySpan<char> s, IFormatProvider? provider) => new(double.Parse(s, provider));

    /// <summary>
    /// Parses the.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="provider">The provider.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Parse(string s, IFormatProvider? provider) => new(double.Parse(s, provider));

    /// <summary>
    /// Parses the.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="style">The style.</param>
    /// <param name="provider">The provider.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider) => new(double.Parse(s, style, provider));

    /// <summary>
    /// Parses the.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="style">The style.</param>
    /// <param name="provider">The provider.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Parse(string s, NumberStyles style, IFormatProvider? provider) => new(double.Parse(s, style, provider));

    /// <summary>
    /// Tries the parse.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="style">The style.</param>
    /// <param name="provider">The provider.</param>
    /// <param name="result">The result.</param>
    /// <returns>A bool.</returns>
    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out MetersUnit result)
    {
        if (double.TryParse(s, style, provider, out var r))
        {
            result = new(r);
            return true;
        }
        result = default;
        return false;
    }

    /// <summary>
    /// Tries the parse.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="style">The style.</param>
    /// <param name="provider">The provider.</param>
    /// <param name="result">The result.</param>
    /// <returns>A bool.</returns>
    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, out MetersUnit result)
    {
        if (double.TryParse(s, style, provider, out var r))
        {
            result = new(r);
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
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out MetersUnit result)
    {
        if (double.TryParse(s, provider, out var r))
        {
            result = new(r);
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
        if (double.TryParse(s, provider, out var r))
        {
            result = new(r);
            return true;
        }
        result = default;
        return false;
    }
    #endregion

    #region Min Max Rounding
    /// <summary>
    /// Mins the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Min(MetersUnit x, MetersUnit y) => new(double.Min(x.Value, y.Value));

    /// <summary>
    /// Maxes the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Max(MetersUnit x, MetersUnit y) => new(double.Max(x.Value, y.Value));

    /// <summary>
    /// Mins the number.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit MinNumber(MetersUnit x, MetersUnit y) => new(double.MinNumber(x.Value, y.Value));

    /// <summary>
    /// Maxes the number.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit MaxNumber(MetersUnit x, MetersUnit y) => new(double.MaxNumber(x.Value, y.Value));

    /// <summary>
    /// Mins the magnitude.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit MinMagnitude(MetersUnit x, MetersUnit y) => new(double.MinMagnitude(x.Value, y.Value));

    /// <summary>
    /// Maxes the magnitude.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit MaxMagnitude(MetersUnit x, MetersUnit y) => new(double.MaxMagnitude(x.Value, y.Value));

    /// <summary>
    /// Mins the magnitude number.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit MinMagnitudeNumber(MetersUnit x, MetersUnit y) => new(double.MinMagnitudeNumber(x.Value, y.Value));

    /// <summary>
    /// Maxes the magnitude number.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit MaxMagnitudeNumber(MetersUnit x, MetersUnit y) => new(double.MaxMagnitudeNumber(x.Value, y.Value));

    /// <summary>
    /// Ceilings the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Ceiling(MetersUnit x) => new(double.Ceiling(x.Value));

    /// <summary>
    /// Floors the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Floor(MetersUnit x) => new(double.Floor(x.Value));

    /// <summary>
    /// Clamps the.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="min">The min.</param>
    /// <param name="max">The max.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Clamp(MetersUnit value, MetersUnit min, MetersUnit max) => new(double.Clamp(value.Value, min.Value, max.Value));

    /// <summary>
    /// Truncates the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Truncate(MetersUnit x) => new(double.Truncate(x.Value));

    /// <summary>
    /// Rounds the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Round(MetersUnit x) => new(double.Round(x.Value));

    /// <summary>
    /// Rounds the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="digits">The digits.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Round(MetersUnit x, int digits) => new(double.Round(x.Value, digits));

    /// <summary>
    /// Rounds the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="mode">The mode.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Round(MetersUnit x, MidpointRounding mode) => new(double.Round(x.Value, mode));

    /// <summary>
    /// Rounds the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="digits">The digits.</param>
    /// <param name="mode">The mode.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Round(MetersUnit x, int digits, MidpointRounding mode) => new(double.Round(x.Value, digits, mode));
    #endregion

    #region Exponents Powers Logs Roots
    /// <summary>
    /// Are the pow2.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A bool.</returns>
    public static bool IsPow2(MetersUnit value) => double.IsPow2(value.Value);

    /// <summary>
    /// Pows the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Pow(MetersUnit x, MetersUnit y) => new(double.Pow(x.Value, x.Value));

    /// <summary>
    /// Exps the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Exp(MetersUnit x) => new(double.Exp(x.Value));

    /// <summary>
    /// Exp10S the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Exp10(MetersUnit x) => new(double.Pow(10.0, x.Value));

    /// <summary>
    /// Exp10S the m1.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Exp10M1(MetersUnit x) => new(double.Pow(10.0, x.Value) - 1d);

    /// <summary>
    /// Exp2S the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Exp2(MetersUnit x) => new(double.Pow(2.0, x.Value));

    /// <summary>
    /// Exp2S the m1.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Exp2M1(MetersUnit x) => new(double.Pow(2.0, x.Value) - 1.0);

    /// <summary>
    /// Exps the m1.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit ExpM1(MetersUnit x) => new(double.Exp(x.Value) - 1.0);

    /// <summary>
    /// IS the log b.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>An int.</returns>
    public static int ILogB(MetersUnit x) => double.ILogB(x.Value);

    /// <summary>
    /// Logs the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Log(MetersUnit x) => new(double.Log(x.Value));

    /// <summary>
    /// Logs the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="newBase">The new base.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Log(MetersUnit x, MetersUnit newBase) => new(double.Log(x.Value, newBase.Value));

    /// <summary>
    /// Log2S the.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Log2(MetersUnit value) => new(double.Log2(value.Value));

    /// <summary>
    /// Log10S the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Log10(MetersUnit x) => new(double.Log10(x.Value));

    /// <summary>
    /// Log10S the p1.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Log10P1(MetersUnit x) => new(double.Log10P1(x.Value));

    /// <summary>
    /// Log2S the p1.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Log2P1(MetersUnit x) => new(double.Log2P1(x.Value));

    /// <summary>
    /// Logs the p1.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit LogP1(MetersUnit x) => new(double.LogP1(x.Value));

    /// <summary>
    /// Cbrts the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Cbrt(MetersUnit x) => new(double.Cbrt(x.Value));

    /// <summary>
    /// Sqrts the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Sqrt(MetersUnit x) => new(double.Sqrt(x.Value));
    #endregion

    /// <summary>
    /// Bits the decrement.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit BitDecrement(MetersUnit x) => new(double.BitDecrement(x.Value));

    /// <summary>
    /// Bits the increment.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit BitIncrement(MetersUnit x) => new(double.BitIncrement(x.Value));

    /// <summary>
    /// Gets the exponent byte count.
    /// </summary>
    /// <returns>An int.</returns>
    public int GetExponentByteCount() => 2;

    /// <summary>
    /// Gets the exponent shortest bit length.
    /// </summary>
    /// <returns>An int.</returns>
    public int GetExponentShortestBitLength()
    {
        ulong bits = BitConverter.DoubleToUInt64Bits(Value);
        var BiasedExponent = (ushort)((bits >> 52) & 0x7FF);
        short exponent = (short)(BiasedExponent - 1023);
        if (exponent >= 0)
        {
            return 16 - short.LeadingZeroCount(exponent);
        }
        return 17 - short.LeadingZeroCount((short)~exponent);
    }

    /// <summary>
    /// Gets the significand byte count.
    /// </summary>
    /// <returns>An int.</returns>
    public int GetSignificandByteCount() => 8;

    /// <summary>
    /// Gets the significand bit length.
    /// </summary>
    /// <returns>An int.</returns>
    public int GetSignificandBitLength() => 53;

    /// <summary>
    /// Tries the write exponent big endian.
    /// </summary>
    /// <param name="destination">The destination.</param>
    /// <param name="bytesWritten">The bytes written.</param>
    /// <returns>A bool.</returns>
    public bool TryWriteExponentBigEndian(Span<byte> destination, out int bytesWritten) => throw new NotImplementedException();
    //	{
    //		if (destination.Length >= 2)
    //		{
    //			short exponent = Exponent;
    //    _ = BitConverter.IsLittleEndian;
    //			exponent = BinaryPrimitives.ReverseEndianness(exponent);
    //			Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), exponent);
    //			bytesWritten = 2;
    //			return true;
    //		}
    //bytesWritten = 0;
    //		return false;
    //	}

    /// <summary>
    /// Tries the write exponent little endian.
    /// </summary>
    /// <param name="destination">The destination.</param>
    /// <param name="bytesWritten">The bytes written.</param>
    /// <returns>A bool.</returns>
    public bool TryWriteExponentLittleEndian(Span<byte> destination, out int bytesWritten) => throw new NotImplementedException();
    //    	{
    //		if (destination.Length >= 2)
    //		{
    //			short exponent = Exponent;
    //			if (!BitConverter.IsLittleEndian)
    //			{
    //			}
    //			Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), exponent);
    //			bytesWritten = 2;
    //			return true;
    //		}
    //bytesWritten = 0;
    //		return false;
    //	}

    /// <summary>
    /// Tries the write significand big endian.
    /// </summary>
    /// <param name="destination">The destination.</param>
    /// <param name="bytesWritten">The bytes written.</param>
    /// <returns>A bool.</returns>
    public bool TryWriteSignificandBigEndian(Span<byte> destination, out int bytesWritten) => throw new NotImplementedException();
    //    	{
    //		if (destination.Length >= 8)
    //		{
    //			ulong significand = Significand;
    //    _ = BitConverter.IsLittleEndian;
    //			significand = BinaryPrimitives.ReverseEndianness(significand);
    //			Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), significand);
    //			bytesWritten = 8;
    //			return true;
    //		}
    //bytesWritten = 0;
    //		return false;
    //	}

    /// <summary>
    /// Tries the write significand little endian.
    /// </summary>
    /// <param name="destination">The destination.</param>
    /// <param name="bytesWritten">The bytes written.</param>
    /// <returns>A bool.</returns>
    public bool TryWriteSignificandLittleEndian(Span<byte> destination, out int bytesWritten) => throw new NotImplementedException();
    //    	{
    //		if (destination.Length >= 8)
    //		{
    //			ulong significand = Significand;
    //			if (!BitConverter.IsLittleEndian)
    //			{
    //			}
    //			Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), significand);
    //			bytesWritten = 8;
    //			return true;
    //		}
    //bytesWritten = 0;
    //		return false;
    //	}

    /// <summary>
    /// Fuseds the multiply add.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <param name="addend">The addend.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit FusedMultiplyAdd(MetersUnit left, MetersUnit right, MetersUnit addend) => new(double.FusedMultiplyAdd(left.Value, right.Value, addend.Value));

    /// <summary>
    /// Ieee754S the remainder.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Ieee754Remainder(MetersUnit left, MetersUnit right) => new(double.Ieee754Remainder(left.Value, right.Value));

    /// <summary>
    /// Reciprocals the estimate.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit ReciprocalEstimate(MetersUnit x) => new(double.ReciprocalEstimate(x.Value));

    /// <summary>
    /// Reciprocals the sqrt estimate.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit ReciprocalSqrtEstimate(MetersUnit x) => new(double.ReciprocalSqrtEstimate(x.Value));

    /// <summary>
    /// Scales the b.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="n">The n.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit ScaleB(MetersUnit x, int n) => new(double.ScaleB(x.Value, n));

    /// <summary>
    /// Copies the sign.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="sign">The sign.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit CopySign(MetersUnit value, MetersUnit sign) => new(double.CopySign(value.Value, sign.Value));

    /// <summary>
    /// Signs the.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>An int.</returns>
    public static int Sign(MetersUnit value) => double.Sign(value.Value);

    /// <summary>
    /// Abs the.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Abs(MetersUnit value) => new(double.Abs(value.Value));

    #region Queries
    /// <summary>
    /// Are the canonical.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A bool.</returns>
    public static bool IsCanonical(MetersUnit value) => true;

    /// <summary>
    /// Are the complex number.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A bool.</returns>
    public static bool IsComplexNumber(MetersUnit value) => false;

    /// <summary>
    /// Are the even integer.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A bool.</returns>
    public static bool IsEvenInteger(MetersUnit value) => double.IsEvenInteger(value.Value);

    /// <summary>
    /// Are the finite.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A bool.</returns>
    public static bool IsFinite(MetersUnit value) => double.IsFinite(value.Value);

    /// <summary>
    /// Are the imaginary number.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A bool.</returns>
    public static bool IsImaginaryNumber(MetersUnit value) => false;

    /// <summary>
    /// Are the infinity.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A bool.</returns>
    public static bool IsInfinity(MetersUnit value) => double.IsInfinity(value.Value);

    /// <summary>
    /// Are the integer.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A bool.</returns>
    public static bool IsInteger(MetersUnit value) => double.IsInteger(value.Value);

    /// <summary>
    /// Are the na n.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A bool.</returns>
    public static bool IsNaN(MetersUnit value) => double.IsNaN(value.Value);

    /// <summary>
    /// Are the negative.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A bool.</returns>
    public static bool IsNegative(MetersUnit value) => double.IsNegative(value.Value);

    /// <summary>
    /// Are the negative infinity.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A bool.</returns>
    public static bool IsNegativeInfinity(MetersUnit value) => double.IsNegativeInfinity(value.Value);

    /// <summary>
    /// Are the normal.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A bool.</returns>
    public static bool IsNormal(MetersUnit value) => double.IsNormal(value.Value);

    /// <summary>
    /// Are the odd integer.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A bool.</returns>
    public static bool IsOddInteger(MetersUnit value) => double.IsOddInteger(value.Value);

    /// <summary>
    /// Are the positive.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A bool.</returns>
    public static bool IsPositive(MetersUnit value) => double.IsPositive(value.Value);

    /// <summary>
    /// Are the positive infinity.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A bool.</returns>
    public static bool IsPositiveInfinity(MetersUnit value) => double.IsPositiveInfinity(value.Value);

    /// <summary>
    /// Are the real number.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A bool.</returns>
    public static bool IsRealNumber(MetersUnit value) => double.IsRealNumber(value.Value);

    /// <summary>
    /// Are the subnormal.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A bool.</returns>
    public static bool IsSubnormal(MetersUnit value) => double.IsSubnormal(value.Value);

    /// <summary>
    /// Are the zero.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A bool.</returns>
    public static bool IsZero(MetersUnit value) => value.Value == 0;
    #endregion

    #region Trigonometry
    /// <summary>
    /// Sins the cos.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A (Metric Sin, Metric Cos) .</returns>
    public static (MetersUnit Sin, MetersUnit Cos) SinCos(MetersUnit x)
    {
        var v = double.SinCos(x.Value);
        return (new(v.Sin), new(v.Cos));
    }

    /// <summary>
    /// Sins the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Sin(MetersUnit x) => new(double.Sin(x.Value));

    /// <summary>
    /// Cos the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Cos(MetersUnit x) => new(double.Cos(x.Value));

    /// <summary>
    /// Tans the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Tan(MetersUnit x) => new(double.Tan(x.Value));

    /// <summary>
    /// Asins the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Asin(MetersUnit x) => new(double.Asin(x.Value));

    /// <summary>
    /// Acos the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Acos(MetersUnit x) => new(double.Acos(x.Value));

    /// <summary>
    /// Atans the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Atan(MetersUnit x) => new(double.Atan(x.Value));

    /// <summary>
    /// Atan2S the.
    /// </summary>
    /// <param name="y">The y.</param>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Atan2(MetersUnit y, MetersUnit x) => new(double.Atan2(y.Value, x.Value));

    /// <summary>
    /// Asinhs the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Asinh(MetersUnit x) => new(double.Asinh(x.Value));

    /// <summary>
    /// Acoshes the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Acosh(MetersUnit x) => new(double.Acosh(x.Value));

    /// <summary>
    /// Atanhs the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Atanh(MetersUnit x) => new(double.Atanh(x.Value));

    /// <summary>
    /// Sinhs the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Sinh(MetersUnit x) => new(double.Sinh(x.Value));

    /// <summary>
    /// Coshes the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Cosh(MetersUnit x) => new(double.Cosh(x.Value));

    /// <summary>
    /// Tanhs the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static MetersUnit Tanh(MetersUnit x) => new(double.Tanh(x.Value));

    /// <summary>
    /// Acos the pi.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A MetersUnit.</returns>
    public static MetersUnit AcosPi(MetersUnit x) => new(double.AcosPi(x.Value));

    /// <summary>
    /// Asins the pi.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A MetersUnit.</returns>
    public static MetersUnit AsinPi(MetersUnit x) => new(double.AsinPi(x.Value));

    /// <summary>
    /// Atan2S the pi.
    /// </summary>
    /// <param name="y">The y.</param>
    /// <param name="x">The x.</param>
    /// <returns>A MetersUnit.</returns>
    public static MetersUnit Atan2Pi(MetersUnit y, MetersUnit x) => new(double.Atan2Pi(y.Value, x.Value));

    /// <summary>
    /// Atans the pi.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A MetersUnit.</returns>
    public static MetersUnit AtanPi(MetersUnit x) => new(double.AtanPi(x.Value));

    /// <summary>
    /// Cos the pi.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A MetersUnit.</returns>
    public static MetersUnit CosPi(MetersUnit x) => new(double.CosPi(x.Value));

    /// <summary>
    /// Sins the pi.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A MetersUnit.</returns>
    public static MetersUnit SinPi(MetersUnit x) => new(double.SinPi(x.Value));

    /// <summary>
    /// Tans the pi.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A MetersUnit.</returns>
    public static MetersUnit TanPi(MetersUnit x) => new(double.TanPi(x.Value));

    /// <summary>
    /// Hypots the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <returns>A MetersUnit.</returns>
    public static MetersUnit Hypot(MetersUnit x, MetersUnit y) => new(double.Hypot(x.Value, y.Value));

    /// <summary>
    /// Roots the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="n">The n.</param>
    /// <returns>A MetersUnit.</returns>
    public static MetersUnit Root(MetersUnit x, int n) => new(double.Root(x.Value, n));
    #endregion
}
