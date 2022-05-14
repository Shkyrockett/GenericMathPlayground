// <copyright file="ILengthUnit.cs" company="Shkyrockett" >
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
/// The length unit.
/// </summary>
public interface ILengthUnit
{
    /// <summary>
    /// Gets the value.
    /// </summary>
    double Value { get; }

    /// <summary>
    /// Gets the in meters.
    /// </summary>
    static abstract double InMeters { get; }
}
