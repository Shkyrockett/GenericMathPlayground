﻿// <copyright file="AngleConverter.cs" company="Shkyrockett" >
//     Copyright © 2013 - 2022 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks></remarks>

using System.ComponentModel;
using System.Globalization;

namespace GenericMathPlayground.Physics;

/// <summary>
/// AngleConverter
/// </summary>
public class AngleConverter
    : TypeConverter
{
    /// <summary>
    /// Boolean, true if the source type is a string
    /// </summary>
    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType) => sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);

    /// <summary>
    /// The can convert to.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="destinationType">The destinationType.</param>
    /// <returns>The <see cref="bool"/>.</returns>
    public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType) => destinationType == typeof(string) || base.CanConvertTo(context, destinationType);

    /// <summary>
    /// Converts the specified string into an angle.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="culture">The culture.</param>
    /// <param name="value">The value.</param>
    /// <returns>The <see cref="object"/>.</returns>
    /// <exception cref="ArgumentException">Parse failed.</exception>
    public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
    {
        if (value is not string str)
        {
            return base.ConvertFrom(context, culture, value);
        }

        var str2 = str.Trim();
        if (str2.Length == 0)
        {
            return null;
        }

        if (culture is null)
        {
            culture = CultureInfo.CurrentCulture;
        }

        var ch = culture.TextInfo.ListSeparator[0];
        var strArray = str2.Split(new char[] { ch });
        var numArray = new double?[strArray.Length];
        var converter = TypeDescriptor.GetConverter(typeof(double));
        for (var i = 0; i < numArray.Length; i++)
        {
            numArray[i] = converter.ConvertFromString(context, culture, strArray[i]) as double?;
        }

        return numArray.Length != 1 ? throw new ArgumentException("Parse failed.") : numArray[0];
    }

    /// <summary>
    /// Converts the Angle into a string.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="culture">The culture.</param>
    /// <param name="value">The value.</param>
    /// <param name="destinationType">The destinationType.</param>
    /// <returns>The <see cref="object"/>.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
    {
        if (value is double @double)
        {
            if (destinationType == typeof(string))
            {
                var angle = @double;
                if (culture is null)
                {
                    culture = CultureInfo.CurrentCulture;
                }

                var separator = $"{culture.TextInfo.ListSeparator} ";
                var converter = TypeDescriptor.GetConverter(typeof(double));
                var strArray = new string?[2];
                var num = 0;
                strArray[num++] = converter?.ConvertToString(context, culture, angle);
                return string.Join(separator, strArray);
            }
            if (destinationType == typeof(System.ComponentModel.Design.Serialization.InstanceDescriptor))
            {
                var angle2 = @double;
                var constructor = typeof(double).GetConstructor(new Type[] { typeof(double) });
                if (constructor is not null)
                {
                    return new System.ComponentModel.Design.Serialization.InstanceDescriptor(constructor, new object[] { angle2 });
                }
            }
        }

        if (destinationType is null)
        {
            throw new ArgumentNullException(nameof(destinationType));
        }

        return base.ConvertTo(context, culture, value, destinationType);
    }

    /// <summary>
    /// Get the create instance supported.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <returns>The <see cref="bool"/>.</returns>
    public override bool GetCreateInstanceSupported(ITypeDescriptorContext? context) => true;
}
