﻿// <copyright file="UnitConverter.cs" company="Shkyrockett" >
//     Copyright © 2021 - 2022 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using GenericMathPlayground.Text;
using System.ComponentModel;
using System.Globalization;
using System.Numerics;

namespace GenericMathPlayground.Physics;

/// <summary>
/// Provides a type converter to convert double-precision, floating point number objects
/// to and from various other representations.
/// </summary>
public class LengthUnitConverter<TType>
    : TypeConverter
    where TType : IParsable<TType>, IFloatingPointIeee754<TType>
{
    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="LengthUnitConverter{TType}"/> class.
    /// </summary>
    public LengthUnitConverter()
    { }
    #endregion

    #region Overrides
    /// <summary>
    /// Gets a value indicating whether this converter can convert an object in the
    /// given source type to the TargetType object using the specified context.
    /// </summary>
    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType) => sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);

    /// <summary>
    /// Converts the given value object to an object of Type TargetType.
    /// </summary>
    public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
    {
        if (value is string text)
        {
            text = text.Trim();

            try
            {
                culture ??= CultureInfo.CurrentCulture;
                var formatInfo = (NumberFormatInfo?)culture.GetFormat(typeof(NumberFormatInfo));
                return FromString(text, formatInfo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        return base.ConvertFrom(context, culture, value);
    }

    /// <summary>
    /// Converts the given value object to the destination type.
    /// </summary>
    public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType) => destinationType switch
    {
        null => throw new ArgumentNullException(nameof(destinationType)),
        var _ when destinationType == typeof(string) && value is not null && typeof(TType).IsInstanceOfType(value) => LengthUnitConverter<TType>.ToString(value, (NumberFormatInfo?)(culture ?? CultureInfo.CurrentCulture).GetFormat(typeof(NumberFormatInfo))),
        var d when d.IsPrimitive => Convert.ChangeType(value, d, culture),
        var t when typeof(ILengthUnit).IsAssignableFrom(t) && value is ILengthUnit v => t.GetConstructor(new[] { typeof(double) })?.Invoke(new object[] { UnitConversion.ConvertToUnit(v.Value, typeof(TType), t) }),
        _ => base.ConvertTo(context, culture, value, destinationType),
    };

    /// <summary>
    /// Cans the convert to.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="destinationType">The destination type.</param>
    /// <returns>A bool.</returns>
    public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
    {
        if (destinationType is not null && destinationType.IsPrimitive)
        {
            return true;
        }

        return base.CanConvertTo(context, destinationType);
    }
    #endregion

    /// <summary>
    /// Convert the given value from a string using the given formatInfo
    /// </summary>
    internal static string ToString(object value, NumberFormatInfo? formatInfo) => ((TType)value).ToString("R", formatInfo);

    /// <summary>
    /// Convert the given value to a string using the given formatInfo
    /// </summary>
    internal static TType FromString(string value, NumberFormatInfo? formatInfo)
    {
        var token = TextManipulation.GetFirstWord(value);
        if (token is null)
        {
            return TType.NaN;
        }

        return TType.Parse(token, formatInfo);
    }
}
