// <copyright file="UnitConversion.Rotation.cs" company="Shkyrockett" >
//     Copyright © 2021 - 2022 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

namespace GenericMathPlayground.Physics;

/// <summary>
/// The unit conversion.
/// </summary>
public static partial class UnitConversion
{
    /// <summary>
    /// 
    /// </summary>
    public static readonly Dictionary<Type, double> RadianRotationUnitConversions = new()
    {
        //[typeof(DegreesUnit)] = 180d / Math.PI,
        //[typeof(RadiansUnit)] = 1d,
    };
}
