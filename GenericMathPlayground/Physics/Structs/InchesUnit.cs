// <copyright file="InchesUnit.cs" company="Shkyrockett" >
//     Copyright © 2021 - 2022 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using GenericMathPlayground.Mathematics;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

namespace GenericMathPlayground.Physics;

/// <summary>
/// The standard inch unit.
/// </summary>
[TypeConverter(typeof(LengthUnitConverter<InchesUnit>))]
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public readonly struct InchesUnit
    : ILengthUnit,
    IComparable, IComparable<InchesUnit>, IEquatable<InchesUnit>,
    IConvertible, IFormattable, ISpanFormattable,
    IParsable<InchesUnit>, ISpanParsable<InchesUnit>,
    IAdditiveIdentity<InchesUnit, InchesUnit>, IMultiplicativeIdentity<InchesUnit, InchesUnit>,
    ISignedNumber<InchesUnit>, INumber<InchesUnit>, INumberBase<InchesUnit>, IBinaryNumber<InchesUnit>, IFloatingPoint<InchesUnit>, IFloatingPointIeee754<InchesUnit>, IBinaryFloatingPointIeee754<InchesUnit>,
    ITrigonometricFunctions<InchesUnit>, ILogarithmicFunctions<InchesUnit>, IExponentialFunctions<InchesUnit>, IHyperbolicFunctions<InchesUnit>, IPowerFunctions<InchesUnit>, IRootFunctions<InchesUnit>,
    IBitwiseOperators<InchesUnit, InchesUnit, InchesUnit>, IComparisonOperators<InchesUnit, InchesUnit>, IEqualityOperators<InchesUnit, InchesUnit>, IUnaryNegationOperators<InchesUnit, InchesUnit>, IUnaryPlusOperators<InchesUnit, InchesUnit>, IDecrementOperators<InchesUnit>, IIncrementOperators<InchesUnit>, IAdditionOperators<InchesUnit, InchesUnit, InchesUnit>, ISubtractionOperators<InchesUnit, InchesUnit, InchesUnit>, IMultiplyOperators<InchesUnit, InchesUnit, InchesUnit>, IDivisionOperators<InchesUnit, InchesUnit, InchesUnit>, IModulusOperators<InchesUnit, InchesUnit, InchesUnit>,
    IMinMaxValue<InchesUnit>
{
    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="InchesUnit"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public InchesUnit(double value)
    {
        Value = value;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InchesUnit"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public InchesUnit(ILengthUnit value)
    {
        // Dirty hack to get around not being able to access the InMeters static property on the incoming value.
        var valueInMeters = (double)(value.GetType()?.GetProperty("InMeters")?.GetValue(typeof(double), null) ?? default(double));
        Value = value.Value * (valueInMeters * (1d / InchesUnit.InMeters));
    }
    #endregion

    #region Properties
    /// <summary>
    /// Gets the value.
    /// </summary>
    public double Value { get; }

    /// <summary>
    /// Gets the in meters.
    /// </summary>
    public static double InMeters => 0.0254d;

    /// <summary>
    /// Gets the e.
    /// </summary>
    public static InchesUnit E => new(Math.E);

    /// <summary>
    /// Gets the epsilon.
    /// </summary>
    public static InchesUnit Epsilon => new(double.Epsilon);

    /// <summary>
    /// Gets the na n.
    /// </summary>
    public static InchesUnit NaN => new(double.NaN);

    /// <summary>
    /// Gets the negative infinity.
    /// </summary>
    public static InchesUnit NegativeInfinity => new(double.NegativeInfinity);

    /// <summary>
    /// Gets the negative zero.
    /// </summary>
    public static InchesUnit NegativeZero => new(double.NegativeZero);

    /// <summary>
    /// Gets the pi.
    /// </summary>
    public static InchesUnit Pi => new(double.Pi);

    /// <summary>
    /// Gets the positive infinity.
    /// </summary>
    public static InchesUnit PositiveInfinity => new(double.PositiveInfinity);

    /// <summary>
    /// Gets the tau.
    /// </summary>
    public static InchesUnit Tau => new(double.Tau);

    /// <summary>
    /// Gets the one.
    /// </summary>
    public static InchesUnit One => new(1d);

    /// <summary>
    /// Gets the radix.
    /// </summary>
    public static int Radix => 10;

    /// <summary>
    /// Gets the zero.
    /// </summary>
    public static InchesUnit Zero => new(0d);

    /// <summary>
    /// Gets the additive identity.
    /// </summary>
    public static InchesUnit AdditiveIdentity => new(0d);

    /// <summary>
    /// Gets the multiplicative identity.
    /// </summary>
    public static InchesUnit MultiplicativeIdentity => new(1d);

    /// <summary>
    /// Gets the negative one.
    /// </summary>
    public static InchesUnit NegativeOne => new(-1d);

    /// <summary>
    /// Gets the max value.
    /// </summary>
    public static InchesUnit MaxValue => new(double.MaxValue);

    /// <summary>
    /// Gets the min value.
    /// </summary>
    public static InchesUnit MinValue => new(double.MinValue);
    #endregion

    #region Operators
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(InchesUnit left, InchesUnit right) => left.Equals(right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(InchesUnit left, InchesUnit right) => !(left == right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator <(InchesUnit left, InchesUnit right) => left.CompareTo(right) < 0;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator >(InchesUnit left, InchesUnit right) => left.CompareTo(right) > 0;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator <=(InchesUnit left, InchesUnit right) => left.CompareTo(right) <= 0;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator >=(InchesUnit left, InchesUnit right) => left.CompareTo(right) >= 0;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static InchesUnit operator +(InchesUnit value) => new(+value.Value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static InchesUnit operator -(InchesUnit value) => new(-value.Value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static InchesUnit operator checked -(InchesUnit value) => new(-value.Value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static InchesUnit operator ++(InchesUnit value) => new(value.Value + 1d);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static InchesUnit operator checked ++(InchesUnit value) => new(value.Value + 1d);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static InchesUnit operator --(InchesUnit value) => new(value.Value - 1d);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static InchesUnit operator checked --(InchesUnit value) => new(value.Value - 1d);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static InchesUnit operator +(InchesUnit left, InchesUnit right) => new(left.Value + right.Value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static InchesUnit operator checked +(InchesUnit left, InchesUnit right) => new(left.Value + right.Value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static InchesUnit operator -(InchesUnit left, InchesUnit right) => new(left.Value - right.Value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static InchesUnit operator checked -(InchesUnit left, InchesUnit right) => new(left.Value - right.Value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static InchesUnit operator *(InchesUnit left, InchesUnit right) => new(left.Value * right.Value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static InchesUnit operator checked *(InchesUnit left, InchesUnit right) => new(left.Value * right.Value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static InchesUnit operator /(InchesUnit left, InchesUnit right) => new(left.Value / right.Value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static InchesUnit operator checked /(InchesUnit left, InchesUnit right) => new(left.Value / right.Value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static InchesUnit operator %(InchesUnit left, InchesUnit right) => new(left.Value % right.Value);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static InchesUnit operator &(InchesUnit left, InchesUnit right) => throw new NotImplementedException();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static InchesUnit operator |(InchesUnit left, InchesUnit right) => throw new NotImplementedException();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static InchesUnit operator ^(InchesUnit left, InchesUnit right) => throw new NotImplementedException();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static InchesUnit operator ~(InchesUnit value) => throw new NotImplementedException();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="v"></param>
    public static implicit operator InchesUnit(double v) => new(v);
    #endregion

    #region Comparison Equatable
    /// <summary>
    /// Gets the hash code.
    /// </summary>
    /// <returns>An int.</returns>
    public override int GetHashCode() => HashCode.Combine(Value);

    /// <summary>
    /// Compares the to.
    /// </summary>
    /// <param name="obj">The obj.</param>
    /// <returns>An int.</returns>
    public int CompareTo(object? obj) => obj switch
    {
        null => 1,
        InchesUnit metric => CompareTo(metric),
        double num => Value.CompareTo(num),
        _ => throw new ArgumentException("Object must be double or Metric"),
    };

    /// <summary>
    /// Compares the to.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>An int.</returns>
    public int CompareTo(InchesUnit other) => Value.CompareTo(other.Value);

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="obj">The obj.</param>
    /// <returns>A bool.</returns>
    public override bool Equals(object? obj) => obj is InchesUnit metric && Value == metric.Value;

    /// <summary>
    /// Equals the.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>A bool.</returns>
    public bool Equals(InchesUnit other) => Value.Equals(other.Value);
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
    static bool INumberBase<InchesUnit>.TryConvertFromChecked<TOther>(TOther value, out InchesUnit result)
    {
        return TryConvertFrom(value, out result);
    }

    /// <summary>
    /// Tries the convert from saturating.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="result">The result.</param>
    /// <returns>A bool.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    static bool INumberBase<InchesUnit>.TryConvertFromSaturating<TOther>(TOther value, out InchesUnit result)
    {
        return TryConvertFrom(value, out result);
    }

    /// <summary>
    /// Tries the convert from truncating.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="result">The result.</param>
    /// <returns>A bool.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    static bool INumberBase<InchesUnit>.TryConvertFromTruncating<TOther>(TOther value, out InchesUnit result)
    {
        return TryConvertFrom(value, out result);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TOther"></typeparam>
    /// <param name="value"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private static bool TryConvertFrom<TOther>(TOther value, out InchesUnit result)
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
    static bool INumberBase<InchesUnit>.TryConvertToChecked<TOther>(InchesUnit value, out TOther result)
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
    static bool INumberBase<InchesUnit>.TryConvertToSaturating<TOther>(InchesUnit value, out TOther result)
        where TOther : default
    {
        return TryConvertTo<TOther>(value, out result);
    }

    /// <summary>
    /// Tries the convert to truncating.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="result">The result.</param>
    /// <returns>A bool.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    static bool INumberBase<InchesUnit>.TryConvertToTruncating<TOther>(InchesUnit value, out TOther result)
        where TOther : default
    {
        return TryConvertTo<TOther>(value, out result);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TOther"></typeparam>
    /// <param name="value"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private static bool TryConvertTo<TOther>(InchesUnit value, [NotNullWhen(true)] out TOther result)
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
            float ff = ((float)value.Value);
            result = (TOther)(object)ff;
            return true;
        }
        if (type == typeof(double))
        {
            double dd = ((double)value.Value);
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
    public object ToType(Type conversionType, IFormatProvider? provider) => throw new NotImplementedException();

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
    public string ToString(string? format, IFormatProvider? provider) => $"{Value.ToString(format, provider)} in";

    /// <summary>
    /// Gets the debugger display.
    /// </summary>
    /// <returns>A string.</returns>
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
    public static InchesUnit Parse(ReadOnlySpan<char> s, IFormatProvider? provider) => new(double.Parse(s, provider));

    /// <summary>
    /// Parses the.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="provider">The provider.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Parse(string s, IFormatProvider? provider) => new(double.Parse(s, provider));

    /// <summary>
    /// Parses the.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="style">The style.</param>
    /// <param name="provider">The provider.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider) => new(double.Parse(s, style, provider));

    /// <summary>
    /// Parses the.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="style">The style.</param>
    /// <param name="provider">The provider.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Parse(string s, NumberStyles style, IFormatProvider? provider) => new(double.Parse(s, style, provider));

    /// <summary>
    /// Tries the parse.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="style">The style.</param>
    /// <param name="provider">The provider.</param>
    /// <param name="result">The result.</param>
    /// <returns>A bool.</returns>
    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out InchesUnit result)
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
    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, out InchesUnit result)
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
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out InchesUnit result)
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
    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out InchesUnit result)
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
    public static InchesUnit Min(InchesUnit x, InchesUnit y) => new(Math.Min(x.Value, y.Value));

    /// <summary>
    /// Maxes the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Max(InchesUnit x, InchesUnit y) => new(Math.Max(x.Value, y.Value));

    /// <summary>
    /// Mins the number.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit MinNumber(InchesUnit x, InchesUnit y) => new(double.MinNumber(x.Value, y.Value));

    /// <summary>
    /// Maxes the number.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit MaxNumber(InchesUnit x, InchesUnit y) => new(double.MaxNumber(x.Value, y.Value));

    /// <summary>
    /// Mins the magnitude.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit MinMagnitude(InchesUnit x, InchesUnit y) => new(double.MinMagnitude(x.Value, y.Value));

    /// <summary>
    /// Maxes the magnitude.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit MaxMagnitude(InchesUnit x, InchesUnit y) => new(double.MaxMagnitude(x.Value, y.Value));

    /// <summary>
    /// Mins the magnitude number.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit MinMagnitudeNumber(InchesUnit x, InchesUnit y) => new(double.MinMagnitudeNumber(x.Value, y.Value));

    /// <summary>
    /// Maxes the magnitude number.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit MaxMagnitudeNumber(InchesUnit x, InchesUnit y) => new(double.MaxMagnitudeNumber(x.Value, y.Value));

    /// <summary>
    /// Ceilings the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Ceiling(InchesUnit x) => new(Math.Ceiling(x.Value));

    /// <summary>
    /// Floors the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Floor(InchesUnit x) => new(Math.Floor(x.Value));

    /// <summary>
    /// Clamps the.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="min">The min.</param>
    /// <param name="max">The max.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Clamp(InchesUnit value, InchesUnit min, InchesUnit max) => new(Math.Clamp(value.Value, min.Value, max.Value));

    /// <summary>
    /// Truncates the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Truncate(InchesUnit x) => new(Math.Truncate(x.Value));

    /// <summary>
    /// Rounds the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Round(InchesUnit x) => new(Math.Round(x.Value));

    /// <summary>
    /// Rounds the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="digits">The digits.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Round(InchesUnit x, int digits) => new(Math.Round(x.Value, digits));

    /// <summary>
    /// Rounds the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="mode">The mode.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Round(InchesUnit x, MidpointRounding mode) => new(Math.Round(x.Value, mode));

    /// <summary>
    /// Rounds the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="digits">The digits.</param>
    /// <param name="mode">The mode.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Round(InchesUnit x, int digits, MidpointRounding mode) => new(Math.Round(x.Value, digits, mode));
    #endregion

    #region Exponents Powers Logs Roots
    /// <summary>
    /// Are the pow2.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A bool.</returns>
    public static bool IsPow2(InchesUnit value) => double.IsPow2(value.Value);

    /// <summary>
    /// Pows the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Pow(InchesUnit x, InchesUnit y) => new(Math.Pow(x.Value, x.Value));

    /// <summary>
    /// Exps the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Exp(InchesUnit x) => new(Math.Exp(x.Value));

    /// <summary>
    /// Exp10S the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Exp10(InchesUnit x) => new(Math.Pow(10.0, x.Value));

    /// <summary>
    /// Exp10S the m1.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Exp10M1(InchesUnit x) => new(Math.Pow(10.0, x.Value) - 1d);

    /// <summary>
    /// Exp2S the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Exp2(InchesUnit x) => new(Math.Pow(2.0, x.Value));

    /// <summary>
    /// Exp2S the m1.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Exp2M1(InchesUnit x) => new(Math.Pow(2.0, x.Value) - 1.0);

    /// <summary>
    /// Exps the m1.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit ExpM1(InchesUnit x) => new(Math.Exp(x.Value) - 1.0);

    /// <summary>
    /// IS the log b.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>An int.</returns>
    public static int ILogB(InchesUnit x) => Math.ILogB(x.Value);

    /// <summary>
    /// Logs the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Log(InchesUnit x) => new(Math.Log(x.Value));

    /// <summary>
    /// Logs the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="newBase">The new base.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Log(InchesUnit x, InchesUnit newBase) => new(Math.Log(x.Value, newBase.Value));

    /// <summary>
    /// Log2S the.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Log2(InchesUnit value) => new(Math.Log2(value.Value));

    /// <summary>
    /// Log10S the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Log10(InchesUnit x) => new(Math.Log10(x.Value));

    /// <summary>
    /// Log10S the p1.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Log10P1(InchesUnit x) => new(double.Log10P1(x.Value));

    /// <summary>
    /// Log2S the p1.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Log2P1(InchesUnit x) => new(double.Log2P1(x.Value));

    /// <summary>
    /// Logs the p1.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit LogP1(InchesUnit x) => new(double.LogP1(x.Value));

    /// <summary>
    /// Cbrts the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Cbrt(InchesUnit x) => new(Math.Cbrt(x.Value));

    /// <summary>
    /// Sqrts the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Sqrt(InchesUnit x) => new(Math.Sqrt(x.Value));
    #endregion

    /// <summary>
    /// Bits the decrement.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit BitDecrement(InchesUnit x) => new(Math.BitDecrement(x.Value));

    /// <summary>
    /// Bits the increment.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit BitIncrement(InchesUnit x) => new(Math.BitIncrement(x.Value));

    /// <summary>
    /// Gets the exponent byte count.
    /// </summary>
    /// <returns>An int.</returns>
    public int GetExponentByteCount() => throw new NotImplementedException();

    /// <summary>
    /// Gets the exponent shortest bit length.
    /// </summary>
    /// <returns>An int.</returns>
    public int GetExponentShortestBitLength() => throw new NotImplementedException();

    /// <summary>
    /// Gets the significand byte count.
    /// </summary>
    /// <returns>An int.</returns>
    public int GetSignificandByteCount() => throw new NotImplementedException();

    /// <summary>
    /// Gets the significand bit length.
    /// </summary>
    /// <returns>An int.</returns>
    public int GetSignificandBitLength() => throw new NotImplementedException();

    /// <summary>
    /// Tries the write exponent big endian.
    /// </summary>
    /// <param name="destination">The destination.</param>
    /// <param name="bytesWritten">The bytes written.</param>
    /// <returns>A bool.</returns>
    public bool TryWriteExponentBigEndian(Span<byte> destination, out int bytesWritten) => throw new NotImplementedException();

    /// <summary>
    /// Tries the write exponent little endian.
    /// </summary>
    /// <param name="destination">The destination.</param>
    /// <param name="bytesWritten">The bytes written.</param>
    /// <returns>A bool.</returns>
    public bool TryWriteExponentLittleEndian(Span<byte> destination, out int bytesWritten) => throw new NotImplementedException();

    /// <summary>
    /// Tries the write significand big endian.
    /// </summary>
    /// <param name="destination">The destination.</param>
    /// <param name="bytesWritten">The bytes written.</param>
    /// <returns>A bool.</returns>
    public bool TryWriteSignificandBigEndian(Span<byte> destination, out int bytesWritten) => throw new NotImplementedException();

    /// <summary>
    /// Tries the write significand little endian.
    /// </summary>
    /// <param name="destination">The destination.</param>
    /// <param name="bytesWritten">The bytes written.</param>
    /// <returns>A bool.</returns>
    public bool TryWriteSignificandLittleEndian(Span<byte> destination, out int bytesWritten) => throw new NotImplementedException();

    /// <summary>
    /// Fuseds the multiply add.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <param name="addend">The addend.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit FusedMultiplyAdd(InchesUnit left, InchesUnit right, InchesUnit addend) => new(Math.FusedMultiplyAdd(left.Value, right.Value, addend.Value));

    /// <summary>
    /// Ieee754S the remainder.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Ieee754Remainder(InchesUnit left, InchesUnit right) => new(Math.IEEERemainder(left.Value, right.Value));

    /// <summary>
    /// Reciprocals the estimate.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit ReciprocalEstimate(InchesUnit x) => new(Math.ReciprocalEstimate(x.Value));

    /// <summary>
    /// Reciprocals the sqrt estimate.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit ReciprocalSqrtEstimate(InchesUnit x) => new(Math.ReciprocalSqrtEstimate(x.Value));

    /// <summary>
    /// Scales the b.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="n">The n.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit ScaleB(InchesUnit x, int n) => new(Math.ScaleB(x.Value, n));

    /// <summary>
    /// Copies the sign.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="sign">The sign.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit CopySign(InchesUnit value, InchesUnit sign) => new(double.CopySign(value.Value, sign.Value));

    /// <summary>
    /// Signs the.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>An int.</returns>
    public static int Sign(InchesUnit value) => double.Sign(value.Value);

    /// <summary>
    /// Abs the.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Abs(InchesUnit value) => new(Math.Abs(value.Value));

    #region Queries
    /// <summary>
    /// Are the canonical.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A bool.</returns>
    public static bool IsCanonical(InchesUnit value) => throw new NotImplementedException();

    /// <summary>
    /// Are the complex number.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A bool.</returns>
    public static bool IsComplexNumber(InchesUnit value) => throw new NotImplementedException();

    /// <summary>
    /// Are the even integer.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A bool.</returns>
    public static bool IsEvenInteger(InchesUnit value) => double.IsEvenInteger(value.Value);

    /// <summary>
    /// Are the finite.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A bool.</returns>
    public static bool IsFinite(InchesUnit value) => double.IsFinite(value.Value);

    /// <summary>
    /// Are the imaginary number.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A bool.</returns>
    public static bool IsImaginaryNumber(InchesUnit value) => throw new NotImplementedException();

    /// <summary>
    /// Are the infinity.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A bool.</returns>
    public static bool IsInfinity(InchesUnit value) => double.IsInfinity(value.Value);

    /// <summary>
    /// Are the integer.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A bool.</returns>
    public static bool IsInteger(InchesUnit value) => double.IsInteger(value.Value);

    /// <summary>
    /// Are the na n.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A bool.</returns>
    public static bool IsNaN(InchesUnit value) => double.IsNaN(value.Value);

    /// <summary>
    /// Are the negative.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A bool.</returns>
    public static bool IsNegative(InchesUnit value) => double.IsNegative(value.Value);

    /// <summary>
    /// Are the negative infinity.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A bool.</returns>
    public static bool IsNegativeInfinity(InchesUnit value) => double.IsNegativeInfinity(value.Value);

    /// <summary>
    /// Are the normal.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A bool.</returns>
    public static bool IsNormal(InchesUnit value) => double.IsNormal(value.Value);

    /// <summary>
    /// Are the odd integer.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A bool.</returns>
    public static bool IsOddInteger(InchesUnit value) => double.IsOddInteger(value.Value);

    /// <summary>
    /// Are the positive.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A bool.</returns>
    public static bool IsPositive(InchesUnit value) => double.IsPositive(value.Value);

    /// <summary>
    /// Are the positive infinity.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A bool.</returns>
    public static bool IsPositiveInfinity(InchesUnit value) => double.IsPositiveInfinity(value.Value);

    /// <summary>
    /// Are the real number.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A bool.</returns>
    public static bool IsRealNumber(InchesUnit value) => double.IsRealNumber(value.Value);

    /// <summary>
    /// Are the subnormal.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A bool.</returns>
    public static bool IsSubnormal(InchesUnit value) => double.IsSubnormal(value.Value);

    /// <summary>
    /// Are the zero.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>A bool.</returns>
    public static bool IsZero(InchesUnit value) => value.Value == 0;
    #endregion

    #region Trigonometry
    /// <summary>
    /// Sins the cos.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A (Metric Sin, Metric Cos) .</returns>
    public static (InchesUnit Sin, InchesUnit Cos) SinCos(InchesUnit x) => throw new NotImplementedException();

    /// <summary>
    /// Sins the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Sin(InchesUnit x) => new(Math.Sin(x.Value));

    /// <summary>
    /// Cos the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Cos(InchesUnit x) => new(Math.Cos(x.Value));

    /// <summary>
    /// Tans the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Tan(InchesUnit x) => new(Math.Tan(x.Value));

    /// <summary>
    /// Asins the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Asin(InchesUnit x) => new(Math.Asin(x.Value));

    /// <summary>
    /// Acos the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Acos(InchesUnit x) => new(Math.Acos(x.Value));

    /// <summary>
    /// Atans the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Atan(InchesUnit x) => new(Math.Atan(x.Value));

    /// <summary>
    /// Atan2S the.
    /// </summary>
    /// <param name="y">The y.</param>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Atan2(InchesUnit y, InchesUnit x) => new(Math.Atan2(y.Value, x.Value));

    /// <summary>
    /// Asinhs the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Asinh(InchesUnit x) => new(Math.Asinh(x.Value));

    /// <summary>
    /// Acoshes the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Acosh(InchesUnit x) => new(Math.Acosh(x.Value));

    /// <summary>
    /// Atanhs the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Atanh(InchesUnit x) => new(Math.Atanh(x.Value));

    /// <summary>
    /// Sinhs the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Sinh(InchesUnit x) => new(Math.Sinh(x.Value));

    /// <summary>
    /// Coshes the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Cosh(InchesUnit x) => new(Math.Cosh(x.Value));

    /// <summary>
    /// Tanhs the.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <returns>A Metric.</returns>
    public static InchesUnit Tanh(InchesUnit x) => new(Math.Tanh(x.Value));
    #endregion
}
